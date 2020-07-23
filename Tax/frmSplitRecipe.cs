using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax
{
    public partial class frmSplitRecipe : Form
    {
        public TaxInfo.ItemDetail OrgRecipe = null;

        List<TaxInfo.ItemDetail> SplitRecipe = new List<TaxInfo.ItemDetail>();

        public delegate void Finished(List<TaxInfo.ItemDetail> items);

        public Finished FinishSplit;

        public frmSplitRecipe()
        {
            InitializeComponent();

        }

        private void frmSplitRecipe_Load(object sender, EventArgs e)
        {
            lblOrgAmount.Text = "金额:" + OrgRecipe.金额_不含税.ToString();
            lblOrgPrice.Text = "单价:" + OrgRecipe.单价_不含税.ToString();
            lblOrgQuilty.Text = "数量:" + OrgRecipe.数量.ToString();
            numSplit.Maximum = (decimal)OrgRecipe.数量;
        }

        private void btnSplite_Click(object sender, EventArgs e)
        {
            //复制一个新的项目
            var Clone = new TaxInfo.ItemDetail();
            Clone.公司 = OrgRecipe.公司;
            Clone.单价_不含税 = OrgRecipe.单价_不含税;
            Clone.单位 = OrgRecipe.单位;
            Clone.品名 = OrgRecipe.品名;
            Clone.已开票 = false;
            Clone.数量 = (double)numSplit.Value;
            Clone.税率 = OrgRecipe.税率;
            Clone.税额 = OrgRecipe.税额;
            Clone.编码 = OrgRecipe.编码;
            Clone.被拆分 = false;
            Clone.规格 = OrgRecipe.规格;
            Clone.金额_不含税 = Math.Round(OrgRecipe.单价_不含税 * Clone.数量,6);
            SplitRecipe.Add(Clone);

            lstRecipeDetails.Clear();
            lstRecipeDetails.Columns.Add("单价（不含税）", 150);
            lstRecipeDetails.Columns.Add("数量", 150);
            lstRecipeDetails.Columns.Add("金额（不含税）", 150);

            foreach (var item in SplitRecipe)
            {
                var lstitem = new ListViewItem(new string[] { item.单价_不含税.ToString(), item.数量.ToString(), item.金额_不含税.ToString() });
                lstitem.Tag = item;
                lstRecipeDetails.Items.Add(lstitem);
            }

            var Qulity = SplitRecipe.Sum(x => x.数量);
            var Remain = Math.Round(OrgRecipe.数量 - Qulity,3);
            if (Remain < 0.000001) Remain = 0;
            numSplit.Maximum = (decimal)Remain;
            lblAssign.Text = "已分配数量：" + Qulity + "剩余数量：" + Remain;
        }

        private void numSplit_ValueChanged(object sender, EventArgs e)
        {
            lblSplitAmout.Text = Math.Round((double)numSplit.Value * OrgRecipe.单价_不含税, 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Qulity = SplitRecipe.Sum(x => x.数量);
            var Remain = (OrgRecipe.数量 - Qulity);
            if (Remain < 0.000001) Remain = 0;
            if (Remain == 0)
            {
                OrgRecipe.被拆分 = true;
                FinishSplit(SplitRecipe);
                this.Close();
            }
            else
            {
                MessageBox.Show("还没有分配完毕！");
            }
        }
    }
}
