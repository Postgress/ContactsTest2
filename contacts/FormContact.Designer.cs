namespace contacts
{
    partial class FormContact
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContact));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.enterName = new System.Windows.Forms.Label();
            this.dtBithday = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbLName = new System.Windows.Forms.TextBox();
            this.txbSecName = new System.Windows.Forms.TextBox();
            this.picB1 = new System.Windows.Forms.PictureBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Numbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bCreate = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bCancel);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.bCreate);
            this.splitContainer1.Size = new System.Drawing.Size(668, 473);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.enterName);
            this.splitContainer3.Panel1.Controls.Add(this.dtBithday);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.txbMail);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.txbName);
            this.splitContainer3.Panel1.Controls.Add(this.txbLName);
            this.splitContainer3.Panel1.Controls.Add(this.txbSecName);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.picB1);
            this.splitContainer3.Size = new System.Drawing.Size(668, 294);
            this.splitContainer3.SplitterDistance = 379;
            this.splitContainer3.TabIndex = 0;
            // 
            // enterName
            // 
            this.enterName.AutoSize = true;
            this.enterName.ForeColor = System.Drawing.Color.Firebrick;
            this.enterName.Location = new System.Drawing.Point(105, 9);
            this.enterName.Name = "enterName";
            this.enterName.Size = new System.Drawing.Size(74, 13);
            this.enterName.TabIndex = 16;
            this.enterName.Text = "Введите Имя";
            this.enterName.Visible = false;
            // 
            // dtBithday
            // 
            this.dtBithday.Location = new System.Drawing.Point(105, 152);
            this.dtBithday.Mask = "00/00/0000";
            this.dtBithday.Name = "dtBithday";
            this.dtBithday.ResetOnSpace = false;
            this.dtBithday.Size = new System.Drawing.Size(62, 20);
            this.dtBithday.TabIndex = 14;
            this.dtBithday.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "e-mail";
            // 
            // txbMail
            // 
            this.txbMail.Location = new System.Drawing.Point(104, 115);
            this.txbMail.Name = "txbMail";
            this.txbMail.Size = new System.Drawing.Size(224, 20);
            this.txbMail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Дата рождения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчество";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(104, 22);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(224, 20);
            this.txbName.TabIndex = 0;
            this.txbName.Leave += new System.EventHandler(this.txbName_Leave);
            // 
            // txbLName
            // 
            this.txbLName.Location = new System.Drawing.Point(104, 86);
            this.txbLName.Name = "txbLName";
            this.txbLName.Size = new System.Drawing.Size(224, 20);
            this.txbLName.TabIndex = 12;
            // 
            // txbSecName
            // 
            this.txbSecName.Location = new System.Drawing.Point(104, 54);
            this.txbSecName.Multiline = true;
            this.txbSecName.Name = "txbSecName";
            this.txbSecName.Size = new System.Drawing.Size(224, 20);
            this.txbSecName.TabIndex = 13;
            // 
            // picB1
            // 
            this.picB1.Image = ((System.Drawing.Image)(resources.GetObject("picB1.Image")));
            this.picB1.Location = new System.Drawing.Point(32, 40);
            this.picB1.MaximumSize = new System.Drawing.Size(220, 220);
            this.picB1.MinimumSize = new System.Drawing.Size(220, 220);
            this.picB1.Name = "picB1";
            this.picB1.Size = new System.Drawing.Size(220, 220);
            this.picB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picB1.TabIndex = 0;
            this.picB1.TabStop = false;
            this.picB1.Click += new System.EventHandler(this.picB1_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(23, 140);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numbers,
            this.Types});
            this.dataGridView1.Location = new System.Drawing.Point(85, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(491, 131);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // Numbers
            // 
            this.Numbers.HeaderText = "Numbers";
            this.Numbers.Name = "Numbers";
            this.Numbers.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Numbers.Width = 250;
            // 
            // Types
            // 
            this.Types.HeaderText = "Types";
            this.Types.Name = "Types";
            this.Types.Width = 200;
            // 
            // bCreate
            // 
            this.bCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bCreate.Location = new System.Drawing.Point(560, 140);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(96, 23);
            this.bCreate.TabIndex = 4;
            this.bCreate.Text = "Создать";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(668, 183);
            this.splitContainer2.SplitterDistance = 154;
            this.splitContainer2.TabIndex = 0;
            // 
            // FormContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormContact";
            this.Text = "FormContact";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMail;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.PictureBox picB1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txbSecName;
        private System.Windows.Forms.TextBox txbLName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.BindingSource typePhoneBindingSource;
        private System.Windows.Forms.BindingSource typePhoneBindingSource1;
        private System.Windows.Forms.BindingSource contactsDataSetBindingSource;
    
        private System.Windows.Forms.BindingSource numberTypeBindingSource;
  
        private System.Windows.Forms.BindingSource phoneContactsDataSet1BindingSource;

        private System.Windows.Forms.BindingSource numberTypesBindingSource;

        private System.Windows.Forms.BindingSource numberTypesBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox dtBithday;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label enterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbers;
        private System.Windows.Forms.DataGridViewComboBoxColumn Types;
    }
}

