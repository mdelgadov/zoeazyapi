using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;

namespace ZoEazy.Api.Model
{
    public class TokenAuthOption
    {
        public  string Authority { get; } = "MyAutorhity";
        public  string Audience { get; } = "MyAudience";
        public  string Issuer { get; } = "MyIssuer";
        public  bool RequireHttpsMetadata { get; } = false;
        public  X509SecurityKey Key { get; set; }
        public  X509Certificate2 Cert { get; set; }
        // public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());

        public  SigningCredentials SigningCredentials { get; set; }
        public  TimeSpan ExpiresSpan { get; } = TimeSpan.FromHours(15);
        public  string TokenType { get; } = "Bearer";
        public  bool AutomaticAuthenticate { get; } = true;
        public bool ValidateIssuerSigningKey { get;  }= true;
        public bool RequireSignedTokens { get; } = true;
        public bool ValidateLifetime { get; } = true;
        public TimeSpan ClockSkew { get; } = TimeSpan.FromMinutes(0);
        public TokenAuthOption()
        {
            Cert = GetCertificateFromStore("CN=localhost");
            using (var xCert = new X509Certificate2(Cert))
            {
                Key = new X509SecurityKey(xCert);
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
            }
        }
        private static X509Certificate2 GetCertificateFromStore(string certName)
        {

            // Get the certificate store for the current user.
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                if (signingCert.Count == 0)
                    return null;
                // Return the first certificate in the collection, has the right name and is current.
                return signingCert[0];
            }
            finally
            {
                store.Close();
            }

        }

    }
}