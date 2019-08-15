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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.columnhi2ro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lableOTOLines = new System.Windows.Forms.Label();
            this.labelOTOint = new System.Windows.Forms.Label();
            this.textEndNote = new System.Windows.Forms.TextBox();
            this.EndNote = new System.Windows.Forms.Label();
            this.textBreNote = new System.Windows.Forms.TextBox();
            this.BreathEndNote = new System.Windows.Forms.Label();
            this.checkHI2RO = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RedefineEndNote = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.RedifineBrethEndNote = new System.Windows.Forms.Label();
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radioButtonJCVVC = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonCCVVC = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTurn2INDLE = new System.Windows.Forms.ToolStripMenuItem();
            this.textOTOpath = new System.Windows.Forms.Label();
            this.buttonClose = new oto2dvcfg.NFCButton();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // Pitch
            // 
            resources.ApplyResources(this.Pitch, "Pitch");
            this.Pitch.BackColor = System.Drawing.Color.Transparent;
            this.Pitch.ForeColor = System.Drawing.Color.White;
            this.Pitch.Name = "Pitch";
            // 
            // textPitch
            // 
            resources.ApplyResources(this.textPitch, "textPitch");
            this.textPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textPitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPitch.ForeColor = System.Drawing.Color.White;
            this.textPitch.Name = "textPitch";
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNo,
            this.wavNameColumn,
            this.aliasColumn,
            this.offsetColumn,
            this.consonantColumn,
            this.cutoffColumn,
            this.preutteranceColumn,
            this.overlapColumn,
            this.aliasTypeColumn,
            this.columnhi2ro});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseClick);
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
            // columnhi2ro
            // 
            resources.ApplyResources(this.columnhi2ro, "columnhi2ro");
            // 
            // lableOTOLines
            // 
            resources.ApplyResources(this.lableOTOLines, "lableOTOLines");
            this.lableOTOLines.BackColor = System.Drawing.Color.Transparent;
            this.lableOTOLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lableOTOLines.ForeColor = System.Drawing.Color.White;
            this.lableOTOLines.Name = "lableOTOLines";
            // 
            // labelOTOint
            // 
            resources.ApplyResources(this.labelOTOint, "labelOTOint");
            this.labelOTOint.BackColor = System.Drawing.Color.Transparent;
            this.labelOTOint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelOTOint.ForeColor = System.Drawing.Color.White;
            this.labelOTOint.Name = "labelOTOint";
            // 
            // textEndNote
            // 
            resources.ApplyResources(this.textEndNote, "textEndNote");
            this.textEndNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textEndNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textEndNote.ForeColor = System.Drawing.Color.White;
            this.textEndNote.Name = "textEndNote";
            // 
            // EndNote
            // 
            resources.ApplyResources(this.EndNote, "EndNote");
            this.EndNote.BackColor = System.Drawing.Color.Transparent;
            this.EndNote.ForeColor = System.Drawing.Color.White;
            this.EndNote.Name = "EndNote";
            // 
            // textBreNote
            // 
            resources.ApplyResources(this.textBreNote, "textBreNote");
            this.textBreNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBreNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBreNote.ForeColor = System.Drawing.Color.White;
            this.textBreNote.Name = "textBreNote";
            // 
            // BreathEndNote
            // 
            resources.ApplyResources(this.BreathEndNote, "BreathEndNote");
            this.BreathEndNote.BackColor = System.Drawing.Color.Transparent;
            this.BreathEndNote.ForeColor = System.Drawing.Color.White;
            this.BreathEndNote.Name = "BreathEndNote";
            // 
            // checkHI2RO
            // 
            resources.ApplyResources(this.checkHI2RO, "checkHI2RO");
            this.checkHI2RO.BackColor = System.Drawing.Color.Transparent;
            this.checkHI2RO.ForeColor = System.Drawing.Color.White;
            this.checkHI2RO.Name = "checkHI2RO";
            this.checkHI2RO.UseVisualStyleBackColor = false;
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Name = "textBox1";
            // 
            // RedefineEndNote
            // 
            resources.ApplyResources(this.RedefineEndNote, "RedefineEndNote");
            this.RedefineEndNote.BackColor = System.Drawing.Color.Transparent;
            this.RedefineEndNote.ForeColor = System.Drawing.Color.White;
            this.RedefineEndNote.Name = "RedefineEndNote";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Name = "textBox2";
            // 
            // RedifineBrethEndNote
            // 
            resources.ApplyResources(this.RedifineBrethEndNote, "RedifineBrethEndNote");
            this.RedifineBrethEndNote.BackColor = System.Drawing.Color.Transparent;
            this.RedifineBrethEndNote.ForeColor = System.Drawing.Color.White;
            this.RedifineBrethEndNote.Name = "RedifineBrethEndNote";
            // 
            // comboLang
            // 
            resources.ApplyResources(this.comboLang, "comboLang");
            this.comboLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLang.ForeColor = System.Drawing.Color.White;
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Items.AddRange(new object[] {
            resources.GetString("comboLang.Items"),
            resources.GetString("comboLang.Items1")});
            this.comboLang.Name = "comboLang";
            this.comboLang.SelectedIndexChanged += new System.EventHandler(this.ComboLang_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.optionChanged);
            // 
            // radioButtonJCVVC
            // 
            resources.ApplyResources(this.radioButtonJCVVC, "radioButtonJCVVC");
            this.radioButtonJCVVC.ForeColor = System.Drawing.Color.White;
            this.radioButtonJCVVC.Name = "radioButtonJCVVC";
            this.radioButtonJCVVC.TabStop = true;
            this.radioButtonJCVVC.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.radioButtonDefault);
            this.groupBox1.Controls.Add(this.radioButtonCCVVC);
            this.groupBox1.Controls.Add(this.radioButtonJCVVC);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButtonDefault
            // 
            resources.ApplyResources(this.radioButtonDefault, "radioButtonDefault");
            this.radioButtonDefault.ForeColor = System.Drawing.Color.White;
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            // 
            // radioButtonCCVVC
            // 
            resources.ApplyResources(this.radioButtonCCVVC, "radioButtonCCVVC");
            this.radioButtonCCVVC.ForeColor = System.Drawing.Color.White;
            this.radioButtonCCVVC.Name = "radioButtonCCVVC";
            this.radioButtonCCVVC.TabStop = true;
            this.radioButtonCCVVC.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDel,
            this.toolStripMenuItemTurn2INDLE});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            // 
            // toolStripMenuItemDel
            // 
            resources.ApplyResources(this.toolStripMenuItemDel, "toolStripMenuItemDel");
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // toolStripMenuItemTurn2INDLE
            // 
            resources.ApplyResources(this.toolStripMenuItemTurn2INDLE, "toolStripMenuItemTurn2INDLE");
            this.toolStripMenuItemTurn2INDLE.Name = "toolStripMenuItemTurn2INDLE";
            // 
            // textOTOpath
            // 
            resources.ApplyResources(this.textOTOpath, "textOTOpath");
            this.textOTOpath.BackColor = System.Drawing.Color.Transparent;
            this.textOTOpath.ForeColor = System.Drawing.Color.White;
            this.textOTOpath.Name = "textOTOpath";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::oto2dvcfg.Properties.Resources.buttonCloseNormal;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.textOTOpath);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboLang);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.RedifineBrethEndNote);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RedefineEndNote);
            this.Controls.Add(this.checkHI2RO);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.OpenOTO_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
        private System.Windows.Forms.CheckBox checkHI2RO;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label RedefineEndNote;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label RedifineBrethEndNote;
        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton radioButtonJCVVC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonCCVVC;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTurn2INDLE;
        private NFCButton buttonClose;
        private System.Windows.Forms.Label textOTOpath;
        private System.Windows.Forms.ColumnHeader columnhi2ro;
    }
}

