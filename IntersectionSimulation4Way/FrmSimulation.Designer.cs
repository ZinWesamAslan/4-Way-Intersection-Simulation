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
            this.picFourWayIntersectionSimulation = new System.Windows.Forms.PictureBox();
            this.UcTrafficLightRight = new IntersectionSimulation4Way.UcTrafficLight();
            this.UcTrafficLightLift = new IntersectionSimulation4Way.UcTrafficLight();
            this.UcTrafficLightUp = new IntersectionSimulation4Way.UcTrafficLight();
            this.UcTrafficLightDown = new IntersectionSimulation4Way.UcTrafficLight();
            ((System.ComponentModel.ISupportInitialize)(this.picFourWayIntersectionSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightLift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightDown)).BeginInit();
            this.SuspendLayout();
            // 
            // picFourWayIntersectionSimulation
            // 
            this.picFourWayIntersectionSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFourWayIntersectionSimulation.Image = ((System.Drawing.Image)(resources.GetObject("picFourWayIntersectionSimulation.Image")));
            this.picFourWayIntersectionSimulation.Location = new System.Drawing.Point(0, 0);
            this.picFourWayIntersectionSimulation.Name = "picFourWayIntersectionSimulation";
            this.picFourWayIntersectionSimulation.Size = new System.Drawing.Size(1366, 745);
            this.picFourWayIntersectionSimulation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFourWayIntersectionSimulation.TabIndex = 0;
            this.picFourWayIntersectionSimulation.TabStop = false;
            // 
            // UcTrafficLightRight
            // 
            this.UcTrafficLightRight.Angle = 270F;
            this.UcTrafficLightRight.BackColor = System.Drawing.Color.Transparent;
            this.UcTrafficLightRight.Image = ((System.Drawing.Image)(resources.GetObject("UcTrafficLightRight.Image")));
            this.UcTrafficLightRight.Location = new System.Drawing.Point(885, 139);
            this.UcTrafficLightRight.Name = "UcTrafficLightRight";
            this.UcTrafficLightRight.ShadowDecoration.Parent = this.UcTrafficLightRight;
            this.UcTrafficLightRight.Size = new System.Drawing.Size(100, 100);
            this.UcTrafficLightRight.TabIndex = 4;
            this.UcTrafficLightRight.TabStop = false;
            this.UcTrafficLightRight.UseTransparentBackground = true;
            // 
            // UcTrafficLightLift
            // 
            this.UcTrafficLightLift.Angle = 90F;
            this.UcTrafficLightLift.BackColor = System.Drawing.Color.Transparent;
            this.UcTrafficLightLift.Image = ((System.Drawing.Image)(resources.GetObject("UcTrafficLightLift.Image")));
            this.UcTrafficLightLift.Location = new System.Drawing.Point(386, 508);
            this.UcTrafficLightLift.Name = "UcTrafficLightLift";
            this.UcTrafficLightLift.ShadowDecoration.Parent = this.UcTrafficLightLift;
            this.UcTrafficLightLift.Size = new System.Drawing.Size(100, 100);
            this.UcTrafficLightLift.TabIndex = 3;
            this.UcTrafficLightLift.TabStop = false;
            this.UcTrafficLightLift.UseTransparentBackground = true;
            // 
            // UcTrafficLightUp
            // 
            this.UcTrafficLightUp.Angle = 180F;
            this.UcTrafficLightUp.BackColor = System.Drawing.Color.Transparent;
            this.UcTrafficLightUp.Image = ((System.Drawing.Image)(resources.GetObject("UcTrafficLightUp.Image")));
            this.UcTrafficLightUp.Location = new System.Drawing.Point(386, 139);
            this.UcTrafficLightUp.Mode = IntersectionSimulation4Way.UcTrafficLight.enTrafficLightMode.GreenUL;
            this.UcTrafficLightUp.Name = "UcTrafficLightUp";
            this.UcTrafficLightUp.ShadowDecoration.Parent = this.UcTrafficLightUp;
            this.UcTrafficLightUp.Size = new System.Drawing.Size(100, 100);
            this.UcTrafficLightUp.TabIndex = 2;
            this.UcTrafficLightUp.TabStop = false;
            this.UcTrafficLightUp.UseTransparentBackground = true;
            // 
            // UcTrafficLightDown
            // 
            this.UcTrafficLightDown.BackColor = System.Drawing.Color.Transparent;
            this.UcTrafficLightDown.Image = ((System.Drawing.Image)(resources.GetObject("UcTrafficLightDown.Image")));
            this.UcTrafficLightDown.Location = new System.Drawing.Point(885, 508);
            this.UcTrafficLightDown.Mode = IntersectionSimulation4Way.UcTrafficLight.enTrafficLightMode.GreenUL;
            this.UcTrafficLightDown.Name = "UcTrafficLightDown";
            this.UcTrafficLightDown.ShadowDecoration.Parent = this.UcTrafficLightDown;
            this.UcTrafficLightDown.Size = new System.Drawing.Size(100, 100);
            this.UcTrafficLightDown.TabIndex = 1;
            this.UcTrafficLightDown.TabStop = false;
            this.UcTrafficLightDown.UseTransparentBackground = true;
            // 
            // FrmSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1366, 745);
            this.Controls.Add(this.UcTrafficLightRight);
            this.Controls.Add(this.UcTrafficLightLift);
            this.Controls.Add(this.UcTrafficLightUp);
            this.Controls.Add(this.UcTrafficLightDown);
            this.Controls.Add(this.picFourWayIntersectionSimulation);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4-Way Intersection Simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSimulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFourWayIntersectionSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightLift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UcTrafficLightDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picFourWayIntersectionSimulation;
        private UcTrafficLight UcTrafficLightDown;
        private UcTrafficLight UcTrafficLightUp;
        private UcTrafficLight UcTrafficLightLift;
        private UcTrafficLight UcTrafficLightRight;
    }
}

