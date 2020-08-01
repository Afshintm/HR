using System.Linq;
using Newtonsoft.Json.Linq;

namespace HR.Api.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static JObject ToLowerCase(this JObject jsonObject)
        {
            if (jsonObject == null) return null;
            foreach (var property in jsonObject.Properties().ToList())
            {
                if (property.Value.Type == JTokenType.Object)
                    ((JObject) property.Value).ToLowerCase();

                if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var subItem in property.Value.Children<JObject>())
                    {
                        subItem.ToLowerCase();
                    }
                }

                property.Replace(new JProperty(property.Name.ToLower(),property.Value));
            }
            return jsonObject;
        }
    }
}