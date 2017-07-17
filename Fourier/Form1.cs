using System;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Chart.GraphicsCore;
using Xceed.Chart.Standard;
using Xceed.Chart.Core;
using Fourier.Logica;
using System.Collections.Generic;
using System.Reflection;
using Xceed.Chart.Server;

namespace Fourier
{


    public partial class Form1 : Form
    {
        private Recursos rec;
        private LineSeries m_Line1;
       

        internal Recursos Rec
        {
            get
            {
                return rec;
            }

            set
            {
                rec = value;
            }
        }

        public Form1()
        {
            Xceed.Chart.Licenser.LicenseKey = "CHT44-KW1D9-3ZDYH-3GPA";
            InitializeComponent();
        }

      
        private void MultiSeriesLineUC_Load(object sender, System.EventArgs e)
        {
            m_ChartControl.Settings.RenderDevice = RenderDevice.OpenGL;
            m_ChartControl.InteractivityOperations.Add(new TrackballDragOperation());
            m_ChartControl.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant2, Color.Ivory, Color.Khaki);

            ChartLabel header = m_ChartControl.Labels.AddHeader("Grafico de cada Armonico");
            header.TextProps.Backplane.Visible = false;
            header.TextProps.FillEffect.Color = Color.Navy;
            header.TextProps.Shadow.Type = ShadowType.Solid;
            header.TextProps.HorzAlign = HorzAlign.Left;
            header.TextProps.VertAlign = VertAlign.Top;
            header.HorizontalMargin = 2;
            header.VerticalMargin = 2;

            m_Chart = m_ChartControl.Charts[0];
            m_Chart.Width = 60;
            m_Chart.Height = 25;
            m_Chart.Depth = 45;
            m_Chart.MarginMode = MarginMode.Fit;
            m_Chart.Margins = new RectangleF(15, 15, 70, 70);
            m_Chart.View.Projection = ProjectionType.Perspective;
            m_Chart.View.Elevation = 28;
            m_Chart.View.Rotation = -17;
            Color c = new Color();
            c = Color.AliceBlue;
            List<Color> allColors = new List<Color>();

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    allColors.Add((Color)property.GetValue(null));
                }
            }
           
            int w = 0;
            for (int i=0; i <rec.Armonicos.Count ; i++)
            {
                if(w >= 141)
                {
                    w = 0;
                }
                
                m_Line1 = (LineSeries)m_Chart.Series.Add(SeriesType.Line);
                m_Line1.MultiLineMode = MultiLineMode.Series;
                m_Line1.LineStyle = LineSeriesStyle.Tape;
                m_Line1.DataLabels.Mode = DataLabelsMode.None;
                m_Line1.DepthPercent = 50;
                m_Line1.Name = "Armonico  " + (i+1);
                for (int j=0; j<rec.Armonicos[i].Gt.Count;j++)
                {
                    m_Line1.Values.Add(rec.Armonicos[i].Gt[j]);
                }
               
                m_Line1.LineFillEffect.SetSolidColor(allColors[w]);
                m_Line1.LineBorder.Color = allColors[w];
                w++;
                                    
            }
      
        }
        private void ChartDepthScroll_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            m_Chart.Depth = (float)ChartDepthScroll.Value;
            m_ChartControl.Refresh();
        }

       
       

        private void Charge(object sender, EventArgs e)
        {
            MultiSeriesLineUC_Load(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
