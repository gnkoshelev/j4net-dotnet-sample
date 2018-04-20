using BenchmarkDotNet.Running;

namespace HashGrpcBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HashGrpcBenchmark>();
        }
    }
}
