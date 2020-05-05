namespace DataRecovery
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
            this.buttonCheck = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIrecovery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(622, 37);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(63, 25);
            this.buttonCheck.TabIndex = 8;
            this.buttonCheck.Text = "...";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(78, 37);
            this.textFile.Name = "textFile";
            this.textFile.ReadOnly = true;
            this.textFile.Size = new System.Drawing.Size(527, 25);
            this.textFile.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(34, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "文件";
            // 
            // buttonIrecovery
            // 
            this.buttonIrecovery.Location = new System.Drawing.Point(537, 84);
            this.buttonIrecovery.Name = "buttonIrecovery";
            this.buttonIrecovery.Size = new System.Drawing.Size(135, 44);
            this.buttonIrecovery.TabIndex = 9;
            this.buttonIrecovery.Text = "确定恢复";
            this.buttonIrecovery.UseVisualStyleBackColor = true;
            this.buttonIrecovery.Click += new System.EventHandler(this.buttonIrecovery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(34, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "数据库备份文件位于back-up文件夹内";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(37, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "注意：数据恢复后，现有未保存的数据将清除";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 151);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonIrecovery);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "数据恢复";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIrecovery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

