namespace SY.Client.Forms
{
    partial class AddCategoryForm
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
            this.tb_categoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_AJHComponent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_WJJComponent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb_AJJ = new System.Windows.Forms.RadioButton();
            this.rb_WJJ = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.cb_categoryParentDescription = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_categoryName
            // 
            this.tb_categoryName.Location = new System.Drawing.Point(175, 22);
            this.tb_categoryName.Name = "tb_categoryName";
            this.tb_categoryName.Size = new System.Drawing.Size(244, 21);
            this.tb_categoryName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "分类号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(74, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "父分类名称：";
            // 
            // tb_AJHComponent
            // 
            this.tb_AJHComponent.Location = new System.Drawing.Point(175, 91);
            this.tb_AJHComponent.Name = "tb_AJHComponent";
            this.tb_AJHComponent.ReadOnly = true;
            this.tb_AJHComponent.Size = new System.Drawing.Size(244, 21);
            this.tb_AJHComponent.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "案卷级档案号组成：";
            // 
            // tb_WJJComponent
            // 
            this.tb_WJJComponent.Location = new System.Drawing.Point(175, 129);
            this.tb_WJJComponent.Name = "tb_WJJComponent";
            this.tb_WJJComponent.Size = new System.Drawing.Size(244, 21);
            this.tb_WJJComponent.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(124, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "名称：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rb_AJJ);
            this.panel3.Controls.Add(this.rb_WJJ);
            this.panel3.Location = new System.Drawing.Point(182, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(138, 18);
            this.panel3.TabIndex = 22;
            // 
            // rb_AJJ
            // 
            this.rb_AJJ.AutoSize = true;
            this.rb_AJJ.Location = new System.Drawing.Point(3, 1);
            this.rb_AJJ.Name = "rb_AJJ";
            this.rb_AJJ.Size = new System.Drawing.Size(59, 16);
            this.rb_AJJ.TabIndex = 14;
            this.rb_AJJ.Text = "案卷级";
            this.rb_AJJ.UseVisualStyleBackColor = true;
            // 
            // rb_WJJ
            // 
            this.rb_WJJ.AutoSize = true;
            this.rb_WJJ.Checked = true;
            this.rb_WJJ.Location = new System.Drawing.Point(68, 1);
            this.rb_WJJ.Name = "rb_WJJ";
            this.rb_WJJ.Size = new System.Drawing.Size(59, 16);
            this.rb_WJJ.TabIndex = 15;
            this.rb_WJJ.TabStop = true;
            this.rb_WJJ.Text = "文件级";
            this.rb_WJJ.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(91, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "分类类型：";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(344, 205);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 23;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // cb_categoryParentDescription
            // 
            this.cb_categoryParentDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_categoryParentDescription.FormattingEnabled = true;
            this.cb_categoryParentDescription.Location = new System.Drawing.Point(175, 56);
            this.cb_categoryParentDescription.Name = "cb_categoryParentDescription";
            this.cb_categoryParentDescription.Size = new System.Drawing.Size(244, 20);
            this.cb_categoryParentDescription.TabIndex = 27;
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 242);
            this.Controls.Add(this.cb_categoryParentDescription);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_WJJComponent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_AJHComponent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_categoryName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加分类";
            this.Load += new System.EventHandler(this.AddCategoryForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_categoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_AJHComponent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_WJJComponent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rb_AJJ;
        private System.Windows.Forms.RadioButton rb_WJJ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.ComboBox cb_categoryParentDescription;
    }
}