namespace oto2dvcfg
{
    partial class FormFAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFAR));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReplace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.nfcButton2 = new oto2dvcfg.NFCButton();
            this.nfcButton1 = new oto2dvcfg.NFCButton();
            this.buttonLoad = new oto2dvcfg.NFCButton();
            this.buttonSave = new oto2dvcfg.NFCButton();
            this.buttonDel = new oto2dvcfg.NFCButton();
            this.buttonEdit = new oto2dvcfg.NFCButton();
            this.buttonAdd = new oto2dvcfg.NFCButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnFind,
            this.columnReplace});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(494, 544);
            this.listView1.TabIndex = 31;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 234;
            // 
            // columnFind
            // 
            this.columnFind.Text = "Find";
            this.columnFind.Width = 130;
            // 
            // columnReplace
            // 
            this.columnReplace.Text = "Replace";
            this.columnReplace.Width = 130;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // nfcButton2
            // 
            this.nfcButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nfcButton2.ForeColor = System.Drawing.Color.White;
            this.nfcButton2.Location = new System.Drawing.Point(598, 528);
            this.nfcButton2.Name = "nfcButton2";
            this.nfcButton2.Size = new System.Drawing.Size(83, 28);
            this.nfcButton2.TabIndex = 38;
            this.nfcButton2.Text = "Cancel";
            this.nfcButton2.UseVisualStyleBackColor = true;
            this.nfcButton2.Click += new System.EventHandler(this.NfcButton2_Click);
            // 
            // nfcButton1
            // 
            this.nfcButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nfcButton1.ForeColor = System.Drawing.Color.White;
            this.nfcButton1.Location = new System.Drawing.Point(512, 528);
            this.nfcButton1.Name = "nfcButton1";
            this.nfcButton1.Size = new System.Drawing.Size(83, 28);
            this.nfcButton1.TabIndex = 37;
            this.nfcButton1.Text = "OK";
            this.nfcButton1.UseVisualStyleBackColor = true;
            this.nfcButton1.Click += new System.EventHandler(this.NfcButton1_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(512, 479);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(169, 43);
            this.buttonLoad.TabIndex = 36;
            this.buttonLoad.Text = "Load from template ";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(512, 430);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(169, 43);
            this.buttonSave.TabIndex = 35;
            this.buttonSave.Text = "Save to template ";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDel.ForeColor = System.Drawing.Color.White;
            this.buttonDel.Location = new System.Drawing.Point(512, 86);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(169, 31);
            this.buttonDel.TabIndex = 34;
            this.buttonDel.Text = "Delete rule";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(512, 49);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(169, 31);
            this.buttonEdit.TabIndex = 33;
            this.buttonEdit.Text = "Edit rule";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(512, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(169, 31);
            this.buttonAdd.TabIndex = 32;
            this.buttonAdd.Text = "Add rule";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // FormFAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(738, 568);
            this.Controls.Add(this.nfcButton2);
            this.Controls.Add(this.nfcButton1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormFAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFAR";
            this.Load += new System.EventHandler(this.FormFAR_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnFind;
        private System.Windows.Forms.ColumnHeader columnReplace;
        private NFCButton buttonAdd;
        private NFCButton buttonEdit;
        private NFCButton buttonDel;
        private NFCButton buttonSave;
        private NFCButton buttonLoad;
        private NFCButton nfcButton1;
        private NFCButton nfcButton2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}