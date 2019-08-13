using System;

namespace ZoEazy.Api.Model
{
    public class BearerToken
    {
        public BearerToken()
        {
        }

        public BearerToken(DateTime requestAt, DateTime expiresIn, string type, string accessToken)
        {
            RequestAt = requestAt;
            ExpiresIn = expiresIn;
            Type = type;
            AccessToken = accessToken;
        }

        public DateTime RequestAt { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string Type { get; set; }
        public string AccessToken { get; set; }

    }
}