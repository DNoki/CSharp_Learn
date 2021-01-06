using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 排列公式
/// </summary>
/// <typeparam name="T"></typeparam>
public class Arrangement<T>
{
    //排列的定义：从n个不同元素中，任取m(m≤n,m与n均为自然数,下同）个元素按照一定的顺序排成一列，叫做从n个不同元素中取出m个元素的一个排列；从n个不同元素中取出m(m≤n）个元素的所有排列的个数，叫做从n个不同元素中取出m个元素的排列数，用符号 A(n,m）表示。
    //排列公式A(m,n) = n(n-1)(n-2)…(n-m+1) = n!/(n-m)!       
    /// <summary>
    /// 正排列公式
    /// </summary>
    /// <param name="m">取出的元素数量</param>
    /// <returns></returns>
    public static int GetArrangement(int m)
    {
        if (m == 0) return 1;// 0 的排列定义为1
        int v = 1;
        for (int i = 0; i < m; i++)
        {
            v *= (i + 1);
        }
        return v;
    }
    /// <summary>
    /// 排列公式
    /// </summary>
    /// <param name="m">取出的元素数量</param>
    /// <param name="n">元素总数</param>
    /// <returns></returns>
    public static int GetArrangement(int m, int n)
    {
        if (m > n) return 0;
        else if (m < 0 || n < 0) return 0;
        return Arrangement<T>.GetArrangement(n) / Arrangement<T>.GetArrangement(n - m);
    }

    /// <summary>
    /// 成员索引
    /// </summary>
    public struct IndexStruct
    {
        public int Index;
        public T Data;
        public static bool operator >(IndexStruct a, IndexStruct b)
        { return a.Index > b.Index; }
        public static bool operator <(IndexStruct a, IndexStruct b)
        { return a.Index < b.Index; }



        public IndexStruct(T data, int index)
        {
            Data = data;
            Index = index;
        }
    }
    /// <summary>
    /// 根据索引取得数据
    /// </summary>
    /// <param name="members"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static T GetData(List<IndexStruct> members, int index)
    {
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].Index == index)
            {
                return members[i].Data;
            }
        }
        return default(T);
    }

    /// <summary>
    /// 包含元素
    /// </summary>
    public List<IndexStruct> Members { get; set; }
    /// <summary>
    /// 元素数量(n)
    /// </summary>
    public int Count { get { return Members.Count; } }
    /// <summary>
    /// 取出元素数量(m)
    /// </summary>
    public int TakeQuantity { get; set; }
    /// <summary>
    /// 取得索引位置的数据
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T this[int i] { get { return GetData(this.Members, i); } }

    /// <summary>
    /// 获取一组按照索引顺序的排列
    /// </summary>
    /// <param name="indexMembers">索引顺序</param>
    /// <returns></returns>
    public List<T> GetArrangementData(List<int> indexMembers)
    {
        if (indexMembers.Count != Count) return null;
        var list = new List<T>();
        foreach (var index in indexMembers)
        {
            list.Add(this[index]);
        }
        return list;
    }

    /// <summary>
    /// 包含索引
    /// </summary>
    public static List<int> IndexMembers(List<IndexStruct> members)
    {
        List<int> indexarray = new List<int>();
        foreach (var value in members)
        {
            indexarray.Add(value.Index);
        }
        return indexarray;
    }

    /// <summary>
    /// 获取全排列
    /// </summary>
    /// <param name="members">排列数据</param>
    /// <returns></returns>
    public static List<List<int>> Perm(List<IndexStruct> members)
    {
        List<List<int>> indexArray = new List<List<int>>();// 得到的所有排列
                                                           //List<int> data = new List<int>() {4, 3, 2, 1 };
                                                           //Perm(data,0,3, ref indexArray);
        Perm(IndexMembers(members), 0, members.Count, ref indexArray);
        return indexArray;
    }
    /// <summary>
    /// 排列
    /// </summary>
    /// <param name="data">排列数据</param>
    /// <param name="k">前缀的位置</param>
    /// <param name="m">要排列的数目</param>
    /// <param name="indexArray">打印排列数</param>
    private static void Perm(List<int> data, int k, int m, ref List<List<int>> indexArray)
    {
        if (k == m - 1)//前缀是最后一个位置,此时打印排列数.
        {
            var array = new List<int>();
            for (int i = 0; i < m; i++)
            {
                //printf("%d", list[i]);
                array.Add(data[i]);
            }
            //printf("\n");
            indexArray.Add(new List<int>(array));
        }
        else
        {
            for (int i = k; i < m; i++)
            {
                //交换前缀,使之产生下一个前缀.
                Swap(data, k, i);
                Perm(data, k + 1, m, ref indexArray);
                //将前缀换回来,继续做上一个的前缀排列.
                Swap(data, k, i);
            }
        }
    }
    /// <summary>
    /// 交换数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static void Swap(List<int> data, int a, int b)
    {
        int temp = data[a];
        data[a] = data[b];
        data[b] = temp;
    }

    /// <summary>
    /// 构造一个排列对象
    /// </summary>
    /// <param name="array"></param>
    /// <param name="takeQuantity"></param>
    public Arrangement(List<T> array, int takeQuantity)
    {
        Members = new List<IndexStruct>();
        for (int i = 0; i < array.Count; i++)
        {
            Members.Add(new IndexStruct(array[i], i));
        }
        TakeQuantity = takeQuantity;
    }
}