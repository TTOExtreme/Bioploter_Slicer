using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Bioploter_Slicer
{
    class FileOutput
    {
        private List<String> ObjPath = new List<string>(); //list of objects paths
        private List<Point3D> RotObj = new List<Point3D>();
        private List<Point3D> Offset = new List<Point3D>();

        String CurrentDirectory = System.IO.Directory.GetCurrentDirectory(); //get the directory of the program

        //variables default
        String LayerHeight = "0.3";
        String FirstLayerHeight = "0.3";
        String NozzleDiameter = "0.2";
        String Density = "100";
        String Skirts = "0";
        String SkirtDistance = "6";

        //*****************************************************************************************************************************************************
        //set the list of objects paths to get the .gcode
        public void Objects(List<String> _ObjPath)
        {
            ObjPath = _ObjPath;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set the offcet of objects
        public void Offcet(List<Point3D> _Offcet)
        {
            Offset = _Offcet;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //generate the .c3d for printing

        public void Generate(String SavePath)
        {
            getData();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = CurrentDirectory + "/bin/slicer/Slic3r.exe";

            if (!Directory.Exists(CurrentDirectory + "/bin/Temp/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/Temp/"); }
            int i = 0;
            foreach (String strPath in ObjPath)
            {
                try
                {
                    startInfo.Arguments = " -o " + CurrentDirectory + "/bin/Temp/" + i + ".ger " + ArgumentsSlicer(i) + strPath;
                    //startInfo.Arguments = " -o " + SavePath + " " + ArgumentsSlicer() + strPath;
                    var process = (Process.Start(startInfo));
                    process.WaitForExit();
                }catch(Exception e)
                {

                }
                i++;
            }
            c3dGer(SavePath);
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get data and process the .c3d

        private void c3dGer(String Path)
        {
            String[] arm;
            List<List<List<String>>> layersCode = new List<List<List<string>>>();
            for(int i = 0; i < ObjPath.LongCount(); i++)
            {
                layersCode.Add(new List<List<string>>());
                while (!File.Exists(CurrentDirectory + "/bin/Temp/" + i + ".ger")) ;
                arm =File.ReadAllLines(CurrentDirectory + "/bin/Temp/" + i + ".ger");

                layersCode[i].Add(new List<string>());
                for(int j=0; j < arm.LongCount();j++)//line by line
                {
                    if (arm[j].IndexOf("G1") > -1)
                    {
                        //if (arm[j].IndexOf("G1 Z") > -1){ layersCode[i][Convert.ToInt32(layersCode[i].LongCount() - 1)].Add(arm[j]); }
                        while(arm[j].IndexOf("G1 Z") < 0)
                        {
                            if (arm[j].IndexOf("G1") > -1)
                            {
                                layersCode[i][Convert.ToInt32(layersCode[i].LongCount() - 1)].Add(arm[j]);
                            }
                            j++;
                            if (arm[j].IndexOf("EndCode") > -1) { break; }
                        }
                        layersCode[i].Add(new List<string>());
                        if (arm[j].IndexOf("G1 Z") > -1)
                        {
                            layersCode[i][Convert.ToInt32(layersCode[i].LongCount() - 1)].Add("tool: " + i);
                            //insert tool change
                            layersCode[i][Convert.ToInt32(layersCode[i].LongCount() - 1)].Add(arm[j]);
                        }
                            if (arm[j].IndexOf("EndCode") > -1) { break; }
                    }
                    if (arm[j].IndexOf("EndCode") > -1) { break; }
                }
            }
            System.IO.DirectoryInfo di = new DirectoryInfo(CurrentDirectory + "/bin/Temp/");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            Directory.Delete(CurrentDirectory + "/bin/Temp/");

            for (int i=0;i<layersCode.LongCount();i++)
            {
                //if (Offset[i].X != 0)
                //{
                for (int j = 0; j < layersCode[i].LongCount(); j++)
                {
                    for (int k = 0; k < layersCode[i][j].LongCount(); k++)
                    {
                        if (layersCode[i][j][k].IndexOf("G1 Z") > -1)
                        {
                            string sz = layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Z") + 1, (layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Z") + 1)).IndexOf(" "));
                            sz.Replace(".", ",");
                            decimal Z = Convert.ToDecimal(sz);
                            Z += Convert.ToDecimal(Offset[i].X * 1000);
                            Z = Z / 1000;

                            string s1z = layersCode[i][j][k].Substring(0, layersCode[i][j][k].IndexOf("Z") + 1) + String.Format("{0:0.000}", Z);
                            s1z.Replace("\",\"", "\".\"");
                            layersCode[i][j][k] = s1z;
                        }
                        double x1 = 0;
                        double y1 = 0;
                        string str = "";

                        if (layersCode[i][j][k].IndexOf("X") > -1)
                        {
                            if ((layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("X") + 1)).IndexOf(" ") > -1)
                            {
                                string str1 = layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("X") + 1, (layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("X") + 1)).IndexOf(" "));
                                x1 = Convert.ToDouble(str1) / 1000;
                            }
                            else
                            {
                                string str1 = layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("X") + 1);
                                x1 = Convert.ToDouble(str1) / 1000;
                            }

                        }

                        if (layersCode[i][j][k].IndexOf("Y") > -1)
                        {

                            if ((layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Y") + 1)).IndexOf(" ") > -1)
                            {
                                string str1 = layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Y") + 1, (layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Y") + 1)).IndexOf(" "));
                                y1 = Convert.ToDouble(str1) / 1000;
                                str = layersCode[i][j][k].Substring(layersCode[i][j][k].LastIndexOf(" "));
                            }
                            else
                            {
                                string str1 = layersCode[i][j][k].Substring(layersCode[i][j][k].IndexOf("Y") + 1);
                                y1 = Convert.ToDouble(str1) / 1000;
                            }

                        }
                        if (x1 != 0 && y1 != 0)
                        {
                            layersCode[i][j][k] = layersCode[i][j][k].Substring(0, layersCode[i][j][k].IndexOf("X") + 1) + String.Format("{0:0.000}", x1) + " Y" + String.Format("{0:0.000}", y1) + str;
                        }else
                        {
                            if (layersCode[i][j][k].IndexOf("Z") == -1 && layersCode[i][j][k].IndexOf("tool") == -1) { layersCode[i][j].RemoveAt(k); k--; }
                        }
                    }
                }
                //}
            }
            if (layersCode.LongCount() == 1)
            {
                List<String> str4 = new List<string>();
                for (int i = 0; i < layersCode.LongCount(); i++)//for file
                {
                    for (int j = 0; j < layersCode[i].LongCount(); j++)//for layer
                    {
                        for (int k = 0; k < layersCode[i][j].LongCount(); k++)//for lines of layers
                        {
                            str4.Add(layersCode[i][j][k]);
                        }
                        //str4.Add(" ");
                    }
                }
                if (File.Exists(Path)) { File.Delete(Path); }
                File.WriteAllLines(Path, str4);
            }
            else
            {

                List<List<String>> list1 = new List<List<string>>();
                double lastLay = 0;
                double firstLay = 4000;
                double numd = 0;

                for (int i = 0; i < layersCode.LongCount(); i++)//for file
                {
                    for (int j = 0; j < layersCode[i].LongCount(); j++)//for layer
                    {
                        if (layersCode[i][j].LongCount() > 0)
                        {
                            if (layersCode[i][j][0].IndexOf(" ") > -1)
                            {
                                string sub = layersCode[i][j][0].Substring(layersCode[i][j][0].IndexOf(" ") + 1);
                                if (layersCode[i][j][0].LongCount() > 0)
                                {
                                    if (sub.IndexOf(" ") < 0)
                                    {
                                        numd = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1));
                                        if (lastLay < numd)
                                        {
                                            lastLay = numd;
                                        }
                                        if (firstLay > numd)
                                        {
                                            firstLay = numd;
                                        }
                                    }
                                    else
                                    {
                                        numd = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1, layersCode[i][j][1].LastIndexOf(" ") - (layersCode[i][j][1].IndexOf("Z"))));
                                        if (lastLay < numd)
                                        {
                                            lastLay = numd;
                                        }
                                        if (firstLay > numd)
                                        {
                                            firstLay = numd;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                double nextlay = 0;
                double lastLay1 = 0;

                while (nextlay < lastLay)
                {
                    double numd2 = firstLay;
                    double nextlay1 = 40000000;

                    for (int i = 0; i < layersCode.LongCount(); i++)
                    {
                        if (layersCode[i].LongCount() > 1)
                        {
                            for (int j = 0; j < layersCode[i].LongCount(); j++)
                            {
                                if (layersCode[i][j].LongCount() > 0)
                                {
                                    string sub = layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf(" ") + 1);
                                    if (sub.IndexOf(" ") < 0)
                                    {
                                        numd2 = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1)) ;

                                        if (nextlay1 > numd2 && numd2 > lastLay1)
                                        {
                                            nextlay1 = numd2;
                                        }
                                    }
                                    else
                                    {
                                        numd2 = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1, layersCode[i][j][1].LastIndexOf(" ") - (layersCode[i][j][1].IndexOf("Z") + 1)));

                                        if (nextlay1 > numd2 && numd2 > lastLay1)
                                        {
                                            nextlay1 = numd2;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            numd2 = Convert.ToDouble(layersCode[i][1][1].Substring(layersCode[i][1][1].IndexOf("Z") + 1, layersCode[i][1][1].IndexOf(" ") - (layersCode[i][1][1].IndexOf("Z") + 1))) ;
                        }
                    }

                    nextlay = nextlay1;
                    //get the layer



                    for (int i = 0; i < layersCode.LongCount(); i++)
                    {
                        for (int j = 0; j < layersCode[i].LongCount(); j++)
                        {
                            if (layersCode[i][j].LongCount() > 0)
                            {
                                string sub = layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf(" ") + 1);
                                if (sub.IndexOf(" ") < 0)
                                {
                                    double numd1 = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1));

                                    if (numd1 == nextlay)
                                    {
                                        list1.Add(layersCode[i][j]);
                                    }
                                }
                                else
                                {
                                    double numd1 = Convert.ToDouble(layersCode[i][j][1].Substring(layersCode[i][j][1].IndexOf("Z") + 1, layersCode[i][j][1].LastIndexOf(" ") - (layersCode[i][j][1].IndexOf("Z") + 1)));

                                    if (numd1 == nextlay)
                                    {
                                        list1.Add(layersCode[i][j]);
                                    }
                                }
                            }
                        }
                    }
                    lastLay1 = nextlay;
                    Console.WriteLine(" layer high: " + nextlay + "  " + lastLay);
                }
                
                List<String> str4 = new List<string>();
                for (int i = 0; i < list1.LongCount(); i++)//for file
                {
                    for (int j = 0; j < list1[i].LongCount()-1; j++)//for layer
                    {
                         str4.Add(list1[i][j]);
                    }
                    //str4.Add(" ");
                }
                if (File.Exists(Path)) { File.Delete(Path); }
                File.WriteAllLines(Path, str4);

            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the settings for generate the .gcode

        private void getData()
        {

            if(File.Exists(CurrentDirectory + "/bin/config/c3d.cfg"))
            {
                String[] readed = File.ReadAllLines(CurrentDirectory + "/bin/config/c3d.cfg");
                foreach (String str in readed)
                {
                    if (str.IndexOf("=")>0)
                    {
                        if (str.Substring(0, str.IndexOf("=")) == "Layer Height ") { LayerHeight = str.Substring(str.IndexOf("=")+2); }
                        if (str.Substring(0, str.IndexOf("=")) == "First Layer Height ") { FirstLayerHeight = str.Substring(str.IndexOf("=") + 2); }
                        if (str.Substring(0, str.IndexOf("=")) == "Nozzle Diameter ") { NozzleDiameter = str.Substring(str.IndexOf("=") + 2); }
                        if (str.Substring(0, str.IndexOf("=")) == "Density ") { Density = str.Substring(str.IndexOf("=") + 2); }
                        if (str.Substring(0, str.IndexOf("=")) == "Skirts ") { Skirts = str.Substring(str.IndexOf("=") + 2); }
                        if (str.Substring(0, str.IndexOf("=")) == "Skirt Distance ") { SkirtDistance = str.Substring(str.IndexOf("=") + 2); }
                    }
                }
            }else{
                List<String> str = new List<string>();
                str.Add("//----------------------------\\ \r\n"+
                        "|| Created by Lucas Camarotto || \r\n"+
                        "||        In 14/07/2016       || \r\n"+
                        "\\----------------------------// \r\n");
                str.Add("Layer Height = " + LayerHeight);
                str.Add("First Layer Height = " + FirstLayerHeight);
                str.Add("Filament Diameter = " + NozzleDiameter);
                str.Add("Density = " + Density);
                str.Add("Skirts = " + Skirts);
                str.Add("Skirt Distance = " + SkirtDistance);
                if (!Directory.Exists(CurrentDirectory + "/bin/config/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/config/"); }
                File.WriteAllLines(CurrentDirectory + "/bin/config/c3d.cfg", str);
                getData();
            }
        }

        //*****************************************************************************************************************************************************
        
        //*****************************************************************************************************************************************************
        //return the argments to generate the .gcode

        private String ArgumentsSlicer(int i)
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            String str = " ";
            str += "--load " + CurrentDirectory.Replace("\\","/") + "/bin/config/slicer.ini ";
            str += "--print-center " + (Offset[i].Z) + "," + (Offset[i].Y) + " ";
            //str += "--layer-height " + LayerHeight + " ";
            //str += "--first-layer-height " + FirstLayerHeight + " ";
            //str += "--nozzle-diameter 0.5 ";
            //str += "--nozzle-diameter " + NozzleDiameter + " ";
            //int num = Convert.ToInt32(Main.RotObj[i].Z*2);
            //str += "--rotate " + num + " ";
            str += "--start-gcode IniciatesCode ";
            str += "--end-gcode EndCode ";
            str += "--layer-gcode LayerCode ";
            //str += "--fill-density " + Density +"% ";
            str += "--skirts " + Skirts + " ";
            str += "--skirt-distance " + SkirtDistance + " ";

            return str;
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
