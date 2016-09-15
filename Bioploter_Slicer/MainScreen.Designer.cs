using System;

namespace Bioploter_Slicer
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.list_Objects = new System.Windows.Forms.ListBox();
            this.Pos_X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.objects_group = new System.Windows.Forms.GroupBox();
            this.Load_progress = new System.Windows.Forms.ProgressBar();
            this.ResetButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bot_remove = new System.Windows.Forms.Button();
            this.bot_load = new System.Windows.Forms.Button();
            this.Proprietie_group = new System.Windows.Forms.GroupBox();
            this.Transpy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Rot_Z = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Rot_Y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Rot_X = new System.Windows.Forms.TextBox();
            this.bot_realocate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Pos_Z = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pos_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_View = new System.Windows.Forms.GroupBox();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.Slice_Number = new System.Windows.Forms.TextBox();
            this.NSlice = new System.Windows.Forms.Button();
            this.BSlice = new System.Windows.Forms.Button();
            this.Bot_Reset_view = new System.Windows.Forms.Button();
            this.Tools_group = new System.Windows.Forms.GroupBox();
            this.Print_bot = new System.Windows.Forms.Button();
            this.Generate_code = new System.Windows.Forms.Button();
            this.SliceView_group = new System.Windows.Forms.GroupBox();
            this.Printer_group = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ComPorts = new System.Windows.Forms.ComboBox();
            this.Temperature_extruder = new System.Windows.Forms.TextBox();
            this.Printer_Send = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.objects_group.SuspendLayout();
            this.Proprietie_group.SuspendLayout();
            this.box_View.SuspendLayout();
            this.Tools_group.SuspendLayout();
            this.Printer_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackBar1.Location = new System.Drawing.Point(6, 589);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(500, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(512, 589);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Rotate View";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // list_Objects
            // 
            this.list_Objects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Objects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.list_Objects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Objects.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Objects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.list_Objects.FormattingEnabled = true;
            this.list_Objects.ItemHeight = 18;
            this.list_Objects.Location = new System.Drawing.Point(6, 20);
            this.list_Objects.Name = "list_Objects";
            this.list_Objects.Size = new System.Drawing.Size(190, 216);
            this.list_Objects.TabIndex = 4;
            this.list_Objects.SelectedIndexChanged += new System.EventHandler(this.list_Objects_SelectedIndexChanged);
            // 
            // Pos_X
            // 
            this.Pos_X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Pos_X.Location = new System.Drawing.Point(29, 36);
            this.Pos_X.Name = "Pos_X";
            this.Pos_X.Size = new System.Drawing.Size(74, 20);
            this.Pos_X.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Position";
            // 
            // objects_group
            // 
            this.objects_group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objects_group.AutoSize = true;
            this.objects_group.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.objects_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.objects_group.Controls.Add(this.Load_progress);
            this.objects_group.Controls.Add(this.list_Objects);
            this.objects_group.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.objects_group.Location = new System.Drawing.Point(1144, 5);
            this.objects_group.Name = "objects_group";
            this.objects_group.Size = new System.Drawing.Size(202, 255);
            this.objects_group.TabIndex = 7;
            this.objects_group.TabStop = false;
            this.objects_group.Text = "Objects";
            this.objects_group.Visible = false;
            // 
            // Load_progress
            // 
            this.Load_progress.Location = new System.Drawing.Point(6, 212);
            this.Load_progress.Name = "Load_progress";
            this.Load_progress.Size = new System.Drawing.Size(190, 23);
            this.Load_progress.TabIndex = 10;
            this.Load_progress.Visible = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(699, 16);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(105, 25);
            this.ResetButton.TabIndex = 11;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(334, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load .c3d";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OpenC3D_Click);
            // 
            // bot_remove
            // 
            this.bot_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bot_remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bot_remove.Enabled = false;
            this.bot_remove.Location = new System.Drawing.Point(115, 16);
            this.bot_remove.Margin = new System.Windows.Forms.Padding(0);
            this.bot_remove.Name = "bot_remove";
            this.bot_remove.Size = new System.Drawing.Size(105, 25);
            this.bot_remove.TabIndex = 5;
            this.bot_remove.Text = "Remove .stl";
            this.bot_remove.UseVisualStyleBackColor = true;
            this.bot_remove.Click += new System.EventHandler(this.bot_remove_Click);
            // 
            // bot_load
            // 
            this.bot_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bot_load.Location = new System.Drawing.Point(6, 16);
            this.bot_load.Margin = new System.Windows.Forms.Padding(0);
            this.bot_load.Name = "bot_load";
            this.bot_load.Size = new System.Drawing.Size(105, 25);
            this.bot_load.TabIndex = 1;
            this.bot_load.Text = "Add New .stl";
            this.bot_load.UseVisualStyleBackColor = true;
            this.bot_load.Click += new System.EventHandler(this.bot_load_Click);
            // 
            // Proprietie_group
            // 
            this.Proprietie_group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Proprietie_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Proprietie_group.Controls.Add(this.Transpy);
            this.Proprietie_group.Controls.Add(this.label10);
            this.Proprietie_group.Controls.Add(this.label9);
            this.Proprietie_group.Controls.Add(this.comboBox1);
            this.Proprietie_group.Controls.Add(this.label8);
            this.Proprietie_group.Controls.Add(this.label5);
            this.Proprietie_group.Controls.Add(this.Rot_Z);
            this.Proprietie_group.Controls.Add(this.label6);
            this.Proprietie_group.Controls.Add(this.Rot_Y);
            this.Proprietie_group.Controls.Add(this.label7);
            this.Proprietie_group.Controls.Add(this.Rot_X);
            this.Proprietie_group.Controls.Add(this.bot_realocate);
            this.Proprietie_group.Controls.Add(this.label4);
            this.Proprietie_group.Controls.Add(this.Pos_Z);
            this.Proprietie_group.Controls.Add(this.label3);
            this.Proprietie_group.Controls.Add(this.Pos_Y);
            this.Proprietie_group.Controls.Add(this.label2);
            this.Proprietie_group.Controls.Add(this.Pos_X);
            this.Proprietie_group.Controls.Add(this.label1);
            this.Proprietie_group.Location = new System.Drawing.Point(1144, 265);
            this.Proprietie_group.Name = "Proprietie_group";
            this.Proprietie_group.Size = new System.Drawing.Size(202, 397);
            this.Proprietie_group.TabIndex = 8;
            this.Proprietie_group.TabStop = false;
            this.Proprietie_group.Text = "Proprieties";
            this.Proprietie_group.Visible = false;
            // 
            // Transpy
            // 
            this.Transpy.Location = new System.Drawing.Point(115, 248);
            this.Transpy.Name = "Transpy";
            this.Transpy.Size = new System.Drawing.Size(82, 20);
            this.Transpy.TabIndex = 23;
            this.Transpy.TextChanged += new System.EventHandler(this.Transpy_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Transparency:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tool:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 217);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Rotation";
            this.label8.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Z:";
            this.label5.Visible = false;
            // 
            // Rot_Z
            // 
            this.Rot_Z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Rot_Z.Location = new System.Drawing.Point(29, 191);
            this.Rot_Z.Name = "Rot_Z";
            this.Rot_Z.Size = new System.Drawing.Size(74, 20);
            this.Rot_Z.TabIndex = 13;
            this.Rot_Z.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Y:";
            this.label6.Visible = false;
            // 
            // Rot_Y
            // 
            this.Rot_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Rot_Y.Location = new System.Drawing.Point(29, 165);
            this.Rot_Y.Name = "Rot_Y";
            this.Rot_Y.Size = new System.Drawing.Size(74, 20);
            this.Rot_Y.TabIndex = 12;
            this.Rot_Y.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "X:";
            this.label7.Visible = false;
            // 
            // Rot_X
            // 
            this.Rot_X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Rot_X.Location = new System.Drawing.Point(29, 139);
            this.Rot_X.Name = "Rot_X";
            this.Rot_X.Size = new System.Drawing.Size(74, 20);
            this.Rot_X.TabIndex = 11;
            this.Rot_X.Visible = false;
            // 
            // bot_realocate
            // 
            this.bot_realocate.Location = new System.Drawing.Point(63, 273);
            this.bot_realocate.Name = "bot_realocate";
            this.bot_realocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bot_realocate.Size = new System.Drawing.Size(85, 23);
            this.bot_realocate.TabIndex = 14;
            this.bot_realocate.Text = "Apply";
            this.bot_realocate.UseVisualStyleBackColor = true;
            this.bot_realocate.Click += new System.EventHandler(this.bot_realocate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Z:";
            // 
            // Pos_Z
            // 
            this.Pos_Z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Pos_Z.Location = new System.Drawing.Point(29, 88);
            this.Pos_Z.Name = "Pos_Z";
            this.Pos_Z.Size = new System.Drawing.Size(74, 20);
            this.Pos_Z.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y:";
            // 
            // Pos_Y
            // 
            this.Pos_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Pos_Y.Location = new System.Drawing.Point(29, 62);
            this.Pos_Y.Name = "Pos_Y";
            this.Pos_Y.Size = new System.Drawing.Size(74, 20);
            this.Pos_Y.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X:";
            // 
            // box_View
            // 
            this.box_View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.box_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.box_View.Controls.Add(this.vScrollBar);
            this.box_View.Controls.Add(this.Slice_Number);
            this.box_View.Controls.Add(this.NSlice);
            this.box_View.Controls.Add(this.BSlice);
            this.box_View.Controls.Add(this.Bot_Reset_view);
            this.box_View.Controls.Add(this.trackBar1);
            this.box_View.Controls.Add(this.checkBox1);
            this.box_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.box_View.Location = new System.Drawing.Point(5, 60);
            this.box_View.Name = "box_View";
            this.box_View.Size = new System.Drawing.Size(810, 640);
            this.box_View.TabIndex = 9;
            this.box_View.TabStop = false;
            this.box_View.Text = "View";
            // 
            // vScrollBar
            // 
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(787, 16);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 590);
            this.vScrollBar.TabIndex = 22;
            this.vScrollBar.Visible = false;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // Slice_Number
            // 
            this.Slice_Number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Slice_Number.Location = new System.Drawing.Point(755, 611);
            this.Slice_Number.Name = "Slice_Number";
            this.Slice_Number.Size = new System.Drawing.Size(49, 20);
            this.Slice_Number.TabIndex = 13;
            this.Slice_Number.Visible = false;
            this.Slice_Number.TextChanged += new System.EventHandler(this.Slice_Number_TextChanged);
            // 
            // NSlice
            // 
            this.NSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NSlice.Location = new System.Drawing.Point(674, 611);
            this.NSlice.Name = "NSlice";
            this.NSlice.Size = new System.Drawing.Size(75, 23);
            this.NSlice.TabIndex = 12;
            this.NSlice.Text = "Next Slice";
            this.NSlice.UseVisualStyleBackColor = true;
            this.NSlice.Visible = false;
            this.NSlice.Click += new System.EventHandler(this.NSlice_Click);
            // 
            // BSlice
            // 
            this.BSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BSlice.Location = new System.Drawing.Point(593, 611);
            this.BSlice.Name = "BSlice";
            this.BSlice.Size = new System.Drawing.Size(75, 23);
            this.BSlice.TabIndex = 11;
            this.BSlice.Text = "Prev Slice";
            this.BSlice.UseVisualStyleBackColor = true;
            this.BSlice.Visible = false;
            this.BSlice.Click += new System.EventHandler(this.BSlice_Click);
            // 
            // Bot_Reset_view
            // 
            this.Bot_Reset_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bot_Reset_view.Location = new System.Drawing.Point(512, 611);
            this.Bot_Reset_view.Name = "Bot_Reset_view";
            this.Bot_Reset_view.Size = new System.Drawing.Size(75, 23);
            this.Bot_Reset_view.TabIndex = 10;
            this.Bot_Reset_view.Text = "Reset";
            this.Bot_Reset_view.UseVisualStyleBackColor = true;
            this.Bot_Reset_view.Click += new System.EventHandler(this.Bot_Reset_view_Click);
            // 
            // Tools_group
            // 
            this.Tools_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Tools_group.Controls.Add(this.Print_bot);
            this.Tools_group.Controls.Add(this.button2);
            this.Tools_group.Controls.Add(this.ResetButton);
            this.Tools_group.Controls.Add(this.Generate_code);
            this.Tools_group.Controls.Add(this.bot_load);
            this.Tools_group.Controls.Add(this.bot_remove);
            this.Tools_group.Location = new System.Drawing.Point(5, 5);
            this.Tools_group.Name = "Tools_group";
            this.Tools_group.Size = new System.Drawing.Size(810, 53);
            this.Tools_group.TabIndex = 10;
            this.Tools_group.TabStop = false;
            this.Tools_group.Text = "Tools";
            // 
            // Print_bot
            // 
            this.Print_bot.Enabled = false;
            this.Print_bot.Location = new System.Drawing.Point(445, 16);
            this.Print_bot.Name = "Print_bot";
            this.Print_bot.Size = new System.Drawing.Size(105, 25);
            this.Print_bot.TabIndex = 12;
            this.Print_bot.Text = "Print";
            this.Print_bot.UseVisualStyleBackColor = true;
            this.Print_bot.Click += new System.EventHandler(this.Print_bot_Click);
            // 
            // Generate_code
            // 
            this.Generate_code.Enabled = false;
            this.Generate_code.Location = new System.Drawing.Point(223, 16);
            this.Generate_code.Name = "Generate_code";
            this.Generate_code.Size = new System.Drawing.Size(105, 25);
            this.Generate_code.TabIndex = 0;
            this.Generate_code.Text = "Generate .c3d";
            this.Generate_code.UseVisualStyleBackColor = true;
            this.Generate_code.Click += new System.EventHandler(this.Generate_code_Click);
            // 
            // SliceView_group
            // 
            this.SliceView_group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SliceView_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.SliceView_group.Location = new System.Drawing.Point(866, 5);
            this.SliceView_group.Name = "SliceView_group";
            this.SliceView_group.Size = new System.Drawing.Size(480, 480);
            this.SliceView_group.TabIndex = 11;
            this.SliceView_group.TabStop = false;
            this.SliceView_group.Text = "Slice Viewer";
            this.SliceView_group.Visible = false;
            // 
            // Printer_group
            // 
            this.Printer_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Printer_group.Controls.Add(this.Printer_Send);
            this.Printer_group.Controls.Add(this.label13);
            this.Printer_group.Controls.Add(this.CodeBox);
            this.Printer_group.Controls.Add(this.label12);
            this.Printer_group.Controls.Add(this.label11);
            this.Printer_group.Controls.Add(this.ComPorts);
            this.Printer_group.Controls.Add(this.Temperature_extruder);
            this.Printer_group.Location = new System.Drawing.Point(821, 5);
            this.Printer_group.Name = "Printer_group";
            this.Printer_group.Size = new System.Drawing.Size(257, 695);
            this.Printer_group.TabIndex = 12;
            this.Printer_group.TabStop = false;
            this.Printer_group.Text = "Printer";
            this.Printer_group.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Code:";
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(6, 91);
            this.CodeBox.Multiline = true;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.ReadOnly = true;
            this.CodeBox.Size = new System.Drawing.Size(244, 595);
            this.CodeBox.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Temperature Extruder:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "SerialPort:";
            // 
            // ComPorts
            // 
            this.ComPorts.FormattingEnabled = true;
            this.ComPorts.Location = new System.Drawing.Point(129, 16);
            this.ComPorts.Name = "ComPorts";
            this.ComPorts.Size = new System.Drawing.Size(121, 21);
            this.ComPorts.TabIndex = 1;
            // 
            // Temperature_extruder
            // 
            this.Temperature_extruder.Location = new System.Drawing.Point(129, 43);
            this.Temperature_extruder.Name = "Temperature_extruder";
            this.Temperature_extruder.Size = new System.Drawing.Size(100, 20);
            this.Temperature_extruder.TabIndex = 0;
            // 
            // Printer_Send
            // 
            this.Printer_Send.Location = new System.Drawing.Point(175, 66);
            this.Printer_Send.Name = "Printer_Send";
            this.Printer_Send.Size = new System.Drawing.Size(75, 23);
            this.Printer_Send.TabIndex = 13;
            this.Printer_Send.Text = "Send";
            this.Printer_Send.UseVisualStyleBackColor = true;
            this.Printer_Send.Click += new System.EventHandler(this.Printer_Send_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BackgroundImage = global::Bioploter_Slicer.Properties.Resources.bio_2c;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.Printer_group);
            this.Controls.Add(this.Proprietie_group);
            this.Controls.Add(this.Tools_group);
            this.Controls.Add(this.objects_group);
            this.Controls.Add(this.box_View);
            this.Controls.Add(this.SliceView_group);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.objects_group.ResumeLayout(false);
            this.Proprietie_group.ResumeLayout(false);
            this.Proprietie_group.PerformLayout();
            this.box_View.ResumeLayout(false);
            this.box_View.PerformLayout();
            this.Tools_group.ResumeLayout(false);
            this.Printer_group.ResumeLayout(false);
            this.Printer_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControl2 userControl2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox list_Objects;
        private System.Windows.Forms.TextBox Pos_X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox objects_group;
        private System.Windows.Forms.Button bot_load;
        private System.Windows.Forms.GroupBox Proprietie_group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Pos_Z;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Pos_Y;
        private System.Windows.Forms.GroupBox box_View;
        private System.Windows.Forms.Button bot_realocate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Rot_Z;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Rot_Y;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Rot_X;
        private System.Windows.Forms.Button bot_remove;
        private System.Windows.Forms.ProgressBar Load_progress;
        private System.Windows.Forms.Button Bot_Reset_view;
        private System.Windows.Forms.GroupBox Tools_group;
        private System.Windows.Forms.Button Generate_code;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button NSlice;
        private System.Windows.Forms.Button BSlice;
        private System.Windows.Forms.TextBox Slice_Number;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.TextBox Transpy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox SliceView_group;
        private System.Windows.Forms.Button Print_bot;
        private System.Windows.Forms.GroupBox Printer_group;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComPorts;
        private System.Windows.Forms.TextBox Temperature_extruder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Printer_Send;
    }
}


/*
*
*   Created By Lucas Camarotto
*   In 14/7/2016
*
*/
