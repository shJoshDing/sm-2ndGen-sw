﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ADI.DMY2;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace CurrentSensorV3
{
    public partial class CurrentSensorConsole : Form
    {
        public CurrentSensorConsole()
        {
            InitializeComponent();
            UserInit();
        }

        public struct ModuleAttribute
        { 
            public double dIQ;
            public double dVoutIPNative;
            public double dVout0ANative;
            public double dVoutIPMiddle;
            public double dVout0AMiddle;
            public double dVoutIPTrimmed;
            public double dVout0ATrimmed;
            public bool bDigitalCommFail;
            public bool bNormalModeFail;
            public bool bReadMarginal;
            public bool bReadSafety;
            public bool bTrimmed;
        }

        #region Param Definition

        bool bUsbConnected = false;

        bool bAutoTrimTest = true;          //Debug mode, display engineer tab
        //bool bAutoTrimTest = false;       //Release mode, bon't display engineer tab
        //bool bPretrimOrAuto = false;        //For operator, only auto tab
        //bool bPretrimOrAuto = true;         //For engineer, only PreTrim tab
        uint uTabVisibleCode = 0;
        bool bMRE = false;
        bool bMASK = false;
        bool bSAFEREAD = false;

        uint DeviceAddress = 0x73;
        uint SampleRateNum = 1024;
        uint SampleRate = 1000;     //KHz
        string SerialNum = "None";

        /// <summary>
        /// Delay Define
        /// </summary>
        int Delay_Power = 100;      //ms
        int Delay_Operation =50;   //ms
        int Delay_Fuse = 400;       //ms
        int Delay_Sync = 50;        //ms

        double ADCOffset = 0;
        double AadcOffset
        {
            set
            {
                this.ADCOffset = Math.Round(value, 0);
                //Set three adcofset combobox on the GUI
                //this.txt_IP_EngT.Text = this.ip.ToString("F0");
                this.txt_AdcOffset_PreT.Text = this.ADCOffset.ToString("F0");
                this.txt_AdcOffset_AutoT.Text = this.ADCOffset.ToString("F0");
            }
            get { return this.ADCOffset; }
        }

        double VoutIPThreshold = 0.010;
        double ThresholdOfGain = 0.995;
        double RefVoltOffset = -0.007;
        double dCurrentUpLimit = 20;
        double dCurrentDownLimit = 8;

        double Vout_0A = 0;
        double Vout_IP = 0;
        double Mout_0A = 0;
        double Mout_IP = 0;
        double AMPout_0A = 0;
        double AMPout_IP = 0;
        double ip = 20;
        double IP
        {
            set
            {
                this.ip = Math.Round(value,0);
                //Set three ip combobox on the GUI
                this.txt_IP_EngT.Text = this.ip.ToString("F0");
                this.txt_IP_PreT.Text = this.ip.ToString("F0");
                this.txt_IP_AutoT.Text = this.ip.ToString("F0");
            }
            get { return this.ip; }
        }

        string StrIPx_Auto = "15A";
        double selectedCurrent_Auto = 20;   //A
        double targetGain_customer = 100;    //mV/A

        double targetOffset = 2.5;
        double TargetOffset
        {
            get { return this.targetOffset; }
            set 
            {
                this.targetOffset = value;
                //this.txt_VoutOffset_AutoT.Text = (string)this.cmb_Voffset_PreT.SelectedItem;

                if (this.targetOffset == 1.65)
                    saturationVout = 3.25;
                else
                    saturationVout = 4.9;

                //Update trim code table 
                FilledRoughTable_Customer();
                FilledPreciseTable_Customer();
            }
        }
        double saturationVout = 4.90;
        double bin2accuracy = 2;
        double bin3accuracy = 3;

        double targetVoltage_customer = 2;
        double TargetVoltage_customer
        {
            get { return this.targetVoltage_customer; }
            set
            {
                this.targetVoltage_customer = value;

                //Update GUI
                this.txt_targetvoltage_PreT.Text = this.targetVoltage_customer.ToString();
                //this.txt_TargetGain_PreT.Text = this.targetVoltage_customer.ToString();
                this.txt_TargertVoltage_AutoT.Text = this.targetVoltage_customer.ToString();
            }
        }

        double TargetGain_customer
        {
            get { return this.targetGain_customer; }
            set
            {
                this.targetGain_customer = value;

                //Update GUI
                this.txt_TargetGain_EngT.Text = this.targetGain_customer.ToString();
                this.txt_TargetGain_PreT.Text = this.targetGain_customer.ToString();
                this.txt_TargetGain_AutoT.Text = this.targetGain_customer.ToString();
            }
        }

        uint reg80Value = 0;
        uint Reg80Value
        {
            get { return this.reg80Value; }
            set
            {
                this.reg80Value = value;
                //Update GUI
                this.txt_reg80_EngT.Text = "0x" + this.reg80Value.ToString("X2");
                this.txt_Reg80_PreT.Text = "0x" + this.reg80Value.ToString("X2");
            }
        }

        uint reg81Value = 0;
        uint Reg81Value
        {
            get { return this.reg81Value; }
            set
            {
                this.reg81Value = value;
                //Update GUI
                this.txt_reg81_EngT.Text = "0x" + this.reg81Value.ToString("X2");
                this.txt_Reg81_PreT.Text = "0x" + this.reg81Value.ToString("X2");
            }
        }

        uint reg82Value = 0;
        uint Reg82Value
        {
            get { return this.reg82Value; }
            set
            {
                this.reg82Value = value;
                //Update GUI
                this.txt_reg82_EngT.Text = "0x" + this.reg82Value.ToString("X2");
                this.txt_Reg82_PreT.Text = "0x" + this.reg82Value.ToString("X2");
            }
        }

        uint reg83Value = 0;
        uint Reg83Value
        {
            get { return this.reg83Value; }
            set
            {
                this.reg83Value = value;
                //Update GUI
                this.txt_reg83_EngT.Text = "0x" + this.reg83Value.ToString("X2");
                this.txt_Reg83_PreT.Text = "0x" + this.reg83Value.ToString("X2");
            }
        }

        //uint Reg84Value = 0;

        //Just used for auto trim, will be updated when auto tirm tabe entering and loading config file
        uint[] Reg80ToReg83Backup = new uint[4];

        uint[] tempReadback = new uint[5];

        int moduleTypeindex = 0;
        int ModuleTypeIndex
        {
            set 
            {
                this.moduleTypeindex = value; 
                //Set both combobox on GUI
                this.cmb_Module_EngT.SelectedIndex = this.moduleTypeindex;
                this.cmb_Module_PreT.SelectedIndex = this.moduleTypeindex;
                this.txt_ModuleType_AutoT.Text = (string)this.cmb_Module_EngT.SelectedItem;

                //Set Voffset
                if (this.moduleTypeindex == 2)
                {
                    TargetOffset = 1.65;
                    //saturationVout = 3.25;
                }
                else if (this.moduleTypeindex == 1)
                {
                    TargetOffset = 2.5;
                    //saturationVout = 4.9;
                }
                else
                {
                    //TargetOffset = 2.5;
                    //saturationVout = 4.9;
                }

                //if (this.moduleTypeindex == 2)
                //{
                //    this.cmb_Voffset_PreT.SelectedItem = (object)(this.TargetOffset + "V");
                //    //this.cmb_Voffset_PreT.Enabled = false;
                //}
                //else if (this.moduleTypeindex == 1)
                //{
                //    this.cmb_Voffset_PreT.SelectedItem = (object)(this.TargetOffset + "V");
                //    //this.cmb_Voffset_PreT.Enabled = false;
                //}
                //else
                //{
                //    //this.cmb_Voffset_PreT.Enabled = true;
                //}
            }
            get { return this.moduleTypeindex; }
        }

        int socketType = 0;
        int SocketType
        {
            set
            {
                this.socketType = value;
                //Set combobox on GUI
                this.cmb_SocketType_AutoT.SelectedIndex = this.socketType;
                //this.cmb_Module_PreT.SelectedIndex = this.moduleTypeindex;
                //this.cmb_SocketType_AutoT.Text = (string)this.cmb_Module_EngT.SelectedItem;
            }
            get { return this.socketType; }
        }

        int programMode = 0;
        int ProgramMode
        {
            set
            {
                this.programMode = value;
                this.cmb_ProgramMode_AutoT.SelectedIndex = this.programMode;
            }
            get { return this.programMode; }
        }

        uint ix_forRoughGainCtrl = 15;
        uint Ix_ForRoughGainCtrlBackup = 15;
        uint Ix_ForRoughGainCtrl
        {
            get { return this.ix_forRoughGainCtrl; }
            set
            {
                this.ix_forRoughGainCtrl = value;
                this.txt_ChosenGain_AutoT.Text = RoughTable_Customer[0][ix_forRoughGainCtrl].ToString("F2");
                this.txt_ChosenGain_PreT.Text = RoughTable_Customer[0][ix_forRoughGainCtrl].ToString("F2");
            }
        }

        int ix_forPrecisonGainCtrl = 0;
        int Ix_ForPrecisonGainCtrl
        {
            get { return this.ix_forPrecisonGainCtrl; }
            set { this.ix_forPrecisonGainCtrl = value; }
        }

        int ix_forOffsetATable = 0;
        int Ix_ForOffsetATable
        {
            get { return this.ix_forOffsetATable; }
            set { this.ix_forOffsetATable = value; }
        }

        int ix_forOffsetBTable = 0;
        int Ix_ForOffsetBTable
        {
            get { return this.ix_forOffsetBTable; }
            set { this.ix_forOffsetBTable = value; }
        }

        double k_slope = 0.5;
        double b_offset = 0;

        double[][] RoughTable = new double[3][];        //3x16: 0x80,0x81,Rough
        double[][] PreciseTable = new double[2][];      //2x32: 0x80,Precise
        double[][] OffsetTableA = new double[3][];      //3x16: 0x81,0x82,OffsetA
        double[][] OffsetTableB = new double[2][];      //2x16: 0x83,OffsetB

        //Trim code for 2.5V offset
        double[][] RoughTable_Customer = new double[3][];        //3x16: Rough,0x80,0x81
        double[][] PreciseTable_Customer = new double[2][];      //2x32: 0x80,Precise
        double[][] OffsetTableA_Customer = new double[3][];      //3x16: 0x81,0x82,OffsetA
        double[][] OffsetTableB_Customer = new double[2][];      //2x16: 0x83,OffsetB

        //Gain trim code for 1.65V offset
        //double[][] RoughTable_1v65offset = new double[3][];        //3x16: Rough,0x80,0x81
        //double[][] PreciseTable_1v65offset = new double[2][];      //2x32: 0x80,Precise

        uint[] MultiSiteReg0 = new uint[16];
        uint[] MultiSiteReg1 = new uint[16];
        uint[] MultiSiteReg2 = new uint[16];
        uint[] MultiSiteReg3 = new uint[16];
        uint[] MultiSiteRoughGainCodeIndex = new uint[16];

        uint[] BrakeReg = new uint[5];                          //Brake usage
        int Ix_OffsetA_Brake = 0;
        int Ix_OffsetB_Brake = 0;
        int Ix_GainRough_Brake = 0;
        int Ix_GainPrecision_Brake = 0;

        enum PRGMRSULT{
            DUT_BIN_1 = 1,
            DUT_BIN_2 = 2,
            DUT_BIN_3 = 3,
            DUT_BIN_4 = 4,
            DUT_BIN_5 = 5,
            DUT_BIN_6 = 6,
            DUT_BIN_NORMAL = 21,
            DUT_BIN_MARGINAL = 22,
            DUT_CURRENT_ABNORMAL = 91,
            DUT_TRIMMED_ALREADY = 92,
            DUT_VOUT_SATURATION = 93,
            DUT_LOW_SENSITIVITY = 94,
            DUT_RESERVED_RESULT = 95
        }

        #region Bit Operation Mask
        readonly uint bit0_Mask = Convert.ToUInt32(Math.Pow(2, 0));
        readonly uint bit1_Mask = Convert.ToUInt32(Math.Pow(2, 1));
        readonly uint bit2_Mask = Convert.ToUInt32(Math.Pow(2, 2));
        readonly uint bit3_Mask = Convert.ToUInt32(Math.Pow(2, 3));
        readonly uint bit4_Mask = Convert.ToUInt32(Math.Pow(2, 4));
        readonly uint bit5_Mask = Convert.ToUInt32(Math.Pow(2, 5));
        readonly uint bit6_Mask = Convert.ToUInt32(Math.Pow(2, 6));
        readonly uint bit7_Mask = Convert.ToUInt32(Math.Pow(2, 7));

        uint bit_op_mask;
        #endregion Bit Mask

        #endregion

        #region Device Connection
        OneWireInterface oneWrie_device = new OneWireInterface();

        private int WM_DEVICECHANGE = 0x0219;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {
                ConnectDevice();
            }
        }

        private void ConnectDevice()
        {
            bool result = false;
            #region One wire
            if(!bUsbConnected)
                result = oneWrie_device.ConnectDevice();

            if (result)
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.YellowGreen;
                this.toolStripStatusLabel_Connection.Text = "Connected";
                btn_GetFW_OneWire_Click(null, null);
                bUsbConnected = true;
            }
            else
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.IndianRed;
                this.toolStripStatusLabel_Connection.Text = "Disconnected";
            }
            #endregion
        }
        #endregion Device Connection

        #region Device Setting
        private decimal pilotwidth_ow_value_backup = 80000;
        private void numUD_pilotwidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.numUD_pilotwidth_ow_EngT.Value = (decimal)((int)Math.Round((double)this.numUD_pilotwidth_ow_EngT.Value / 20d) * 20);
            if (this.numUD_pilotwidth_ow_EngT.Value % 20 == 0 & this.numUD_pilotwidth_ow_EngT.Value != pilotwidth_ow_value_backup)
            {
                this.pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow_EngT.Value;
                Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth((uint)this.numUD_pilotwidth_ow_EngT.Value));
            }
        }

        private void num_UD_pulsewidth_ow_ValueChanged(object sender, EventArgs e)
        {
            //this.num_UD_pulsewidth_ow_EngT.Value = (decimal)((int)Math.Round((double)this.num_UD_pulsewidth_ow_EngT.Value / 5d) * 5);
            //this.num_UD_pulsewidth_ow_EngT.Value = (double)this.num_UD_pulsewidth_ow_EngT.Value;
        }

        private void btn_fuse_action_ow_Click(object sender, EventArgs e)
        {
            //bool fuseMasterBit = false;
            

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config_EngT.Checked = true;

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITHOUT_CAP);
            //rbt_withCap_Vout.Checked = false;
            rbt_withoutCap_Vout_EngT.Checked = true;
            //rbt_signalPathSeting_Vout.Checked = false;

            //0x03->0x43
            uint _reg_addr = 0x43;
            uint _reg_data = 0x03;
            oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);

            //0xAA->0x44
            _reg_addr = 0x44;
            _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            
            //Console.WriteLine("Fuse write result->{0}", oneWrie_device.FuseClockSwitch((double)this.num_UD_pulsewidth_ow_EngT.Value, (double)this.numUD_pulsedurationtime_ow_EngT.Value));
        }

        private void btn_fuse_clock_ow_EngT_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Please Change Power To 6V", "Change Power", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            Console.WriteLine("Fuse write result->{0}", oneWrie_device.FuseClockSwitch((double)this.num_UD_pulsewidth_ow_EngT.Value, (double)this.numUD_pulsedurationtime_ow_EngT.Value));
        }

        private void btn_flash_onewire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Flash result->{0}", oneWrie_device.FlashLED());
        }

        private void btn_GetFW_OneWire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Enter Get FW Interface");
            byte[] info = oneWrie_device.GetFirmwareInfo();

            if (info == null)
                return;

            string fwVersion = "v" + info[1].ToString() + "." + info[0].ToString() + " ";

            char[] dataInfo = new char[12];
            Array.Copy(info, 8, dataInfo, 0, 12);

            char[] timeInfo = new char[8];
            Array.Copy(info, 20, timeInfo, 0, 8);

            SerialNum = ((info[29] << 8) + info[28]).ToString();

            string data = new string(dataInfo);
            string time = "Build @ " + new string(timeInfo);

            this.toolStripStatusLabel_FWInfo.Text = fwVersion + time + " " + data;
            //this.lbl_FW_onewire.Text = "FW Version:" + oneWrie_device.GetFWVersion();
        }

        #endregion Device Setting

        #region Methods

        private void UserInit()
        {
            //Connect device first.
            ConnectDevice();

            //Refresh pilot width
            //Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth(8000));
            numUD_pilotwidth_ow_ValueChanged(null, null);

            //Fill all the tables for internal tab
            FilledRoughTable();
            FilledPreciseTable();
            FilledOffsetTableA();
            FilledOffsetTableB();

            //Fill all the tables for customer tab
            FilledRoughTable_Customer();
            FilledPreciseTable_Customer();
            FilledOffsetTableA_Customer();
            FilledOffsetTableB_Customer();

            //FilledRoughTable_1v65offset();
            //FilledPreciseTable_1v65offse();

            //Init combobox
            //1. Engineering
            this.cmb_SensingDirection_EngT.SelectedIndex = 0;
            this.cmb_OffsetOption_EngT.SelectedIndex = 0;
            this.cmb_PolaritySelect_EngT.SelectedIndex = 0;
            this.cmb_Module_EngT.SelectedIndex = 0;
            //2. PreTrim
            this.cmb_SensitivityAdapt_PreT.SelectedIndex = 0;
            //this.cmb_TempCmp_PreT.SelectedIndex = 0;
            //-350ppm
            this.cmb_TempCmp_PreT.SelectedIndex = 1;

            this.cmb_IPRange_PreT.SelectedIndex = 1;
            this.cmb_Module_PreT.SelectedIndex = 0;
            this.cmb_Voffset_PreT.SelectedIndex = 0;
            this.cmb_SocketType_AutoT.SelectedIndex = 0;
            this.cmb_ProgramMode_AutoT.SelectedIndex = 0;

            //Serial Num
            this.txt_SerialNum_EngT.Text = SerialNum;
            this.txt_SerialNum_PreT.Text = SerialNum;

            //load config
            btn_loadconfig_AutoT_Click(null, null);

            this.tabControl1.Controls.Remove(BrakeTab);

            //Display Tab
            if (uTabVisibleCode == 1)
            {
                //this.tabControl1.Controls.Remove(AutoTrimTab);
                this.tabControl1.Controls.Remove(EngineeringTab);
                this.tabControl1.Controls.Remove(PriTrimTab);
                DisplayOperateMes("Load config profile success!");
            }
            else if (uTabVisibleCode == 2)
            {
                this.tabControl1.Controls.Remove(AutoTrimTab);
                this.tabControl1.Controls.Remove(EngineeringTab);
                DisplayOperateMes("Load config profile success!");
            }
            else if (uTabVisibleCode == 3)
            {
                //this.tabControl1.Controls.Remove(AutoTrimTab);
                this.tabControl1.Controls.Remove(EngineeringTab);
                DisplayOperateMes("Load config profile success!");
            }
            else if (uTabVisibleCode == 4)
            {
                DisplayOperateMes("Load config profile success!");
            }
            else
            {
                DisplayOperateMes("Invalid config profile!", Color.DarkRed);
                //MessageBox.Show("Invalid config profile!");
                MessageBox.Show("Invalid config profile!", "Change Current", MessageBoxButtons.OKCancel);
            }

            //DisplayOperateMes("AadcOffset = " + AadcOffset.ToString());
            DisplayOperateMes("MRE = "+ bMRE.ToString());
            DisplayOperateMes("MASK = " + bMASK .ToString());
            DisplayOperateMes("SAFETY = " + bSAFEREAD .ToString());
            DisplayOperateMes("<------- " + DateTime.Now.ToString() + " ------->");
        }

        private double AverageVout()
        {
            double result = oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, SampleRateNum));
            Delay(Delay_Operation/3);
            result += oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, SampleRateNum));
            Delay(Delay_Operation/3);
            result += oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, SampleRateNum));

            result /= 3d;

            result = RefVoltOffset - AadcOffset/1000d + (result * 5d / 4096d);
            return result;
        }

        private double AverageVout_Customer(uint sampleNum)
        {
            double result = oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, sampleNum));

            result = RefVoltOffset - AadcOffset/1000d + (result * 5d / 4096d);
            return result;
        }

        private double GetModuleCurrent()
        {
            double result = oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, SampleRateNum));

            result = 1000d * (RefVoltOffset + (result * 5d / 4096d)) / 100d;
            return result;
        }

        private void SaveMultiSiteRegData(uint indexDut)
        {
            MultiSiteReg0[indexDut] = Reg80Value;
            MultiSiteReg1[indexDut] = Reg81Value;
            MultiSiteReg2[indexDut] = Reg82Value;
            MultiSiteReg3[indexDut] = Reg83Value;
        }

        /// <summary>
        /// 根据采集的Vout@0A，Vout@IP计算出Gain
        /// </summary>
        /// <returns>计算出的Gain供查表用,单位mV/A</returns>
        private double GainCalculate()
        {
            double result = 0;

            result = 1000d * ((Vout_IP - Vout_0A) / IP);

            return result;
        }

        /// <summary>
        /// 根据采集的Vout@0A，Vout@IP计算出Gain
        /// </summary>
        /// <returns>计算出的Gain供查表用,单位mV/A</returns>
        private double GainCalculate(double v_0A, double v_ip)
        {
            return 1000d * ((v_ip - v_0A) / IP);
        }

        /// <summary>
        /// 根据第二次计算的IP0计算，公式：2.5/IP0
        /// </summary>
        /// <returns>计算出的Offset供查表用</returns>
        private double OffsetTuningCalc_Customer()
        {
            //return 2.5 / Vout_0A;
            return TargetOffset / Vout_0A;
        }

        private double GainTuningCalc_Customer(double testValue, double targetValue)
        {
            return targetValue / testValue;
        }

        private void FilledRoughTable()
        {
            for (int i = 0; i < RoughTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Rough
                        RoughTable[i] = new double[]{
                            -87.75,
                            -85.91,
                            -83.76,
                            -81.26,
                            -78.44,
                            -75.19,
                            -71.27,
                            -67.16,
                            -62.28,
                            -56.52,
                            -50.05,
                            -42.45,
                            -33.83,
                            -24.01,
                            -12.47,
                            0.00
                            };
                        break;
                    case 2: //0x81
                        RoughTable[i] = new double[]{
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0
                        };
                        break;
                    case 1: //0x80
                        RoughTable[i] = new double[]{
                        0xE0,
                        0xE0,
                        0x60,
                        0x60,
                        0xA0,
                        0xA0,
                        0x20,
                        0x20,
                        0xC0,
                        0xC0,
                        0x40,
                        0x40,
                        0x80,
                        0x80,
                        0x0,
                        0x0
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledPreciseTable()
        {
            for (int i = 0; i < PreciseTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Precise
                        PreciseTable[i] = new double[]{
                            0.00,
                            -0.45,
                            -0.90,
                            -1.35,
                            -1.80,
                            -2.25,
                            -2.69,
                            -3.14,
                            -3.59,
                            -4.04,
                            -4.49,
                            -4.94,
                            -5.38,
                            -5.83,
                            -6.28,
                            -6.73,
                            -7.18,
                            -7.63,
                            -8.08,
                            -8.52,
                            -8.97,
                            -9.42,
                            -9.87,
                            -10.32,
                            -10.77,
                            -11.21,
                            -11.66,
                            -12.11,
                            -12.56,
                            -13.01,
                            -13.46,
                            -13.90
                        };
                        break;
                    case 1: //0x80
                        PreciseTable[i] = new double[]{
                            0x0,
                            0x8,
                            0x4,
                            0xC,
                            0x2,
                            0xA,
                            0x6,
                            0xE,
                            0x1,
                            0x9,
                            0x5,
                            0xD,
                            0x3,
                            0xB,
                            0x7,
                            0xF,
                            0x10,
                            0x18,
                            0x14,
                            0x1C,
                            0x12,
                            0x1A,
                            0x16,
                            0x1E,
                            0x11,
                            0x19,
                            0x15,
                            0x1D,
                            0x13,
                            0x1B,
                            0x17,
                            0x1F        
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableA()
        {
            for (int i = 0; i < OffsetTableA.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableA[i] = new double[]{
                            0,
                            -1.08,
                            -2.160,
                            -3.240,
                            -4.320,
                            -5.400,
                            -6.480,
                            -7.560,
                            8.28,
                            7.2450,
                            6.2100,
                            5.1750,
                            4.1400,
                            3.1050,
                            2.0700,
                            1.0350
                            };
                        break;
                    case 1: //0x81
                        OffsetTableA[i] = new double[]{
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80    
                        };
                        break;
                    case 2: //0x82
                        OffsetTableA[i] = new double[]{
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7,
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7   
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableB()
        {
            for (int i = 0; i < OffsetTableB.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableB[i] = new double[]{
                            0,
                            -0.29,
                            -0.58,
                            -0.87,
                            -1.16,
                            -1.45,
                            -1.74,
                            -2.03,
                            2.32,
                            2.03,
                            1.74,
                            1.45,
                            1.16,
                            0.87,
                            0.58,
                            0.29   
                        };
                        break;
                    case 1: //0x83
                        OffsetTableB[i] = new double[]{
                            0x0,
                            0x20,
                            0x10,
                            0x30,
                            0x8,
                            0x28,
                            0x18,
                            0x38,
                            0x4,
                            0x24,
                            0x14,
                            0x34,
                            0xC,
                            0x2C,
                            0x1C,
                            0x3C  
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledRoughTable_Customer()
        {
            if (TargetOffset == 2.5)
            {
                for (int i = 0; i < RoughTable.Length; i++)
                {
                    switch (i)
                    {
                        case 0: //Rough
                            RoughTable_Customer[i] = new double[]{
                                12.36,
                                14.13,
                                16.26,
                                18.73,
                                21.52,
                                24.74,
                                28.64,
                                32.74,
                                37.76,
                                43.51,
                                49.97,
                                57.56,
                                66.19,
                                76.00,
                                87.54,
                                100.00
                            };
                            break;
                        case 2: //0x81
                            RoughTable_Customer[i] = new double[]{
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0
                            };
                            break;
                        case 1: //0x80
                            RoughTable_Customer[i] = new double[]{
                            0xE0,
                            0xE0,
                            0x60,
                            0x60,
                            0xA0,
                            0xA0,
                            0x20,
                            0x20,
                            0xC0,
                            0xC0,
                            0x40,
                            0x40,
                            0x80,
                            0x80,
                            0x0,
                            0x0
                            };
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (TargetOffset == 1.65)
            {
                for (int i = 0; i < RoughTable.Length; i++)
                {
                    switch (i)
                    {
                        case 0: //Rough
                            RoughTable_Customer[i] = new double[]{
                                12.5545,
                                14.4698,
                                16.6670,
                                19.1870,
                                22.0822,
                                25.4006,
                                29.1830,
                                33.5584,
                                38.7607,
                                44.6210,
                                51.2550,
                                58.9272,
                                67.5783,
                                77.3808,
                                88.4811,
                                100.0000

                            };
                            break;
                        case 2: //0x81
                            RoughTable_Customer[i] = new double[]{
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0,
                                1,
                                0
                            };
                            break;
                        case 1: //0x80
                            RoughTable_Customer[i] = new double[]{
                            0xE0,
                            0xE0,
                            0x60,
                            0x60,
                            0xA0,
                            0xA0,
                            0x20,
                            0x20,
                            0xC0,
                            0xC0,
                            0x40,
                            0x40,
                            0x80,
                            0x80,
                            0x0,
                            0x0
                            };
                            break;
                        default:
                            break;
                    }
                }
            }
            else
                DisplayOperateMes("Offset Selection Error!",Color.DarkRed);
        }

        private void FilledPreciseTable_Customer()
        {
            if (TargetOffset == 2.5)
            {
                for (int i = 0; i < PreciseTable.Length; i++)
                {
                    switch (i)
                    {
                        case 0: //Precise
                            PreciseTable_Customer[i] = new double[]{
                            100.00,
                            99.51,
                            99.09,
                            98.64,
                            98.19,
                            97.73,
                            97.22,
                            96.79,
                            96.33,
                            95.91,
                            95.48,
                            95.00,
                            94.59,
                            94.22,
                            93.69,
                            93.25,
                            92.83,
                            92.38,
                            91.90,
                            91.50,
                            91.03,
                            90.55,
                            90.09,
                            89.66,
                            89.21,
                            88.76,
                            88.29,
                            87.85,
                            87.40,
                            86.96,
                            86.49,
                            86.07
                        };
                            break;
                        case 1: //0x80
                            PreciseTable_Customer[i] = new double[]{
                            0x0,
                            0x8,
                            0x4,
                            0xC,
                            0x2,
                            0xA,
                            0x6,
                            0xE,
                            0x1,
                            0x9,
                            0x5,
                            0xD,
                            0x3,
                            0xB,
                            0x7,
                            0xF,
                            0x10,
                            0x18,
                            0x14,
                            0x1C,
                            0x12,
                            0x1A,
                            0x16,
                            0x1E,
                            0x11,
                            0x19,
                            0x15,
                            0x1D,
                            0x13,
                            0x1B,
                            0x17,
                            0x1F        
                        };
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (TargetOffset == 1.65)
            {
                for (int i = 0; i < PreciseTable.Length; i++)
                {
                    switch (i)
                    {
                        case 0: //Precise
                            PreciseTable_Customer[i] = new double[]{
                            100.0000,
                            99.5621,
                            99.0883,
                            98.6571,
                            98.2420,
                            97.8018,
                            97.3733,
                            96.9106,
                            96.5204,
                            96.0668,
                            95.6047,
                            95.1692,
                            94.7649,
                            94.3190,
                            93.8573,
                            93.4373,
                            93.0262,
                            92.5910,
                            92.1260,
                            91.7141,
                            91.2899,
                            90.8342,
                            90.4010,
                            89.9252,
                            89.4676,
                            89.0324,
                            88.5949,
                            88.1567,
                            87.6997,
                            87.2675,
                            86.8323,
                            86.3821

                        };
                            break;
                        case 1: //0x80
                            PreciseTable_Customer[i] = new double[]{
                            0x0,
                            0x8,
                            0x4,
                            0xC,
                            0x2,
                            0xA,
                            0x6,
                            0xE,
                            0x1,
                            0x9,
                            0x5,
                            0xD,
                            0x3,
                            0xB,
                            0x7,
                            0xF,
                            0x10,
                            0x18,
                            0x14,
                            0x1C,
                            0x12,
                            0x1A,
                            0x16,
                            0x1E,
                            0x11,
                            0x19,
                            0x15,
                            0x1D,
                            0x13,
                            0x1B,
                            0x17,
                            0x1F       
                        };
                            break;
                        default:
                            break;
                    }
                }
            }
            else
                DisplayOperateMes("Offset Selection Error!", Color.DarkRed);
        }

        private void FilledOffsetTableA_Customer()
        {
            for (int i = 0; i < OffsetTableA_Customer.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableA_Customer[i] = new double[]{
                            100.00,
                            98.94,
                            97.87,
                            96.78,
                            95.68,
                            94.60,
                            93.50,
                            92.39,
                            108.27,
                            107.27,
                            106.26,
                            105.23,
                            104.20,
                            103.16,
                            102.12,
                            101.07
                        };
                        break;
                    case 1: //0x81
                        OffsetTableA_Customer[i] = new double[]{
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80    
                        };
                        break;
                    case 2: //0x82
                        OffsetTableA_Customer[i] = new double[]{
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7,
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7   
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableB_Customer()
        {
            for (int i = 0; i < OffsetTableB_Customer.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableB_Customer[i] = new double[]{
                            100.00,
                            99.72,
                            99.43,
                            99.14,
                            98.85,
                            98.56,
                            98.28,
                            98.00,
                            102.39,
                            102.10,
                            101.80,
                            101.48,
                            101.19,
                            100.89,
                            100.60,
                            100.31
                        };
                        break;
                    case 1: //0x83
                        OffsetTableB_Customer[i] = new double[]{
                            0x0,
                            0x20,
                            0x10,
                            0x30,
                            0x8,
                            0x28,
                            0x18,
                            0x38,
                            0x4,
                            0x24,
                            0x14,
                            0x34,
                            0xC,
                            0x2C,
                            0x1C,
                            0x3C  
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        //private void FilledRoughTable_1v65offset()
        //{
        //    for (int i = 0; i < RoughTable.Length; i++)
        //    {
        //        switch (i)
        //        {
        //            case 0: //Rough
        //                RoughTable_Customer[i] = new double[]{
        //                    12.216,
        //                    13.862,
        //                    16.147,
        //                    18.348,
        //                    21.401,
        //                    24.653,
        //                    29.975,
        //                    34.020,
        //                    38.312,
        //                    44.412,
        //                    52.052,
        //                    59.549,
        //                    68.440,
        //                    77.870,
        //                    88.259,
        //                    100.000

        //                };
        //                break;
        //            case 2: //0x81
        //                RoughTable_Customer[i] = new double[]{
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0,
        //                    1,
        //                    0
        //                };
        //                break;
        //            case 1: //0x80
        //                RoughTable_Customer[i] = new double[]{
        //                0xE0,
        //                0xE0,
        //                0x60,
        //                0x60,
        //                0xA0,
        //                0xA0,
        //                0x20,
        //                0x20,
        //                0xC0,
        //                0xC0,
        //                0x40,
        //                0x40,
        //                0x80,
        //                0x80,
        //                0x0,
        //                0x0
        //                };
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        
        //}

        //private void FilledPreciseTable_1v65offse()
        //{
        //    for (int i = 0; i < PreciseTable.Length; i++)
        //    {
        //        switch (i)
        //        {
        //            case 0: //Precise
        //                PreciseTable_Customer[i] = new double[]{
        //                    100,
        //                    100.9133872,
        //                    100.6252553,
        //                    98.38610861,
        //                    97.60862141,
        //                    96.76134507,
        //                    96.72656851,
        //                    96.58239657,
        //                    95.42803881,
        //                    95.39503088,
        //                    94.97995235,
        //                    93.9553052,
        //                    93.75533338,
        //                    93.14090708,
        //                    92.67175348,
        //                    92.1915706,
        //                    91.78149903,
        //                    91.73470358,
        //                    91.59799441,
        //                    91.51023103,
        //                    90.70553856,
        //                    90.51250858,
        //                    90.15082225,
        //                    90.03869214,
        //                    89.96089341,
        //                    89.84972078,
        //                    89.7525681,
        //                    89.3287556,
        //                    88.18534057,
        //                    87.14040232,
        //                    86.86542726,
        //                    85.50573369

        //                };
        //                break;
        //            case 1: //0x80
        //                PreciseTable_Customer[i] = new double[]{
        //                    0x0,
        //                    0x8,
        //                    0x4,
        //                    0x2,
        //                    0x1,
        //                    0xC,
        //                    0xE,
        //                    0x9,
        //                    0x5,
        //                    0x3,
        //                    0x6,
        //                    0xA,
        //                    0xB,
        //                    0x13,
        //                    0x18,
        //                    0x1D,
        //                    0xD ,
        //                    0x15,
        //                    0x1B,
        //                    0x10,
        //                    0x19,
        //                    0x12,
        //                    0x16,
        //                    0x1A,
        //                    0x14,
        //                    0x11,
        //                    0x1C,
        //                    0x17,
        //                    0x7,
        //                    0x1F,
        //                    0x1E,
        //                    0xF
        
        //                };
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        //Abs(Value) decreased table

        private int LookupRoughGain(double tuningGain, double[][] gainTable)
        {
            if (tuningGain.ToString() == "Infinity")
            {
                return gainTable[0].Length - 1;
            }

            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) >= 0)
                    return i;
            }
            return gainTable[0].Length - 1;
        }

        //Abs(Value) increased table
        private int LookupPreciseGain(double tuningGain, double[][] gainTable)
        {
            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) >= 0)
                {
                    if ((i > 0) && (i < gainTable[0].Length - 1))
                    {
                        if (Math.Abs(temp - Math.Abs(gainTable[0][i - 1])) <= Math.Abs(temp - Math.Abs(gainTable[0][i])))
                            return (i - 1);
                        else
                            return i;
                    }
                }
            }
            return 0;
        }

        private int LookupOffset(ref double offset, double[][] offsetTable)
        {
            double temp = offset - offsetTable[0][0];
            int ix = 0;
            for (int i = 1; i < offsetTable[0].Length; i++)
            {
                if (Math.Abs(temp) > Math.Abs(offset - offsetTable[0][i]))
                {
                    temp = offset - offsetTable[0][i];
                    ix = i;
                }
            }
            //offset = temp;
            offset = 100 * offset / offsetTable[0][ix];
            return ix;
        }

        private int LookupOffsetIndex(uint regData, double[][] offsetTable)
        {
            for (int i = 0; i < offsetTable[0].Length; i++)
            {
                if (regData == offsetTable[1][i])
                    return i;
            }

            return 0;
        }

        //Abs(Value) increased table
        private int LookupRoughGain_Customer(double tuningGain, double[][] gainTable)
        {
            if (tuningGain.ToString() == "Infinity")
            {
                return gainTable[0].Length - 1;
            }

            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) <= 0)
                    return i;
            }
            return gainTable[0].Length - 1;
        }

        //Abs(Value) decreased table
        private int LookupPreciseGain_Customer(double tuningGain, double[][] gainTable)
        {
            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) >= 0)
                {
                    if ((i > 0) && (i < gainTable[0].Length - 1))
                    {
                        if (Math.Abs(temp - Math.Abs(gainTable[0][i - 1])) <= Math.Abs(temp - Math.Abs(gainTable[0][i])))
                            return (i - 1);
                        else
                            return i;
                    }
                }
            }
            return 0;
        }

        private int LookupOffset_Customer(ref double offset, double[][] offsetTable)
        {
            //Offset = 2.5/IP0_Auto
            double temp = offset - offsetTable[0][0];
            int ix = 0;
            for (int i = 1; i < offsetTable[0].Length; i++)
            {
                if (Math.Abs(temp) > Math.Abs(offset - offsetTable[0][i]))
                {
                    temp = offset - offsetTable[0][i];
                    ix = i;
                }
            }

            offset = 100 * offset / offsetTable[0][ix];  //Return (2.5/IP0_Auto)/offsetTable[ix] which will used for next lookup table operation
            return ix;
        }

        public void DisplayOperateMes(string strError, Color fontColor)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputLogInfo.Text.Length;
            txt_OutputLogInfo.AppendText(strError + "\r\n");
            //txt_OutputLogInfo.ForeColor = Color.Chartreuse;
            txt_OutputLogInfo.Select(beginIndex, length);
            txt_OutputLogInfo.SelectionColor = fontColor;
            txt_OutputLogInfo.Select(txt_OutputLogInfo.Text.Length, 0);//.SelectedText = "";
            txt_OutputLogInfo.ScrollToCaret();
            txt_OutputLogInfo.Refresh();
        }

        public void DisplayOperateMes(string strError)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputLogInfo.Text.Length;
            txt_OutputLogInfo.AppendText(strError + "\r\n");
            //txt_OutputLogInfo.ForeColor = Color.Chartreuse;
            txt_OutputLogInfo.Select(beginIndex, length);
            //txt_OutputLogInfo.SelectionColor = fontColor;
            txt_OutputLogInfo.Select(txt_OutputLogInfo.Text.Length, 0);//.SelectedText = "";
            txt_OutputLogInfo.ScrollToCaret();
            txt_OutputLogInfo.Refresh();
        }

        public void DisplayOperateMesClear( )
        {
            txt_OutputLogInfo.Clear();
        }

        private void DisplayAutoTrimOperateMes(string strMes, bool ifSucceeded, int step)
        {
            if (bAutoTrimTest)
            {
                if (step == 0)
                {
                    if (ifSucceeded)
                        DisplayOperateMes("-------------------Automatica Trim Start(Debug Mode)-------------------\r\n");
                    else
                        DisplayOperateMes("-------------------Automatica Trim Finished(Debug Mode)-------------------\r\n");

                    return;
                }

                //DisplayOperateMes("Step " + step + ":");
                strMes = "Step" + step.ToString() + ":" + strMes;
                if (ifSucceeded)
                {
                    strMes += " succeeded!";
                    DisplayOperateMes(strMes);
                }
                else
                {
                    strMes += " Failed!";
                    DisplayOperateMes(strMes, Color.Red);
                }
            }
        }

        private void DisplayAutoTrimOperateMes(string strMes, bool ifSucceeded)
        {
            if (bAutoTrimTest)
            {
                //DisplayOperateMes("Step " + step + ":");
                if (ifSucceeded)
                {
                    strMes += " succeeded!";
                    DisplayOperateMes(strMes);
                }
                else
                {
                    strMes += " Failed!";
                    DisplayOperateMes(strMes, Color.Red);
                }
            }
        }

        private void DisplayAutoTrimOperateMes(string strMes, int step)
        {
            if (bAutoTrimTest)
            {
                strMes = "Step" + step.ToString() + ":" + strMes;
                DisplayOperateMes(strMes);
            }
        }

        private void DisplayAutoTrimOperateMes(string strMes)
        {
            if (bAutoTrimTest)
            {
                DisplayOperateMes(strMes);
            }
        }

        private void DisplayAutoTrimResult(bool ifPass)
        {
            if (ifPass)
            {
                this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                this.lbl_passOrFailed.Text = "PASS!";
            }
            else
            {
                this.lbl_passOrFailed.ForeColor = Color.Red;
                this.lbl_passOrFailed.Text = "FAIL!";
            }
        }

        private void DisplayAutoTrimResult( UInt16 errorCode)
        {
            switch ( errorCode & 0x000F )
            {
                case 0x0000:
                    this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                    this.lbl_passOrFailed.Text = "PASS!";
                    break;

                case 0x0001:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "S.N.E";
                    break;

                case 0x0002:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.R.E";
                    break;

                case 0x0003:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "O.P.E";
                    break;

                case 0x0004:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.T.E";
                    break;

                case 0x0005:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                    break;

                default:
                    break;

            
            }
        }

        private void DisplayAutoTrimResult(bool ifPass, UInt16 errorCode,string strResult)
        {
            if (ifPass)
            {
                this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                this.lbl_passOrFailed.Text = "PASS!";

                autoTrimResultIndicator.Clear();
                autoTrimResultIndicator.AppendText( "PASS!\t\t" + strResult);
                autoTrimResultIndicator.Refresh();

            }
            else
            {
                switch (errorCode & 0x000F)
                {
                    case 0x0001:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "S.N.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Sentisivity NOT Enough!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0002:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "M.R.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Marginal Read Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0003:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "O.P.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Output Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0004:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "M.T.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Master Bits Trim Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0005:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "H.W.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("No Hardware!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0006:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "I2C.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("I2C Comunication Error\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0007:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "O.P.C";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Operation Canceled!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0008:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "T.M.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Trim Master Bits Again!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x000F:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "FAIL!";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("FAIL!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    default:
                        break;


                }           
            }
        }

        private void DisplayLogInfo(string strError, Color fontColor)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputLogInfo.Text.Length;
            txt_OutputLogInfo.AppendText(strError + "\r\n");
            txt_OutputLogInfo.Select(beginIndex, length);
            txt_OutputLogInfo.SelectionColor = fontColor;
            txt_OutputLogInfo.Select(txt_OutputLogInfo.Text.Length, 0);//.SelectedText = "";
            txt_OutputLogInfo.ScrollToCaret();
            txt_OutputLogInfo.Refresh();
        }

        private void DisplayLogInfo(string strError)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputLogInfo.Text.Length;
            txt_OutputLogInfo.AppendText(strError + "\r\n");
            txt_OutputLogInfo.Select(beginIndex, length);
            txt_OutputLogInfo.Select(txt_OutputLogInfo.Text.Length, 0);//.SelectedText = "";
            txt_OutputLogInfo.ScrollToCaret();
            txt_OutputLogInfo.Refresh();
        }

        private void MultiSiteDisplayResult(uint[] uResult)
        {
            //bool FF = false;
            autoTrimResultIndicator.Clear();
            autoTrimResultIndicator.SelectionColor = Color.Black;
            autoTrimResultIndicator.AppendText("\r\n");
            autoTrimResultIndicator.AppendText("--00--\t--01--\t--02--\t--03--\t--04--\t--05--\t--06--\t--07--\t--08--\t--09--\t--10--\t--11--\t--12--\t--13--\t--14--\t--15--\r\n\r\n");
            for (uint idut = 0; idut < 16; idut++)
            {
                if ( uResult[idut] < 4 && uResult[idut] >0 )
                {
                    autoTrimResultIndicator.SelectionColor = Color.Green;
                    autoTrimResultIndicator.AppendText("PASS\t");
                }
                else if (uResult[idut] < 7 && uResult[idut] > 3 )
                {
                    if (bMRE)
                    {
                        autoTrimResultIndicator.SelectionColor = Color.Green;
                        autoTrimResultIndicator.AppendText("MRE!\t");
                    }
                    else
                    {
                        autoTrimResultIndicator.SelectionColor = Color.Green;
                        autoTrimResultIndicator.AppendText("PASS\t");
                    }
                }
                else
                {
                    autoTrimResultIndicator.SelectionColor = Color.Red;
                    autoTrimResultIndicator.AppendText("**" + uResult[idut].ToString() + "**\t");
                }
            }
        }

        private void MultiSiteDisplayVout(double[] uResult)
        {
            //bool FF = false;
            autoTrimResultIndicator.Clear();
            autoTrimResultIndicator.SelectionColor = Color.Black;
            autoTrimResultIndicator.AppendText("\r\n");
            autoTrimResultIndicator.AppendText("--00--\t--01--\t--02--\t--03--\t--04--\t--05--\t--06--\t--07--\t--08--\t--09--\t--10--\t--11--\t--12--\t--13--\t--14--\t--15--\r\n\r\n");
            for (uint idut = 0; idut < 16; idut++)
            {
                autoTrimResultIndicator.SelectionColor = Color.Green;
                autoTrimResultIndicator.AppendText( uResult[idut].ToString("F3") + "\t");             
            }
        }

        private void MultiSiteSocketSelect(UInt32 uDut)
        {
            Delay(Delay_Sync);
            if( uDut < 8)
                oneWrie_device.SDPSignalPathGroupSel(OneWireInterface.SPControlCommand.SP_MULTISITTE_GROUP_A);
            else
                oneWrie_device.SDPSignalPathGroupSel(OneWireInterface.SPControlCommand.SP_MULTISITTE_GROUP_B);

            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSocketSel(uDut);
        }

        private string CreateSingleLogInfo(int index)
        {
            return string.Format("{0}\t{1}\t", "DUT" + index, DateTime.Now.ToString());
        }

        private uint[] ReadBackReg1ToReg4(uint DevAddr)
        {
            uint _dev_addr = DevAddr;

            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            //Read Back 0x80~0x84
            uint _reg_addr_start = 0x80;
            uint[] _readBack_data = new uint[4];

            if (oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr_start, 4, _readBack_data) != 0)
            {
                DisplayAutoTrimOperateMes("Burst Read Back failed!");
                return null;
            }
            else
            {
                DisplayAutoTrimOperateMes("Reg1 = 0x" + _readBack_data[0].ToString("X") +
                    "\r\nReg2 = 0x" + _readBack_data[1].ToString("X") +
                    "\r\nReg3 = 0x" + _readBack_data[2].ToString("X") +
                    "\r\nReg4 = 0x" + _readBack_data[3].ToString("X"));
            }

            return _readBack_data;
        }

        private uint[] ReadBackReg1ToReg5(uint DevAddr)
        {
            uint _dev_addr = DevAddr;

            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            //Read Back 0x80~0x85
            uint _reg_addr_start = 0x80;
            uint[] _readBack_data = new uint[5];

            if (oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr_start, 5, _readBack_data) != 0)
            {
                DisplayAutoTrimOperateMes("Burst Read Back failed!");
                return null;
            }
            else
            {
                DisplayAutoTrimOperateMes("Reg1 = 0x" + _readBack_data[0].ToString("X") +
                    "\r\nReg2 = 0x" + _readBack_data[1].ToString("X") +
                    "\r\nReg3 = 0x" + _readBack_data[2].ToString("X") +
                    "\r\nReg4 = 0x" + _readBack_data[3].ToString("X") +
                    "\r\nReg5 = 0x" + _readBack_data[4].ToString("X"));
            }

            return _readBack_data;
        }

        private bool CheckReg1ToReg4(uint[] readBackData, uint Reg1, uint Reg2, uint Reg3, uint Reg4)
        {
            if (readBackData == null)
                return false;

            if ((readBackData[0] >= Reg1) &&
                (readBackData[1] >= Reg2) &&
                (readBackData[2] >= Reg3) &&
                (readBackData[3] >= Reg4))
                return true;
            else if((readBackData[0] == Reg1) &&
                    (readBackData[1] == Reg2) &&
                    (readBackData[2] == Reg3) &&
                    (readBackData[3] == Reg4))
                return true;
            else
                return false;
        }

        private bool MarginalCheckReg1ToReg4(uint[] readBackData, uint _dev_addr, double testGain_Auto)
        {
            if (readBackData == null)
                return false;

            #region Setup Marginal Read
            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            _reg_addr = 0x43;
            _reg_data = 0x0E;

            bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
            if (writeResult)
                DisplayOperateMes("Marginal Read succeeded!");
            else
                DisplayOperateMes("I2C write failed, Marginal Read Failed!", Color.Red);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayOperateMes("Delay 50ms");

            _reg_addr = 0x43;
            _reg_data = 0x0;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
            //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            if (writeResult)
                DisplayOperateMes("Reset Reg0x43 succeeded!");
            else
                DisplayOperateMes("Reset Reg0x43 failed!", Color.Red);
            #endregion Setup Marginal Read

            uint[] _MarginalreadBack_data = new uint[4];
            _MarginalreadBack_data = ReadBackReg1ToReg4(_dev_addr);

            if ((readBackData[0] == _MarginalreadBack_data[0]) &&
                (readBackData[1] == _MarginalreadBack_data[1]) &&
                (readBackData[2] == _MarginalreadBack_data[2]) &&
                (readBackData[3] == _MarginalreadBack_data[3]))
                return true;
            else
            {
                //if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x20) == 0x20 )
                //{
                //    return false;
                //}
                //else if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x40) == 0x40 && (readBackData[0] & 0x20) == 0x20 )
                //{
                //    return false;
                //}
                //else if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x80) == 0x80 && (readBackData[0] & 0x40) == 0x40 && (readBackData[0] & 0x20) == 0x20)
                //{
                //    return false;
                //}
                //else if (((readBackData[1] ^ _MarginalreadBack_data[1]) & 0x80)==0x80 || ((readBackData[2] ^ _MarginalreadBack_data[2]) & 0x01 )== 0x01 )
                //{
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
                return false;
            }
        }

        private bool FuseClockOn(uint _dev_addr, double fusePulseWidth, double fuseDurationTime)
        {
            //0x03->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x03;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
            {
                if (bAutoTrimTest)
                {
                    DisplayAutoTrimOperateMes("I2C Write 1 before Fuse Clock", true);
                }
            }
            else
            {
                return false;
            }

            //Delay(Delay_Operation);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
            {
                if (bAutoTrimTest)
                {
                    DisplayAutoTrimOperateMes("I2C Write 2 before Fuse Clock", true);
                }
            }
            else
            {
                return false; ;
            }

            Delay(Delay_Power);

            //Fuse 
            if (oneWrie_device.FuseClockSwitch(fusePulseWidth, fuseDurationTime))
            {
                if (bAutoTrimTest)
                {
                    DisplayAutoTrimOperateMes("Fuse Clock On", true);
                }
            }
            else
            {
                return false;
            }

            Delay(Delay_Operation);
            return true;
        }

        private bool FuseClockOn(uint _dev_addr, double fusePulseWidth, double fuseDurationTime, int delayTime , int step)
        {
            //0x03->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x03;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 1 before Fuse Clock", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 2 before Fuse Clock", true, step);
            else
            {
                return false; ;
            }

            //Delay 50ms
            Thread.Sleep(delayTime);
            DisplayAutoTrimOperateMes("Delay x00ms", step);

            //Fuse 
            if (oneWrie_device.FuseClockSwitch(fusePulseWidth, fuseDurationTime))
                DisplayAutoTrimOperateMes("Fuse Clock On", true, step);
            else
            {
                return false;
            }

            //Delay 700ms -> changed to 100ms @ 2014-09-04
            Thread.Sleep(100);
            DisplayAutoTrimOperateMes("Delay 100ms", step);
            return true;
        }

        private bool WriteBlankFuseCode(uint _dev_addr, uint _reg1Addr, uint _reg2Addr, uint _reg3Addr, int step)
        {
            uint _reg_Value = 00;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg1Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.1"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg2Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.2"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg3Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.3"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            return true;
        }

        private bool WriteMasterBit(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x07;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool WriteMasterBit0(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x01;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool WriteMasterBit1(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x02;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool ResetReg43And44(uint _dev_addr, int step)
        {
            //0x00->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Reset Reg0x43 before new bit Fuse", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Reset Reg0x44 before new bit Fuse", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);
            return true;
        }

        private void EnterNomalMode()
        {
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITHOUT_CAP);
            //rbt_signalPathSeting_Config_EngT.Checked = true;
            //Thread.Sleep(100);
            Delay(Delay_Sync);

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            //rbt_signalPathSeting_Config_EngT.Checked = true;
            //Thread.Sleep(100);
            Delay(Delay_Sync);

            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);

            Delay(Delay_Sync);

            _reg_addr = 0x42;
            _reg_data = 0x04;

            bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Enter Nomal Mode succeeded!");
                }
            }
            else
                DisplayOperateMes("I2C write failed, Enter Normal Mode Failed!", Color.Red);

            //Thread.Sleep(100);
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);

            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            //rbt_signalPathSeting_AIn_EngT.Checked = true;

            //Delay(Delay_Sync);
            //rbt_withCap_Vout_EngT.Checked = true;
        }

        private void EnterTestMode()
        {
            Delay(Delay_Sync);
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);
            Delay(Delay_Sync);

            //set CONFIG without cap
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITHOUT_CAP);
            Delay(Delay_Sync);
            //set CONFIG to VOUT
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            Delay(Delay_Sync);
            //Enter test mode
            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            if (oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data))
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Enter test mode succeeded!");
                }
            }
            else
                DisplayOperateMes("Enter test mode failed!");
        }

        private bool RegisterWrite(int wrNum, uint[] data)
        {
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITHOUT_CAP);
            //rbt_signalPathSeting_Config_EngT.Checked = true;
            Delay(Delay_Sync);
            oneWrie_device.I2CWrite_Single(this.DeviceAddress, 0x55, 0xAA);

            bool rt = false;
            if (data.Length < wrNum * 2)
                return false;

            if (bAutoTrimTest)
                DisplayOperateMes("Write In Data is:");

            for (int ix = 0; ix < wrNum; ix++)
            {
                rt = oneWrie_device.I2CWrite_Single(this.DeviceAddress, data[ix * 2], data[ix * 2 + 1]);
            }

            return rt;
        }

        private double CalcTargetXFromDetectiveY(double y)
        {
            /* y = k*x + b -> x = (y - b) / k */
            return (y - b_offset) / k_slope;
        }

        /// <summary>
        /// Use Y = kX +b to calculate the real vout X, and modify the index of precison table to
        /// find the best gain code. 
        /// ** Enter Current is 0A.
        /// ** Exit Current is also 0A.
        /// </summary>
        /// <returns></returns>
        private bool GainCodeCalcWithLoop()
        {
            double vout_0A_Convert;
            double vout_IP_Convert;
            double target_Gain1 = 0; //new
            double target_Gain2 = 0; //older
            bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask | bit3_Mask | bit4_Mask;
            /* 1. Write Reg0x80 and enter normal mode */
            EnterTestMode();
            RegisterWrite(1, new uint[2] { 0x80, Reg80Value });
            EnterNomalMode();

            /* 2.Get Vout@0A and Vout@IP */
            Vout_0A = AverageVout();
            DialogResult dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                return false;
            }
            Vout_IP = AverageVout();

            vout_0A_Convert = CalcTargetXFromDetectiveY(Vout_0A);
            vout_IP_Convert = CalcTargetXFromDetectiveY(Vout_IP);
            target_Gain1 = GainCalculate(vout_0A_Convert, vout_IP_Convert);
            target_Gain2 = target_Gain1;

            if (target_Gain1 == TargetGain_customer)
            {
                /* make sure exit current is 0A */
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", 0), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    return false;
                }
                return true;
            }

            // if (testGain > targetGain) then index++
            bool IncreaseOrDecrease = (target_Gain1 > TargetGain_customer) ? true : false;

            while (true)
            {
                /* get the right value, will record the Ix_ForPrecisonGainCtrl and break loop */
                if ((target_Gain1 - TargetGain_customer) * (target_Gain2 - TargetGain_customer) <= 0)
                {
                    /* Judge which target gain is the best */
                    if (Math.Abs(target_Gain1 - TargetGain_customer) <= Math.Abs(target_Gain2 - TargetGain_customer)) //The new value is needed
                    {
                        break;
                    }
                    else // Back to older gain
                    {
                        /* Increase/decrease the Ix_ForPrecisonGainCtrl; update reg80; Get Vaout*/
                        if (!IncreaseOrDecrease)
                        {
                            if (Ix_ForPrecisonGainCtrl < 15)
                                Ix_ForPrecisonGainCtrl++;
                            else
                                break;
                        }
                        else
                        {
                            if (Ix_ForPrecisonGainCtrl > 0)
                                Ix_ForPrecisonGainCtrl--;
                            else
                                break;
                        }

                        /* 1. Write Reg0x80 and enter normal mode */
                        Reg80Value &= ~bit_op_mask;
                        Reg80Value |= Convert.ToUInt32(PreciseTable[1][Ix_ForPrecisonGainCtrl]);
                        EnterTestMode();
                        RegisterWrite(1, new uint[2] { 0x80, Reg80Value });
                        EnterNomalMode();
                        /* 2.Get Vout@IP and Vout@0A */
                        Vout_IP = AverageVout();
                        dr = MessageBox.Show(String.Format("Please Change Current To {0}A", 0), "Change Current", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.Cancel)
                        {
                            DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                            return false;
                        }
                        Vout_0A = AverageVout();
                        return true;
                    }
                }
                else
                {
                    /* Increase/decrease the Ix_ForPrecisonGainCtrl; update reg80; Get Vaout*/
                    if (IncreaseOrDecrease)
                    {
                        if (Ix_ForPrecisonGainCtrl < 15)
                            Ix_ForPrecisonGainCtrl++;
                        else
                            break;
                    }
                    else
                    {
                        if (Ix_ForPrecisonGainCtrl > 0)
                            Ix_ForPrecisonGainCtrl--;
                        else
                            break;
                    }

                    /* 1. Write Reg0x80 and enter normal mode */
                    Reg80Value &= ~bit_op_mask;
                    Reg80Value |= Convert.ToUInt32(PreciseTable[1][Ix_ForPrecisonGainCtrl]);
                    EnterTestMode();
                    RegisterWrite(1, new uint[2] { 0x80, Reg80Value });
                    EnterNomalMode();
                    /* 2.Get Vout@IP and Vout@0A */
                    Vout_IP = AverageVout();
                    dr = MessageBox.Show(String.Format("Please Change Current To {0}A", 0), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        return false;
                    }
                    Vout_0A = AverageVout();

                    vout_0A_Convert = CalcTargetXFromDetectiveY(Vout_0A);
                    vout_IP_Convert = CalcTargetXFromDetectiveY(Vout_IP);
                    target_Gain2 = target_Gain1;    //backup history gain
                    target_Gain1 = GainCalculate(vout_0A_Convert, vout_IP_Convert);
                    dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        return false;
                    }
                }
            }

            /* make sure exit current is 0A */
            dr = MessageBox.Show(String.Format("Please Change Current To {0}A", 0), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                return false;
            }
            return true;
        }

        private bool OffsetCalcWithLoop()
        {
            /* 如果小与2.5那么就从最后一行往上索引到102.40%(ix: 15 -> 8),如果大于2.5那么就从第一行向下索引到97.97%(ix:0 -> 7) */
            double delta_offset1 = 0; //new
            double delta_offset2 = 0; //older
            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            /* 1. Write Reg0x81, 0x82, 0x83 and enter normal mode */
            EnterTestMode();
            RegisterWrite(3, new uint[6] { 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value});
            EnterNomalMode();

            /* 2.Get Vout@0A */
            Vout_0A = AverageVout();

            if (Vout_0A == b_offset)
            {
                return true;
            }

            delta_offset1 = Vout_0A - b_offset;
            delta_offset2 = delta_offset1;
            // if (Vout_0A > b_offset) then index++ ,else index--
            bool IncreaseOrDecrease = (delta_offset1 > 0) ? true : false;
            Ix_ForOffsetBTable = IncreaseOrDecrease ? 0 : 15;
            
            while(true)
            {
                /* get the right offset code */
                if (delta_offset1 * delta_offset2 <= 0)
                {
                    /* the latest one is the right code, do nothing then */
                    if (Math.Abs(delta_offset1) <= Math.Abs(delta_offset2))
                    {
                        break;
                    }
                    /* Back to older one */
                    else
                    {
                        if (!IncreaseOrDecrease)
                        {
                            if (Ix_ForOffsetBTable > 0)
                                Ix_ForOffsetBTable--;
                            else
                                break;
                        }
                        else
                        {
                            if (Ix_ForOffsetBTable < 15)
                                Ix_ForOffsetBTable++;
                            else
                                break;
                        }

                        Reg83Value &= ~bit_op_mask;
                        Reg83Value |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]);
                        /* 1. Write Reg0x83 and enter normal mode */
                        EnterTestMode();
                        RegisterWrite(1, new uint[2] { 0x83, Reg83Value });
                        EnterNomalMode();
                        /* 2.Get Vout@0A */
                        Vout_0A = AverageVout();
                        break;
                    }
                }
                /* Increase/decrease the Ix_ForPrecisonGainCtrl; update reg80; Get Vaout*/
                else
                {
                    if (IncreaseOrDecrease)
                    {
                        if (Ix_ForOffsetBTable < 7)
                            Ix_ForOffsetBTable++;
                        else
                            break;
                    }
                    else
                    {
                        if (Ix_ForOffsetBTable > 8)
                            Ix_ForOffsetBTable--;
                        else
                            break;
                    }
                    Reg83Value &= ~bit_op_mask;
                    Reg83Value |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]);
                    /* 1. Write Reg0x83 and enter normal mode */
                    EnterTestMode();
                    RegisterWrite(1, new uint[2] { 0x83, Reg83Value });
                    EnterNomalMode();
                    /* 2.Get Vout@0A */
                    Vout_0A = AverageVout();
                    delta_offset2 = delta_offset1;
                    delta_offset1 = Vout_0A - b_offset;
                }
            }

            return true;
        }

        private void RePower()
        {
            Delay(Delay_Sync);
            //1. Power Off
            PowerOff();

            Delay(Delay_Power);

            //2. Power On
            PowerOn();
        }

        private void PowerOff()
        {
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_OFF))
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Power off succeeded!");
                }
            }
            else
                DisplayOperateMes("Power off failed!");
        }

        private void PowerOn()
        {
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_ON))
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Power on succeeded!");
                }
            }
            else
                DisplayOperateMes("Power on failed!");
        }

        private void Delay(int time)
        {
            Thread.Sleep(time);
            if (bAutoTrimTest)
            {
                //DisplayOperateMes(String.Format("Delay {0}ms", time));
            }
        }

        private void StoreReg80ToReg83Value()
        {
            Reg80ToReg83Backup[0] = Reg80Value;
            Reg80ToReg83Backup[1] = Reg81Value;
            Reg80ToReg83Backup[2] = Reg82Value;
            Reg80ToReg83Backup[3] = reg83Value;
            Ix_ForRoughGainCtrlBackup = Ix_ForRoughGainCtrl;
        }

        private void RestoreReg80ToReg83Value()
        {
            Reg80Value = Reg80ToReg83Backup[0];
            Reg81Value = Reg80ToReg83Backup[1];
            Reg82Value = Reg80ToReg83Backup[2];
            Reg83Value = Reg80ToReg83Backup[3];
            Ix_ForRoughGainCtrl = Ix_ForRoughGainCtrlBackup;
        }

        private void MarginalReadPreset()
        {
            EnterTestMode();

            uint _reg_addr = 0x43;
            uint _reg_data = 0x06;
            bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("I2C write failed, Marginal Read Failed!", Color.Red);
                return;
            }

            Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x0E;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Marginal Read succeeded!");
                }
            }
            else
            {
                DisplayOperateMes("I2C write failed, Marginal Read Failed!", Color.Red);
                return;
            }

            Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x0;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Marginal Read Setup succeeded!");
                }
            }
            else
                DisplayOperateMes("Marginal Read Setup failed!", Color.Red);
        }

        private void ReloadPreset()
        {
            EnterTestMode();

            uint _reg_addr = 0x43;
            uint _reg_data = 0x0B;
            bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Reload succeeded!");
                }
            }
            else
            {
                DisplayOperateMes("I2C write failed, Relaod Failed!", Color.Red);
                return;
            }

            Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x0;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Reload Setup succeeded!");
                }
            }
            else
                DisplayOperateMes("Reload Setup failed!", Color.Red);
        
        }

        private void SafetyReadPreset()
        {
            EnterTestMode();

            uint _reg_addr = 0x84;
            uint _reg_data = 0xC0;
            bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("1st I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            _reg_addr = 0x84;
            _reg_data = 0x00;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("1st I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x06;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("2nd I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x0E;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("3rd I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation); //delay 300ms

            _reg_addr = 0x43;
            _reg_data = 0x0;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Reset Reg0x43 succeeded!");
                }
            }
            else
            {
                DisplayOperateMes("Reset Reg0x43 failed!", Color.Red);
                return;
            }

            Delay(Delay_Operation);    //delay 300ms

            //_reg_addr = 0x84;
            //_reg_data = 0x0;
            //writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            //if (writeResult)
            //{
            //    if (bAutoTrimTest)
            //    {
            //        DisplayOperateMes("Safety Read Setup succeeded!\r\n");
            //    }
            //}
            //else
            //    DisplayOperateMes("Safety Read Setup failed!\r\n", Color.Red);
        }

        private void SafetyHighReadPreset()
        {
            EnterTestMode();

            uint _reg_addr = 0x84;
            uint _reg_data = 0xC0;
            bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("1st I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            _reg_addr = 0x84;
            _reg_data = 0x00;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("1st I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x06;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("2nd I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation);

            _reg_addr = 0x43;
            _reg_data = 0x03;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("3rd I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            _reg_addr = 0x43;
            _reg_data = 0x0B;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (!writeResult)
            {
                DisplayOperateMes("3rd I2C write failed, Safety Read Failed!", Color.Red);
                return;
            }

            //Delay(Delay_Operation); //delay 300ms

            _reg_addr = 0x43;
            _reg_data = 0x0;
            writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
            if (writeResult)
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Reset Reg0x43 succeeded!");
                }
            }
            else
            {
                DisplayOperateMes("Reset Reg0x43 failed!", Color.Red);
                return;
            }

            Delay(Delay_Operation);    //delay 300ms
        }

        private bool BurstRead(uint _reg_addr_start, int num, uint[] _readBack_data)
        {
            Delay(Delay_Sync);
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);

            if (bAutoTrimTest)
                DisplayOperateMes("Read Out Data is:");

            if (oneWrie_device.I2CRead_Burst(this.DeviceAddress, _reg_addr_start, 5, _readBack_data) == 0)
            {
                for (int ix = 0; ix < num; ix++)
                {
                    if (bAutoTrimTest)
                        DisplayOperateMes(string.Format("Reg{0} = 0x{1}", ix, _readBack_data[ix].ToString("X2")));
                }
                return true;
            }
            else
            {
                DisplayOperateMes("Read Back Failed!");
                return false;
            }
        }

        private void TrimFinish()
        {
            //DisplayOperateMes("AutoTrim Canceled!", Color.Red);
            oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u);
            Delay(Delay_Operation);
            PowerOff();
            RestoreReg80ToReg83Value();
            DisplayOperateMes("Return!");
            //return;
        }

        private void PrintDutAttribute( ModuleAttribute sDUT)
        {
            DisplayOperateMes("<--------------------------->");
            DisplayOperateMes("IQ = " + sDUT.dIQ.ToString("F3"));
            DisplayOperateMes("dVoutIPNative = " + sDUT.dVoutIPNative.ToString("F3"));
            DisplayOperateMes("dVout0ANative = " + sDUT.dVout0ANative.ToString("F3"));
            DisplayOperateMes("dVoutIPMiddle = " + sDUT.dVoutIPMiddle.ToString("F3"));
            DisplayOperateMes("dVout0AMiddle = " + sDUT.dVout0AMiddle.ToString("F3"));
            DisplayOperateMes("dVoutIPTrimmed = " + sDUT.dVoutIPTrimmed.ToString("F3"));
            DisplayOperateMes("dVout0ATrimmed = " + sDUT.dVout0ATrimmed.ToString("F3"));
            DisplayOperateMes("bDigitalCommFail = " + sDUT.bDigitalCommFail.ToString());
            DisplayOperateMes("bNormalModeFail = " + sDUT.bNormalModeFail.ToString());
            DisplayOperateMes("bReadMarginal = " + sDUT.bReadMarginal.ToString());
            DisplayOperateMes("bReadSafety = " + sDUT.bReadSafety.ToString());
            DisplayOperateMes("bTrimmed = " + sDUT.bTrimmed.ToString());
            DisplayOperateMes("<--------------------------->");
        }

        #endregion Methods

        #region Events

        private void contextMenuStrip_Copy_MouseUp(object sender, MouseEventArgs e)
        {
            this.txt_OutputLogInfo.Copy();
        }

        private void contextMenuStrip_Paste_Click(object sender, EventArgs e)
        {
            this.txt_OutputLogInfo.Paste();
        }

        private void contextMenuStrip_Clear_MouseUp(object sender, MouseEventArgs e)
        {
            this.txt_OutputLogInfo.Text = null;
            //解决Scroll Bar的刷新问题。
            this.txt_OutputLogInfo.ScrollBars = RichTextBoxScrollBars.None;
            this.txt_OutputLogInfo.ScrollBars = RichTextBoxScrollBars.Both;
        }

        private void contextMenuStrip_SelAll_Click(object sender, EventArgs e)
        {
            this.txt_OutputLogInfo.SelectAll();
        }

        private void txt_TargetGain_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //temp = (4500d - 2000d) / double.Parse(this.txt_TargetGain.Text);
                if ((sender as TextBox).Text.ToCharArray()[(sender as TextBox).Text.Length - 1].ToString() == ".")
                    return;
                TargetGain_customer = double.Parse((sender as TextBox).Text);
                //TargetGain_customer = (double.Parse((sender as TextBox).Text) * 2000d)/IP;
            }
            catch
            {
                string tempStr = string.Format("Target gain set failed, will use default value {0}", this.TargetGain_customer);
                DisplayOperateMes(tempStr, Color.Red);
            }
            finally
            {
                //TargetGain_customer = TargetGain_customer;      //Force to update text to default.
            }

            //double temp = 2000d / TargetGain_customer;
            //this.IP = temp;  
            //this.txt_IP_EngT.Text = temp.ToString();
            //this.txt_IP_PreT.Text = temp.ToString();
            //this.txt_IP_AutoT.Text = temp.ToString();
        }

        private void btn_PowerOn_OWCI_ADC_Click(object sender, EventArgs e)
        {
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_ON))
                DisplayOperateMes("Power on succeeded!");
            else
                DisplayOperateMes("Power on failed!");
        }

        private void btn_PowerOff_OWCI_ADC_Click(object sender, EventArgs e)
        {
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_OFF))
                DisplayOperateMes("Power off succeeded!");
            else
                DisplayOperateMes("Power off failed!");
            //uint[] uTest = new uint[16];
            //for (uint i = 0; i < 16; i++)
            //{
            //    uTest[i] = i;
            //}

            //MultiSiteDisplayResult(uTest);


        }

        private void btn_enterNomalMode_Click(object sender, EventArgs e)
        {
            EnterNomalMode();
        }
        
        private void btn_ADCReset_Click(object sender, EventArgs e)
        {
            if (!oneWrie_device.ADCReset())
                DisplayOperateMes("ADC Reset Failed!", Color.Red);
            else
                DisplayOperateMes("ADC Reset succeeded!");
        }

        private void btn_CalcGainCode_EngT_Click(object sender, EventArgs e)
        {
            //Rough Trim
            string baseMes = "Calculate Gain Operation:";
            if (bAutoTrimTest)
            {
                DisplayOperateMes(baseMes);
            }

            double testGain = GainCalculate();
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Test Gain = " + testGain.ToString());
            }

            double gainTuning = 100 * GainTuningCalc_Customer(testGain, TargetGain_customer);   //计算修正值，供查表用
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Ideal Gain = " + gainTuning.ToString("F4") + "%");
            }

            Ix_ForPrecisonGainCtrl = LookupPreciseGain(gainTuning, PreciseTable_Customer);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Precise Gain Index = " + Ix_ForPrecisonGainCtrl.ToString() +
                    ";Choosed Gain = " + PreciseTable_Customer[0][Ix_ForPrecisonGainCtrl].ToString() + "%");
            }

            bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask | bit3_Mask | bit4_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_ForPrecisonGainCtrl]);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg1 Value = " + Reg80Value.ToString() +
                    "(+ 0x" + Convert.ToInt32(PreciseTable_Customer[1][Ix_ForPrecisonGainCtrl]).ToString("X") + ")");
            }
        }

        private bool MultiSiteOffsetAlg(uint[] reg_TMS )
        {
            string baseMes = "Offset Trim Operation:";
            if (bAutoTrimTest)
            {
                DisplayOperateMes(baseMes);
            }
            double offsetTuning = 100 * OffsetTuningCalc_Customer();
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Lookup offset = " + offsetTuning.ToString("F4") + "%");
            }

            Ix_ForOffsetATable = LookupOffset(ref offsetTuning, OffsetTableA_Customer);
            //offsetTuning = offsetTuning / OffsetTableA_Customer[0][Ix_ForOffsetATable]; 
            Ix_ForOffsetBTable = LookupOffset(ref offsetTuning, OffsetTableB_Customer);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("Offset TableA chose Index = " + Ix_ForOffsetATable.ToString() +
                    ";Choosed OffsetA = " + OffsetTableA_Customer[0][Ix_ForOffsetATable].ToString("F4"));
                DisplayOperateMes("Offset TableB chose Index = " + Ix_ForOffsetBTable.ToString() +
                    ";Choosed OffsetB = " + OffsetTableB_Customer[0][Ix_ForOffsetBTable].ToString("F4"));
            }

            reg_TMS[0] += Convert.ToUInt32(OffsetTableA_Customer[1][Ix_ForOffsetATable]);
            reg_TMS[1] += Convert.ToUInt32(OffsetTableA_Customer[2][Ix_ForOffsetATable]);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg0x81 Value = 0x" + reg_TMS[0].ToString("X2") + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[1][Ix_ForOffsetATable]).ToString("X") + ")");
                DisplayOperateMes("Reg0x82 Value = 0x" + reg_TMS[1].ToString("X2") + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[2][Ix_ForOffsetATable]).ToString("X") + ")");
            }

            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            reg_TMS[2] &= ~bit_op_mask;
            reg_TMS[2] |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg0x83 Value = 0x" + reg_TMS[2].ToString("X2") + "(+ 0x" + Convert.ToInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]).ToString("X") + ")");
            }
            return true;
        }

        private void btn_offset_Click(object sender, EventArgs e)
        {
            string baseMes = "Offset Trim Operation:";
            if (bAutoTrimTest)
            {
                DisplayOperateMes(baseMes);
            }
            double offsetTuning = 100 * OffsetTuningCalc_Customer();
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Lookup offset = " + offsetTuning.ToString("F4") + "%");
            }

            Ix_ForOffsetATable = LookupOffset(ref offsetTuning, OffsetTableA_Customer);
            //offsetTuning = offsetTuning / OffsetTableA_Customer[0][Ix_ForOffsetATable]; 
            Ix_ForOffsetBTable = LookupOffset(ref offsetTuning, OffsetTableB_Customer);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("Offset TableA chose Index = " + Ix_ForOffsetATable.ToString() +
                    ";Choosed OffsetA = " + OffsetTableA_Customer[0][Ix_ForOffsetATable].ToString("F4"));
                DisplayOperateMes("Offset TableB chose Index = " + Ix_ForOffsetBTable.ToString() +
                    ";Choosed OffsetB = " + OffsetTableB_Customer[0][Ix_ForOffsetBTable].ToString("F4"));
            }

            Reg81Value += Convert.ToUInt32(OffsetTableA_Customer[1][Ix_ForOffsetATable]);
            Reg82Value += Convert.ToUInt32(OffsetTableA_Customer[2][Ix_ForOffsetATable]);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg2 Value = " + Reg81Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[1][Ix_ForOffsetATable]).ToString("X") + ")");
                DisplayOperateMes("Reg3 Value = " + Reg82Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[2][Ix_ForOffsetATable]).ToString("X") + ")");
            }

            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            Reg83Value &= ~bit_op_mask;
            Reg83Value |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg4 Value = " + Reg83Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]).ToString("X") + ")");
            }
        }

        private void btn_writeFuseCode_Click(object sender, EventArgs e)
        {
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config_EngT.Checked = true;


            bool fuseMasterBit = false;
            DialogResult dr = MessageBox.Show("Do you want to Fuse master bit?", "Fuse master bit??", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
                return;
            else if (dr == System.Windows.Forms.DialogResult.Yes)
                fuseMasterBit = true;

            try
            {
                string temp;
                uint _dev_addr = this.DeviceAddress;

                //Enter test mode
                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                //Reg80
                temp = this.txt_reg80_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_Addr = 0x80;
                uint _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg1(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg1 Failed!", Color.Red);

                //Reg81
                temp = this.txt_reg81_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x81;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg2(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg2 Failed!", Color.Red);

                //Reg82
                temp = this.txt_reg82_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x82;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg3(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg3 Failed!", Color.Red);

                //Reg83
                temp = this.txt_reg83_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x83;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg4(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg4 Failed!", Color.Red);

                if (fuseMasterBit)
                {
                    //Reg84
                    _reg_Addr = 0x84;
                    _reg_Value = 0x07;

                    if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                        DisplayOperateMes("Master bit fused succeeded!");
                    else
                        DisplayOperateMes("Master bit fused Failed!", Color.Red);
                }

            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void txt_reg80_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_reg81_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_reg82_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg82_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (Reg82Value == regValue)
                    return;
                else
                {
                    this.Reg82Value = regValue;
                    DisplayOperateMes("Enter Reg3 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg3 value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg82_EngT.Text = "0x" + this.Reg82Value.ToString("X2");
            }
        }

        private void txt_reg83_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg83_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
                if (Reg83Value == regValue)
                    return;
                else
                {
                    this.Reg83Value = regValue;
                    DisplayOperateMes("Enter Reg3 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg83_EngT.Text = "0x" + this.Reg83Value.ToString("X2");
            }
        }

        private void txt_RegValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt_Regx = sender as TextBox;
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            string str = "\r\b0123456789abcdefABCDEF";//This will allow the user to enter numeric HEX values only.

            e.Handled = !(str.Contains(e.KeyChar.ToString()));

            if (e.Handled)
                return;
            else
            {
                if (e.KeyChar.ToString() == "\r")
                {
                    RegTextChangedDisplay(txt_Regx);
                    txt_Regx.SelectionStart = txt_Regx.Text.Length;
                    //try
                    //{
                    //    //string temp = txt_Regx.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                    //    //uint _reg_value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
                    //    RegTextChangedDisplay(txt_Regx);
                    //}
                    //catch
                    //{
                    //    txt_Regx.Text = this.
                    //}
                }
            }

            #region Comment out
            //if (txt_Regx.Text.Length >= 2)
            //{
            //    if (txt_Regx.Text.StartsWith("0x") | txt_Regx.Text.StartsWith("0X"))
            //    {
            //        if (txt_Regx.Text.Length >= 4)
            //        {
            //            if ((e.KeyChar == '\b') | ((txt_Regx.SelectionLength >= 1) & (txt_Regx.SelectionStart >= 2)) |
            //                           (txt_Regx.SelectionLength == txt_Regx.Text.Length))
            //            {
            //                e.Handled = !(str.Contains(e.KeyChar.ToString()));
            //                RegTextChangedDisplay(txt_Regx);
            //                return;
            //            }
            //            else
            //            {
            //                e.Handled = true;
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (e.KeyChar != '\b' | (txt_Regx.SelectionLength == txt_Regx.Text.Length))
            //        {
            //            e.Handled = true;
            //            txt_Regx.Text = "0x" + txt_Regx.Text;
            //            RegTextChangedDisplay(txt_Regx);
            //            return;
            //        }

            //    }
            //}
            //e.Handled = !(str.Contains(e.KeyChar.ToString()));
            //if (e.Handled | txt_Regx.Text.StartsWith("0x") | txt_Regx.Text.StartsWith("0X"))
            //{
            //    return;
            //}
            //else
            //{
            //    txt_Regx.Text = "0x" + txt_Regx.Text;
            //    RegTextChangedDisplay(txt_Regx);
            //    txt_Regx.SelectionStart = txt_Regx.Text.Length;
            //}
            #endregion Comment out
        }

        private void RegTextChangedDisplay(TextBox txtReg)
        {
            if ((txtReg == this.txt_reg80_EngT) | (txtReg == this.txt_Reg80_PreT))
                this.txt_reg80_TextChanged(null, null);
            else if ((txtReg == this.txt_reg81_EngT) | (txtReg == this.txt_Reg81_PreT))
                this.txt_reg81_TextChanged(null, null);
            else if ((txtReg == this.txt_reg82_EngT) | (txtReg == this.txt_Reg82_PreT))
                this.txt_reg82_TextChanged(null, null);
            else if ((txtReg == this.txt_reg83_EngT) | (txtReg == this.txt_Reg83_PreT))
                this.txt_reg83_TextChanged(null, null);
        }

        private void rbt_5V_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_VDD_5V_EngT.Checked)
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            else
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);

            string message;
            if (rbt_VDD_5V_EngT.Checked)
                message = "VDD chose 5V";
            else
                message = "VDD chose external power";

            if (setResult)
            {
                if (bAutoTrimTest)
                {
                    message += " succeeded!";
                    DisplayOperateMes(message);
                }
            }
            else
            {
                if (bAutoTrimTest)
                {
                    message += " Failed!";
                    DisplayOperateMes(message, Color.Red);
                }
            }
        }

        private void rbt_withCap_Vout_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_withCap_Vout_EngT.Checked)
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            else
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITHOUT_CAP);

            string message;
            if (rbt_withCap_Vout_EngT.Checked)
                message = "Vout with Cap set";
            else
                message = "Vout without Cap set";

            if (setResult)
            {
                if (bAutoTrimTest)
                {
                    message += " succeeded!";
                    DisplayOperateMes(message);
                }
            }
            else
            {
                if (bAutoTrimTest)
                {
                    message += " Failed!";
                    DisplayOperateMes(message, Color.Red);
                }
            }
        }

        private void rbt_withCap_Vref_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_withCap_Vref.Checked)
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VREF_WITH_CAP);
            else
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VREF_WITHOUT_CAP);

            string message;
            if (rbt_withCap_Vref.Checked)
                message = "Vref with Cap set";
            else
                message = "Vref without Cap set";
            if (setResult)
            {
                if (bAutoTrimTest)
                {
                    message += " succeeded!";
                    DisplayOperateMes(message);
                }
            }
            else
            {
                if (bAutoTrimTest)
                {
                    message += " Failed!";
                    DisplayOperateMes(message, Color.Red);
                }
            }
        }

        private void rbt_signalPathSeting_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            string message;
            //L-Vout
            if (rbt_signalPathSeting_Vout_EngT.Checked && rbt_signalPathSeting_AIn_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
                message = "Vout to VIn set";
            }
            else if (rbt_signalPathSeting_Vout_EngT.Checked && rbt_signalPathSeting_Config_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
                message = "Vout to CONFIG set";
            }
            //L-Vref
            else if (rbt_signalPathSeting_Vref_EngT.Checked && rbt_signalPathSeting_AIn_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VREF);
                message = "Vref to VIn set";
            }
            else if (rbt_signalPathSeting_Vref_EngT.Checked && rbt_signalPathSeting_Config_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VREF);
                message = "Vref to CONFIG set";
            }
            //L-VCS
            else if (rbt_signalPathSeting_VCS_EngT.Checked && rbt_signalPathSeting_AIn_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VCS);
                message = "VCS to VIn set";
            }
            else if (rbt_signalPathSeting_VCS_EngT.Checked && rbt_signalPathSeting_Config_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VCS);
                message = "VSC to CONFIG set";
            }
            //L-510out
            else if (rbt_signalPathSeting_510Out_EngT.Checked && rbt_signalPathSeting_AIn_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_510OUT);
                message = "510out to VIn set";
            }
            else if (rbt_signalPathSeting_510Out_EngT.Checked && rbt_signalPathSeting_Config_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_510OUT);
                message = "510out to CONFIG set";
            }
            //L-Mout
            else if (rbt_signalPathSeting_Mout_EngT.Checked && rbt_signalPathSeting_AIn_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_MOUT);
                message = "Mout to VIn set";
            }
            else if (rbt_signalPathSeting_Mout_EngT.Checked && rbt_signalPathSeting_Config_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_MOUT);
                message = "Mout to CONFIG set";
            }
            else
            {
                message = "Signal path routing failed!";
                return;
            }

            if (setResult)
            {
                if (bAutoTrimTest)
                {
                    message += " succeeded!";
                    DisplayOperateMes(message);
                }
            }
            else
            {
                if (bAutoTrimTest)
                {
                    message += " Failed!";
                    DisplayOperateMes(message, Color.Red);
                }
            }
        }

        private void rbtn_CSResistorByPass_EngT_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            string message;
            if (rbtn_CSResistorByPass_EngT.Checked)
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_BYPASS_CURRENT_SENCE);
                message = "Vout to VIn set";
            }
            else
            {
                setResult = oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_SET_CURRENT_SENCE);
                message = "Vout to CONFIG set";
            }

            if (setResult)
            {
                if (bAutoTrimTest)
                {
                    message += " succeeded!";
                    DisplayOperateMes(message);
                }
            }
            else
            {
                if (bAutoTrimTest)
                {
                    message += " Failed!";
                    DisplayOperateMes(message, Color.Red);
                }
            }
        }

        private void btn_burstRead_Click(object sender, EventArgs e)
        {
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config_EngT.Checked = true;

            EnterTestMode();

            //Read Back 0x80~0x85
            uint _reg_addr_start = 0x80;
            uint[] _readBack_data = new uint[5];

            BurstRead(_reg_addr_start, 5, _readBack_data);

            //uint data = 0;
            //oneWrie_device.I2CRead_Single(this.DeviceAddress, 0x4E);
            //DisplayOperateMes(string.Format("Reg0x4E = 0x{0}", data.ToString("X2")));
        }

        private void btn_MarginalRead_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Vout_EngT.Checked = true;
            rbt_signalPathSeting_Config_EngT.Checked = true;

            MarginalReadPreset();
        }

        private void btn_SafetyRead_EngT_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Vout_EngT.Checked = true;
            rbt_signalPathSeting_Config_EngT.Checked = true;

            SafetyReadPreset();
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config_EngT.Checked = true;

            try
            {
                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);

                _reg_addr = 0x43;
                _reg_data = 0x0B;

                bool writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reload succeeded!");
                else
                    DisplayOperateMes("I2C write failed, Reload Failed!", Color.Red);

                //Delay 100ms
                Thread.Sleep(100);
                DisplayOperateMes("Delay 100ms");

                _reg_addr = 0x43;
                _reg_data = 0x0;

                writeResult = oneWrie_device.I2CWrite_Single(this.DeviceAddress, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reset Reg0x43 succeeded!");
                else
                    DisplayOperateMes("Reset Reg0x43 failed!", Color.Red);
            }
            catch
            {
                DisplayOperateMes("Reload Failed!", Color.Red);
            }
        }
        
        private void numUD_TargetGain_Customer_ValueChanged(object sender, EventArgs e)
        {
            targetGain_customer = (double)(sender as NumericUpDown).Value;
        }

        private void numUD_IPxForCalc_Customer_ValueChanged(object sender, EventArgs e)
        {
            StrIPx_Auto = (sender as NumericUpDown).Value.ToString("F1") + "A";
            selectedCurrent_Auto = (double)(sender as NumericUpDown).Value;
        }

        private void AutoTrimTab_Enter(object sender, EventArgs e)
        {
            //Backup value for autotrim
            StoreReg80ToReg83Value();
        }


        //bool bAutoTrimTest = false;
        private void btn_AutomaticaTrim_Click(object sender, EventArgs e)
        {

            if (this.cmb_Module_PreT.SelectedItem.ToString() == "5V" || this.cmb_Module_PreT.SelectedItem.ToString() == "3.3V")
            {
                if (SocketType == 0)
                    AutomaticaTrim_5V_SingleSite();
                else if (SocketType == 1)
                    btn_AutomaticaTrim5V_MultiSite(null, null);
                else
                    return;
            }
            else
            {
                if (SocketType == 0)
                    AutomaticaTrim_15V_SingleSite();
                else if (SocketType == 1)
                    btn_AutomaticaTrim15V_MultiSite(null, null);
                else
                    return;
            }

        }
        //Multi-Site
        private void btn_AutomaticaTrim5V_MultiSite(object sender, EventArgs e)
        {
            //DisplayOperateMes("AadcOffset = " + AadcOffset.ToString());
            #region Define Parameters
            DialogResult dr;
            bool bMarginal = false;
            //bool bSafety = false;
            //uint[] tempReadback = new uint[5];
            double dVip_Target = TargetOffset + TargetVoltage_customer;
            double dGainTestMinusTarget = 1;
            double dGainTest = 0;

            //**********************************
            // PARAMETERS DEFINE FOR MULTISITE
            //**********************************
            uint uDutCount = 16;
            bool bValidRound = false;
            //bool bSecondCurrentOn = false;
            double dModuleCurrent = 0;
            bool[] bGainBoost = new bool[16];
            bool[] bDutValid = new bool[16];
            bool[] bDutNoNeedTrim = new bool[16];
            uint[] uDutTrimResult = new uint[16];
            double[] dMultiSiteVoutIP = new double[16];
            double[] dMultiSiteVout0A = new double[16];

            /* autoAdaptingGoughGain algorithm*/
            double autoAdaptingGoughGain = 0;
            double autoAdaptingPresionGain = 0;
            double tempG1 = 0;
            double tempG2 = 0;
            double dGainPreset = 0;
            int Ix_forAutoAdaptingRoughGain = 0;
            int Ix_forAutoAdaptingPresionGain = 0;

            int ix_forOffsetIndex_Rough = 0;
            int ix_forOffsetIndex_Rough_Complementary = 0;
            double dMultiSiteVout_0A_Complementary = 0;
                 
            DisplayOperateMes("\r\nStart...");
            this.lbl_passOrFailed.ForeColor = Color.Black;
            this.lbl_passOrFailed.Text = "START!";
            
            for(uint idut = 0; idut < uDutCount; idut++)
            {
                dMultiSiteVoutIP[idut] = 0d;
                dMultiSiteVout0A[idut] = 0d;

                MultiSiteReg0[idut] = Reg80Value;
                MultiSiteReg1[idut] = Reg81Value;
                MultiSiteReg2[idut] = Reg82Value;
                MultiSiteReg3[idut] = Reg83Value;

                MultiSiteRoughGainCodeIndex[idut] = Ix_ForRoughGainCtrl;

                uDutTrimResult[idut] = 0u;
                bDutNoNeedTrim[idut] = false;
                bDutValid[idut] = false;
                bGainBoost[idut] = false;
            }
            #endregion Define Parameters

            #region UART Initialize
            if (ProgramMode == 0)
            {
               
                //UART Initialization
                if (oneWrie_device.UARTInitilize(9600, 1))
                    DisplayOperateMes("UART Initilize succeeded!");
                else
                    DisplayOperateMes("UART Initilize failed!");
                //ding hao
                Delay(Delay_Operation);
                //DisplayAutoTrimOperateMes("Delay 300ms");

                //1. Current Remote CTL
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_REMOTE, 0))
                    DisplayOperateMes("Set Current Remote succeeded!");
                else
                    DisplayOperateMes("Set Current Remote failed!");

                //Delay 300ms
                //Thread.Sleep(300);
                Delay(Delay_Operation);
                //DisplayAutoTrimOperateMes("Delay 300ms");

                //2. Current On
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_OUTPUTON, 0))
                    DisplayOperateMes("Set Current On succeeded!");
                else
                    DisplayOperateMes("Set Current On failed!");

                //Delay 300ms
                Delay(Delay_Operation);
                //DisplayOperateMes("Delay 300ms");

                //3. Set Voltage
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETVOLT, 2u))
                    DisplayOperateMes(string.Format("Set Voltage to {0}V succeeded!", 2));
                else
                    DisplayOperateMes(string.Format("Set Voltage to {0}V failed!", 2));


                //Delay 300ms
                Delay(Delay_Operation);
                //DisplayOperateMes("Delay 300ms");

            }

            #endregion UART Initialize

            #region Get module current
            //clear log
            DisplayOperateMesClear();
            /*  power on */
            RePower();
            Delay(Delay_Sync);
            this.lbl_passOrFailed.Text = "Module Current Checking!";
            /* Get module current */
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VCS))
            {
                if (bAutoTrimTest)
                    DisplayOperateMes("Set ADC VIN to VCS");
            }
            else
            {
                DisplayOperateMes("Set ADC VIN to VCS failed", Color.Red);
                //PowerOff();
                TrimFinish();
                return;
            }
            Delay(Delay_Sync);
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_SET_CURRENT_SENCE))
            {
                if (bAutoTrimTest)
                    DisplayOperateMes("Set ADC current sensor");
            }

            this.txt_ModuleCurrent_EngT.Text = GetModuleCurrent().ToString("F1");
            this.txt_ModuleCurrent_PreT.Text = this.txt_ModuleCurrent_EngT.Text;

            bValidRound = false;
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                MultiSiteSocketSelect(idut);
                dModuleCurrent = GetModuleCurrent();
                if ( dCurrentDownLimit > dModuleCurrent || dModuleCurrent > dCurrentUpLimit)
                {
                    DisplayOperateMes("Module " + idut.ToString() + " current is " + dModuleCurrent.ToString("F3"), Color.Red);
                    bDutValid[idut] = false;
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_CURRENT_ABNORMAL;
                }
                else
                {
                    DisplayOperateMes("Module " + idut.ToString() + " current is " + dModuleCurrent.ToString("F3"));
                    bDutValid[idut] = true;
                }

                bValidRound |= bDutValid[idut];
            }
            /* Judge IDD */
            if ( !bValidRound )
            {
                dr = MessageBox.Show(String.Format("Module Current is abnormal!"), "Warning", MessageBoxButtons.OK);
                DisplayOperateMes("No Valid Module!!!", Color.Red);
                //PowerOff();
                TrimFinish();
                return;
            }
            #endregion Get module current

            #region Saturation judgement
            // Change Current to IP  */
            if (ProgramMode == 0)
            {
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                    TrimFinish();
                    return;
                }
            }
            else
            {
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }
            //Delay(Delay_Sync);

            bValidRound = false;
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut])
                {
                    MultiSiteSocketSelect(idut);
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    BurstRead(0x80, 5, tempReadback);
                    if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
                    {
                        DisplayOperateMes("DUT " + idut.ToString() + " has been Blown!", Color.Red);
                        bDutValid[idut] = false;
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_TRIMMED_ALREADY;
                    }

                    //RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    BurstRead(0x80, 5, tempReadback);
                    /* Get vout @ IP */
                    EnterNomalMode();
                    //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
                    Delay(Delay_Fuse);
                    dMultiSiteVoutIP[idut] = AverageVout();
                    DisplayOperateMes("Vout[" + idut.ToString() + "] @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));

                    /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
                    if (dMultiSiteVoutIP[idut] > saturationVout)
                    {
                        DisplayOperateMes("Module" + idut.ToString() + " Vout is SATURATION!", Color.Red);
                        //bDutSaturation[idut] = true;
                        bDutValid[idut] = false;
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                    }
                    else if (dMultiSiteVoutIP[idut] < TargetOffset)
                    {
                        DisplayOperateMes("Module" + idut.ToString() + " Invert IP!", Color.Red);
                        //bDutSaturation[idut] = true;
                        bDutValid[idut] = false;
                        //uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                    }
                    else
                    {
                        //bDutSaturation[idut] = false;
                        bDutValid[idut] = true;
                    }

                    bValidRound |= bDutValid[idut];
                }
            }

            if (!bValidRound)
            {
                dr = MessageBox.Show(String.Format("Vout Abnormal!"), "Warning", MessageBoxButtons.OK);
                DisplayOperateMes("Vout of all DUTs are SATURATION or too LOW!", Color.Red);
                //PowerOff();
                TrimFinish();
                return;
            }

            #endregion Saturation judgement

            #region Get Vout@0A
            /* Change Current to 0A */
            if (ProgramMode == 0)
            {
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", 0u));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", 0u));
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    //PowerOff();
                    //RestoreReg80ToReg83Value();
                    TrimFinish();
                    return;
                }
            }
            else
            {
                dr = MessageBox.Show(String.Format("Please Change Current To 0A"), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }
            //Delay(Delay_Sync);

            bValidRound = false;
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut])
                {
                    MultiSiteSocketSelect(idut);
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    BurstRead(0x80, 5, tempReadback);
                    if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
                        DisplayOperateMes("DUT " + idut.ToString() + " has been Blown!", Color.Red);

                    //RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    BurstRead(0x80, 5, tempReadback);
                    /* Get vout @ 0A */
                    EnterNomalMode();
                    //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
                    Delay(Delay_Fuse);
                    dMultiSiteVout0A[idut] = AverageVout();
                    DisplayOperateMes("Vout[" + idut.ToString() + "] @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));

                    if (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut] < VoutIPThreshold)
                    {
                        bDutValid[idut] = false;
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_LOW_SENSITIVITY;
                    }
                    else
                        bDutValid[idut] = true;

                    bValidRound |= bDutValid[idut];
                }
            }
            if (!bValidRound)
            {
                dr = MessageBox.Show(String.Format("Please Conform Current is {0}A!!!", IP), "Change Current", MessageBoxButtons.OK);
                //if (dr == DialogResult.Cancel)
                //{
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                //PowerOff();
                //RestoreReg80ToReg83Value();
                TrimFinish();
                return;
                //}
            }           
            #endregion  Get Vout@0A

            #region No need Trim case
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut])
                {
                    if ((TargetOffset - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= (TargetOffset + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= (TargetVoltage_customer + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= (TargetVoltage_customer - 0.01))
                    {
                        //oneWrie_device.SDPSignalPathSocketSel(idut);
                        Delay(Delay_Sync);
                        oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
                        //Delay(Delay_Sync);
                        MultiSiteSocketSelect(idut);
                        //Delay(Delay_Sync);
                        //RePower();
                        EnterTestMode();
                        //RegisterWrite(5, new uint[10] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value, 0x84, 0x07 });
                        RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
                        BurstRead(0x80, 5, tempReadback);
                        /* fuse */
                        FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                        DisplayOperateMes("Processing...");
                        Delay(Delay_Fuse);
                        ReloadPreset();
                        Delay(Delay_Operation);
                        BurstRead(0x80, 5, tempReadback);
                        Delay(Delay_Operation);
                        /* Margianl read, compare with writed code; 
                         * if ( = ), go on
                         * else bMarginal = true; */
                        MarginalReadPreset();
                        Delay(Delay_Operation);
                        BurstRead(0x80, 5, tempReadback);
                        bMarginal = false;
                        if (((tempReadback[0] & 0xE0) != (MultiSiteReg0[idut] & 0xE0)) | (tempReadback[1] & 0x81) != (MultiSiteReg1[idut] & 0x81) |
                            (tempReadback[2] & 0x99) != (MultiSiteReg2[idut] & 0x99) | (tempReadback[3] & 0x83) != (MultiSiteReg3[idut] & 0x83) | (tempReadback[4] < 1))
                            bMarginal = true;

                        if (!bMarginal)
                        {
                            DisplayOperateMes("DUT"+ idut.ToString() +"Pass! Bin Normal");
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_NORMAL;
                        }
                        else
                        {
                            DisplayOperateMes("DUT"+ idut.ToString() +"Pass! Bin Mriginal");
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_MARGINAL;
                        }

                        bDutValid[idut] = false;
                        bDutNoNeedTrim[idut] = true;
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_1; ;
                    }
                }
            
            }
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            #endregion No need Trim case

            #region For low sensitivity case, without IP
            bValidRound = false;
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut])
                {
                    dGainTest = 1000d * (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP;
                    if (dGainTest < (TargetGain_customer * ThresholdOfGain))
                    {
                        dGainTestMinusTarget = dGainTest / TargetGain_customer;
                        dGainPreset = RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]] / 100d;

                        if (this.cmb_IPRange_PreT.SelectedItem.ToString() == "Small")
                        {
                            if (dGainTestMinusTarget >= dGainPreset)
                            {
                                //Ix_ForRoughGainCtrl = (uint)LookupRoughGain_Customer(TargetGain_customer * 100d / dGainTest * dGainPreset, RoughTable_Customer);
                                MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer(TargetGain_customer * 100d / dGainTest * dGainPreset, RoughTable_Customer);
                                /* Rough Gain Code*/
                                bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                                MultiSiteReg0[idut] &= ~bit_op_mask;
                                MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);
                                //MultiSiteReg0[idut] = Reg80Value;

                                bit_op_mask = bit0_Mask;
                                MultiSiteReg1[idut] &= ~bit_op_mask;
                                MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);

                                bDutValid[idut] = true;
                                //MultiSiteReg1[idut] = Reg81Value;
                            }
                            else
                            {
                                DisplayOperateMes("DUT" + idut.ToString() + " Sensitivity is NOT enough!" ,Color.Red);
                                bDutValid[idut] = false;
                                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_LOW_SENSITIVITY;
                            }

                        }
                        else
                        {
                            if (dGainTestMinusTarget >= dGainPreset)
                            {
                                MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer(TargetGain_customer * 100d / dGainTest * dGainPreset, RoughTable_Customer);
                                /* Rough Gain Code*/
                                bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                                MultiSiteReg0[idut] &= ~bit_op_mask;
                                MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);
                                //MultiSiteReg0[idut] = Reg80Value;

                                bit_op_mask = bit0_Mask;
                                MultiSiteReg1[idut] &= ~bit_op_mask;
                                MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);
                                //MultiSiteReg1[idut] = Reg81Value;

                                bDutValid[idut] = true;
                            }
                            else
                            {
                                if (dGainTest * 1.5 / dGainPreset >= (TargetGain_customer * ThresholdOfGain))
                                {
                                    MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer((TargetGain_customer * 100d / (dGainTest * 1.5d) * dGainPreset), RoughTable_Customer);
                                    MultiSiteReg3[idut] |= 0x80;
                                    /* Rough Gain Code*/
                                    bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                                    MultiSiteReg0[idut] &= ~bit_op_mask;
                                    MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);
                                    //MultiSiteReg0[idut] = Reg80Value;

                                    bit_op_mask = bit0_Mask;
                                    MultiSiteReg1[idut] &= ~bit_op_mask;
                                    MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);
                                    //MultiSiteReg1[idut] = Reg81Value;

                                    bDutValid[idut] = true;
                                    bGainBoost[idut] = true;
                                }
                                else
                                {
                                    DisplayOperateMes("DUT"+ idut.ToString() +" Sensitivity is NOT enough!", Color.Red);
                                    bDutValid[idut] = false;
                                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_LOW_SENSITIVITY;
                                }
                            }
                        }

                        //DisplayOperateMes("RoughGainCodeIndex of DUT" + idut.ToString() + " = " + MultiSiteRoughGainCodeIndex[idut].ToString("F0"));

                        //bSecondCurrentOn = true;
                    }

                    DisplayOperateMes("RoughGainCodeIndex of DUT" + idut.ToString() + " = " + MultiSiteRoughGainCodeIndex[idut].ToString("F0"));
                    DisplayOperateMes("SelectedRoughGain = " + RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]].ToString());
                    DisplayOperateMes("0x80 = 0x" + MultiSiteReg0[idut].ToString("X2"));
                    DisplayOperateMes("0x81 = 0x" + MultiSiteReg1[idut].ToString("X2"));
                    DisplayOperateMes("0x82 = 0x" + MultiSiteReg2[idut].ToString("X2"));
                    DisplayOperateMes("0x83 = 0x" + MultiSiteReg3[idut].ToString("X2"));
                    //SaveMultiSiteRegData(idut);
                    bValidRound |= bDutValid[idut];
                }
            }

            if (!bValidRound)
            {
                dr = MessageBox.Show(String.Format("Invalid Round!"), "Warning", MessageBoxButtons.OK);
                DisplayOperateMes("All DUTs are Invalid after Boost Sensitivity!", Color.Red);
                //PowerOff();
                TrimFinish();
                return;
            }

            //if( bSecondCurrentOn )
            if (true)
            {
                if (ProgramMode == 0)
                {
                    /* Change Current to IP  */
                    if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                        DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                    else
                    {
                        DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                        TrimFinish();
                        return;
                    }
                }
                else
                {
                    dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        PowerOff();
                        RestoreReg80ToReg83Value();
                        return;
                    }
                }
                //Delay(Delay_Sync);

                bValidRound = false;
                for (uint idut = 0; idut < uDutCount; idut++)
                {
                    if (bDutValid[idut])
                    {
                        /*  power on */
                        //RePower();
                        MultiSiteSocketSelect(idut);
                        //Delay(Delay_Sync);
                        this.lbl_passOrFailed.Text = "Processing!";
                        EnterTestMode();
                        //RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
                        RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                        BurstRead(0x80, 5, tempReadback);
                        /* Get vout @ IP */
                        EnterNomalMode();
                        //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
                        Delay(Delay_Fuse);
                        dMultiSiteVoutIP[idut] = AverageVout();
                        DisplayOperateMes("Vout[" + idut.ToString() + "] @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));

                        /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
                        if (dMultiSiteVoutIP[idut] > saturationVout)
                        {
                            DisplayOperateMes("Module" + idut.ToString() + " Vout is SATURATION!", Color.Red);
                            bDutValid[idut] = false;
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                        }
                        else
                        {
                            bDutValid[idut] = true;
                        }

                        bValidRound |= bDutValid[idut];
                    }
                }

                if (!bValidRound)
                {
                    dr = MessageBox.Show(String.Format("SATURATION!"), "Vout SATURATION!", MessageBoxButtons.OK);
                    //DisplayOperateMes("All DUTs are Invalid after Re-current On!", Color.Red);
                    PowerOff();
                    for (uint idut = 0; idut < uDutCount; idut++)
                    {
                        if (idut < 10)
                            DisplayOperateMes("Dut0" + idut.ToString() + " = " + uDutTrimResult[idut].ToString());
                        else
                            DisplayOperateMes("Dut" + idut.ToString() + " = " + uDutTrimResult[idut].ToString());
                    }
                    MultiSiteDisplayResult(uDutTrimResult);
                    TrimFinish();
                    return;
                }

                /* Change Current to 0A */
                if (ProgramMode == 0)
                {
                    if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u))
                        DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", 0u));
                    else
                    {
                        DisplayOperateMes(string.Format("Set Current to {0}A failed!", 0u));
                        TrimFinish();
                        return;
                    }
                }
                else
                {
                    dr = MessageBox.Show(String.Format("Please Change Current To 0A"), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        PowerOff();
                        RestoreReg80ToReg83Value();
                        return;
                    }
                }
                //Delay(Delay_Sync);

                for (uint idut = 0; idut < uDutCount; idut++)
                {
                    if (bDutValid[idut])
                    {
                        /*  power on */
                        //RePower();
                        MultiSiteSocketSelect(idut);
                        //Delay(Delay_Sync);
                        this.lbl_passOrFailed.Text = "Processing!";
                        EnterTestMode();
                        //RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
                        RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                        BurstRead(0x80, 5, tempReadback);
                        /* Get vout @ IP */
                        EnterNomalMode();
                        //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
                        Delay(Delay_Fuse);
                        dMultiSiteVout0A[idut] = AverageVout();
                        DisplayOperateMes("Vout[" + idut.ToString() + "] @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));
                    }
                }
            }

            #endregion For low sensitivity case, without IP

            #region Adapting algorithm

            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut])
                {
                    DisplayOperateMes("\r\nDUT" + idut.ToString() + " start Adaptive Algorithm ");
                    //RestoreReg80ToReg83Value();
                    tempG1 = RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]] / 100d;
                    tempG2 = (TargetGain_customer / ((dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP)) / 1000d;

                    if( bGainBoost[idut] )
                        autoAdaptingGoughGain = tempG1 * tempG2 * 100d;
                    else
                        autoAdaptingGoughGain = tempG1 * tempG2 * 100d;

                    DisplayOperateMes( "TuningGoughGain = " + autoAdaptingGoughGain.ToString("F3") );

                    Ix_forAutoAdaptingRoughGain = LookupRoughGain_Customer(autoAdaptingGoughGain, RoughTable_Customer);
                    autoAdaptingPresionGain = 100d * autoAdaptingGoughGain / RoughTable_Customer[0][Ix_forAutoAdaptingRoughGain];
                    Ix_forAutoAdaptingPresionGain = LookupPreciseGain_Customer(autoAdaptingPresionGain, PreciseTable_Customer);
                    if (bAutoTrimTest)
                    {
                        DisplayOperateMes("IP = " + IP.ToString("F0"));
                        DisplayOperateMes("TargetGain_customer" + idut.ToString() + " = " + TargetGain_customer.ToString("F4"));
                        DisplayOperateMes("(dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut])/IP = " + ((dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP).ToString("F4"));
                        DisplayOperateMes("tempG1" + idut.ToString() + " = " + tempG1.ToString("F4"));
                        DisplayOperateMes("tempG2" + idut.ToString() + " = " + tempG2.ToString("F4"));
                        DisplayOperateMes("Ix_forAutoAdaptingRoughGain" + idut.ToString() +  " = " + Ix_forAutoAdaptingRoughGain.ToString("F0"));
                        DisplayOperateMes("Ix_forAutoAdaptingPresionGain" + idut.ToString() + " = " + Ix_forAutoAdaptingPresionGain.ToString("F0"));
                        DisplayOperateMes("autoAdaptingGoughGain" + idut.ToString() + " = " + RoughTable_Customer[0][Ix_forAutoAdaptingRoughGain].ToString("F4"));
                        DisplayOperateMes("autoAdaptingPresionGain" + idut.ToString() + " = " + PreciseTable_Customer[0][Ix_forAutoAdaptingPresionGain].ToString("F4"));
                    }

                    /* Rough Gain Code*/
                    bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                    MultiSiteReg0[idut] &= ~bit_op_mask;
                    MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][Ix_forAutoAdaptingRoughGain]);

                    bit_op_mask = bit0_Mask;
                    MultiSiteReg1[idut] &= ~bit_op_mask;
                    MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][Ix_forAutoAdaptingRoughGain]);

                    if (bAutoTrimTest)
                    {
                        DisplayOperateMes("Rough Gain RegValue80 = 0x" + MultiSiteReg0[idut].ToString("X2"));
                        DisplayOperateMes("Rough Gain RegValue81 = 0x" + MultiSiteReg1[idut].ToString("X2"));
                    }

                    /* Presion Gain Code*/
                    bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask | bit3_Mask | bit4_Mask;
                    MultiSiteReg0[idut] &= ~bit_op_mask;
                    MultiSiteReg0[idut] |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_forAutoAdaptingPresionGain]);

                    if (bAutoTrimTest)
                        DisplayOperateMes("Precesion Gain RegValue80 = 0x" + MultiSiteReg0[idut].ToString("X2"));


                    MultiSiteSocketSelect(idut);
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    //RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    EnterNomalMode();
                    //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
                    Delay(Delay_Fuse);
                    dMultiSiteVout0A[idut] = AverageVout();
                    if (bAutoTrimTest)
                        DisplayOperateMes("DUT"+ idut.ToString() +" Vout @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));

                    /* Offset trim code calculate */
                    Vout_0A = dMultiSiteVout0A[idut];
                    //btn_offset_Click(null, null);
                    uint[] regTMultiSite = new uint[3]; 

                    MultiSiteOffsetAlg(regTMultiSite);
                    MultiSiteReg1[idut] |= regTMultiSite[0]; 
                    MultiSiteReg2[idut] |= regTMultiSite[1];
                    MultiSiteReg3[idut] |= regTMultiSite[2];

                    bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                    ix_forOffsetIndex_Rough = 0;
                    ix_forOffsetIndex_Rough = LookupOffsetIndex(MultiSiteReg3[idut] & bit_op_mask, OffsetTableB_Customer);
                    ix_forOffsetIndex_Rough_Complementary = ix_forOffsetIndex_Rough;
                    //DisplayOperateMes("ix_forOffsetIndex_Rough = " + ix_forOffsetIndex_Rough.ToString());
                    DisplayOperateMes("Processing...");
                    /* Repower on 5V */
                    oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
                    //Delay(Delay_Sync);
                    RePower();
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    EnterNomalMode();
                    //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
                    Delay(Delay_Fuse);
                    dMultiSiteVout0A[idut] = AverageVout();
                    DisplayOperateMes("MultiSiteReg3[idut] = 0x" + MultiSiteReg3[idut].ToString("X2"));
                    DisplayOperateMes("ix_forOffsetIndex_Rough = " + ix_forOffsetIndex_Rough.ToString());
                    DisplayOperateMes("dMultiSiteVout0A[idut] = " + dMultiSiteVout0A[idut].ToString("F3"));

                    if (dMultiSiteVout0A[idut] > TargetOffset)
                    {
                        if (ix_forOffsetIndex_Rough == 7)
                            ix_forOffsetIndex_Rough = 7;
                        else if (ix_forOffsetIndex_Rough == 15)
                            ix_forOffsetIndex_Rough = 0;
                        else
                            ix_forOffsetIndex_Rough += 1;
                    }
                    else if (dMultiSiteVout0A[idut] < TargetOffset)
                    {
                        if (ix_forOffsetIndex_Rough == 8)
                            ix_forOffsetIndex_Rough = 8;
                        else if (ix_forOffsetIndex_Rough == 0)
                            ix_forOffsetIndex_Rough = 15;
                        else
                            ix_forOffsetIndex_Rough -= 1;
                    }
                    bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                    MultiSiteReg3[idut] &= ~bit_op_mask;
                    MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough]);
                    //DisplayOperateMes("MultiSiteReg3[idut] = 0x" + MultiSiteReg3[idut].ToString("X2"));

                    RePower();
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    EnterNomalMode();
                    //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
                    Delay(Delay_Fuse);
                    dMultiSiteVout_0A_Complementary = AverageVout();
                    DisplayOperateMes("\r\nMultiSiteReg3[idut] = 0x" + MultiSiteReg3[idut].ToString("X2"));
                    DisplayOperateMes("ix_forOffsetIndex_Rough = " + ix_forOffsetIndex_Rough.ToString());
                    DisplayOperateMes("dMultiSiteVout_0A_Complementary = " + dMultiSiteVout_0A_Complementary.ToString("F3"));

                    if (Math.Abs(dMultiSiteVout0A[idut] - TargetOffset) < Math.Abs(dMultiSiteVout_0A_Complementary - TargetOffset))
                    {
                        bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                        MultiSiteReg3[idut] &= ~bit_op_mask;
                        MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough_Complementary]);
                        DisplayOperateMes("Last MultiSiteReg3[idut] = 0x" + MultiSiteReg3[idut].ToString("X2"));
                    }
                    else
                    {
                        bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                        MultiSiteReg3[idut] &= ~bit_op_mask;
                        MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough]);
                        DisplayOperateMes("Last MultiSiteReg3[idut] = 0x" + MultiSiteReg3[idut].ToString("X2"));
                    }
                        
                    DisplayOperateMes("Processing...");

                    //Fuse
                    oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
                    //Delay(Delay_Sync);
                    RePower();
                    //Delay(Delay_Sync);
                    EnterTestMode();
                    //RegisterWrite(5, new uint[10] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value, 0x84, 0x07 });
                    RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
                    BurstRead(0x80, 5, tempReadback);
                    //DisplayOperateMes("\r\nDUT" + idut.ToString()+"");
                    FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                    DisplayOperateMes("Trim Processing...");
                    Delay(Delay_Fuse);

                    ReloadPreset();
                    Delay(Delay_Operation);
                    BurstRead(0x80, 5, tempReadback);
                    Delay(Delay_Operation);
                    if(tempReadback[4] == 0)
                    {
                        RePower();
                        //Delay(Delay_Sync);
                        EnterTestMode();
                        RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
                        BurstRead(0x80, 5, tempReadback);
                        //DisplayOperateMes("\r\nDUT" + idut.ToString()+"");
                        FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                        DisplayOperateMes("Re-Trim Processing...");
                        Delay(Delay_Fuse);

                        ReloadPreset();
                        Delay(Delay_Operation);
                        BurstRead(0x80, 5, tempReadback);
                        Delay(Delay_Operation);
                    }


                    /* Margianl read, compare with writed code; 
                     * if ( = ), go on
                     * else bMarginal = true; */
                    MarginalReadPreset();
                    Delay(Delay_Operation);
                    BurstRead(0x80, 5, tempReadback);
                    bMarginal = false;
                    if (((tempReadback[0] & 0xE0) != (MultiSiteReg0[idut] & 0xE0)) | (tempReadback[1] & 0x81) != (MultiSiteReg1[idut] & 0x81) |
                        (tempReadback[2] & 0x99) != (MultiSiteReg2[idut] & 0x99) | (tempReadback[3] & 0x83) != (MultiSiteReg3[idut] & 0x83) | (tempReadback[4] < 1)) 
                        bMarginal = true;

                    if (!bMarginal)
                    {
                        DisplayOperateMes("DUT" + idut.ToString("D2") + "Pass! Bin Normal");
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_NORMAL;
                    }
                    else
                    {
                        DisplayOperateMes("DUT" + idut.ToString("D2") + "Pass! Bin Mriginal");
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_MARGINAL;
                    }

                    /* Repower on 5V */
                    oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
                }
            }

            #endregion Adapting algorithm

            #region Bin
            /* Repower on 5V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut] || bDutNoNeedTrim[idut])
                {
                    MultiSiteSocketSelect(idut);
                    Delay(Delay_Fuse);
                    dMultiSiteVout0A[idut] = AverageVout();
                    DisplayOperateMes("Vout[" + idut.ToString("D2") + "] @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));
                }
            }

            if (ProgramMode == 0)
            {
                /* Change Current to IP  */
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                    TrimFinish();
                    return;
                }
            }
            else
            {
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }
            //Delay(Delay_Sync);

            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut] || bDutNoNeedTrim[idut])
                {
                    MultiSiteSocketSelect(idut);
                    Delay(Delay_Fuse);
                    dMultiSiteVoutIP[idut] = AverageVout();
                    DisplayOperateMes("Vout[" + idut.ToString() + "] @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));
                }
            }

            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if (bDutValid[idut] || bDutNoNeedTrim[idut])
                {
                    if (uDutTrimResult[idut] == (uint)PRGMRSULT.DUT_BIN_MARGINAL)
                    {
                        if (TargetOffset * (1 - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - 0.01))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_4;
                            //DisplayOperateMes("Pass! Bin4");
                            //this.lbl_passOrFailed.ForeColor = Color.Green;
                            //this.lbl_passOrFailed.Text = "Pass!";
                        }
                        else if (TargetOffset * (1 - bin2accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin2accuracy / 100d))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_5;
                        }
                        else if (TargetOffset * (1 - bin3accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin3accuracy / 100d))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_6;
                        }

                    }

                    /* bin1,2,3 */
                    //if ((!bMarginal) && (!bSafety))
                    else if (uDutTrimResult[idut] == (uint)PRGMRSULT.DUT_BIN_NORMAL)
                    {
                        if (TargetOffset * (1 - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - 0.01))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_1;
                        }
                        else if (TargetOffset * (1 - bin2accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin2accuracy / 100d))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_2;
                        }
                        else if (TargetOffset * (1 - bin3accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin3accuracy / 100d))
                        {
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_3;
                        }
                    }
                }
            }

            #endregion Bin
            
            #region Display Result and Reset parameters
            for (uint idut = 0; idut < uDutCount; idut++)
            {
                if ( idut<10 )
                    DisplayOperateMes("Dut0"+idut.ToString() + " = " + uDutTrimResult[idut].ToString());
                else
                    DisplayOperateMes("Dut"+idut.ToString() + " = " + uDutTrimResult[idut].ToString());
            }

            MultiSiteDisplayResult(uDutTrimResult);

            //reset vout_0A, vout_IP and power off
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_OFF);
            RestoreReg80ToReg83Value();
            TrimFinish();
            DisplayOperateMes("Next...");
            #endregion Display Result and Reset parameters
        }     
        //Multi-Site
        private void btn_AutomaticaTrim15V_MultiSite(object sender, EventArgs e)
        {
            DialogResult dr;
            bool bMarginal = false;
            bool bSafety = false;
            uint[] tempReadback = new uint[5];
            double dVip_Target = TargetOffset + TargetVoltage_customer;

            DisplayOperateMes("Start...");
            this.lbl_passOrFailed.ForeColor = Color.Black;
            this.lbl_passOrFailed.Text = "START!";

            /* AutoTrim code */
            #region Get module current
            /*  power on */
            RePower();

            Delay(Delay_Operation);

            this.lbl_passOrFailed.Text = "Checking!";

            /* Get module current */
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VCS))
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Set ADC VIN to VCS");
                }
            }
            else
            {
                DisplayOperateMes("Set ADC VIN to VCS failed", Color.Red);
                PowerOff();
                return;
            }

            Delay(Delay_Operation);

            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_SET_CURRENT_SENCE))
            {
                if (bAutoTrimTest)
                {
                    DisplayOperateMes("Set ADC current sensor");
                }
            }
            else
            {
                DisplayOperateMes("Set ADC current sensor failed", Color.Red);
                PowerOff();
                return;
            }

            this.txt_ModuleCurrent_EngT.Text = GetModuleCurrent().ToString("F1");
            this.txt_ModuleCurrent_PreT.Text = this.txt_ModuleCurrent_EngT.Text;

            /* Judge IDD */
            if (GetModuleCurrent() > 100)
            {
                dr = MessageBox.Show(String.Format("Module power is abnormal!"), "Warning", MessageBoxButtons.OK);
                DisplayOperateMes("Module power is abnormal!", Color.Red);

                PowerOff();

                return;
            }
            #endregion

            this.lbl_passOrFailed.Text = "Processing!";

            #region Saturation judgement
            EnterTestMode();
            RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });
            BurstRead(0x80, 5, tempReadback);

            /* Change Current to IP  */
            dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                PowerOff();
                RestoreReg80ToReg83Value();
                return;
            }

            /* Get vout @ IP */
            EnterNomalMode();
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_510OUT);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            Delay(Delay_Operation);
            Vout_IP = AverageVout();
            DisplayOperateMes("Vout @ IP = " + Vout_IP.ToString("F3"));

            /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
            if (Vout_IP > saturationVout)
            {
                DisplayOperateMes("Module Vout is SATURATION!", Color.Red);
                PowerOff();
                RestoreReg80ToReg83Value();
                return;
            }

            /* Get Mout to calc AMPout*/
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_MOUT);
            Delay(Delay_Operation);
            Mout_IP = AverageVout();
            AMPout_IP = - k_slope * Mout_IP + b_offset;
            DisplayOperateMes("Mout @ IP = " + Mout_IP.ToString("F3") );
            DisplayOperateMes("AMPout @ IP = " + AMPout_IP.ToString("F3"));

            #endregion

            #region autoAdaptingGoughGain algorithm

            /* Change Current to 0A */
            dr = MessageBox.Show(String.Format("Please Change Current To 0A"), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                PowerOff();
                RestoreReg80ToReg83Value();
                return;
            }
            Delay(Delay_Operation);
            Mout_0A = AverageVout();
            AMPout_0A = - k_slope * Mout_0A + b_offset;
            DisplayOperateMes("Mout @ 0A = " + Mout_0A.ToString("F3"));
            DisplayOperateMes("AMPout @ 0A = " + AMPout_0A.ToString("F3"));


            /* autoAdaptingGoughGain algorithm*/
            double autoAdaptingGoughGain = 0;
            double autoAdaptingPresionGain = 0;
            double tempG1 = 0;
            double tempG2 = 0;
            int Ix_forAutoAdaptingRoughGain = 0;
            int Ix_forAutoAdaptingPresionGain = 0;
            tempG1 = RoughTable_Customer[0][Ix_ForRoughGainCtrl] / 100d;
            tempG2 = (TargetGain_customer*k_slope / (Math.Abs(Mout_IP - Mout_0A) / IP)) / 1000d;
            autoAdaptingGoughGain = tempG1 * tempG2 * 100d;
            //autoAdaptingGoughGain = 100d * ( TargetGain_customer / ((Vout_IP - Vout_0A)/IP) * 1000d) * (RoughTable_Customer[0][Ix_ForRoughGainCtrl]/100d);

            Ix_forAutoAdaptingRoughGain = LookupRoughGain_Customer(autoAdaptingGoughGain, RoughTable_Customer);

            autoAdaptingPresionGain = 100d * autoAdaptingGoughGain / RoughTable_Customer[0][Ix_forAutoAdaptingRoughGain];

            Ix_forAutoAdaptingPresionGain = LookupPreciseGain_Customer(autoAdaptingPresionGain, PreciseTable_Customer);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("IP = " + IP.ToString("F0"));
                DisplayOperateMes("TargetGain_customer * k_slope = " + (TargetGain_customer*k_slope).ToString("F3"));
                DisplayOperateMes("abs(Mout_IP - Mout_0A)/IP = " + (Math.Abs(Mout_IP - Mout_0A) / IP).ToString("F3"));
                DisplayOperateMes("tempG1 = " + tempG1.ToString("F3"));
                DisplayOperateMes("tempG2 = " + tempG2.ToString("F3"));
                DisplayOperateMes("Ix_forAutoAdaptingRoughGain = " + Ix_forAutoAdaptingRoughGain.ToString("F0"));
                DisplayOperateMes("Ix_forAutoAdaptingPresionGain = " + Ix_forAutoAdaptingPresionGain.ToString("F0"));
                //DisplayOperateMes("RoughTable_Customer[0][Ix_ForRoughGainCtrl]/100d = " + (RoughTable_Customer[0][Ix_ForRoughGainCtrl] / 100d).ToString("F3"));
                //DisplayOperateMes("( TargetGain_customer / (Vout_IP - Vout_0A)*1000d / IP) = " + ((TargetGain_customer / (Vout_IP - Vout_0A) * 1000d / IP)).ToString("F3"));
                DisplayOperateMes("autoAdaptingGoughGain = " + autoAdaptingGoughGain.ToString("F3"));
                DisplayOperateMes("autoAdaptingPresionGain = " + autoAdaptingPresionGain.ToString("F3"));
            }

            /* Rough Gain Code*/
            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= Convert.ToUInt32(RoughTable_Customer[1][Ix_forAutoAdaptingRoughGain]);

            bit_op_mask = bit0_Mask;
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= Convert.ToUInt32(RoughTable_Customer[2][Ix_forAutoAdaptingRoughGain]);

            /* Presion Gain Code*/
            bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask | bit3_Mask | bit4_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_forAutoAdaptingPresionGain]);

            #endregion

            DisplayOperateMes("Processing...");
            this.lbl_passOrFailed.ForeColor = Color.Black;
            this.lbl_passOrFailed.Text = "Processing!";

            #region Offset Trim
            /* Repower on */
            RePower();
            EnterTestMode();

            /* write trim code to regsiters */
            RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });

            EnterNomalMode();
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_MOUT);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            Delay(Delay_Operation);
            Mout_0A = AverageVout();
            AMPout_0A = - k_slope * Mout_0A + b_offset;

            /* Offset trim code calculate */
            //btn_offset_Click(null, null);
            double MoutoffsetTuning = 0;
            MoutoffsetTuning =  b_offset * 100 / Mout_0A;
            Ix_ForOffsetBTable = LookupOffset(ref MoutoffsetTuning, OffsetTableB_Customer);

            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            Reg83Value &= ~bit_op_mask;
            Reg83Value |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("Reg4 Value = " + Reg83Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableB_Customer[1][Ix_ForOffsetBTable]).ToString("X") + ")");
            }

            DisplayOperateMes("Processing...");

            #endregion Offset Trim

            #region Fuse Normal bits and Marginal Safty read
            /* Repower on 6V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
            RePower();
            EnterTestMode();

            /* write trim code to regsiters */
            RegisterWrite(4, new uint[8] { 0x80, Reg80Value, 0x81, Reg81Value, 0x82, Reg82Value, 0x83, Reg83Value });

            /* fuse */
            FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
            DisplayOperateMes("Processing...");
            Delay(Delay_Fuse);

            /* Repower on 5V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            Delay(Delay_Operation);

            /* Margianl read, compare with writed code; 
             * if ( = ), go on
             * else bMarginal = true; */
            MarginalReadPreset();
            //uint[] tempReadback = new uint[5];
            BurstRead(0x80, 5, tempReadback);
            bMarginal = false;
            if ((tempReadback[0] != Reg80Value) | tempReadback[1] != Reg81Value |
                tempReadback[2] != Reg82Value | tempReadback[3] != Reg83Value)
                bMarginal = true;

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config_EngT.Checked = true;

            /* Safety Read, compare with writed code;
             * if ( = ), go on 
             * else bSafety = true; */
            SafetyReadPreset();
            tempReadback = new uint[5];
            BurstRead(0x80, 5, tempReadback);
            bSafety = false;
            if ((tempReadback[0] != Reg80Value) | tempReadback[1] != Reg81Value |
                tempReadback[2] != Reg82Value | tempReadback[3] != Reg83Value)
                bSafety = true;

            #endregion Fuse Normal bits and Marginal Safty read

            #region Fuse master bits and Marginal Safty read
            /* Repower on 6V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
            RePower();
            EnterTestMode();
            Delay(Delay_Operation);
            /* fuse maser bits, write 0x07 to Reg0x84 */
            RegisterWrite(1, new uint[] { 0x84, 0x07 });

            /* Fuse */
            FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
            DisplayOperateMes("Processing...");

            Delay(Delay_Fuse);

            /* Margianl Read master bits*/
            MarginalReadPreset();
            tempReadback = new uint[5];
            BurstRead(0x80, 5, tempReadback);
            //bSafety = false;
            if (tempReadback[4] < 3)
                bMarginal |= true;

            Delay(Delay_Operation);

            /* Safety Read master bits*/
            SafetyReadPreset();
            tempReadback = new uint[5];
            BurstRead(0x80, 5, tempReadback);
            //bSafety = false;
            if (tempReadback[4] < 3)
                bSafety |= true;
            #endregion Fuse master bits and Marginal Safty read

            #region Re-Test
            /* Repower on 5V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);

            Delay(Delay_Operation);

            Vout_0A = AverageVout();

            /* Change Current to IP  */
            dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                PowerOff();
                RestoreReg80ToReg83Value();
                return;
            }

            Vout_IP = AverageVout();
            DisplayOperateMes("Done...");
            #endregion Re-Test

            #region Bin decided
            /* bin1,2,3 */
            if ((!bMarginal) && (!bSafety))
            {
                if (TargetOffset * (1 - 0.01) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.01) && Vout_IP <= dVip_Target * (1 + 0.01) && Vout_IP >= dVip_Target * (1 - 0.01))
                {
                    DisplayOperateMes("Pass! Bin1");
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "Pass!";
                }
                else if (TargetOffset * (1 - 0.03) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.02) && Vout_IP <= dVip_Target * (1 + 0.03) && Vout_IP >= dVip_Target * (1 - 0.02))
                {
                    DisplayOperateMes("Pass! Bin2");
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "Pass!";
                }
                else if (TargetOffset * (1 - 0.06) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.03) && Vout_IP <= dVip_Target * (1 + 0.06) && Vout_IP >= dVip_Target * (1 - 0.03))
                {
                    DisplayOperateMes("Pass! Bin3");
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "Pass!";
                }
                else
                {
                    DisplayOperateMes("Fail!");
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "Fail!";
                }
            }
            /* bin4,5,6 */
            else if (bMarginal == true)
            //else
            {
                if (TargetOffset * (1 - 0.01) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.01) && Vout_IP <= dVip_Target * (1 + 0.01) && Vout_IP >= dVip_Target * (1 - 0.01))
                {
                    DisplayOperateMes("M.R.E! Bin4");
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.R.E!";
                }
                else if (TargetOffset * (1 - 0.03) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.03) && Vout_IP <= dVip_Target * (1 + 0.03) && Vout_IP >= dVip_Target * (1 - 0.03))
                {
                    DisplayOperateMes("M.R.E! Bin5");
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.R.E!";
                }
                else if (TargetOffset * (1 - 0.06) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.06) && Vout_IP <= dVip_Target * (1 + 0.06) && Vout_IP >= dVip_Target * (1 - 0.06))
                {
                    DisplayOperateMes("M.R.E! Bin6");
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.R.E!";
                }
                else
                {
                    DisplayOperateMes("Fail!");
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "Fail!";
                }
            }
            /* bin7,8,9 */
            else
            {
                if (TargetOffset * (1 - 0.01) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.01) && Vout_IP <= dVip_Target * (1 + 0.01) && Vout_IP >= dVip_Target * (1 - 0.01))
                {
                    DisplayOperateMes("Pass! Bin7");
                }
                else if (TargetOffset * (1 - 0.03) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.03) && Vout_IP <= dVip_Target * (1 + 0.03) && Vout_IP >= dVip_Target * (1 - 0.03))
                {
                    DisplayOperateMes("Pass! Bin8");
                }
                else if (TargetOffset * (1 - 0.06) <= Vout_0A && Vout_0A <= TargetOffset * (1 + 0.06) && Vout_IP <= dVip_Target * (1 + 0.06) && Vout_IP >= dVip_Target * (1 - 0.06))
                {
                    DisplayOperateMes("Pass! Bin9");
                }
                else
                {
                    DisplayOperateMes("Fail!");
                }
            }
            #endregion Bin decided

            #region Next
            DisplayOperateMes("Vout @ 0A = " + Vout_0A.ToString("F3"));
            Mout_0A = - k_slope * Vout_0A + b_offset;
            DisplayOperateMes("Mout @ 0A = " + Mout_0A.ToString("F3"));
            DisplayOperateMes("Vout @ IP = " + Vout_IP.ToString("F3"));
            Mout_IP = - k_slope * Vout_IP + b_offset;
            DisplayOperateMes("Mout @ IP = " + Mout_IP.ToString("F3"));

            //reset vout_0A, vout_IP and power off
            Vout_0A = 0;
            Vout_IP = 0;
            Mout_0A = 0;
            Mout_IP = 0;
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_POWER_OFF);

            /* Restore register value to preset */
            RestoreReg80ToReg83Value();

            DisplayOperateMes("Next...");
            #endregion Next
            //this.lbl_passOrFailed.ForeColor = Color.Black;
            //this.lbl_passOrFailed.Text = "Done!";
        }
        //Single Site
        private void AutomaticaTrim_5V_SingleSite()
        {
            #region Define Parameters
            DialogResult dr;
            bool bMarginal = false;
            bool bSafety = false;
            //uint[] tempReadback = new uint[5];
            double dVip_Target = TargetOffset + TargetVoltage_customer;
            double dGainTestMinusTarget = 1;
            double dGainTest = 0;
            ModuleAttribute sDUT;
            sDUT.dIQ = 0;     
            sDUT.dVoutIPNative = 0; 
            sDUT.dVout0ANative = 0;
            sDUT.dVoutIPMiddle = 0;
            sDUT.dVout0AMiddle = 0; 
            sDUT.dVoutIPTrimmed = 0; 
            sDUT.dVout0ATrimmed = 0; 
            sDUT.bDigitalCommFail = false; 
            sDUT.bNormalModeFail = false;
            sDUT.bReadMarginal = false;
            sDUT.bReadSafety = false;
            sDUT.bTrimmed = false;


            //**********************************
            // PARAMETERS DEFINE FOR MULTISITE
            //**********************************
            uint idut = 0;
            uint uDutCount = 16;
            //bool bValidRound = false;
            //bool bSecondCurrentOn = false;
            double dModuleCurrent = 0;
            bool[] bGainBoost = new bool[16];
            bool[] bDutValid = new bool[16];
            bool[] bDutNoNeedTrim = new bool[16];
            uint[] uDutTrimResult = new uint[16];
            double[] dMultiSiteVoutIP = new double[16];
            double[] dMultiSiteVout0A = new double[16];

            /* autoAdaptingGoughGain algorithm*/
            double autoAdaptingGoughGain = 0;
            double autoAdaptingPresionGain = 0;
            double tempG1 = 0;
            double tempG2 = 0;
            double dGainPreset = 0;
            int Ix_forAutoAdaptingRoughGain = 0;
            int Ix_forAutoAdaptingPresionGain = 0;

            int ix_forOffsetIndex_Rough = 0;
            int ix_forOffsetIndex_Rough_Complementary = 0;
            double dMultiSiteVout_0A_Complementary = 0;

            DisplayOperateMes("\r\n**************" + DateTime.Now.ToString() + "**************");
            DisplayOperateMes("Start...");
            this.lbl_passOrFailed.ForeColor = Color.Black;
            this.lbl_passOrFailed.Text = "START!";

            for (uint i = 0; i < uDutCount; i++)
            {
                dMultiSiteVoutIP[i] = 0d;
                dMultiSiteVout0A[i] = 0d;

                MultiSiteReg0[i] = Reg80Value;
                MultiSiteReg1[i] = Reg81Value;
                MultiSiteReg2[i] = Reg82Value;
                MultiSiteReg3[i] = Reg83Value;

                MultiSiteRoughGainCodeIndex[i] = Ix_ForRoughGainCtrl;

                uDutTrimResult[i] = 0u;
                bDutNoNeedTrim[i] = false;
                bDutValid[i] = false;
                bGainBoost[i] = false;
            }
            #endregion Define Parameters

            #region Get module current
            //clear log
            DisplayOperateMesClear();
            /*  power on */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            Delay(Delay_Sync);
            this.lbl_passOrFailed.Text = "Module Current!";
            /* Get module current */
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VCS))
            {
                if (bAutoTrimTest)
                    DisplayOperateMes("Set ADC VIN to VCS");
            }
            else
            {
                DisplayOperateMes("Set ADC VIN to VCS failed", Color.Red);
                PowerOff();
                return;
            }
            Delay(Delay_Sync);
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_SET_CURRENT_SENCE))
            {
                if (bAutoTrimTest)
                    DisplayOperateMes("Set ADC current sensor");
            }

            this.txt_ModuleCurrent_EngT.Text = GetModuleCurrent().ToString("F1");
            this.txt_ModuleCurrent_PreT.Text = this.txt_ModuleCurrent_EngT.Text;


            dModuleCurrent = GetModuleCurrent();
            sDUT.dIQ = dModuleCurrent;
            if (dCurrentDownLimit > dModuleCurrent || dModuleCurrent > dCurrentUpLimit)
            {
                DisplayOperateMes("Module " + " current is " + dModuleCurrent.ToString("F3"), Color.Red);
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_CURRENT_ABNORMAL;
                PowerOff();
                PrintDutAttribute(sDUT);
                MessageBox.Show(String.Format("IDD Error,Confrim MODULE Connection!"), "Try Again", MessageBoxButtons.OK);
                return;
            }
            else
                DisplayOperateMes("Module " + " current is " + dModuleCurrent.ToString("F3"));

            #endregion Get module current

            #region UART Initialize
            if (ProgramMode == 0)
            {
                
                //UART Initialization
                if (oneWrie_device.UARTInitilize(9600, 1))
                    DisplayOperateMes("UART Initilize succeeded!");
                else
                    DisplayOperateMes("UART Initilize failed!");
                //ding hao
                Delay(Delay_Sync);
                //DisplayAutoTrimOperateMes("Delay 300ms");

                //1. Current Remote CTL
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_REMOTE, 0))
                    DisplayOperateMes("Set Current Remote succeeded!");
                else
                    DisplayOperateMes("Set Current Remote failed!");

                //Delay 300ms
                //Thread.Sleep(300);
                Delay(Delay_Sync);
                //DisplayAutoTrimOperateMes("Delay 300ms");

                //2. Current On
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_OUTPUTON, 0))
                    DisplayOperateMes("Set Current On succeeded!");
                else
                    DisplayOperateMes("Set Current On failed!");

                //Delay 300ms
                Delay(Delay_Sync);
                //DisplayOperateMes("Delay 300ms");

                //3. Set Voltage
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETVOLT, 6u))
                    DisplayOperateMes(string.Format("Set Voltage to {0}V succeeded!", 6));
                else
                    DisplayOperateMes(string.Format("Set Voltage to {0}V failed!", 6));


                //Delay 300ms
                Delay(Delay_Sync);
                //DisplayOperateMes("Delay 300ms");


            }
            #endregion UART Initialize

            #region Saturation judgement
            /* Change Current to IP  */
            //dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
            //3. Set Voltage
            if (ProgramMode == 0)
            {
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                    TrimFinish();
                    return;
                }
            }
            else if ( ProgramMode == 1 )
            {
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }

            //Delay(Delay_Sync);
            EnterTestMode();
            //Delay(Delay_Sync);
            BurstRead(0x80, 5, tempReadback);
            if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
            {
                DisplayOperateMes("DUT" + " has been Blown!", Color.Red);
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_TRIMMED_ALREADY;
                TrimFinish();
                sDUT.bTrimmed = true;
                PrintDutAttribute(sDUT);
                this.lbl_passOrFailed.ForeColor = Color.Red;
                this.lbl_passOrFailed.Text = "FAIL!";
                return;
            }

            RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
            BurstRead(0x80, 5, tempReadback);
            if (tempReadback[0] != MultiSiteReg0[idut] || tempReadback[1] != MultiSiteReg1[idut] || tempReadback[2] != MultiSiteReg2[idut] || tempReadback[3] != MultiSiteReg3[idut])
            {
                DisplayOperateMes("DUT digital communication fail!", Color.Red);
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_TRIMMED_ALREADY;
                TrimFinish();
                sDUT.bDigitalCommFail = true;
                PrintDutAttribute(sDUT);
                this.lbl_passOrFailed.ForeColor = Color.Red;
                this.lbl_passOrFailed.Text = "FAIL!";
                return;
            }
            /* Get vout @ IP */
            EnterNomalMode();
            //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            Delay(Delay_Fuse);
            dMultiSiteVoutIP[idut] = AverageVout();
            sDUT.dVoutIPNative = dMultiSiteVoutIP[idut];
            DisplayOperateMes("Vout"  + " @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));

            /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
            if (dMultiSiteVoutIP[idut] > saturationVout)
            {
                DisplayOperateMes("Module"  + " Vout is SATURATION!", Color.Red);
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                TrimFinish();
                PrintDutAttribute(sDUT);
                this.lbl_passOrFailed.ForeColor = Color.Red;
                this.lbl_passOrFailed.Text = "MOA!";
                return;
            }

            #endregion Saturation judgement

            #region Get Vout@0A
            /* Change Current to 0A */
            //3. Set Voltage
            if (ProgramMode == 0)
            {
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", 0u));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", 0u));
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    TrimFinish();
                    return;
                }
            }
            else
            {
                dr = MessageBox.Show(String.Format("Please Change Current To 0A"), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }

            Delay(Delay_Fuse);
            dMultiSiteVout0A[idut] = AverageVout();
            sDUT.dVout0ANative = dMultiSiteVout0A[idut];
            DisplayOperateMes("Vout"  + " @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));

            if (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut] < VoutIPThreshold)
            {
                TrimFinish();
                PrintDutAttribute(sDUT);
                MessageBox.Show(String.Format("Please Conform Current is {0}A!!!", IP), "Try Again", MessageBoxButtons.OK);
                return;
            }

            else if (dMultiSiteVoutIP[idut] < dMultiSiteVout0A[idut] )
            {
                TrimFinish();
                PrintDutAttribute(sDUT);
                MessageBox.Show(String.Format("Please invert IP!"), "Try Again", MessageBoxButtons.OK);
                return;
            }

            if(TargetOffset == 2.5)
            {
                if (dMultiSiteVout0A[idut] < 2.25 || dMultiSiteVout0A[idut] > 2.8)
                {
                    TrimFinish();
                    PrintDutAttribute(sDUT);
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                    //MessageBox.Show(String.Format("Please invert IP!"), "Try Again", MessageBoxButtons.OK);
                    return;
                }
            }
            else if (TargetOffset == 1.65)
            {
                if (dMultiSiteVout0A[idut] < 1.0 || dMultiSiteVout0A[idut] > 2.5)
                {
                    TrimFinish();
                    PrintDutAttribute(sDUT);
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                    //MessageBox.Show(String.Format("Please invert IP!"), "Try Again", MessageBoxButtons.OK);
                    return;
                }
            }

            #endregion  Get Vout@0A

            #region No need Trim case
            if ((TargetOffset - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= (TargetOffset + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= (TargetVoltage_customer + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= (TargetVoltage_customer - 0.01))
            {
                oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
                Delay(Delay_Sync);
                RePower();
                //Delay(Delay_Sync);
                EnterTestMode();
                RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
                BurstRead(0x80, 5, tempReadback);
                /* fuse */
                FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                DisplayOperateMes("Processing...");
                Delay(Delay_Fuse);
                ReloadPreset();
                Delay(Delay_Operation);
                BurstRead(0x80, 5, tempReadback);
                Delay(Delay_Operation);
                /* Margianl read, compare with writed code; 
                    * if ( = ), go on
                    * else bMarginal = true; */
                MarginalReadPreset();
                Delay(Delay_Operation);
                BurstRead(0x80, 5, tempReadback);
                bMarginal = false;

                if (bMASK)
                {
                    if (((tempReadback[0] & 0xE0) != (MultiSiteReg0[idut] & 0xE0)) | (tempReadback[1] & 0x81) != (MultiSiteReg1[idut] & 0x81) |
                        (tempReadback[2] & 0x99) != (MultiSiteReg2[idut] & 0x99) | (tempReadback[3] & 0x83) != (MultiSiteReg3[idut] & 0x83) | (tempReadback[4] < 1))
                        bMarginal = true;
                }
                else
                {
                    if (((tempReadback[0] & 0xFF) != (MultiSiteReg0[idut] & 0xFF)) | (tempReadback[1] & 0xFF) != (MultiSiteReg1[idut] & 0xFF) |
                        (tempReadback[2] & 0xFF) != (MultiSiteReg2[idut] & 0xFF) | (tempReadback[3] & 0xFF) != (MultiSiteReg3[idut] & 0xFF) | (tempReadback[4] < 7))
                        bMarginal = true;
                }

                if (bSAFEREAD)
                {
                    Delay(Delay_Operation);
                    SafetyReadPreset();
                    Delay(Delay_Operation);
                    BurstRead(0x80, 5, tempReadback);
                    bSafety = false;
                    if (((tempReadback[0] & 0xFF) != (MultiSiteReg0[idut] & 0xFF)) | (tempReadback[1] & 0xFF) != (MultiSiteReg1[idut] & 0xFF) |
                            (tempReadback[2] & 0xFF) != (MultiSiteReg2[idut] & 0xFF) | (tempReadback[3] & 0xFF) != (MultiSiteReg3[idut] & 0xFF) | (tempReadback[4] < 7))
                        bSafety = true;
                }

                sDUT.bReadMarginal = bMarginal;
                sDUT.bReadSafety = bSafety;

                if (!(bMarginal|bSafety))
                {
                    DisplayOperateMes("DUT" + idut.ToString() + "Pass! Bin Normal");
                    //uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_NORMAL;
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_1;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "PASS!";
                    DisplayOperateMes("Bin" + " = " + uDutTrimResult[idut].ToString());
                    DisplayOperateMes("Marginal Read ->" + bMarginal.ToString());
                    DisplayOperateMes("Safety REad ->" + bSafety.ToString());
                    MultiSiteDisplayResult(uDutTrimResult);
                    TrimFinish();
                    PrintDutAttribute(sDUT);
                    return;
                }
                else
                {
                    DisplayOperateMes("DUT" + idut.ToString() + "Pass! Bin Mriginal");
                    //uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_MARGINAL;
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_4;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    if (bMRE)
                        this.lbl_passOrFailed.Text = "M.R.E!";
                    else
                        this.lbl_passOrFailed.Text = "PASS!";

                    DisplayOperateMes("Bin" + " = " + uDutTrimResult[idut].ToString());
                    DisplayOperateMes("Marginal Read ->" + bMarginal.ToString());
                    DisplayOperateMes("Safety REad ->" + bSafety.ToString());
                    MultiSiteDisplayResult(uDutTrimResult);
                    TrimFinish();
                    PrintDutAttribute(sDUT);
                    return;
                }

            }
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);

            #endregion No need Trim case

            #region For low sensitivity case, with IP

            dGainTest = 1000d * (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP;
            if (dGainTest < (TargetGain_customer * ThresholdOfGain))
            {
                dGainTestMinusTarget = dGainTest / TargetGain_customer;
                dGainPreset = RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]] / 100d;

                if (this.cmb_IPRange_PreT.SelectedItem.ToString() == "1.5x610")
                {
                    if (dGainTestMinusTarget >= dGainPreset)
                    {
                        MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer(TargetGain_customer * 100d / dGainTest * dGainPreset, RoughTable_Customer);
                        /* Rough Gain Code*/
                        bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                        MultiSiteReg0[idut] &= ~bit_op_mask;
                        MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);

                        bit_op_mask = bit0_Mask;
                        MultiSiteReg1[idut] &= ~bit_op_mask;
                        MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);
                    }
                    else
                    {
                        DisplayOperateMes("DUT" + idut.ToString() + " Sensitivity is NOT enough!", Color.Red);
                        bDutValid[idut] = false;
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_LOW_SENSITIVITY;
                        TrimFinish();
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "MOA!";
                        PrintDutAttribute(sDUT);
                        return;
                    }

                }
                else
                {
                    if (dGainTestMinusTarget >= dGainPreset)
                    {
                        MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer(TargetGain_customer * 100d / dGainTest * dGainPreset, RoughTable_Customer);
                        /* Rough Gain Code*/
                        bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                        MultiSiteReg0[idut] &= ~bit_op_mask;
                        MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);

                        bit_op_mask = bit0_Mask;
                        MultiSiteReg1[idut] &= ~bit_op_mask;
                        MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);
                    }
                    else
                    {
                        if (dGainTest * 1.5 / dGainPreset >= (TargetGain_customer * ThresholdOfGain))
                        {
                            MultiSiteRoughGainCodeIndex[idut] = (uint)LookupRoughGain_Customer((TargetGain_customer * 100d / (dGainTest * 1.5d) * dGainPreset), RoughTable_Customer);
                            MultiSiteRoughGainCodeIndex[idut] -= 1;
                            MultiSiteReg3[idut] |= 0xC0;
                            /* Rough Gain Code*/
                            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                            MultiSiteReg0[idut] &= ~bit_op_mask;
                            MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);

                            bit_op_mask = bit0_Mask;
                            MultiSiteReg1[idut] &= ~bit_op_mask;
                            MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);
                        }
                        else
                        {
                            DisplayOperateMes("DUT" + idut.ToString() + " Sensitivity is NOT enough!", Color.Red);
                            uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_LOW_SENSITIVITY;
                            //PowerOff();
                            //RestoreReg80ToReg83Value();
                            TrimFinish();
                            this.lbl_passOrFailed.ForeColor = Color.Red;
                            this.lbl_passOrFailed.Text = "MOA!";
                            PrintDutAttribute(sDUT);
                            return;
                        }
                    }
                }


                DisplayOperateMes("RoughGainCodeIndex of DUT" + " = " + MultiSiteRoughGainCodeIndex[idut].ToString("F0"));
                DisplayOperateMes("SelectedRoughGain = " + RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]].ToString());
                DisplayOperateMes("CalcCode:");
                DisplayOperateMes("0x80 = 0x" + MultiSiteReg0[idut].ToString("X2"));
                DisplayOperateMes("0x81 = 0x" + MultiSiteReg1[idut].ToString("X2"));
                DisplayOperateMes("0x82 = 0x" + MultiSiteReg2[idut].ToString("X2"));
                DisplayOperateMes("0x83 = 0x" + MultiSiteReg3[idut].ToString("X2"));

                /* Change Current to IP  */
                //3. Set Voltage
                if (ProgramMode == 0)
                {
                    if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                        DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                    else
                    {
                        DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        TrimFinish();
                        return;
                    }
                }
                else
                {
                    dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        PowerOff();
                        RestoreReg80ToReg83Value();
                        return;
                    }
                }
                /*  power on */
                RePower();
                EnterTestMode();
                RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                BurstRead(0x80, 5, tempReadback);
                /* Get vout @ IP */
                EnterNomalMode();
                Delay(Delay_Fuse);
                dMultiSiteVoutIP[idut] = AverageVout();
                sDUT.dVoutIPMiddle = dMultiSiteVoutIP[idut];
                DisplayOperateMes("Vout" + " @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));


                /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
                if (dMultiSiteVoutIP[idut] > saturationVout)
                {
                    //DisplayOperateMes("Module" + " Vout is SATURATION!", Color.Red);
                    //uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                    //TrimFinish();
                    //this.lbl_passOrFailed.ForeColor = Color.Red;
                    //this.lbl_passOrFailed.Text = "MOA!";
                    //PrintDutAttribute(sDUT);
                    //return;

                    //decrease gain preset
                    MultiSiteRoughGainCodeIndex[idut] -= 1;
                    /* Rough Gain Code*/
                    bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
                    MultiSiteReg0[idut] &= ~bit_op_mask;
                    MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][MultiSiteRoughGainCodeIndex[idut]]);

                    bit_op_mask = bit0_Mask;
                    MultiSiteReg1[idut] &= ~bit_op_mask;
                    MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][MultiSiteRoughGainCodeIndex[idut]]);

                    /*  power on */
                    RePower();
                    EnterTestMode();
                    RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
                    BurstRead(0x80, 5, tempReadback);
                    /* Get vout @ IP */
                    EnterNomalMode();
                    Delay(Delay_Fuse);
                    dMultiSiteVoutIP[idut] = AverageVout();
                    sDUT.dVoutIPMiddle = dMultiSiteVoutIP[idut];
                    DisplayOperateMes("Vout" + " @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));

                    /*Judge PreSet gain; delta Vout target >= delta Vout test * 86.07% */
                    if (dMultiSiteVoutIP[idut] > saturationVout)
                    {
                        DisplayOperateMes("Module" + " Vout is SATURATION!", Color.Red);
                        uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_VOUT_SATURATION;
                        TrimFinish();
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "MOA!";
                        PrintDutAttribute(sDUT);
                        return;
                    }
                }

                /* Change Current to 0A */
                //3. Set Voltage
                if (ProgramMode == 0)
                {
                    if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u))
                        DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", 0u));
                    else
                    {
                        DisplayOperateMes(string.Format("Set Current to {0}A failed!", 0u));
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        TrimFinish();
                        return;
                    }
                }
                else
                {
                    dr = MessageBox.Show(String.Format("Please Change Current To 0A"), "Change Current", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                        PowerOff();
                        RestoreReg80ToReg83Value();
                        return;
                    }
                }

                /*  power on */
                Delay(Delay_Fuse);
                this.lbl_passOrFailed.Text = "Processing!";
                dMultiSiteVout0A[idut] = AverageVout();
                sDUT.dVout0AMiddle = dMultiSiteVout0A[idut];
                DisplayOperateMes("Vout" + " @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));
            }
           
            #endregion For low sensitivity case, with IP

            #region Adapting algorithm

            tempG1 = RoughTable_Customer[0][MultiSiteRoughGainCodeIndex[idut]] / 100d;
            tempG2 = (TargetGain_customer / ((dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP)) / 1000d;

            autoAdaptingGoughGain = tempG1 * tempG2 * 100d;
            DisplayOperateMes("TuningGoughGain = " + autoAdaptingGoughGain.ToString("F3"));

            Ix_forAutoAdaptingRoughGain = LookupRoughGain_Customer(autoAdaptingGoughGain, RoughTable_Customer);
            autoAdaptingPresionGain = 100d * autoAdaptingGoughGain / RoughTable_Customer[0][Ix_forAutoAdaptingRoughGain];
            Ix_forAutoAdaptingPresionGain = LookupPreciseGain_Customer(autoAdaptingPresionGain, PreciseTable_Customer);
            if (bAutoTrimTest)
            {
                DisplayOperateMes("IP = " + IP.ToString("F0"));
                DisplayOperateMes("TargetGain_customer" + idut.ToString() + " = " + TargetGain_customer.ToString("F4"));
                DisplayOperateMes("(dMultiSiteVoutIP - dMultiSiteVout0A)/IP = " + ((dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) / IP).ToString("F4"));
                DisplayOperateMes("tempG1" + idut.ToString() + " = " + tempG1.ToString("F4"));
                DisplayOperateMes("tempG2" + idut.ToString() + " = " + tempG2.ToString("F4"));
                DisplayOperateMes("Ix_forAutoAdaptingRoughGain" + idut.ToString() + " = " + Ix_forAutoAdaptingRoughGain.ToString("F0"));
                DisplayOperateMes("Ix_forAutoAdaptingPresionGain" + idut.ToString() + " = " + Ix_forAutoAdaptingPresionGain.ToString("F0"));
                DisplayOperateMes("autoAdaptingGoughGain" + idut.ToString() + " = " + RoughTable_Customer[0][Ix_forAutoAdaptingRoughGain].ToString("F4"));
                DisplayOperateMes("autoAdaptingPresionGain" + idut.ToString() + " = " + PreciseTable_Customer[0][Ix_forAutoAdaptingPresionGain].ToString("F4"));
            }

            /* Rough Gain Code*/
            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
            MultiSiteReg0[idut] &= ~bit_op_mask;
            MultiSiteReg0[idut] |= Convert.ToUInt32(RoughTable_Customer[1][Ix_forAutoAdaptingRoughGain]);

            bit_op_mask = bit0_Mask;
            MultiSiteReg1[idut] &= ~bit_op_mask;
            MultiSiteReg1[idut] |= Convert.ToUInt32(RoughTable_Customer[2][Ix_forAutoAdaptingRoughGain]);

            if (bAutoTrimTest)
            {
                DisplayOperateMes("Rough Gain RegValue80 = 0x" + MultiSiteReg0[idut].ToString("X2"));
                DisplayOperateMes("Rough Gain RegValue81 = 0x" + MultiSiteReg1[idut].ToString("X2"));
            }

            /* Presion Gain Code*/
            bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask | bit3_Mask | bit4_Mask;
            MultiSiteReg0[idut] &= ~bit_op_mask;
            MultiSiteReg0[idut] |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_forAutoAdaptingPresionGain]);

            if (bAutoTrimTest)
                DisplayOperateMes("Precesion Gain RegValue80 = 0x" + MultiSiteReg0[idut].ToString("X2"));

            RePower();
            EnterTestMode();
            RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
            EnterNomalMode();
            //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            Delay(Delay_Fuse);
            dMultiSiteVout0A[idut] = AverageVout();
            if (bAutoTrimTest)
                DisplayOperateMes("DUT" + " Vout @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));

            /* Offset trim code calculate */
            Vout_0A = dMultiSiteVout0A[idut];
            //btn_offset_Click(null, null);
            uint[] regTMultiSite = new uint[3];

            MultiSiteOffsetAlg(regTMultiSite);
            MultiSiteReg1[idut] |= regTMultiSite[0];
            MultiSiteReg2[idut] |= regTMultiSite[1];
            MultiSiteReg3[idut] |= regTMultiSite[2];

            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            ix_forOffsetIndex_Rough = 0;
            ix_forOffsetIndex_Rough = LookupOffsetIndex(MultiSiteReg3[idut] & bit_op_mask, OffsetTableB_Customer);
            ix_forOffsetIndex_Rough_Complementary = ix_forOffsetIndex_Rough;
            DisplayOperateMes("\r\nProcessing...");

            /* Repower on 5V */
            //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            //Delay(Delay_Sync);
            EnterTestMode();
            RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
            EnterNomalMode();
            //oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            Delay(Delay_Fuse);
            dMultiSiteVout0A[idut] = AverageVout();
            DisplayOperateMes("MultiSiteReg3 = 0x" + MultiSiteReg3[idut].ToString("X2"));
            DisplayOperateMes("ix_forOffsetIndex_Rough = " + ix_forOffsetIndex_Rough.ToString());
            DisplayOperateMes("dMultiSiteVout0A = " + dMultiSiteVout0A[idut].ToString("F3"));

            if (dMultiSiteVout0A[idut] > TargetOffset)
            {
                if (ix_forOffsetIndex_Rough == 7)
                    ix_forOffsetIndex_Rough = 7;
                else if (ix_forOffsetIndex_Rough == 15)
                    ix_forOffsetIndex_Rough = 0;
                else
                    ix_forOffsetIndex_Rough += 1;
            }
            else if (dMultiSiteVout0A[idut] < TargetOffset)
            {
                if (ix_forOffsetIndex_Rough == 8)
                    ix_forOffsetIndex_Rough = 8;
                else if (ix_forOffsetIndex_Rough == 0)
                    ix_forOffsetIndex_Rough = 15;
                else
                    ix_forOffsetIndex_Rough -= 1;
            }
            bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
            MultiSiteReg3[idut] &= ~bit_op_mask;
            MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough]);

            RePower();
            EnterTestMode();
            RegisterWrite(4, new uint[8] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut] });
            EnterNomalMode();
            Delay(Delay_Fuse);
            dMultiSiteVout_0A_Complementary = AverageVout();
            DisplayOperateMes("\r\nMultiSiteReg3 = 0x" + MultiSiteReg3[idut].ToString("X2"));
            DisplayOperateMes("ix_forOffsetIndex_Rough = " + ix_forOffsetIndex_Rough.ToString());
            DisplayOperateMes("dMultiSiteVout_0A_Complementary = " + dMultiSiteVout_0A_Complementary.ToString("F3"));

            if (Math.Abs(dMultiSiteVout0A[idut] - TargetOffset) < Math.Abs(dMultiSiteVout_0A_Complementary - TargetOffset))
            {
                bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                MultiSiteReg3[idut] &= ~bit_op_mask;
                MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough_Complementary]);
                DisplayOperateMes("Last MultiSiteReg3 = 0x" + MultiSiteReg3[idut].ToString("X2"));
            }
            else
            {
                bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                MultiSiteReg3[idut] &= ~bit_op_mask;
                MultiSiteReg3[idut] |= Convert.ToUInt32(OffsetTableB_Customer[1][ix_forOffsetIndex_Rough]);
                DisplayOperateMes("Last MultiSiteReg3 = 0x" + MultiSiteReg3[idut].ToString("X2"));
            }

            DisplayOperateMes("Processing...");

            //Fuse
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
            RePower();
            EnterTestMode();
            RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
            BurstRead(0x80, 5, tempReadback);
            FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
            DisplayOperateMes("Trimming...");
            Delay(Delay_Fuse);

            ReloadPreset();
            Delay(Delay_Operation);
            BurstRead(0x80, 5, tempReadback);
            if (tempReadback[4] == 0)
            {
                RePower();
                EnterTestMode();
                RegisterWrite(5, new uint[10] { 0x80, MultiSiteReg0[idut], 0x81, MultiSiteReg1[idut], 0x82, MultiSiteReg2[idut], 0x83, MultiSiteReg3[idut], 0x84, 0x07 });
                BurstRead(0x80, 5, tempReadback);
                FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                DisplayOperateMes("Trimming...");
                Delay(Delay_Fuse);
            }
            Delay(Delay_Operation);
            /* Margianl read, compare with writed code; 
                * if ( = ), go on
                * else bMarginal = true; */
            MarginalReadPreset();
            Delay(Delay_Operation);
            BurstRead(0x80, 5, tempReadback);
            bMarginal = false;
            if (bMASK)
            {
                if (((tempReadback[0] & 0xE0) != (MultiSiteReg0[idut] & 0xE0)) | (tempReadback[1] & 0x81) != (MultiSiteReg1[idut] & 0x81) |
                    (tempReadback[2] & 0x99) != (MultiSiteReg2[idut] & 0x99) | (tempReadback[3] & 0x83) != (MultiSiteReg3[idut] & 0x83) | (tempReadback[4] < 1))
                    bMarginal = true;
            }
            else
            {
                if (((tempReadback[0] & 0xFF) != (MultiSiteReg0[idut] & 0xFF)) | (tempReadback[1] & 0xFF) != (MultiSiteReg1[idut] & 0xFF) |
                        (tempReadback[2] & 0xFF) != (MultiSiteReg2[idut] & 0xFF) | (tempReadback[3] & 0xFF) != (MultiSiteReg3[idut] & 0xFF) | (tempReadback[4] < 7))
                    bMarginal = true;
            }

            if (bSAFEREAD)
            {
                Delay(Delay_Operation);
                SafetyReadPreset();
                Delay(Delay_Operation);
                BurstRead(0x80, 5, tempReadback);
                bSafety = false;
                if (((tempReadback[0] & 0xFF) != (MultiSiteReg0[idut] & 0xFF)) | (tempReadback[1] & 0xFF) != (MultiSiteReg1[idut] & 0xFF) |
                        (tempReadback[2] & 0xFF) != (MultiSiteReg2[idut] & 0xFF) | (tempReadback[3] & 0xFF) != (MultiSiteReg3[idut] & 0xFF) | (tempReadback[4] < 7))
                    bSafety = true;
            }

            sDUT.bReadMarginal = bMarginal;
            sDUT.bReadSafety = bSafety;

            if (!(bMarginal | bSafety))
            {
                DisplayOperateMes("DUT" + "Pass! Bin Normal");
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_NORMAL;
            }
            else
            {
                DisplayOperateMes("DUT" + "Pass! Bin Mriginal");
                uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_MARGINAL;
            }
            
            #endregion Adapting algorithm

            #region Bin
            /* Repower on 5V */
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);

            Delay(Delay_Operation);
            dMultiSiteVout0A[idut] = AverageVout();
            sDUT.dVout0ATrimmed = dMultiSiteVout0A[idut];
            DisplayOperateMes("Vout" + " @ 0A = " + dMultiSiteVout0A[idut].ToString("F3"));            

            /* Change Current to IP  */
            if (ProgramMode == 0)
            {
                if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                    DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
                else
                {
                    DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    TrimFinish();
                    return;
                }
            }
            else
            {
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", IP), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    DisplayOperateMes("AutoTrim Canceled!", Color.Red);
                    PowerOff();
                    RestoreReg80ToReg83Value();
                    return;
                }
            }

            Delay(Delay_Fuse);
            dMultiSiteVoutIP[idut] = AverageVout();
            sDUT.dVoutIPTrimmed = dMultiSiteVoutIP[idut];
            DisplayOperateMes("Vout"  + " @ IP = " + dMultiSiteVoutIP[idut].ToString("F3"));

            if (uDutTrimResult[idut] == (uint)PRGMRSULT.DUT_BIN_MARGINAL)
            {
                if (TargetOffset * (1 - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - 0.01))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_4;      
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    if (bMRE)
                        this.lbl_passOrFailed.Text = "M.R.E!";
                    else
                        this.lbl_passOrFailed.Text = "PASS!";
                }
                else if (TargetOffset * (1 - bin2accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin2accuracy / 100d))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_5;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    if (bMRE)
                        this.lbl_passOrFailed.Text = "M.R.E!";
                    else
                        this.lbl_passOrFailed.Text = "PASS!";
                }
                else if (TargetOffset * (1 - bin3accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin3accuracy / 100d))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_6;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    if (bMRE)
                        this.lbl_passOrFailed.Text = "M.R.E!";
                    else
                        this.lbl_passOrFailed.Text = "PASS!";
                }
                else
                {
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                }

            }

            /* bin1,2,3 */
            //if ((!bMarginal) && (!bSafety))
            else if (uDutTrimResult[idut] == (uint)PRGMRSULT.DUT_BIN_NORMAL)
            {
                if (TargetOffset * (1 - 0.01) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + 0.01) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - 0.01))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_1;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "PASS!";
                }
                else if (TargetOffset * (1 - bin2accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin2accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin2accuracy / 100d))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_2;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "PASS!";
                }
                else if (TargetOffset * (1 - bin3accuracy / 100d) <= dMultiSiteVout0A[idut] && dMultiSiteVout0A[idut] <= TargetOffset * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) <= TargetVoltage_customer * (1 + bin3accuracy / 100d) && (dMultiSiteVoutIP[idut] - dMultiSiteVout0A[idut]) >= TargetVoltage_customer * (1 - bin3accuracy / 100d))
                {
                    uDutTrimResult[idut] = (uint)PRGMRSULT.DUT_BIN_3;
                    this.lbl_passOrFailed.ForeColor = Color.Green;
                    this.lbl_passOrFailed.Text = "PASS!";
                }
                else
                {
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                }
            }
                         
            #endregion Bin

            #region Display Result and Reset parameters
            DisplayOperateMes("Bin" + " = " + uDutTrimResult[idut].ToString());
            MultiSiteDisplayResult(uDutTrimResult);
            TrimFinish();
            PrintDutAttribute(sDUT);
            DisplayOperateMes("Next...");
            #endregion Display Result and Reset parameters
        }
        //Single Site
        private void AutomaticaTrim_15V_SingleSite()
        {
            return;
        }
         
        private double abs(double p)
        {
            throw new NotImplementedException();
        }


        //sel_vr button
        private void btn_sel_vr_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x82;
            _reg_Value = 0x08;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_nc_1x_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x83;
            _reg_Value = 0x01;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write NC_1X", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_ch_ck_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x82;
            _reg_Value = 0x80;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_sel_cap_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x81;
            _reg_Value = 0x08;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void txt_dev_addr_onewire_EngT_TextChanged(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = this.txt_dev_addr_onewire_EngT.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                this.DeviceAddress = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                temp = string.Format("Device address set failed, will use default adrress {0}", this.DeviceAddress);
                DisplayOperateMes(temp, Color.Red);
                this.txt_dev_addr_onewire_EngT.Text = "0x" + this.DeviceAddress.ToString("X2");
            }
            finally 
            {
                //this.txt_dev_addr_onewire_EngT.Text = "0x" + this.DeviceAddress.ToString("X2");
            }
        }

        private void btn_Reset_EngT_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Flash result->{0}", oneWrie_device.ResetBoard());
        }

        private void btn_ModuleCurrent_EngT_Click(object sender, EventArgs e)
        {
            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VCS))
                DisplayOperateMes("Set ADC VIN to VCS");
            else
                DisplayOperateMes("Set ADC VIN to VCS failed",Color.Red);

            if (oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_SET_CURRENT_SENCE))
                DisplayOperateMes("Set ADC current sensor");
            else
                DisplayOperateMes("Set ADC current sensor failed", Color.Red);

            this.txt_ModuleCurrent_EngT.Text = GetModuleCurrent().ToString("F1");
            this.txt_ModuleCurrent_PreT.Text = this.txt_ModuleCurrent_EngT.Text;
        }

        private void txt_sampleNum_EngT_TextChanged(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = this.txt_sampleNum_EngT.Text;
                SampleRateNum = UInt32.Parse((temp == "" ? "0" : temp));
            }
            catch
            {
                temp = string.Format("Sample rate number set failed, will use default value {0}", this.SampleRateNum);
                DisplayOperateMes(temp, Color.Red);
            }
            finally 
            {
                this.txt_sampleNum_EngT.Text = this.SampleRateNum.ToString();
            }
        }

        private void txt_sampleRate_EngT_TextChanged(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = this.txt_sampleRate_EngT.Text;
                SampleRate = UInt32.Parse((temp == "" ? "0" : temp));   //Get the KHz value
                SampleRate *= 1000;     //Change to Hz
            }
            catch
            {
                temp = string.Format("Sample rate set failed, will use default value {0}", this.SampleRate/1000);
                DisplayOperateMes(temp, Color.Red);
            }
            finally
            {
                this.txt_sampleRate_EngT.Text = (this.SampleRate / 1000).ToString();
            }
        }

        private void btn_VoutIP_EngT_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn_EngT.Checked = true;
            rbt_signalPathSeting_Vout_EngT.Checked = true;

            Vout_IP = AverageVout();
            DisplayOperateMes("Vout @ IP = " + Vout_IP.ToString("F3"));
        }

        private void btn_Vout0A_EngT_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn_EngT.Checked = true;
            rbt_signalPathSeting_Vout_EngT.Checked = true;

            Vout_0A = AverageVout();
            DisplayOperateMes("Vout @ 0A = " + Vout_0A.ToString("F3"));
        }

        private void btn_Vout_PreT_Click(object sender, EventArgs e)
        {
            RePower();
            MultiSiteSocketSelect(0);
            EnterTestMode();

            int wrNum = 4;
            uint[] data = new uint[2 * wrNum];
            data[0] = 0x80;
            data[1] = Reg80Value;
            data[2] = 0x81;
            data[3] = Reg81Value;
            data[4] = 0x82;
            data[5] = Reg82Value;
            data[6] = 0x83;
            data[7] = Reg83Value;

            if (!RegisterWrite(wrNum, data))
               DisplayOperateMes("Register write failed!", Color.Red);

            EnterNomalMode();

            Delay(Delay_Fuse);

            txt_PresetVoutIP_PreT.Text = AverageVout().ToString("F3");
        }

        private void btn_GainCtrlPlus_PreT_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);

            //RePower();

            //EnterTestMode();

            if (Ix_ForRoughGainCtrl < 15)
                Ix_ForRoughGainCtrl++;

            int wrNum = 4;
            uint[] data = new uint[2 * wrNum];
            data[0] = 0x80;
            data[1] = Convert.ToUInt32(RoughTable_Customer[1][Ix_ForRoughGainCtrl]);     //Reg0x80
            data[2] = 0x81;
            data[3] = Convert.ToUInt32(RoughTable_Customer[2][Ix_ForRoughGainCtrl]);   //Reg0x81
            data[4] = 0x82;
            data[5] = Reg82Value;                                                        //Reg0x82
            data[6] = 0x83;
            data[7] = Reg83Value;                                                        //Reg0x83

            //back up to register 
            /* bit5 & bit6 & bit7 of 0x80 */
            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= data[1];

            /* bit0 of 0x81 */
            bit_op_mask = bit0_Mask;
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= data[3];

            //if (!RegisterWrite(wrNum, data))
             //   DisplayOperateMes("Register write failed!", Color.Red);

            //EnterNomalMode();
            //txt_PresetVoutIP_PreT.Text = AverageVout().ToString("F3");

            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
        }

        private void btn_GainCtrlMinus_PreT_Click(object sender, EventArgs e)
        {
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);

            //RePower();

            //EnterTestMode();

            if (Ix_ForRoughGainCtrl > 0)
                Ix_ForRoughGainCtrl--;

            int wrNum = 4;
            uint[] data = new uint[2 * wrNum];
            data[0] = 0x80;
            data[1] = Convert.ToUInt32(RoughTable_Customer[1][Ix_ForRoughGainCtrl]);     //Reg0x80
            data[2] = 0x81;
            data[3] = Convert.ToUInt32(RoughTable_Customer[2][Ix_ForRoughGainCtrl]);     //Reg0x81
            data[4] = 0x82;
            data[5] = Reg82Value;                                                        //Reg0x82
            data[6] = 0x83;
            data[7] = Reg83Value;                                                        //Reg0x83

            //back up to register 
            /* bit5 & bit6 & bit7 of 0x80 */
            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= data[1];

            /* bit0 of 0x81 */
            bit_op_mask = bit0_Mask;
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= data[3];

            //if (!RegisterWrite(wrNum, data))
            //    DisplayOperateMes("Register write failed!", Color.Red);

            //EnterNomalMode();
            //txt_PresetVoutIP_PreT.Text = AverageVout().ToString("F3");

            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
        }

        private void cmb_Module_EngT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuleTypeIndex = (sender as ComboBox).SelectedIndex;

            //if (ModuleTypeIndex == 2)
            //{
            //    TargetOffset = 1.65;
            //    saturationVout = 3.25;
            //}
            //else if (ModuleTypeIndex == 1 )
            //{
            //    TargetOffset = 2.5;
            //    saturationVout = 4.9;
            //}
            //else 
            //{
            //    //TargetOffset = 2.5;
            //    saturationVout = 4.9;
            //}
        }

        private void numUD_SlopeK_ValueChanged(object sender, EventArgs e)
        {
            this.k_slope = (double)this.numUD_SlopeK.Value;
        }

        private void numUD_OffsetB_ValueChanged(object sender, EventArgs e)
        {
            this.b_offset = (double)this.numUD_OffsetB.Value;
        }

        private void txt_IP_EngT_TextChanged(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = (sender as TextBox).Text;
                this.IP = double.Parse(temp); 
            }
            catch
            {
                temp = string.Format("IP set failed, will use default value {0}", this.IP);
                DisplayOperateMes(temp, Color.Red);
            }
            finally
            {
                this.IP = this.IP;  //force update GUI
            }

            TargetGain_customer = targetVoltage_customer * 1000d / IP;
        }

        private void cmb_SensitivityAdapt_PreT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit0 & bit1 of 0x83 */
            bit_op_mask = bit0_Mask | bit1_Mask;
            uint[] valueTable = new uint[3]
            {
                0x0,
                0x03,
                0x02
            };

            int ix_TableStart = this.cmb_SensitivityAdapt_PreT.SelectedIndex;
            //back up to register and update GUI
            Reg83Value &= ~bit_op_mask;
            Reg83Value |= valueTable[ix_TableStart];
            this.txt_SensitivityAdapt_AutoT.Text = this.cmb_SensitivityAdapt_PreT.SelectedItem.ToString();
        }

        private void cmb_TempCmp_PreT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit4 & bit5 & bit6 of 0x81 */
            bit_op_mask = bit4_Mask | bit5_Mask | bit6_Mask;
            uint[] valueTable = new uint[8]
            {
                0x0,
                0x10,
                0x20,
                0x30,
                0x40,
                0x50,
                0x60,
                0x70
            };

            int ix_TableStart = this.cmb_TempCmp_PreT.SelectedIndex;
            //back up to register and update GUI
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= valueTable[ix_TableStart];            
            this.txt_TempComp_AutoT.Text = this.cmb_TempCmp_PreT.SelectedItem.ToString();
        }

        private void cmb_IPRange_PreT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit7 of 0x82 and 0x83 */
            bit_op_mask = bit7_Mask | bit6_Mask;
            uint[] valueTable = new uint[10]
            {
                0x0,0x0,
                0x0,0x40,
                0x0,0x80,
                0x0,0xC0,
                0x80,0x0 
            };

            int ix_TableStart = this.cmb_IPRange_PreT.SelectedIndex * 2;
            //back up to register and update GUI
            Reg82Value &= ~bit7_Mask;
            Reg82Value |= valueTable[ix_TableStart];
            Reg83Value &= ~bit_op_mask;
            Reg83Value |= valueTable[ix_TableStart + 1];
            this.txt_IPRange_AutoT.Text = this.cmb_IPRange_PreT.SelectedItem.ToString();
        }

        private void cmb_SensingDirection_EngT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit5 & bit6 of 0x82 */
            bit_op_mask = bit5_Mask | bit6_Mask;
            uint[] valueTable = new uint[4]
            {
                0x0,
                0x20,
                0x40,
                0x60
            };

            int ix_TableStart = this.cmb_SensingDirection_EngT.SelectedIndex;
            //back up to register and update GUI
            Reg82Value &= ~bit_op_mask;
            Reg82Value |= valueTable[ix_TableStart];
        }

        private void cmb_OffsetOption_EngT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit3 & bit4 of 0x82 */
            bit_op_mask = bit3_Mask | bit4_Mask;
            uint[] valueTable = new uint[4]
            {
                0x0,
                0x08,
                0x10,
                0x18
            };

            int ix_TableStart = this.cmb_OffsetOption_EngT.SelectedIndex;
            //back up to register and update GUI
            Reg82Value &= ~bit_op_mask;
            Reg82Value |= valueTable[ix_TableStart];        //Reg0x82
        }

        private void cmb_PolaritySelect_EngT_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* bit1 & bit2 of 0x81 */
            bit_op_mask = bit1_Mask | bit2_Mask;
            uint[] valueTable = new uint[3]
            {
                0x0,
                0x04,
                0x06
            };

            int ix_TableStart = this.cmb_PolaritySelect_EngT.SelectedIndex;
            //back up to register and update GUI
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= valueTable[ix_TableStart];        //Reg0x81
        }

        private void cmb_SocketType_AutoT_SelectedIndexChanged(object sender, EventArgs e)
        {
            SocketType = this.cmb_SocketType_AutoT.SelectedIndex;
            if (SocketType == 0)
                DisplayOperateMes("Signle-Side Socket");
            else if (SocketType == 1)
                DisplayOperateMes("Multi-Side Socket");
            else
                DisplayOperateMes("Invalid Socket Type", Color.DarkRed); ;
        }

        private void rbtn_VoutOptionHigh_EngT_CheckedChanged(object sender, EventArgs e)
        {
            /* bit6 of 0x83 */
            //bit_op_mask = bit6_Mask;
            //Reg83Value &= ~bit_op_mask;
            //if (this.rbtn_VoutOptionHigh_EngT.Checked)
            //{
            //    Reg83Value |= 0x40;
            //}
            //else
            //{
            //    Reg83Value |= 0x0;
            //}
        }

        private void rbtn_InsideFilterOff_EngT_CheckedChanged(object sender, EventArgs e)
        {
            /* bit3 of 0x81 */
            bit_op_mask = bit3_Mask;
            Reg81Value &= ~bit_op_mask;
            if(rbtn_InsideFilterOff_EngT.Checked)
            {
                Reg81Value |= 0x08;
            }
            else
            {
                Reg81Value |= 0x0;
            }
        }
        
        private void btn_SaveConfig_PreT_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.Windows.Forms.Application.StartupPath;;
                filename += @"\config.cfg";

                StreamWriter sw = File.CreateText(filename);
                sw.WriteLine("/* Current Sensor Console configs, CopyRight of SenkoMicro, Inc */");
                /* ******************************************************
                 * module type, Current Range, Sensitivity adapt, Temprature Cmp, and preset gain 
                 * combobox type: name|combobox index|selected item text
                 * preset gain: name|index in table|percentage
                 *******************************************************/
                string msg;
                // module type: 
                msg = string.Format("module type|{0}|{1}",
                    this.cmb_Module_PreT.SelectedIndex.ToString(), this.cmb_Module_PreT.SelectedItem.ToString());
                sw.WriteLine(msg);

                // Current Range
                msg = string.Format("IP Range|{0}|{1}",
                    this.cmb_IPRange_PreT.SelectedIndex.ToString(), this.cmb_IPRange_PreT.SelectedItem.ToString());
                sw.WriteLine(msg);

                // Sensitivity Adapt
                msg = string.Format("Sensitivity Adapt|{0}|{1}",
                    this.cmb_SensitivityAdapt_PreT.SelectedIndex.ToString(), this.cmb_SensitivityAdapt_PreT.SelectedItem.ToString());
                sw.WriteLine(msg);

                // Temprature Compensation
                msg = string.Format("Temprature Compensation|{0}|{1}",
                    this.cmb_TempCmp_PreT.SelectedIndex.ToString(), this.cmb_TempCmp_PreT.SelectedItem.ToString());
                sw.WriteLine(msg);

                // Chosen Gain
                msg = string.Format("Preset Gain|{0}|{1}",
                    this.Ix_ForRoughGainCtrl.ToString(), RoughTable_Customer[0][Ix_ForRoughGainCtrl].ToString("F2"));
                sw.WriteLine(msg);

                // Target Voltage
                msg = string.Format("Target Voltage|{0}",
                    this.txt_targetvoltage_PreT.Text );
                sw.WriteLine(msg);

                // IP
                msg = string.Format("IP|{0}",
                    this.txt_IP_PreT.Text );
                sw.WriteLine(msg);

                // ADC Offset
                msg = string.Format("ADC Offset|{0}",
                    this.txt_AdcOffset_PreT.Text);
                sw.WriteLine(msg);

                // Vout @ 0A
                msg = string.Format("Voffset|{0}|{1}",
                    this.cmb_Voffset_PreT.SelectedIndex.ToString(), this.TargetOffset.ToString());
                    //this.cmb_Voffset_PreT.SelectedIndex.ToString(), this.cmb_Voffset_PreT.SelectedItem.ToString());
                sw.WriteLine(msg);

                // bin2 accuracy
                msg = string.Format("bin2 accuracy|{0}",
                    this.txt_bin2accuracy_PreT.Text);
                sw.WriteLine(msg);

                // bin3 accuracy
                msg = string.Format("bin3 accuracy|{0}",
                    this.txt_bin3accuracy_PreT.Text);
                sw.WriteLine(msg);

                // Tab visible code
                msg = string.Format("TVC|{0}",
                    this.uTabVisibleCode);
                sw.WriteLine(msg);

                // MRE display or not
                msg = string.Format("MRE|{0}",
                    Convert.ToUInt32(bMRE));
                sw.WriteLine(msg);

                // MASK or NOT
                msg = string.Format("MASK|{0}",
                    Convert.ToUInt32(bMASK));
                sw.WriteLine(msg);

                // SAFETY READ or NOT
                msg = string.Format("SAFEREAD|{0}",
                    Convert.ToUInt32(bSAFEREAD));
                sw.WriteLine(msg);

                sw.Close();
            }
            catch
            {
                MessageBox.Show("Save config file failed!");
            }
        }

        private void btn_loadconfig_AutoT_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.Windows.Forms.Application.StartupPath;
                filename += @"\config.cfg";

                StreamReader sr = new StreamReader(filename);
                string comment = sr.ReadLine();
                string[] msg;
                int ix;
                /* ******************************************************
                 * module type, Current Range, Sensitivity adapt, Temprature Cmp, and preset gain 
                 * combobox type: name|combobox index|selected item text
                 * preset gain: name|index in table|percentage
                 *******************************************************/
                // module type
                msg = sr.ReadLine().Split("|".ToCharArray());
                ix = int.Parse(msg[1]);
                this.cmb_Module_PreT.SelectedIndex = ix;
                this.txt_ModuleType_AutoT.Text = msg[2];

                // IP Range
                msg = sr.ReadLine().Split("|".ToCharArray());
                ix = int.Parse(msg[1]);
                this.cmb_IPRange_PreT.SelectedIndex = ix;

                // Sensitivity adapt
                msg = sr.ReadLine().Split("|".ToCharArray());
                ix = int.Parse(msg[1]);
                this.cmb_SensitivityAdapt_PreT.SelectedIndex = ix;

                // Temprature Compensation
                msg = sr.ReadLine().Split("|".ToCharArray());
                ix = int.Parse(msg[1]);
                this.cmb_TempCmp_PreT.SelectedIndex = ix;

                // Preset Gain
                msg = sr.ReadLine().Split("|".ToCharArray());
                Ix_ForRoughGainCtrl = uint.Parse(msg[1]);

                // Target Voltage
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                this.txt_targetvoltage_PreT.Text = msg[1];

                // IP
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                this.txt_IP_PreT.Text = msg[1];

                // ADC Offset
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                this.txt_AdcOffset_AutoT.Text = msg[1];
                AadcOffset = double.Parse(msg[1]);

                // Vout @ 0A
                msg = sr.ReadLine().Split("|".ToCharArray());
                ix = int.Parse(msg[1]);
                this.cmb_Voffset_PreT.SelectedIndex = ix;
                this.txt_VoutOffset_AutoT.Text = msg[2];

                // bin2 accuracy
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                bin2accuracy = double.Parse(msg[1]);
                //this.txt_bin2accuracy_PreT.Text = msg[1];
                this.txt_bin2accuracy_PreT.Text = bin2accuracy.ToString();

                // bin3 accuracy
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                bin3accuracy = double.Parse(msg[1]);
                //this.txt_bin3accuracy_PreT.Text = msg[1];
                this.txt_bin3accuracy_PreT.Text = bin3accuracy.ToString();

                // Tab visible code
                msg = sr.ReadLine().Split("|".ToCharArray());
                //ix = int.Parse(msg[1]);
                uTabVisibleCode = uint.Parse(msg[1]);

                //MRE diapaly or not
                msg = sr.ReadLine().Split("|".ToCharArray());
                bMRE = Convert.ToBoolean(uint.Parse(msg[1]));

                //MASK or NOT
                msg = sr.ReadLine().Split("|".ToCharArray());
                bMASK = Convert.ToBoolean(uint.Parse(msg[1]));

                //SAFETY READ or NOT
                msg = sr.ReadLine().Split("|".ToCharArray());
                bSAFEREAD = Convert.ToBoolean(uint.Parse(msg[1]));

                sr.Close();

                //Backup value for autotrim
                StoreReg80ToReg83Value();
            }
            catch
            {
                MessageBox.Show("Load config file failed, please choose correct file!");
            }
        }
       
        private void txt_targetvoltage_PreT_TextChanged(object sender, EventArgs e)
        {
            //targetVoltage_customer = double.Parse((sender as TextBox).Text);
            //TargetGain_customer = (targetVoltage_customer * 2000d) / IP;

            try
            {
                //temp = (4500d - 2000d) / double.Parse(this.txt_TargetGain.Text);
                if ((sender as TextBox).Text.ToCharArray()[(sender as TextBox).Text.Length - 1].ToString() == ".")
                    return;
                TargetVoltage_customer = double.Parse((sender as TextBox).Text);
                //TargetGain_customer = (double.Parse((sender as TextBox).Text) * 2000d)/IP;
            }
            catch
            {
                string tempStr = string.Format("Target voltage set failed, will use default value {0}", this.TargetVoltage_customer);
                DisplayOperateMes(tempStr, Color.Red);
            }
            finally
            {
                //TargetVoltage_customer = TargetVoltage_customer;      //Force to update text to default.
            }

            TargetGain_customer = (TargetVoltage_customer * 1000d) / IP;
        }

        private void txt_ChosenGain_PreT_TextChanged(object sender, EventArgs e)
        {
            //data[1] = Convert.ToUInt32(RoughTable_Customer[1][Ix_ForRoughGainCtrl]);     //Reg0x80
            //data[3] = Convert.ToUInt32(RoughTable_Customer[2][Ix_ForRoughGainCtrl]);     //Reg0x81

            //Reset rough gain used register bits
            /* bit5 & bit6 & bit7 of 0x80 */
            bit_op_mask = bit5_Mask | bit6_Mask | bit7_Mask;
            Reg80Value &= ~bit_op_mask;
            Reg80Value |= Convert.ToUInt32(RoughTable_Customer[1][Ix_ForRoughGainCtrl]);     //Reg0x80[1];

            /* bit0 of 0x81 */
            bit_op_mask = bit0_Mask;
            Reg81Value &= ~bit_op_mask;
            Reg81Value |= Convert.ToUInt32(RoughTable_Customer[2][Ix_ForRoughGainCtrl]);     //Reg0x81;
        }

        private void txt_reg80_EngT_TextChanged(object sender, EventArgs e)
        {
            this.txt_Reg80_PreT.Text = this.txt_reg80_EngT.Text;
        }

        private void txt_reg81_EngT_TextChanged(object sender, EventArgs e)
        {
            this.txt_Reg81_PreT.Text = this.txt_reg81_EngT.Text;
        }

        private void txt_reg82_EngT_TextChanged(object sender, EventArgs e)
        {
            this.txt_Reg82_PreT.Text = this.txt_reg82_EngT.Text;
        }

        private void txt_reg83_EngT_TextChanged(object sender, EventArgs e)
        {
            this.txt_Reg83_PreT.Text = this.txt_reg83_EngT.Text;
        }

        private void btn_AdcOut_EngT_Click(object sender, EventArgs e)
        {
            double temp = 0;
            //oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn_EngT.Checked = true;
            //rbt_signalPathSeting_Vout_EngT.Checked = true;
            temp = AverageVout();
            this.txt_AdcOut_EngT.Text = temp.ToString("F3");
            //Vout_0A = AverageVout();
            DisplayOperateMes("ADC Out = " + temp.ToString("F3"));
        }

        private void txt_AdcOffset_PreT_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.ToCharArray()[(sender as TextBox).Text.Length - 1].ToString() == ".")
                return;
            AadcOffset = double.Parse((sender as TextBox).Text);
            //AadcOffset = AadcOffset;
        }

        private void cmb_Voffset_PreT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ix = 0;
            ix = this.cmb_Voffset_PreT.SelectedIndex;
            if( ix == 0 )
            {
                TargetOffset = 2.5;
                bit_op_mask = bit3_Mask | bit4_Mask;
                Reg82Value &= ~bit_op_mask;
                Reg82Value |= 0x00;        //Reg0x82
                //Reg82Value = 0x18;
                this.cmb_OffsetOption_EngT.SelectedIndex = 0;
                this.txt_VoutOffset_AutoT.Text = "2.5";
            }
            else if( ix == 1 )
            {
                TargetOffset = 2.5;
                bit_op_mask = bit3_Mask | bit4_Mask;
                Reg82Value &= ~bit_op_mask;
                Reg82Value |= 0x08;        //Reg0x82
                //Reg82Value = 0x00;
                this.cmb_OffsetOption_EngT.SelectedIndex = 1;
                this.txt_VoutOffset_AutoT.Text = "2.5";
            }
            else if (ix == 2)
            {
                if (ModuleTypeIndex == 2)
                    TargetOffset = 1.65;
                else
                    TargetOffset = 2.5;
                bit_op_mask = bit3_Mask | bit4_Mask;
                Reg82Value &= ~bit_op_mask;
                Reg82Value |= 0x10;        //Reg0x82
                //Reg82Value = 0x00;
                this.cmb_OffsetOption_EngT.SelectedIndex = 2;
                this.txt_VoutOffset_AutoT.Text = TargetOffset.ToString();
            }
            else if (ix == 3)
            {
                TargetOffset = 1.65;
                bit_op_mask = bit3_Mask | bit4_Mask;
                Reg82Value &= ~bit_op_mask;
                Reg82Value |= 0x18;        //Reg0x82
                //Reg82Value = 0x00;
                this.cmb_OffsetOption_EngT.SelectedIndex = 3;
                this.txt_VoutOffset_AutoT.Text = "1.65";
            }
        }

        private void btn_Vout_AutoT_Click(object sender, EventArgs e)
        {
            uint uDutCount = 16;
            uint idut = 0;
            double[] uVout = new double[16];

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VOUT_WITH_CAP);
            Delay(Delay_Sync);
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VIN_TO_VOUT);
            Delay(Delay_Sync);
            RePower();
            for (idut = 0; idut < uDutCount; idut++)
            {
                MultiSiteSocketSelect(idut);
                Delay(Delay_Power);
                uVout[idut] = AverageVout();
                DisplayOperateMes("Vout[" + idut.ToString() + "] @ 0A = " + uVout[idut].ToString("F3"));
            }

            MultiSiteDisplayVout(uVout);
        }

        private void btn_EngTab_Connect_Click(object sender, EventArgs e)
        {
            bool result = false;
            //#region One wire
            //if (!bUsbConnected)
            result = oneWrie_device.ConnectDevice();

            if (result)
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.YellowGreen;
                this.toolStripStatusLabel_Connection.Text = "Connected";
                btn_GetFW_OneWire_Click(null, null);
                bUsbConnected = true;
            }
            else
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.IndianRed;
                this.toolStripStatusLabel_Connection.Text = "Disconnected";
            }
            //#endregion

            //numUD_pilotwidth_ow_ValueChanged(null,null);
            //numUD_pilotwidth_ow_ValueChanged(null,null);
            //num_UD_pulsewidth_ow_ValueChanged
        }

        private void btn_EngTab_Ipoff_Click(object sender, EventArgs e)
        {
            //Set Voltage
            if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, 0u))
                DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", 0));
            else
            {
                DisplayOperateMes(string.Format("Set Current to {0}A failed!", 0));
            }
        }

        private void btn_EngTab_Ipon_Click(object sender, EventArgs e)
        {
            //Set Voltage
            if (oneWrie_device.UARTWrite(OneWireInterface.UARTControlCommand.ADI_SDP_CMD_UART_SETCURR, Convert.ToUInt32(IP)))
                DisplayOperateMes(string.Format("Set Current to {0}A succeeded!", IP));
            else
            {
                DisplayOperateMes(string.Format("Set Current to {0}A failed!", IP));
            }
        }

        private void cmb_ProgramMode_AutoT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProgramMode = this.cmb_ProgramMode_AutoT.SelectedIndex;
            if (ProgramMode == 0)
                DisplayOperateMes("Automatic Program");
            else if (ProgramMode == 1)
                DisplayOperateMes("Manual Program");
            else
                DisplayOperateMes("Invalid Program Mode", Color.DarkRed);
        }       

        private void btn_StartPoint_BrakeT_Click(object sender, EventArgs e)
        {
            double dStartPoint = 0;
            //double dStopPoint = 0;
            bool bTerminate = false;
            Ix_OffsetA_Brake = 0;
            Ix_OffsetB_Brake = 0;
            //uint[] BrakeReg = new uint[5];

            //BrakeReg = [0;0;0;0;0];

            while (!bTerminate)
            {
                RePower();
                EnterTestMode();
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
                {
                    DisplayOperateMes("DUT" + " has been Blown!", Color.Red);
                    PowerOff();
                    return;
                }

                RegisterWrite(4, new uint[8] { 0x80, BrakeReg[0], 0x81, BrakeReg[1], 0x82, BrakeReg[2], 0x83, BrakeReg[3] });
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] != BrakeReg[0] || tempReadback[1] != BrakeReg[1] || tempReadback[2] != BrakeReg[2] || tempReadback[3] != BrakeReg[3])
                {
                    DisplayOperateMes("DUT digital communication fail!", Color.Red);
                    PowerOff();
                    return;
                }
                
                EnterNomalMode();
                dStartPoint = AverageVout();
                DisplayOperateMes("start point = " + dStartPoint.ToString("F3"));
                if (dStartPoint < 0.09)
                {
                    bTerminate = true;
                }

                if (Ix_OffsetA_Brake < 8)
                {
                    bit_op_mask = bit7_Mask;
                    BrakeReg[1] &= ~bit_op_mask;
                    BrakeReg[1] |= Convert.ToUInt32(OffsetTableA_Customer[1][Ix_OffsetA_Brake]);

                    bit_op_mask = bit0_Mask | bit1_Mask | bit2_Mask;
                    BrakeReg[2] &= ~bit_op_mask;
                    BrakeReg[2] |= Convert.ToUInt32(OffsetTableA_Customer[2][Ix_OffsetA_Brake]);

                    Ix_OffsetA_Brake++;
                }
                else if (Ix_OffsetB_Brake < 8)
                {
                    bit_op_mask = bit2_Mask | bit3_Mask | bit4_Mask | bit5_Mask;
                    BrakeReg[3] &= ~bit_op_mask;
                    BrakeReg[3] |= Convert.ToUInt32(OffsetTableB_Customer[1][Ix_OffsetB_Brake]);

                    Ix_OffsetB_Brake++;
                }
                else
                {
                    DisplayOperateMes("Unable to adjust start point!", Color.Red);
                    PowerOff();
                    bTerminate = true;
                }
            }
        }

        private void btn_StopPoint_BrakeT_Click(object sender, EventArgs e)
        {
            double dStopPoint = 0;
            bool bTerminate = false;
            Ix_GainRough_Brake = 0;
            Ix_GainPrecision_Brake = 0;
            //uint[] BrakeReg = new uint[5];
            BrakeReg[0] |= 0xE0;
            BrakeReg[1] |= 0x01;

            //BrakeReg = [0;0;0;0;0];

            while (!bTerminate)
            {
                RePower();
                EnterTestMode();
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
                {
                    DisplayOperateMes("DUT" + " has been Blown!", Color.Red);
                    PowerOff();
                    return;
                }

                RegisterWrite(4, new uint[8] { 0x80, BrakeReg[0], 0x81, BrakeReg[1], 0x82, BrakeReg[2], 0x83, BrakeReg[3] });
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] != BrakeReg[0] || tempReadback[1] != BrakeReg[1] || tempReadback[2] != BrakeReg[2] || tempReadback[3] != BrakeReg[3])
                {
                    DisplayOperateMes("DUT digital communication fail!", Color.Red);
                    PowerOff();
                    return;
                }

                EnterNomalMode();
                dStopPoint = AverageVout();
                DisplayOperateMes("stop point = " + dStopPoint.ToString("F3"));
                if (dStopPoint >= 4.9)
                {
                    bTerminate = true;
                }

                if (Ix_GainRough_Brake < 16)
                {
                    bit_op_mask = bit7_Mask | bit6_Mask | bit5_Mask ;
                    BrakeReg[0] &= ~bit_op_mask;
                    BrakeReg[0] |= Convert.ToUInt32(RoughTable_Customer[1][Ix_GainRough_Brake]);

                    bit_op_mask = bit0_Mask;
                    BrakeReg[1] &= ~bit_op_mask;
                    BrakeReg[1] |= Convert.ToUInt32(RoughTable_Customer[2][Ix_GainRough_Brake]);

                    Ix_GainRough_Brake++;
                }
                else
                {
                    DisplayOperateMes("Unable to adjust stop point!", Color.Red);
                    PowerOff();
                    bTerminate = true;
                }
            }

            bTerminate = false;
            while (!bTerminate)
            {
                RePower();
                EnterTestMode();
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] + tempReadback[1] + tempReadback[2] + tempReadback[3] + tempReadback[4] != 0)
                {
                    DisplayOperateMes("DUT" + " has been Blown!", Color.Red);
                    PowerOff();
                    return;
                }

                RegisterWrite(4, new uint[8] { 0x80, BrakeReg[0], 0x81, BrakeReg[1], 0x82, BrakeReg[2], 0x83, BrakeReg[3] });
                BurstRead(0x80, 5, tempReadback);
                if (tempReadback[0] != BrakeReg[0] || tempReadback[1] != BrakeReg[1] || tempReadback[2] != BrakeReg[2] || tempReadback[3] != BrakeReg[3])
                {
                    DisplayOperateMes("DUT digital communication fail!", Color.Red);
                    PowerOff();
                    return;
                }

                EnterNomalMode();
                dStopPoint = AverageVout();
                DisplayOperateMes("stop point = " + dStopPoint.ToString("F3"));
                if (dStopPoint <= 4.9)
                {
                    bTerminate = true;
                }

                if (Ix_GainPrecision_Brake < 32)
                {
                    bit_op_mask = bit4_Mask | bit3_Mask | bit2_Mask | bit1_Mask | bit0_Mask;
                    BrakeReg[0] &= ~bit_op_mask;
                    BrakeReg[0] |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_GainPrecision_Brake]);

                    Ix_GainPrecision_Brake++;
                }
                else
                {
                    DisplayOperateMes("Unable to adjust stop point!", Color.Red);
                    PowerOff();
                    bTerminate = true;
                }
            }
            Ix_GainPrecision_Brake--;
            bit_op_mask = bit4_Mask | bit3_Mask | bit2_Mask | bit1_Mask | bit0_Mask;
            BrakeReg[0] &= ~bit_op_mask;
            BrakeReg[0] |= Convert.ToUInt32(PreciseTable_Customer[1][Ix_GainPrecision_Brake]);
        }

        private void btn_Fuse_BrakeT_Click(object sender, EventArgs e)
        {
            bool bMarginal = false;

            //Fuse
            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_EXT);
            RePower();
            EnterTestMode();
            RegisterWrite(5, new uint[10] { 0x80, BrakeReg[0], 0x81, BrakeReg[1], 0x82, BrakeReg[2], 0x83, BrakeReg[3], 0x84, 0x07 });
            BurstRead(0x80, 5, tempReadback);
            FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
            DisplayOperateMes("Trimming...");
            Delay(Delay_Fuse);

            ReloadPreset();
            Delay(Delay_Operation);
            BurstRead(0x80, 5, tempReadback);
            if (tempReadback[4] == 0)
            {
                RePower();
                EnterTestMode();
                RegisterWrite(5, new uint[10] { 0x80, BrakeReg[0], 0x81, BrakeReg[1], 0x82, BrakeReg[2], 0x83, BrakeReg[3], 0x84, 0x07 });
                BurstRead(0x80, 5, tempReadback);
                FuseClockOn(DeviceAddress, (double)num_UD_pulsewidth_ow_EngT.Value, (double)numUD_pulsedurationtime_ow_EngT.Value);
                DisplayOperateMes("Trimming...");
                Delay(Delay_Fuse);
            }
            Delay(Delay_Operation);

            MarginalReadPreset();
            Delay(Delay_Operation);
            BurstRead(0x80, 5, tempReadback);
            bMarginal = false;
            if (bMASK)
            {
                if (((tempReadback[0] & 0xE0) != (BrakeReg[0] & 0xE0)) | (tempReadback[1] & 0x81) != (BrakeReg[1] & 0x81) |
                    (tempReadback[2] & 0x99) != (BrakeReg[2] & 0x99) | (tempReadback[3] & 0x83) != (BrakeReg[3] & 0x83) | (tempReadback[4] < 1))
                    bMarginal = true;
            }
            else
            {
                if (((tempReadback[0] & 0xFF) != (BrakeReg[0] & 0xFF)) | (tempReadback[1] & 0xFF) != (BrakeReg[1] & 0xFF) |
                        (tempReadback[2] & 0xFF) != (BrakeReg[2] & 0xFF) | (tempReadback[3] & 0xFF) != (BrakeReg[3] & 0xFF) | (tempReadback[4] < 7))
                    bMarginal = true;
            }
            if (bMarginal)
            {
                DisplayOperateMes("MRE");
            }

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            PowerOff();

        }

        

        private void btn_CommunicationTest_Click(object sender, EventArgs e)
        {
            //bool bCommPass = false;

            oneWrie_device.SDPSignalPathSet(OneWireInterface.SPControlCommand.SP_VDD_FROM_5V);
            RePower();
            EnterTestMode();
            RegisterWrite(5, new uint[10] { 0x80, 0xAA, 0x81, 0xAA, 0x82, 0xAA, 0x83, 0xAA, 0x84, 0x07 });
            //DisplayOperateMes("Write In Data is: ");
            DisplayOperateMes("Reg{0} = 0xAA");
            DisplayOperateMes("Reg{1} = 0xAA");
            DisplayOperateMes("Reg{2} = 0xAA");
            DisplayOperateMes("Reg{3} = 0xAA");
            DisplayOperateMes("Reg{4} = 0x07");
            BurstRead(0x80, 5, tempReadback);

            if (tempReadback[0]!=0xAA || tempReadback[1]!=0xAA || tempReadback[2]!=0xAA || tempReadback[3]!=0xAA || tempReadback[4]!=0x07)
            {
                //bCommPass = false;
                DisplayOperateMes("Communication Fail!", Color.Red);
                return;
            }

            Delay(Delay_Operation);

            RegisterWrite(5, new uint[10] { 0x80, 0x55, 0x81, 0x55, 0x82, 0x55, 0x83, 0x55, 0x84, 0x07 });
            DisplayOperateMes("Write In Data is: ");
            DisplayOperateMes("Reg{0} = 0x55");
            DisplayOperateMes("Reg{1} = 0x55");
            DisplayOperateMes("Reg{2} = 0x55");
            DisplayOperateMes("Reg{3} = 0x55");
            DisplayOperateMes("Reg{4} = 0x07");
            BurstRead(0x80, 5, tempReadback);

            if (tempReadback[0] != 0x55 || tempReadback[1] != 0x55 || tempReadback[2] != 0x55 || tempReadback[3] != 0x55 || tempReadback[4] != 0x07)
            {
                //bCommPass = false;
                DisplayOperateMes("Communication Fail!", Color.Red);
                return;
            }

            DisplayOperateMes("Communication Pass! ");
        }
        
        
        

        private void btn_SafetyHighRead_EngT_Click(object sender, EventArgs e)
        {
            rbt_signalPathSeting_Vout_EngT.Checked = true;
            rbt_signalPathSeting_Config_EngT.Checked = true;

            SafetyHighReadPreset();
        }
        
        #endregion Events

    }

    
}
