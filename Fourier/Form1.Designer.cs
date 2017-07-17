using Xceed.Chart;

namespace Fourier
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.m_ChartControl = new Xceed.Chart.ChartControl();
            this.ChartDepthScroll = new System.Windows.Forms.HScrollBar();
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
            this.m_ChartControl.Location = new System.Drawing.Point(9, 12);
            this.m_ChartControl.Name = "m_ChartControl";
            this.m_ChartControl.Settings = ((Xceed.Chart.Core.Settings)(resources.GetObject("m_ChartControl.Settings")));
            this.m_ChartControl.Size = new System.Drawing.Size(1377, 729);
            this.m_ChartControl.TabIndex = 0;
            this.m_ChartControl.Watermarks = ((Xceed.Chart.Standard.WatermarkCollection)(resources.GetObject("m_ChartControl.Watermarks")));
            // 
            // ChartDepthScroll
            // 
            this.ChartDepthScroll.Location = new System.Drawing.Point(9, 753);
            this.ChartDepthScroll.Name = "ChartDepthScroll";
            this.ChartDepthScroll.Size = new System.Drawing.Size(1377, 24);
            this.ChartDepthScroll.TabIndex = 0;
            this.ChartDepthScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ChartDepthScroll_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 777);
            this.Controls.Add(this.m_ChartControl);
            this.Controls.Add(this.ChartDepthScroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Grafica de cada Armonico";
            this.Load += new System.EventHandler(this.Charge);
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.HScrollBar ChartDepthScroll;
        private ChartControl m_ChartControl;
        private Xceed.Chart.Core.Chart m_Chart;

    }
}

