namespace Tax
{
    partial class frmSplitRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplitRecipe));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblOrgPrice = new System.Windows.Forms.Label();
            this.lblOrgAmount = new System.Windows.Forms.Label();
            this.lblOrgQuilty = new System.Windows.Forms.Label();
            this.btnSplite = new System.Windows.Forms.Button();
            this.numSplit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRecipeDetails = new System.Windows.Forms.ListView();
            this.lblAssign = new System.Windows.Forms.Label();
            this.lblSplitAmout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(406, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(503, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 33);
            this.button2.TabIndex = 0;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lblOrgPrice
            // 
            this.lblOrgPrice.AutoSize = true;
            this.lblOrgPrice.Location = new System.Drawing.Point(34, 22);
            this.lblOrgPrice.Name = "lblOrgPrice";
            this.lblOrgPrice.Size = new System.Drawing.Size(41, 12);
            this.lblOrgPrice.TabIndex = 1;
            this.lblOrgPrice.Text = "单价：";
            // 
            // lblOrgAmount
            // 
            this.lblOrgAmount.AutoSize = true;
            this.lblOrgAmount.Location = new System.Drawing.Point(135, 22);
            this.lblOrgAmount.Name = "lblOrgAmount";
            this.lblOrgAmount.Size = new System.Drawing.Size(41, 12);
            this.lblOrgAmount.TabIndex = 1;
            this.lblOrgAmount.Text = "金额：";
            // 
            // lblOrgQuilty
            // 
            this.lblOrgQuilty.AutoSize = true;
            this.lblOrgQuilty.Location = new System.Drawing.Point(247, 22);
            this.lblOrgQuilty.Name = "lblOrgQuilty";
            this.lblOrgQuilty.Size = new System.Drawing.Size(41, 12);
            this.lblOrgQuilty.TabIndex = 1;
            this.lblOrgQuilty.Text = "数量：";
            // 
            // btnSplite
            // 
            this.btnSplite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplite.Location = new System.Drawing.Point(342, 56);
            this.btnSplite.Name = "btnSplite";
            this.btnSplite.Size = new System.Drawing.Size(75, 23);
            this.btnSplite.TabIndex = 2;
            this.btnSplite.Text = "分割";
            this.btnSplite.UseVisualStyleBackColor = true;
            this.btnSplite.Click += new System.EventHandler(this.btnSplite_Click);
            // 
            // numSplit
            // 
            this.numSplit.DecimalPlaces = 3;
            this.numSplit.Location = new System.Drawing.Point(137, 58);
            this.numSplit.Name = "numSplit";
            this.numSplit.Size = new System.Drawing.Size(78, 21);
            this.numSplit.TabIndex = 3;
            this.numSplit.ValueChanged += new System.EventHandler(this.numSplit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "分割吨：";
            // 
            // lstRecipeDetails
            // 
            this.lstRecipeDetails.FullRowSelect = true;
            this.lstRecipeDetails.GridLines = true;
            this.lstRecipeDetails.HideSelection = false;
            this.lstRecipeDetails.Location = new System.Drawing.Point(12, 84);
            this.lstRecipeDetails.Name = "lstRecipeDetails";
            this.lstRecipeDetails.Size = new System.Drawing.Size(596, 223);
            this.lstRecipeDetails.TabIndex = 5;
            this.lstRecipeDetails.UseCompatibleStateImageBehavior = false;
            this.lstRecipeDetails.View = System.Windows.Forms.View.Details;
            // 
            // lblAssign
            // 
            this.lblAssign.AutoSize = true;
            this.lblAssign.Location = new System.Drawing.Point(22, 323);
            this.lblAssign.Name = "lblAssign";
            this.lblAssign.Size = new System.Drawing.Size(77, 12);
            this.lblAssign.TabIndex = 1;
            this.lblAssign.Text = "已分配数量：";
            // 
            // lblSplitAmout
            // 
            this.lblSplitAmout.AutoSize = true;
            this.lblSplitAmout.Location = new System.Drawing.Point(247, 62);
            this.lblSplitAmout.Name = "lblSplitAmout";
            this.lblSplitAmout.Size = new System.Drawing.Size(77, 12);
            this.lblSplitAmout.TabIndex = 4;
            this.lblSplitAmout.Text = "金额：0.0000";
            // 
            // frmSplitRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 358);
            this.Controls.Add(this.lstRecipeDetails);
            this.Controls.Add(this.lblSplitAmout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSplit);
            this.Controls.Add(this.btnSplite);
            this.Controls.Add(this.lblAssign);
            this.Controls.Add(this.lblOrgQuilty);
            this.Controls.Add(this.lblOrgAmount);
            this.Controls.Add(this.lblOrgPrice);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplitRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发票拆分";
            this.Load += new System.EventHandler(this.frmSplitRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSplit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblOrgPrice;
        private System.Windows.Forms.Label lblOrgAmount;
        private System.Windows.Forms.Label lblOrgQuilty;
        private System.Windows.Forms.Button btnSplite;
        private System.Windows.Forms.NumericUpDown numSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstRecipeDetails;
        private System.Windows.Forms.Label lblAssign;
        private System.Windows.Forms.Label lblSplitAmout;
    }
}