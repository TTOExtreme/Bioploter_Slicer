using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Bioploter_Slicer
{
    class FileInput
    {
        Draw3DSpace ds = new Draw3DSpace();
        //*****************************************************************************************************************************************************
        //load the file mesh

        public void LoadPointsofFile()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            byte[] binaryInt;
            if ((binaryInt = File.ReadAllBytes(Main.PathObj[Convert.ToInt32(Main.PathObj.LongCount() - 1)])) == null)////stl file location
            {
                //textBox1.AppendText(" \n the is failed to accessed");
            }
            
            byte[] arrByte = new byte[4];
            double[] points = new double[12];

            /*
            arrByte[0] = binaryInt[80];
            arrByte[1] = binaryInt[81];
            arrByte[2] = binaryInt[82];
            arrByte[3] = binaryInt[83];

            numVectors = System.BitConverter.ToInt32(arrByte, 0);
            //*/

            Point3D compar = new Point3D();
            Int32Collection indices = new Int32Collection();
            Point3DCollection corners = new Point3DCollection();

            Main.XObj.Add(0);
            Main.YObj.Add(0);
            Main.ZObj.Add(500);

            int vectornumber = 0;

            List<double> xoffset = new List<double>();
            List<double> yoffset = new List<double>();

            double zmin = 40000;
            double zmax = -40000;
            double ymin = 40000;
            double ymax = -40000;
            double xmin = 40000;
            double xmax = -40000;

            for (long i = 84; i < binaryInt.Length; i += 50)
            {
                for (int j = 0; j < 12; j++)
                {
                    arrByte[0] = binaryInt[i + 0 + (j * 4)];
                    arrByte[1] = binaryInt[i + 1 + (j * 4)];
                    arrByte[2] = binaryInt[i + 2 + (j * 4)];
                    arrByte[3] = binaryInt[i + 3 + (j * 4)];
                    points[j] = System.BitConverter.ToSingle(arrByte, 0);
                    //points[j] = (Math.Round(points[j] * 100) / 100);
                }
                /*textBox1.AppendText("N1:" + points[0].ToString() + " N2:" + points[1].ToString() + " N3:" + points[2].ToString() +
                                    " V1x:" + points[3].ToString() + " V1y:" + points[4].ToString() + " V1z:" + points[5].ToString() +
                                    " V2x:" + points[6].ToString() + " V2y:" + points[7].ToString() + " V2z:" + points[8].ToString() +
                                    " V3x:" + points[9].ToString() + " V3y:" + points[10].ToString() + " V3z:" + points[11].ToString() + "\r\n" + "\r\n");*/

                compar = new Point3D(-points[4], points[5], -points[3]);
                corners.Add(compar);
                indices.Add(vectornumber);
                vectornumber++;

                if (points[5] < Main.ZObj.Last()) { Main.ZObj[Convert.ToInt32(Main.ZObj.LongCount() - 1)] = points[5]; }
                xoffset.Add(points[3]);
                yoffset.Add(points[4]);

                if (points[3] < xmin) { xmin = points[3]; }
                if (points[4] < ymin) { ymin = points[4]; }
                if (points[5] < zmin) { zmin = points[5]; }

                if (points[3] > xmax) { xmax = points[3]; }
                if (points[4] > ymax) { ymax = points[4]; }
                if (points[5] > zmax) { zmax = points[5]; }

                compar = new Point3D(-points[7], points[8], -points[6]);
                corners.Add(compar);
                indices.Add(vectornumber);
                vectornumber++;

                if (points[8] < Main.ZObj.Last()) { Main.ZObj[Convert.ToInt32(Main.ZObj.LongCount() - 1)] = points[8]; }
                xoffset.Add(points[6]);
                yoffset.Add(points[7]);

                if (points[6] < xmin) { xmin = points[6]; }
                if (points[7] < ymin) { ymin = points[7]; }
                if (points[8] < zmin) { zmin = points[8]; }

                if (points[6] > xmax) { xmax = points[6]; }
                if (points[7] > ymax) { ymax = points[7]; }
                if (points[8] > zmax) { zmax = points[8]; }

                compar = new Point3D(-points[10], points[11], -points[9]);
                corners.Add(compar);
                indices.Add(vectornumber);
                vectornumber++;

                if (points[11] < Main.ZObj.Last()) { Main.ZObj[Convert.ToInt32(Main.ZObj.LongCount() - 1)] = points[11]; }
                xoffset.Add(points[9]);
                yoffset.Add(points[10]);

                if (points[9] < xmin) { xmin = points[9]; }
                if (points[10] < ymin) { ymin = points[10]; }
                if (points[11] < zmin) { zmin = points[11]; }

                if (points[9] > xmax) { xmax = points[9]; }
                if (points[10] > ymax) { ymax = points[10]; }
                if (points[11] > zmax) { zmax = points[11]; }

                Main.Loadprogress(Convert.ToInt32(100 * i / binaryInt.Length));
                //Main.Loadprogress.Update();
            }

            Main.XObj[Convert.ToInt32(Main.XObj.LongCount() - 1)] = (xoffset.Sum() / xoffset.Count());
            Main.YObj[Convert.ToInt32(Main.YObj.LongCount() - 1)] = (yoffset.Sum() / yoffset.Count());

            Main.XMid.Add((xmax + xmin) / 2);
            Main.YMid.Add((ymax + ymin) / 2);
            Main.ZMid.Add(((zmax + zmin) / 2) - Main.ZObj.Last());

            MeshGeometry3D cube = new MeshGeometry3D();
            cube.Positions = corners;
            cube.TriangleIndices = indices;
            Main.NObj.Add(cube);
            //Main.OffsetObj.Add(new Point3D(0, 0, 0));
            //Draw.Redraw();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //load the .c3d and generates the grid

        public void LoadC3D(string path)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            string[] Cors = {"Red", "Blue", "Lime", "Yellow", "Magenta", "Cyan", "Orange", "Brown" };
            string[] lines;

            int toolNumber=1;

            lines = File.ReadAllLines(path);

            Main.CodeLines = new List<string>();
            foreach (string str in lines)
            {
                Main.CodeLines.Add(str);
            }

            Main.sliceData = new List<List<sliceDataTipe>>();
            Main.sliceData.Add(new List<sliceDataTipe>());

            if (lines != null)
            {
                double x = 0;
                double y = 0;
                double z = 0;

                double x1 = 0;
                double y1 = 0;
                double z1 = 0;

                foreach (string str in lines)
                {
                    if (str.IndexOf("tool") > -1)
                    {
                        toolNumber = Convert.ToInt32(str.Substring(str.IndexOf(" ")));
                    }
                    if (str.IndexOf("G1") > -1)
                    {
                        if (str.IndexOf("X") > -1)
                        {
                            if ((str.Substring(str.IndexOf("X") + 1)).IndexOf(" ") > -1)
                            {
                                string str1 = str.Substring(str.IndexOf("X") + 1, (str.Substring(str.IndexOf("X") + 1)).IndexOf(" "));
                                x1 = Convert.ToDouble(str1);
                            }
                            else
                            {
                                string str1 = str.Substring(str.IndexOf("X") + 1);
                                x1 = Convert.ToDouble(str1);
                            }
                            
                        }

                        if (str.IndexOf("Y") > -1)
                        {

                            if ((str.Substring(str.IndexOf("Y") + 1)).IndexOf(" ") > -1)
                            {
                                string str1 = str.Substring(str.IndexOf("Y") + 1, (str.Substring(str.IndexOf("Y") + 1)).IndexOf(" "));
                                y1 = Convert.ToDouble(str1);
                            }
                            else
                            {
                                string str1 = str.Substring(str.IndexOf("Y") + 1);
                                y1 = Convert.ToDouble(str1);
                            }

                        }

                        if (str.IndexOf("Z") > -1)
                        {
                            if ((str.Substring(str.IndexOf("Z") + 1)).IndexOf(" ") > -1)
                            {
                                string str1 = str.Substring(str.IndexOf("Z") + 1, (str.Substring(str.IndexOf("Z") + 1)).IndexOf(" "));
                                z1 = Convert.ToDouble(str1);
                            }
                            else
                            {
                                string str1 = str.Substring(str.IndexOf("Z") + 1);
                                z1 = Convert.ToDouble(str1);
                            }
                            if (z != z1) { Main.sliceData.Add(new List<sliceDataTipe>()); }
                        }
                        

                        sliceDataTipe sd = new sliceDataTipe();
                        sd.startPoint = new Point3D(x, y, z);
                        sd.endPoint = new Point3D(x1, y1, z1);
                        sd.lineSize = 0.01;
                        sd.Cors = Cors[toolNumber];

                        Main.sliceData[Convert.ToInt32(Main.sliceData.LongCount() - 1)].Add(sd);           

                        x = x1;
                        y = y1;
                        z = z1;

                    }
                }

                foreach(List<sliceDataTipe> Lsld in Main.sliceData)
                {
                    foreach (sliceDataTipe sld in Lsld)
                    {
                        ds.DrawLine(sld.startPoint, sld.endPoint, sld.lineSize, sld.Cors);
                    }
                }
            }
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
