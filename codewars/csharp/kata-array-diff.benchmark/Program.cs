using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<MineVsSolution>();

public class MineVsSolution
{
    private const int N = 10000;
    private const int M = 1000;
    private readonly int[] data;
    private readonly int[] toRemove;

    public MineVsSolution()
    {
        var r = new Random();
        data = (new int[N]).Select(x => r.Next(0, N)).ToArray();
        toRemove = (new int[M]).Select(x => r.Next(0, M)).ToArray();
    }

    [Benchmark]
    public int[] Mine() => kata_array_diff.lib.Kata.ArrayDiff(data, toRemove);

    [Benchmark]
    public int[] Solution() => kata_array_diff.lib.Others.SolutionArrayDiff(data, toRemove);

    [Benchmark]
    public int[] ArrayContains() => kata_array_diff.lib.Others.ArrayContainsArrayDiff(data, toRemove);

    [Benchmark]
    public int[] ArrayFindAll() => kata_array_diff.lib.Others.FindAllArrayDiff(data, toRemove);
}