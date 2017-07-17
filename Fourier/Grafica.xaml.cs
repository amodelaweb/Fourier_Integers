using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Media3D;
using System.IO;
using Fourier.Logica;

namespace Fourier
{
    /// <summary>
    /// Lógica de interacción para Grafica.xaml
    /// </summary>
    public partial class Grafica : Window
    {
        private Recursos r;

        public Grafica( )
        {
            InitializeComponent();
           
        }

        private Model3DGroup MainModel3Dgroup = new Model3DGroup();
        private PerspectiveCamera TheCamera;

        private double CameraPhi = Math.PI / 6.0;     
        private double CameraTheta = Math.PI / 6.0;    
        private double CameraR = 891;


        private const double CameraDPhi = 0.1;


        private const double CameraDTheta = 0.1;

        private const double CameraDR = 8;

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            System.Console.WriteLine(r.Narmonicos);
            TheCamera = new PerspectiveCamera();
            TheCamera.FieldOfView = 60;
            MainViewport.Camera = TheCamera;
            PositionCamera();

            DefineLights();

            double[,] values = MakeData();

            CreateAltitudeMap(values);

            DefineModel(MainModel3Dgroup, values);

            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModel3Dgroup;


            MainViewport.Children.Add(model_visual);
        }


        private void DefineLights()
        {
            AmbientLight ambient_light = new AmbientLight(Colors.Gray);
            DirectionalLight directional_light =
             new DirectionalLight(Colors.Gray, new Vector3D(-1.0, -3.0, -2.0));
            MainModel3Dgroup.Children.Add(ambient_light);
            MainModel3Dgroup.Children.Add(directional_light);
        }

        private int xmin, xmax, dx, zmin, zmax, dz;
        private double texture_xscale, texture_zscale;


        private double[,] MakeData()
        {
            int n = r.Gt.Count;

            double[,] values = new double[100, n];
            {
            for (int i=0; i<100; i++)
                for (int j = 0; j<n; j++)
                {
                    values[i, j] = (double)(r.Gt[j] * 300);
                }
            }

            xmin = 0;
            xmax = values.GetUpperBound(0);
            dx = 1;
            zmin = 0;
            zmax = values.GetUpperBound(1);
            dz = 1;

            texture_xscale = (xmax - xmin);
            texture_zscale = (zmax - zmin);

            return values;
        }

 
        private void CreateAltitudeMap(double[,] values)
        {
           
            int xwidth = values.GetUpperBound(0) + 1;
            int zwidth = values.GetUpperBound(1) + 1;
            double dx = (xmax - xmin) / xwidth;
            double dz = (zmax - zmin) / zwidth;

            var get_values =
                from double value in values
                select value;
            double ymin = get_values.Min();
            double ymax = get_values.Max();

            BitmapPixelMaker bm_maker = new BitmapPixelMaker(xwidth, zwidth);
            
            for (int ix = 0; ix < xwidth; ix++)
            {
                for (int iz = 0; iz < zwidth; iz++)
                {
                    byte red, green, blue;
                    MapRainbowColor(values[ix, iz], ymin, ymax,
                        out red, out green, out blue);
                    bm_maker.SetPixel(ix, iz, red, green, blue, 255);
                }
            }

            WriteableBitmap wbitmap = bm_maker.MakeBitmap(96, 96);

            wbitmap.Save("Texture.png");
        }

       
        private void MapRainbowColor(double value, double min_value, double max_value,
            out byte red, out byte green, out byte blue)
        {
           
            int int_value = (int)(1023 * (value - min_value) / (max_value - min_value));

            if (int_value < 256)
            {
                red = 255;
                green = (byte)int_value;
                blue = 0;
            }
            else if (int_value < 512)
            {
               
                int_value -= 256;
                red = (byte)(255 - int_value);
                green = 255;
                blue = 0;
            }
            else if (int_value < 768)
            {
                
                int_value -= 512;
                red = 0;
                green = 255;
                blue = (byte)int_value;
            }
            else
            {
               
                int_value -= 768;
                red = 0;
                green = (byte)(255 - int_value);
                blue = 255;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender , e);
        }

