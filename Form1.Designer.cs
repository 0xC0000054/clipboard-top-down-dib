namespace ClipboardTopDownDib
{
    partial class Form1
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
            this.copyImageToClipboardButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // copyImageToClipboardButton
            // 
            this.copyImageToClipboardButton.Location = new System.Drawing.Point(380, 415);
            this.copyImageToClipboardButton.Name = "copyImageToClipboardButton";
            this.copyImageToClipboardButton.Size = new System.Drawing.Size(141, 23);
            this.copyImageToClipboardButton.TabIndex = 0;
            this.copyImageToClipboardButton.Text = "Copy image to Clipboard";
            this.copyImageToClipboardButton.UseVisualStyleBackColor = true;
            this.copyImageToClipboardButton.Click += new System.EventHandler(this.CopyImageToClipboardButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(508, 376);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.copyImageToClipboardButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button copyImageToClipboardButton;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}