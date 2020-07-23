using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Tax.TaxInfo;

namespace Tax
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var CustomerInfoCnt = CustomerInfo.ReadSys();
            var ItemInfoCnt = ItemInfo.ReadSys();
            TaxInfo.ReadTemplate();
            var invalidCIcount = CustomerInfo.list.Count(x => x.TaxCode.Length != 18);
            toolStripStatusLabel1.Text = "读取客户编码:" + CustomerInfoCnt + " 商品编码：" + ItemInfoCnt;
            MessageBox.Show("税号非18位的客户记录数：" + invalidCIcount);
        }

        private void btnReadOrg_Click(object sender, EventArgs e)
        {
            var OF = new OpenFileDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                var cnt = TaxInfo.ReadExcel(OF.FileName);
                lstCompany.Clear();
                lstCompany.Columns.Add("公司名", 250);
                lstCompany.Columns.Add("发票件数");
                lstCompany.Columns.Add("金额", 150);
                lstCompany.Columns.Add("符合条件");
                foreach (var item in TaxInfo.list.GroupBy(x => x.公司))
                {
                    var SumAmount = item.Sum(x => x.金额_不含税);
                    var IsOK = item.Count() <= TaxInfo.CountLimit && SumAmount < TaxInfo.AmountLimit_不含税;
                    lstCompany.Items.Add(new ListViewItem(new string[] { item.Key, item.Count().ToString(), SumAmount.ToString(), IsOK ? "是" : "否" }));
                }
                MessageBox.Show("读取到发票记录数：" + cnt);
            }
        }

        private void btnCreateSimpleRecipe_Click(object sender, EventArgs e)
        {
            if (txtXMLFolder.Text == "")
            {
                MessageBox.Show("请先选择XML目录");
                return;
            }

            int MissCustomCnt = 0;
            int ZeroAmountCnt = 0;
            int SimpleCnt = 0;
            foreach (var item in TaxInfo.list.GroupBy(x => x.公司))
            {
                var SumAmount = item.Sum(x => x.金额_不含税);
                if (SumAmount == 0)
                {
                    //冲账用，不开发票
                    ZeroAmountCnt++; continue;
                }
                var IsOK = item.Count() <= TaxInfo.CountLimit && SumAmount < TaxInfo.AmountLimit_不含税;
                if (!IsOK) continue;
                //客户编码是全角的
                var CompanySeekKey = item.Key.Replace("(", "（");
                CompanySeekKey = CompanySeekKey.Replace(")", "）");
                var cInfo = CustomerInfo.list.Where(x => x.Name == CompanySeekKey).FirstOrDefault();
                if (cInfo == null)
                {
                    MissCustomCnt++; continue;
                }
                var strRecipe = TaxInfo.FillTemplate(CompanySeekKey, item.ToList());
                var sw = new StreamWriter(txtXMLFolder.Text + CompanySeekKey + ".xml", false, Encoding.GetEncoding("GBK"));
                sw.Write(strRecipe);
                sw.Close();
                SimpleCnt++;
                MessageBox.Show("制作发票数：" + SimpleCnt + " 公司信息缺失数：" + MissCustomCnt + " 冲账数：" + ZeroAmountCnt);
            }
        }

        private void lstCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblSelectCount.Text = "选中件数：0";
            lblSelectCount.ForeColor = System.Drawing.Color.Black;
            lblSelectAmount.Text = "选中金额：0";
            lblSelectAmount.ForeColor = System.Drawing.Color.Black;
            lstRecipeDetails.Clear();
            lstRecipeDetails.CheckBoxes = true;
            lstRecipeDetails.Columns.Add("公司名", 250);
            lstRecipeDetails.Columns.Add("品名", 150);
            lstRecipeDetails.Columns.Add("规格", 150);
            lstRecipeDetails.Columns.Add("单价（不含税）", 150);
            lstRecipeDetails.Columns.Add("数量", 150);
            lstRecipeDetails.Columns.Add("金额（不含税）", 150);
            lstRecipeDetails.Columns.Add("状态", 150);
            if (lstCompany.SelectedItems.Count == 0) return;
            var CompanyName = lstCompany.SelectedItems[0].SubItems[0].Text;
            txtFilename.Text = CompanyName;
            foreach (var item in TaxInfo.list.Where(x => x.公司 == CompanyName))
            {
                var status = item.已开票 ? "已开票" : "未开票";
                if (item.金额_不含税 < 0) status = "冲账";
                if (item.被拆分) status = "被拆分";
                if (item.被合并) status = "被合并";
                var lstitem = new ListViewItem(new string[] { item.公司,item.品名,item.规格.ToString(),
                                                                           item.单价_不含税.ToString(),item.数量.ToString(),item.金额_不含税.ToString(),status });
                if (item.已开票) lstitem.BackColor = System.Drawing.Color.Gray;
                if (item.金额_不含税 < 0) lstitem.BackColor = System.Drawing.Color.Pink;
                if (item.被拆分) lstitem.BackColor = System.Drawing.Color.AliceBlue;
                if (item.被合并) lstitem.BackColor = System.Drawing.Color.LightYellow;
                lstitem.Tag = item;
                lstRecipeDetails.Items.Add(lstitem);
            }
        }

        private void lstRecipeDetails_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            double checkAmount = 0;
            foreach (ListViewItem item in lstRecipeDetails.CheckedItems)
            {
                checkAmount += (item.Tag as ItemDetail).金额_不含税;
            }
            lblSelectCount.Text = "选中件数：" + lstRecipeDetails.CheckedItems.Count;
            if (lstRecipeDetails.CheckedItems.Count > TaxInfo.CountLimit)
            {
                lblSelectCount.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblSelectCount.ForeColor = System.Drawing.Color.Black;
            }
            lblSelectAmount.Text = "选中金额：" + checkAmount;
            if (checkAmount > TaxInfo.AmountLimit_不含税)
            {
                lblSelectAmount.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblSelectAmount.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnCreateRecipeXML_Click(object sender, EventArgs e)
        {
            double checkAmount = 0;
            bool HasPrint = false;
            bool HasSplited = false;
            bool HasMerged = false;
            var checkItems = new List<ItemDetail>();
            foreach (ListViewItem item in lstRecipeDetails.CheckedItems)
            {
                var r = (item.Tag as ItemDetail);
                if (r.已开票)
                {
                    HasPrint = true;
                    break;
                }
                if (r.被拆分)
                {
                    HasSplited = true;
                    break;
                }
                if (r.被合并)
                {
                    HasMerged = true;
                    break;
                }
                checkAmount += r.金额_不含税;
                checkItems.Add(r);
            }


            if (HasSplited)
            {
                MessageBox.Show("发票里面有被拆分项目");
                return;
            }
            if (HasMerged)
            {
                MessageBox.Show("发票里面有被合并项目");
                return;
            }
            if (HasPrint)
            {
                MessageBox.Show("发票里面有已开票项目");
                return;
            }
            if (lstRecipeDetails.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择需要开票的项目！");
                return;
            }
            if (lstRecipeDetails.CheckedItems.Count > TaxInfo.CountLimit || checkAmount > TaxInfo.AmountLimit_不含税)
            {
                MessageBox.Show("开票条件不符合！");
                return;
            }
            //客户编码是全角的
            var CompanySeekKey = checkItems[0].公司.Replace("(", "（");
            CompanySeekKey = CompanySeekKey.Replace(")", "）");
            var cInfo = CustomerInfo.list.Where(x => x.Name == CompanySeekKey).FirstOrDefault();
            if (cInfo == null)
            {
                MessageBox.Show("无法找到公司【" + CompanySeekKey + "】的信息！");
                return;
            }
            if (cInfo.TaxCode.Length != 18)
            {
                MessageBox.Show("公司税号不是18位:" + cInfo.TaxCode);
                return;
            }
            if (txtXMLFolder.Text == "")
            {
                MessageBox.Show("请先选择XML目录");
                return;
            }
            var strRecipe = TaxInfo.FillTemplate(CompanySeekKey, checkItems);
            var filename = txtXMLFolder.Text + txtFilename.Text + (chkFilenameTimeStamp.Checked ? ("_" + System.DateTime.Now.ToString("yyyyMMdd")) : "") + ".xml";
            if (File.Exists(filename))
            {
                if (MessageBox.Show("已经存在文件，是否覆盖？", "覆盖", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            var sw = new StreamWriter(filename, false, Encoding.GetEncoding("GBK"));
            sw.Write(strRecipe);
            sw.Close();
            foreach (ListViewItem item in lstRecipeDetails.CheckedItems)
            {
                var r = (item.Tag as ItemDetail);
                r.已开票 = true;
                item.SubItems[6].Text = "已开票";
                item.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void btnPickXmlFolder_Click(object sender, EventArgs e)
        {
            var OF = new FolderBrowserDialog();
            if (OF.ShowDialog() == DialogResult.OK)
            {
                txtXMLFolder.Text = OF.SelectedPath + "\\";
            }
        }

        private void btnSplitRecipe_Click(object sender, EventArgs e)
        {
            if (lstRecipeDetails.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要拆分的发票");
                return;
            }
            var r = lstRecipeDetails.SelectedItems[0].Tag as ItemDetail;
            if (r.金额_不含税 < 0)
            {
                MessageBox.Show("冲账用发票不可分割");
                return;
            }
            if (r.已开票)
            {
                MessageBox.Show("已开票发票不可分割");
                return;
            }
            if (r.被拆分)
            {
                MessageBox.Show("已被拆分发票不可分割");
                return;
            }
            if (r.被合并)
            {
                MessageBox.Show("已被合并发票不可分割");
                return;
            }
            var frm = new frmSplitRecipe();
            frm.FinishSplit += AddSplit;
            frm.OrgRecipe = r;
            frm.ShowDialog();
        }

        private void AddSplit(List<TaxInfo.ItemDetail> items)
        {
            TaxInfo.list.AddRange(items);
            lstCompany_SelectedIndexChanged(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstCompany.Clear();
            lstCompany.Columns.Add("公司名", 250);
            lstCompany.Columns.Add("发票件数");
            lstCompany.Columns.Add("金额", 150);
            lstCompany.Columns.Add("符合条件");
            if (string.IsNullOrEmpty(txtSearchKey.Text))
            {
                foreach (var item in TaxInfo.list.GroupBy(x => x.公司))
                {
                    var SumAmount = item.Sum(x => x.金额_不含税);
                    var IsOK = item.Count() <= TaxInfo.CountLimit && SumAmount < TaxInfo.AmountLimit_不含税;
                    lstCompany.Items.Add(new ListViewItem(new string[] { item.Key, item.Count().ToString(), SumAmount.ToString(), IsOK ? "是" : "否" }));
                }
            }
            else
            {
                foreach (var item in TaxInfo.list.GroupBy(x => x.公司))
                {
                    if (!item.Key.Contains(txtSearchKey.Text)) continue;
                    var SumAmount = item.Sum(x => x.金额_不含税);
                    var IsOK = item.Count() <= TaxInfo.CountLimit && SumAmount < TaxInfo.AmountLimit_不含税;
                    lstCompany.Items.Add(new ListViewItem(new string[] { item.Key, item.Count().ToString(), SumAmount.ToString(), IsOK ? "是" : "否" }));
                }
            }
        }

        private void btnMergeRecipe_Click(object sender, EventArgs e)
        {
            //合并当前发票
            if (lstRecipeDetails.CheckedItems.Count < 2)
            {
                MessageBox.Show("请选择需要合并的发票");
                return;
            }
            //单价和规格一致的发票进行合并
            bool HasPrint = false;
            bool HasSplited = false;
            bool HasMerged = false;
            bool HasMinus = false;
            var checkItems = new List<ItemDetail>();
            foreach (ListViewItem item in lstRecipeDetails.CheckedItems)
            {
                var r = (item.Tag as ItemDetail);
                if (r.已开票)
                {
                    HasPrint = true;
                    break;
                }
                if (r.金额_不含税 < 0)
                {
                    HasMinus = true;
                    break;
                }
                if (r.被拆分)
                {
                    HasSplited = true;
                    break;
                }
                if (r.被合并)
                {
                    HasMerged = true;
                    break;
                }
                checkItems.Add(r);
            }
            if (HasSplited)
            {
                MessageBox.Show("发票里面有被拆分项目");
                return;
            }
            if (HasMerged)
            {
                MessageBox.Show("发票里面有被合并项目");
                return;
            }
            if (HasPrint)
            {
                MessageBox.Show("发票里面有已开票项目");
                return;
            }
            if (HasMinus)
            {
                MessageBox.Show("发票里面有冲账项目");
                return;
            }

            if (checkItems.Select(x => x.规格).Distinct().Count() != 1)
            {
                MessageBox.Show("规格不统一");
                return;
            }
            if (checkItems.Select(x => x.单价_不含税).Distinct().Count() != 1)
            {
                MessageBox.Show("单价(不含税)不统一");
                return;
            }
            if (checkItems.Select(x => x.品名).Distinct().Count() != 1)
            {
                MessageBox.Show("品名不统一");
                return;
            }
            foreach (var item in checkItems)
            {
                item.被合并 = true;
            }
            //
            var NewRecipe = new ItemDetail();
            NewRecipe.公司 = checkItems[0].公司;
            NewRecipe.编码 = checkItems[0].编码;
            NewRecipe.品名 = checkItems[0].品名;
            NewRecipe.规格 = checkItems[0].规格;
            NewRecipe.单位 = checkItems[0].单位;
            NewRecipe.数量 = checkItems.Sum(x => x.数量);
            NewRecipe.单价_不含税 = checkItems[0].单价_不含税;
            NewRecipe.金额_不含税 = checkItems.Sum(x => x.金额_不含税);
            NewRecipe.税率 = checkItems[0].税率;
            NewRecipe.税额 = checkItems.Sum(x => x.税额);
            TaxInfo.list.Add(NewRecipe);
            lstCompany_SelectedIndexChanged(null, null);
        }
    }
}
