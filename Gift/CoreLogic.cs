using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Gift
{
    public class CoreLogic
    {
        public static Dictionary<string, double> 理算重量表 = new Dictionary<string, double>();

        public static void Read_理算重量表()
        {
            理算重量表.Clear();
            var templetefs = new FileStream("理算重量表.xlsx", FileMode.Open, FileAccess.ReadWrite);
            var hssfworkbook = new XSSFWorkbook(templetefs);
            var sheet = hssfworkbook.GetSheetAt(0);
            var RowIdx = 1;
            while (sheet.GetRow(RowIdx) != null)
            {
                理算重量表.Add(sheet.GetRow(RowIdx).GetCell(0).StringCellValue.Trim(), sheet.GetRow(RowIdx).GetCell(1).NumericCellValue);
                RowIdx++;
            }
            Console.WriteLine("理算重量表" + 理算重量表.Count);
        }

        public static List<string> 产地List = new List<string>();

        public static void Create(List<Record> rs, string filename)
        {
            产地List = rs.Select(x => x.产地).Distinct().ToList();
            System.IO.File.Copy(filename, filename.Replace(".xlsx", "(完成).xlsx"), true);
            filename = filename.Replace(".xlsx", "(完成).xlsx");
            var templetefs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            var hssfworkbook = new XSSFWorkbook(templetefs);
            var H型钢 = rs.Where(x => x.品名.Equals("H型钢")).ToList();
            var 低合金H型钢 = rs.Where(x => x.品名.Equals("低合金H型钢")).ToList();
            var sheet1 = hssfworkbook.GetSheetAt(0);
            CreateSheet(H型钢, sheet1);
            sheet1.ForceFormulaRecalculation = true;
            var sheet2 = hssfworkbook.GetSheetAt(1);
            CreateSheet(低合金H型钢, sheet2);
            sheet2.ForceFormulaRecalculation = true;
            var reportfs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            hssfworkbook.Write(reportfs);
            reportfs.Close();
            reportfs.Dispose();
        }

        static void CreateSheet(List<Record> rs, NPOI.SS.UserModel.ISheet sheet)
        {
            var OutRs = new List<OutPutRecord>();
            var 仓库统计H型钢 = string.Empty;
            var 仓库统计低合金H型钢 = string.Empty;
            foreach (var 仓库Group in rs.GroupBy(x => x.仓库))
            {
                var 仓库记录列表 = 仓库Group.ToList();
                foreach (var 规格Group in 仓库记录列表.GroupBy(x => x.规格 + "-" + x.产地))
                {
                    var r = new OutPutRecord();
                    var SegInfo = 规格Group.Key.Split("-".ToCharArray());
                    r.规格 = SegInfo[0];
                    r.产地 = 仓库Group.Key + "-" + SegInfo[1] + (SegInfo.Length == 3 ? ("-" + SegInfo[2]) : string.Empty);
                    r.数量 = 规格Group.Sum(x => x.可供数);
                    Console.WriteLine(r.产地 + ":" + r.规格);
                    OutRs.Add(r);
                }
                仓库统计H型钢 += 仓库Group.Key + ":" + 仓库Group.Sum(x => x.品名 == "H型钢" ? x.可供数 : 0) + "支，";
                仓库统计低合金H型钢 += 仓库Group.Key + ":" + 仓库Group.Sum(x => x.品名 == "低合金H型钢" ? x.可供数 : 0) + "支，";
            }
            Console.WriteLine("Start Fill");
            //填写数量
            SeekAndFill(sheet, OutRs, 0);
            SeekAndFill(sheet, OutRs, 10);
            if (sheet.SheetName == "H型钢")
            {
                var rfirst = sheet.FirstRowNum;
                var rlast = sheet.LastRowNum;
                for (int i = rfirst; i < rlast; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(1)!=null && row.GetCell(1).CellType == CellType.String && row.GetCell(1).StringCellValue == "仓库")
                    {
                        row.GetCell(2).SetCellValue(仓库统计H型钢.TrimEnd("，".ToCharArray()));
                        break;
                    }
                }
            }
            else
            {
                SeekAndFill(sheet, OutRs, 20);
                var rfirst = sheet.FirstRowNum;
                var rlast = sheet.LastRowNum;
                for (int i = rfirst; i < rlast; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(21) != null && row.GetCell(21).CellType == CellType.String && row.GetCell(21).StringCellValue == "仓库")
                    {
                        row.GetCell(22).SetCellValue(仓库统计低合金H型钢.TrimEnd("，".ToCharArray()));
                        break;
                    }
                }
            }
        }

        private static void SeekAndFill(ISheet sheet, List<OutPutRecord> OutRs, int ColIdx)
        {
            var rfirst = sheet.FirstRowNum;
            var rlast = sheet.LastRowNum;
            var SizeKey = string.Empty;
            for (int i = rfirst; i < rlast; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(ColIdx + 1) != null && row.GetCell(ColIdx + 1).CellType == CellType.String && row.GetCell(ColIdx + 1).StringCellValue.StartsWith("仓库")) { 
                    continue; 
                }
                if (row.GetCell(ColIdx + 2) == null) continue;
                var key = row.GetCell(ColIdx + 2).StringCellValue;
                if (row.GetCell(ColIdx) != null && row.GetCell(ColIdx).StringCellValue.Contains("*")) SizeKey = row.GetCell(ColIdx).StringCellValue.Split(System.Environment.NewLine.ToCharArray())[0];
                if (key.StartsWith("小计") || key.StartsWith("产地") || key.StartsWith("合计") || string.IsNullOrEmpty(key)) continue;
                //纠正产地：
                key = key.Trim();
                key = key.Replace("宝德", "宝得");
                key = key.Replace("速-", "速全-");
                key = key.Replace("罗-", "罗蔡-");
                key = key.Replace("张-", "张庙-");

                key = key.Replace("-兴-", "-兴华-");
                key = key.Replace("-唐-", "-唐山-");
                key = key.Replace("/兴-", "/兴华-");
                key = key.Replace("/唐-", "/唐山-");

                Console.WriteLine(key + ":" + SizeKey);
                if (key.Split("/".ToArray()).Length == 1)
                {
                    var m = OutRs.Where(x => x.产地 == key && x.规格 == SizeKey.Trim());
                    if (m.Count() == 0)
                    {
                        row.GetCell(ColIdx + 3).SetCellValue(0);
                    }
                    else
                    {
                        row.GetCell(ColIdx + 3).SetCellValue(m.First().数量);
                    }
                }
                else
                {
                    //针对有Prefix有  -中 -协的情况进行修补
                    var Prefix = key.Substring(0,key.IndexOf("-"));
                    var Prefix2 = key.Substring(key.IndexOf("-") + 1);
                    var m1 = OutRs.Where(x => x.产地 == Prefix + "-" + Covert产地(Prefix2.Split("/".ToArray())[0]) && x.规格 == SizeKey.Trim());
                    var m2 = OutRs.Where(x => x.产地 == Prefix + "-" + Covert产地(Prefix2.Split("/".ToArray())[1]) && x.规格 == SizeKey.Trim());
                    var cnt = (m1.Count() == 0 ? 0 : m1.First().数量) + (m2.Count() == 0 ? 0 : m2.First().数量);
                    if (cnt == 0)
                    {
                        row.GetCell(ColIdx + 3).SetCellValue(0);
                    }
                    else
                    {
                        row.GetCell(ColIdx + 3).SetCellValue(cnt);
                    }
                }
            }
        }

        private static string Covert产地(string Simple)
        {
            Simple = Simple.Trim();
            if (Simple.Length == 2) return Simple;
            foreach (var item in 产地List)
            {
                if (item.StartsWith(Simple)) return item;
            }
            return Simple;

        }

    }

    public class OutPutRecord
    {
        public string 规格 { get; set; }
        public double 米重
        {
            get
            {
                return CoreLogic.理算重量表[规格.Replace("协", string.Empty).Replace("中", string.Empty)];
            }
        }
        public string 产地 { get; set; }
        public double 数量 { get; set; }
        public double 理算库存
        {
            get
            {
                return Math.Round(米重 * 数量 * 12 / 1000, 3);
            }
        }
        public double 理价 { get; set; }
        public string 在途支 { get; set; }
        public string 计划吨 { get; set; }
        public string 已销支 { get; set; }

    }
}
