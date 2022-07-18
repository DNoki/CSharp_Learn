using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

public static class ZipUtility
{
    public static byte[] Compression(byte[] data)
    {
        using var streamMemory = new MemoryStream();
        using var compressor = new GZipStream(streamMemory, CompressionMode.Compress);
        compressor.Write(data, 0, data.Length);
        return streamMemory.ToArray();
    }
    public static byte[] Decompression(byte[] data)
    {
        throw new NotImplementedException();
    }
}