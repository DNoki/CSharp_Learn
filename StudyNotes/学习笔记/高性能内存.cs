using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class 高性能内存
{
    public void TestRun()
    {
        // https://www.cnblogs.com/justmine/p/10006621.html
        var span = new Span<byte>();
        var readOnlySpan = new ReadOnlySpan<byte>();
        var memory = new Memory<byte>();
        var readOnlyMemory = new ReadOnlyMemory<byte>();
    }
}