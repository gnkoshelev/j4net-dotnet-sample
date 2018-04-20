using System;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace HashGrpcBenchmark
{
    [ClrJob(isBaseline: true)]
    public class HashGrpcBenchmark
    {
        private HashGrpcClient.HashGrpcClient client;
        private string algorithm;
        private byte[] data;

        [Params(5000, 50000, 500000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            algorithm = "SHA-512";
            data = new byte[N];
            new Random(12345).NextBytes(data);
            client = new HashGrpcClient.HashGrpcClient();
            client.Start();
        }

        [Benchmark]
        public string Compute() => client.Compute(algorithm, data);
    }
}
