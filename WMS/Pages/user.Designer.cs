namespace WMS
{
    partial class WMSuser
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNullName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textOldPwd = new System.Windows.Forms.TextBox();
            this.buttonEditPwd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textNewPwd2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNewPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.panelTitle1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textAddPwd2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textAddPwd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textaddName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.labelNullOldPwd = new System.Windows.Forms.Label();
            this.labelNullNewPwd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAdminPwd = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelTitle1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(43, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "身份";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "管理员",
            "普通用户"});
            this.comboBox1.Location = new System.Drawing.Point(123, 282);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 23);
            this.comboBox1.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.labelNullNewPwd);
            this.panel1.Controls.Add(this.labelNullOldPwd);
            this.panel1.Controls.Add(this.labelNullName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textOldPwd);
            this.panel1.Controls.Add(this.buttonEditPwd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textNewPwd2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textNewPwd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textUserName);
            this.panel1.Controls.Add(this.panelTitle1);
            this.panel1.Location = new System.Drawing.Point(47, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 411);
            this.panel1.TabIndex = 2;
            // 
            // labelNullName
            // 
            this.labelNullName.AutoSize = true;
            this.labelNullName.ForeColor = System.Drawing.Color.Red;
            this.labelNullName.Location = new System.Drawing.Point(120, 136);
            this.labelNullName.Name = "labelNullName";
            this.labelNullName.Size = new System.Drawing.Size(112, 15);
            this.labelNullName.TabIndex = 22;
            this.labelNullName.Text = "用户名不能为空";
            this.labelNullName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(27, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "旧密码";
            // 
            // textOldPwd
            // 
            this.textOldPwd.Location = new System.Drawing.Point(112, 160);
            this.textOldPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textOldPwd.Multiline = true;
            this.textOldPwd.Name = "textOldPwd";
            this.textOldPwd.PasswordChar = '*';
            this.textOldPwd.Size = new System.Drawing.Size(180, 30);
            this.textOldPwd.TabIndex = 20;
            // 
            // buttonEditPwd
            // 
            this.buttonEditPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.buttonEditPwd.FlatAppearance.BorderSize = 0;
            this.buttonEditPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditPwd.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonEditPwd.Location = new System.Drawing.Point(239, 339);
            this.buttonEditPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditPwd.Name = "buttonEditPwd";
            this.buttonEditPwd.Size = new System.Drawing.Size(99, 42);
            this.buttonEditPwd.TabIndex = 19;
            this.buttonEditPwd.Text = "确定";
            this.buttonEditPwd.UseVisualStyleBackColor = false;
            this.buttonEditPwd.Click += new System.EventHandler(this.buttonEditPwd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(119, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "两次输入密码不一致";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(7, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "确认密码";
            // 
            // textNewPwd2
            // 
            this.textNewPwd2.Location = new System.Drawing.Point(111, 275);
            this.textNewPwd2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNewPwd2.Multiline = true;
            this.textNewPwd2.Name = "textNewPwd2";
            this.textNewPwd2.PasswordChar = '*';
            this.textNewPwd2.Size = new System.Drawing.Size(180, 30);
            this.textNewPwd2.TabIndex = 16;
            this.textNewPwd2.TextChanged += new System.EventHandler(this.textNewPwd2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(27, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "新密码";
            // 
            // textNewPwd
            // 
            this.textNewPwd.Location = new System.Drawing.Point(112, 216);
            this.textNewPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNewPwd.Multiline = true;
            this.textNewPwd.Name = "textNewPwd";
            this.textNewPwd.PasswordChar = '*';
            this.textNewPwd.Size = new System.Drawing.Size(180, 30);
            this.textNewPwd.TabIndex = 14;
            this.textNewPwd.TextChanged += new System.EventHandler(this.textNewPwd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(27, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "用户名";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(112, 104);
            this.textUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textUserName.Multiline = true;
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(180, 30);
            this.textUserName.TabIndex = 10;
            // 
            // panelTitle1
            // 
            this.panelTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.panelTitle1.Controls.Add(this.label11);
            this.panelTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelTitle1.Location = new System.Drawing.Point(0, 0);
            this.panelTitle1.Name = "panelTitle1";
            this.panelTitle1.Size = new System.Drawing.Size(385, 72);
            this.panelTitle1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(26, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 27);
            this.label11.TabIndex = 0;
            this.label11.Text = "修改密码";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textAdminPwd);
            this.panel2.Controls.Add(this.buttonAddUser);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textAddPwd2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textAddPwd);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textaddName);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(575, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 411);
            this.panel2.TabIndex = 3;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.buttonAddUser.FlatAppearance.BorderSize = 0;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonAddUser.Location = new System.Drawing.Point(230, 339);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(99, 42);
            this.buttonAddUser.TabIndex = 27;
            this.buttonAddUser.Text = "确定";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(17, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "确认密码";
            // 
            // textAddPwd2
            // 
            this.textAddPwd2.Location = new System.Drawing.Point(123, 183);
            this.textAddPwd2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAddPwd2.Multiline = true;
            this.textAddPwd2.Name = "textAddPwd2";
            this.textAddPwd2.PasswordChar = '*';
            this.textAddPwd2.Size = new System.Drawing.Size(180, 30);
            this.textAddPwd2.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(43, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "密码";
            // 
            // textAddPwd
            // 
            this.textAddPwd.Location = new System.Drawing.Point(123, 136);
            this.textAddPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAddPwd.Multiline = true;
            this.textAddPwd.Name = "textAddPwd";
            this.textAddPwd.PasswordChar = '*';
            this.textAddPwd.Size = new System.Drawing.Size(180, 30);
            this.textAddPwd.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(37, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "用户名";
            // 
            // textaddName
            // 
            this.textaddName.Location = new System.Drawing.Point(123, 93);
            this.textaddName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textaddName.Multiline = true;
            this.textaddName.Name = "textaddName";
            this.textaddName.Size = new System.Drawing.Size(180, 30);
            this.textaddName.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label17);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 72);
            this.panel3.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(26, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 27);
            this.label17.TabIndex = 0;
            this.label17.Text = "新建用户";
            // 
            // labelNullOldPwd
            // 
            this.labelNullOldPwd.AutoSize = true;
            this.labelNullOldPwd.ForeColor = System.Drawing.Color.Red;
            this.labelNullOldPwd.Location = new System.Drawing.Point(120, 197);
            this.labelNullOldPwd.Name = "labelNullOldPwd";
            this.labelNullOldPwd.Size = new System.Drawing.Size(112, 15);
            this.labelNullOldPwd.TabIndex = 23;
            this.labelNullOldPwd.Text = "旧密码不能为空";
            this.labelNullOldPwd.Visible = false;
            // 
            // labelNullNewPwd
            // 
            this.labelNullNewPwd.AutoSize = true;
            this.labelNullNewPwd.ForeColor = System.Drawing.Color.Red;
            this.labelNullNewPwd.Location = new System.Drawing.Point(120, 255);
            this.labelNullNewPwd.Name = "labelNullNewPwd";
            this.labelNullNewPwd.Size = new System.Drawing.Size(112, 15);
            this.labelNullNewPwd.TabIndex = 24;
            this.labelNullNewPwd.Text = "新密码不能为空";
            this.labelNullNewPwd.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(15, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "admin密码";
            // 
            // textAdminPwd
            // 
            this.textAdminPwd.Location = new System.Drawing.Point(123, 227);
            this.textAdminPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAdminPwd.Multiline = true;
            this.textAdminPwd.Name = "textAdminPwd";
            this.textAdminPwd.PasswordChar = '*';
            this.textAdminPwd.Size = new System.Drawing.Size(180, 30);
            this.textAdminPwd.TabIndex = 28;
            // 
            // WMSuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WMSuser";
            this.Text = "用户管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTitle1.ResumeLayout(false);
            this.panelTitle1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTitle1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonEditPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNewPwd2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNewPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textAddPwd2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textAddPwd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textaddName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textOldPwd;
        private System.Windows.Forms.Label labelNullName;
        private System.Windows.Forms.Label labelNullOldPwd;
        private System.Windows.Forms.Label labelNullNewPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAdminPwd;
    }
}