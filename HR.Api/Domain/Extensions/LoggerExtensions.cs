using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HR.Api.Domain.Extensions
{
    public static class LoggerExtensions
    {
        //private static readonly IJObjectCaseReplacement _caseReplacement = new JObjectCaseReplacement();
        private const string replacement = "--sanitized--";
        private static readonly string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static readonly bool isProd
            = string.IsNullOrEmpty(environment)
              || string.Compare(environment, "Production", StringComparison.InvariantCultureIgnoreCase) == 0;


        private static readonly Regex BearerStripper = new Regex(
            @"^(.*?)([Bb]earer\s{1,}[^\s\\""]*)(.*?)$",
            RegexOptions.Compiled
        );

        private static readonly Regex EmailPattern = new Regex(
            @"[^/=]+@[^/=]+",
            RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromMilliseconds(250));


        private static string[] prefixes = new[]
        {
            "",
            "task."
        };

        public static readonly IReadOnlyList<string> SuppressedFieldNames = new ReadOnlyCollection<string>(new string[]
            {
                "Abn",
                "AbnLabel",
                "AccessToken",
                "AccountName",
                "AccountNumber",
                "Acn",
                "Address",
                "Addresses",
                "AgentAbn",
                "AgentName",
                "AgentReferenceNumber",
                "Arbn",
                "AssignedBy",
                "AssignedUsers",
                "AssignedTo",
                "AustralianBusinessNumber",
                "Authorization",
                "AuthToken",
                "BankDetails",
                "Branch",
                "Bsb",
                "ClientName",
                "ClientReference",
                "CompanyName",
                "ContactName",
                "ContactName2",
                "ContactName3",
                "CreatedBy",
                "CurrentPostalAddressLine1",
                "CurrentPostalAddressLine2",
                "DateOfBirth",
                "DaytimeContactNumber",
                "DaytimeContactNumberAreaCode",
                "Description",
                "DisplayName",
                "Email",
                "Emails",
                "Files",
                "FirstName",
                "FromEmail",
                "FromFullName",
                "FullName",
                "Initials",
                "LastName",
                "MainBusinessAddressLine1",
                "MainBusinessAddressLine2",
                "MainBusinessAddressSuburb",
                "MiddleName",
                "OrganisationName",
                "Phone",
                "Phones",
                "PlaceOfBirth",
                "PreviousName",
                "PreviousNameYesNo",
                "PreviousPostalAddressLine1",
                "PreviousPostalAddressLine2",
                "ProxySecret",
                "Reference",
                "Sex",
                "TaskReferenceName",
                "Tfn",
                "Title",
                "UpdatedBy",
                "UserName",
                "Users",
                "WatchList",
                "WebsiteAddresses",
                "x-api-key"
                
            }
            .Select(x => x.ToLower())
            .Distinct()
            .ToArray());

        private static readonly ImmutableSortedSet<string> DiscardFieldNames = ImmutableSortedSet.Create(
            StringComparer.InvariantCultureIgnoreCase,
            "X-NewRelic-App-Data",
            "Strict-Transport-Security",
            "Server",
            "Connection",
            "Transfer-Encoding",
            "Date"
        );


        private static string ToSafeData(this ILogger logger, object data)
        {
            if (data == null) return string.Empty;

            try
            {
                // var contentAsString = JsonConvert.SerializeObject(data,
                //     Formatting.None,
                //     new JsonSerializerSettings
                //     {
                //         ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //     });
                var contentAsString = JsonConvert.SerializeObject(data, Formatting.None,
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

                return TryRemoveSensitiveData(contentAsString);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception cleaning data in ToSafeDataLog: {ex.Message}");
                return "Failed to Sanitize data";
            }
        }

        public static string ToSafeData(this ILogger logger, string data)
        {
            try
            {
                return TryRemoveSensitiveData(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception cleaning data in ToSafeDataLog: {ex.Message}");
                return "Failed to Sanitize data";
            }
        }

        public static object ToSafeDataLog<T>(this ILogger logger, object data)
            where T : class
        {
            return ToSafeData(logger, data);
        }

        public static object ToSafeDataLog<T>(this ILogger logger, string data)
            where T : class
        {
            return ToSafeData(logger, data);
        }

        private static string RemoveSensitiveData(string contentAsString) =>
            string.IsNullOrWhiteSpace(contentAsString)
                ? contentAsString
                : JObject.Parse(CleanPlainTextAuthTokenValues(contentAsString)).ToLowerCase()
                    .Sanatize()
                    .ToString();

        private static string TryRemoveSensitiveData(string contentAsString) =>
            Try((str) => RemoveSensitiveData(str), contentAsString);

        private static string Try(Func<string, string> func, string str)
        {
            try
            {
                return func.Invoke(str);
            }
            catch (Exception)
            {
                return isProd ? replacement : str;
            }
        }

        private static JObject Sanatize(this JObject obj)
        {
            foreach (var prefix in prefixes)
            {
                foreach (var suppressedFieldName in SuppressedFieldNames)
                {
                    obj
                        .SelectTokens($"..{prefix}{suppressedFieldName.ToLower()}")
                        .ToList()
                        .ForEach(token => token.Replace("--Sanitized--"));
                }
            }

            return obj;
        }

        public static string RemoveSensitiveQueryParamFromUrl(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? url : StripQueryParamFromUrl(url, SuppressedFieldNames.ToArray());
        }

        public static string CleanPlainTextAuthTokenValues(string data)
        {
            return BearerStripper.Replace(data, "$1--Bearer token--$3");
        }


        private static string StripQueryParamFromUrl(string url, params string[] keys)
        {
            var filteredUrl = EmailPattern.Replace(url, replacement);

            Uri.TryCreate(filteredUrl, UriKind.Absolute, out var uri);
            if (uri == null) return filteredUrl;

            // this gets all the query string key value pairs as a collection
            var newQueryString = HttpUtility.ParseQueryString(uri.Query);
            foreach (var key in keys)
            {
                // this sanitize the key if exists
                if (newQueryString.AllKeys.Contains(key, StringComparer.InvariantCultureIgnoreCase))
                {
                    newQueryString[key] = replacement;
                }
            }

            // this gets the page path from root without QueryString
            var pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            return newQueryString.Count > 0
                ? $"{pagePathWithoutQueryString}?{newQueryString}"
                : pagePathWithoutQueryString;
        }

        public static IEnumerable<KeyValuePair<string, string>> SanatizeHeaders(
            this IEnumerable<KeyValuePair<string, string>> input
        ) =>
            from kvp in input
            where !DiscardFieldNames.Contains(kvp.Key)
            let expectedValue = SuppressedFieldNames.Contains(kvp.Key.ToLower()) ? replacement : kvp.Value
            select KeyValuePair.Create(kvp.Key, expectedValue);
    }
}