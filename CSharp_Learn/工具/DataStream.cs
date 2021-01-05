using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>
/// 数据处理流
/// </summary>
public class DataStream
{
    private readonly Stream _stream = null;
    private readonly BinaryReader _reader = null;
    private readonly BinaryWriter _writer = null;

    public Stream Stream => _stream;
    public byte this[int index]
    {
        get
        {
            var position = _stream.Position;
            _stream.Position = index;
            var result = ReadByte();
            _stream.Position = position;
            return result;
        }
    }

    public void ResetPosition() => _stream.Position = 0;
    public void Clear()
    {
        _stream.SetLength(0);
        ResetPosition();
    }
    public byte[] ToArray()
    {
        var position = _stream.Position;
        ResetPosition();
        var result = _reader.ReadBytes(Convert.ToInt32(_stream.Length));
        _stream.Position = position;
        return result;
    }

    #region DefaultMethod
    public void Write(ulong value) => _writer.Write(value);
    public void Write(uint value) => _writer.Write(value);
    public void Write(ushort value) => _writer.Write(value);
    public void Write(string value) => _writer.Write(value);
    public void Write(float value) => _writer.Write(value);
    public void Write(sbyte value) => _writer.Write(value);
    public void Write(long value) => _writer.Write(value);
    public void Write(int value) => _writer.Write(value);
    public void Write(short value) => _writer.Write(value);
    public void Write(decimal value) => _writer.Write(value);
    public void Write(char[] chars, int index, int count) => _writer.Write(chars, index, count);
    public void Write(char[] chars) => _writer.Write(chars);
    public void Write(byte[] buffer, int index, int count) => _writer.Write(buffer, index, count);
    public void Write(byte[] buffer) => _writer.Write(buffer);
    public void Write(byte value) => _writer.Write(value);
    public void Write(bool value) => _writer.Write(value);
    public void Write(double value) => _writer.Write(value);
    public void Write(char ch) => _writer.Write(ch);

    public int Read(byte[] buffer, int index, int count) => _reader.Read(buffer, index, count);
    public int Read(char[] buffer, int index, int count) => _reader.Read(buffer, index, count);
    public bool ReadBoolean() => _reader.ReadBoolean();
    public byte ReadByte() => _reader.ReadByte();
    public byte[] ReadBytes(int count) => _reader.ReadBytes(count);
    public char ReadChar() => _reader.ReadChar();
    public char[] ReadChars(int count) => _reader.ReadChars(count);
    public decimal ReadDecimal() => _reader.ReadDecimal();
    public double ReadDouble() => _reader.ReadDouble();
    public short ReadInt16() => _reader.ReadInt16();
    public int ReadInt32() => _reader.ReadInt32();
    public long ReadInt64() => _reader.ReadInt64();
    public sbyte ReadSByte() => _reader.ReadSByte();
    public float ReadSingle() => _reader.ReadSingle();
    public string ReadString() => _reader.ReadString();
    public ushort ReadUInt16() => _reader.ReadUInt16();
    public uint ReadUInt32() => _reader.ReadUInt32();
    public ulong ReadUInt64() => _reader.ReadUInt64();
    #endregion

    public void Write<T>(in T value) where T : unmanaged
    {
        var type = typeof(T);
        int size = type.IsEnum
            ? Marshal.SizeOf(type.GetEnumUnderlyingType())
            : Marshal.SizeOf(type);
        GCHandle handle = type.IsEnum
            ? GCHandle.Alloc(Convert.ChangeType(value, type.GetEnumUnderlyingType()), GCHandleType.Pinned)
            : GCHandle.Alloc(value, GCHandleType.Pinned);
        var bytes = new byte[size];
        Marshal.Copy(handle.AddrOfPinnedObject(), bytes, 0, size);
        handle.Free();
        _writer.Write(bytes);
    }
    public T Read<T>() where T : unmanaged
    {
        var type = typeof(T);
        int size = Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
        var bytes = _reader.ReadBytes(size);
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        var result = type.IsEnum
            ? (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), type.GetEnumUnderlyingType())
            : Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
        handle.Free();
        return result;
    }
    public unsafe void WriteArray<T>(T[] array) where T : unmanaged
    {
        _writer.Write(array.Length);
        if (array.Length == 0) return;

        var type = typeof(T);
        var size = array.Length * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
        var bytes = new byte[size];
        fixed (void* ptr = array)
        {
            Marshal.Copy((IntPtr)ptr, bytes, 0, size);
        }
        //var handle = GCHandle.Alloc(array, GCHandleType.Pinned);
        //Marshal.Copy(handle.AddrOfPinnedObject(), bytes, 0, size);
        //handle.Free();
        _writer.Write(bytes);
    }
    public unsafe T[] ReadArray<T>() where T : unmanaged
    {
        var array = new T[_reader.ReadInt32()];
        if (array.Length == 0) return array;

        var type = typeof(T);
        var size = array.Length * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
        var bytes = _reader.ReadBytes(size);
        fixed (void* ptr = array)
        {
            Marshal.Copy(bytes, 0, (IntPtr)ptr, size);
        }
        //var handle = GCHandle.Alloc(array, GCHandleType.Pinned);
        //Marshal.Copy(bytes, 0, handle.AddrOfPinnedObject(), size);
        //handle.Free();
        return array;
    }

    public unsafe void WriteDictionary<TKey, TValue>(IDictionary<TKey, TValue> dic) where TKey : unmanaged where TValue : unmanaged
    {
        _writer.Write(dic.Count);
        if (dic.Count == 0) return;

        {
            var keys = dic.Keys.ToArray();
            var type = typeof(TKey);
            var size = keys.Length * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
            var bytes = new byte[size];
            fixed (void* ptr = keys)
            {
                Marshal.Copy((IntPtr)ptr, bytes, 0, size);
            }
            _writer.Write(bytes);
        }
        {
            var value = dic.Values.ToArray();
            var type = typeof(TValue);
            var size = value.Length * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
            var bytes = new byte[size];
            fixed (void* ptr = value)
            {
                Marshal.Copy((IntPtr)ptr, bytes, 0, size);
            }
            _writer.Write(bytes);
        }
    }
    public unsafe Dictionary<TKey, TValue> ReadDictionary<TKey, TValue>() where TKey : unmanaged where TValue : unmanaged
    {
        var dic = new Dictionary<TKey, TValue>();
        var count = _reader.ReadInt32();
        if (count == 0) return dic;

        var keys = new TKey[count];
        var values = new TValue[count];
        {
            var type = typeof(TKey);
            var size = count * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
            var bytes = _reader.ReadBytes(size);
            fixed (void* ptr = keys)
            {
                Marshal.Copy(bytes, 0, (IntPtr)ptr, size);
            }
        }
        {
            var type = typeof(TValue);
            var size = count * Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
            var bytes = _reader.ReadBytes(size);
            fixed (void* ptr = values)
            {
                Marshal.Copy(bytes, 0, (IntPtr)ptr, size);
            }
        }
        for (int i = 0; i < count; i++)
            dic.Add(keys[i], values[i]);

        return dic;
    }

    public DataStream()
    {
        _stream = new MemoryStream();
        _reader = new BinaryReader(_stream);
        _writer = new BinaryWriter(_stream);
    }
    ~DataStream()
    {
        _writer.Dispose();
        _reader.Dispose();
        _stream.Dispose();
    }
}