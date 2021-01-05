using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 数组补丁
/// </summary>
public class ArrayPatch
{
    /*
     *
     * 题目描述 
        给出一个从小到大排好序的整数数组nums和一个整数n，在数组中添加若干个补丁（元素）使得[1,n]的区间内的所有数都可以表示成nums中若干个数的和。返回最少需要添加的补丁个数。

        Example 1：

        nums =
        [1, 3],

        n = 6

        返回1，表示至少需要添加1个数｛2｝，才可以表示1到6之间所有数。


        Example 2:

        nums =
        [1, 5, 10],

        n = 20

        返回2，表示至少需要添加两个数｛2，4｝，才可以表示1到20之间所有数。 
     */
    public int N { get; set; }
    public List<int> IntArray { get; set; }

    public void 调用()
    {
        Console.Write("请输入数据，以空格隔开（例如：1 5 10）：");
        var input = Console.ReadLine().Split(' ');
        var listInput = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            listInput.Add(Convert.ToInt32(input[i]));
        }
        Console.Write("请输入n值：");
        var N = Convert.ToInt32(Console.ReadLine());

        var aplist = listInput;
        //var aplist = new List<int> {1, 3,55,566};
        ArrayPatch ap = new ArrayPatch(aplist, N);
        ap.GetPatchQuantity();

        Console.Read();
        Console.Read();
        Console.Read();
        Console.Read();
        return;
    }
    public int GetPatchQuantity()
    {
        var arrayPatch = new List<int>() { 1 };
        var copyIntArray = new List<int>(IntArray);
        if (copyIntArray.Count > 0)
        {
            if (copyIntArray[0] != 1)
            {
                arrayPatch.AddRange(GetNumPatch(copyIntArray[0]));
            }
            else
            {
                copyIntArray.RemoveAt(0);
            }
        }
        GetNumPatch(ref arrayPatch, ref copyIntArray);

        arrayPatch.Sort();
        var patchs = new List<int>(arrayPatch);
        foreach (var r in IntArray)
        {
            patchs.Remove(r);
        }

        Console.Write("n值：" + N + "\n原数组：\n");
        //输出元数据
        foreach (var item in IntArray)
        {
            Console.Write(item + " ");
        }
        Console.Write("\n加入补丁后的数组：\n");
        //输出所有数
        foreach (var item in arrayPatch)
        {
            Console.Write(item + " ");
        }
        Console.Write("\n加入的补丁：\n");
        //输出补丁
        foreach (var item in patchs)
        {
            Console.Write(item + " ");
        }
        Console.Write("\n最少需要加入的补丁个数：" + patchs.Count);
        return 0;
    }

    /// <summary>
    /// 合并list并移除相同元素
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public List<int> ListMerger(List<int> list1, List<int> list2)
    {
        if (list1.Count == 0 || list2.Count == 0)
        {
            list1.AddRange(list2);
            return list1;
        }
        foreach (var valu in list1)
        {
            list2.Remove(valu);
        }
        list1.AddRange(list2);
        list1.Sort();
        return list1;
    }
    /// <summary>
    /// 求和
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public int Sum(List<int> list)
    {
        int num = 0;
        foreach (var vule in list)
        {
            num += vule;
        }
        return num;
    }

    /// <summary>
    /// 递归求取补丁
    /// </summary>
    /// <param name="arrayPatch"></param>
    /// <param name="copyIntArray"></param>
    /// <returns></returns>
    public void GetNumPatch(ref List<int> arrayPatch, ref List<int> copyIntArray)
    {
        if (Sum(arrayPatch) >= N)
            return;
        else if (copyIntArray.Count > 0 && Sum(arrayPatch) >= copyIntArray[0])
        {
            //当补丁和大于下个数据时，将该值加入补丁
            arrayPatch.Add(copyIntArray[0]);
            copyIntArray.Remove(copyIntArray[0]);
            GetNumPatch(ref arrayPatch, ref copyIntArray);
        }
        else
        {
            //当补丁和小于下个数据时，将一个最小值加入补丁
            //当没有下个数据时，取得剩余所有补丁
            arrayPatch.Add(Sum(arrayPatch) + 1);
            GetNumPatch(ref arrayPatch, ref copyIntArray);

            /*
            copyIntArray = GetNumPatch(N);
            foreach (var vule in copyIntArray)
            {
                if (vule > arrayPatch[arrayPatch.Count - 1]&&vule> Sum(arrayPatch))
                {
                    arrayPatch.Add(vule);
                }
            }*/
        }
    }

    /// <summary>
    /// 给定一个数，给出表示1到这个数之间所有数都可以被求和的数组。
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public List<int> GetNumPatch(int num)
    {
        var arr = new List<int>() { 2 };
        GetNumPatchSub(num, arr);
        arr.RemoveAt(arr.Count - 1);
        return arr;
    }
    public List<int> GetNumPatchSub(int num, List<int> arr)
    {
        if (num > arr[arr.Count - 1])
        {
            arr.Add(arr[arr.Count - 1] * 2);
            GetNumPatchSub(num, arr);
        }
        return arr;
    }

    public ArrayPatch(List<int> list, int n)
    {
        list.Sort();
        IntArray = list;
        N = n;
    }
}