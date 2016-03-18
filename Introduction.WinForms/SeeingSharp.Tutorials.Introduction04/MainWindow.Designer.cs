namespace SeeingSharp.Tutorials.Introduction04
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.m_ctrlRenderControl = new SeeingSharp.Multimedia.Views.SeeingSharpRendererControl();
            this.m_pickingTimer = new System.Windows.Forms.Timer(this.components);
            this.m_barStatus = new System.Windows.Forms.StatusStrip();
            this.m_lblPickedObjectDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_lblPickedObject = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_barStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctrlRenderControl
            // 
            this.m_ctrlRenderControl.DiscardRendering = true;
            this.m_ctrlRenderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlRenderControl.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlRenderControl.Name = "m_ctrlRenderControl";
            this.m_ctrlRenderControl.Size = new System.Drawing.Size(544, 375);
            this.m_ctrlRenderControl.TabIndex = 0;
            this.m_ctrlRenderControl.ViewConfiguration.AccentuationFactor = 0F;
            this.m_ctrlRenderControl.ViewConfiguration.AlphaEnabledSwapChain = false;
            this.m_ctrlRenderControl.ViewConfiguration.AmbientFactor = 0.2F;
            this.m_ctrlRenderControl.ViewConfiguration.AntialiasingEnabled = true;
            this.m_ctrlRenderControl.ViewConfiguration.AntialiasingQuality = SeeingSharp.Multimedia.Core.AntialiasingQualityLevel.Medium;
            this.m_ctrlRenderControl.ViewConfiguration.GeneratedBorderFactor = 1F;
            this.m_ctrlRenderControl.ViewConfiguration.GeneratedColorGradientFactor = 1F;
            this.m_ctrlRenderControl.ViewConfiguration.LightPower = 0.8F;
            this.m_ctrlRenderControl.ViewConfiguration.ShowTextures = true;
            this.m_ctrlRenderControl.ViewConfiguration.StrongLightFactor = 1.5F;
            this.m_ctrlRenderControl.ViewConfiguration.WireframeEnabled = false;
            this.m_ctrlRenderControl.MouseEnter += new System.EventHandler(this.OnCtrlRenderControl_MouseEnter);
            this.m_ctrlRenderControl.MouseLeave += new System.EventHandler(this.OnCtrlRenderControl_MouseLeave);
            this.m_ctrlRenderControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnCtrlRenderControl_MouseMove);
            // 
            // m_pickingTimer
            // 
            this.m_pickingTimer.Enabled = true;
            this.m_pickingTimer.Tick += new System.EventHandler(this.OnPickingTimer_Tick);
            // 
            // m_barStatus
            // 
            this.m_barStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_barStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lblPickedObjectDesc,
            this.m_lblPickedObject});
            this.m_barStatus.Location = new System.Drawing.Point(0, 375);
            this.m_barStatus.Name = "m_barStatus";
            this.m_barStatus.Size = new System.Drawing.Size(544, 25);
            this.m_barStatus.TabIndex = 1;
            this.m_barStatus.Text = "statusStrip1";
            // 
            // m_lblPickedObjectDesc
            // 
            this.m_lblPickedObjectDesc.Name = "m_lblPickedObjectDesc";
            this.m_lblPickedObjectDesc.Size = new System.Drawing.Size(101, 20);
            this.m_lblPickedObjectDesc.Text = "Picked object:";
            // 
            // m_lblPickedObject
            // 
            this.m_lblPickedObject.Name = "m_lblPickedObject";
            this.m_lblPickedObject.Size = new System.Drawing.Size(73, 20);
            this.m_lblPickedObject.Text = "<Object>";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 400);
            this.Controls.Add(this.m_ctrlRenderControl);
            this.Controls.Add(this.m_barStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Seeing# Tutorials - Introduction 4 (Win.Forms)";
            this.m_barStatus.ResumeLayout(false);
            this.m_barStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SeeingSharp.Multimedia.Views.SeeingSharpRendererControl m_ctrlRenderControl;
        private System.Windows.Forms.Timer m_pickingTimer;
        private System.Windows.Forms.StatusStrip m_barStatus;
        private System.Windows.Forms.ToolStripStatusLabel m_lblPickedObjectDesc;
        private System.Windows.Forms.ToolStripStatusLabel m_lblPickedObject;
    }
}

