
using System.Collections.Concurrent;
using System.Diagnostics;

var n = 1000000000;
var list = new GuIdHolder[n];
var watch = new Stopwatch();
var maxthread = 0;
ThreadPool.GetMaxThreads(out maxthread, out int a);
var options = new ParallelOptions()
{
    MaxDegreeOfParallelism = maxthread / 100

};
watch.Start();
var firstTask =Task.Factory.StartNew(() => Parallel.For(0, n/3, options, i => list[i] = new GuIdHolder(Guid.NewGuid())));
var secendTask =Task.Factory.StartNew(() => Parallel.For((n/3)+1, (n/3)*2, options, i => list[i] = new GuIdHolder(Guid.NewGuid())));
var thirdTask =Task.Factory.StartNew(() => Parallel.For(((n / 3) * 2)+1, n, options, i => list[i] = new GuIdHolder(Guid.NewGuid())));
Task.WaitAll(firstTask,secendTask,thirdTask);
//old way
//Parallel.For(0, n, options, i => list[i] = new GuIdHolder(Guid.NewGuid()));
watch.Stop();
var time = watch.Elapsed;
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine($"Time :{time.Hours}:{time.Minutes}:{time.Seconds}");
Console.WriteLine($"List's Count :{list.Length}\nType of list's item : class");
Console.WriteLine("-----------------------------------------------------");

























void Go()
{
    Process Proc = Process.GetCurrentProcess();
    long AffinityMask = (long)Proc.ProcessorAffinity;

}
public struct GuIdHolder
{
    private readonly Guid id;
    public GuIdHolder(Guid id)
    {

        this.id = id;

    }
}