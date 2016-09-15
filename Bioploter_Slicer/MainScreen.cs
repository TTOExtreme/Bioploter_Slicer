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
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Input;


namespace Bioploter_Slicer
{
    public partial class MainScreen : Form
    {

        public List<String> PathObj = new List<string>(); //local of .stl

        public int SelectedObj=0;

        public List<string> CodeLines = new List<string>();

        String CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

        //setup of printer the default dimensions
        public double xmm = 200;
        public double ymm = 200;
        public double zmm = 200;

        //values of build rendering
        public double linesize = 0.05;//line size of the build area
        public int CameraPosCorect = 3;//correção da posição da camera
        public int CameraPos = 50;//start position of camera
        public int CameraPos2 = -50;//start position of camera
        public int Zoffset = -50;//start offset in z of camera

        //var to rendering area
        public int ViewAreaX = 800;//size x of view area
        public int ViewAreaY = 600;//size y of view area
        public int ViewArea2DX = 470;//size x of view area
        public int ViewArea2DY = 480;//size y of view area

        public double xang = 283;//applied to angular x of object
        public double yang = 209;//applied to angular y of object

        public double xoff2 = 0;//applied to angular x of object
        public double yoff2 = 0;//applied to angular y of object

        public double mousex = 0;//mouse x variation for rotation of camera
        public double mousey = 0;//mouse y variation for rotation of camera
        public double mousez = 0;//mouse z variation for rotation of camera
        public double mousew = 0;//mouse wheel variation for zoom of camera

        public double mousex2 = 0;//mouse x variation for rotation of camera
        public double mousey2 = 0;//mouse y variation for rotation of camera
        public double mousew2 = -50;//mouse wheel variation for zoom of camera

        public bool Rotates = false;//rotation automatic of view

        public bool mouseFinder = false;//for follow the mouse for rotation
        public bool mouseFinder2 = false;//for follow the mouse for rotation
        public bool mouseFinderz = false;//for follow the mouse for offset

        //presets of vars to manang the objects
        public Viewport3D myViewport = new Viewport3D();//inicializate the view port
        public Viewport3D ViewP2D = new Viewport3D();
        public List<MeshGeometry3D> NObj = new List<MeshGeometry3D>();//the objects in mesh geometry
        public List<Point3D> OffsetObj = new List<Point3D>();//offset added in object
        public List<Point3D> RotObj = new List<Point3D>();//rotation of object
        public List<Point3D> RotObjIn = new List<Point3D>();//rotation of object
        public Point3D OffsetObjInt = new Point3D();//insert new offset in object

        public List<int> Transparency = new List<int>();

        public List<int> toolSelected = new List<int>();
        public String[] Tools;

        //class initializate
        Draw3DSpace Draw = new Draw3DSpace();
        Draw2DSpace Draw2D = new Draw2DSpace();
        BuildGrid Build_Grid = new BuildGrid();
        public UserControl2 uc = new UserControl2();
        public ElementHost host = new ElementHost();
        public UserControl2 uc2 = new UserControl2();
        public ElementHost host2 = new ElementHost();

        PrinterSender ps = new PrinterSender();

        //vars of object offset inicial for put the object in the middle
        public List<double> XObj = new List<double>();
        public List<double> YObj = new List<double>();
        public List<double> ZObj = new List<double>();

        //the center of gravity of objects
        public List<double> XMid = new List<double>();
        public List<double> YMid = new List<double>();
        public List<double> ZMid = new List<double>();
        
        public List<Transform3DGroup> RotObjInt = new List<Transform3DGroup>();//transformation group of objects

        public List<List<sliceDataTipe>> sliceData = new List<List<sliceDataTipe>>();//the data of slices
        int SliceSelector = 0;

        //*****************************************************************************************************************************************************
        //Load the form

        public MainScreen()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //get the settings of project
            getData();

            comboBox1.Items.AddRange(Tools);

