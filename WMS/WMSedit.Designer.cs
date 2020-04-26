namespace WMS
{
    partial class WMSedit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEdit = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modify = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1082, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(934, 38);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(122, 32);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "批量删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(793, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "显示全部";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(353, 38);
            this.textName.Multiline = true;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(244, 32);
            this.textName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(258, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品名称";
            // 
            // dgvEdit
            // 
            this.dgvEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.productID,
            this.name,
            this.stock,
            this.unit,
            this.supplier,
            this.entry,
            this.remarks,
            this.modify,
            this.delete});
            this.dgvEdit.Location = new System.Drawing.Point(0, 86);
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.RowTemplate.Height = 27;
            this.dgvEdit.Size = new System.Drawing.Size(1082, 435);
            this.dgvEdit.TabIndex = 3;
            this.dgvEdit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEdit_CellContentClick);
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Width = 30;
            // 
            // productID
            // 
            this.productID.DataPropertyName = "productID";
            this.productID.HeaderText = "产品ID";
            this.productID.Name = "productID";
            this.productID.Width = 80;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "产品名称";
            this.name.Name = "name";
            // 
            // stock
            // 
            this.stock.DataPropertyName = "stock";
            this.stock.HeaderText = "数量";
            this.stock.Name = "stock";
            this.stock.Width = 50;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.Width = 50;
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "供应商";
            this.supplier.Name = "supplier";
            this.supplier.Width = 110;
            // 
            // entry
            // 
            this.entry.DataPropertyName = "entry";
            this.entry.HeaderText = "录入人员";
            this.entry.Name = "entry";
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "备注";
            this.remarks.Name = "remarks";
            this.remarks.Width = 150;
            // 
            // modify
            // 
            dataGridViewCellStyle1.NullValue = "修改";
            this.modify.DefaultCellStyle = dataGridViewCellStyle1;
            this.modify.HeaderText = "修改";
            this.modify.Name = "modify";
            this.modify.Width = 50;
            // 
            // delete
            // 
            dataGridViewCellStyle2.NullValue = "删除";
            this.delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.Width = 50;
            // 
            // WMSedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 533);
            this.Controls.Add(this.dgvEdit);
            this.Controls.Add(this.groupBox1);
            this.Name = "WMSedit";
            this.Text = "修改和删除";
            this.Load += new System.EventHandler(this.WMSedit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn productID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn entry;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewLinkColumn modify;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private System.Windows.Forms.Button buttonDelete;
    }
}