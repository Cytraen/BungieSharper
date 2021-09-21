using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;

namespace BungieSharper.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, DefaultConfig.Instance);
        }
    }
}