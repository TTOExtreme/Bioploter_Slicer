using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Forms.Integration;
using System.Windows.Media.Animation;
using System.Windows;

namespace Bioploter_Slicer
{
    class BuildGrid
    {
        private double xmm = 200;//startup
        private double ymm = 200;
        private double zmm = 200;

        private double linesize = 0.1;

        private Draw3DSpace Draw_Space = new Draw3DSpace();
        private Draw2DSpace Draw_Space2 = new Draw2DSpace();

        //*****************************************************************************************************************************************************
        //Load the mesh of the build area

        public void LoadTableMatrix()
        {
            var MainForm = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            
            xmm = MainForm.xmm;
            ymm = MainForm.ymm;
            zmm = MainForm.zmm;
            linesize = MainForm.linesize;
            

            Int32[] indices = { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3 };
            
            //load the perimeter
            MeshGeometry3D tableMatrix = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//0
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//1
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//2
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//3
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) - linesize));//4
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) - linesize));//5
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//6
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//7

            tableMatrix.Positions = corners;
             
            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            GeometryModel3D cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//8
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//9
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));//10
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));//11
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//12
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//13
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//14
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//15

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//16
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) + linesize));//17
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//18
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//19
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//20
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//21
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//22
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//23

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//24
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//25
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//26
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//27
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//28
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//29
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//30
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//31

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");
            Draw_Space2.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//32
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//33
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//34
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//35
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//36
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//37
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//38
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//39

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//40
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//41
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//42
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//43
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//44
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//45
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) - linesize));//46
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) - linesize));//47

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");
            Draw_Space2.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//48
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//49
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//50
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));//51
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//52
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//53
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//54
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//55

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");
            Draw_Space2.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));//56
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));//57
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//58
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) + linesize));//59
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//60
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//61
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//62
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//63

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) + linesize));//64
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) + linesize));//65
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//66
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//67
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) - linesize));//68
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) - linesize));//69
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//70
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//71

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) + linesize));//72
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (-xmm / 2) + linesize));//73
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//74
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//75
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//76
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) + linesize, (xmm / 2) - linesize));//77
            corners.Add(new Point3D((-ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//78
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (xmm / 2) - linesize));//79

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/

            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//80
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));//81
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//82
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) + linesize));//83
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//84
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) - linesize));//85
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//86
            corners.Add(new Point3D((ymm / 2) + linesize, (zmm / 2) + (zmm / 2) - linesize, (-xmm / 2) - linesize));//87

            tableMatrix.Positions = corners;
             
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");

            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            //*/
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));//88
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));//89
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));//90
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));//91
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//92
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize));//93
            corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//94
            corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize));//95

            tableMatrix.Positions = corners;
            // 
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Gray");
            Draw_Space2.DrawItRGB(cube, "Gray");


            //load the table subdivision
            indices = new Int32[] { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3 };
            for (int i = 0; i < xmm / 10; i++)
            {
                tableMatrix = new MeshGeometry3D();
                corners = new Point3DCollection();
                corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize - (i * 10)));
                corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize - (i * 10)));
                corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize - (i * 10)));
                corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize - (i * 10)));
                corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize - (i * 10)));
                corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) - linesize - (i * 10)));
                corners.Add(new Point3D((ymm / 2) - linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize - (i * 10)));
                corners.Add(new Point3D((-ymm / 2) + linesize, (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) - linesize - (i * 10)));
                tableMatrix.Positions = corners;
                Triangles = new Int32Collection();
                foreach (Int32 index in indices) { Triangles.Add(index); }
                tableMatrix.TriangleIndices = Triangles;
                cube = new GeometryModel3D();
                cube.Geometry = tableMatrix;
                Draw_Space.DrawItRGB(cube, "Gray");
                Draw_Space2.DrawItRGB(cube, "Gray");
            }
            //y z x
            for (int i = 0; i < ymm / 10; i++)
            {
                tableMatrix = new MeshGeometry3D();
                corners = new Point3DCollection();
                corners.Add(new Point3D((ymm / 2) + linesize - (i * 10), (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) + linesize - (i * 10), (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) + linesize - (i * 10), (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) + linesize - (i * 10), (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) - linesize - (i * 10), (zmm / 2) + (-zmm / 2) + linesize, (-xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) - linesize - (i * 10), (zmm / 2) + (-zmm / 2) + linesize, (xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) - linesize - (i * 10), (zmm / 2) + (-zmm / 2) - linesize, (xmm / 2) + linesize));
                corners.Add(new Point3D((ymm / 2) - linesize - (i * 10), (zmm / 2) + (-zmm / 2) - linesize, (-xmm / 2) + linesize));
                tableMatrix.Positions = corners;
                Triangles = new Int32Collection();
                foreach (Int32 index in indices) { Triangles.Add(index); }
                tableMatrix.TriangleIndices = Triangles;
                cube = new GeometryModel3D();
                cube.Geometry = tableMatrix;
                Draw_Space.DrawItRGB(cube, "Gray");
                Draw_Space2.DrawItRGB(cube, "Gray");
            }



            //axis colored
            //x
            indices = new int[] { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3, 8, 12, 9, 8, 10, 11 };
            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            corners.Add(new Point3D(((ymm / 2) + linesize * 2), linesize * 2, (xmm / 2)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 2), linesize * 2, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 2), linesize * 2, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 2), linesize * 2, (xmm / 2)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 2), -linesize * 2, (xmm / 2)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 2), -linesize * 2, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 2), -linesize * 2, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 2), -linesize * 2, (xmm / 2)));//7

            corners.Add(new Point3D(((ymm / 2)), 0, (xmm / 4) - (xmm / 16)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 16), -linesize * 16, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 16), +linesize * 16, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 16), -linesize * 16, (xmm / 4)));
            corners.Add(new Point3D(((ymm / 2) - linesize * 16), +linesize * 16, (xmm / 4)));
            tableMatrix.Positions = corners;
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Red");
            //y
            //indices = new int[] { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3, 8, 12, 9, 8, 10, 11 };
            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            corners.Add(new Point3D((ymm / 2), linesize * 2, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 4), linesize * 2, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 4), linesize * 2, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2), linesize * 2, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2), -linesize * 2, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 4), -linesize * 2, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 4), -linesize * 2, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2), -linesize * 2, (xmm / 2) - linesize * 2));

            corners.Add(new Point3D((ymm / 4) - (ymm / 16), 0, (xmm / 2)));
            corners.Add(new Point3D(((ymm / 4)), -linesize * 16, (xmm / 2) + linesize * 16));
            corners.Add(new Point3D(((ymm / 4)), +linesize * 16, (xmm / 2) + linesize * 16));
            corners.Add(new Point3D(((ymm / 4)), -linesize * 16, (xmm / 2) - linesize * 16));
            corners.Add(new Point3D(((ymm / 4)), +linesize * 16, (xmm / 2) - linesize * 16));
            tableMatrix.Positions = corners;
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Lime");
            //z
            //indices = new int[] { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 4, 0, 3, 4, 3, 7, 1, 5, 6, 1, 6, 2, 1, 0, 4, 1, 4, 5, 2, 6, 7, 2, 7, 3, 8, 12, 9, 8, 10, 11 };
            tableMatrix = new MeshGeometry3D();
            corners = new Point3DCollection();
            corners.Add(new Point3D((ymm / 2) + linesize * 2, 0, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 2) + linesize * 2, zmm / 4, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 2) + linesize * 2, zmm / 4, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2) + linesize * 2, 0, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2) - linesize * 2, 0, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 2) - linesize * 2, zmm / 4, (xmm / 2) + linesize * 2));
            corners.Add(new Point3D((ymm / 2) - linesize * 2, zmm / 4, (xmm / 2) - linesize * 2));
            corners.Add(new Point3D((ymm / 2) - linesize * 2, 0, (xmm / 2) - linesize * 2));

            corners.Add(new Point3D((ymm / 2), (zmm / 4) + (zmm / 16), (xmm / 2)));
            corners.Add(new Point3D(((ymm / 2) + linesize * 16), (zmm / 4), (xmm / 2) - linesize * 16));
            corners.Add(new Point3D(((ymm / 2) + linesize * 16), (zmm / 4), (xmm / 2) + linesize * 16));
            corners.Add(new Point3D(((ymm / 2) - linesize * 16), (zmm / 4), (xmm / 2) - linesize * 16));
            corners.Add(new Point3D(((ymm / 2) - linesize * 16), (zmm / 4), (xmm / 2) + linesize * 16));
            tableMatrix.Positions = corners;
            Triangles = new Int32Collection();
            foreach (Int32 index in indices) { Triangles.Add(index); }
            tableMatrix.TriangleIndices = Triangles;
            cube = new GeometryModel3D();
            cube.Geometry = tableMatrix;
            Draw_Space.DrawItRGB(cube, "Blue");
            
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
