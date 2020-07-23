using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;

namespace Gift
{
    public class Record
    {
        public string 品名 { get; set; }
        public string 材质 { get; set; }
        public string 规格 { get; set; }
        public string 产地 { get; set; }
        public string 单位 { get; set; }
        public double 可供数 { get; set; }
        public double 可供量 { get; set; }
        public double 库存量 { get; set; }
        public double 开单量 { get; set; }
        public double 库存数 { get; set; }
        public double 开单数 { get; set; }
        public double 加工数 { get; set; }
        public string 计量 { get; set; }
        public string 仓库 { get; set; }
        public string 采购批号 { get; set; }
        public string 采购合同号 { get; set; }
        public string 入库单号 { get; set; }
        public string 仓储号 { get; set; }
        public string 捆包号 { get; set; }
        public string 公差 { get; set; }
        public DateTime 入库日期 { get; set; }
        public string 备注 { get; set; }
        public string 件编号 { get; set; }
        public string 炉批号 { get; set; }
        public string 车船名 { get; set; }
        public string 机构 { get; set; }
        public double 原始数量 { get; set; }
        public double 原始重量 { get; set; }
        public string 入库性质 { get; set; }

        public static List<Record> ReadSysFile(string Filename)
        {
            var records = new List<Record>();
            var templetefs = new FileStream(Filename, FileMode.Open, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(templetefs);
            var sheet = hssfworkbook.GetSheetAt(0);
            var RowIdx = 5;
            while (sheet.GetRow(RowIdx).GetCell(0).StringCellValue != "合计")
            {
                if (sheet.GetRow(RowIdx).GetCell(0).StringCellValue == "小计")
                {
                    RowIdx++;
                    continue;
                }
                var rec = new Record();
                rec.品名 = sheet.GetRow(RowIdx).GetCell(0).StringCellValue;
                rec.材质 = sheet.GetRow(RowIdx).GetCell(1).StringCellValue;
                rec.规格 = sheet.GetRow(RowIdx).GetCell(2).StringCellValue;
                rec.产地 = sheet.GetRow(RowIdx).GetCell(3).StringCellValue;
                if (rec.规格.EndsWith("中") || rec.规格.EndsWith("协"))
                {
                    rec.产地 = rec.产地 + "-" + rec.规格.Substring(rec.规格.Length - 1);
                    rec.规格 = rec.规格.Substring(0, rec.规格.Length - 1);
                }
                rec.单位 = sheet.GetRow(RowIdx).GetCell(4).StringCellValue;
                rec.可供数 = sheet.GetRow(RowIdx).GetCell(5).NumericCellValue;
                rec.可供量 = sheet.GetRow(RowIdx).GetCell(6).NumericCellValue;
                rec.库存量 = sheet.GetRow(RowIdx).GetCell(7).NumericCellValue;
                rec.开单量 = sheet.GetRow(RowIdx).GetCell(8).NumericCellValue;
                rec.库存数 = sheet.GetRow(RowIdx).GetCell(9).NumericCellValue;
                rec.开单数 = sheet.GetRow(RowIdx).GetCell(10).NumericCellValue;
                rec.加工数 = sheet.GetRow(RowIdx).GetCell(11).NumericCellValue;
                rec.计量 = sheet.GetRow(RowIdx).GetCell(12).StringCellValue;
                //仓库保留2个汉字
                rec.仓库 = sheet.GetRow(RowIdx).GetCell(13).StringCellValue.Substring(0, 2);
                rec.采购批号 = sheet.GetRow(RowIdx).GetCell(14).StringCellValue;
                rec.采购合同号 = sheet.GetRow(RowIdx).GetCell(15).StringCellValue;
                rec.入库单号 = sheet.GetRow(RowIdx).GetCell(16).StringCellValue;
                rec.仓储号 = sheet.GetRow(RowIdx).GetCell(17).StringCellValue;
                rec.捆包号 = sheet.GetRow(RowIdx).GetCell(18).StringCellValue;
                rec.公差 = sheet.GetRow(RowIdx).GetCell(19).StringCellValue;
                rec.入库日期 = sheet.GetRow(RowIdx).GetCell(20).DateCellValue;
                rec.备注 = sheet.GetRow(RowIdx).GetCell(21).StringCellValue;
                rec.件编号 = sheet.GetRow(RowIdx).GetCell(22).StringCellValue;
                rec.炉批号 = sheet.GetRow(RowIdx).GetCell(23).StringCellValue;
                rec.车船名 = sheet.GetRow(RowIdx).GetCell(24).StringCellValue;
                rec.机构 = sheet.GetRow(RowIdx).GetCell(25).StringCellValue;
                rec.原始数量 = sheet.GetRow(RowIdx).GetCell(26).NumericCellValue;
                rec.原始重量 = sheet.GetRow(RowIdx).GetCell(27).NumericCellValue;
                rec.入库性质 = sheet.GetRow(RowIdx).GetCell(28).StringCellValue;
                
                records.Add(rec);
                RowIdx++;
            }
            return records;
        }

    }

}
