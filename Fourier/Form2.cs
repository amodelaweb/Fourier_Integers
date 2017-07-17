using System;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Chart.GraphicsCore;
using Xceed.Chart.Standard;
using Xceed.Chart.Core;
using Xceed.Chart.Server;
using Fourier.Logica;
using System.Collections.Generic;
using System.Reflection;
using Xceed.Utils;



namespace Fourier
{
    public partial class Form2 : Form
    {
        Recursos r;

        internal Recursos R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;
            }
        }

        public Form2()
        {
            Xceed.Chart.Licenser.LicenseKey = "CHT44-KW1D9-3ZDYH-3GPA";


            InitializeComponent();
            LineStyleCombo.Items.Add("Line");
            LineStyleCombo.Items.Add("Tape");
            LineStyleCombo.Items.Add("Tube");
            LineStyleCombo.Items.Add("Ellipsoid");

        }

        private void Form_load(object sender, EventArgs e)
        {
            
            List<Color> allColors = new List<Color>();

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    allColors.Add((Color)property.GetValue(null));
                }
            }

            ChartLabel header = m_ChartControl.Labels.AddHeader("Suma de armonicos");
            header.TextProps.Backplane.Visible = true;
            header.TextProps.FillEffect.Color = Color.Navy;
            header.TextProps.Shadow.Type = ShadowType.Solid;
            header.TextProps.HorzAlign = HorzAlign.Left;
            header.TextProps.VertAlign = VertAlign.Top;
            header.HorizontalMargin = 2;
            header.VerticalMargin = 2;

            m_Chart = m_ChartControl.Charts[0];
            m_Chart.Axis(StandardAxis.Depth).Visible = false;
            
            m_ChartControl.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant2, Color.Ivory, Color.Khaki);

            m_ChartControl.Settings.RenderDevice = RenderDevice.OpenGL;
            m_ChartControl.InteractivityOperations.Add(new TrackballDragOperation());
   

            m_Chart = m_ChartControl.Charts[0];
            m_Chart.Width = 60;
            m_Chart.Height = 25;
            m_Chart.Depth = 45;
            m_Chart.MarginMode = MarginMode.Fit;
            m_Chart.Margins = new RectangleF(15, 15, 70, 70);
            m_Chart.View.Projection = ProjectionType.Perspective;
            m_Chart.View.Elevation = 28;
            m_Chart.View.Rotation = -17;


            m_Line = (LineSeries)m_Chart.Series.Add(SeriesType.Line);
            m_Line.Name = "Suma de armonicos";
            m_Line.DataLabels.Mode = DataLabelsMode.None;
            m_Line.LineStyle = LineSeriesStyle.Tape;
            m_Line.DepthPercent = 8;


            for (int i = 0; i < r.Gt.Count; i++)
            {
                
                    m_Line.Values.Add(r.Gt[i]);
               

            }
            Random rn = new Random();
            int num = rn.Next(0, 140);
            m_Line.LineFillEffect.SetSolidColor(allColors[num]);
            m_Line.LineBorder.Color = allColors[num];
           
        }

        private void LineStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bSimpleLine = (LineStyleCombo.SelectedIndex == 0);

            switch (LineStyleCombo.SelectedIndex)
            {
                case 0: 
                    m_Line.LineStyle = LineSeriesStyle.Line;
                    m_Line.DepthPercent = 0;
                    break;

                case 1: 
                    m_Line.LineStyle = LineSeriesStyle.Tape;
                    m_Line.DepthPercent = 50;
                    break;

                case 2: 
                    m_Line.LineStyle = LineSeriesStyle.Tube;
                    m_Line.DepthPercent = 10;
                    break;

                case 3: 
                    m_Line.LineStyle = LineSeriesStyle.Ellipsoid;
                    m_Line.DepthPercent = 10;
                    break;

            }
            LineDepthScroll.Enabled = !bSimpleLine;


            m_ChartControl.Refresh();
        }

        private void BorderPropsButton_Click(object sender, EventArgs e)
        {

            if (m_Line.LineBorder.ShowEditor())
            {
                m_ChartControl.Refresh();
            }
        }

        private void LineDepthScroll_Scroll(object sender, ScrollEventArgs e)
        {

            m_Line.DepthPercent = LineDepthScroll.Value;
            m_ChartControl.Refresh();
        }

        private void LineFillColorButton_Click(object sender, EventArgs e)
        {

            m_Line.LineFillEffect.ShowEditor();
            m_ChartControl.Refresh();
        }

      
       

       
        private void MarkerBorderButton_Click(object sender, EventArgs e)
        {
            if (m_Line.Markers.Border.ShowEditor())
            {
                m_ChartControl.Refresh();
            }
        }

        private void MarkerFillEffectButton_Click(object sender, EventArgs e)
        {

            if (m_Line.Markers.FillEffect.ShowEditor())
            {
                m_ChartControl.Refresh();
            }
        }

        private void m_ChartControl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowMarkersCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }

}
