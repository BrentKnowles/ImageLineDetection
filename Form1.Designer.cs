namespace ImageLineDetection
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
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonTGAVIew = new System.Windows.Forms.Button();
            this.target = new System.Windows.Forms.Panel();
            this.buttonScanImages = new System.Windows.Forms.Button();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.buttonTGAVIew);
            this.flowLayoutPanel4.Controls.Add(this.buttonScanImages);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1484, 107);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // buttonTGAVIew
            // 
            this.buttonTGAVIew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTGAVIew.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTGAVIew.Location = new System.Drawing.Point(3, 3);
            this.buttonTGAVIew.Name = "buttonTGAVIew";
            this.buttonTGAVIew.Size = new System.Drawing.Size(100, 100);
            this.buttonTGAVIew.TabIndex = 0;
            this.buttonTGAVIew.Text = "TGA View";
            this.buttonTGAVIew.UseVisualStyleBackColor = true;
            this.buttonTGAVIew.Click += new System.EventHandler(this.buttonTGAVIew_Click);
            // 
            // target
            // 
            this.target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.target.Location = new System.Drawing.Point(0, 107);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(1484, 680);
            this.target.TabIndex = 6;
            // 
            // buttonScanImages
            // 
            this.buttonScanImages.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonScanImages.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScanImages.Location = new System.Drawing.Point(109, 3);
            this.buttonScanImages.Name = "buttonScanImages";
            this.buttonScanImages.Size = new System.Drawing.Size(100, 100);
            this.buttonScanImages.TabIndex = 1;
            this.buttonScanImages.Text = "Scan Image Files for Lines";
            this.buttonScanImages.UseVisualStyleBackColor = true;
            this.buttonScanImages.Click += new System.EventHandler(this.buttonScanImages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 787);
            this.Controls.Add(this.target);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button buttonTGAVIew;
        private System.Windows.Forms.Panel target;
        private System.Windows.Forms.Button buttonScanImages;
    }
}