        private void DefineModel(Model3DGroup model_group, double[,] values)
        {
           
            MeshGeometry3D mesh = new MeshGeometry3D();
            
            float offset_x = xmax / 2f;
            float offset_z = zmax / 2f;
            for (int x = xmin; x <= xmax - dx; x += dx)
            {
                for (int z = zmin; z <= zmax - dz; z += dx)
                {
                    Point3D p00 = new Point3D(x - offset_x, values[x, z], z - offset_z);
                    Point3D p10 = new Point3D(x - offset_x + dx, values[x + dx, z], z - offset_z);
                    Point3D p01 = new Point3D(x - offset_x, values[x, z + dz], z - offset_z + dz);
                    Point3D p11 = new Point3D(x - offset_x + dx, values[x + dx, z + dz], z - offset_z + dz);

                    AddTriangle(mesh, p00, p01, p11);
                    AddTriangle(mesh, p00, p11, p10);
                }
            }
            Console.WriteLine(mesh.Positions.Count + " points");
            Console.WriteLine(mesh.TriangleIndices.Count / 3 + " triangles");
            Console.WriteLine();

            ImageBrush texture_brush = new ImageBrush();
            texture_brush.ImageSource =
                new BitmapImage(new Uri("carlos.png", UriKind.Relative));
            DiffuseMaterial surface_material = new DiffuseMaterial(texture_brush);

            GeometryModel3D surface_model = new GeometryModel3D(mesh, surface_material);
            
            surface_model.BackMaterial = surface_material;
            
            model_group.Children.Add(surface_model);
        }

        private void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {

            int index1 = AddPoint(mesh.Positions, mesh.TextureCoordinates, point1);
            int index2 = AddPoint(mesh.Positions, mesh.TextureCoordinates, point2);
            int index3 = AddPoint(mesh.Positions, mesh.TextureCoordinates, point3);

            mesh.TriangleIndices.Add(index1);
            mesh.TriangleIndices.Add(index2);
            mesh.TriangleIndices.Add(index3);
        }

        private Dictionary<Point3D, int> PointDictionary =
            new Dictionary<Point3D, int>();

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


        private int AddPoint(Point3DCollection points,
            PointCollection texture_coords, Point3D point)
        {
           

            if (PointDictionary.ContainsKey(point))
                return PointDictionary[point];

           
            points.Add(point);
            PointDictionary.Add(point, points.Count - 1);

            texture_coords.Add(
                new Point(
                    (point.X - xmin) * texture_xscale,
                    (point.Z - zmin) * texture_zscale));

            
            return points.Count - 1;
        }

       
        private void Ventana_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Up:
                    CameraPhi += CameraDPhi;
                    if (CameraPhi > Math.PI / 2.0) CameraPhi = Math.PI / 2.0;
                    break;
                case Key.Down:
                    CameraPhi -= CameraDPhi;
                    if (CameraPhi < -Math.PI / 2.0) CameraPhi = -Math.PI / 2.0;
                    break;
                case Key.Left:
                    CameraTheta += CameraDTheta;
                    break;
                case Key.Right:
                    CameraTheta -= CameraDTheta;
                    break;
                case Key.Add:
                case Key.OemPlus:
                    CameraR -= CameraDR;
                    if (CameraR < CameraDR) CameraR = CameraDR;
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    CameraR += CameraDR;
                    break;
            }

           
            PositionCamera();
        }

      
        private void PositionCamera()
        {
           
            double y = CameraR * Math.Sin(CameraPhi);
            double hyp = CameraR * Math.Cos(CameraPhi);
            double x = hyp * Math.Cos(CameraTheta);
            double z = hyp * Math.Sin(CameraTheta);
            TheCamera.Position = new Point3D(x, y, z);

          
            TheCamera.LookDirection = new Vector3D(-x, -y, -z);

           
            TheCamera.UpDirection = new Vector3D(0, 1, 0);

            
        }
    }
}
    
   
