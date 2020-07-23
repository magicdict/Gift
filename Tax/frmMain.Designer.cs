namespace Tax
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnReadOrg = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstCompany = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.txtXMLFolder = new System.Windows.Forms.TextBox();
            this.btnCreateSimpleRecipe = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPickXmlFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRecipeDetails = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMergeRecipe = new System.Windows.Forms.Button();
            this.chkFilenameTimeStamp = new System.Windows.Forms.CheckBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSplitRecipe = new System.Windows.Forms.Button();
            this.btnCreateRecipeXML = new System.Windows.Forms.Button();
            this.lblSelectAmount = new System.Windows.Forms.Label();
            this.lblSelectCount = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReadOrg
            // 
            this.btnReadOrg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadOrg.Location = new System.Drawing.Point(12, 9);
            this.btnReadOrg.Name = "btnReadOrg";
            this.btnReadOrg.Size = new System.Drawing.Size(151, 23);
            this.btnReadOrg.TabIndex = 3;
            this.btnReadOrg.Text = "读取销项发票明细";
            this.btnReadOrg.UseVisualStyleBackColor = true;
            this.btnReadOrg.Click += new System.EventHandler(this.btnReadOrg_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1663, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstCompany);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstRecipeDetails);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1663, 607);
            this.splitContainer1.SplitterDistance = 598;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstCompany
            // 
            this.lstCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCompany.FullRowSelect = true;
            this.lstCompany.GridLines = true;
            this.lstCompany.HideSelection = false;
            this.lstCompany.Location = new System.Drawing.Point(0, 131);
            this.lstCompany.Name = "lstCompany";
            this.lstCompany.Size = new System.Drawing.Size(598, 476);
            this.lstCompany.TabIndex = 4;
            this.lstCompany.UseCompatibleStateImageBehavior = false;
            this.lstCompany.View = System.Windows.Forms.View.Details;
            this.lstCompany.SelectedIndexChanged += new System.EventHandler(this.lstCompany_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearchKey);
            this.panel1.Controls.Add(this.txtXMLFolder);
            this.panel1.Controls.Add(this.btnCreateSimpleRecipe);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnPickXmlFolder);
            this.panel1.Controls.Add(this.btnReadOrg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 131);
            this.panel1.TabIndex = 5;
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(89, 88);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(357, 21);
            this.txtSearchKey.TabIndex = 4;
            // 
            // txtXMLFolder
            // 
            this.txtXMLFolder.Location = new System.Drawing.Point(89, 46);
            this.txtXMLFolder.Name = "txtXMLFolder";
            this.txtXMLFolder.ReadOnly = true;
            this.txtXMLFolder.Size = new System.Drawing.Size(357, 21);
            this.txtXMLFolder.TabIndex = 2;
            // 
            // btnCreateSimpleRecipe
            // 
            this.btnCreateSimpleRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSimpleRecipe.Location = new System.Drawing.Point(169, 9);
            this.btnCreateSimpleRecipe.Name = "btnCreateSimpleRecipe";
            this.btnCreateSimpleRecipe.Size = new System.Drawing.Size(180, 23);
            this.btnCreateSimpleRecipe.TabIndex = 3;
            this.btnCreateSimpleRecipe.Text = "新建所有简单发票XML文件";
            this.btnCreateSimpleRecipe.UseVisualStyleBackColor = true;
            this.btnCreateSimpleRecipe.Click += new System.EventHandler(this.btnCreateSimpleRecipe_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(467, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "检索...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPickXmlFolder
            // 
            this.btnPickXmlFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickXmlFolder.Location = new System.Drawing.Point(467, 46);
            this.btnPickXmlFolder.Name = "btnPickXmlFolder";
            this.btnPickXmlFolder.Size = new System.Drawing.Size(71, 26);
            this.btnPickXmlFolder.TabIndex = 1;
            this.btnPickXmlFolder.Text = "浏览...";
            this.btnPickXmlFolder.UseVisualStyleBackColor = true;
            this.btnPickXmlFolder.Click += new System.EventHandler(this.btnPickXmlFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "公司名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "XML默认目录";
            // 
            // lstRecipeDetails
            // 
            this.lstRecipeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecipeDetails.FullRowSelect = true;
            this.lstRecipeDetails.GridLines = true;
            this.lstRecipeDetails.HideSelection = false;
            this.lstRecipeDetails.Location = new System.Drawing.Point(0, 0);
            this.lstRecipeDetails.Name = "lstRecipeDetails";
            this.lstRecipeDetails.Size = new System.Drawing.Size(1061, 453);
            this.lstRecipeDetails.TabIndex = 0;
            this.lstRecipeDetails.UseCompatibleStateImageBehavior = false;
            this.lstRecipeDetails.View = System.Windows.Forms.View.Details;
            this.lstRecipeDetails.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstRecipeDetails_ItemChecked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMergeRecipe);
            this.panel2.Controls.Add(this.chkFilenameTimeStamp);
            this.panel2.Controls.Add(this.txtFilename);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSplitRecipe);
            this.panel2.Controls.Add(this.btnCreateRecipeXML);
            this.panel2.Controls.Add(this.lblSelectAmount);
            this.panel2.Controls.Add(this.lblSelectCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1061, 154);
            this.panel2.TabIndex = 1;
            // 
            // btnMergeRecipe
            // 
            this.btnMergeRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeRecipe.Location = new System.Drawing.Point(542, 13);
            this.btnMergeRecipe.Name = "btnMergeRecipe";
            this.btnMergeRecipe.Size = new System.Drawing.Size(155, 26);
            this.btnMergeRecipe.TabIndex = 5;
            this.btnMergeRecipe.Text = "合并当前选中发票";
            this.btnMergeRecipe.UseVisualStyleBackColor = true;
            this.btnMergeRecipe.Click += new System.EventHandler(this.btnMergeRecipe_Click);
            // 
            // chkFilenameTimeStamp
            // 
            this.chkFilenameTimeStamp.AutoSize = true;
            this.chkFilenameTimeStamp.Checked = true;
            this.chkFilenameTimeStamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilenameTimeStamp.Location = new System.Drawing.Point(105, 92);
            this.chkFilenameTimeStamp.Name = "chkFilenameTimeStamp";
            this.chkFilenameTimeStamp.Size = new System.Drawing.Size(120, 16);
            this.chkFilenameTimeStamp.TabIndex = 4;
            this.chkFilenameTimeStamp.Text = "文件名添加时间戳";
            this.chkFilenameTimeStamp.UseVisualStyleBackColor = true;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(105, 53);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(231, 21);
            this.txtFilename.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "XML文件名";
            // 
            // btnSplitRecipe
            // 
            this.btnSplitRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplitRecipe.Location = new System.Drawing.Point(370, 13);
            this.btnSplitRecipe.Name = "btnSplitRecipe";
            this.btnSplitRecipe.Size = new System.Drawing.Size(155, 26);
            this.btnSplitRecipe.TabIndex = 1;
            this.btnSplitRecipe.Text = "拆分当前选中发票";
            this.btnSplitRecipe.UseVisualStyleBackColor = true;
            this.btnSplitRecipe.Click += new System.EventHandler(this.btnSplitRecipe_Click);
            // 
            // btnCreateRecipeXML
            // 
            this.btnCreateRecipeXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRecipeXML.Location = new System.Drawing.Point(370, 49);
            this.btnCreateRecipeXML.Name = "btnCreateRecipeXML";
            this.btnCreateRecipeXML.Size = new System.Drawing.Size(155, 26);
            this.btnCreateRecipeXML.TabIndex = 1;
            this.btnCreateRecipeXML.Text = "发票XML文件做成";
            this.btnCreateRecipeXML.UseVisualStyleBackColor = true;
            this.btnCreateRecipeXML.Click += new System.EventHandler(this.btnCreateRecipeXML_Click);
            // 
            // lblSelectAmount
            // 
            this.lblSelectAmount.AutoSize = true;
            this.lblSelectAmount.Location = new System.Drawing.Point(150, 20);
            this.lblSelectAmount.Name = "lblSelectAmount";
            this.lblSelectAmount.Size = new System.Drawing.Size(71, 12);
            this.lblSelectAmount.TabIndex = 0;
            this.lblSelectAmount.Text = "选中金额：0";
            // 
            // lblSelectCount
            // 
            this.lblSelectCount.AutoSize = true;
            this.lblSelectCount.Location = new System.Drawing.Point(29, 20);
            this.lblSelectCount.Name = "lblSelectCount";
            this.lblSelectCount.Size = new System.Drawing.Size(71, 12);
            this.lblSelectCount.TabIndex = 0;
            this.lblSelectCount.Text = "选中件数：0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1663, 629);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开发票 20200622";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReadOrg;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstCompany;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateSimpleRecipe;
        private System.Windows.Forms.ListView lstRecipeDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSelectAmount;
        private System.Windows.Forms.Label lblSelectCount;
        private System.Windows.Forms.Button btnCreateRecipeXML;
        private System.Windows.Forms.TextBox txtXMLFolder;
        private System.Windows.Forms.Button btnPickXmlFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSplitRecipe;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFilenameTimeStamp;
        private System.Windows.Forms.Button btnMergeRecipe;
    }
}

