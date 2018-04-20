using System;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

using HashProxy;

namespace HashProxyBenchmark
{
    [ClrJob(isBaseline: true)]
    public class HashProxyBenchmark
    {
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
        }

        [Benchmark]
        public string Compute() => HasherProxy.Compute(algorithm, data);
    }
}
