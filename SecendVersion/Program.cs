using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

var size = 200000000;
var structure = Channel.CreateUnbounded<GuIdHolder>();
var watch = new Stopwatch();
watch.Start();
for (int i = 0; i < size; i++)
{
  await  structure.Writer.WriteAsync(new GuIdHolder(Guid.NewGuid()));
}
watch.Stop();
var time = watch.Elapsed;
Console.WriteLine($"Time :{time.Hours}:{time.Minutes}:{time.Seconds}");

public struct GuIdHolder
{
    public readonly Guid id;
    public GuIdHolder(Guid id)
    {

        this.id = id;

    }
}