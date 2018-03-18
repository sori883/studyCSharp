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
            this.btnWake = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWake
            // 
            this.btnWake.Location = new System.Drawing.Point(13, 39);
            this.btnWake.Name = "btnWake";
            this.btnWake.Size = new System.Drawing.Size(155, 110);
            this.btnWake.TabIndex = 0;
            this.btnWake.Text = "起動";
            this.btnWake.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(174, 39);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(148, 110);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "シャットダウン";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnWake);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWake;
        private System.Windows.Forms.Button btnDown;
    }
}

