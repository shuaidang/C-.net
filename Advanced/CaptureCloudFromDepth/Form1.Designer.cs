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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMap));
            this.btn_depth = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.cMap = new System.Windows.Forms.PictureBox();
            this.btn_livecolor = new System.Windows.Forms.Button();
            this.btn_livedepth = new System.Windows.Forms.Button();
            this.btn_stoplive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_depth
            // 
            this.btn_depth.Location = new System.Drawing.Point(745, 552);
            this.btn_depth.Name = "btn_depth";
            this.btn_depth.Size = new System.Drawing.Size(100, 40);
            this.btn_depth.TabIndex = 3;
            this.btn_depth.Text = "capture and save(depth)";
            this.btn_depth.UseVisualStyleBackColor = true;
            this.btn_depth.Click += new System.EventHandler(this.btn_depth_Click);
            // 
            // btn_color
            // 
            this.btn_color.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_color.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_color.Location = new System.Drawing.Point(639, 552);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(100, 40);
            this.btn_color.TabIndex = 4;
            this.btn_color.Text = "capture and save(color)";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // cMap
            // 
            this.cMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cMap.Image = ((System.Drawing.Image)(resources.GetObject("cMap.Image")));
            this.cMap.Location = new System.Drawing.Point(1, 0);
            this.cMap.Name = "cMap";
            this.cMap.Size = new System.Drawing.Size(877, 546);
            this.cMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cMap.TabIndex = 0;
            this.cMap.TabStop = false;
            // 
            // btn_livecolor
            // 
            this.btn_livecolor.Location = new System.Drawing.Point(12, 552);
            this.btn_livecolor.Name = "btn_livecolor";
            this.btn_livecolor.Size = new System.Drawing.Size(100, 40);
            this.btn_livecolor.TabIndex = 6;
            this.btn_livecolor.Text = "capture live(color)";
            this.btn_livecolor.UseVisualStyleBackColor = true;
            this.btn_livecolor.Click += new System.EventHandler(this.btn_liveimg_Click);
            // 
            // btn_livedepth
            // 
            this.btn_livedepth.Location = new System.Drawing.Point(118, 552);
            this.btn_livedepth.Name = "btn_livedepth";
            this.btn_livedepth.Size = new System.Drawing.Size(100, 40);
            this.btn_livedepth.TabIndex = 7;
            this.btn_livedepth.Text = "capture live(depth)";
            this.btn_livedepth.UseVisualStyleBackColor = true;
            this.btn_livedepth.Click += new System.EventHandler(this.btn_livedepth_Click);
            // 
            // btn_stoplive
            // 
            this.btn_stoplive.Location = new System.Drawing.Point(224, 552);
            this.btn_stoplive.Name = "btn_stoplive";
            this.btn_stoplive.Size = new System.Drawing.Size(100, 40);
            this.btn_stoplive.TabIndex = 8;
            this.btn_stoplive.Text = "stop live";
            this.btn_stoplive.UseVisualStyleBackColor = true;
            this.btn_stoplive.Click += new System.EventHandler(this.btn_stoplive_Click);
            // 
            // ShowMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 601);
            this.Controls.Add(this.btn_stoplive);
            this.Controls.Add(this.btn_livedepth);
            this.Controls.Add(this.btn_livecolor);
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
        private System.Windows.Forms.Button btn_livecolor;
        private System.Windows.Forms.Button btn_livedepth;
        private System.Windows.Forms.Button btn_stoplive;
    }
}