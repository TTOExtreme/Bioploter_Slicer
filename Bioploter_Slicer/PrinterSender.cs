using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioploter_Slicer
{
    class PrinterSender
    {
        String CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
        private SerialPort SerialCom = new SerialPort();
        private double temperature_extruder = 0;

        private List<string> Code = new List<string>();
        private List<string> ChangeTool = new List<string>();

        private int RobotType = 1;
        private int Pass_to_mm = 95;
        private int Pass_to_rot = 200;
        private string Com = "Select Port";

        private bool Confirm = false;


        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //inicialize the objects

        public void Init()
        {
            SerialCom.BaudRate = 115200;
            SerialCom.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);
            getPrinterData();
        }
        
        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //recieve data from the printer

        private void DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            string recieved = SerialCom.ReadExisting();
            if (recieved.IndexOf("n") > -1)
            {
                Confirm = true;
            }else
            {
                if (recieved.IndexOf("Error") > -1)
                {
                    System.Windows.MessageBox.Show(recieved);
                }
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the ComPort

        public void ComPort(string com)
        {
            if (com.IndexOf("ect") == -1)
            {
                SerialCom.PortName = com;
                Com = com;
                WritePrinterData();
            }
            else
            {
                System.Windows.MessageBox.Show("[Error] Select an COM Port");
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Get the ports available

        public string[] GetPortsAvailable()
        {
            return SerialPort.GetPortNames();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Get the port pre-selected

        public string GetPort()
        {
            return Com;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Get the predefined temperature

        public string GetTemperature()
        {
            return temperature_extruder.ToString();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the temperature of extruder

        public void setTemperature(double temp)
        {
            temperature_extruder = temp;
            WritePrinterData();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Get the data form configs

        private void getPrinterData()
        {

            if (File.Exists(CurrentDirectory + "/bin/config/Printer.cfg"))
            {
                String[] readed = File.ReadAllLines(CurrentDirectory + "/bin/config/Printer.cfg");
                foreach (String str in readed)
                {
                    if (str.IndexOf("=") > 0)
                    {
                        if (str.Substring(0, str.IndexOf("=")) == "Pass to mm ") { Pass_to_mm = Convert.ToInt32(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Pass to Rot ") { Pass_to_rot = Convert.ToInt32(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "Robot Type ") { RobotType = Convert.ToInt32(str.Substring(str.IndexOf("="))); }
                        if (str.Substring(0, str.IndexOf("=")) == "COM Port ") { Com = str.Substring(str.IndexOf("=")); }
                        if (str.Substring(0, str.IndexOf("=")) == "Temperature of Extruder ") { temperature_extruder = Convert.ToDouble(str.Substring(str.IndexOf("="))); }
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
                str.Add("1 = an xyz type; 2 = an Scara type");
                str.Add("Robot Type  = " + RobotType);
                str.Add("COM Port  = " + Com);
                str.Add("Pass to mm  = " + Pass_to_mm);
                str.Add("Pass to rot  = " + Pass_to_rot);
                str.Add("Temperature of Extruder  = " + temperature_extruder);

                if (!Directory.Exists(CurrentDirectory + "/bin/config/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/config/"); }
                File.WriteAllLines(CurrentDirectory + "/bin/config/Printer.cfg", str);

                getPrinterData();
            }
            //get the change tool protocol
            if (File.Exists(CurrentDirectory + "/bin/config/tcPrinter.cfg"))
            {
                ChangeTool.Clear();
                String[] readed = File.ReadAllLines(CurrentDirectory + "/bin/config/tcPrinter.cfg");
                foreach (String str in readed)
                {
                    if (str.IndexOf("#") > 0)
                    {
                        ChangeTool.Add(str);
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
                str.Add("#G1 Z150.000;");
                str.Add("#G1 X0.000 Y0.000;");

                if (!Directory.Exists(CurrentDirectory + "/bin/config/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/config/"); }
                File.WriteAllLines(CurrentDirectory + "/bin/config/tcPrinter.cfg", str);

                getPrinterData();
            }
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //write to config

        private void WritePrinterData()
        {
            List<String> str = new List<string>();
            str.Add("//----------------------------\\ \r\n" +
                    "|| Created by Lucas Camarotto || \r\n" +
                    "||        In 13/07/2016       || \r\n" +
                    "\\----------------------------//");
            str.Add("1 = an xyz type; 2 = an Scara type");
            str.Add("Robot Type  = " + RobotType);
            str.Add("COM Port  = " + Com);
            str.Add("Pass to mm  = " + Pass_to_mm);
            str.Add("Pass to rot  = " + Pass_to_rot);
            str.Add("Temperature of Extruder  = " + temperature_extruder);

            if (!Directory.Exists(CurrentDirectory + "/bin/config/")) { Directory.CreateDirectory(CurrentDirectory + "/bin/config/"); }
            File.WriteAllLines(CurrentDirectory + "/bin/config/Printer.cfg", str);

            getPrinterData();
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Set the code to print

        public void PrinterCode(List<string> list)
        {
            Code = list;
        }

        //*****************************************************************************************************************************************************

        //*****************************************************************************************************************************************************
        //Send the code
        
        public async void SendCode()
        {
            var Main = System.Windows.Forms.Application.OpenForms.OfType<MainScreen>().Single();
            if (Com.IndexOf("Select") == -1)
            {
                List<String> PreConfigPrinter = new List<string>();
                if (RobotType == 1)
                {
                    PreConfigPrinter.Add("#C00 Ps" + Pass_to_mm + ";");
                }
                else
                {
                    PreConfigPrinter.Add("#C01 Ps" + Pass_to_rot + ";");
                }

                PreConfigPrinter.Add("#C05;");//set origem

                if (temperature_extruder > 0)
                {
                    PreConfigPrinter.Add("#T05 Dv00 Tp" + temperature_extruder + ";");
                }

                foreach (string str in PreConfigPrinter)
                {
                    SerialCom.Write(str);
                    Main.CodeBoxText(str);
                    int cont = 600;
                    while (!Confirm) { Task.Delay(100); cont--; if (cont < 0) { break; Main.CodeBoxText("[Error] TimeLimit exceeded"); } }
                    Confirm = false;
                }

                foreach (string str in Code)
                {
                    if (str.IndexOf("tool") > -1)
                    {
                        foreach (string str1 in ChangeTool)
                        {
                            SerialCom.Write(str1);
                            Main.CodeBoxText(str);
                            int cont = 600;
                            while (!Confirm) { Task.Delay(100); cont--; if (cont < 0) { break; Main.CodeBoxText("[Error] TimeLimit exceeded"); } }
                            Confirm = false;
                        }
                    }
                    else
                    {
                        SerialCom.Write(str);
                        Main.CodeBoxText(str);
                        int cont = 600;
                        while (!Confirm) { Task.Delay(100); cont--; if (cont < 0) { break; Main.CodeBoxText("[Error] TimeLimit exceeded"); } }
                        Confirm = false;
                    }
                }

            }
            else
            {
                System.Windows.MessageBox.Show("[Error] Select an COM Port");
            }
        }

        //*****************************************************************************************************************************************************
        
    }
}
