using System.Collections.Generic;
using System.IO;
using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;

namespace Infrastructure.Providers
{
    public class CredProvider : ICredentialsProvider
    {
        public SslCredentials GetSslClientCredentials()
        {
            var caCert = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.CaCertificateName));
            var cert = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.ClientCertificateName));
            var key = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.ClientCertificateKeyName));
            var keyPair = new KeyCertificatePair(cert, key);
            var credentials = new SslCredentials(caCert, keyPair);
            return credentials;
        }

        public SslServerCredentials GetSslServerCredentials()
        {
            var caCert = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.CaCertificateName));
            var cert = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.ServerCertificateName));
            var key = File.ReadAllText(Path.Combine(Defines.CertFolderPath, Defines.ServerCertificateKeyName));

            var certificateCollection = new List<KeyCertificatePair>
            {
                new KeyCertificatePair(cert, key)
            };

            var serverCredentials = new SslServerCredentials(certificateCollection, caCert, SslClientCertificateRequestType.RequestAndRequireButDontVerify);
            return serverCredentials;
        }
    }
}
