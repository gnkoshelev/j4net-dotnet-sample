using BenchmarkDotNet.Running;

namespace HashProxyBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HashProxyBenchmark>();
        }
    }
}
