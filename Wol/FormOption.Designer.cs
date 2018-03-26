namespace Wol
{
    partial class FormOption
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblDownTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DoDownTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DoDownTime)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Location = new System.Drawing.Point(185, 135);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(74, 28);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Location = new System.Drawing.Point(265, 135);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(74, 28);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblDownTime
            // 
            this.LblDownTime.AutoSize = true;
            this.LblDownTime.Location = new System.Drawing.Point(22, 29);
            this.LblDownTime.Name = "LblDownTime";
            this.LblDownTime.Size = new System.Drawing.Size(178, 12);
            this.LblDownTime.TabIndex = 2;
            this.LblDownTime.Text = "シャットダウンまでの時間 (0～120秒)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "秒";
            // 
            // DoDownTime
            // 
            this.DoDownTime.Location = new System.Drawing.Point(205, 26);
            this.DoDownTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.DoDownTime.Name = "DoDownTime";
            this.DoDownTime.Size = new System.Drawing.Size(84, 19);
            this.DoDownTime.TabIndex = 5;
            this.DoDownTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 175);
            this.Controls.Add(this.DoDownTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblDownTime);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOption";
            ((System.ComponentModel.ISupportInitialize)(this.DoDownTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblDownTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DoDownTime;
    }
}