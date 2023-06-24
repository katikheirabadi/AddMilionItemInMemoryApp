using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

var structure = new BufferBlock<GuIdHolder>();
var size = 500000000;
var watch = new Stopwatch();
watch.Start();
Parallel.For(0, size, i => structure.Post(new GuIdHolder(new Guid())));
watch.Stop();
var time = watch.Elapsed;
Console.WriteLine($"Time :{time.Hours}:{time.Minutes}:{time.Seconds}");

public struct GuIdHolder
{
    private readonly Guid id;
    public GuIdHolder(Guid id)
    {

        this.id = id;

    }
}