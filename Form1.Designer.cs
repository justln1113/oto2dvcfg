namespace oto2dvcfg
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Close = new System.Windows.Forms.Button();
            this.openOTO = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textOTOpath = new System.Windows.Forms.TextBox();
            this.Pitch = new System.Windows.Forms.Label();
            this.textPitch = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wavNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aliasColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offsetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.consonantColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cutoffColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.preutteranceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.overlapColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aliasTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lableOTOLines = new System.Windows.Forms.Label();
            this.labelOTOint = new System.Windows.Forms.Label();
            this.textEndNote = new System.Windows.Forms.TextBox();
            this.EndNote = new System.Windows.Forms.Label();
            this.textBreNote = new System.Windows.Forms.TextBox();
            this.BreathEndNote = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RedefineEndNote = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.RedifineBrethEndNote = new System.Windows.Forms.Label();
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Close
            // 
            resources.ApplyResources(this.Close, "Close");
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Close.Name = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // openOTO
            // 
            resources.ApplyResources(this.openOTO, "openOTO");
            this.openOTO.ForeColor = System.Drawing.Color.White;
            this.openOTO.Name = "openOTO";
            this.openOTO.TabStop = false;
            this.openOTO.UseVisualStyleBackColor = true;
            this.openOTO.Click += new System.EventHandler(this.OpenOTO_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // textOTOpath
            // 
            this.textOTOpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textOTOpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textOTOpath.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textOTOpath, "textOTOpath");
            this.textOTOpath.Name = "textOTOpath";
            // 
            // Pitch
            // 
            resources.ApplyResources(this.Pitch, "Pitch");
            this.Pitch.ForeColor = System.Drawing.Color.White;
            this.Pitch.Name = "Pitch";
            // 
            // textPitch
            // 
            this.textPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textPitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPitch.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textPitch, "textPitch");
            this.textPitch.Name = "textPitch";
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Name = "Title";
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // buttonGenerate
            // 
            resources.ApplyResources(this.buttonGenerate, "buttonGenerate");
            this.buttonGenerate.ForeColor = System.Drawing.Color.White;
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNo,
            this.wavNameColumn,
            this.aliasColumn,
            this.offsetColumn,
            this.consonantColumn,
            this.cutoffColumn,
            this.preutteranceColumn,
            this.overlapColumn,
            this.aliasTypeColumn});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.optionChangedList);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnNo
            // 
            resources.ApplyResources(this.columnNo, "columnNo");
            // 
            // wavNameColumn
            // 
            resources.ApplyResources(this.wavNameColumn, "wavNameColumn");
            // 
            // aliasColumn
            // 
            resources.ApplyResources(this.aliasColumn, "aliasColumn");
            // 
            // offsetColumn
            // 
            resources.ApplyResources(this.offsetColumn, "offsetColumn");
            // 
            // consonantColumn
            // 
            resources.ApplyResources(this.consonantColumn, "consonantColumn");
            // 
            // cutoffColumn
            // 
            resources.ApplyResources(this.cutoffColumn, "cutoffColumn");
            // 
            // preutteranceColumn
            // 
            resources.ApplyResources(this.preutteranceColumn, "preutteranceColumn");
            // 
            // overlapColumn
            // 
            resources.ApplyResources(this.overlapColumn, "overlapColumn");
            // 
            // aliasTypeColumn
            // 
            resources.ApplyResources(this.aliasTypeColumn, "aliasTypeColumn");
            // 
            // lableOTOLines
            // 
            resources.ApplyResources(this.lableOTOLines, "lableOTOLines");
            this.lableOTOLines.ForeColor = System.Drawing.Color.White;
            this.lableOTOLines.Name = "lableOTOLines";
            // 
            // labelOTOint
            // 
            resources.ApplyResources(this.labelOTOint, "labelOTOint");
            this.labelOTOint.ForeColor = System.Drawing.Color.White;
            this.labelOTOint.Name = "labelOTOint";
            // 
            // textEndNote
            // 
            this.textEndNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textEndNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textEndNote.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textEndNote, "textEndNote");
            this.textEndNote.Name = "textEndNote";
            // 
            // EndNote
            // 
            resources.ApplyResources(this.EndNote, "EndNote");
            this.EndNote.ForeColor = System.Drawing.Color.White;
            this.EndNote.Name = "EndNote";
            // 
            // textBreNote
            // 
            this.textBreNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBreNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBreNote.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBreNote, "textBreNote");
            this.textBreNote.Name = "textBreNote";
            // 
            // BreathEndNote
            // 
            resources.ApplyResources(this.BreathEndNote, "BreathEndNote");
            this.BreathEndNote.ForeColor = System.Drawing.Color.White;
            this.BreathEndNote.Name = "BreathEndNote";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.optionChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // RedefineEndNote
            // 
            resources.ApplyResources(this.RedefineEndNote, "RedefineEndNote");
            this.RedefineEndNote.ForeColor = System.Drawing.Color.White;
            this.RedefineEndNote.Name = "RedefineEndNote";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // RedifineBrethEndNote
            // 
            resources.ApplyResources(this.RedifineBrethEndNote, "RedifineBrethEndNote");
            this.RedifineBrethEndNote.ForeColor = System.Drawing.Color.White;
            this.RedifineBrethEndNote.Name = "RedifineBrethEndNote";
            // 
            // comboLang
            // 
            this.comboLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.comboLang, "comboLang");
            this.comboLang.ForeColor = System.Drawing.Color.White;
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Name = "comboLang";
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.optionChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboLang);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.RedifineBrethEndNote);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RedefineEndNote);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBreNote);
            this.Controls.Add(this.BreathEndNote);
            this.Controls.Add(this.textEndNote);
            this.Controls.Add(this.EndNote);
            this.Controls.Add(this.labelOTOint);
            this.Controls.Add(this.lableOTOLines);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.textPitch);
            this.Controls.Add(this.Pitch);
            this.Controls.Add(this.textOTOpath);
            this.Controls.Add(this.openOTO);
            this.Controls.Add(this.Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.OpenOTO_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button openOTO;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textOTOpath;
        private System.Windows.Forms.Label Pitch;
        private System.Windows.Forms.TextBox textPitch;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader wavNameColumn;
        private System.Windows.Forms.ColumnHeader aliasColumn;
        private System.Windows.Forms.ColumnHeader offsetColumn;
        private System.Windows.Forms.ColumnHeader consonantColumn;
        private System.Windows.Forms.ColumnHeader cutoffColumn;
        private System.Windows.Forms.ColumnHeader preutteranceColumn;
        private System.Windows.Forms.ColumnHeader overlapColumn;
        private System.Windows.Forms.Label lableOTOLines;
        private System.Windows.Forms.Label labelOTOint;
        private System.Windows.Forms.ColumnHeader aliasTypeColumn;
        private System.Windows.Forms.TextBox textEndNote;
        private System.Windows.Forms.Label EndNote;
        private System.Windows.Forms.TextBox textBreNote;
        private System.Windows.Forms.Label BreathEndNote;
        private System.Windows.Forms.ColumnHeader columnNo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label RedefineEndNote;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label RedifineBrethEndNote;
        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

