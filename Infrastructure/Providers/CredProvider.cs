﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;

namespace Infrastructure.Providers
{
    public class CredProvider : ICredentialsProvider
    {
        public SslCredentials GetSslClientCredentials()
        {
            var certificatePath = Path.Combine(Environment.CurrentDirectory, Defines.CertificatesFolderName);

            var caCert = File.ReadAllText(Path.Combine(certificatePath, Defines.CaCertificateName));
            var cert = File.ReadAllText(Path.Combine(certificatePath, Defines.ClientCertificateName));
            var key = File.ReadAllText(Path.Combine(certificatePath, Defines.ClientCertificateKeyName));
            var keyPair = new KeyCertificatePair(cert, key);
            var credentials = new SslCredentials(caCert, keyPair);
            return credentials;
        }

        public SslServerCredentials GetSslServerCredentials()
        {
            var certsFolder = Path.Combine(Environment.CurrentDirectory, Defines.CertificatesFolderName);
            var caCert = File.ReadAllText(Path.Combine(certsFolder, Defines.CaCertificateName));
            var cert = File.ReadAllText(Path.Combine(certsFolder, Defines.ServerCertificateName));
            var key = File.ReadAllText(Path.Combine(certsFolder, Defines.ServerCertificateKeyName));

            var certificateCollection = new List<KeyCertificatePair>
            {
                new KeyCertificatePair(cert, key)
            };

            var serverCredentials = new SslServerCredentials(certificateCollection, caCert, SslClientCertificateRequestType.RequestAndRequireButDontVerify);
            return serverCredentials;
        }
    }
}