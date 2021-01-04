using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace CSharp_Learn.Demo
{
    class DataTable详解
    {
        public void Table()
        {
            //创建一个空表
            DataTable dt = new DataTable();
            //创建一个名为"Table_New"的空表
            dt = new DataTable("Table_New");


            //1.创建空列
            DataColumn dc = new DataColumn();
            dt.Columns.Add(dc);
            //2.创建带列名和类型名的列(两种方式任选其一)
            dt.Columns.Add("column0", System.Type.GetType("System.String"));
            dt.Columns.Add("column0", typeof(String));
            //3.通过列架构添加列
            dc = new DataColumn("column1", System.Type.GetType("System.DateTime"));
            dc = new DataColumn("column1", typeof(DateTime));
            dt.Columns.Add(dc);


            //1.创建空行
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            //2.创建空行
            dt.Rows.Add();
            //3.通过行框架创建并赋值
            dt.Rows.Add("张三", DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
            //4.通过复制dt2表的某一行来创建
            dt.Rows.Add(dt.Rows[0].ItemArray);


            //新建行的赋值
            dr = dt.NewRow();
            dr[0] = "张三";//通过索引赋值
            dr["column1"] = DateTime.Now; //通过名称赋值
                                          //对表已有行进行赋值
            dt.Rows[0][0] = "张三"; //通过索引赋值
            dt.Rows[0]["column1"] = DateTime.Now;//通过名称赋值
                                                 //取值
            string name = dt.Rows[0][0].ToString();
            string time = dt.Rows[0]["column1"].ToString();


            //选择column1列值为空的行的集合
            DataRow[] drs = dt.Select("column1 is null");
            //选择column0列值为"李四"的行的集合
            drs = dt.Select("column0 = '李四'");
            //筛选column0列值中有"张"的行的集合(模糊查询)
            drs = dt.Select("column0 like '张%'");//如果的多条件筛选，可以加 and 或 or
                                                 //筛选column0列值中有"张"的行的集合并按column1降序排序
            drs = dt.Select("column0 like '张%'", "column1 DESC");


            //使用DataTable.Rows.Remove(DataRow)方法
            dt.Rows.Remove(dt.Rows[0]);
            //使用DataTable.Rows.RemoveAt(index)方法
            dt.Rows.RemoveAt(0);
            //使用DataRow.Delete()方法
            //dt.Rows[0].Delete();
            dt.AcceptChanges();

            //-----区别和注意点-----
            //Remove()和RemoveAt()方法是直接删除
            //Delete()方法只是将该行标记为deleted，但是还存在，还可DataTable.RejectChanges()回滚，使该行取消删除。
            //用Rows.Count来获取行数时，还是删除之前的行数，需要使用DataTable.AcceptChanges()方法来提交修改。
            //如果要删除DataTable中的多行，应该采用倒序循环DataTable.Rows，而且不能用foreach进行循环删除，因为正序删除时索引会发生变化，程式发生异常，很难预料后果。
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dt.Rows.RemoveAt(i);
            }


            //复制表，同时复制了表结构和表中的数据
            DataTable dtNew = new DataTable();
            dtNew = dt.Copy();
            //复制表
            dtNew = dt.Copy();  //复制dt表数据结构
            dtNew.Clear();  //清空数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (true)
                {
                    dtNew.Rows.Add(dt.Rows[i].ItemArray);  //添加数据行
                }
            }
            //克隆表，只是复制了表结构，不包括数据
            dtNew = new DataTable();
            dtNew = dt.Clone();
            //如果只需要某个表中的某一行
            dtNew = new DataTable();
            dtNew = dt.Copy();
            dtNew.Rows.Clear();//清空表数据
            dtNew.ImportRow(dt.Rows[0]);//这是加入的是第一行


            dt = new DataTable();//创建表
            dt.Columns.Add("ID", typeof(Int32));//添加列
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Age", typeof(Int32));
            dt.Rows.Add(new object[] { 1, "张三", 20 });//添加行
            dt.Rows.Add(new object[] { 2, "李四", 25 });
            dt.Rows.Add(new object[] { 3, "王五", 30 });
            DataView dv = dt.DefaultView;//获取表视图
            dv.Sort = "ID DESC";//按照ID倒序排序
            dv.ToTable();//转为表
        }


        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public static bool SaveCSV(DataTable dt, string fullPath)
        {
            try
            {
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";
                //写出列名称
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += "\"" + dt.Columns[i].ColumnName.ToString() + "\"";
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
                //写出各行数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        str = string.Format("\"{0}\"", str);
                        data += str;
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取CSV文件到DataTable中
        /// </summary>
        /// <param name="filePath">CSV的文件路径</param>
        /// <returns></returns>
        public static DataTable ReadCSV(string filePath)
        {
            DataTable dt = new DataTable();
            int lineNumber = 0;
            using (CsvFileReader reader = new CsvFileReader(filePath))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {

                    if (0 == lineNumber)
                    {
                        foreach (string s in row)
                        {
                            dt.Columns.Add(s.Replace("\"", ""));
                        }
                    }
                    else
                    {
                        int index = 0;
                        DataRow dr = dt.NewRow();
                        foreach (string s in row)
                        {
                            dr[index] = s.Replace("\"", "");
                            index++;
                        }
                        dt.Rows.Add(dr);
                    }
                    lineNumber++;
                }
            }
            return dt;
        }


        public class CsvRow : List<string>
        {
            public string LineText { get; set; }
        }
        public class CsvFileReader : StreamReader
        {
            public CsvFileReader(Stream stream)
                : base(stream)
            {
            }

            public CsvFileReader(string filename)
                : base(filename)
            {
            }

            /// <summary>  
            /// Reads a row of data from a CSV file  
            /// </summary>  
            /// <param name="row"></param>  
            /// <returns></returns>  
            public bool ReadRow(CsvRow row)
            {
                row.LineText = ReadLine();
                if (String.IsNullOrEmpty(row.LineText))
                    return false;

                int pos = 0;
                int rows = 0;

                while (pos < row.LineText.Length)
                {
                    string value;

                    // Special handling for quoted field  
                    if (row.LineText[pos] == '"')
                    {
                        // Skip initial quote  
                        pos++;

                        // Parse quoted value  
                        int start = pos;
                        while (pos < row.LineText.Length)
                        {
                            // Test for quote character  
                            if (row.LineText[pos] == '"')
                            {
                                // Found one  
                                pos++;

                                // If two quotes together, keep one  
                                // Otherwise, indicates end of value  
                                if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                                {
                                    pos--;
                                    break;
                                }
                            }
                            pos++;
                        }
                        value = row.LineText.Substring(start, pos - start);
                        value = value.Replace("\"\"", "\"");
                    }
                    else
                    {
                        // Parse unquoted value  
                        int start = pos;
                        while (pos < row.LineText.Length && row.LineText[pos] != ',')
                            pos++;
                        value = row.LineText.Substring(start, pos - start);
                    }

                    // Add field to list  
                    if (rows < row.Count)
                        row[rows] = value;
                    else
                        row.Add(value);
                    rows++;

                    // Eat up to and including next comma  
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    if (pos < row.LineText.Length)
                        pos++;
                }
                // Delete any unused items  
                while (row.Count > rows)
                    row.RemoveAt(rows);

                // Return true if any columns read  
                return (row.Count > 0);
            }
        }
    }
}
