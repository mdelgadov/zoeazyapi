﻿using System.Security.Cryptography.X509Certificates;

namespace ZoEazy.Api.STS.Services.Certificate
{
    public interface ICertificateService
    {
        X509Certificate2 GetCertificateFromKeyVault(string vaultCertificateName);
    }
}