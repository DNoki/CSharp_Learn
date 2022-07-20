using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

/// <summary> 压缩算法实用类 </summary>
public static class CompressUtility
{
    public static byte[] ZipCompress(byte[] data, CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, compressionLevel))
                gs.Write(data, 0, data.Length);

            return mso.ToArray();
        }
    }

    public static byte[] ZipDecompress(byte[] bytes)
    {
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }
            return mso.ToArray();
        }
    }

    public static byte[] BrotliCompress(byte[] data, CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        using (var mso = new MemoryStream())
        {
            using (var gs = new BrotliStream(mso, compressionLevel))
                gs.Write(data, 0, data.Length);

            return mso.ToArray();
        }
    }

    public static byte[] BrotliDecompress(byte[] bytes)
    {
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new BrotliStream(msi, CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }
            return mso.ToArray();
        }
    }

    public static void TestRun()
    {
        var data = new byte[1024 * 1024];
        var random = new Random();

        for (var i = 0; i < 1024; i++)
        {
            data.AsSpan().Slice(i * 1024, 1024).Fill((byte)random.Next());
        }

        for (var i = 0; i < 2; i++)
        {
            var result = CompressUtility.BrotliCompress(data, (System.IO.Compression.CompressionLevel)i);

            Console.WriteLine($"Brotli压缩前：{data.Length / 1024.0f}K，压缩后：{result.Length / 1024.0f}K");

            var decompressed = CompressUtility.BrotliDecompress(result);

            if (decompressed.Length != data.Length ||
                decompressed[0] != data[0] ||
               decompressed[^1] != data[^1])
            {
                Console.WriteLine("数据不同！");
            }
            Console.WriteLine("");
        }
        for (var i = 0; i < 2; i++)
        {
            var result = CompressUtility.ZipCompress(data, (System.IO.Compression.CompressionLevel)i);

            Console.WriteLine($"Zip压缩前：{data.Length / 1024.0f}K，压缩后：{result.Length / 1024.0f}K");

            var decompressed = CompressUtility.ZipDecompress(result);

            if (decompressed.Length != data.Length ||
                decompressed[0] != data[0] ||
               decompressed[^1] != data[^1])
            {
                Console.WriteLine("数据不同！");
            }
            Console.WriteLine("");
        }
    }
}