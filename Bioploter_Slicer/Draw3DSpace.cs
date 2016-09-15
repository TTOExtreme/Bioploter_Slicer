using System;
using System.Collections.Generic;
using System.Drawing;
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
    class Draw3DSpace
    {
        Model3DGroup modelGroup = new Model3DGroup();
        PerspectiveCamera Camera1 = new PerspectiveCamera();
        PerspectiveCamera Camera2 = new PerspectiveCamera();

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
                    DrawItRGB(cube, "LightGray",b);
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

        public void DrawItRGB(GeometryModel3D Cube, String Cor,byte b)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            ColorObj(Cube, Cor, b);
            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;
            CameraFocus();
            Main.myViewport.Children.Add(modelsVisual);
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
            Main.myViewport.Children.Add(modelsVisual);
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
            if (Cor == "LightGray" || Cor =="LightRed")
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

            Camera1 = new PerspectiveCamera();
            Camera1.FieldOfView = 60;
            Camera1.Position = new Point3D(((Main.ymm + 50) - (Main.CameraPos * (Main.ymm + 50) / 100)) * Math.Sin(-Main.yang / 360) * Math.Sin(Main.xang / 360), -Main.Zoffset + (((Main.zmm + 50) - (Main.CameraPos * (Main.zmm + 50) / 100)) * Math.Cos(-Main.yang / 360)), ((Main.xmm + 50) - (Main.CameraPos * (Main.xmm + 50) / 100)) * Math.Sin(-Main.yang / 360) * Math.Cos(Main.xang / 360));
            Camera1.LookDirection = new Vector3D((-Main.ymm + 50) * Math.Sin(-Main.yang / 360) * Math.Sin(Main.xang / 360), ((-Main.zmm + 50) * Math.Cos(-Main.yang / 360)), (-Main.xmm + 50) * Math.Sin(-Main.yang / 360) * Math.Cos(Main.xang / 360));
            
            Main.myViewport.Camera = Camera1;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set the canvas settings

        public void CanvasSetings()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            Main.myViewport.Height = Main.ViewAreaY;
            Main.myViewport.Width = Main.ViewAreaX;

            Canvas.SetTop(Main.myViewport, 0);
            Canvas.SetLeft(Main.myViewport, 0);
            Main.uc.Width = Main.myViewport.Width;
            Main.uc.Height = Main.myViewport.Height;
            Main.uc.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Main.uc.VerticalAlignment = VerticalAlignment.Top;
            Thickness margin = Main.uc.Margin;
            margin.Top = 5;
            margin.Left = 5;
            Main.uc.Margin = margin;
            Main.uc.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 30, 30, 30));
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //render the entire thing 
        private void Render()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            CanvasSetings();
            RotationView();
            Main.uc.Canvas1.Children.Add(Main.myViewport);
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set the auto rotation view

        public void RotationView()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            DoubleAnimation RotAngle = new DoubleAnimation();
            AxisAngleRotation3D axis = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            RotateTransform3D Rotate = new RotateTransform3D(axis);
            NameScope.SetNameScope(Main.uc.Canvas1, new NameScope());
            Storyboard RotCube = new Storyboard();

            if (Main.Rotates)
            {
                Camera1.Transform = Rotate;
                RotAngle.From = 0;
                RotAngle.To = 360;
                RotAngle.Duration = new Duration(TimeSpan.FromSeconds(20.0));
                RotAngle.RepeatBehavior = RepeatBehavior.Forever;
                Main.uc.Canvas1.RegisterName("cameraaxis", axis);
                Storyboard.SetTargetName(RotAngle, "cameraaxis");
                Storyboard.SetTargetProperty(RotAngle, new PropertyPath(AxisAngleRotation3D.AngleProperty));
                RotCube = new Storyboard();
                RotCube.Children.Add(RotAngle);
                RotCube.Begin(Main.uc.Canvas1);
            }
            else
            {
                Camera1.Transform = Rotate;
                RotAngle.From = 0;
                RotAngle.To = 360;
                RotAngle.Duration = new Duration(TimeSpan.FromSeconds(0));
                RotAngle.RepeatBehavior = RepeatBehavior.Forever;
                Main.uc.Canvas1.RegisterName("cameraaxis", axis);
                Storyboard.SetTargetName(RotAngle, "cameraaxis");
                Storyboard.SetTargetProperty(RotAngle, new PropertyPath(AxisAngleRotation3D.AngleProperty));
                RotCube = new Storyboard();
                RotCube.Children.Add(RotAngle);
                RotCube.Begin(Main.uc.Canvas1);
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //realocate the object in the build area

        public void Realocate()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            Main.RotObjInt[Main.SelectedObj] = new Transform3DGroup();
            Main.RotObjInt[Main.SelectedObj].Children.Add(new TranslateTransform3D(new Vector3D( Main.OffsetObjInt.Y, Main.OffsetObjInt.X,  Main.OffsetObjInt.Z)));
            /*
            Point3DCollection points = Main.NObj[Main.SelectedObj].Positions;
            for (int j = 0; j < points.Count; j++)
            {
                Point3D point = points[j];
                point.X += Main.OffsetObj[Main.SelectedObj].Y - Main.OffsetObjInt.Y;
                point.Y += Main.OffsetObj[Main.SelectedObj].X - Main.OffsetObjInt.X;
                point.Z += Main.OffsetObj[Main.SelectedObj].Z - Main.OffsetObjInt.Z;
                points[j] = point;
            }
            //*/

            Main.OffsetObj[Main.SelectedObj] = Main.OffsetObjInt;
            Main.RotObjIn = Main.RotObj;
            //Redraw();
            RotateOBJ();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        // function that rotates the object aroun the axis

        private void RotateOBJ()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            double num = 0.000000000000000000000000000000000000;
            
            Quaternion q1 = new Quaternion(new Vector3D(1, 0, 0), Main.RotObj[Main.SelectedObj].Y + num);
            Quaternion q2 = new Quaternion(new Vector3D(0, 1, 0), Main.RotObj[Main.SelectedObj].Z + num);
            Quaternion q3 = new Quaternion(new Vector3D(0, 0, 1), Main.RotObj[Main.SelectedObj].X + num);
            //*/
            /*
            Quaternion q1 = new Quaternion(Math.Sin(Main.RotObj[Main.SelectedObj].Y / 2), 0, 0, Math.Cos(Main.RotObj[Main.SelectedObj].Y/2));
            Quaternion q2 = new Quaternion(0, Math.Sin(Main.RotObj[Main.SelectedObj].Z / 2), 0, Math.Cos(Main.RotObj[Main.SelectedObj].Z/2));
            Quaternion q3 = new Quaternion(0, 0, Math.Sin(Main.RotObj[Main.SelectedObj].X / 2), Math.Cos(Main.RotObj[Main.SelectedObj].X/2));
            //*/
            Quaternion q = new Quaternion();
            q = q3*q1*q2;

            
            AxisAngleRotation3D an = new AxisAngleRotation3D(q.Axis,q.Angle);
            RotateTransform3D Rot = new RotateTransform3D(an);
            /*
            Rot.CenterX = Main.YMid[Main.SelectedObj] + Main.OffsetObj[Main.SelectedObj].Y;
            Rot.CenterY = Main.ZMid[Main.SelectedObj] + Main.OffsetObj[Main.SelectedObj].Z;
            Rot.CenterZ = Main.XMid[Main.SelectedObj] + Main.OffsetObj[Main.SelectedObj].X;
            //*/
            //Main.RotObjInt[Main.SelectedObj] = new Transform3DGroup();
            Main.RotObjInt[Main.SelectedObj].Children.Add(Rot);

        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //put the object in the middle of the area

        public void Middle()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            //for (int i = 0; i < NObj.LongCount(); i++)
            //{
            Point3DCollection points = Main.NObj[Main.SelectedObj].Positions;
            for (int j = 0; j < points.Count; j++)
            {
                Point3D point = points[j];

                point.X += 0 - Main.YMid[Main.SelectedObj];
                point.Y -= Main.ZObj[Main.SelectedObj];
                point.Z += 0 - Main.XMid[Main.SelectedObj];

                points[j] = point;
            }
            //}
            Main.OffsetObj[Main.SelectedObj] = Main.OffsetObjInt;
            //Redraw();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Draw a line

        public void DrawLine(Point3D Startpoint, Point3D Endpoint,double linesize,string Color)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();

            double xin = Startpoint.X;
            double yin = Startpoint.Y;
            double zin = Startpoint.Z;

            double xout = Endpoint.X;
            double yout = Endpoint.Y;
            double zout = Endpoint.Z;
            


            //Int32[] indices = { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3 };
            Int32[] indices = { 0, 1, 2, 3, 2, 1, 0, 1, 4, 5, 4, 1, 2, 3, 6, 7, 6, 3, 0, 2, 4, 6, 4, 2, 1, 3, 5, 7, 5, 3, 4, 5, 6, 7, 6, 5, 4, 5, 7};
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

/*
*
*   Created By Lucas Camarotto
*   In 14/7/2016
*
*/