            host.Dock = DockStyle.Fill; //set size of dock of rendering 3d
            host.Child = uc; //inserts the user control to the host controler
            box_View.Controls.Add(host); //add the rendering area to view groupBox
            host.Location = new System.Drawing.Point(5, 1); //set the position of the area in the groupBox
            box_View.Size = new System.Drawing.Size(10 + ViewAreaX, 75 + ViewAreaY); //set the size of groupbox
            trackBar1.Value = CameraPos; //reset the camera zoom in the trackbar
            mousew = CameraPos; //reset the variable of wheel of mouse to increase or decrease the zoom
            CameraPos = (trackBar1.Value - (100 - (100 / CameraPosCorect))) * CameraPosCorect; //reformat the value to camera zoom
            checkBox1.Checked = Rotates; //set if the auto rotation view is on or off
            uc.Canvas1.Children.Clear(); //clear the canvas
            myViewport = new Viewport3D(); //reset the viewport
            Build_Grid.LoadTableMatrix(); //generate the build area

            Draw.Redraw(); //render the objects

            //inicialize the events handlers
            host.HostContainer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseLeftEnter);
            host.HostContainer.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseLeftRelease);
            host.HostContainer.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseEnter);
            host.HostContainer.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseRelease);
            host.HostContainer.MouseMove += new System.Windows.Input.MouseEventHandler(HostContainer_MouseMove);
            host.HostContainer.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(HostContainer_MouseWheel);

            host2.HostContainer.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseEnter2);
            host2.HostContainer.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(HostContainer_MouseRelease2);
            host2.HostContainer.MouseMove += new System.Windows.Input.MouseEventHandler(HostContainer_MouseMove2);
            host2.HostContainer.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(HostContainer_MouseWheel2);

            //get the mouse position to inicialize
            mousex = System.Windows.Forms.Cursor.Position.X + xang;
            mousey = System.Windows.Forms.Cursor.Position.Y + yang;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //settings

        private void getData()
        {

            if (File.Exists(CurrentDirectory + "/bin/config/BuildArea.cfg"))
            {
                String[] readed = File.ReadAllLines(CurrentDirectory + "/bin/config/BuildArea.cfg");
                foreach (String str in readed)
                {
                    if (str.IndexOf("=") > 0)
                    {
                        if (str.Substring(0, str.IndexOf("=")) == "Dimension in X ") { xmm = Convert.ToDouble(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Dimension in Y ") { ymm = Convert.ToDouble(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Dimension in Z ") { zmm = Convert.ToDouble(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Line Size ") { linesize = Convert.ToDouble(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Tools ") { Tools = (str.Substring(str.IndexOf("=")+2)).Split(new string[] { "," }, StringSplitOptions.None); }
                    }
                }
            }
            else
            {
                List<String> str = new List<string>();
                str.Add("//----------------------------\\ \r\n" +
                        "|| Created by Lucas Camarotto || \r\n" +
                        "||        In 13/07/2016       || \r\n" +
                        "\\----------------------------//");
                str.Add("Dimension in X  = " + xmm);
                str.Add("Dimension in Y  = " + ymm);
                str.Add("Dimension in Z  = " + zmm);
                str.Add("Line Size  = " + linesize);
                str.Add("Tools = Extruder 1");

                getData();

                if (!Directory.Exists(CurrentDirectory + "/bin/config/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/config/"); }
                File.WriteAllLines(CurrentDirectory + "/bin/config/BuildArea.cfg", str);
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //for progress bar to change value

        internal void Loadprogress(int v)
        {
            Load_progress.Value = v;
            Load_progress.Update();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the variation on mouse wheel for zoom on camera

        private void HostContainer_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            mousew += e.Delta / 50;
            if (mousew > 100) { mousew = 100; }
            if (mousew < 0) { mousew = 0; }
            trackBar1.Value = Convert.ToInt32(mousew);
            CameraPos = (trackBar1.Value - (100 - (100 / CameraPosCorect))) * CameraPosCorect;
            Draw.CameraFocus();
            Draw.CanvasSetings();
        }

        private void HostContainer_MouseWheel2(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            mousew2 += e.Delta/50;
            if (mousew2 > -1) { mousew2 = -1; }
            if (mousew2 < -250) { mousew2 = -250; }
            //trackBar1.Value = Convert.ToInt32(mousew);
            CameraPos2 = Convert.ToInt32(mousew2);
            Draw2D.CameraFocus();
            Draw2D.CanvasSetings();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the variation on mouse moviment

        private void HostContainer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (mouseFinder)
            {
                xang = (mousex - System.Windows.Forms.Cursor.Position.X);
                yang = (mousey - System.Windows.Forms.Cursor.Position.Y);
                if (xang == 0) { xang = 1; }
                if (yang == 0) { yang = 1; }
                Draw.CameraFocus();
                Draw.CanvasSetings();
            }
            if (mouseFinderz)
            {
                Zoffset = Convert.ToInt32(mousez - System.Windows.Forms.Cursor.Position.Y);

                Draw.CameraFocus();
                Draw.CanvasSetings();
            }
        }

        private void HostContainer_MouseMove2(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (mouseFinder2)
            {
                xoff2 = (mousex2 - (System.Windows.Forms.Cursor.Position.X * (mousew2 / 250)));
                yoff2 = (mousey2 - (System.Windows.Forms.Cursor.Position.Y * (mousew2 / 250)));

                Draw2D.CameraFocus();
                Draw2D.CanvasSetings();
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the variation on mouse clicks

        private void HostContainer_MouseRelease(object sender, MouseButtonEventArgs e)
        {
            mouseFinder = false;
        }

        private void HostContainer_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseFinder = true;
            mousex = System.Windows.Forms.Cursor.Position.X + xang;
            mousey = System.Windows.Forms.Cursor.Position.Y + yang;
        }

        private void HostContainer_MouseLeftRelease(object sender, MouseButtonEventArgs e)
        {
            mouseFinderz = false;
        }

        private void HostContainer_MouseLeftEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseFinderz = true;
            mousez = System.Windows.Forms.Cursor.Position.Y + Zoffset;
        }


        private void HostContainer_MouseRelease2(object sender, MouseButtonEventArgs e)
        {
            mouseFinder2 = false;
        }

        private void HostContainer_MouseEnter2(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseFinder2 = true;
            mousex2 = System.Windows.Forms.Cursor.Position.X * (mousew2 / 250) + xoff2;
            mousey2 = System.Windows.Forms.Cursor.Position.Y * (mousew2 / 250) + yoff2;
        }


        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the object.stl to slice

        private void bot_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Solid Model Files|*.stl";
            openFileDialog1.Title = "Select the model File";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathObj.Add(openFileDialog1.FileName);

                OffsetObj.Add(new Point3D(0,0,0));
                RotObj.Add(new Point3D(0, 0, 0));
                RotObjIn.Add(new Point3D(0, 0, 0));
                Transparency.Add(0);
                toolSelected.Add(0);

                RotObjInt.Add(new Transform3DGroup());
                list_Objects.Items.Add(PathObj[Convert.ToInt32(PathObj.LongCount()-1)].Substring(PathObj[Convert.ToInt32(PathObj.LongCount() - 1)].LastIndexOf("\\")+1, PathObj[Convert.ToInt32(PathObj.LongCount() - 1)].LastIndexOf(".stl") - PathObj[Convert.ToInt32(PathObj.LongCount() - 1)].LastIndexOf("\\")-1));
                PathObj[Convert.ToInt32(PathObj.LongCount() - 1)].Replace("\\","/"); Load_progress.Value = 0;

                Load_progress.Visible = true;
                Load_progress.Update();
                uc.Canvas1.Children.Clear();
                myViewport = new Viewport3D();
                Build_Grid.LoadTableMatrix();

                new FileInput().LoadPointsofFile();

                Load_progress.Visible = false;
                list_Objects.SelectedIndex = list_Objects.Items.Count - 1;
                comboBox1.SelectedIndex = 0;
                Transpy.Text = 0.ToString();
                Draw.Middle();
            }

            //sets the point of obj
            try
            {
                uc.Canvas1.Children.Clear();
                myViewport = new Viewport3D();
                Build_Grid.LoadTableMatrix();
                OffsetObj[SelectedObj] = new Point3D(Convert.ToDouble(Pos_Z.Text), Convert.ToDouble(Pos_Y.Text), Convert.ToDouble(Pos_X.Text));
                OffsetObjInt = new Point3D(Convert.ToDouble(Pos_Z.Text), Convert.ToDouble(Pos_Y.Text), Convert.ToDouble(Pos_X.Text));
                RotObj[SelectedObj] = new Point3D(Convert.ToDouble(Rot_X.Text), Convert.ToDouble(Rot_Y.Text), Convert.ToDouble(Rot_Z.Text));
                Draw.Realocate();
                Draw.Redraw();

            }
            catch (Exception ei)
            {
                //System.Windows.MessageBox.Show("Please provide numbers only");
            }

        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the variation on trackbar to zoom on camera

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            CameraPos = (trackBar1.Value-(100-(100/CameraPosCorect)))*CameraPosCorect;
            Draw.CameraFocus();
            Draw.CanvasSetings();

        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //set to auto rotates the view 

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Rotates=checkBox1.Checked;
            Draw.RotationView();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //get the object selected in the list

        private void list_Objects_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedObj = list_Objects.SelectedIndex;
            if (list_Objects.SelectedIndex > -1)
            {
                Proprietie_group.Visible = true;
                objects_group.Visible = true;
                Generate_code.Enabled = true;
                bot_remove.Enabled = true;

                Pos_Z.Text = (OffsetObj[list_Objects.SelectedIndex].X).ToString();
                Pos_Y.Text = OffsetObj[list_Objects.SelectedIndex].Y.ToString();
                Pos_X.Text = OffsetObj[list_Objects.SelectedIndex].Z.ToString();

                Rot_X.Text = RotObj[list_Objects.SelectedIndex].X.ToString();
                Rot_Y.Text = RotObj[list_Objects.SelectedIndex].Y.ToString();
                Rot_Z.Text = RotObj[list_Objects.SelectedIndex].Z.ToString();

                Transpy.Text = Transparency[SelectedObj].ToString();
            }else
            {
                Proprietie_group.Visible = false;
                objects_group.Visible = false;
                Generate_code.Enabled = false;
                bot_remove.Enabled = false;
            }

            uc.Canvas1.Children.Clear();
            myViewport = new Viewport3D();
            Build_Grid.LoadTableMatrix();
            Draw.Redraw();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //realocate and rotates the object in the build area

        private void bot_realocate_Click(object sender, EventArgs e)
        {
            
            try
            {
                uc.Canvas1.Children.Clear();
                myViewport = new Viewport3D();
                Build_Grid.LoadTableMatrix();
                OffsetObj[SelectedObj]= new Point3D(Convert.ToDouble(Pos_Z.Text), Convert.ToDouble(Pos_Y.Text), Convert.ToDouble(Pos_X.Text));
                OffsetObjInt = new Point3D(Convert.ToDouble(Pos_Z.Text), Convert.ToDouble(Pos_Y.Text), Convert.ToDouble(Pos_X.Text));
                RotObj[SelectedObj] = new Point3D(Convert.ToDouble(Rot_X.Text), Convert.ToDouble(Rot_Y.Text), Convert.ToDouble(Rot_Z.Text));
                Draw.Realocate();
                Draw.Redraw();

            }
            catch (Exception ei)
            {
                //System.Windows.MessageBox.Show("Please provide numbers only");
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //remove the object

        private void bot_remove_Click(object sender, EventArgs e)
        {
            if (list_Objects.SelectedIndex > -1)
            {
                XObj.RemoveAt(list_Objects.SelectedIndex);
                YObj.RemoveAt(list_Objects.SelectedIndex);
                ZObj.RemoveAt(list_Objects.SelectedIndex);

                XMid.RemoveAt(list_Objects.SelectedIndex);
                YMid.RemoveAt(list_Objects.SelectedIndex);
                ZMid.RemoveAt(list_Objects.SelectedIndex);

                PathObj.RemoveAt(list_Objects.SelectedIndex);
                NObj.RemoveAt(list_Objects.SelectedIndex);
                OffsetObj.RemoveAt(list_Objects.SelectedIndex);

                RotObjIn.RemoveAt(list_Objects.SelectedIndex);
                //RotObj.RemoveAt(list_Objects.SelectedIndex);
                RotObjInt.RemoveAt(list_Objects.SelectedIndex);

                list_Objects.Items.RemoveAt(list_Objects.SelectedIndex);
                uc.Canvas1.Children.Clear();
                myViewport = new Viewport3D();
                Build_Grid.LoadTableMatrix();
                Draw.Redraw();
                //Draw.Render();
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //reset the position of camera

        private void Bot_Reset_view_Click(object sender, EventArgs e)
        {
            mousew = 50;
            trackBar1.Value = Convert.ToInt32(mousew);

            CameraPos = (trackBar1.Value - (100 - (100 / CameraPosCorect))) * CameraPosCorect;
            Zoffset = -50;
            xang = 283;
            yang = 209;

            Draw.CameraFocus();
            Draw.CanvasSetings();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //generate the code for the printer

        private void Generate_code_Click(object sender, EventArgs e)
        {
            FileOutput fi = new FileOutput();
            fi.Objects(PathObj);
            fi.Offcet(OffsetObj);
            //fi.Generate("D:/_Arquivos/BIOFABRIS/Impressora_3d/Bioploter_Slicer/BioFabris/bin/Temp/1.c3d");
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Code for |*.c3d";
            sfd.Title = "Select the model File";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fi.Generate(sfd.FileName);
            }
            //*/
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the tool of object

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolSelected[SelectedObj] = comboBox1.Items.IndexOf( comboBox1.SelectedItem);
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //read c3d
        
        private void OpenC3D_Click(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "3D Printer Code|*.c3d";
            openFileDialog1.Title = "Select the Printer Code File";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                new FileInput().LoadC3D(openFileDialog1.FileName);
                NSlice.Visible = false;
                BSlice.Visible = false;
                Slice_Number.Visible = false;
                vScrollBar.Visible = true;
                SliceView_group.Visible = true;
                Print_bot.Enabled = true;
                vScrollBar.Value = 100;
                SliceSelector = Convert.ToInt32(sliceData.LongCount());
                Slice_Number.Text = SliceSelector.ToString();
                //render2d area

                host2.Dock = DockStyle.Fill; //set size of dock of rendering 3d
                host2.Child = uc2; //inserts the user control to the host controler
                uc2.Canvas1.Children.Clear(); //clear the canvas
                SliceView_group.Controls.Add(host2); //add the rendering area to view groupBox
                host2.Location = new System.Drawing.Point(1, 1); //set the position of the area in the groupBox
                SliceView_group.Size = new System.Drawing.Size(10 + ViewArea2DX, 10 + ViewArea2DY); //set the size of groupbox
                SliceSelector_Scroll(1);
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the tool of object
        
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //clear the vars
            list_Objects.Items.Clear();
            
            Proprietie_group.Visible = false;
            objects_group.Visible = false;
            Generate_code.Enabled = false;
            bot_remove.Enabled = false;
            Printer_group.Visible = false;

            Print_bot.Enabled = false;

            NSlice.Visible = false;
            BSlice.Visible = false;
            Slice_Number.Visible = false;
            vScrollBar.Visible = false;
            SliceView_group.Visible = false;

            XObj = new List<double>();
            YObj = new List<double>();
            ZObj = new List<double>();

            XMid = new List<double>();
            YMid = new List<double>();
            ZMid = new List<double>();

            PathObj = new List<string>();
            NObj = new List<MeshGeometry3D>();
            OffsetObj = new List<Point3D>();

            RotObjIn = new List<Point3D>();
            RotObj = new List<Point3D>();
            RotObjInt = new List<Transform3DGroup>();

            myViewport = new Viewport3D();
            uc.Canvas1.Children.Clear();

            Build_Grid.LoadTableMatrix();
            Draw.Redraw();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the slice to view

        private void SliceSelector_Scroll(int sliceLay)
        {
            int slice = sliceLay;
            myViewport = new Viewport3D();
            uc.Canvas1.Children.Clear();
            uc2.Canvas1.Children.Clear();
            ViewP2D = new Viewport3D();

            Build_Grid.LoadTableMatrix();
            Draw.Redraw();

            sliceLay++;
            foreach (List<sliceDataTipe> Lsld in sliceData)
            {
                foreach (sliceDataTipe sld in Lsld)
                {
                    Draw.DrawLine(sld.startPoint, sld.endPoint, sld.lineSize, sld.Cors);
                }
                sliceLay--;
                if (sliceLay == 0) { break; }
            }
            Draw2D.Redraw();
            if (slice >= sliceData.LongCount()) { slice = Convert.ToInt32(sliceData.LongCount() - 1); }
            foreach (sliceDataTipe sld in sliceData[slice])
            {
                Draw2D.DrawLine(sld.startPoint, sld.endPoint, sld.lineSize, sld.Cors);
            }
        }
        
        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the next slice

        private void NSlice_Click(object sender, EventArgs e)
        {
            SliceSelector++;
            if (SliceSelector > sliceData.LongCount()) { SliceSelector = Convert.ToInt32(sliceData.LongCount()); }
            SliceSelector_Scroll(SliceSelector);
            Slice_Number.Text = SliceSelector.ToString();
        }
        
        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the previous slice

        private void BSlice_Click(object sender, EventArgs e)
        {
            SliceSelector--;
            if (SliceSelector <0) { SliceSelector = 0; }
            SliceSelector_Scroll(SliceSelector);
            Slice_Number.Text = SliceSelector.ToString();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set number of the slice

        private void Slice_Number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SliceSelector = Convert.ToInt32(Slice_Number.Text);
            }catch(Exception ex) { }
            if (SliceSelector < 0) { SliceSelector = 0; }
            if (SliceSelector > sliceData.LongCount()) { SliceSelector = Convert.ToInt32(sliceData.LongCount()); }
            SliceSelector_Scroll(SliceSelector);
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            SliceSelector = Convert.ToInt32((sliceData.LongCount() * (100-(vScrollBar.Value)+1))/100)-1;
            if (SliceSelector < 1) { SliceSelector = 1; }
            if (SliceSelector > sliceData.LongCount()) { SliceSelector = Convert.ToInt32(sliceData.LongCount()); }
            Slice_Number.Text = SliceSelector.ToString();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the transparency of object

        private void Transpy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Transparency[SelectedObj] = Convert.ToInt32(Transpy.Text);
                if (Transparency[SelectedObj] > 100) { Transparency[SelectedObj] = 100; }
                if (Transparency[SelectedObj] <0) { Transparency[SelectedObj] = 0; }
            }
            catch(Exception ex)
            {

            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //open the printer box
        
        private void Print_bot_Click(object sender, EventArgs e)
        {
            ps = new PrinterSender();
            ps.Init();
            CodeBox.Clear();
            Printer_group.Visible = true;
            SliceView_group.Visible = false;
            ComPorts = new System.Windows.Forms.ComboBox();
            foreach (string s in ps.GetPortsAvailable())
            {
                ComPorts.Items.Add(s);
            }
            ComPorts.SelectedText = ps.GetPort();
            ps.PrinterCode(CodeLines);
            Temperature_extruder.Text = ps.GetTemperature();
        }
        
        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Send the code to printer

        private void Printer_Send_Click(object sender, EventArgs e)
        {
            CodeBox.Clear();
            try
            {
                ps.setTemperature(Convert.ToDouble(Temperature_extruder));
                ps.ComPort(ComPorts.SelectedText.ToString());
                ps.SendCode();
            }
            catch (Exception ei)
            {
                System.Windows.MessageBox.Show("[Error] Select an COM Port");
            }
        }
        
        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //add the code pf printing to an text box

        public void CodeBoxText(string s)
        {
            CodeBox.AppendText(s);
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
