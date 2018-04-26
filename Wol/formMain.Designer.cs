namespace Wol
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnWake = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolEdit = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolOption = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolVersion = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnWake
            // 
            this.BtnWake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnWake.Location = new System.Drawing.Point(13, 39);
            this.BtnWake.Name = "BtnWake";
            this.BtnWake.Size = new System.Drawing.Size(155, 110);
            this.BtnWake.TabIndex = 0;
            this.BtnWake.Text = "起動";
            this.BtnWake.UseVisualStyleBackColor = true;
            this.BtnWake.Click += new System.EventHandler(this.BtnWake_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDown.Location = new System.Drawing.Point(174, 39);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(148, 110);
            this.BtnDown.TabIndex = 1;
            this.BtnDown.Text = "シャットダウン";
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolEdit,
            this.toolStripSeparator2,
            this.ToolOption,
            this.toolStripSeparator1,
            this.ToolVersion});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(334, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolEdit
            // 
            this.ToolEdit.Name = "ToolEdit";
            this.ToolEdit.Size = new System.Drawing.Size(31, 22);
            this.ToolEdit.Text = "編集";
            this.ToolEdit.Click += new System.EventHandler(this.ToolEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolOption
            // 
            this.ToolOption.Name = "ToolOption";
            this.ToolOption.Size = new System.Drawing.Size(51, 22);
            this.ToolOption.Text = "オプション";
            this.ToolOption.Click += new System.EventHandler(this.ToolOption_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolVersion
            // 
            this.ToolVersion.Name = "ToolVersion";
            this.ToolVersion.Size = new System.Drawing.Size(51, 22);
            this.ToolVersion.Text = "バージョン";
            this.ToolVersion.Click += new System.EventHandler(this.ToolVersion_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnWake);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnWake;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel ToolEdit;
        private System.Windows.Forms.ToolStripLabel ToolOption;
        private System.Windows.Forms.ToolStripLabel ToolVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

