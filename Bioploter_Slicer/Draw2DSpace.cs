using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Bioploter_Slicer
{
    class Draw2DSpace
    {

        Model3DGroup modelGroup = new Model3DGroup();
        OrthographicCamera Camera1 = new OrthographicCamera();

        //*****************************************************************************************************************************************************
        //redraw everything

        public void Redraw()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            GeometryModel3D cube = new GeometryModel3D();
            byte b;

            for (int i = 0; i < Main.NObj.LongCount(); i++)
            {
                if (i == Main.SelectedObj)
                {
                    /*
                    GeometryModel3D cube = new GeometryModel3D();
                    cube.Geometry = Main.NObj[i];
                    cube.Transform = Main.RotObjInt[i];
                    byte b = Convert.ToByte(((100 - Main.Transparency[i]) * 255) / 100);
                    DrawItRGB(cube, "LightRed",b);
                    //*/
                }
                else
                {
                    cube = new GeometryModel3D();
                    cube.Geometry = Main.NObj[i];
                    cube.Transform = Main.RotObjInt[i];
                    b = Convert.ToByte(((100 - Main.Transparency[i]) * 255) / 100);
                    DrawItRGB(cube, "LightGray", b);
                }
            }
            if (Main.NObj.LongCount() > 0)
            {
                cube = new GeometryModel3D();
                cube.Geometry = Main.NObj[Main.SelectedObj];
                cube.Transform = Main.RotObjInt[Main.SelectedObj];
                b = Convert.ToByte(((100 - Main.Transparency[Main.SelectedObj]) * 255) / 100);
                DrawItRGB(cube, "LightRed", b);
            }
            Render();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Draw the object in the color

        public void DrawItRGB(GeometryModel3D Cube, String Cor, byte b)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            ColorObj(Cube, Cor, b);
            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;
            CameraFocus();
            Main.ViewP2D.Children.Add(modelsVisual);
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Draw the object in the color

        public void DrawItRGB(GeometryModel3D Cube, String Cor)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            ColorObj(Cube, Cor, 255);
            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;
            CameraFocus();
            Main.ViewP2D.Children.Add(modelsVisual);
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set the color of object

        private void ColorObj(GeometryModel3D Cube, String Cor, byte Transparency)
        {
            //"Red", "Blue", "Lime", "Yellow", "Magenta", "Cyan", "Orange", "Brown"
            if (Cor == "Red") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Red); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Red); }
            if (Cor == "Blue") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Blue); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Blue); }
            if (Cor == "Lime") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Lime); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Lime); }
            if (Cor == "Yellow") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Yellow); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Yellow); }
            if (Cor == "Magenta") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Magenta); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Magenta); }
            if (Cor == "Cyan") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Cyan); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Cyan); }
            if (Cor == "Orange") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Orange); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Orange); }
            if (Cor == "Brown") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Brown); Cube.BackMaterial = new DiffuseMaterial(System.Windows.Media.Brushes.Brown); }

            if (Cor == "Gray") { Cube.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Gray); }

            modelGroup = new Model3DGroup();
            if (Cor == "LightGray" || Cor == "LightRed")
            {
                GeometryModel3D Cube2 = new GeometryModel3D();
                Cube2.Geometry = Cube.Geometry;
                Cube2.Transform = Cube.Transform;
                //if (Cor == "LightRed") { Cube2.Material = new DiffuseMaterial(System.Windows.Media.Brushes.DarkRed); }
                //if (Cor == "LightGray") { Cube2.Material = new DiffuseMaterial(System.Windows.Media.Brushes.DarkSlateGray); }

                if (Cor == "LightRed")
                {
                    Cube2.Material = new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(Transparency, 128, 0, 0)));
                    Cube2.BackMaterial = Cube2.Material;
                }
                if (Cor == "LightGray")
                {
                    Cube2.Material = new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(Transparency, 47, 79, 79)));
                    Cube2.BackMaterial = Cube2.Material;
                }
                modelGroup.Children.Add(Cube2);

                SpecularMaterial mat = new SpecularMaterial();

                //if (Cor == "LightRed") { mat.Brush = System.Windows.Media.Brushes.LightSalmon; }
                //if (Cor == "LightGray") { mat.Brush = System.Windows.Media.Brushes.LightSlateGray; }

                if (Cor == "LightRed") { mat.Brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Transparency, 200, 0, 0)); }
                if (Cor == "LightGray") { mat.Brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Transparency, 160, 160, 160)); }

                mat.SpecularPower = 15;
                Cube.Material = mat;
                Cube.BackMaterial = Cube.Material;

                modelGroup.Children.Add(Cube);

                DirectionalLight DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(-1, -1, -1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(1, -1, -1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(-1, -1, 1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(1, -1, 1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(-1, 1, -1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(1, 1, -1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(-1, 1, 1);
                modelGroup.Children.Add(DirLight1);

                DirLight1 = new DirectionalLight();
                DirLight1.Color = Colors.Gray;
                DirLight1.Direction = new Vector3D(1, 1, 1);
                modelGroup.Children.Add(DirLight1);

                //*/
            }
            else
            {
                modelGroup.Children.Add(Cube);
                AmbientLight DirLight1 = new AmbientLight();
                DirLight1.Color = Colors.White;

                modelGroup.Children.Add(DirLight1);
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //change the camera location and the zoom

        public void CameraFocus()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            //x =x  y=z z=y

            Camera1 = new OrthographicCamera();
            Camera1.Width = Main.CameraPos2;
            Camera1.Position = new Point3D(1 + Main.yoff2/2, Main.zmm, 0 - Main.xoff2/2);
            Camera1.LookDirection = new Vector3D(-1, -Main.zmm, 0);

            Main.ViewP2D.Camera = Camera1;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set the canvas settings

        public void CanvasSetings()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            Main.ViewP2D.Height = Main.ViewArea2DY;
            Main.ViewP2D.Width = Main.ViewArea2DX;

            Canvas.SetTop(Main.myViewport, 0);
            Canvas.SetLeft(Main.myViewport, 0);
            Main.uc2.Width = Main.myViewport.Width;
            Main.uc2.Height = Main.myViewport.Height;
            Main.uc2.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Main.uc2.VerticalAlignment = VerticalAlignment.Top;
            Thickness margin = Main.uc.Margin;
            margin.Top = 5;
            margin.Left = 5;
            Main.uc2.Margin = margin;
            Main.uc2.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 30, 30, 30));
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //render the entire thing 
        private void Render()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            CanvasSetings();
            Main.uc2.Canvas1.Children.Add(Main.ViewP2D);
        }

        //*****************************************************************************************************************************************************
        
        //*****************************************************************************************************************************************************
        //Draw a line

        public void DrawLine(Point3D Startpoint, Point3D Endpoint, double linesize, string Color)
        {
           // var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            double xin = Startpoint.X;
            double yin = Startpoint.Y;
            double zin = Startpoint.Z;

            double xout = Endpoint.X;
            double yout = Endpoint.Y;
            double zout = Endpoint.Z;

            linesize += linesize;

            //Int32[] indices = { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3 };
            Int32[] indices = { 0, 1, 2, 3, 2, 1, 0, 1, 4, 5, 4, 1, 2, 3, 6, 7, 6, 3, 0, 2, 4, 6, 4, 2, 1, 3, 5, 7, 5, 3, 4, 5, 6, 7, 6, 5, 4, 5, 7 };
            //set the points of line
            MeshGeometry3D tableMatrix = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();
            corners.Add(new Point3D(yin + linesize / 2, zin + linesize, xin + linesize / 2));//0
            corners.Add(new Point3D(yin + linesize / 2, zin - linesize, xin + linesize / 2));//1
            corners.Add(new Point3D(yin - linesize, zin, xin));//2
            corners.Add(new Point3D(yin, zin, xin - linesize));//3
            corners.Add(new Point3D(yout + linesize / 2, zout + linesize, xout + linesize / 2));//4
            corners.Add(new Point3D(yout + linesize / 2, zout - linesize, xout + linesize / 2));//5
            corners.Add(new Point3D(yout - linesize, zout, xout));//6
            corners.Add(new Point3D(yout, zout, xout - linesize));//7

            tableMatrix.Positions = corners;

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            GeometryModel3D cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            DrawItRGB(cube, Color);
        }

        //*****************************************************************************************************************************************************

    }
}
