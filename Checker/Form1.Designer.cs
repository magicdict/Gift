namespace Checker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnRecipe = new System.Windows.Forms.TextBox();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.btnUnRecipe = new System.Windows.Forms.Button();
            this.btnRemain = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radTypeA = new System.Windows.Forms.RadioButton();
            this.radTypeB = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "未进/出发票XLS文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "销售余额XLS文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "核算项目余额表";
            // 
            // txtUnRecipe
            // 
            this.txtUnRecipe.Location = new System.Drawing.Point(157, 26);
            this.txtUnRecipe.Name = "txtUnRecipe";
            this.txtUnRecipe.Size = new System.Drawing.Size(316, 21);
            this.txtUnRecipe.TabIndex = 1;
            // 
            // txtRemain
            // 
            this.txtRemain.Location = new System.Drawing.Point(157, 57);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(316, 21);
            this.txtRemain.TabIndex = 1;
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(157, 90);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(316, 21);
            this.txtCheck.TabIndex = 1;
            // 
            // btnUnRecipe
            // 
            this.btnUnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnRecipe.Location = new System.Drawing.Point(491, 24);
            this.btnUnRecipe.Name = "btnUnRecipe";
            this.btnUnRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnUnRecipe.TabIndex = 2;
            this.btnUnRecipe.Text = "浏览...";
            this.btnUnRecipe.UseVisualStyleBackColor = true;
            this.btnUnRecipe.Click += new System.EventHandler(this.btnUnRecipe_Click);
            // 
            // btnRemain
            // 
            this.btnRemain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemain.Location = new System.Drawing.Point(491, 55);
            this.btnRemain.Name = "btnRemain";
            this.btnRemain.Size = new System.Drawing.Size(75, 23);
            this.btnRemain.TabIndex = 2;
            this.btnRemain.Text = "浏览...";
            this.btnRemain.UseVisualStyleBackColor = true;
            this.btnRemain.Click += new System.EventHandler(this.btnRemain_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Location = new System.Drawing.Point(491, 88);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "浏览...";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Location = new System.Drawing.Point(219, 146);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(159, 33);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "运行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radTypeB);
            this.groupBox1.Controls.Add(this.radTypeA);
            this.groupBox1.Location = new System.Drawing.Point(47, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别";
            // 
            // radTypeA
            // 
            this.radTypeA.AutoSize = true;
            this.radTypeA.Checked = true;
            this.radTypeA.Location = new System.Drawing.Point(24, 21);
            this.radTypeA.Name = "radTypeA";
            this.radTypeA.Size = new System.Drawing.Size(47, 16);
            this.radTypeA.TabIndex = 0;
            this.radTypeA.TabStop = true;
            this.radTypeA.Text = "借方";
            this.radTypeA.UseVisualStyleBackColor = true;
            // 
            // radTypeB
            // 
            this.radTypeB.AutoSize = true;
            this.radTypeB.Location = new System.Drawing.Point(77, 20);
            this.radTypeB.Name = "radTypeB";
            this.radTypeB.Size = new System.Drawing.Size(47, 16);
            this.radTypeB.TabIndex = 0;
            this.radTypeB.Text = "贷方";
            this.radTypeB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 228);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnRemain);
            this.Controls.Add(this.btnUnRecipe);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.txtUnRecipe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "核算项目余额表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnRecipe;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.Button btnUnRecipe;
        private System.Windows.Forms.Button btnRemain;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radTypeB;
        private System.Windows.Forms.RadioButton radTypeA;
    }
}

