namespace IntersectionSimulation4Way
{
    partial class FrmSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSimulation));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucTrafficLight2 = new IntersectionSimulation4Way.UcTrafficLight();
            this.ucTrafficLight1 = new IntersectionSimulation4Way.UcTrafficLight();
            this.ucTrafficLight3 = new IntersectionSimulation4Way.UcTrafficLight();
            this.ucTrafficLight4 = new IntersectionSimulation4Way.UcTrafficLight();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1366, 745);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucTrafficLight2
            // 
            this.ucTrafficLight2.Angle = 180F;
            this.ucTrafficLight2.BackColor = System.Drawing.Color.Transparent;
            this.ucTrafficLight2.Image = ((System.Drawing.Image)(resources.GetObject("ucTrafficLight2.Image")));
            this.ucTrafficLight2.Location = new System.Drawing.Point(386, 139);
            this.ucTrafficLight2.Name = "ucTrafficLight2";
            this.ucTrafficLight2.ShadowDecoration.Parent = this.ucTrafficLight2;
            this.ucTrafficLight2.Size = new System.Drawing.Size(100, 100);
            this.ucTrafficLight2.TabIndex = 2;
            this.ucTrafficLight2.TabStop = false;
            this.ucTrafficLight2.UseTransparentBackground = true;
            // 
            // ucTrafficLight1
            // 
            this.ucTrafficLight1.BackColor = System.Drawing.Color.Transparent;
            this.ucTrafficLight1.Image = ((System.Drawing.Image)(resources.GetObject("ucTrafficLight1.Image")));
            this.ucTrafficLight1.Location = new System.Drawing.Point(885, 508);
            this.ucTrafficLight1.Name = "ucTrafficLight1";
            this.ucTrafficLight1.ShadowDecoration.Parent = this.ucTrafficLight1;
            this.ucTrafficLight1.Size = new System.Drawing.Size(100, 100);
            this.ucTrafficLight1.TabIndex = 1;
            this.ucTrafficLight1.TabStop = false;
            this.ucTrafficLight1.UseTransparentBackground = true;
            // 
            // ucTrafficLight3
            // 
            this.ucTrafficLight3.Angle = 90F;
            this.ucTrafficLight3.BackColor = System.Drawing.Color.Transparent;
            this.ucTrafficLight3.Image = ((System.Drawing.Image)(resources.GetObject("ucTrafficLight3.Image")));
            this.ucTrafficLight3.Location = new System.Drawing.Point(386, 508);
            this.ucTrafficLight3.Mode = IntersectionSimulation4Way.UcTrafficLight.enTrafficLightMode.Green;
            this.ucTrafficLight3.Name = "ucTrafficLight3";
            this.ucTrafficLight3.ShadowDecoration.Parent = this.ucTrafficLight3;
            this.ucTrafficLight3.Size = new System.Drawing.Size(100, 100);
            this.ucTrafficLight3.TabIndex = 3;
            this.ucTrafficLight3.TabStop = false;
            this.ucTrafficLight3.UseTransparentBackground = true;
            // 
            // ucTrafficLight4
            // 
            this.ucTrafficLight4.Angle = 270F;
            this.ucTrafficLight4.BackColor = System.Drawing.Color.Transparent;
            this.ucTrafficLight4.Image = ((System.Drawing.Image)(resources.GetObject("ucTrafficLight4.Image")));
            this.ucTrafficLight4.Location = new System.Drawing.Point(885, 139);
            this.ucTrafficLight4.Mode = IntersectionSimulation4Way.UcTrafficLight.enTrafficLightMode.Green;
            this.ucTrafficLight4.Name = "ucTrafficLight4";
            this.ucTrafficLight4.ShadowDecoration.Parent = this.ucTrafficLight4;
            this.ucTrafficLight4.Size = new System.Drawing.Size(100, 100);
            this.ucTrafficLight4.TabIndex = 4;
            this.ucTrafficLight4.TabStop = false;
            this.ucTrafficLight4.UseTransparentBackground = true;
            // 
            // FrmSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1366, 745);
            this.Controls.Add(this.ucTrafficLight4);
            this.Controls.Add(this.ucTrafficLight3);
            this.Controls.Add(this.ucTrafficLight2);
            this.Controls.Add(this.ucTrafficLight1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4-Way Intersection Simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSimulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTrafficLight4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private UcTrafficLight ucTrafficLight1;
        private UcTrafficLight ucTrafficLight2;
        private UcTrafficLight ucTrafficLight3;
        private UcTrafficLight ucTrafficLight4;
    }
}

