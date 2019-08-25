namespace oto2dvcfg
{
    partial class FormRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRule));
            this.textName = new System.Windows.Forms.TextBox();
            this.Pitch = new System.Windows.Forms.Label();
            this.textFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textReplace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nfcButton1 = new oto2dvcfg.NFCButton();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.textName.ForeColor = System.Drawing.Color.Black;
            this.textName.Location = new System.Drawing.Point(86, 23);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(157, 22);
            this.textName.TabIndex = 8;
            // 
            // Pitch
            // 
            this.Pitch.AutoSize = true;
            this.Pitch.BackColor = System.Drawing.Color.Transparent;
            this.Pitch.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.Pitch.ForeColor = System.Drawing.Color.Black;
            this.Pitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pitch.Location = new System.Drawing.Point(12, 25);
            this.Pitch.Name = "Pitch";
            this.Pitch.Size = new System.Drawing.Size(52, 20);
            this.Pitch.TabIndex = 7;
            this.Pitch.Text = "Name";
            // 
            // textFind
            // 
            this.textFind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textFind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textFind.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.textFind.ForeColor = System.Drawing.Color.Black;
            this.textFind.Location = new System.Drawing.Point(86, 51);
            this.textFind.Name = "textFind";
            this.textFind.Size = new System.Drawing.Size(157, 22);
            this.textFind.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Find";
            // 
            // textReplace
            // 
            this.textReplace.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textReplace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textReplace.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.textReplace.ForeColor = System.Drawing.Color.Black;
            this.textReplace.Location = new System.Drawing.Point(86, 79);
            this.textReplace.Name = "textReplace";
            this.textReplace.Size = new System.Drawing.Size(157, 22);
            this.textReplace.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Replace";
            // 
            // nfcButton1
            // 
            this.nfcButton1.Location = new System.Drawing.Point(16, 110);
            this.nfcButton1.Name = "nfcButton1";
            this.nfcButton1.Size = new System.Drawing.Size(227, 30);
            this.nfcButton1.TabIndex = 13;
            this.nfcButton1.Text = "Add";
            this.nfcButton1.UseVisualStyleBackColor = true;
            this.nfcButton1.Click += new System.EventHandler(this.NfcButton1_Click);
            // 
            // FormRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(261, 152);
            this.Controls.Add(this.nfcButton1);
            this.Controls.Add(this.textReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.Pitch);
            this.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add rule...";
            this.Load += new System.EventHandler(this.FormRule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label Pitch;
        private System.Windows.Forms.TextBox textFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textReplace;
        private System.Windows.Forms.Label label2;
        private NFCButton nfcButton1;
    }
}