using System;
using System.Linq;
using System.Windows.Forms;

namespace Gift
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnOpenSysFile_Click(object sender, EventArgs e)
        {
            var Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                txtSysFile.Text = Openfile.FileName;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            var SaveFile = new SaveFileDialog();
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                txtSaveFile.Text = SaveFile.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var rs = Record.ReadSysFile(txtSysFile.Text);
            lblMsg.Text = "读取到库存数：" + rs.Count();
            CoreLogic.Create(rs,txtSaveFile.Text);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CoreLogic.Read_理算重量表();
            lblMsg.Text = "读取理算重量表数：" + CoreLogic.理算重量表.Count();
        }
    }
}
