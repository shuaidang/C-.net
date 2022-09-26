namespace CaptureCloudFromDepth
{
    partial class ShowMap
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
            this.btn_depth = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.cMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_depth
            // 
            this.btn_depth.Location = new System.Drawing.Point(234, 566);
            this.btn_depth.Name = "btn_depth";
            this.btn_depth.Size = new System.Drawing.Size(130, 40);
            this.btn_depth.TabIndex = 3;
            this.btn_depth.Text = "depth";
            this.btn_depth.UseVisualStyleBackColor = true;
            this.btn_depth.Click += new System.EventHandler(this.btn_depth_Click);
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(587, 566);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(130, 40);
            this.btn_color.TabIndex = 4;
            this.btn_color.Text = "color";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // cMap
            // 
            this.cMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cMap.Image = global::CaptureCloudFromDepth.Resource1.ColorMap;
            this.cMap.Location = new System.Drawing.Point(0, 0);
            this.cMap.Name = "cMap";
            this.cMap.Size = new System.Drawing.Size(1034, 651);
            this.cMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cMap.TabIndex = 0;
            this.cMap.TabStop = false;
            this.cMap.Click += new System.EventHandler(this.cMap_Click);
            // 
            // ShowMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 651);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_depth);
            this.Controls.Add(this.cMap);
            this.Name = "ShowMap";
            this.Text = "ShowMap";
            this.Load += new System.EventHandler(this.ShowMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cMap;
        private System.Windows.Forms.Button btn_depth;
        private System.Windows.Forms.Button btn_color;
    }
}