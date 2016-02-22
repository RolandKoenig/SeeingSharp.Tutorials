namespace SeeingSharp.Tutorials.Introduction01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.m_ctrlRenderControl = new SeeingSharp.Multimedia.Views.SeeingSharpRendererControl();
            this.SuspendLayout();
            // 
            // m_ctrlRenderControl
            // 
            this.m_ctrlRenderControl.DiscardRendering = true;
            this.m_ctrlRenderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlRenderControl.InputMode = SeeingSharp.Multimedia.Input.SeeingSharpInputMode.FreeCameraMovement;
            this.m_ctrlRenderControl.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlRenderControl.Name = "m_ctrlRenderControl";
            this.m_ctrlRenderControl.Size = new System.Drawing.Size(544, 400);
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
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 400);
            this.Controls.Add(this.m_ctrlRenderControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Seeing# Tutorials - Introduction 1 (Win.Forms)";
            this.ResumeLayout(false);

        }

        #endregion

        private SeeingSharp.Multimedia.Views.SeeingSharpRendererControl m_ctrlRenderControl;
    }
}

