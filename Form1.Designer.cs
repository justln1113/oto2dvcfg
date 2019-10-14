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
            this.columnFAR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnhi2ron = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOriginal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lableOTOLines = new System.Windows.Forms.Label();
            this.labelOTOint = new System.Windows.Forms.Label();
            this.checkHI2RO = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTurn2INDLE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTurn2CV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTurn2VX = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopyAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.textOTOpath = new System.Windows.Forms.Label();
            this.checkFARpreview = new System.Windows.Forms.CheckBox();
            this.checkHI2RON = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFindAndReplace = new oto2dvcfg.NFCButton();
            this.buttonClose = new oto2dvcfg.NFCButton();
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
            this.textPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textPitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textPitch, "textPitch");
            this.textPitch.ForeColor = System.Drawing.Color.White;
            this.textPitch.Name = "textPitch";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.columnhi2ro,
            this.columnFAR,
            this.columnhi2ron,
            this.columnOriginal});
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1_DoubleClick);
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
            // columnFAR
            // 
            resources.ApplyResources(this.columnFAR, "columnFAR");
            // 
            // columnhi2ron
            // 
            resources.ApplyResources(this.columnhi2ron, "columnhi2ron");
            // 
            // columnOriginal
            // 
            resources.ApplyResources(this.columnOriginal, "columnOriginal");
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
            // checkHI2RO
            // 
            resources.ApplyResources(this.checkHI2RO, "checkHI2RO");
            this.checkHI2RO.BackColor = System.Drawing.Color.Transparent;
            this.checkHI2RO.ForeColor = System.Drawing.Color.Black;
            this.checkHI2RO.Name = "checkHI2RO";
            this.checkHI2RO.UseVisualStyleBackColor = false;
            this.checkHI2RO.CheckedChanged += new System.EventHandler(this.CheckHI2RO_CheckedChanged);
            // 
            // comboLang
            // 
            this.comboLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboLang, "comboLang");
            this.comboLang.ForeColor = System.Drawing.Color.White;
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Items.AddRange(new object[] {
            resources.GetString("comboLang.Items"),
            resources.GetString("comboLang.Items1")});
            this.comboLang.Name = "comboLang";
            this.comboLang.SelectedIndexChanged += new System.EventHandler(this.ComboLang_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDel,
            this.toolStripMenuItemTurn2INDLE,
            this.toolStripMenuItemTurn2CV,
            this.toolStripMenuItemTurn2VX,
            this.toolStripSeparator1,
            this.toolStripMenuItemCopyAlias});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            resources.ApplyResources(this.toolStripMenuItemDel, "toolStripMenuItemDel");
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // toolStripMenuItemTurn2INDLE
            // 
            this.toolStripMenuItemTurn2INDLE.Name = "toolStripMenuItemTurn2INDLE";
            resources.ApplyResources(this.toolStripMenuItemTurn2INDLE, "toolStripMenuItemTurn2INDLE");
            this.toolStripMenuItemTurn2INDLE.Click += new System.EventHandler(this.ToolStripMenuItemTurn2INDLE_Click);
            // 
            // toolStripMenuItemTurn2CV
            // 
            this.toolStripMenuItemTurn2CV.Name = "toolStripMenuItemTurn2CV";
            resources.ApplyResources(this.toolStripMenuItemTurn2CV, "toolStripMenuItemTurn2CV");
            this.toolStripMenuItemTurn2CV.Click += new System.EventHandler(this.ToolStripMenuItemTurn2CV_Click);
            // 
            // toolStripMenuItemTurn2VX
            // 
            this.toolStripMenuItemTurn2VX.Name = "toolStripMenuItemTurn2VX";
            resources.ApplyResources(this.toolStripMenuItemTurn2VX, "toolStripMenuItemTurn2VX");
            this.toolStripMenuItemTurn2VX.Click += new System.EventHandler(this.ToolStripMenuItemTurn2VX_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItemCopyAlias
            // 
            this.toolStripMenuItemCopyAlias.Name = "toolStripMenuItemCopyAlias";
            resources.ApplyResources(this.toolStripMenuItemCopyAlias, "toolStripMenuItemCopyAlias");
            this.toolStripMenuItemCopyAlias.Click += new System.EventHandler(this.ToolStripMenuItemCopyAlias_Click);
            // 
            // textOTOpath
            // 
            this.textOTOpath.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.textOTOpath, "textOTOpath");
            this.textOTOpath.ForeColor = System.Drawing.Color.White;
            this.textOTOpath.Name = "textOTOpath";
            // 
            // checkFARpreview
            // 
            resources.ApplyResources(this.checkFARpreview, "checkFARpreview");
            this.checkFARpreview.BackColor = System.Drawing.Color.Transparent;
            this.checkFARpreview.Name = "checkFARpreview";
            this.checkFARpreview.UseVisualStyleBackColor = false;
            this.checkFARpreview.CheckedChanged += new System.EventHandler(this.CheckFARpreview_CheckedChanged);
            // 
            // checkHI2RON
            // 
            resources.ApplyResources(this.checkHI2RON, "checkHI2RON");
            this.checkHI2RON.BackColor = System.Drawing.Color.Transparent;
            this.checkHI2RON.ForeColor = System.Drawing.Color.Black;
            this.checkHI2RON.Name = "checkHI2RON";
            this.checkHI2RON.UseVisualStyleBackColor = false;
            this.checkHI2RON.CheckedChanged += new System.EventHandler(this.CheckHI2ROn_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonFindAndReplace
            // 
            this.buttonFindAndReplace.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.buttonFindAndReplace, "buttonFindAndReplace");
            this.buttonFindAndReplace.ForeColor = System.Drawing.Color.Transparent;
            this.buttonFindAndReplace.Name = "buttonFindAndReplace";
            this.buttonFindAndReplace.UseVisualStyleBackColor = false;
            this.buttonFindAndReplace.Click += new System.EventHandler(this.buttonFindAndReplace_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::oto2dvcfg.Properties.Resources.buttonCloseNormal;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.BackgroundImage = global::oto2dvcfg.Properties.Resources.formBack;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkHI2RON);
            this.Controls.Add(this.checkFARpreview);
            this.Controls.Add(this.buttonFindAndReplace);
            this.Controls.Add(this.textOTOpath);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.comboLang);
            this.Controls.Add(this.checkHI2RO);
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
        private System.Windows.Forms.ColumnHeader columnNo;
        private System.Windows.Forms.CheckBox checkHI2RO;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTurn2INDLE;
        private NFCButton buttonClose;
        private System.Windows.Forms.Label textOTOpath;
        private System.Windows.Forms.ColumnHeader columnhi2ro;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTurn2CV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTurn2VX;
        private NFCButton buttonFindAndReplace;
        private System.Windows.Forms.CheckBox checkFARpreview;
        private System.Windows.Forms.ColumnHeader columnFAR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyAlias;
        private System.Windows.Forms.CheckBox checkHI2RON;
        private System.Windows.Forms.ColumnHeader columnhi2ron;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnOriginal;
    }
}

