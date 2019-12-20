﻿using System.Collections.Generic;
using Grpc.Core;

namespace Infrastructure.Interfaces
{
    public interface ICredentialsProvider
    {
        SslCredentials GetSslClientCredentials();
        SslServerCredentials GetSslServerCredentials();
        List<ChannelOption> GetClientChannelOptions(Dictionary<string, string> options);
    }
}
