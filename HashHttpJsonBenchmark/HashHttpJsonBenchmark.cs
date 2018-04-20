using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashHttpJsonBenchmark
{
    [ClrJob(isBaseline: true)]
    public class HashHttpJsonBenchmark
    {
        private HashHttpJsonClient.HashHttpJsonClient client;
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
            client = new HashHttpJsonClient.HashHttpJsonClient();
        }

        [Benchmark]
        public async Task<string> Compute() => await client.Compute(algorithm, data);

    }
}
