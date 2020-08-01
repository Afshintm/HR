namespace HR.Api.Domain.Constants
{
        public static class LoggerConstants
        {
            public const string DefaultMessageTemplate = "RequestId: {@requestId}, TenantId: {@tenantId}, ClientId: {@clientId}";

            public const string DefaultMessageTemplateWithBody = "RequestId: {@requestId}, TenantId: {@tenantId}, ClientId: {@clientId}, Body: {@body}";

            
        }
   
}