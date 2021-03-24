using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace StudyNotes.工具
{
    public class ExcelTool
    {
        public static void RadeExcel(string path)
        {
            var daTable = new DataTable();
            var rowList = new List<string>();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.Position = 0;
                var xssWorkbook = new XSSFWorkbook(stream);
            }
        }
    }
}
