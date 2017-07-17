using Xceed.Chart;
using Xceed.Chart.Core;

namespace Fourier
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.m_ChartControl = new Xceed.Chart.ChartControl();
            this.LineStyleCombo = new System.Windows.Forms.ComboBox();
            this.LineDepthScroll = new System.Windows.Forms.HScrollBar();
            this.BorderPropsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_ChartControl
            // 
            this.m_ChartControl.BackColor = System.Drawing.SystemColors.Control;
            this.m_ChartControl.Background = ((Xceed.Chart.Standard.Background)(resources.GetObject("m_ChartControl.Background")));
            this.m_ChartControl.Charts = ((Xceed.Chart.Core.ChartCollection)(resources.GetObject("m_ChartControl.Charts")));
            this.m_ChartControl.InteractivityOperations = ((Xceed.Chart.Core.InteractivityOperationsCollection)(resources.GetObject("m_ChartControl.InteractivityOperations")));
            this.m_ChartControl.Labels = ((Xceed.Chart.Standard.ChartLabelCollection)(resources.GetObject("m_ChartControl.Labels")));
            this.m_ChartControl.Legends = ((Xceed.Chart.Core.LegendCollection)(resources.GetObject("m_ChartControl.Legends")));
            this.m_ChartControl.Location = new System.Drawing.Point(12, 12);
            this.m_ChartControl.Name = "m_ChartControl";
            this.m_ChartControl.Settings = ((Xceed.Chart.Core.Settings)(resources.GetObject("m_ChartControl.Settings")));
            this.m_ChartControl.Size = new System.Drawing.Size(1473, 698);
            this.m_ChartControl.TabIndex = 1;
            this.m_ChartControl.Watermarks = ((Xceed.Chart.Standard.WatermarkCollection)(resources.GetObject("m_ChartControl.Watermarks")));
            this.m_ChartControl.Click += new System.EventHandler(this.m_ChartControl_Click);
            // 
            // LineStyleCombo
            // 
            this.LineStyleCombo.Location = new System.Drawing.Point(134, 718);
            this.LineStyleCombo.Name = "LineStyleCombo";
            this.LineStyleCombo.Size = new System.Drawing.Size(121, 24);
            this.LineStyleCombo.TabIndex = 0;
            this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
            // 
            // LineDepthScroll
            // 
            this.LineDepthScroll.Location = new System.Drawing.Point(411, 716);
            this.LineDepthScroll.Name = "LineDepthScroll";
            this.LineDepthScroll.Size = new System.Drawing.Size(1074, 21);
            this.LineDepthScroll.TabIndex = 0;
            this.LineDepthScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LineDepthScroll_Scroll);
            // 
            // BorderPropsButton
            // 
            this.BorderPropsButton.Location = new System.Drawing.Point(271, 716);
            this.BorderPropsButton.Name = "BorderPropsButton";
            this.BorderPropsButton.Size = new System.Drawing.Size(137, 26);
            this.BorderPropsButton.TabIndex = 0;
            this.BorderPropsButton.Text = "Propiedades";
            this.BorderPropsButton.Click += new System.EventHandler(this.BorderPropsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 722);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Linea : ";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 748);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BorderPropsButton);
            this.Controls.Add(this.LineStyleCombo);
            this.Controls.Add(this.LineDepthScroll);
            this.Controls.Add(this.m_ChartControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Suma de los Armonicos";
            this.Load += new System.EventHandler(this.Form_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Xceed.Chart.Core.Chart m_Chart;
        private LineSeries m_Line;
        private System.Windows.Forms.ComboBox LineStyleCombo;
        private System.Windows.Forms.HScrollBar LineDepthScroll;
        private System.Windows.Forms.Button BorderPropsButton;
        private ChartControl m_ChartControl;
        private System.Windows.Forms.Label label1;
    }
}