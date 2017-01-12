namespace SY.Client.Forms
{
    partial class AddColumnForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_columnName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_emptyYes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rb_systemNo = new System.Windows.Forms.RadioButton();
            this.rb_systemYes = new System.Windows.Forms.RadioButton();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.bt_add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_emptyNo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_typeDouble = new System.Windows.Forms.RadioButton();
            this.rb_typeBool = new System.Windows.Forms.RadioButton();
            this.rb_typeInt = new System.Windows.Forms.RadioButton();
            this.rb_typeTime = new System.Windows.Forms.RadioButton();
            this.rb_typeString = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.tb_bytes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "字段名：";
            // 
            // tb_columnName
            // 
            this.tb_columnName.Location = new System.Drawing.Point(109, 27);
            this.tb_columnName.Name = "tb_columnName";
            this.tb_columnName.Size = new System.Drawing.Size(306, 21);
            this.tb_columnName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "允许空：";
            // 
            // rb_emptyYes
            // 
            this.rb_emptyYes.AutoSize = true;
            this.rb_emptyYes.Checked = true;
            this.rb_emptyYes.Location = new System.Drawing.Point(7, 5);
            this.rb_emptyYes.Name = "rb_emptyYes";
            this.rb_emptyYes.Size = new System.Drawing.Size(35, 16);
            this.rb_emptyYes.TabIndex = 3;
            this.rb_emptyYes.TabStop = true;
            this.rb_emptyYes.Text = "是";
            this.rb_emptyYes.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "字段类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(30, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "分类号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "系统参数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(46, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "描述：";
            // 
            // rb_systemNo
            // 
            this.rb_systemNo.AutoSize = true;
            this.rb_systemNo.Checked = true;
            this.rb_systemNo.Location = new System.Drawing.Point(42, 1);
            this.rb_systemNo.Name = "rb_systemNo";
            this.rb_systemNo.Size = new System.Drawing.Size(35, 16);
            this.rb_systemNo.TabIndex = 15;
            this.rb_systemNo.TabStop = true;
            this.rb_systemNo.Text = "否";
            this.rb_systemNo.UseVisualStyleBackColor = true;
            // 
            // rb_systemYes
            // 
            this.rb_systemYes.AutoSize = true;
            this.rb_systemYes.Location = new System.Drawing.Point(3, 1);
            this.rb_systemYes.Name = "rb_systemYes";
            this.rb_systemYes.Size = new System.Drawing.Size(35, 16);
            this.rb_systemYes.TabIndex = 14;
            this.rb_systemYes.Text = "是";
            this.rb_systemYes.UseVisualStyleBackColor = true;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(108, 192);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(306, 209);
            this.tb_description.TabIndex = 16;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(329, 405);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 17;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_emptyNo);
            this.panel1.Controls.Add(this.rb_emptyYes);
            this.panel1.Location = new System.Drawing.Point(104, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 24);
            this.panel1.TabIndex = 18;
            // 
            // rb_emptyNo
            // 
            this.rb_emptyNo.AutoSize = true;
            this.rb_emptyNo.Location = new System.Drawing.Point(48, 5);
            this.rb_emptyNo.Name = "rb_emptyNo";
            this.rb_emptyNo.Size = new System.Drawing.Size(35, 16);
            this.rb_emptyNo.TabIndex = 24;
            this.rb_emptyNo.Text = "否";
            this.rb_emptyNo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rb_typeDouble);
            this.panel2.Controls.Add(this.rb_typeBool);
            this.panel2.Controls.Add(this.rb_typeInt);
            this.panel2.Controls.Add(this.rb_typeTime);
            this.panel2.Controls.Add(this.rb_typeString);
            this.panel2.Location = new System.Drawing.Point(101, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 21);
            this.panel2.TabIndex = 19;
            // 
            // rb_typeDouble
            // 
            this.rb_typeDouble.AutoSize = true;
            this.rb_typeDouble.Location = new System.Drawing.Point(228, 4);
            this.rb_typeDouble.Name = "rb_typeDouble";
            this.rb_typeDouble.Size = new System.Drawing.Size(47, 16);
            this.rb_typeDouble.TabIndex = 14;
            this.rb_typeDouble.Text = "浮点";
            this.rb_typeDouble.UseVisualStyleBackColor = true;
            // 
            // rb_typeBool
            // 
            this.rb_typeBool.AutoSize = true;
            this.rb_typeBool.Location = new System.Drawing.Point(166, 3);
            this.rb_typeBool.Name = "rb_typeBool";
            this.rb_typeBool.Size = new System.Drawing.Size(59, 16);
            this.rb_typeBool.TabIndex = 13;
            this.rb_typeBool.Text = "布尔值";
            this.rb_typeBool.UseVisualStyleBackColor = true;
            // 
            // rb_typeInt
            // 
            this.rb_typeInt.AutoSize = true;
            this.rb_typeInt.Location = new System.Drawing.Point(10, 3);
            this.rb_typeInt.Name = "rb_typeInt";
            this.rb_typeInt.Size = new System.Drawing.Size(47, 16);
            this.rb_typeInt.TabIndex = 10;
            this.rb_typeInt.Text = "整数";
            this.rb_typeInt.UseVisualStyleBackColor = true;
            // 
            // rb_typeTime
            // 
            this.rb_typeTime.AutoSize = true;
            this.rb_typeTime.Location = new System.Drawing.Point(116, 3);
            this.rb_typeTime.Name = "rb_typeTime";
            this.rb_typeTime.Size = new System.Drawing.Size(47, 16);
            this.rb_typeTime.TabIndex = 12;
            this.rb_typeTime.Text = "时间";
            this.rb_typeTime.UseVisualStyleBackColor = true;
            // 
            // rb_typeString
            // 
            this.rb_typeString.AutoSize = true;
            this.rb_typeString.Checked = true;
            this.rb_typeString.Location = new System.Drawing.Point(63, 3);
            this.rb_typeString.Name = "rb_typeString";
            this.rb_typeString.Size = new System.Drawing.Size(47, 16);
            this.rb_typeString.TabIndex = 11;
            this.rb_typeString.TabStop = true;
            this.rb_typeString.Text = "字符";
            this.rb_typeString.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rb_systemYes);
            this.panel3.Controls.Add(this.rb_systemNo);
            this.panel3.Location = new System.Drawing.Point(105, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 18);
            this.panel3.TabIndex = 20;
            // 
            // cb_category
            // 
            this.cb_category.FormattingEnabled = true;
            this.cb_category.Location = new System.Drawing.Point(111, 142);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(121, 20);
            this.cb_category.TabIndex = 21;
            // 
            // tb_bytes
            // 
            this.tb_bytes.Location = new System.Drawing.Point(112, 115);
            this.tb_bytes.Name = "tb_bytes";
            this.tb_bytes.Size = new System.Drawing.Size(47, 21);
            this.tb_bytes.TabIndex = 23;
            this.tb_bytes.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(45, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "位数：";
            // 
            // AddColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 433);
            this.Controls.Add(this.tb_bytes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.tb_description);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_columnName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddColumnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加字段";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_columnName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_emptyYes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_systemNo;
        private System.Windows.Forms.RadioButton rb_systemYes;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rb_typeBool;
        private System.Windows.Forms.RadioButton rb_typeInt;
        private System.Windows.Forms.RadioButton rb_typeTime;
        private System.Windows.Forms.RadioButton rb_typeString;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.TextBox tb_bytes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rb_emptyNo;
        private System.Windows.Forms.RadioButton rb_typeDouble;
    }
}