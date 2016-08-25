﻿namespace CurrentSensorV3
{
    partial class CurrentSensorConsole
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentSensorConsole));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_FWInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.EngineeringTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_sel_cap = new System.Windows.Forms.Button();
            this.btn_GetFW_OneWire = new System.Windows.Forms.Button();
            this.btn_nc_1x = new System.Windows.Forms.Button();
            this.btn_ch_ck = new System.Windows.Forms.Button();
            this.btn_sel_vr = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbt_withoutCap_Vref = new System.Windows.Forms.RadioButton();
            this.rbt_withCap_Vref = new System.Windows.Forms.RadioButton();
            this.btn_EngTab_Ipon = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_EngTab_Ipoff = new System.Windows.Forms.Button();
            this.btn_EngTab_Connect = new System.Windows.Forms.Button();
            this.btn_AdcOut_EngT = new System.Windows.Forms.Button();
            this.txt_AdcOut_EngT = new System.Windows.Forms.TextBox();
            this.numUD_OffsetB = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.numUD_SlopeK = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.grb_HWInfo = new System.Windows.Forms.GroupBox();
            this.cmb_Module_EngT = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.btn_Reset_EngT = new System.Windows.Forms.Button();
            this.btn_ModuleCurrent_EngT = new System.Windows.Forms.Button();
            this.txt_ModuleCurrent_EngT = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_SerialNum_EngT = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_flash_onewire = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_PolaritySelect_EngT = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cmb_OffsetOption_EngT = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rbtn_InsideFilterDefault_EngT = new System.Windows.Forms.RadioButton();
            this.rbtn_InsideFilterOff_EngT = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rbtn_VoutOpetionDefault_EngT = new System.Windows.Forms.RadioButton();
            this.rbtn_VoutOptionHigh_EngT = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.cmb_SensingDirection_EngT = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_ADCReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rbtn_CSResistorSet_EngT = new System.Windows.Forms.RadioButton();
            this.rbtn_CSResistorByPass_EngT = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbt_signalPathSeting_Config_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_AIn_EngT = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbt_signalPathSeting_Mout_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_510Out_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_VCS_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_Vref_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_Vout_EngT = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbt_withoutCap_Vout_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_withCap_Vout_EngT = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtb_VDD_Ext_EngT = new System.Windows.Forms.RadioButton();
            this.rbt_VDD_5V_EngT = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SafetyHighRead_EngT = new System.Windows.Forms.Button();
            this.btn_SafetyRead_EngT = new System.Windows.Forms.Button();
            this.btn_burstRead_EngT = new System.Windows.Forms.Button();
            this.btn_MarginalRead_EngT = new System.Windows.Forms.Button();
            this.btn_Vout0A_EngT = new System.Windows.Forms.Button();
            this.btn_Reload_EngT = new System.Windows.Forms.Button();
            this.btn_VoutIP_EngT = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_reg83_EngT = new System.Windows.Forms.TextBox();
            this.txt_reg82_EngT = new System.Windows.Forms.TextBox();
            this.txt_reg81_EngT = new System.Windows.Forms.TextBox();
            this.txt_reg80_EngT = new System.Windows.Forms.TextBox();
            this.btn_writeFuseCode_EngT = new System.Windows.Forms.Button();
            this.btn_fuse_clock_ow_EngT = new System.Windows.Forms.Button();
            this.btn_fuse_action_ow_EngT = new System.Windows.Forms.Button();
            this.btn_enterNomalMode_EngT = new System.Windows.Forms.Button();
            this.btn_offset_EngT = new System.Windows.Forms.Button();
            this.btn_CalcGainCode_EngT = new System.Windows.Forms.Button();
            this.btn_PowerOff_OWCI_ADC_EngT = new System.Windows.Forms.Button();
            this.btn_PowerOn_OWCI_ADC_EngT = new System.Windows.Forms.Button();
            this.grb_devInfo_ow = new System.Windows.Forms.GroupBox();
            this.txt_sampleNum_EngT = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_sampleRate_EngT = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numUD_pilotwidth_ow_EngT = new System.Windows.Forms.NumericUpDown();
            this.numUD_pulsedurationtime_ow_EngT = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_pilotwidth_ow = new System.Windows.Forms.Label();
            this.lbl_pulsewidth_ow = new System.Windows.Forms.Label();
            this.txt_TargetGain_EngT = new System.Windows.Forms.TextBox();
            this.num_UD_pulsewidth_ow_EngT = new System.Windows.Forms.NumericUpDown();
            this.txt_dev_addr_onewire_EngT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_pulsedurationtime_ow = new System.Windows.Forms.Label();
            this.txt_IP_EngT = new System.Windows.Forms.TextBox();
            this.lbl_devAddr_onewire = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_preciseTrim = new System.Windows.Forms.Button();
            this.PriTrimTab = new System.Windows.Forms.TabPage();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txt_Reg80_PreT = new System.Windows.Forms.TextBox();
            this.txt_Reg81_PreT = new System.Windows.Forms.TextBox();
            this.txt_Reg82_PreT = new System.Windows.Forms.TextBox();
            this.txt_Reg83_PreT = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt_Delay_PreT = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.btn_SaveConfig_PreT = new System.Windows.Forms.Button();
            this.btn_GainCtrlMinus_PreT = new System.Windows.Forms.Button();
            this.btn_GainCtrlPlus_PreT = new System.Windows.Forms.Button();
            this.btn_Vout_PreT = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.txt_ChosenGain_PreT = new System.Windows.Forms.TextBox();
            this.txt_PresetVoutIP_PreT = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_bin3accuracy_PreT = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.txt_bin2accuracy_PreT = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.cmb_Voffset_PreT = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txt_IP_PreT = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_targetvoltage_PreT = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txt_AdcOffset_PreT = new System.Windows.Forms.TextBox();
            this.txt_TargetGain_PreT = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cmb_IPRange_PreT = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmb_TempCmp_PreT = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cmb_SensitivityAdapt_PreT = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btn_Reset_PreT = new System.Windows.Forms.Button();
            this.btn_FlashLed_PreT = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_PowerOn_PreT = new System.Windows.Forms.Button();
            this.cmb_Module_PreT = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.btn_ModuleCurrent_PreT = new System.Windows.Forms.Button();
            this.txt_ModuleCurrent_PreT = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txt_SerialNum_PreT = new System.Windows.Forms.TextBox();
            this.btn_PowerOff_PreT = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.AutoTrimTab = new System.Windows.Forms.TabPage();
            this.btn_CommunicationTest = new System.Windows.Forms.Button();
            this.cmb_ProgramMode_AutoT = new System.Windows.Forms.ComboBox();
            this.cmb_SocketType_AutoT = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_Vout_AutoT = new System.Windows.Forms.Button();
            this.btn_loadconfig_AutoT = new System.Windows.Forms.Button();
            this.btn_PowerOff_AutoT = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.numUD_TargetGain_Customer = new System.Windows.Forms.NumericUpDown();
            this.numUD_IPxForCalc_Customer = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.autoTrimResultIndicator = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_passOrFailed = new System.Windows.Forms.Label();
            this.btn_AutomaticaTrim15V = new System.Windows.Forms.Button();
            this.btn_AutomaticaTrim5V = new System.Windows.Forms.Button();
            this.btn_AutomaticaTrim = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txt_ModuleType_AutoT = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txt_ChosenGain_AutoT = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.txt_IP_AutoT = new System.Windows.Forms.TextBox();
            this.txt_VoutOffset_AutoT = new System.Windows.Forms.TextBox();
            this.txt_TargertVoltage_AutoT = new System.Windows.Forms.TextBox();
            this.txt_AdcOffset_AutoT = new System.Windows.Forms.TextBox();
            this.txt_SensitivityAdapt_AutoT = new System.Windows.Forms.TextBox();
            this.txt_TargetGain_AutoT = new System.Windows.Forms.TextBox();
            this.txt_IPRange_AutoT = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.txt_TempComp_AutoT = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.BrakeTab = new System.Windows.Forms.TabPage();
            this.btn_BrakeTab_PowerOff = new System.Windows.Forms.Button();
            this.btn_BrakeTab_PowerOn = new System.Windows.Forms.Button();
            this.txt_StopPoint_BrakeT = new System.Windows.Forms.TextBox();
            this.txt_StartPoint_BrakeT = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.btn_Fuse_BrakeT = new System.Windows.Forms.Button();
            this.btn_StopPoint_BrakeT = new System.Windows.Forms.Button();
            this.btn_StartPoint_BrakeT = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_BrakeTab_InitializeUart = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_SelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_OutputLogInfo = new System.Windows.Forms.RichTextBox();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.EngineeringTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_OffsetB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SlopeK)).BeginInit();
            this.grb_HWInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grb_devInfo_ow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow_EngT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow_EngT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow_EngT)).BeginInit();
            this.PriTrimTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.AutoTrimTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TargetGain_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_IPxForCalc_Customer)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.BrakeTab.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Connection,
            this.toolStripStatusLabel_FWInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 603);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1098, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel_Connection
            // 
            this.toolStripStatusLabel_Connection.BackColor = System.Drawing.Color.IndianRed;
            this.toolStripStatusLabel_Connection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripStatusLabel_Connection.Name = "toolStripStatusLabel_Connection";
            this.toolStripStatusLabel_Connection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel_Connection.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Connection.Text = "Disconnected";
            // 
            // toolStripStatusLabel_FWInfo
            // 
            this.toolStripStatusLabel_FWInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripStatusLabel_FWInfo.Name = "toolStripStatusLabel_FWInfo";
            this.toolStripStatusLabel_FWInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1098, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            this.toolStrip.Visible = false;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 22);
            this.newToolStripButton.Text = "New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 22);
            this.openToolStripButton.Text = "Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Enabled = false;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(24, 22);
            this.printPreviewToolStripButton.Text = "Print Preview";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.EngineeringTab);
            this.tabControl1.Controls.Add(this.PriTrimTab);
            this.tabControl1.Controls.Add(this.AutoTrimTab);
            this.tabControl1.Controls.Add(this.BrakeTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MaximumSize = new System.Drawing.Size(1000, 600);
            this.tabControl1.MinimumSize = new System.Drawing.Size(683, 500);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 600);
            this.tabControl1.TabIndex = 5;
            // 
            // EngineeringTab
            // 
            this.EngineeringTab.Controls.Add(this.groupBox5);
            this.EngineeringTab.Controls.Add(this.panel3);
            this.EngineeringTab.Controls.Add(this.btn_EngTab_Ipon);
            this.EngineeringTab.Controls.Add(this.label14);
            this.EngineeringTab.Controls.Add(this.btn_EngTab_Ipoff);
            this.EngineeringTab.Controls.Add(this.btn_EngTab_Connect);
            this.EngineeringTab.Controls.Add(this.btn_AdcOut_EngT);
            this.EngineeringTab.Controls.Add(this.txt_AdcOut_EngT);
            this.EngineeringTab.Controls.Add(this.numUD_OffsetB);
            this.EngineeringTab.Controls.Add(this.label56);
            this.EngineeringTab.Controls.Add(this.numUD_SlopeK);
            this.EngineeringTab.Controls.Add(this.label55);
            this.EngineeringTab.Controls.Add(this.grb_HWInfo);
            this.EngineeringTab.Controls.Add(this.groupBox3);
            this.EngineeringTab.Controls.Add(this.btn_ADCReset);
            this.EngineeringTab.Controls.Add(this.groupBox2);
            this.EngineeringTab.Controls.Add(this.groupBox1);
            this.EngineeringTab.Controls.Add(this.grb_devInfo_ow);
            this.EngineeringTab.Controls.Add(this.btn_preciseTrim);
            this.EngineeringTab.Location = new System.Drawing.Point(4, 22);
            this.EngineeringTab.Name = "EngineeringTab";
            this.EngineeringTab.Padding = new System.Windows.Forms.Padding(3);
            this.EngineeringTab.Size = new System.Drawing.Size(803, 574);
            this.EngineeringTab.TabIndex = 0;
            this.EngineeringTab.Text = "Engineering";
            this.EngineeringTab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_sel_cap);
            this.groupBox5.Controls.Add(this.btn_GetFW_OneWire);
            this.groupBox5.Controls.Add(this.btn_nc_1x);
            this.groupBox5.Controls.Add(this.btn_ch_ck);
            this.groupBox5.Controls.Add(this.btn_sel_vr);
            this.groupBox5.Location = new System.Drawing.Point(232, 558);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(398, 10);
            this.groupBox5.TabIndex = 67;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            this.groupBox5.Visible = false;
            // 
            // btn_sel_cap
            // 
            this.btn_sel_cap.Location = new System.Drawing.Point(14, 119);
            this.btn_sel_cap.Name = "btn_sel_cap";
            this.btn_sel_cap.Size = new System.Drawing.Size(90, 23);
            this.btn_sel_cap.TabIndex = 66;
            this.btn_sel_cap.Text = "SEL_CAP";
            this.btn_sel_cap.UseVisualStyleBackColor = true;
            this.btn_sel_cap.Click += new System.EventHandler(this.btn_sel_cap_Click);
            // 
            // btn_GetFW_OneWire
            // 
            this.btn_GetFW_OneWire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_GetFW_OneWire.Location = new System.Drawing.Point(242, -13);
            this.btn_GetFW_OneWire.Name = "btn_GetFW_OneWire";
            this.btn_GetFW_OneWire.Size = new System.Drawing.Size(54, 23);
            this.btn_GetFW_OneWire.TabIndex = 56;
            this.btn_GetFW_OneWire.Text = "FW Ver";
            this.btn_GetFW_OneWire.UseVisualStyleBackColor = true;
            this.btn_GetFW_OneWire.Visible = false;
            this.btn_GetFW_OneWire.Click += new System.EventHandler(this.btn_GetFW_OneWire_Click);
            // 
            // btn_nc_1x
            // 
            this.btn_nc_1x.Location = new System.Drawing.Point(109, -13);
            this.btn_nc_1x.Name = "btn_nc_1x";
            this.btn_nc_1x.Size = new System.Drawing.Size(65, 23);
            this.btn_nc_1x.TabIndex = 66;
            this.btn_nc_1x.Text = "NC_1X";
            this.btn_nc_1x.UseVisualStyleBackColor = true;
            this.btn_nc_1x.Click += new System.EventHandler(this.btn_nc_1x_Click);
            // 
            // btn_ch_ck
            // 
            this.btn_ch_ck.Location = new System.Drawing.Point(178, -13);
            this.btn_ch_ck.Name = "btn_ch_ck";
            this.btn_ch_ck.Size = new System.Drawing.Size(65, 23);
            this.btn_ch_ck.TabIndex = 66;
            this.btn_ch_ck.Text = "CH_CK";
            this.btn_ch_ck.UseVisualStyleBackColor = true;
            this.btn_ch_ck.Click += new System.EventHandler(this.btn_ch_ck_Click);
            // 
            // btn_sel_vr
            // 
            this.btn_sel_vr.Location = new System.Drawing.Point(43, -13);
            this.btn_sel_vr.Name = "btn_sel_vr";
            this.btn_sel_vr.Size = new System.Drawing.Size(65, 23);
            this.btn_sel_vr.TabIndex = 66;
            this.btn_sel_vr.Text = "SEL_VR";
            this.btn_sel_vr.UseVisualStyleBackColor = true;
            this.btn_sel_vr.Click += new System.EventHandler(this.btn_sel_vr_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbt_withoutCap_Vref);
            this.panel3.Controls.Add(this.rbt_withCap_Vref);
            this.panel3.Location = new System.Drawing.Point(678, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(87, 23);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // rbt_withoutCap_Vref
            // 
            this.rbt_withoutCap_Vref.AutoSize = true;
            this.rbt_withoutCap_Vref.Location = new System.Drawing.Point(3, 25);
            this.rbt_withoutCap_Vref.Name = "rbt_withoutCap_Vref";
            this.rbt_withoutCap_Vref.Size = new System.Drawing.Size(84, 17);
            this.rbt_withoutCap_Vref.TabIndex = 1;
            this.rbt_withoutCap_Vref.Text = "Without Cap";
            this.rbt_withoutCap_Vref.UseVisualStyleBackColor = true;
            // 
            // rbt_withCap_Vref
            // 
            this.rbt_withCap_Vref.AutoSize = true;
            this.rbt_withCap_Vref.Checked = true;
            this.rbt_withCap_Vref.Location = new System.Drawing.Point(6, 5);
            this.rbt_withCap_Vref.Name = "rbt_withCap_Vref";
            this.rbt_withCap_Vref.Size = new System.Drawing.Size(69, 17);
            this.rbt_withCap_Vref.TabIndex = 0;
            this.rbt_withCap_Vref.TabStop = true;
            this.rbt_withCap_Vref.Text = "With Cap";
            this.rbt_withCap_Vref.UseVisualStyleBackColor = true;
            this.rbt_withCap_Vref.CheckedChanged += new System.EventHandler(this.rbt_withCap_Vref_CheckedChanged);
            // 
            // btn_EngTab_Ipon
            // 
            this.btn_EngTab_Ipon.Location = new System.Drawing.Point(722, 417);
            this.btn_EngTab_Ipon.Name = "btn_EngTab_Ipon";
            this.btn_EngTab_Ipon.Size = new System.Drawing.Size(56, 40);
            this.btn_EngTab_Ipon.TabIndex = 89;
            this.btn_EngTab_Ipon.Text = "IP ON";
            this.btn_EngTab_Ipon.UseVisualStyleBackColor = true;
            this.btn_EngTab_Ipon.Click += new System.EventHandler(this.btn_EngTab_Ipon_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(771, 558);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Vref";
            this.label14.Visible = false;
            // 
            // btn_EngTab_Ipoff
            // 
            this.btn_EngTab_Ipoff.Location = new System.Drawing.Point(722, 348);
            this.btn_EngTab_Ipoff.Name = "btn_EngTab_Ipoff";
            this.btn_EngTab_Ipoff.Size = new System.Drawing.Size(56, 40);
            this.btn_EngTab_Ipoff.TabIndex = 89;
            this.btn_EngTab_Ipoff.Text = "IP OFF";
            this.btn_EngTab_Ipoff.UseVisualStyleBackColor = true;
            this.btn_EngTab_Ipoff.Click += new System.EventHandler(this.btn_EngTab_Ipoff_Click);
            // 
            // btn_EngTab_Connect
            // 
            this.btn_EngTab_Connect.Location = new System.Drawing.Point(722, 491);
            this.btn_EngTab_Connect.Name = "btn_EngTab_Connect";
            this.btn_EngTab_Connect.Size = new System.Drawing.Size(56, 40);
            this.btn_EngTab_Connect.TabIndex = 89;
            this.btn_EngTab_Connect.Text = "Connect";
            this.btn_EngTab_Connect.UseVisualStyleBackColor = true;
            this.btn_EngTab_Connect.Click += new System.EventHandler(this.btn_EngTab_Connect_Click);
            // 
            // btn_AdcOut_EngT
            // 
            this.btn_AdcOut_EngT.Location = new System.Drawing.Point(722, 214);
            this.btn_AdcOut_EngT.Name = "btn_AdcOut_EngT";
            this.btn_AdcOut_EngT.Size = new System.Drawing.Size(56, 20);
            this.btn_AdcOut_EngT.TabIndex = 88;
            this.btn_AdcOut_EngT.Text = "ADC";
            this.btn_AdcOut_EngT.UseVisualStyleBackColor = true;
            this.btn_AdcOut_EngT.Click += new System.EventHandler(this.btn_AdcOut_EngT_Click);
            // 
            // txt_AdcOut_EngT
            // 
            this.txt_AdcOut_EngT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_AdcOut_EngT.Location = new System.Drawing.Point(722, 195);
            this.txt_AdcOut_EngT.Name = "txt_AdcOut_EngT";
            this.txt_AdcOut_EngT.ReadOnly = true;
            this.txt_AdcOut_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_AdcOut_EngT.TabIndex = 87;
            this.txt_AdcOut_EngT.Text = "0.000";
            this.txt_AdcOut_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numUD_OffsetB
            // 
            this.numUD_OffsetB.DecimalPlaces = 3;
            this.numUD_OffsetB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUD_OffsetB.Location = new System.Drawing.Point(722, 159);
            this.numUD_OffsetB.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUD_OffsetB.Name = "numUD_OffsetB";
            this.numUD_OffsetB.Size = new System.Drawing.Size(56, 20);
            this.numUD_OffsetB.TabIndex = 86;
            this.numUD_OffsetB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_OffsetB.ValueChanged += new System.EventHandler(this.numUD_OffsetB_ValueChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(726, 142);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(49, 14);
            this.label56.TabIndex = 85;
            this.label56.Text = "Offset(b)";
            // 
            // numUD_SlopeK
            // 
            this.numUD_SlopeK.DecimalPlaces = 3;
            this.numUD_SlopeK.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUD_SlopeK.Location = new System.Drawing.Point(722, 103);
            this.numUD_SlopeK.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numUD_SlopeK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUD_SlopeK.Name = "numUD_SlopeK";
            this.numUD_SlopeK.Size = new System.Drawing.Size(56, 20);
            this.numUD_SlopeK.TabIndex = 84;
            this.numUD_SlopeK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_SlopeK.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUD_SlopeK.ValueChanged += new System.EventHandler(this.numUD_SlopeK_ValueChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(727, 80);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 14);
            this.label55.TabIndex = 83;
            this.label55.Text = "Slope(k)";
            // 
            // grb_HWInfo
            // 
            this.grb_HWInfo.Controls.Add(this.cmb_Module_EngT);
            this.grb_HWInfo.Controls.Add(this.label53);
            this.grb_HWInfo.Controls.Add(this.btn_Reset_EngT);
            this.grb_HWInfo.Controls.Add(this.btn_ModuleCurrent_EngT);
            this.grb_HWInfo.Controls.Add(this.txt_ModuleCurrent_EngT);
            this.grb_HWInfo.Controls.Add(this.label28);
            this.grb_HWInfo.Controls.Add(this.txt_SerialNum_EngT);
            this.grb_HWInfo.Controls.Add(this.label27);
            this.grb_HWInfo.Controls.Add(this.btn_flash_onewire);
            this.grb_HWInfo.Location = new System.Drawing.Point(46, 22);
            this.grb_HWInfo.Name = "grb_HWInfo";
            this.grb_HWInfo.Size = new System.Drawing.Size(649, 55);
            this.grb_HWInfo.TabIndex = 82;
            this.grb_HWInfo.TabStop = false;
            this.grb_HWInfo.Text = "Hardware Info";
            // 
            // cmb_Module_EngT
            // 
            this.cmb_Module_EngT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Module_EngT.FormattingEnabled = true;
            this.cmb_Module_EngT.Items.AddRange(new object[] {
            "5V",
            "+/-15V",
            "3.3V"});
            this.cmb_Module_EngT.Location = new System.Drawing.Point(414, 21);
            this.cmb_Module_EngT.Name = "cmb_Module_EngT";
            this.cmb_Module_EngT.Size = new System.Drawing.Size(61, 21);
            this.cmb_Module_EngT.TabIndex = 88;
            this.cmb_Module_EngT.SelectedIndexChanged += new System.EventHandler(this.cmb_Module_EngT_SelectedIndexChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(372, 24);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 14);
            this.label53.TabIndex = 87;
            this.label53.Text = "Module";
            // 
            // btn_Reset_EngT
            // 
            this.btn_Reset_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Reset_EngT.Location = new System.Drawing.Point(499, 20);
            this.btn_Reset_EngT.Name = "btn_Reset_EngT";
            this.btn_Reset_EngT.Size = new System.Drawing.Size(67, 23);
            this.btn_Reset_EngT.TabIndex = 86;
            this.btn_Reset_EngT.Text = "Reset";
            this.btn_Reset_EngT.UseVisualStyleBackColor = true;
            this.btn_Reset_EngT.Click += new System.EventHandler(this.btn_Reset_EngT_Click);
            // 
            // btn_ModuleCurrent_EngT
            // 
            this.btn_ModuleCurrent_EngT.Location = new System.Drawing.Point(182, 20);
            this.btn_ModuleCurrent_EngT.Name = "btn_ModuleCurrent_EngT";
            this.btn_ModuleCurrent_EngT.Size = new System.Drawing.Size(87, 23);
            this.btn_ModuleCurrent_EngT.TabIndex = 83;
            this.btn_ModuleCurrent_EngT.Text = "Module Current";
            this.btn_ModuleCurrent_EngT.UseVisualStyleBackColor = true;
            this.btn_ModuleCurrent_EngT.Click += new System.EventHandler(this.btn_ModuleCurrent_EngT_Click);
            // 
            // txt_ModuleCurrent_EngT
            // 
            this.txt_ModuleCurrent_EngT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_ModuleCurrent_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_ModuleCurrent_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_ModuleCurrent_EngT.Location = new System.Drawing.Point(275, 21);
            this.txt_ModuleCurrent_EngT.Name = "txt_ModuleCurrent_EngT";
            this.txt_ModuleCurrent_EngT.ReadOnly = true;
            this.txt_ModuleCurrent_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_ModuleCurrent_EngT.TabIndex = 85;
            this.txt_ModuleCurrent_EngT.Text = "0.0";
            this.txt_ModuleCurrent_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(331, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 14);
            this.label28.TabIndex = 84;
            this.label28.Text = "mA";
            // 
            // txt_SerialNum_EngT
            // 
            this.txt_SerialNum_EngT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_SerialNum_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_SerialNum_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_SerialNum_EngT.Location = new System.Drawing.Point(65, 21);
            this.txt_SerialNum_EngT.Name = "txt_SerialNum_EngT";
            this.txt_SerialNum_EngT.ReadOnly = true;
            this.txt_SerialNum_EngT.Size = new System.Drawing.Size(100, 20);
            this.txt_SerialNum_EngT.TabIndex = 83;
            this.txt_SerialNum_EngT.Text = "Null";
            this.txt_SerialNum_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(9, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 14);
            this.label27.TabIndex = 82;
            this.label27.Text = "Serial Num";
            // 
            // btn_flash_onewire
            // 
            this.btn_flash_onewire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_flash_onewire.Location = new System.Drawing.Point(572, 20);
            this.btn_flash_onewire.Name = "btn_flash_onewire";
            this.btn_flash_onewire.Size = new System.Drawing.Size(67, 23);
            this.btn_flash_onewire.TabIndex = 55;
            this.btn_flash_onewire.Text = "FlashLED";
            this.btn_flash_onewire.UseVisualStyleBackColor = true;
            this.btn_flash_onewire.Click += new System.EventHandler(this.btn_flash_onewire_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_PolaritySelect_EngT);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.cmb_OffsetOption_EngT);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.panel7);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.panel6);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.cmb_SensingDirection_EngT);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(432, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 190);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensor Options";
            // 
            // cmb_PolaritySelect_EngT
            // 
            this.cmb_PolaritySelect_EngT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PolaritySelect_EngT.FormattingEnabled = true;
            this.cmb_PolaritySelect_EngT.Items.AddRange(new object[] {
            "Default",
            "Vout@0A = 4.5V",
            "Vout@0A = 0.5"});
            this.cmb_PolaritySelect_EngT.Location = new System.Drawing.Point(113, 155);
            this.cmb_PolaritySelect_EngT.Name = "cmb_PolaritySelect_EngT";
            this.cmb_PolaritySelect_EngT.Size = new System.Drawing.Size(137, 21);
            this.cmb_PolaritySelect_EngT.TabIndex = 9;
            this.cmb_PolaritySelect_EngT.SelectedIndexChanged += new System.EventHandler(this.cmb_PolaritySelect_EngT_SelectedIndexChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(17, 158);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(75, 14);
            this.label45.TabIndex = 8;
            this.label45.Text = "Polarity Select";
            // 
            // cmb_OffsetOption_EngT
            // 
            this.cmb_OffsetOption_EngT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OffsetOption_EngT.FormattingEnabled = true;
            this.cmb_OffsetOption_EngT.Items.AddRange(new object[] {
            "Default",
            "2.5V Low Power",
            "Half Vdd",
            "1.65V Low Power"});
            this.cmb_OffsetOption_EngT.Location = new System.Drawing.Point(113, 121);
            this.cmb_OffsetOption_EngT.Name = "cmb_OffsetOption_EngT";
            this.cmb_OffsetOption_EngT.Size = new System.Drawing.Size(137, 21);
            this.cmb_OffsetOption_EngT.TabIndex = 7;
            this.cmb_OffsetOption_EngT.SelectedIndexChanged += new System.EventHandler(this.cmb_OffsetOption_EngT_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(17, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 14);
            this.label26.TabIndex = 6;
            this.label26.Text = "Offset Option";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rbtn_InsideFilterDefault_EngT);
            this.panel7.Controls.Add(this.rbtn_InsideFilterOff_EngT);
            this.panel7.Location = new System.Drawing.Point(113, 88);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(137, 23);
            this.panel7.TabIndex = 5;
            // 
            // rbtn_InsideFilterDefault_EngT
            // 
            this.rbtn_InsideFilterDefault_EngT.AutoSize = true;
            this.rbtn_InsideFilterDefault_EngT.Checked = true;
            this.rbtn_InsideFilterDefault_EngT.Location = new System.Drawing.Point(76, 3);
            this.rbtn_InsideFilterDefault_EngT.Name = "rbtn_InsideFilterDefault_EngT";
            this.rbtn_InsideFilterDefault_EngT.Size = new System.Drawing.Size(59, 17);
            this.rbtn_InsideFilterDefault_EngT.TabIndex = 1;
            this.rbtn_InsideFilterDefault_EngT.TabStop = true;
            this.rbtn_InsideFilterDefault_EngT.Text = "Default";
            this.rbtn_InsideFilterDefault_EngT.UseVisualStyleBackColor = true;
            // 
            // rbtn_InsideFilterOff_EngT
            // 
            this.rbtn_InsideFilterOff_EngT.AutoSize = true;
            this.rbtn_InsideFilterOff_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbtn_InsideFilterOff_EngT.Name = "rbtn_InsideFilterOff_EngT";
            this.rbtn_InsideFilterOff_EngT.Size = new System.Drawing.Size(64, 17);
            this.rbtn_InsideFilterOff_EngT.TabIndex = 0;
            this.rbtn_InsideFilterOff_EngT.Text = "Filter Off";
            this.rbtn_InsideFilterOff_EngT.UseVisualStyleBackColor = true;
            this.rbtn_InsideFilterOff_EngT.CheckedChanged += new System.EventHandler(this.rbtn_InsideFilterOff_EngT_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(17, 92);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 14);
            this.label25.TabIndex = 4;
            this.label25.Text = "Inside Filter";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rbtn_VoutOpetionDefault_EngT);
            this.panel6.Controls.Add(this.rbtn_VoutOptionHigh_EngT);
            this.panel6.Location = new System.Drawing.Point(113, 54);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(137, 23);
            this.panel6.TabIndex = 3;
            // 
            // rbtn_VoutOpetionDefault_EngT
            // 
            this.rbtn_VoutOpetionDefault_EngT.AutoSize = true;
            this.rbtn_VoutOpetionDefault_EngT.Checked = true;
            this.rbtn_VoutOpetionDefault_EngT.Location = new System.Drawing.Point(76, 3);
            this.rbtn_VoutOpetionDefault_EngT.Name = "rbtn_VoutOpetionDefault_EngT";
            this.rbtn_VoutOpetionDefault_EngT.Size = new System.Drawing.Size(59, 17);
            this.rbtn_VoutOpetionDefault_EngT.TabIndex = 1;
            this.rbtn_VoutOpetionDefault_EngT.TabStop = true;
            this.rbtn_VoutOpetionDefault_EngT.Text = "Default";
            this.rbtn_VoutOpetionDefault_EngT.UseVisualStyleBackColor = true;
            // 
            // rbtn_VoutOptionHigh_EngT
            // 
            this.rbtn_VoutOptionHigh_EngT.AutoSize = true;
            this.rbtn_VoutOptionHigh_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbtn_VoutOptionHigh_EngT.Name = "rbtn_VoutOptionHigh_EngT";
            this.rbtn_VoutOptionHigh_EngT.Size = new System.Drawing.Size(72, 17);
            this.rbtn_VoutOptionHigh_EngT.TabIndex = 0;
            this.rbtn_VoutOptionHigh_EngT.Text = "Vout High";
            this.rbtn_VoutOptionHigh_EngT.UseVisualStyleBackColor = true;
            this.rbtn_VoutOptionHigh_EngT.CheckedChanged += new System.EventHandler(this.rbtn_VoutOptionHigh_EngT_CheckedChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(17, 59);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 14);
            this.label24.TabIndex = 2;
            this.label24.Text = "Vout Option";
            // 
            // cmb_SensingDirection_EngT
            // 
            this.cmb_SensingDirection_EngT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SensingDirection_EngT.FormattingEnabled = true;
            this.cmb_SensingDirection_EngT.Items.AddRange(new object[] {
            "Default",
            "Resistor Type",
            "Invert Default",
            "Invert Resistor Type"});
            this.cmb_SensingDirection_EngT.Location = new System.Drawing.Point(113, 22);
            this.cmb_SensingDirection_EngT.MinimumSize = new System.Drawing.Size(137, 0);
            this.cmb_SensingDirection_EngT.Name = "cmb_SensingDirection_EngT";
            this.cmb_SensingDirection_EngT.Size = new System.Drawing.Size(137, 21);
            this.cmb_SensingDirection_EngT.TabIndex = 1;
            this.cmb_SensingDirection_EngT.SelectedIndexChanged += new System.EventHandler(this.cmb_SensingDirection_EngT_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(17, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 14);
            this.label23.TabIndex = 0;
            this.label23.Text = "Sensing Direction";
            // 
            // btn_ADCReset
            // 
            this.btn_ADCReset.Location = new System.Drawing.Point(5, 545);
            this.btn_ADCReset.Name = "btn_ADCReset";
            this.btn_ADCReset.Size = new System.Drawing.Size(73, 23);
            this.btn_ADCReset.TabIndex = 80;
            this.btn_ADCReset.Text = "Reset ADC";
            this.btn_ADCReset.UseVisualStyleBackColor = true;
            this.btn_ADCReset.Visible = false;
            this.btn_ADCReset.Click += new System.EventHandler(this.btn_ADCReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(432, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 229);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hardware Control";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rbtn_CSResistorSet_EngT);
            this.panel8.Controls.Add(this.rbtn_CSResistorByPass_EngT);
            this.panel8.Location = new System.Drawing.Point(153, 166);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(97, 47);
            this.panel8.TabIndex = 12;
            // 
            // rbtn_CSResistorSet_EngT
            // 
            this.rbtn_CSResistorSet_EngT.AutoSize = true;
            this.rbtn_CSResistorSet_EngT.Location = new System.Drawing.Point(3, 24);
            this.rbtn_CSResistorSet_EngT.Name = "rbtn_CSResistorSet_EngT";
            this.rbtn_CSResistorSet_EngT.Size = new System.Drawing.Size(41, 17);
            this.rbtn_CSResistorSet_EngT.TabIndex = 1;
            this.rbtn_CSResistorSet_EngT.Text = "Set";
            this.rbtn_CSResistorSet_EngT.UseVisualStyleBackColor = true;
            // 
            // rbtn_CSResistorByPass_EngT
            // 
            this.rbtn_CSResistorByPass_EngT.AutoSize = true;
            this.rbtn_CSResistorByPass_EngT.Checked = true;
            this.rbtn_CSResistorByPass_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbtn_CSResistorByPass_EngT.Name = "rbtn_CSResistorByPass_EngT";
            this.rbtn_CSResistorByPass_EngT.Size = new System.Drawing.Size(59, 17);
            this.rbtn_CSResistorByPass_EngT.TabIndex = 0;
            this.rbtn_CSResistorByPass_EngT.TabStop = true;
            this.rbtn_CSResistorByPass_EngT.Text = "Bypass";
            this.rbtn_CSResistorByPass_EngT.UseVisualStyleBackColor = true;
            this.rbtn_CSResistorByPass_EngT.CheckedChanged += new System.EventHandler(this.rbtn_CSResistorByPass_EngT_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(153, 151);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "CS Resistor";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(94, 113);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "--------------";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbt_signalPathSeting_Config_EngT);
            this.panel4.Controls.Add(this.rbt_signalPathSeting_AIn_EngT);
            this.panel4.Location = new System.Drawing.Point(153, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(97, 45);
            this.panel4.TabIndex = 9;
            // 
            // rbt_signalPathSeting_Config_EngT
            // 
            this.rbt_signalPathSeting_Config_EngT.AutoSize = true;
            this.rbt_signalPathSeting_Config_EngT.Checked = true;
            this.rbt_signalPathSeting_Config_EngT.Location = new System.Drawing.Point(3, 25);
            this.rbt_signalPathSeting_Config_EngT.Name = "rbt_signalPathSeting_Config_EngT";
            this.rbt_signalPathSeting_Config_EngT.Size = new System.Drawing.Size(65, 17);
            this.rbt_signalPathSeting_Config_EngT.TabIndex = 1;
            this.rbt_signalPathSeting_Config_EngT.TabStop = true;
            this.rbt_signalPathSeting_Config_EngT.Text = "CONFIG";
            this.rbt_signalPathSeting_Config_EngT.UseVisualStyleBackColor = true;
            // 
            // rbt_signalPathSeting_AIn_EngT
            // 
            this.rbt_signalPathSeting_AIn_EngT.AutoSize = true;
            this.rbt_signalPathSeting_AIn_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbt_signalPathSeting_AIn_EngT.Name = "rbt_signalPathSeting_AIn_EngT";
            this.rbt_signalPathSeting_AIn_EngT.Size = new System.Drawing.Size(43, 17);
            this.rbt_signalPathSeting_AIn_EngT.TabIndex = 0;
            this.rbt_signalPathSeting_AIn_EngT.Text = "AIN";
            this.rbt_signalPathSeting_AIn_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_AIn_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbt_signalPathSeting_Mout_EngT);
            this.panel5.Controls.Add(this.rbt_signalPathSeting_510Out_EngT);
            this.panel5.Controls.Add(this.rbt_signalPathSeting_VCS_EngT);
            this.panel5.Controls.Add(this.rbt_signalPathSeting_Vref_EngT);
            this.panel5.Controls.Add(this.rbt_signalPathSeting_Vout_EngT);
            this.panel5.Location = new System.Drawing.Point(20, 99);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(85, 114);
            this.panel5.TabIndex = 7;
            // 
            // rbt_signalPathSeting_Mout_EngT
            // 
            this.rbt_signalPathSeting_Mout_EngT.AutoSize = true;
            this.rbt_signalPathSeting_Mout_EngT.Location = new System.Drawing.Point(12, 93);
            this.rbt_signalPathSeting_Mout_EngT.Name = "rbt_signalPathSeting_Mout_EngT";
            this.rbt_signalPathSeting_Mout_EngT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_Mout_EngT.Size = new System.Drawing.Size(49, 17);
            this.rbt_signalPathSeting_Mout_EngT.TabIndex = 4;
            this.rbt_signalPathSeting_Mout_EngT.Text = "Mout";
            this.rbt_signalPathSeting_Mout_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_Mout_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // rbt_signalPathSeting_510Out_EngT
            // 
            this.rbt_signalPathSeting_510Out_EngT.AutoSize = true;
            this.rbt_signalPathSeting_510Out_EngT.Location = new System.Drawing.Point(3, 70);
            this.rbt_signalPathSeting_510Out_EngT.Name = "rbt_signalPathSeting_510Out_EngT";
            this.rbt_signalPathSeting_510Out_EngT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_510Out_EngT.Size = new System.Drawing.Size(58, 17);
            this.rbt_signalPathSeting_510Out_EngT.TabIndex = 3;
            this.rbt_signalPathSeting_510Out_EngT.Text = "510out";
            this.rbt_signalPathSeting_510Out_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_510Out_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // rbt_signalPathSeting_VCS_EngT
            // 
            this.rbt_signalPathSeting_VCS_EngT.AutoSize = true;
            this.rbt_signalPathSeting_VCS_EngT.Location = new System.Drawing.Point(15, 48);
            this.rbt_signalPathSeting_VCS_EngT.Name = "rbt_signalPathSeting_VCS_EngT";
            this.rbt_signalPathSeting_VCS_EngT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_VCS_EngT.Size = new System.Drawing.Size(46, 17);
            this.rbt_signalPathSeting_VCS_EngT.TabIndex = 2;
            this.rbt_signalPathSeting_VCS_EngT.Text = "VCS";
            this.rbt_signalPathSeting_VCS_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_VCS_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // rbt_signalPathSeting_Vref_EngT
            // 
            this.rbt_signalPathSeting_Vref_EngT.AutoSize = true;
            this.rbt_signalPathSeting_Vref_EngT.Location = new System.Drawing.Point(17, 25);
            this.rbt_signalPathSeting_Vref_EngT.Name = "rbt_signalPathSeting_Vref_EngT";
            this.rbt_signalPathSeting_Vref_EngT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_Vref_EngT.Size = new System.Drawing.Size(44, 17);
            this.rbt_signalPathSeting_Vref_EngT.TabIndex = 1;
            this.rbt_signalPathSeting_Vref_EngT.Text = "Vref";
            this.rbt_signalPathSeting_Vref_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_Vref_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // rbt_signalPathSeting_Vout_EngT
            // 
            this.rbt_signalPathSeting_Vout_EngT.AutoSize = true;
            this.rbt_signalPathSeting_Vout_EngT.Checked = true;
            this.rbt_signalPathSeting_Vout_EngT.Location = new System.Drawing.Point(14, 3);
            this.rbt_signalPathSeting_Vout_EngT.Name = "rbt_signalPathSeting_Vout_EngT";
            this.rbt_signalPathSeting_Vout_EngT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_Vout_EngT.Size = new System.Drawing.Size(47, 17);
            this.rbt_signalPathSeting_Vout_EngT.TabIndex = 0;
            this.rbt_signalPathSeting_Vout_EngT.TabStop = true;
            this.rbt_signalPathSeting_Vout_EngT.Text = "Vout";
            this.rbt_signalPathSeting_Vout_EngT.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_Vout_EngT.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbt_withoutCap_Vout_EngT);
            this.panel2.Controls.Add(this.rbt_withCap_Vout_EngT);
            this.panel2.Location = new System.Drawing.Point(153, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 45);
            this.panel2.TabIndex = 3;
            // 
            // rbt_withoutCap_Vout_EngT
            // 
            this.rbt_withoutCap_Vout_EngT.AutoSize = true;
            this.rbt_withoutCap_Vout_EngT.Location = new System.Drawing.Point(3, 25);
            this.rbt_withoutCap_Vout_EngT.Name = "rbt_withoutCap_Vout_EngT";
            this.rbt_withoutCap_Vout_EngT.Size = new System.Drawing.Size(84, 17);
            this.rbt_withoutCap_Vout_EngT.TabIndex = 1;
            this.rbt_withoutCap_Vout_EngT.Text = "Without Cap";
            this.rbt_withoutCap_Vout_EngT.UseVisualStyleBackColor = true;
            // 
            // rbt_withCap_Vout_EngT
            // 
            this.rbt_withCap_Vout_EngT.AutoSize = true;
            this.rbt_withCap_Vout_EngT.Checked = true;
            this.rbt_withCap_Vout_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbt_withCap_Vout_EngT.Name = "rbt_withCap_Vout_EngT";
            this.rbt_withCap_Vout_EngT.Size = new System.Drawing.Size(69, 17);
            this.rbt_withCap_Vout_EngT.TabIndex = 0;
            this.rbt_withCap_Vout_EngT.TabStop = true;
            this.rbt_withCap_Vout_EngT.Text = "With Cap";
            this.rbt_withCap_Vout_EngT.UseVisualStyleBackColor = true;
            this.rbt_withCap_Vout_EngT.CheckedChanged += new System.EventHandler(this.rbt_withCap_Vout_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(153, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 14);
            this.label13.TabIndex = 2;
            this.label13.Text = "Vout and Vref";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtb_VDD_Ext_EngT);
            this.panel1.Controls.Add(this.rbt_VDD_5V_EngT);
            this.panel1.Location = new System.Drawing.Point(20, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 45);
            this.panel1.TabIndex = 1;
            // 
            // rtb_VDD_Ext_EngT
            // 
            this.rtb_VDD_Ext_EngT.AutoSize = true;
            this.rtb_VDD_Ext_EngT.Location = new System.Drawing.Point(3, 25);
            this.rtb_VDD_Ext_EngT.Name = "rtb_VDD_Ext_EngT";
            this.rtb_VDD_Ext_EngT.Size = new System.Drawing.Size(73, 17);
            this.rtb_VDD_Ext_EngT.TabIndex = 1;
            this.rtb_VDD_Ext_EngT.Text = "Ext Power";
            this.rtb_VDD_Ext_EngT.UseVisualStyleBackColor = true;
            // 
            // rbt_VDD_5V_EngT
            // 
            this.rbt_VDD_5V_EngT.AutoSize = true;
            this.rbt_VDD_5V_EngT.Checked = true;
            this.rbt_VDD_5V_EngT.Location = new System.Drawing.Point(3, 3);
            this.rbt_VDD_5V_EngT.Name = "rbt_VDD_5V_EngT";
            this.rbt_VDD_5V_EngT.Size = new System.Drawing.Size(41, 17);
            this.rbt_VDD_5V_EngT.TabIndex = 0;
            this.rbt_VDD_5V_EngT.TabStop = true;
            this.rbt_VDD_5V_EngT.Text = "5 V";
            this.rbt_VDD_5V_EngT.UseVisualStyleBackColor = true;
            this.rbt_VDD_5V_EngT.CheckedChanged += new System.EventHandler(this.rbt_5V_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "VDD";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SafetyHighRead_EngT);
            this.groupBox1.Controls.Add(this.btn_SafetyRead_EngT);
            this.groupBox1.Controls.Add(this.btn_burstRead_EngT);
            this.groupBox1.Controls.Add(this.btn_MarginalRead_EngT);
            this.groupBox1.Controls.Add(this.btn_Vout0A_EngT);
            this.groupBox1.Controls.Add(this.btn_Reload_EngT);
            this.groupBox1.Controls.Add(this.btn_VoutIP_EngT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_reg83_EngT);
            this.groupBox1.Controls.Add(this.txt_reg82_EngT);
            this.groupBox1.Controls.Add(this.txt_reg81_EngT);
            this.groupBox1.Controls.Add(this.txt_reg80_EngT);
            this.groupBox1.Controls.Add(this.btn_writeFuseCode_EngT);
            this.groupBox1.Controls.Add(this.btn_fuse_clock_ow_EngT);
            this.groupBox1.Controls.Add(this.btn_fuse_action_ow_EngT);
            this.groupBox1.Controls.Add(this.btn_enterNomalMode_EngT);
            this.groupBox1.Controls.Add(this.btn_offset_EngT);
            this.groupBox1.Controls.Add(this.btn_CalcGainCode_EngT);
            this.groupBox1.Controls.Add(this.btn_PowerOff_OWCI_ADC_EngT);
            this.groupBox1.Controls.Add(this.btn_PowerOn_OWCI_ADC_EngT);
            this.groupBox1.Location = new System.Drawing.Point(46, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 280);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trim Sensor";
            // 
            // btn_SafetyHighRead_EngT
            // 
            this.btn_SafetyHighRead_EngT.Location = new System.Drawing.Point(206, 229);
            this.btn_SafetyHighRead_EngT.Name = "btn_SafetyHighRead_EngT";
            this.btn_SafetyHighRead_EngT.Size = new System.Drawing.Size(43, 38);
            this.btn_SafetyHighRead_EngT.TabIndex = 82;
            this.btn_SafetyHighRead_EngT.Text = "8X";
            this.btn_SafetyHighRead_EngT.UseVisualStyleBackColor = true;
            this.btn_SafetyHighRead_EngT.Click += new System.EventHandler(this.btn_SafetyHighRead_EngT_Click);
            // 
            // btn_SafetyRead_EngT
            // 
            this.btn_SafetyRead_EngT.Location = new System.Drawing.Point(143, 229);
            this.btn_SafetyRead_EngT.Name = "btn_SafetyRead_EngT";
            this.btn_SafetyRead_EngT.Size = new System.Drawing.Size(43, 38);
            this.btn_SafetyRead_EngT.TabIndex = 82;
            this.btn_SafetyRead_EngT.Text = "4X";
            this.btn_SafetyRead_EngT.UseVisualStyleBackColor = true;
            this.btn_SafetyRead_EngT.Click += new System.EventHandler(this.btn_SafetyRead_EngT_Click);
            // 
            // btn_burstRead_EngT
            // 
            this.btn_burstRead_EngT.Location = new System.Drawing.Point(269, 229);
            this.btn_burstRead_EngT.Name = "btn_burstRead_EngT";
            this.btn_burstRead_EngT.Size = new System.Drawing.Size(53, 38);
            this.btn_burstRead_EngT.TabIndex = 63;
            this.btn_burstRead_EngT.Text = "Read";
            this.btn_burstRead_EngT.UseVisualStyleBackColor = true;
            this.btn_burstRead_EngT.Click += new System.EventHandler(this.btn_burstRead_Click);
            // 
            // btn_MarginalRead_EngT
            // 
            this.btn_MarginalRead_EngT.Location = new System.Drawing.Point(80, 229);
            this.btn_MarginalRead_EngT.Name = "btn_MarginalRead_EngT";
            this.btn_MarginalRead_EngT.Size = new System.Drawing.Size(43, 38);
            this.btn_MarginalRead_EngT.TabIndex = 64;
            this.btn_MarginalRead_EngT.Text = "2X";
            this.btn_MarginalRead_EngT.UseVisualStyleBackColor = true;
            this.btn_MarginalRead_EngT.Click += new System.EventHandler(this.btn_MarginalRead_Click);
            // 
            // btn_Vout0A_EngT
            // 
            this.btn_Vout0A_EngT.Location = new System.Drawing.Point(17, 143);
            this.btn_Vout0A_EngT.Name = "btn_Vout0A_EngT";
            this.btn_Vout0A_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_Vout0A_EngT.TabIndex = 81;
            this.btn_Vout0A_EngT.Text = "Vout @ 0A";
            this.btn_Vout0A_EngT.UseVisualStyleBackColor = true;
            this.btn_Vout0A_EngT.Click += new System.EventHandler(this.btn_Vout0A_EngT_Click);
            // 
            // btn_Reload_EngT
            // 
            this.btn_Reload_EngT.Location = new System.Drawing.Point(17, 229);
            this.btn_Reload_EngT.Name = "btn_Reload_EngT";
            this.btn_Reload_EngT.Size = new System.Drawing.Size(43, 38);
            this.btn_Reload_EngT.TabIndex = 65;
            this.btn_Reload_EngT.Text = "1X";
            this.btn_Reload_EngT.UseVisualStyleBackColor = true;
            this.btn_Reload_EngT.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_VoutIP_EngT
            // 
            this.btn_VoutIP_EngT.Location = new System.Drawing.Point(17, 103);
            this.btn_VoutIP_EngT.Name = "btn_VoutIP_EngT";
            this.btn_VoutIP_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_VoutIP_EngT.TabIndex = 80;
            this.btn_VoutIP_EngT.Text = "Vout @ IP";
            this.btn_VoutIP_EngT.UseVisualStyleBackColor = true;
            this.btn_VoutIP_EngT.Click += new System.EventHandler(this.btn_VoutIP_EngT_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(284, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 79;
            this.label5.Text = "Reg83";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(199, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "Reg82";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 14);
            this.label3.TabIndex = 77;
            this.label3.Text = "Reg81";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 76;
            this.label2.Text = "Reg80";
            // 
            // txt_reg83_EngT
            // 
            this.txt_reg83_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg83_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg83_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_reg83_EngT.Location = new System.Drawing.Point(271, 196);
            this.txt_reg83_EngT.Name = "txt_reg83_EngT";
            this.txt_reg83_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_reg83_EngT.TabIndex = 75;
            this.txt_reg83_EngT.Text = "0x00";
            this.txt_reg83_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg83_EngT.TextChanged += new System.EventHandler(this.txt_reg83_EngT_TextChanged);
            this.txt_reg83_EngT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg82_EngT
            // 
            this.txt_reg82_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg82_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg82_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_reg82_EngT.Location = new System.Drawing.Point(186, 196);
            this.txt_reg82_EngT.Name = "txt_reg82_EngT";
            this.txt_reg82_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_reg82_EngT.TabIndex = 74;
            this.txt_reg82_EngT.Text = "0x00";
            this.txt_reg82_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg82_EngT.TextChanged += new System.EventHandler(this.txt_reg82_EngT_TextChanged);
            this.txt_reg82_EngT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg81_EngT
            // 
            this.txt_reg81_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg81_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg81_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_reg81_EngT.Location = new System.Drawing.Point(101, 196);
            this.txt_reg81_EngT.Name = "txt_reg81_EngT";
            this.txt_reg81_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_reg81_EngT.TabIndex = 73;
            this.txt_reg81_EngT.Text = "0x00";
            this.txt_reg81_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg81_EngT.TextChanged += new System.EventHandler(this.txt_reg81_EngT_TextChanged);
            this.txt_reg81_EngT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg80_EngT
            // 
            this.txt_reg80_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg80_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg80_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_reg80_EngT.Location = new System.Drawing.Point(16, 196);
            this.txt_reg80_EngT.Name = "txt_reg80_EngT";
            this.txt_reg80_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_reg80_EngT.TabIndex = 72;
            this.txt_reg80_EngT.Text = "0x00";
            this.txt_reg80_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg80_EngT.TextChanged += new System.EventHandler(this.txt_reg80_EngT_TextChanged);
            this.txt_reg80_EngT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // btn_writeFuseCode_EngT
            // 
            this.btn_writeFuseCode_EngT.Location = new System.Drawing.Point(187, 103);
            this.btn_writeFuseCode_EngT.Name = "btn_writeFuseCode_EngT";
            this.btn_writeFuseCode_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_writeFuseCode_EngT.TabIndex = 71;
            this.btn_writeFuseCode_EngT.Text = "Write Fuse Code";
            this.btn_writeFuseCode_EngT.UseVisualStyleBackColor = true;
            this.btn_writeFuseCode_EngT.Click += new System.EventHandler(this.btn_writeFuseCode_Click);
            // 
            // btn_fuse_clock_ow_EngT
            // 
            this.btn_fuse_clock_ow_EngT.Location = new System.Drawing.Point(257, 143);
            this.btn_fuse_clock_ow_EngT.Name = "btn_fuse_clock_ow_EngT";
            this.btn_fuse_clock_ow_EngT.Size = new System.Drawing.Size(65, 23);
            this.btn_fuse_clock_ow_EngT.TabIndex = 54;
            this.btn_fuse_clock_ow_EngT.Text = "Fuse";
            this.btn_fuse_clock_ow_EngT.UseVisualStyleBackColor = true;
            this.btn_fuse_clock_ow_EngT.Click += new System.EventHandler(this.btn_fuse_clock_ow_EngT_Click);
            // 
            // btn_fuse_action_ow_EngT
            // 
            this.btn_fuse_action_ow_EngT.Location = new System.Drawing.Point(187, 143);
            this.btn_fuse_action_ow_EngT.Name = "btn_fuse_action_ow_EngT";
            this.btn_fuse_action_ow_EngT.Size = new System.Drawing.Size(65, 23);
            this.btn_fuse_action_ow_EngT.TabIndex = 54;
            this.btn_fuse_action_ow_EngT.Text = "FuseKey";
            this.btn_fuse_action_ow_EngT.UseVisualStyleBackColor = true;
            this.btn_fuse_action_ow_EngT.Click += new System.EventHandler(this.btn_fuse_action_ow_Click);
            // 
            // btn_enterNomalMode_EngT
            // 
            this.btn_enterNomalMode_EngT.Location = new System.Drawing.Point(17, 63);
            this.btn_enterNomalMode_EngT.Name = "btn_enterNomalMode_EngT";
            this.btn_enterNomalMode_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_enterNomalMode_EngT.TabIndex = 61;
            this.btn_enterNomalMode_EngT.Text = "Enter Normal Mode";
            this.btn_enterNomalMode_EngT.UseVisualStyleBackColor = true;
            this.btn_enterNomalMode_EngT.Click += new System.EventHandler(this.btn_enterNomalMode_Click);
            // 
            // btn_offset_EngT
            // 
            this.btn_offset_EngT.Location = new System.Drawing.Point(187, 63);
            this.btn_offset_EngT.Name = "btn_offset_EngT";
            this.btn_offset_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_offset_EngT.TabIndex = 60;
            this.btn_offset_EngT.Text = "Calculate Offset Code";
            this.btn_offset_EngT.UseVisualStyleBackColor = true;
            this.btn_offset_EngT.Click += new System.EventHandler(this.btn_offset_Click);
            // 
            // btn_CalcGainCode_EngT
            // 
            this.btn_CalcGainCode_EngT.Location = new System.Drawing.Point(187, 23);
            this.btn_CalcGainCode_EngT.Name = "btn_CalcGainCode_EngT";
            this.btn_CalcGainCode_EngT.Size = new System.Drawing.Size(135, 23);
            this.btn_CalcGainCode_EngT.TabIndex = 58;
            this.btn_CalcGainCode_EngT.Text = "Calculate Gain Code";
            this.btn_CalcGainCode_EngT.UseVisualStyleBackColor = true;
            this.btn_CalcGainCode_EngT.Click += new System.EventHandler(this.btn_CalcGainCode_EngT_Click);
            // 
            // btn_PowerOff_OWCI_ADC_EngT
            // 
            this.btn_PowerOff_OWCI_ADC_EngT.Location = new System.Drawing.Point(90, 23);
            this.btn_PowerOff_OWCI_ADC_EngT.Name = "btn_PowerOff_OWCI_ADC_EngT";
            this.btn_PowerOff_OWCI_ADC_EngT.Size = new System.Drawing.Size(62, 23);
            this.btn_PowerOff_OWCI_ADC_EngT.TabIndex = 57;
            this.btn_PowerOff_OWCI_ADC_EngT.Text = "Power Off";
            this.btn_PowerOff_OWCI_ADC_EngT.UseVisualStyleBackColor = true;
            this.btn_PowerOff_OWCI_ADC_EngT.Click += new System.EventHandler(this.btn_PowerOff_OWCI_ADC_Click);
            // 
            // btn_PowerOn_OWCI_ADC_EngT
            // 
            this.btn_PowerOn_OWCI_ADC_EngT.Location = new System.Drawing.Point(17, 23);
            this.btn_PowerOn_OWCI_ADC_EngT.Name = "btn_PowerOn_OWCI_ADC_EngT";
            this.btn_PowerOn_OWCI_ADC_EngT.Size = new System.Drawing.Size(62, 23);
            this.btn_PowerOn_OWCI_ADC_EngT.TabIndex = 56;
            this.btn_PowerOn_OWCI_ADC_EngT.Text = "Power On";
            this.btn_PowerOn_OWCI_ADC_EngT.UseVisualStyleBackColor = true;
            this.btn_PowerOn_OWCI_ADC_EngT.Click += new System.EventHandler(this.btn_PowerOn_OWCI_ADC_Click);
            // 
            // grb_devInfo_ow
            // 
            this.grb_devInfo_ow.Controls.Add(this.txt_sampleNum_EngT);
            this.grb_devInfo_ow.Controls.Add(this.label18);
            this.grb_devInfo_ow.Controls.Add(this.label16);
            this.grb_devInfo_ow.Controls.Add(this.txt_sampleRate_EngT);
            this.grb_devInfo_ow.Controls.Add(this.label15);
            this.grb_devInfo_ow.Controls.Add(this.label7);
            this.grb_devInfo_ow.Controls.Add(this.label8);
            this.grb_devInfo_ow.Controls.Add(this.numUD_pilotwidth_ow_EngT);
            this.grb_devInfo_ow.Controls.Add(this.numUD_pulsedurationtime_ow_EngT);
            this.grb_devInfo_ow.Controls.Add(this.label12);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pilotwidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pulsewidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.txt_TargetGain_EngT);
            this.grb_devInfo_ow.Controls.Add(this.num_UD_pulsewidth_ow_EngT);
            this.grb_devInfo_ow.Controls.Add(this.txt_dev_addr_onewire_EngT);
            this.grb_devInfo_ow.Controls.Add(this.label11);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pulsedurationtime_ow);
            this.grb_devInfo_ow.Controls.Add(this.txt_IP_EngT);
            this.grb_devInfo_ow.Controls.Add(this.lbl_devAddr_onewire);
            this.grb_devInfo_ow.Controls.Add(this.label6);
            this.grb_devInfo_ow.Controls.Add(this.label10);
            this.grb_devInfo_ow.Controls.Add(this.label9);
            this.grb_devInfo_ow.Location = new System.Drawing.Point(46, 99);
            this.grb_devInfo_ow.Name = "grb_devInfo_ow";
            this.grb_devInfo_ow.Size = new System.Drawing.Size(338, 140);
            this.grb_devInfo_ow.TabIndex = 57;
            this.grb_devInfo_ow.TabStop = false;
            this.grb_devInfo_ow.Text = "Device Setting";
            // 
            // txt_sampleNum_EngT
            // 
            this.txt_sampleNum_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_sampleNum_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_sampleNum_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_sampleNum_EngT.Location = new System.Drawing.Point(74, 53);
            this.txt_sampleNum_EngT.Name = "txt_sampleNum_EngT";
            this.txt_sampleNum_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_sampleNum_EngT.TabIndex = 81;
            this.txt_sampleNum_EngT.Text = "2048";
            this.txt_sampleNum_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sampleNum_EngT.TextChanged += new System.EventHandler(this.txt_sampleNum_EngT_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 14);
            this.label18.TabIndex = 80;
            this.label18.Text = "Sample Num";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(133, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 14);
            this.label16.TabIndex = 79;
            this.label16.Text = "KHz";
            // 
            // txt_sampleRate_EngT
            // 
            this.txt_sampleRate_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_sampleRate_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_sampleRate_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_sampleRate_EngT.Location = new System.Drawing.Point(74, 81);
            this.txt_sampleRate_EngT.Name = "txt_sampleRate_EngT";
            this.txt_sampleRate_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_sampleRate_EngT.TabIndex = 78;
            this.txt_sampleRate_EngT.Text = "1000";
            this.txt_sampleRate_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sampleRate_EngT.TextChanged += new System.EventHandler(this.txt_sampleRate_EngT_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 14);
            this.label15.TabIndex = 77;
            this.label15.Text = "Sample Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(308, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 14);
            this.label7.TabIndex = 55;
            this.label7.Text = "ns";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(308, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 14);
            this.label8.TabIndex = 56;
            this.label8.Text = "ns";
            // 
            // numUD_pilotwidth_ow_EngT
            // 
            this.numUD_pilotwidth_ow_EngT.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow_EngT.Location = new System.Drawing.Point(252, 25);
            this.numUD_pilotwidth_ow_EngT.Maximum = new decimal(new int[] {
            255000,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow_EngT.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow_EngT.Name = "numUD_pilotwidth_ow_EngT";
            this.numUD_pilotwidth_ow_EngT.Size = new System.Drawing.Size(56, 20);
            this.numUD_pilotwidth_ow_EngT.TabIndex = 47;
            this.numUD_pilotwidth_ow_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_pilotwidth_ow_EngT.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow_EngT.ValueChanged += new System.EventHandler(this.numUD_pilotwidth_ow_ValueChanged);
            // 
            // numUD_pulsedurationtime_ow_EngT
            // 
            this.numUD_pulsedurationtime_ow_EngT.Location = new System.Drawing.Point(252, 73);
            this.numUD_pulsedurationtime_ow_EngT.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_pulsedurationtime_ow_EngT.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUD_pulsedurationtime_ow_EngT.Name = "numUD_pulsedurationtime_ow_EngT";
            this.numUD_pulsedurationtime_ow_EngT.Size = new System.Drawing.Size(56, 20);
            this.numUD_pulsedurationtime_ow_EngT.TabIndex = 51;
            this.numUD_pulsedurationtime_ow_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_pulsedurationtime_ow_EngT.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(303, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 14);
            this.label12.TabIndex = 76;
            this.label12.Text = "A";
            // 
            // lbl_pilotwidth_ow
            // 
            this.lbl_pilotwidth_ow.AutoSize = true;
            this.lbl_pilotwidth_ow.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pilotwidth_ow.Location = new System.Drawing.Point(176, 29);
            this.lbl_pilotwidth_ow.Name = "lbl_pilotwidth_ow";
            this.lbl_pilotwidth_ow.Size = new System.Drawing.Size(62, 14);
            this.lbl_pilotwidth_ow.TabIndex = 46;
            this.lbl_pilotwidth_ow.Text = "Pilot Width";
            // 
            // lbl_pulsewidth_ow
            // 
            this.lbl_pulsewidth_ow.AutoSize = true;
            this.lbl_pulsewidth_ow.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pulsewidth_ow.Location = new System.Drawing.Point(176, 54);
            this.lbl_pulsewidth_ow.Name = "lbl_pulsewidth_ow";
            this.lbl_pulsewidth_ow.Size = new System.Drawing.Size(63, 14);
            this.lbl_pulsewidth_ow.TabIndex = 49;
            this.lbl_pulsewidth_ow.Text = "Pulse Width";
            // 
            // txt_TargetGain_EngT
            // 
            this.txt_TargetGain_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_TargetGain_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TargetGain_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_TargetGain_EngT.Location = new System.Drawing.Point(74, 109);
            this.txt_TargetGain_EngT.Name = "txt_TargetGain_EngT";
            this.txt_TargetGain_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_TargetGain_EngT.TabIndex = 73;
            this.txt_TargetGain_EngT.Text = "100";
            this.txt_TargetGain_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TargetGain_EngT.TextChanged += new System.EventHandler(this.txt_TargetGain_TextChanged);
            // 
            // num_UD_pulsewidth_ow_EngT
            // 
            this.num_UD_pulsewidth_ow_EngT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow_EngT.Location = new System.Drawing.Point(252, 50);
            this.num_UD_pulsewidth_ow_EngT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow_EngT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_UD_pulsewidth_ow_EngT.Name = "num_UD_pulsewidth_ow_EngT";
            this.num_UD_pulsewidth_ow_EngT.Size = new System.Drawing.Size(56, 20);
            this.num_UD_pulsewidth_ow_EngT.TabIndex = 48;
            this.num_UD_pulsewidth_ow_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_UD_pulsewidth_ow_EngT.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow_EngT.ValueChanged += new System.EventHandler(this.num_UD_pulsewidth_ow_ValueChanged);
            // 
            // txt_dev_addr_onewire_EngT
            // 
            this.txt_dev_addr_onewire_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_dev_addr_onewire_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_dev_addr_onewire_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_dev_addr_onewire_EngT.Location = new System.Drawing.Point(74, 25);
            this.txt_dev_addr_onewire_EngT.Name = "txt_dev_addr_onewire_EngT";
            this.txt_dev_addr_onewire_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_dev_addr_onewire_EngT.TabIndex = 45;
            this.txt_dev_addr_onewire_EngT.Text = "0x73";
            this.txt_dev_addr_onewire_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_dev_addr_onewire_EngT.TextChanged += new System.EventHandler(this.txt_dev_addr_onewire_EngT_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(131, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 14);
            this.label11.TabIndex = 75;
            this.label11.Text = "mV/A";
            // 
            // lbl_pulsedurationtime_ow
            // 
            this.lbl_pulsedurationtime_ow.AutoSize = true;
            this.lbl_pulsedurationtime_ow.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pulsedurationtime_ow.Location = new System.Drawing.Point(176, 77);
            this.lbl_pulsedurationtime_ow.Name = "lbl_pulsedurationtime_ow";
            this.lbl_pulsedurationtime_ow.Size = new System.Drawing.Size(76, 14);
            this.lbl_pulsedurationtime_ow.TabIndex = 52;
            this.lbl_pulsedurationtime_ow.Text = "Duration Time";
            // 
            // txt_IP_EngT
            // 
            this.txt_IP_EngT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_IP_EngT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_IP_EngT.ForeColor = System.Drawing.Color.White;
            this.txt_IP_EngT.Location = new System.Drawing.Point(241, 98);
            this.txt_IP_EngT.Name = "txt_IP_EngT";
            this.txt_IP_EngT.ReadOnly = true;
            this.txt_IP_EngT.Size = new System.Drawing.Size(56, 20);
            this.txt_IP_EngT.TabIndex = 74;
            this.txt_IP_EngT.Text = "20";
            this.txt_IP_EngT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_IP_EngT.TextChanged += new System.EventHandler(this.txt_IP_EngT_TextChanged);
            // 
            // lbl_devAddr_onewire
            // 
            this.lbl_devAddr_onewire.AutoSize = true;
            this.lbl_devAddr_onewire.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_devAddr_onewire.Location = new System.Drawing.Point(9, 29);
            this.lbl_devAddr_onewire.Name = "lbl_devAddr_onewire";
            this.lbl_devAddr_onewire.Size = new System.Drawing.Size(50, 14);
            this.lbl_devAddr_onewire.TabIndex = 44;
            this.lbl_devAddr_onewire.Text = "Dev Addr";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 14);
            this.label6.TabIndex = 53;
            this.label6.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(199, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 14);
            this.label10.TabIndex = 72;
            this.label10.Text = "IP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 14);
            this.label9.TabIndex = 71;
            this.label9.Text = "Target Gain";
            // 
            // btn_preciseTrim
            // 
            this.btn_preciseTrim.Location = new System.Drawing.Point(72, 545);
            this.btn_preciseTrim.Name = "btn_preciseTrim";
            this.btn_preciseTrim.Size = new System.Drawing.Size(135, 23);
            this.btn_preciseTrim.TabIndex = 59;
            this.btn_preciseTrim.Text = "Calculate Precise Code";
            this.btn_preciseTrim.UseVisualStyleBackColor = true;
            this.btn_preciseTrim.Visible = false;
            this.btn_preciseTrim.Click += new System.EventHandler(this.btn_CalcGainCode_EngT_Click);
            // 
            // PriTrimTab
            // 
            this.PriTrimTab.Controls.Add(this.label42);
            this.PriTrimTab.Controls.Add(this.label41);
            this.PriTrimTab.Controls.Add(this.txt_Reg80_PreT);
            this.PriTrimTab.Controls.Add(this.txt_Reg81_PreT);
            this.PriTrimTab.Controls.Add(this.txt_Reg82_PreT);
            this.PriTrimTab.Controls.Add(this.txt_Reg83_PreT);
            this.PriTrimTab.Controls.Add(this.label44);
            this.PriTrimTab.Controls.Add(this.label43);
            this.PriTrimTab.Controls.Add(this.groupBox7);
            this.PriTrimTab.Controls.Add(this.groupBox6);
            this.PriTrimTab.Controls.Add(this.btn_Reset_PreT);
            this.PriTrimTab.Controls.Add(this.btn_FlashLed_PreT);
            this.PriTrimTab.Controls.Add(this.groupBox4);
            this.PriTrimTab.Location = new System.Drawing.Point(4, 22);
            this.PriTrimTab.Name = "PriTrimTab";
            this.PriTrimTab.Size = new System.Drawing.Size(803, 574);
            this.PriTrimTab.TabIndex = 2;
            this.PriTrimTab.Text = "PreTrim";
            this.PriTrimTab.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(729, 156);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(30, 14);
            this.label42.TabIndex = 86;
            this.label42.Text = "Reg3";
            this.label42.Visible = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(729, 174);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(30, 14);
            this.label41.TabIndex = 87;
            this.label41.Text = "Reg4";
            this.label41.Visible = false;
            // 
            // txt_Reg80_PreT
            // 
            this.txt_Reg80_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_Reg80_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_Reg80_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_Reg80_PreT.Location = new System.Drawing.Point(762, 116);
            this.txt_Reg80_PreT.Name = "txt_Reg80_PreT";
            this.txt_Reg80_PreT.ReadOnly = true;
            this.txt_Reg80_PreT.Size = new System.Drawing.Size(37, 20);
            this.txt_Reg80_PreT.TabIndex = 80;
            this.txt_Reg80_PreT.Text = "0x00";
            this.txt_Reg80_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Reg80_PreT.Visible = false;
            this.txt_Reg80_PreT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_Reg81_PreT
            // 
            this.txt_Reg81_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_Reg81_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_Reg81_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_Reg81_PreT.Location = new System.Drawing.Point(762, 134);
            this.txt_Reg81_PreT.Name = "txt_Reg81_PreT";
            this.txt_Reg81_PreT.ReadOnly = true;
            this.txt_Reg81_PreT.Size = new System.Drawing.Size(37, 20);
            this.txt_Reg81_PreT.TabIndex = 81;
            this.txt_Reg81_PreT.Text = "0x00";
            this.txt_Reg81_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Reg81_PreT.Visible = false;
            this.txt_Reg81_PreT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_Reg82_PreT
            // 
            this.txt_Reg82_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_Reg82_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_Reg82_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_Reg82_PreT.Location = new System.Drawing.Point(762, 153);
            this.txt_Reg82_PreT.Name = "txt_Reg82_PreT";
            this.txt_Reg82_PreT.ReadOnly = true;
            this.txt_Reg82_PreT.Size = new System.Drawing.Size(37, 20);
            this.txt_Reg82_PreT.TabIndex = 82;
            this.txt_Reg82_PreT.Text = "0x00";
            this.txt_Reg82_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Reg82_PreT.Visible = false;
            this.txt_Reg82_PreT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_Reg83_PreT
            // 
            this.txt_Reg83_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_Reg83_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_Reg83_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_Reg83_PreT.Location = new System.Drawing.Point(762, 171);
            this.txt_Reg83_PreT.Name = "txt_Reg83_PreT";
            this.txt_Reg83_PreT.ReadOnly = true;
            this.txt_Reg83_PreT.Size = new System.Drawing.Size(37, 20);
            this.txt_Reg83_PreT.TabIndex = 83;
            this.txt_Reg83_PreT.Text = "0x00";
            this.txt_Reg83_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Reg83_PreT.Visible = false;
            this.txt_Reg83_PreT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(729, 119);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(30, 14);
            this.label44.TabIndex = 84;
            this.label44.Text = "Reg1";
            this.label44.Visible = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(729, 137);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(30, 14);
            this.label43.TabIndex = 85;
            this.label43.Text = "Reg2";
            this.label43.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txt_Delay_PreT);
            this.groupBox7.Controls.Add(this.label82);
            this.groupBox7.Controls.Add(this.label81);
            this.groupBox7.Controls.Add(this.label64);
            this.groupBox7.Controls.Add(this.btn_SaveConfig_PreT);
            this.groupBox7.Controls.Add(this.btn_GainCtrlMinus_PreT);
            this.groupBox7.Controls.Add(this.btn_GainCtrlPlus_PreT);
            this.groupBox7.Controls.Add(this.btn_Vout_PreT);
            this.groupBox7.Controls.Add(this.label36);
            this.groupBox7.Controls.Add(this.txt_ChosenGain_PreT);
            this.groupBox7.Controls.Add(this.txt_PresetVoutIP_PreT);
            this.groupBox7.Controls.Add(this.label63);
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Location = new System.Drawing.Point(42, 407);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(714, 132);
            this.groupBox7.TabIndex = 85;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Customization";
            // 
            // txt_Delay_PreT
            // 
            this.txt_Delay_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_Delay_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_Delay_PreT.Location = new System.Drawing.Point(553, 37);
            this.txt_Delay_PreT.Name = "txt_Delay_PreT";
            this.txt_Delay_PreT.Size = new System.Drawing.Size(48, 21);
            this.txt_Delay_PreT.TabIndex = 115;
            this.txt_Delay_PreT.Text = "300";
            this.txt_Delay_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Delay_PreT.TextChanged += new System.EventHandler(this.txt_Delay_PreT_TextChanged);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label82.Location = new System.Drawing.Point(602, 40);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(24, 15);
            this.label82.TabIndex = 114;
            this.label82.Text = "ms";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label81.Location = new System.Drawing.Point(502, 40);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(52, 15);
            this.label81.TabIndex = 114;
            this.label81.Text = "IP Delay";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label64.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label64.Location = new System.Drawing.Point(229, 79);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(23, 19);
            this.label64.TabIndex = 113;
            this.label64.Text = "%";
            // 
            // btn_SaveConfig_PreT
            // 
            this.btn_SaveConfig_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_SaveConfig_PreT.Location = new System.Drawing.Point(505, 71);
            this.btn_SaveConfig_PreT.Name = "btn_SaveConfig_PreT";
            this.btn_SaveConfig_PreT.Size = new System.Drawing.Size(120, 32);
            this.btn_SaveConfig_PreT.TabIndex = 91;
            this.btn_SaveConfig_PreT.Text = "Save Config";
            this.btn_SaveConfig_PreT.UseVisualStyleBackColor = true;
            this.btn_SaveConfig_PreT.Click += new System.EventHandler(this.btn_SaveConfig_PreT_Click);
            // 
            // btn_GainCtrlMinus_PreT
            // 
            this.btn_GainCtrlMinus_PreT.BackgroundImage = global::CurrentSensorV3.Properties.Resources.Minus;
            this.btn_GainCtrlMinus_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_GainCtrlMinus_PreT.Location = new System.Drawing.Point(326, 33);
            this.btn_GainCtrlMinus_PreT.Name = "btn_GainCtrlMinus_PreT";
            this.btn_GainCtrlMinus_PreT.Size = new System.Drawing.Size(32, 32);
            this.btn_GainCtrlMinus_PreT.TabIndex = 90;
            this.btn_GainCtrlMinus_PreT.UseVisualStyleBackColor = true;
            this.btn_GainCtrlMinus_PreT.Click += new System.EventHandler(this.btn_GainCtrlMinus_PreT_Click);
            // 
            // btn_GainCtrlPlus_PreT
            // 
            this.btn_GainCtrlPlus_PreT.BackgroundImage = global::CurrentSensorV3.Properties.Resources.Plus;
            this.btn_GainCtrlPlus_PreT.Location = new System.Drawing.Point(276, 33);
            this.btn_GainCtrlPlus_PreT.Name = "btn_GainCtrlPlus_PreT";
            this.btn_GainCtrlPlus_PreT.Size = new System.Drawing.Size(32, 32);
            this.btn_GainCtrlPlus_PreT.TabIndex = 89;
            this.btn_GainCtrlPlus_PreT.UseVisualStyleBackColor = true;
            this.btn_GainCtrlPlus_PreT.Click += new System.EventHandler(this.btn_GainCtrlPlus_PreT_Click);
            // 
            // btn_Vout_PreT
            // 
            this.btn_Vout_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Vout_PreT.Location = new System.Drawing.Point(276, 71);
            this.btn_Vout_PreT.Name = "btn_Vout_PreT";
            this.btn_Vout_PreT.Size = new System.Drawing.Size(82, 32);
            this.btn_Vout_PreT.TabIndex = 88;
            this.btn_Vout_PreT.Text = "Vout";
            this.btn_Vout_PreT.UseVisualStyleBackColor = true;
            this.btn_Vout_PreT.Click += new System.EventHandler(this.btn_Vout_PreT_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(230, 40);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(20, 19);
            this.label36.TabIndex = 86;
            this.label36.Text = "V";
            // 
            // txt_ChosenGain_PreT
            // 
            this.txt_ChosenGain_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_ChosenGain_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ChosenGain_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_ChosenGain_PreT.Location = new System.Drawing.Point(147, 73);
            this.txt_ChosenGain_PreT.Name = "txt_ChosenGain_PreT";
            this.txt_ChosenGain_PreT.ReadOnly = true;
            this.txt_ChosenGain_PreT.Size = new System.Drawing.Size(83, 31);
            this.txt_ChosenGain_PreT.TabIndex = 85;
            this.txt_ChosenGain_PreT.Text = "100";
            this.txt_ChosenGain_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ChosenGain_PreT.TextChanged += new System.EventHandler(this.txt_ChosenGain_PreT_TextChanged);
            // 
            // txt_PresetVoutIP_PreT
            // 
            this.txt_PresetVoutIP_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_PresetVoutIP_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PresetVoutIP_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_PresetVoutIP_PreT.Location = new System.Drawing.Point(146, 34);
            this.txt_PresetVoutIP_PreT.Name = "txt_PresetVoutIP_PreT";
            this.txt_PresetVoutIP_PreT.ReadOnly = true;
            this.txt_PresetVoutIP_PreT.Size = new System.Drawing.Size(83, 31);
            this.txt_PresetVoutIP_PreT.TabIndex = 85;
            this.txt_PresetVoutIP_PreT.Text = "0";
            this.txt_PresetVoutIP_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label63.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label63.Location = new System.Drawing.Point(52, 79);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(95, 19);
            this.label63.TabIndex = 84;
            this.label63.Text = "PreSet Gain ";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(64, 40);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(70, 19);
            this.label37.TabIndex = 84;
            this.label37.Text = "Vout@IP";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txt_bin3accuracy_PreT);
            this.groupBox6.Controls.Add(this.label76);
            this.groupBox6.Controls.Add(this.label75);
            this.groupBox6.Controls.Add(this.label74);
            this.groupBox6.Controls.Add(this.txt_bin2accuracy_PreT);
            this.groupBox6.Controls.Add(this.label73);
            this.groupBox6.Controls.Add(this.cmb_Voffset_PreT);
            this.groupBox6.Controls.Add(this.label60);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.label66);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.txt_IP_PreT);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.txt_targetvoltage_PreT);
            this.groupBox6.Controls.Add(this.label59);
            this.groupBox6.Controls.Add(this.txt_AdcOffset_PreT);
            this.groupBox6.Controls.Add(this.txt_TargetGain_PreT);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.cmb_IPRange_PreT);
            this.groupBox6.Controls.Add(this.label69);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.cmb_TempCmp_PreT);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.cmb_SensitivityAdapt_PreT);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Location = new System.Drawing.Point(42, 151);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(714, 219);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensor Options";
            // 
            // txt_bin3accuracy_PreT
            // 
            this.txt_bin3accuracy_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_bin3accuracy_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bin3accuracy_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_bin3accuracy_PreT.Location = new System.Drawing.Point(505, 172);
            this.txt_bin3accuracy_PreT.Name = "txt_bin3accuracy_PreT";
            this.txt_bin3accuracy_PreT.Size = new System.Drawing.Size(120, 22);
            this.txt_bin3accuracy_PreT.TabIndex = 97;
            this.txt_bin3accuracy_PreT.Text = "3";
            this.txt_bin3accuracy_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label76.Location = new System.Drawing.Point(631, 175);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(20, 16);
            this.label76.TabIndex = 96;
            this.label76.Text = "%";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(397, 175);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(93, 16);
            this.label75.TabIndex = 95;
            this.label75.Text = "Bin3 Accuracy";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label74.Location = new System.Drawing.Point(631, 141);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(20, 16);
            this.label74.TabIndex = 94;
            this.label74.Text = "%";
            // 
            // txt_bin2accuracy_PreT
            // 
            this.txt_bin2accuracy_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_bin2accuracy_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bin2accuracy_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_bin2accuracy_PreT.Location = new System.Drawing.Point(505, 138);
            this.txt_bin2accuracy_PreT.Name = "txt_bin2accuracy_PreT";
            this.txt_bin2accuracy_PreT.Size = new System.Drawing.Size(120, 22);
            this.txt_bin2accuracy_PreT.TabIndex = 93;
            this.txt_bin2accuracy_PreT.Text = "2";
            this.txt_bin2accuracy_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label73.Location = new System.Drawing.Point(397, 141);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(93, 16);
            this.label73.TabIndex = 92;
            this.label73.Text = "Bin2 Accuracy";
            // 
            // cmb_Voffset_PreT
            // 
            this.cmb_Voffset_PreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Voffset_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Voffset_PreT.FormattingEnabled = true;
            this.cmb_Voffset_PreT.Items.AddRange(new object[] {
            "Default",
            "2.5V Low Power",
            "Half Vdd",
            "1.65V Low Power"});
            this.cmb_Voffset_PreT.Location = new System.Drawing.Point(182, 137);
            this.cmb_Voffset_PreT.Name = "cmb_Voffset_PreT";
            this.cmb_Voffset_PreT.Size = new System.Drawing.Size(126, 24);
            this.cmb_Voffset_PreT.TabIndex = 91;
            this.cmb_Voffset_PreT.SelectedIndexChanged += new System.EventHandler(this.cmb_Voffset_PreT_SelectedIndexChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label60.Location = new System.Drawing.Point(632, 39);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(17, 16);
            this.label60.TabIndex = 90;
            this.label60.Text = "V";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(632, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(17, 16);
            this.label40.TabIndex = 90;
            this.label40.Text = "A";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(284, 175);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(28, 16);
            this.label66.TabIndex = 89;
            this.label66.Text = "mV";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(631, 107);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(41, 16);
            this.label39.TabIndex = 89;
            this.label39.Text = "mV/A";
            // 
            // txt_IP_PreT
            // 
            this.txt_IP_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_IP_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IP_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_IP_PreT.Location = new System.Drawing.Point(505, 70);
            this.txt_IP_PreT.Name = "txt_IP_PreT";
            this.txt_IP_PreT.Size = new System.Drawing.Size(120, 22);
            this.txt_IP_PreT.TabIndex = 88;
            this.txt_IP_PreT.Text = "20";
            this.txt_IP_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_IP_PreT.TextChanged += new System.EventHandler(this.txt_IP_EngT_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(433, 73);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(20, 16);
            this.label34.TabIndex = 87;
            this.label34.Text = "IP";
            // 
            // txt_targetvoltage_PreT
            // 
            this.txt_targetvoltage_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_targetvoltage_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_targetvoltage_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_targetvoltage_PreT.Location = new System.Drawing.Point(505, 36);
            this.txt_targetvoltage_PreT.Name = "txt_targetvoltage_PreT";
            this.txt_targetvoltage_PreT.Size = new System.Drawing.Size(120, 22);
            this.txt_targetvoltage_PreT.TabIndex = 83;
            this.txt_targetvoltage_PreT.Text = "2";
            this.txt_targetvoltage_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_targetvoltage_PreT.TextChanged += new System.EventHandler(this.txt_targetvoltage_PreT_TextChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label59.Location = new System.Drawing.Point(406, 39);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(74, 16);
            this.label59.TabIndex = 82;
            this.label59.Text = "VIP-Voffset";
            // 
            // txt_AdcOffset_PreT
            // 
            this.txt_AdcOffset_PreT.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_AdcOffset_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AdcOffset_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_AdcOffset_PreT.Location = new System.Drawing.Point(182, 172);
            this.txt_AdcOffset_PreT.Name = "txt_AdcOffset_PreT";
            this.txt_AdcOffset_PreT.Size = new System.Drawing.Size(104, 22);
            this.txt_AdcOffset_PreT.TabIndex = 83;
            this.txt_AdcOffset_PreT.Text = "0";
            this.txt_AdcOffset_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_AdcOffset_PreT.TextChanged += new System.EventHandler(this.txt_AdcOffset_PreT_TextChanged);
            // 
            // txt_TargetGain_PreT
            // 
            this.txt_TargetGain_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_TargetGain_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TargetGain_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_TargetGain_PreT.Location = new System.Drawing.Point(505, 104);
            this.txt_TargetGain_PreT.Name = "txt_TargetGain_PreT";
            this.txt_TargetGain_PreT.ReadOnly = true;
            this.txt_TargetGain_PreT.Size = new System.Drawing.Size(120, 22);
            this.txt_TargetGain_PreT.TabIndex = 83;
            this.txt_TargetGain_PreT.Text = "100";
            this.txt_TargetGain_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TargetGain_PreT.TextChanged += new System.EventHandler(this.txt_TargetGain_TextChanged);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(82, 175);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(76, 16);
            this.label65.TabIndex = 82;
            this.label65.Text = "ADC Offset ";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(404, 107);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(79, 16);
            this.label38.TabIndex = 82;
            this.label38.Text = "Target Gain";
            // 
            // cmb_IPRange_PreT
            // 
            this.cmb_IPRange_PreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IPRange_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_IPRange_PreT.FormattingEnabled = true;
            this.cmb_IPRange_PreT.Items.AddRange(new object[] {
            "1x",
            "Default",
            "1.5x",
            "1.6x",
            "0.5x"});
            this.cmb_IPRange_PreT.Location = new System.Drawing.Point(182, 103);
            this.cmb_IPRange_PreT.Name = "cmb_IPRange_PreT";
            this.cmb_IPRange_PreT.Size = new System.Drawing.Size(126, 24);
            this.cmb_IPRange_PreT.TabIndex = 9;
            this.cmb_IPRange_PreT.SelectedIndexChanged += new System.EventHandler(this.cmb_IPRange_PreT_SelectedIndexChanged);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label69.Location = new System.Drawing.Point(75, 141);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(91, 16);
            this.label69.TabIndex = 8;
            this.label69.Text = "Voffset Option";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(81, 107);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(78, 16);
            this.label33.TabIndex = 8;
            this.label33.Text = "Gain Option";
            // 
            // cmb_TempCmp_PreT
            // 
            this.cmb_TempCmp_PreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TempCmp_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_TempCmp_PreT.FormattingEnabled = true;
            this.cmb_TempCmp_PreT.Items.AddRange(new object[] {
            "0",
            "200",
            "400",
            "600",
            "600",
            "Default",
            "1000",
            "1200"});
            this.cmb_TempCmp_PreT.Location = new System.Drawing.Point(182, 69);
            this.cmb_TempCmp_PreT.Name = "cmb_TempCmp_PreT";
            this.cmb_TempCmp_PreT.Size = new System.Drawing.Size(126, 24);
            this.cmb_TempCmp_PreT.TabIndex = 7;
            this.cmb_TempCmp_PreT.SelectedIndexChanged += new System.EventHandler(this.cmb_TempCmp_PreT_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(61, 73);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(119, 16);
            this.label32.TabIndex = 6;
            this.label32.Text = "Tem Compesation";
            // 
            // cmb_SensitivityAdapt_PreT
            // 
            this.cmb_SensitivityAdapt_PreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SensitivityAdapt_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_SensitivityAdapt_PreT.FormattingEnabled = true;
            this.cmb_SensitivityAdapt_PreT.Items.AddRange(new object[] {
            "Default",
            "Grade A",
            "Grade B"});
            this.cmb_SensitivityAdapt_PreT.Location = new System.Drawing.Point(182, 35);
            this.cmb_SensitivityAdapt_PreT.Name = "cmb_SensitivityAdapt_PreT";
            this.cmb_SensitivityAdapt_PreT.Size = new System.Drawing.Size(126, 24);
            this.cmb_SensitivityAdapt_PreT.TabIndex = 1;
            this.cmb_SensitivityAdapt_PreT.SelectedIndexChanged += new System.EventHandler(this.cmb_SensitivityAdapt_PreT_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(67, 39);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(107, 16);
            this.label35.TabIndex = 0;
            this.label35.Text = "Sensitivity Adapt";
            // 
            // btn_Reset_PreT
            // 
            this.btn_Reset_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Reset_PreT.Location = new System.Drawing.Point(762, 66);
            this.btn_Reset_PreT.Name = "btn_Reset_PreT";
            this.btn_Reset_PreT.Size = new System.Drawing.Size(27, 25);
            this.btn_Reset_PreT.TabIndex = 92;
            this.btn_Reset_PreT.Text = "Reset";
            this.btn_Reset_PreT.UseVisualStyleBackColor = true;
            this.btn_Reset_PreT.Visible = false;
            this.btn_Reset_PreT.Click += new System.EventHandler(this.btn_Reset_EngT_Click);
            // 
            // btn_FlashLed_PreT
            // 
            this.btn_FlashLed_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_FlashLed_PreT.Location = new System.Drawing.Point(762, 28);
            this.btn_FlashLed_PreT.Name = "btn_FlashLed_PreT";
            this.btn_FlashLed_PreT.Size = new System.Drawing.Size(27, 25);
            this.btn_FlashLed_PreT.TabIndex = 92;
            this.btn_FlashLed_PreT.Text = "FlashLED";
            this.btn_FlashLed_PreT.UseVisualStyleBackColor = true;
            this.btn_FlashLed_PreT.Visible = false;
            this.btn_FlashLed_PreT.Click += new System.EventHandler(this.btn_flash_onewire_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_PowerOn_PreT);
            this.groupBox4.Controls.Add(this.cmb_Module_PreT);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.btn_ModuleCurrent_PreT);
            this.groupBox4.Controls.Add(this.txt_ModuleCurrent_PreT);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.txt_SerialNum_PreT);
            this.groupBox4.Controls.Add(this.btn_PowerOff_PreT);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Location = new System.Drawing.Point(42, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(714, 88);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hardware Info";
            // 
            // btn_PowerOn_PreT
            // 
            this.btn_PowerOn_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_PowerOn_PreT.Location = new System.Drawing.Point(514, 36);
            this.btn_PowerOn_PreT.Name = "btn_PowerOn_PreT";
            this.btn_PowerOn_PreT.Size = new System.Drawing.Size(69, 25);
            this.btn_PowerOn_PreT.TabIndex = 91;
            this.btn_PowerOn_PreT.Text = "Power On";
            this.btn_PowerOn_PreT.UseVisualStyleBackColor = true;
            this.btn_PowerOn_PreT.Click += new System.EventHandler(this.btn_PowerOn_OWCI_ADC_Click);
            // 
            // cmb_Module_PreT
            // 
            this.cmb_Module_PreT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Module_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmb_Module_PreT.FormattingEnabled = true;
            this.cmb_Module_PreT.Items.AddRange(new object[] {
            "5V",
            "+/-15V",
            "3.3V"});
            this.cmb_Module_PreT.Location = new System.Drawing.Point(244, 37);
            this.cmb_Module_PreT.Name = "cmb_Module_PreT";
            this.cmb_Module_PreT.Size = new System.Drawing.Size(74, 23);
            this.cmb_Module_PreT.TabIndex = 90;
            this.cmb_Module_PreT.SelectedIndexChanged += new System.EventHandler(this.cmb_Module_EngT_SelectedIndexChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label54.Location = new System.Drawing.Point(164, 41);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(77, 15);
            this.label54.TabIndex = 89;
            this.label54.Text = "Module Type:";
            // 
            // btn_ModuleCurrent_PreT
            // 
            this.btn_ModuleCurrent_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ModuleCurrent_PreT.Location = new System.Drawing.Point(354, 36);
            this.btn_ModuleCurrent_PreT.Name = "btn_ModuleCurrent_PreT";
            this.btn_ModuleCurrent_PreT.Size = new System.Drawing.Size(60, 25);
            this.btn_ModuleCurrent_PreT.TabIndex = 83;
            this.btn_ModuleCurrent_PreT.Text = "IQ";
            this.btn_ModuleCurrent_PreT.UseVisualStyleBackColor = true;
            this.btn_ModuleCurrent_PreT.Click += new System.EventHandler(this.btn_ModuleCurrent_EngT_Click);
            // 
            // txt_ModuleCurrent_PreT
            // 
            this.txt_ModuleCurrent_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_ModuleCurrent_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_ModuleCurrent_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_ModuleCurrent_PreT.Location = new System.Drawing.Point(415, 38);
            this.txt_ModuleCurrent_PreT.Name = "txt_ModuleCurrent_PreT";
            this.txt_ModuleCurrent_PreT.ReadOnly = true;
            this.txt_ModuleCurrent_PreT.Size = new System.Drawing.Size(48, 22);
            this.txt_ModuleCurrent_PreT.TabIndex = 85;
            this.txt_ModuleCurrent_PreT.Text = "0.0";
            this.txt_ModuleCurrent_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(462, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(25, 15);
            this.label30.TabIndex = 84;
            this.label30.Text = "mA";
            // 
            // txt_SerialNum_PreT
            // 
            this.txt_SerialNum_PreT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_SerialNum_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_SerialNum_PreT.ForeColor = System.Drawing.Color.White;
            this.txt_SerialNum_PreT.Location = new System.Drawing.Point(84, 38);
            this.txt_SerialNum_PreT.Name = "txt_SerialNum_PreT";
            this.txt_SerialNum_PreT.ReadOnly = true;
            this.txt_SerialNum_PreT.Size = new System.Drawing.Size(56, 21);
            this.txt_SerialNum_PreT.TabIndex = 83;
            this.txt_SerialNum_PreT.Text = "Null";
            this.txt_SerialNum_PreT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_PowerOff_PreT
            // 
            this.btn_PowerOff_PreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_PowerOff_PreT.Location = new System.Drawing.Point(618, 36);
            this.btn_PowerOff_PreT.Name = "btn_PowerOff_PreT";
            this.btn_PowerOff_PreT.Size = new System.Drawing.Size(69, 25);
            this.btn_PowerOff_PreT.TabIndex = 92;
            this.btn_PowerOff_PreT.Text = "Power Off";
            this.btn_PowerOff_PreT.UseVisualStyleBackColor = true;
            this.btn_PowerOff_PreT.Click += new System.EventHandler(this.btn_PowerOff_OWCI_ADC_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(20, 41);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 15);
            this.label31.TabIndex = 82;
            this.label31.Text = "Serial Num:";
            // 
            // AutoTrimTab
            // 
            this.AutoTrimTab.Controls.Add(this.btn_CommunicationTest);
            this.AutoTrimTab.Controls.Add(this.cmb_ProgramMode_AutoT);
            this.AutoTrimTab.Controls.Add(this.cmb_SocketType_AutoT);
            this.AutoTrimTab.Controls.Add(this.label77);
            this.AutoTrimTab.Controls.Add(this.label21);
            this.AutoTrimTab.Controls.Add(this.btn_Vout_AutoT);
            this.AutoTrimTab.Controls.Add(this.btn_loadconfig_AutoT);
            this.AutoTrimTab.Controls.Add(this.btn_PowerOff_AutoT);
            this.AutoTrimTab.Controls.Add(this.label22);
            this.AutoTrimTab.Controls.Add(this.numUD_TargetGain_Customer);
            this.AutoTrimTab.Controls.Add(this.numUD_IPxForCalc_Customer);
            this.AutoTrimTab.Controls.Add(this.label19);
            this.AutoTrimTab.Controls.Add(this.autoTrimResultIndicator);
            this.AutoTrimTab.Controls.Add(this.label20);
            this.AutoTrimTab.Controls.Add(this.lbl_passOrFailed);
            this.AutoTrimTab.Controls.Add(this.btn_AutomaticaTrim15V);
            this.AutoTrimTab.Controls.Add(this.btn_AutomaticaTrim5V);
            this.AutoTrimTab.Controls.Add(this.btn_AutomaticaTrim);
            this.AutoTrimTab.Controls.Add(this.groupBox8);
            this.AutoTrimTab.Location = new System.Drawing.Point(4, 22);
            this.AutoTrimTab.Name = "AutoTrimTab";
            this.AutoTrimTab.Padding = new System.Windows.Forms.Padding(3);
            this.AutoTrimTab.Size = new System.Drawing.Size(803, 574);
            this.AutoTrimTab.TabIndex = 1;
            this.AutoTrimTab.Text = "AutoTrim";
            this.AutoTrimTab.UseVisualStyleBackColor = true;
            this.AutoTrimTab.Enter += new System.EventHandler(this.AutoTrimTab_Enter);
            // 
            // btn_CommunicationTest
            // 
            this.btn_CommunicationTest.Location = new System.Drawing.Point(622, 470);
            this.btn_CommunicationTest.Name = "btn_CommunicationTest";
            this.btn_CommunicationTest.Size = new System.Drawing.Size(76, 27);
            this.btn_CommunicationTest.TabIndex = 116;
            this.btn_CommunicationTest.Text = "Com Test";
            this.btn_CommunicationTest.UseVisualStyleBackColor = true;
            this.btn_CommunicationTest.Click += new System.EventHandler(this.btn_CommunicationTest_Click);
            // 
            // cmb_ProgramMode_AutoT
            // 
            this.cmb_ProgramMode_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmb_ProgramMode_AutoT.FormattingEnabled = true;
            this.cmb_ProgramMode_AutoT.Items.AddRange(new object[] {
            "Automatic",
            "Manual"});
            this.cmb_ProgramMode_AutoT.Location = new System.Drawing.Point(305, 346);
            this.cmb_ProgramMode_AutoT.Name = "cmb_ProgramMode_AutoT";
            this.cmb_ProgramMode_AutoT.Size = new System.Drawing.Size(103, 25);
            this.cmb_ProgramMode_AutoT.TabIndex = 115;
            this.cmb_ProgramMode_AutoT.SelectedIndexChanged += new System.EventHandler(this.cmb_ProgramMode_AutoT_SelectedIndexChanged);
            // 
            // cmb_SocketType_AutoT
            // 
            this.cmb_SocketType_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmb_SocketType_AutoT.FormattingEnabled = true;
            this.cmb_SocketType_AutoT.Items.AddRange(new object[] {
            "SingleSite",
            "MultiSite"});
            this.cmb_SocketType_AutoT.Location = new System.Drawing.Point(305, 317);
            this.cmb_SocketType_AutoT.Name = "cmb_SocketType_AutoT";
            this.cmb_SocketType_AutoT.Size = new System.Drawing.Size(103, 25);
            this.cmb_SocketType_AutoT.TabIndex = 115;
            this.cmb_SocketType_AutoT.SelectedIndexChanged += new System.EventHandler(this.cmb_SocketType_AutoT_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label77.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label77.Location = new System.Drawing.Point(192, 348);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(112, 19);
            this.label77.TabIndex = 114;
            this.label77.Text = "Program Mode";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(202, 320);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 19);
            this.label21.TabIndex = 114;
            this.label21.Text = "Socket Type";
            // 
            // btn_Vout_AutoT
            // 
            this.btn_Vout_AutoT.Location = new System.Drawing.Point(88, 470);
            this.btn_Vout_AutoT.Name = "btn_Vout_AutoT";
            this.btn_Vout_AutoT.Size = new System.Drawing.Size(77, 27);
            this.btn_Vout_AutoT.TabIndex = 111;
            this.btn_Vout_AutoT.Text = "Vout";
            this.btn_Vout_AutoT.UseVisualStyleBackColor = true;
            this.btn_Vout_AutoT.Click += new System.EventHandler(this.btn_Vout_AutoT_Click);
            // 
            // btn_loadconfig_AutoT
            // 
            this.btn_loadconfig_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_loadconfig_AutoT.Location = new System.Drawing.Point(10, 207);
            this.btn_loadconfig_AutoT.Name = "btn_loadconfig_AutoT";
            this.btn_loadconfig_AutoT.Size = new System.Drawing.Size(50, 22);
            this.btn_loadconfig_AutoT.TabIndex = 106;
            this.btn_loadconfig_AutoT.Text = "Load Config";
            this.btn_loadconfig_AutoT.UseVisualStyleBackColor = true;
            this.btn_loadconfig_AutoT.Visible = false;
            this.btn_loadconfig_AutoT.Click += new System.EventHandler(this.btn_loadconfig_AutoT_Click);
            // 
            // btn_PowerOff_AutoT
            // 
            this.btn_PowerOff_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_PowerOff_AutoT.ForeColor = System.Drawing.Color.Red;
            this.btn_PowerOff_AutoT.Location = new System.Drawing.Point(11, 118);
            this.btn_PowerOff_AutoT.Name = "btn_PowerOff_AutoT";
            this.btn_PowerOff_AutoT.Size = new System.Drawing.Size(49, 24);
            this.btn_PowerOff_AutoT.TabIndex = 110;
            this.btn_PowerOff_AutoT.Text = "STOP";
            this.btn_PowerOff_AutoT.UseVisualStyleBackColor = true;
            this.btn_PowerOff_AutoT.Visible = false;
            this.btn_PowerOff_AutoT.Click += new System.EventHandler(this.btn_PowerOff_OWCI_ADC_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(8, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 86;
            this.label22.Text = "mV/A";
            this.label22.Visible = false;
            // 
            // numUD_TargetGain_Customer
            // 
            this.numUD_TargetGain_Customer.DecimalPlaces = 4;
            this.numUD_TargetGain_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numUD_TargetGain_Customer.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUD_TargetGain_Customer.Location = new System.Drawing.Point(11, 36);
            this.numUD_TargetGain_Customer.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUD_TargetGain_Customer.Name = "numUD_TargetGain_Customer";
            this.numUD_TargetGain_Customer.Size = new System.Drawing.Size(57, 21);
            this.numUD_TargetGain_Customer.TabIndex = 85;
            this.numUD_TargetGain_Customer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_TargetGain_Customer.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numUD_TargetGain_Customer.Visible = false;
            this.numUD_TargetGain_Customer.ValueChanged += new System.EventHandler(this.numUD_TargetGain_Customer_ValueChanged);
            // 
            // numUD_IPxForCalc_Customer
            // 
            this.numUD_IPxForCalc_Customer.DecimalPlaces = 1;
            this.numUD_IPxForCalc_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numUD_IPxForCalc_Customer.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUD_IPxForCalc_Customer.Location = new System.Drawing.Point(10, 89);
            this.numUD_IPxForCalc_Customer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_IPxForCalc_Customer.Name = "numUD_IPxForCalc_Customer";
            this.numUD_IPxForCalc_Customer.Size = new System.Drawing.Size(58, 21);
            this.numUD_IPxForCalc_Customer.TabIndex = 84;
            this.numUD_IPxForCalc_Customer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_IPxForCalc_Customer.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUD_IPxForCalc_Customer.Visible = false;
            this.numUD_IPxForCalc_Customer.ValueChanged += new System.EventHandler(this.numUD_IPxForCalc_Customer_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label19.Location = new System.Drawing.Point(8, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 82;
            this.label19.Text = "IPx For Calc";
            this.label19.Visible = false;
            // 
            // autoTrimResultIndicator
            // 
            this.autoTrimResultIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.autoTrimResultIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoTrimResultIndicator.Location = new System.Drawing.Point(3, 503);
            this.autoTrimResultIndicator.Name = "autoTrimResultIndicator";
            this.autoTrimResultIndicator.ReadOnly = true;
            this.autoTrimResultIndicator.Size = new System.Drawing.Size(797, 68);
            this.autoTrimResultIndicator.TabIndex = 80;
            this.autoTrimResultIndicator.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label20.Location = new System.Drawing.Point(8, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 76;
            this.label20.Text = "Target Gain";
            this.label20.Visible = false;
            // 
            // lbl_passOrFailed
            // 
            this.lbl_passOrFailed.BackColor = System.Drawing.Color.Azure;
            this.lbl_passOrFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_passOrFailed.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_passOrFailed.Location = new System.Drawing.Point(218, 386);
            this.lbl_passOrFailed.Name = "lbl_passOrFailed";
            this.lbl_passOrFailed.Size = new System.Drawing.Size(341, 118);
            this.lbl_passOrFailed.TabIndex = 58;
            this.lbl_passOrFailed.Text = "START!";
            this.lbl_passOrFailed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AutomaticaTrim15V
            // 
            this.btn_AutomaticaTrim15V.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_AutomaticaTrim15V.Location = new System.Drawing.Point(10, 178);
            this.btn_AutomaticaTrim15V.Name = "btn_AutomaticaTrim15V";
            this.btn_AutomaticaTrim15V.Size = new System.Drawing.Size(50, 23);
            this.btn_AutomaticaTrim15V.TabIndex = 57;
            this.btn_AutomaticaTrim15V.Text = "15V Auto-Trim";
            this.btn_AutomaticaTrim15V.UseVisualStyleBackColor = true;
            this.btn_AutomaticaTrim15V.Visible = false;
            this.btn_AutomaticaTrim15V.Click += new System.EventHandler(this.btn_AutomaticaTrim15V_MultiSite);
            // 
            // btn_AutomaticaTrim5V
            // 
            this.btn_AutomaticaTrim5V.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_AutomaticaTrim5V.Location = new System.Drawing.Point(10, 148);
            this.btn_AutomaticaTrim5V.Name = "btn_AutomaticaTrim5V";
            this.btn_AutomaticaTrim5V.Size = new System.Drawing.Size(50, 24);
            this.btn_AutomaticaTrim5V.TabIndex = 57;
            this.btn_AutomaticaTrim5V.Text = "5V Auto-Trim";
            this.btn_AutomaticaTrim5V.UseVisualStyleBackColor = true;
            this.btn_AutomaticaTrim5V.Visible = false;
            this.btn_AutomaticaTrim5V.Click += new System.EventHandler(this.btn_AutomaticaTrim5V_MultiSite);
            // 
            // btn_AutomaticaTrim
            // 
            this.btn_AutomaticaTrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_AutomaticaTrim.Location = new System.Drawing.Point(426, 315);
            this.btn_AutomaticaTrim.Name = "btn_AutomaticaTrim";
            this.btn_AutomaticaTrim.Size = new System.Drawing.Size(147, 59);
            this.btn_AutomaticaTrim.TabIndex = 57;
            this.btn_AutomaticaTrim.Text = "PROGRAM";
            this.btn_AutomaticaTrim.UseVisualStyleBackColor = true;
            this.btn_AutomaticaTrim.Click += new System.EventHandler(this.btn_AutomaticaTrim_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txt_ModuleType_AutoT);
            this.groupBox8.Controls.Add(this.label57);
            this.groupBox8.Controls.Add(this.txt_ChosenGain_AutoT);
            this.groupBox8.Controls.Add(this.label58);
            this.groupBox8.Controls.Add(this.txt_IP_AutoT);
            this.groupBox8.Controls.Add(this.txt_VoutOffset_AutoT);
            this.groupBox8.Controls.Add(this.txt_TargertVoltage_AutoT);
            this.groupBox8.Controls.Add(this.txt_AdcOffset_AutoT);
            this.groupBox8.Controls.Add(this.txt_SensitivityAdapt_AutoT);
            this.groupBox8.Controls.Add(this.txt_TargetGain_AutoT);
            this.groupBox8.Controls.Add(this.txt_IPRange_AutoT);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Controls.Add(this.label71);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.label70);
            this.groupBox8.Controls.Add(this.txt_TempComp_AutoT);
            this.groupBox8.Controls.Add(this.label68);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.label46);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.label67);
            this.groupBox8.Controls.Add(this.label47);
            this.groupBox8.Controls.Add(this.label72);
            this.groupBox8.Controls.Add(this.label62);
            this.groupBox8.Controls.Add(this.label48);
            this.groupBox8.Controls.Add(this.label61);
            this.groupBox8.Location = new System.Drawing.Point(88, 32);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(610, 239);
            this.groupBox8.TabIndex = 109;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Preset";
            // 
            // txt_ModuleType_AutoT
            // 
            this.txt_ModuleType_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_ModuleType_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_ModuleType_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_ModuleType_AutoT.Location = new System.Drawing.Point(181, 37);
            this.txt_ModuleType_AutoT.Name = "txt_ModuleType_AutoT";
            this.txt_ModuleType_AutoT.ReadOnly = true;
            this.txt_ModuleType_AutoT.Size = new System.Drawing.Size(118, 27);
            this.txt_ModuleType_AutoT.TabIndex = 113;
            this.txt_ModuleType_AutoT.Text = "5V";
            this.txt_ModuleType_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(298, 189);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(23, 19);
            this.label57.TabIndex = 112;
            this.label57.Text = "%";
            // 
            // txt_ChosenGain_AutoT
            // 
            this.txt_ChosenGain_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_ChosenGain_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_ChosenGain_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_ChosenGain_AutoT.Location = new System.Drawing.Point(180, 185);
            this.txt_ChosenGain_AutoT.Name = "txt_ChosenGain_AutoT";
            this.txt_ChosenGain_AutoT.ReadOnly = true;
            this.txt_ChosenGain_AutoT.Size = new System.Drawing.Size(118, 27);
            this.txt_ChosenGain_AutoT.TabIndex = 111;
            this.txt_ChosenGain_AutoT.Text = "100";
            this.txt_ChosenGain_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label58.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label58.Location = new System.Drawing.Point(62, 189);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(96, 19);
            this.label58.TabIndex = 109;
            this.label58.Text = "Chosen Gain";
            // 
            // txt_IP_AutoT
            // 
            this.txt_IP_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_IP_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_IP_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_IP_AutoT.Location = new System.Drawing.Point(445, 109);
            this.txt_IP_AutoT.Name = "txt_IP_AutoT";
            this.txt_IP_AutoT.ReadOnly = true;
            this.txt_IP_AutoT.Size = new System.Drawing.Size(100, 27);
            this.txt_IP_AutoT.TabIndex = 108;
            this.txt_IP_AutoT.Text = "20";
            this.txt_IP_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_VoutOffset_AutoT
            // 
            this.txt_VoutOffset_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_VoutOffset_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_VoutOffset_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_VoutOffset_AutoT.Location = new System.Drawing.Point(445, 37);
            this.txt_VoutOffset_AutoT.Name = "txt_VoutOffset_AutoT";
            this.txt_VoutOffset_AutoT.ReadOnly = true;
            this.txt_VoutOffset_AutoT.Size = new System.Drawing.Size(100, 27);
            this.txt_VoutOffset_AutoT.TabIndex = 107;
            this.txt_VoutOffset_AutoT.Text = "2.5";
            this.txt_VoutOffset_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TargertVoltage_AutoT
            // 
            this.txt_TargertVoltage_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_TargertVoltage_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TargertVoltage_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_TargertVoltage_AutoT.Location = new System.Drawing.Point(445, 73);
            this.txt_TargertVoltage_AutoT.Name = "txt_TargertVoltage_AutoT";
            this.txt_TargertVoltage_AutoT.ReadOnly = true;
            this.txt_TargertVoltage_AutoT.Size = new System.Drawing.Size(100, 27);
            this.txt_TargertVoltage_AutoT.TabIndex = 107;
            this.txt_TargertVoltage_AutoT.Text = "2";
            this.txt_TargertVoltage_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_AdcOffset_AutoT
            // 
            this.txt_AdcOffset_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_AdcOffset_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_AdcOffset_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_AdcOffset_AutoT.Location = new System.Drawing.Point(445, 185);
            this.txt_AdcOffset_AutoT.Name = "txt_AdcOffset_AutoT";
            this.txt_AdcOffset_AutoT.ReadOnly = true;
            this.txt_AdcOffset_AutoT.Size = new System.Drawing.Size(100, 27);
            this.txt_AdcOffset_AutoT.TabIndex = 107;
            this.txt_AdcOffset_AutoT.Text = "0";
            this.txt_AdcOffset_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_SensitivityAdapt_AutoT
            // 
            this.txt_SensitivityAdapt_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_SensitivityAdapt_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_SensitivityAdapt_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_SensitivityAdapt_AutoT.Location = new System.Drawing.Point(181, 109);
            this.txt_SensitivityAdapt_AutoT.Name = "txt_SensitivityAdapt_AutoT";
            this.txt_SensitivityAdapt_AutoT.ReadOnly = true;
            this.txt_SensitivityAdapt_AutoT.Size = new System.Drawing.Size(118, 27);
            this.txt_SensitivityAdapt_AutoT.TabIndex = 103;
            this.txt_SensitivityAdapt_AutoT.Text = "Default";
            this.txt_SensitivityAdapt_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TargetGain_AutoT
            // 
            this.txt_TargetGain_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_TargetGain_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TargetGain_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_TargetGain_AutoT.Location = new System.Drawing.Point(445, 145);
            this.txt_TargetGain_AutoT.Name = "txt_TargetGain_AutoT";
            this.txt_TargetGain_AutoT.ReadOnly = true;
            this.txt_TargetGain_AutoT.Size = new System.Drawing.Size(100, 27);
            this.txt_TargetGain_AutoT.TabIndex = 107;
            this.txt_TargetGain_AutoT.Text = "100";
            this.txt_TargetGain_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_IPRange_AutoT
            // 
            this.txt_IPRange_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_IPRange_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_IPRange_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_IPRange_AutoT.Location = new System.Drawing.Point(180, 145);
            this.txt_IPRange_AutoT.Name = "txt_IPRange_AutoT";
            this.txt_IPRange_AutoT.ReadOnly = true;
            this.txt_IPRange_AutoT.Size = new System.Drawing.Size(118, 27);
            this.txt_IPRange_AutoT.TabIndex = 105;
            this.txt_IPRange_AutoT.Text = "Default";
            this.txt_IPRange_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label50.Location = new System.Drawing.Point(72, 149);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(69, 19);
            this.label50.TabIndex = 99;
            this.label50.Text = "IP Range";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label71.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label71.Location = new System.Drawing.Point(363, 41);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(59, 19);
            this.label71.TabIndex = 97;
            this.label71.Text = "Voffset";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label52.Location = new System.Drawing.Point(52, 113);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(123, 19);
            this.label52.TabIndex = 97;
            this.label52.Text = "Sensitivity Adapt";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label70.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label70.Location = new System.Drawing.Point(63, 41);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(98, 19);
            this.label70.TabIndex = 97;
            this.label70.Text = "Module Type";
            // 
            // txt_TempComp_AutoT
            // 
            this.txt_TempComp_AutoT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_TempComp_AutoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TempComp_AutoT.ForeColor = System.Drawing.Color.White;
            this.txt_TempComp_AutoT.Location = new System.Drawing.Point(180, 73);
            this.txt_TempComp_AutoT.Name = "txt_TempComp_AutoT";
            this.txt_TempComp_AutoT.ReadOnly = true;
            this.txt_TempComp_AutoT.Size = new System.Drawing.Size(118, 27);
            this.txt_TempComp_AutoT.TabIndex = 104;
            this.txt_TempComp_AutoT.Text = "-350ppm";
            this.txt_TempComp_AutoT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(349, 189);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(91, 19);
            this.label68.TabIndex = 91;
            this.label68.Text = "ADC Offset";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(349, 149);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(87, 19);
            this.label49.TabIndex = 91;
            this.label49.Text = "Target Gain";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label46.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label46.Location = new System.Drawing.Point(551, 113);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(20, 19);
            this.label46.TabIndex = 96;
            this.label46.Text = "A";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label51.Location = new System.Drawing.Point(49, 77);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(132, 19);
            this.label51.TabIndex = 98;
            this.label51.Text = "Tem Compesation";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label67.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label67.Location = new System.Drawing.Point(545, 189);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(33, 19);
            this.label67.TabIndex = 95;
            this.label67.Text = "mV";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label47.Location = new System.Drawing.Point(545, 149);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(49, 19);
            this.label47.TabIndex = 95;
            this.label47.Text = "mV/A";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label72.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label72.Location = new System.Drawing.Point(551, 41);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(20, 19);
            this.label72.TabIndex = 95;
            this.label72.Text = "V";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label62.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label62.Location = new System.Drawing.Point(551, 77);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(20, 19);
            this.label62.TabIndex = 95;
            this.label62.Text = "V";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(381, 113);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(24, 19);
            this.label48.TabIndex = 93;
            this.label48.Text = "IP";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label61.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label61.Location = new System.Drawing.Point(349, 77);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(91, 19);
            this.label61.TabIndex = 91;
            this.label61.Text = "VIP-Voffset";
            // 
            // BrakeTab
            // 
            this.BrakeTab.Controls.Add(this.btn_BrakeTab_PowerOff);
            this.BrakeTab.Controls.Add(this.btn_BrakeTab_PowerOn);
            this.BrakeTab.Controls.Add(this.txt_StopPoint_BrakeT);
            this.BrakeTab.Controls.Add(this.txt_StartPoint_BrakeT);
            this.BrakeTab.Controls.Add(this.label80);
            this.BrakeTab.Controls.Add(this.label79);
            this.BrakeTab.Controls.Add(this.label78);
            this.BrakeTab.Controls.Add(this.btn_Fuse_BrakeT);
            this.BrakeTab.Controls.Add(this.btn_StopPoint_BrakeT);
            this.BrakeTab.Controls.Add(this.btn_StartPoint_BrakeT);
            this.BrakeTab.Controls.Add(this.groupBox9);
            this.BrakeTab.Location = new System.Drawing.Point(4, 22);
            this.BrakeTab.Name = "BrakeTab";
            this.BrakeTab.Padding = new System.Windows.Forms.Padding(3);
            this.BrakeTab.Size = new System.Drawing.Size(803, 574);
            this.BrakeTab.TabIndex = 3;
            this.BrakeTab.Text = "Brake";
            this.BrakeTab.UseVisualStyleBackColor = true;
            // 
            // btn_BrakeTab_PowerOff
            // 
            this.btn_BrakeTab_PowerOff.Location = new System.Drawing.Point(673, 156);
            this.btn_BrakeTab_PowerOff.Name = "btn_BrakeTab_PowerOff";
            this.btn_BrakeTab_PowerOff.Size = new System.Drawing.Size(75, 23);
            this.btn_BrakeTab_PowerOff.TabIndex = 3;
            this.btn_BrakeTab_PowerOff.Text = "OFF";
            this.btn_BrakeTab_PowerOff.UseVisualStyleBackColor = true;
            // 
            // btn_BrakeTab_PowerOn
            // 
            this.btn_BrakeTab_PowerOn.Location = new System.Drawing.Point(573, 156);
            this.btn_BrakeTab_PowerOn.Name = "btn_BrakeTab_PowerOn";
            this.btn_BrakeTab_PowerOn.Size = new System.Drawing.Size(75, 23);
            this.btn_BrakeTab_PowerOn.TabIndex = 3;
            this.btn_BrakeTab_PowerOn.Text = "ON";
            this.btn_BrakeTab_PowerOn.UseVisualStyleBackColor = true;
            // 
            // txt_StopPoint_BrakeT
            // 
            this.txt_StopPoint_BrakeT.Location = new System.Drawing.Point(709, 332);
            this.txt_StopPoint_BrakeT.Name = "txt_StopPoint_BrakeT";
            this.txt_StopPoint_BrakeT.Size = new System.Drawing.Size(70, 20);
            this.txt_StopPoint_BrakeT.TabIndex = 2;
            this.txt_StopPoint_BrakeT.Visible = false;
            // 
            // txt_StartPoint_BrakeT
            // 
            this.txt_StartPoint_BrakeT.Location = new System.Drawing.Point(709, 254);
            this.txt_StartPoint_BrakeT.Name = "txt_StartPoint_BrakeT";
            this.txt_StartPoint_BrakeT.Size = new System.Drawing.Size(70, 20);
            this.txt_StartPoint_BrakeT.TabIndex = 2;
            this.txt_StartPoint_BrakeT.Visible = false;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(619, 391);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(73, 13);
            this.label80.TabIndex = 1;
            this.label80.Text = "STEP 3: Fuse";
            this.label80.Visible = false;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(619, 313);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(154, 13);
            this.label79.TabIndex = 1;
            this.label79.Text = "STEP 2: Press Brake and Click";
            this.label79.Visible = false;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(619, 235);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(167, 13);
            this.label78.TabIndex = 1;
            this.label78.Text = "STEP 1: Release Brake and Click";
            this.label78.Visible = false;
            // 
            // btn_Fuse_BrakeT
            // 
            this.btn_Fuse_BrakeT.Location = new System.Drawing.Point(619, 410);
            this.btn_Fuse_BrakeT.Name = "btn_Fuse_BrakeT";
            this.btn_Fuse_BrakeT.Size = new System.Drawing.Size(80, 28);
            this.btn_Fuse_BrakeT.TabIndex = 0;
            this.btn_Fuse_BrakeT.Text = "Fuse";
            this.btn_Fuse_BrakeT.UseVisualStyleBackColor = true;
            this.btn_Fuse_BrakeT.Visible = false;
            this.btn_Fuse_BrakeT.Click += new System.EventHandler(this.btn_Fuse_BrakeT_Click);
            // 
            // btn_StopPoint_BrakeT
            // 
            this.btn_StopPoint_BrakeT.Location = new System.Drawing.Point(619, 332);
            this.btn_StopPoint_BrakeT.Name = "btn_StopPoint_BrakeT";
            this.btn_StopPoint_BrakeT.Size = new System.Drawing.Size(80, 28);
            this.btn_StopPoint_BrakeT.TabIndex = 0;
            this.btn_StopPoint_BrakeT.Text = "Stop Point";
            this.btn_StopPoint_BrakeT.UseVisualStyleBackColor = true;
            this.btn_StopPoint_BrakeT.Visible = false;
            this.btn_StopPoint_BrakeT.Click += new System.EventHandler(this.btn_StopPoint_BrakeT_Click);
            // 
            // btn_StartPoint_BrakeT
            // 
            this.btn_StartPoint_BrakeT.Location = new System.Drawing.Point(619, 254);
            this.btn_StartPoint_BrakeT.Name = "btn_StartPoint_BrakeT";
            this.btn_StartPoint_BrakeT.Size = new System.Drawing.Size(80, 28);
            this.btn_StartPoint_BrakeT.TabIndex = 0;
            this.btn_StartPoint_BrakeT.Text = "Start Point";
            this.btn_StartPoint_BrakeT.UseVisualStyleBackColor = true;
            this.btn_StartPoint_BrakeT.Visible = false;
            this.btn_StartPoint_BrakeT.Click += new System.EventHandler(this.btn_StartPoint_BrakeT_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_BrakeTab_InitializeUart);
            this.groupBox9.Location = new System.Drawing.Point(546, 35);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(227, 169);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "TEST";
            // 
            // btn_BrakeTab_InitializeUart
            // 
            this.btn_BrakeTab_InitializeUart.Location = new System.Drawing.Point(27, 19);
            this.btn_BrakeTab_InitializeUart.Name = "btn_BrakeTab_InitializeUart";
            this.btn_BrakeTab_InitializeUart.Size = new System.Drawing.Size(175, 39);
            this.btn_BrakeTab_InitializeUart.TabIndex = 3;
            this.btn_BrakeTab_InitializeUart.Text = "Initialize";
            this.btn_BrakeTab_InitializeUart.UseVisualStyleBackColor = true;
            this.btn_BrakeTab_InitializeUart.Click += new System.EventHandler(this.btn_BrakeTab_InitializeUart_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuStrip_SelAll,
            this.contextMenuStrip_Copy,
            this.contextMenuStrip_Paste,
            this.toolStripSeparator3,
            this.contextMenuStrip_Clear});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 98);
            // 
            // contextMenuStrip_SelAll
            // 
            this.contextMenuStrip_SelAll.Name = "contextMenuStrip_SelAll";
            this.contextMenuStrip_SelAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuStrip_SelAll.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_SelAll.Text = "Select &All";
            this.contextMenuStrip_SelAll.Click += new System.EventHandler(this.contextMenuStrip_SelAll_Click);
            // 
            // contextMenuStrip_Copy
            // 
            this.contextMenuStrip_Copy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Copy.Name = "contextMenuStrip_Copy";
            this.contextMenuStrip_Copy.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Copy.Text = "&Copy";
            this.contextMenuStrip_Copy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip_Copy_MouseUp);
            // 
            // contextMenuStrip_Paste
            // 
            this.contextMenuStrip_Paste.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Paste.Name = "contextMenuStrip_Paste";
            this.contextMenuStrip_Paste.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Paste.Text = "&Paste";
            this.contextMenuStrip_Paste.Visible = false;
            this.contextMenuStrip_Paste.Click += new System.EventHandler(this.contextMenuStrip_Paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // contextMenuStrip_Clear
            // 
            this.contextMenuStrip_Clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Clear.Name = "contextMenuStrip_Clear";
            this.contextMenuStrip_Clear.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Clear.Text = "C&lear";
            this.contextMenuStrip_Clear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip_Clear_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_OutputLogInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 603);
            this.splitContainer1.SplitterDistance = 811;
            this.splitContainer1.TabIndex = 88;
            // 
            // txt_OutputLogInfo
            // 
            this.txt_OutputLogInfo.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_OutputLogInfo.ContextMenuStrip = this.contextMenuStrip;
            this.txt_OutputLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_OutputLogInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_OutputLogInfo.ForeColor = System.Drawing.Color.White;
            this.txt_OutputLogInfo.Location = new System.Drawing.Point(0, 0);
            this.txt_OutputLogInfo.MaximumSize = new System.Drawing.Size(400, 599);
            this.txt_OutputLogInfo.MinimumSize = new System.Drawing.Size(200, 505);
            this.txt_OutputLogInfo.Name = "txt_OutputLogInfo";
            this.txt_OutputLogInfo.Size = new System.Drawing.Size(283, 599);
            this.txt_OutputLogInfo.TabIndex = 88;
            this.txt_OutputLogInfo.Text = "";
            // 
            // CurrentSensorConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CurrentSensorConsole";
            this.Text = "Current Sensor Console for 610 v1.2.1 - CopyRight of SenkoMicro, Inc";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.EngineeringTab.ResumeLayout(false);
            this.EngineeringTab.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_OffsetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SlopeK)).EndInit();
            this.grb_HWInfo.ResumeLayout(false);
            this.grb_HWInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb_devInfo_ow.ResumeLayout(false);
            this.grb_devInfo_ow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow_EngT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow_EngT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow_EngT)).EndInit();
            this.PriTrimTab.ResumeLayout(false);
            this.PriTrimTab.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.AutoTrimTab.ResumeLayout(false);
            this.AutoTrimTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TargetGain_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_IPxForCalc_Customer)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.BrakeTab.ResumeLayout(false);
            this.BrakeTab.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Connection;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage EngineeringTab;
        private System.Windows.Forms.TabPage AutoTrimTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_fuse_action_ow_EngT;
        private System.Windows.Forms.NumericUpDown numUD_pulsedurationtime_ow_EngT;
        private System.Windows.Forms.Label lbl_pulsewidth_ow;
        private System.Windows.Forms.NumericUpDown num_UD_pulsewidth_ow_EngT;
        private System.Windows.Forms.Label lbl_pulsedurationtime_ow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grb_devInfo_ow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUD_pilotwidth_ow_EngT;
        private System.Windows.Forms.Label lbl_pilotwidth_ow;
        private System.Windows.Forms.TextBox txt_dev_addr_onewire_EngT;
        private System.Windows.Forms.Label lbl_devAddr_onewire;
        private System.Windows.Forms.Button btn_flash_onewire;
        private System.Windows.Forms.Button btn_GetFW_OneWire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_PowerOff_OWCI_ADC_EngT;
        private System.Windows.Forms.Button btn_PowerOn_OWCI_ADC_EngT;
        private System.Windows.Forms.Button btn_preciseTrim;
        private System.Windows.Forms.Button btn_CalcGainCode_EngT;
        private System.Windows.Forms.Button btn_offset_EngT;
        private System.Windows.Forms.TextBox txt_IP_EngT;
        private System.Windows.Forms.TextBox txt_TargetGain_EngT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_enterNomalMode_EngT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_FWInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_writeFuseCode_EngT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Config_EngT;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_AIn_EngT;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Vref_EngT;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Vout_EngT;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbt_withoutCap_Vref;
        private System.Windows.Forms.RadioButton rbt_withCap_Vref;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbt_withoutCap_Vout_EngT;
        private System.Windows.Forms.RadioButton rbt_withCap_Vout_EngT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rtb_VDD_Ext_EngT;
        private System.Windows.Forms.RadioButton rbt_VDD_5V_EngT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_reg83_EngT;
        private System.Windows.Forms.TextBox txt_reg82_EngT;
        private System.Windows.Forms.TextBox txt_reg81_EngT;
        private System.Windows.Forms.TextBox txt_reg80_EngT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_sampleRate_EngT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_sampleNum_EngT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_ADCReset;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_SelAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Copy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Clear;
        private System.Windows.Forms.Button btn_burstRead_EngT;
        private System.Windows.Forms.Label lbl_passOrFailed;
        private System.Windows.Forms.Button btn_AutomaticaTrim;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_MarginalRead_EngT;
        private System.Windows.Forms.Button btn_Reload_EngT;
        private System.Windows.Forms.RichTextBox autoTrimResultIndicator;
        private System.Windows.Forms.Button btn_ch_ck;
        private System.Windows.Forms.Button btn_nc_1x;
        private System.Windows.Forms.Button btn_sel_vr;
        private System.Windows.Forms.Button btn_sel_cap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numUD_TargetGain_Customer;
        private System.Windows.Forms.NumericUpDown numUD_IPxForCalc_Customer;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage PriTrimTab;
        private System.Windows.Forms.Button btn_SafetyRead_EngT;
        private System.Windows.Forms.Button btn_Vout0A_EngT;
        private System.Windows.Forms.Button btn_VoutIP_EngT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmb_SensingDirection_EngT;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rbtn_VoutOpetionDefault_EngT;
        private System.Windows.Forms.RadioButton rbtn_VoutOptionHigh_EngT;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmb_OffsetOption_EngT;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rbtn_InsideFilterDefault_EngT;
        private System.Windows.Forms.RadioButton rbtn_InsideFilterOff_EngT;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox grb_HWInfo;
        private System.Windows.Forms.TextBox txt_SerialNum_EngT;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btn_Reset_EngT;
        private System.Windows.Forms.Button btn_ModuleCurrent_EngT;
        private System.Windows.Forms.TextBox txt_ModuleCurrent_EngT;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Mout_EngT;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_510Out_EngT;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_VCS_EngT;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton rbtn_CSResistorSet_EngT;
        private System.Windows.Forms.RadioButton rbtn_CSResistorByPass_EngT;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_ModuleCurrent_PreT;
        private System.Windows.Forms.TextBox txt_ModuleCurrent_PreT;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txt_SerialNum_PreT;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txt_IP_PreT;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txt_PresetVoutIP_PreT;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txt_TargetGain_PreT;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cmb_IPRange_PreT;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmb_TempCmp_PreT;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmb_SensitivityAdapt_PreT;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txt_Reg83_PreT;
        private System.Windows.Forms.TextBox txt_Reg82_PreT;
        private System.Windows.Forms.TextBox txt_Reg81_PreT;
        private System.Windows.Forms.TextBox txt_Reg80_PreT;
        private System.Windows.Forms.Button btn_SaveConfig_PreT;
        private System.Windows.Forms.Button btn_GainCtrlMinus_PreT;
        private System.Windows.Forms.Button btn_GainCtrlPlus_PreT;
        private System.Windows.Forms.Button btn_Vout_PreT;
        private System.Windows.Forms.ComboBox cmb_PolaritySelect_EngT;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txt_OutputLogInfo;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button btn_loadconfig_AutoT;
        private System.Windows.Forms.TextBox txt_IPRange_AutoT;
        private System.Windows.Forms.TextBox txt_TempComp_AutoT;
        private System.Windows.Forms.TextBox txt_SensitivityAdapt_AutoT;
        private System.Windows.Forms.TextBox txt_IP_AutoT;
        private System.Windows.Forms.TextBox txt_TargetGain_AutoT;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cmb_Module_EngT;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.ComboBox cmb_Module_PreT;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.NumericUpDown numUD_OffsetB;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.NumericUpDown numUD_SlopeK;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button btn_PowerOn_PreT;
        private System.Windows.Forms.Button btn_PowerOff_PreT;
        private System.Windows.Forms.TextBox txt_ChosenGain_AutoT;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button btn_FlashLed_PreT;
        private System.Windows.Forms.Button btn_Reset_PreT;
        private System.Windows.Forms.Button btn_PowerOff_AutoT;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox txt_targetvoltage_PreT;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txt_TargertVoltage_AutoT;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txt_ChosenGain_PreT;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button btn_AdcOut_EngT;
        private System.Windows.Forms.TextBox txt_AdcOut_EngT;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txt_AdcOffset_PreT;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox txt_AdcOffset_AutoT;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button btn_AutomaticaTrim15V;
        private System.Windows.Forms.Button btn_AutomaticaTrim5V;
        private System.Windows.Forms.ComboBox cmb_Voffset_PreT;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox txt_ModuleType_AutoT;
        private System.Windows.Forms.TextBox txt_VoutOffset_AutoT;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btn_fuse_clock_ow_EngT;
        private System.Windows.Forms.TextBox txt_bin3accuracy_PreT;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox txt_bin2accuracy_PreT;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btn_Vout_AutoT;
        private System.Windows.Forms.ComboBox cmb_SocketType_AutoT;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_EngTab_Connect;
        private System.Windows.Forms.Button btn_EngTab_Ipon;
        private System.Windows.Forms.Button btn_EngTab_Ipoff;
        private System.Windows.Forms.ComboBox cmb_ProgramMode_AutoT;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TabPage BrakeTab;
        private System.Windows.Forms.TextBox txt_StopPoint_BrakeT;
        private System.Windows.Forms.TextBox txt_StartPoint_BrakeT;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Button btn_StopPoint_BrakeT;
        private System.Windows.Forms.Button btn_StartPoint_BrakeT;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button btn_Fuse_BrakeT;
        private System.Windows.Forms.Button btn_CommunicationTest;
        private System.Windows.Forms.Button btn_SafetyHighRead_EngT;
        private System.Windows.Forms.Button btn_BrakeTab_PowerOff;
        private System.Windows.Forms.Button btn_BrakeTab_PowerOn;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_BrakeTab_InitializeUart;
        private System.Windows.Forms.TextBox txt_Delay_PreT;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
    }
}