using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnRecipe_Click(object sender, EventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                txtUnRecipe.Text = OF.FileName;
            }
        }

        private void btnRemain_Click(object sender, EventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                txtRemain.Text = OF.FileName;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                txtCheck.Text = OF.FileName;
            }
        }

        Dictionary<string, double> UnRecipeDict = new Dictionary<string, double>();
        Dictionary<string, double> RemainDict = new Dictionary<string, double>();

        private void btnRun_Click(object sender, EventArgs e)
        {
            UnRecipeDict.Clear();
            RemainDict.Clear();
            //未出票
            var templetefs = new FileStream(txtUnRecipe.Text, FileMode.Open, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(templetefs);
            var sheet = hssfworkbook.GetSheetAt(0);
            var rfirst = 6;
            var rlast = sheet.LastRowNum;

            if (radTypeA.Checked)
            {
                for (int i = rfirst; i < rlast; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(1).StringCellValue.Equals("小计"))
                    {
                        var company = sheet.GetRow(i - 1).GetCell(3).StringCellValue;
                        var amount = Math.Round(sheet.GetRow(i).GetCell(11).NumericCellValue, 2); //未开发票
                        if (UnRecipeDict.ContainsKey(company))
                        {
                            UnRecipeDict[company] = Math.Round(UnRecipeDict[company] + amount, 2);
                        }
                        else
                        {
                            UnRecipeDict.Add(company, amount);
                        }
                    }
                }
            }
            else
            {
                for (int i = rfirst; i < rlast; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(5).StringCellValue.Equals("小计"))
                    {
                        var company = sheet.GetRow(i - 1).GetCell(0).StringCellValue;
                        var amount = Math.Round(sheet.GetRow(i).GetCell(8).NumericCellValue, 2); //未开发票
                        if (UnRecipeDict.ContainsKey(company))
                        {
                            UnRecipeDict[company] = Math.Round(UnRecipeDict[company] + amount, 2);
                        }
                        else
                        {
                            UnRecipeDict.Add(company, amount);
                        }
                    }
                }
            }
            Console.WriteLine("Company Count:" + UnRecipeDict.Count);

            templetefs = new FileStream(txtRemain.Text, FileMode.Open, FileAccess.ReadWrite);
            hssfworkbook = new HSSFWorkbook(templetefs);
            sheet = hssfworkbook.GetSheetAt(0);
            rfirst = 6;
            rlast = sheet.LastRowNum;

            if (radTypeA.Checked)
            {
                for (int i = rfirst; i < rlast; i++)
                {
                    var company = sheet.GetRow(i).GetCell(0).StringCellValue;
                    var amount = sheet.GetRow(i).GetCell(5).NumericCellValue;
                    if (company != "小计" && company != "合计") RemainDict.Add(company, amount);
                }
            }
            else
            {
                for (int i = rfirst; i < rlast; i++)
                {
                    var company = sheet.GetRow(i).GetCell(1).StringCellValue;
                    var amount = sheet.GetRow(i).GetCell(7).NumericCellValue;
                    if (company != "小计" && company != "合计") RemainDict.Add(company, amount);
                }
            }
            Console.WriteLine("RemainDict Count:" + RemainDict.Count);


            templetefs = new FileStream(txtCheck.Text, FileMode.Open, FileAccess.ReadWrite);
            hssfworkbook = new HSSFWorkbook(templetefs);
            sheet = hssfworkbook.GetSheetAt(0);
            rfirst = 4;
            rlast = sheet.LastRowNum;
            for (int i = rfirst; i < rlast; i++)
            {
                var company = sheet.GetRow(i).GetCell(1).StringCellValue;
                var RecipeAmount = Math.Round(UnRecipeDict.ContainsKey(company) ? UnRecipeDict[company] : 0, 2);
                var RemainAmount = Math.Round(RemainDict.ContainsKey(company) ? RemainDict[company] : 0, 2);
                var Cell_K = sheet.GetRow(i).CreateCell(10); //K:未开发票
                Cell_K.SetCellValue(RecipeAmount);

                var Cell_L = sheet.GetRow(i).CreateCell(11);
                double Remain = 0;
                if (radTypeA.Checked)
                {
                    //L = I - K
                    Remain = sheet.GetRow(i).GetCell(9).CellType == CellType.String ? 0 : sheet.GetRow(i).GetCell(9).NumericCellValue;
                }
                else
                {
                    //L = J - K
                    Remain = sheet.GetRow(i).GetCell(8).CellType == CellType.String ? 0 : sheet.GetRow(i).GetCell(8).NumericCellValue;
                }
                Cell_L.SetCellValue(Math.Round(Remain - RecipeAmount, 2));

                var Cell_M = sheet.GetRow(i).CreateCell(12); //M
                Cell_M.SetCellValue(RemainAmount);

                var Cell_N = sheet.GetRow(i).CreateCell(13);
                if (radTypeA.Checked)
                {
                    //N = M - L 
                    Cell_N.SetCellValue(Math.Round(RemainAmount - Remain + RecipeAmount, 2));
                }
                else
                {
                    //N = L - M
                    Cell_N.SetCellValue(Math.Round(Remain - RecipeAmount - RemainAmount, 2));
                }
            }

            var filename = txtCheck.Text.Replace(".xls", "(完成).xls");
            var reportfs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            hssfworkbook.Write(reportfs);
            reportfs.Close();
            reportfs.Dispose();
        }
    }
}
