using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Text;
using System.Linq;

namespace Tax
{
    public class TaxInfo
    {

        public const double AmountLimit_不含税 = 100_000;

        public const int CountLimit = 999;  //可以做清单，去除原先8行限制

        public string Name { get; set; }
        public string TaxCode { get; set; }
        public string BankAccount { get; set; }
        public string AddressTel { get; set; }

        public static List<ItemDetail> list = new List<ItemDetail>();

        public class ItemDetail
        {
            public string 公司 { get; set; }

            public string 编码 { get; set; }

            public string 品名 { get; set; }

            public string 规格 { get; set; }

            public string 单位 { get; set; }

            public double 数量 { get; set; }

            public double 单价_不含税 { get; set; }

            public double 金额_不含税 { get; set; }

            public double 税率 { get; set; }

            public double 税额 { get; set; }

            public bool 已开票 { get; set; }

            public bool 被拆分 { get; set; }

            public bool 被合并 { get; set; }

        }

        public static int ReadExcel(string filename)
        {
            var templetefs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(templetefs);
            var sheet = hssfworkbook.GetSheetAt(0);
            var rfirst = 6;
            var rlast = sheet.LastRowNum;
            list.Clear();
            for (int i = rfirst; i < rlast; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(3) != null && row.GetCell(3).CellType == CellType.String)
                {
                    var r = new ItemDetail();
                    r.公司 = row.GetCell(3).StringCellValue;
                    r.单位 = "吨";
                    r.品名 = row.GetCell(12).StringCellValue;
                    r.规格 = row.GetCell(14).StringCellValue;
                    r.编码 = ItemInfo.ItemCodeDict.ContainsKey(r.品名) ? ItemInfo.ItemCodeDict[r.品名] : "0000000";
                    r.数量 = row.GetCell(4).NumericCellValue;
                    r.税率 = 0.13;
                    r.单价_不含税 = row.GetCell(17).NumericCellValue;
                    r.金额_不含税 = row.GetCell(5).NumericCellValue;
                    list.Add(r);
                }
            }
            return list.Count;
        }

        public static string strRecipeTemplate = "";
        public static string strItemTemplate = "";

        public static void ReadTemplate()
        {
            var sr = new StreamReader("发票模板.txt", Encoding.GetEncoding("GBK"));
            strRecipeTemplate = sr.ReadToEnd();
            sr.Close();
            sr = new StreamReader("商品模板.txt", Encoding.GetEncoding("GBK"));
            strItemTemplate = sr.ReadToEnd();
            sr.Close();
        }

        public static string FillTemplate(string CompanySeekKey, List<ItemDetail> items)
        {
            var recipe = strRecipeTemplate;
            recipe = recipe.Replace("@Company@", CompanySeekKey);   //公司名称
            var cInfo = CustomerInfo.list.Where(x => x.Name == CompanySeekKey).FirstOrDefault();
            recipe = recipe.Replace("@TaxCode@", cInfo.TaxCode);
            recipe = recipe.Replace("@BankAccount@", cInfo.BankAccount);
            recipe = recipe.Replace("@TelAddr@", cInfo.AddressTel);
            //货物的做成
            var strItems = "";
            var no = 1;

            //正负对冲处理
            var MinusItems = items.Where(x => x.数量 < 0).ToList();

            foreach (var item in items)
            {
                var strItem = strItemTemplate;
                strItem = strItem.Replace("@no@", no.ToString());
                strItem = strItem.Replace("@name@", item.品名);
                strItem = strItem.Replace("@dj@", item.单价_不含税.ToString());
                strItem = strItem.Replace("@je@", item.金额_不含税.ToString());
                strItem = strItem.Replace("@sl@", item.数量.ToString());
                strItem = strItem.Replace("@size@", item.规格.ToString());
                if (no != 1)
                {
                    strItems += System.Environment.NewLine + strItem;
                }
                else
                {
                    strItems += strItem;
                }
                no++;
            }
            recipe = recipe.Replace("@RecipeDetails@", strItems);
            return recipe;
        }
    }
}
