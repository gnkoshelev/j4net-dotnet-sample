using Grpc.Core;
using Google.Protobuf;

using HashGrpcServer;

namespace HashGrpcClient
{
    public sealed class HashGrpcClient
    {
        private Channel channel;
        private HashService.HashServiceClient client;
        public void Start()
        {
            channel = new Channel("127.0.0.1:7999", ChannelCredentials.Insecure);
            client = new HashService.HashServiceClient(channel);
        }

        public void Stop()
        {
            if (channel != null)
            {
                channel.ShutdownAsync().Wait();
            }
        }

        public string Compute(string algorithm, byte[] bytes)
        {
            if (client != null)
            {
                var request = new HashRequest
                {
                    Algorithm = algorithm,
                    Bytes = ByteString.CopyFrom(bytes)
                };

                var response = client.Compute(request);

                return response.Hash;
            }
            else
            {
                throw new System.Exception("Client has not been started");
            }
            
        }
    }
}
