namespace 雷赛Demo
{
    partial class FormSetInt
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpController = new System.Windows.Forms.GroupBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.grpAxisNo = new System.Windows.Forms.GroupBox();
            this.lblXNo = new System.Windows.Forms.Label();
            this.lblYNo = new System.Windows.Forms.Label();
            this.lblZNo = new System.Windows.Forms.Label();
            this.nudXNo = new System.Windows.Forms.NumericUpDown();
            this.nudYNo = new System.Windows.Forms.NumericUpDown();
            this.nudZNo = new System.Windows.Forms.NumericUpDown();
            this.grpAxisParam = new System.Windows.Forms.GroupBox();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.cboAxisName = new System.Windows.Forms.ComboBox();
            this.btnReadCtrl = new System.Windows.Forms.Button();
            this.btnWriteCtrl = new System.Windows.Forms.Button();
            this.btnApplyAll = new System.Windows.Forms.Button();
            this.btnReloadCfg = new System.Windows.Forms.Button();
            this.btnSaveCfg = new System.Windows.Forms.Button();
            this.grpAxisCfg = new System.Windows.Forms.GroupBox();
            this.lblPulse = new System.Windows.Forms.Label();
            this.nudPulse = new System.Windows.Forms.NumericUpDown();
            this.lblSoftLimit = new System.Windows.Forms.Label();
            this.chkSoftLimit = new System.Windows.Forms.CheckBox();
            this.lblPosLimit = new System.Windows.Forms.Label();
            this.nudPosLimit = new System.Windows.Forms.NumericUpDown();
            this.lblNegLimit = new System.Windows.Forms.Label();
            this.nudNegLimit = new System.Windows.Forms.NumericUpDown();
            this.grpSpeed = new System.Windows.Forms.GroupBox();
            this.lblStartSpeed = new System.Windows.Forms.Label();
            this.nudStartSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblStopSpeed = new System.Windows.Forms.Label();
            this.nudStopSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblAccTime = new System.Windows.Forms.Label();
            this.nudAccTime = new System.Windows.Forms.NumericUpDown();
            this.lblDecTime = new System.Windows.Forms.Label();
            this.nudDecTime = new System.Windows.Forms.NumericUpDown();
            this.grpHome = new System.Windows.Forms.GroupBox();
            this.lblHomeMode = new System.Windows.Forms.Label();
            this.nudHomeMode = new System.Windows.Forms.NumericUpDown();
            this.lblHomeLow = new System.Windows.Forms.Label();
            this.nudHomeLow = new System.Windows.Forms.NumericUpDown();
            this.lblHomeHigh = new System.Windows.Forms.Label();
            this.nudHomeHigh = new System.Windows.Forms.NumericUpDown();
            this.lblHomeAcc = new System.Windows.Forms.Label();
            this.nudHomeAcc = new System.Windows.Forms.NumericUpDown();
            this.lblHomeDec = new System.Windows.Forms.Label();
            this.nudHomeDec = new System.Windows.Forms.NumericUpDown();
            this.lblHomeOffset = new System.Windows.Forms.Label();
            this.nudHomeOffset = new System.Windows.Forms.NumericUpDown();
            this.grpController.SuspendLayout();
            this.grpAxisNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudXNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZNo)).BeginInit();
            this.grpAxisParam.SuspendLayout();
            this.grpAxisCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPulse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNegLimit)).BeginInit();
            this.grpSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecTime)).BeginInit();
            this.grpHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // grpController
            // 
            this.grpController.Controls.Add(this.lblIp);
            this.grpController.Controls.Add(this.txtIp);
            this.grpController.Location = new System.Drawing.Point(16, 15);
            this.grpController.Margin = new System.Windows.Forms.Padding(4);
            this.grpController.Name = "grpController";
            this.grpController.Padding = new System.Windows.Forms.Padding(4);
            this.grpController.Size = new System.Drawing.Size(253, 90);
            this.grpController.TabIndex = 0;
            this.grpController.TabStop = false;
            this.grpController.Text = "控制器配置";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(13, 38);
            this.lblIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(61, 15);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "IP地址:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(93, 32);
            this.txtIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(143, 25);
            this.txtIp.TabIndex = 1;
            // 
            // grpAxisNo
            // 
            this.grpAxisNo.Controls.Add(this.lblXNo);
            this.grpAxisNo.Controls.Add(this.lblYNo);
            this.grpAxisNo.Controls.Add(this.lblZNo);
            this.grpAxisNo.Controls.Add(this.nudXNo);
            this.grpAxisNo.Controls.Add(this.nudYNo);
            this.grpAxisNo.Controls.Add(this.nudZNo);
            this.grpAxisNo.Location = new System.Drawing.Point(16, 112);
            this.grpAxisNo.Margin = new System.Windows.Forms.Padding(4);
            this.grpAxisNo.Name = "grpAxisNo";
            this.grpAxisNo.Padding = new System.Windows.Forms.Padding(4);
            this.grpAxisNo.Size = new System.Drawing.Size(253, 152);
            this.grpAxisNo.TabIndex = 1;
            this.grpAxisNo.TabStop = false;
            this.grpAxisNo.Text = "轴号配置";
            // 
            // lblXNo
            // 
            this.lblXNo.AutoSize = true;
            this.lblXNo.Location = new System.Drawing.Point(13, 35);
            this.lblXNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXNo.Name = "lblXNo";
            this.lblXNo.Size = new System.Drawing.Size(53, 15);
            this.lblXNo.TabIndex = 0;
            this.lblXNo.Text = "X轴号:";
            // 
            // lblYNo
            // 
            this.lblYNo.AutoSize = true;
            this.lblYNo.Location = new System.Drawing.Point(13, 70);
            this.lblYNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYNo.Name = "lblYNo";
            this.lblYNo.Size = new System.Drawing.Size(53, 15);
            this.lblYNo.TabIndex = 1;
            this.lblYNo.Text = "Y轴号:";
            // 
            // lblZNo
            // 
            this.lblZNo.AutoSize = true;
            this.lblZNo.Location = new System.Drawing.Point(13, 105);
            this.lblZNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZNo.Name = "lblZNo";
            this.lblZNo.Size = new System.Drawing.Size(53, 15);
            this.lblZNo.TabIndex = 2;
            this.lblZNo.Text = "Z轴号:";
            // 
            // nudXNo
            // 
            this.nudXNo.Location = new System.Drawing.Point(93, 30);
            this.nudXNo.Margin = new System.Windows.Forms.Padding(4);
            this.nudXNo.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudXNo.Name = "nudXNo";
            this.nudXNo.Size = new System.Drawing.Size(144, 25);
            this.nudXNo.TabIndex = 3;
            // 
            // nudYNo
            // 
            this.nudYNo.Location = new System.Drawing.Point(93, 65);
            this.nudYNo.Margin = new System.Windows.Forms.Padding(4);
            this.nudYNo.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudYNo.Name = "nudYNo";
            this.nudYNo.Size = new System.Drawing.Size(144, 25);
            this.nudYNo.TabIndex = 4;
            // 
            // nudZNo
            // 
            this.nudZNo.Location = new System.Drawing.Point(93, 100);
            this.nudZNo.Margin = new System.Windows.Forms.Padding(4);
            this.nudZNo.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudZNo.Name = "nudZNo";
            this.nudZNo.Size = new System.Drawing.Size(144, 25);
            this.nudZNo.TabIndex = 5;
            // 
            // grpAxisParam
            // 
            this.grpAxisParam.Controls.Add(this.lblAxisName);
            this.grpAxisParam.Controls.Add(this.cboAxisName);
            this.grpAxisParam.Controls.Add(this.btnReadCtrl);
            this.grpAxisParam.Controls.Add(this.btnWriteCtrl);
            this.grpAxisParam.Controls.Add(this.btnApplyAll);
            this.grpAxisParam.Controls.Add(this.btnReloadCfg);
            this.grpAxisParam.Controls.Add(this.btnSaveCfg);
            this.grpAxisParam.Controls.Add(this.grpAxisCfg);
            this.grpAxisParam.Controls.Add(this.grpSpeed);
            this.grpAxisParam.Controls.Add(this.grpHome);
            this.grpAxisParam.Location = new System.Drawing.Point(280, 15);
            this.grpAxisParam.Margin = new System.Windows.Forms.Padding(4);
            this.grpAxisParam.Name = "grpAxisParam";
            this.grpAxisParam.Padding = new System.Windows.Forms.Padding(4);
            this.grpAxisParam.Size = new System.Drawing.Size(744, 401);
            this.grpAxisParam.TabIndex = 2;
            this.grpAxisParam.TabStop = false;
            this.grpAxisParam.Text = "轴参数配置";
            // 
            // lblAxisName
            // 
            this.lblAxisName.AutoSize = true;
            this.lblAxisName.Location = new System.Drawing.Point(20, 40);
            this.lblAxisName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(60, 15);
            this.lblAxisName.TabIndex = 0;
            this.lblAxisName.Text = "轴名称:";
            // 
            // cboAxisName
            // 
            this.cboAxisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAxisName.FormattingEnabled = true;
            this.cboAxisName.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cboAxisName.Location = new System.Drawing.Point(96, 35);
            this.cboAxisName.Margin = new System.Windows.Forms.Padding(4);
            this.cboAxisName.Name = "cboAxisName";
            this.cboAxisName.Size = new System.Drawing.Size(148, 23);
            this.cboAxisName.TabIndex = 1;
            this.cboAxisName.SelectedIndexChanged += new System.EventHandler(this.CboAxisName_SelectedIndexChanged);
            // 
            // btnReadCtrl
            // 
            this.btnReadCtrl.Location = new System.Drawing.Point(303, 31);
            this.btnReadCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadCtrl.Name = "btnReadCtrl";
            this.btnReadCtrl.Size = new System.Drawing.Size(137, 32);
            this.btnReadCtrl.TabIndex = 2;
            this.btnReadCtrl.Text = "读取控制器配置";
            this.btnReadCtrl.UseVisualStyleBackColor = true;
            this.btnReadCtrl.Click += new System.EventHandler(this.btnReadCtrl_Click);
            // 
            // btnWriteCtrl
            // 
            this.btnWriteCtrl.Location = new System.Drawing.Point(448, 31);
            this.btnWriteCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnWriteCtrl.Name = "btnWriteCtrl";
            this.btnWriteCtrl.Size = new System.Drawing.Size(137, 32);
            this.btnWriteCtrl.TabIndex = 3;
            this.btnWriteCtrl.Text = "写入控制器配置";
            this.btnWriteCtrl.UseVisualStyleBackColor = true;
            this.btnWriteCtrl.Click += new System.EventHandler(this.btnWriteCtrl_Click);
            // 
            // btnApplyAll
            // 
            this.btnApplyAll.Location = new System.Drawing.Point(593, 31);
            this.btnApplyAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplyAll.Name = "btnApplyAll";
            this.btnApplyAll.Size = new System.Drawing.Size(118, 32);
            this.btnApplyAll.TabIndex = 4;
            this.btnApplyAll.Text = "应用到所有轴";
            this.btnApplyAll.UseVisualStyleBackColor = true;
            this.btnApplyAll.Click += new System.EventHandler(this.btnApplyAll_Click);
            // 
            // btnReloadCfg
            // 
            this.btnReloadCfg.Location = new System.Drawing.Point(303, 69);
            this.btnReloadCfg.Margin = new System.Windows.Forms.Padding(4);
            this.btnReloadCfg.Name = "btnReloadCfg";
            this.btnReloadCfg.Size = new System.Drawing.Size(137, 32);
            this.btnReloadCfg.TabIndex = 5;
            this.btnReloadCfg.Text = "重载配置文件";
            this.btnReloadCfg.UseVisualStyleBackColor = true;
            this.btnReloadCfg.Click += new System.EventHandler(this.btnReloadCfg_Click);
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Location = new System.Drawing.Point(448, 69);
            this.btnSaveCfg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.Size = new System.Drawing.Size(137, 32);
            this.btnSaveCfg.TabIndex = 6;
            this.btnSaveCfg.Text = "写入配置文件";
            this.btnSaveCfg.UseVisualStyleBackColor = true;
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // grpAxisCfg
            // 
            this.grpAxisCfg.Controls.Add(this.lblPulse);
            this.grpAxisCfg.Controls.Add(this.nudPulse);
            this.grpAxisCfg.Controls.Add(this.lblSoftLimit);
            this.grpAxisCfg.Controls.Add(this.chkSoftLimit);
            this.grpAxisCfg.Controls.Add(this.lblPosLimit);
            this.grpAxisCfg.Controls.Add(this.nudPosLimit);
            this.grpAxisCfg.Controls.Add(this.lblNegLimit);
            this.grpAxisCfg.Controls.Add(this.nudNegLimit);
            this.grpAxisCfg.Location = new System.Drawing.Point(20, 115);
            this.grpAxisCfg.Margin = new System.Windows.Forms.Padding(4);
            this.grpAxisCfg.Name = "grpAxisCfg";
            this.grpAxisCfg.Padding = new System.Windows.Forms.Padding(4);
            this.grpAxisCfg.Size = new System.Drawing.Size(247, 272);
            this.grpAxisCfg.TabIndex = 7;
            this.grpAxisCfg.TabStop = false;
            this.grpAxisCfg.Text = "轴配置";
            // 
            // lblPulse
            // 
            this.lblPulse.AutoSize = true;
            this.lblPulse.Location = new System.Drawing.Point(13, 38);
            this.lblPulse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(75, 15);
            this.lblPulse.TabIndex = 0;
            this.lblPulse.Text = "脉冲当量:";
            // 
            // nudPulse
            // 
            this.nudPulse.Location = new System.Drawing.Point(100, 32);
            this.nudPulse.Margin = new System.Windows.Forms.Padding(4);
            this.nudPulse.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPulse.Name = "nudPulse";
            this.nudPulse.Size = new System.Drawing.Size(133, 25);
            this.nudPulse.TabIndex = 1;
            // 
            // lblSoftLimit
            // 
            this.lblSoftLimit.AutoSize = true;
            this.lblSoftLimit.Location = new System.Drawing.Point(13, 72);
            this.lblSoftLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoftLimit.Name = "lblSoftLimit";
            this.lblSoftLimit.Size = new System.Drawing.Size(60, 15);
            this.lblSoftLimit.TabIndex = 2;
            this.lblSoftLimit.Text = "软限位:";
            // 
            // chkSoftLimit
            // 
            this.chkSoftLimit.AutoSize = true;
            this.chkSoftLimit.Location = new System.Drawing.Point(100, 70);
            this.chkSoftLimit.Margin = new System.Windows.Forms.Padding(4);
            this.chkSoftLimit.Name = "chkSoftLimit";
            this.chkSoftLimit.Size = new System.Drawing.Size(18, 17);
            this.chkSoftLimit.TabIndex = 3;
            this.chkSoftLimit.UseVisualStyleBackColor = true;
            // 
            // lblPosLimit
            // 
            this.lblPosLimit.AutoSize = true;
            this.lblPosLimit.Location = new System.Drawing.Point(13, 108);
            this.lblPosLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosLimit.Name = "lblPosLimit";
            this.lblPosLimit.Size = new System.Drawing.Size(60, 15);
            this.lblPosLimit.TabIndex = 4;
            this.lblPosLimit.Text = "正限位:";
            // 
            // nudPosLimit
            // 
            this.nudPosLimit.DecimalPlaces = 3;
            this.nudPosLimit.Location = new System.Drawing.Point(100, 102);
            this.nudPosLimit.Margin = new System.Windows.Forms.Padding(4);
            this.nudPosLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPosLimit.Name = "nudPosLimit";
            this.nudPosLimit.Size = new System.Drawing.Size(133, 25);
            this.nudPosLimit.TabIndex = 5;
            // 
            // lblNegLimit
            // 
            this.lblNegLimit.AutoSize = true;
            this.lblNegLimit.Location = new System.Drawing.Point(13, 142);
            this.lblNegLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNegLimit.Name = "lblNegLimit";
            this.lblNegLimit.Size = new System.Drawing.Size(60, 15);
            this.lblNegLimit.TabIndex = 6;
            this.lblNegLimit.Text = "负限位:";
            // 
            // nudNegLimit
            // 
            this.nudNegLimit.DecimalPlaces = 3;
            this.nudNegLimit.Location = new System.Drawing.Point(100, 138);
            this.nudNegLimit.Margin = new System.Windows.Forms.Padding(4);
            this.nudNegLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudNegLimit.Name = "nudNegLimit";
            this.nudNegLimit.Size = new System.Drawing.Size(133, 25);
            this.nudNegLimit.TabIndex = 7;
            // 
            // grpSpeed
            // 
            this.grpSpeed.Controls.Add(this.lblStartSpeed);
            this.grpSpeed.Controls.Add(this.nudStartSpeed);
            this.grpSpeed.Controls.Add(this.lblStopSpeed);
            this.grpSpeed.Controls.Add(this.nudStopSpeed);
            this.grpSpeed.Controls.Add(this.lblAccTime);
            this.grpSpeed.Controls.Add(this.nudAccTime);
            this.grpSpeed.Controls.Add(this.lblDecTime);
            this.grpSpeed.Controls.Add(this.nudDecTime);
            this.grpSpeed.Location = new System.Drawing.Point(277, 115);
            this.grpSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.grpSpeed.Name = "grpSpeed";
            this.grpSpeed.Padding = new System.Windows.Forms.Padding(4);
            this.grpSpeed.Size = new System.Drawing.Size(267, 272);
            this.grpSpeed.TabIndex = 8;
            this.grpSpeed.TabStop = false;
            this.grpSpeed.Text = "运动速度曲线";
            // 
            // lblStartSpeed
            // 
            this.lblStartSpeed.AutoSize = true;
            this.lblStartSpeed.Location = new System.Drawing.Point(13, 38);
            this.lblStartSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartSpeed.Name = "lblStartSpeed";
            this.lblStartSpeed.Size = new System.Drawing.Size(75, 15);
            this.lblStartSpeed.TabIndex = 0;
            this.lblStartSpeed.Text = "起始速度:";
            // 
            // nudStartSpeed
            // 
            this.nudStartSpeed.DecimalPlaces = 3;
            this.nudStartSpeed.Location = new System.Drawing.Point(113, 32);
            this.nudStartSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.nudStartSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudStartSpeed.Name = "nudStartSpeed";
            this.nudStartSpeed.Size = new System.Drawing.Size(140, 25);
            this.nudStartSpeed.TabIndex = 1;
            // 
            // lblStopSpeed
            // 
            this.lblStopSpeed.AutoSize = true;
            this.lblStopSpeed.Location = new System.Drawing.Point(13, 72);
            this.lblStopSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopSpeed.Name = "lblStopSpeed";
            this.lblStopSpeed.Size = new System.Drawing.Size(75, 15);
            this.lblStopSpeed.TabIndex = 2;
            this.lblStopSpeed.Text = "停止速度:";
            // 
            // nudStopSpeed
            // 
            this.nudStopSpeed.DecimalPlaces = 3;
            this.nudStopSpeed.Location = new System.Drawing.Point(113, 68);
            this.nudStopSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.nudStopSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudStopSpeed.Name = "nudStopSpeed";
            this.nudStopSpeed.Size = new System.Drawing.Size(140, 25);
            this.nudStopSpeed.TabIndex = 2;
            // 
            // lblAccTime
            // 
            this.lblAccTime.AutoSize = true;
            this.lblAccTime.Location = new System.Drawing.Point(13, 108);
            this.lblAccTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccTime.Name = "lblAccTime";
            this.lblAccTime.Size = new System.Drawing.Size(75, 15);
            this.lblAccTime.TabIndex = 4;
            this.lblAccTime.Text = "加速时间:";
            // 
            // nudAccTime
            // 
            this.nudAccTime.DecimalPlaces = 3;
            this.nudAccTime.Location = new System.Drawing.Point(113, 102);
            this.nudAccTime.Margin = new System.Windows.Forms.Padding(4);
            this.nudAccTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudAccTime.Name = "nudAccTime";
            this.nudAccTime.Size = new System.Drawing.Size(140, 25);
            this.nudAccTime.TabIndex = 3;
            // 
            // lblDecTime
            // 
            this.lblDecTime.AutoSize = true;
            this.lblDecTime.Location = new System.Drawing.Point(13, 142);
            this.lblDecTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDecTime.Name = "lblDecTime";
            this.lblDecTime.Size = new System.Drawing.Size(75, 15);
            this.lblDecTime.TabIndex = 6;
            this.lblDecTime.Text = "减速时间:";
            // 
            // nudDecTime
            // 
            this.nudDecTime.DecimalPlaces = 3;
            this.nudDecTime.Location = new System.Drawing.Point(113, 138);
            this.nudDecTime.Margin = new System.Windows.Forms.Padding(4);
            this.nudDecTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudDecTime.Name = "nudDecTime";
            this.nudDecTime.Size = new System.Drawing.Size(140, 25);
            this.nudDecTime.TabIndex = 4;
            // 
            // grpHome
            // 
            this.grpHome.Controls.Add(this.lblHomeMode);
            this.grpHome.Controls.Add(this.nudHomeMode);
            this.grpHome.Controls.Add(this.lblHomeLow);
            this.grpHome.Controls.Add(this.nudHomeLow);
            this.grpHome.Controls.Add(this.lblHomeHigh);
            this.grpHome.Controls.Add(this.nudHomeHigh);
            this.grpHome.Controls.Add(this.lblHomeAcc);
            this.grpHome.Controls.Add(this.nudHomeAcc);
            this.grpHome.Controls.Add(this.lblHomeDec);
            this.grpHome.Controls.Add(this.nudHomeDec);
            this.grpHome.Controls.Add(this.lblHomeOffset);
            this.grpHome.Controls.Add(this.nudHomeOffset);
            this.grpHome.Location = new System.Drawing.Point(552, 115);
            this.grpHome.Margin = new System.Windows.Forms.Padding(4);
            this.grpHome.Name = "grpHome";
            this.grpHome.Padding = new System.Windows.Forms.Padding(4);
            this.grpHome.Size = new System.Drawing.Size(179, 272);
            this.grpHome.TabIndex = 9;
            this.grpHome.TabStop = false;
            this.grpHome.Text = "回零配置";
            // 
            // lblHomeMode
            // 
            this.lblHomeMode.AutoSize = true;
            this.lblHomeMode.Location = new System.Drawing.Point(11, 38);
            this.lblHomeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeMode.Name = "lblHomeMode";
            this.lblHomeMode.Size = new System.Drawing.Size(75, 15);
            this.lblHomeMode.TabIndex = 0;
            this.lblHomeMode.Text = "回零模式:";
            // 
            // nudHomeMode
            // 
            this.nudHomeMode.Location = new System.Drawing.Point(93, 32);
            this.nudHomeMode.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeMode.Name = "nudHomeMode";
            this.nudHomeMode.Size = new System.Drawing.Size(77, 25);
            this.nudHomeMode.TabIndex = 1;
            // 
            // lblHomeLow
            // 
            this.lblHomeLow.AutoSize = true;
            this.lblHomeLow.Location = new System.Drawing.Point(11, 72);
            this.lblHomeLow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeLow.Name = "lblHomeLow";
            this.lblHomeLow.Size = new System.Drawing.Size(75, 15);
            this.lblHomeLow.TabIndex = 2;
            this.lblHomeLow.Text = "回零低速:";
            // 
            // nudHomeLow
            // 
            this.nudHomeLow.DecimalPlaces = 3;
            this.nudHomeLow.Location = new System.Drawing.Point(93, 68);
            this.nudHomeLow.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeLow.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudHomeLow.Name = "nudHomeLow";
            this.nudHomeLow.Size = new System.Drawing.Size(77, 25);
            this.nudHomeLow.TabIndex = 2;
            // 
            // lblHomeHigh
            // 
            this.lblHomeHigh.AutoSize = true;
            this.lblHomeHigh.Location = new System.Drawing.Point(11, 108);
            this.lblHomeHigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeHigh.Name = "lblHomeHigh";
            this.lblHomeHigh.Size = new System.Drawing.Size(75, 15);
            this.lblHomeHigh.TabIndex = 4;
            this.lblHomeHigh.Text = "回零高速:";
            // 
            // nudHomeHigh
            // 
            this.nudHomeHigh.DecimalPlaces = 3;
            this.nudHomeHigh.Location = new System.Drawing.Point(93, 102);
            this.nudHomeHigh.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeHigh.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudHomeHigh.Name = "nudHomeHigh";
            this.nudHomeHigh.Size = new System.Drawing.Size(77, 25);
            this.nudHomeHigh.TabIndex = 3;
            // 
            // lblHomeAcc
            // 
            this.lblHomeAcc.AutoSize = true;
            this.lblHomeAcc.Location = new System.Drawing.Point(11, 142);
            this.lblHomeAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeAcc.Name = "lblHomeAcc";
            this.lblHomeAcc.Size = new System.Drawing.Size(75, 15);
            this.lblHomeAcc.TabIndex = 6;
            this.lblHomeAcc.Text = "加速时间:";
            // 
            // nudHomeAcc
            // 
            this.nudHomeAcc.DecimalPlaces = 3;
            this.nudHomeAcc.Location = new System.Drawing.Point(93, 138);
            this.nudHomeAcc.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeAcc.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudHomeAcc.Name = "nudHomeAcc";
            this.nudHomeAcc.Size = new System.Drawing.Size(77, 25);
            this.nudHomeAcc.TabIndex = 4;
            // 
            // lblHomeDec
            // 
            this.lblHomeDec.AutoSize = true;
            this.lblHomeDec.Location = new System.Drawing.Point(11, 178);
            this.lblHomeDec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeDec.Name = "lblHomeDec";
            this.lblHomeDec.Size = new System.Drawing.Size(75, 15);
            this.lblHomeDec.TabIndex = 8;
            this.lblHomeDec.Text = "减速时间:";
            // 
            // nudHomeDec
            // 
            this.nudHomeDec.DecimalPlaces = 3;
            this.nudHomeDec.Location = new System.Drawing.Point(93, 172);
            this.nudHomeDec.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeDec.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudHomeDec.Name = "nudHomeDec";
            this.nudHomeDec.Size = new System.Drawing.Size(77, 25);
            this.nudHomeDec.TabIndex = 5;
            // 
            // lblHomeOffset
            // 
            this.lblHomeOffset.AutoSize = true;
            this.lblHomeOffset.Location = new System.Drawing.Point(11, 212);
            this.lblHomeOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeOffset.Name = "lblHomeOffset";
            this.lblHomeOffset.Size = new System.Drawing.Size(75, 15);
            this.lblHomeOffset.TabIndex = 10;
            this.lblHomeOffset.Text = "回零偏移:";
            // 
            // nudHomeOffset
            // 
            this.nudHomeOffset.DecimalPlaces = 3;
            this.nudHomeOffset.Location = new System.Drawing.Point(93, 208);
            this.nudHomeOffset.Margin = new System.Windows.Forms.Padding(4);
            this.nudHomeOffset.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudHomeOffset.Name = "nudHomeOffset";
            this.nudHomeOffset.Size = new System.Drawing.Size(77, 25);
            this.nudHomeOffset.TabIndex = 6;
            // 
            // FormSetInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 431);
            this.Controls.Add(this.grpController);
            this.Controls.Add(this.grpAxisNo);
            this.Controls.Add(this.grpAxisParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetInt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "轴参数配置";
            this.grpController.ResumeLayout(false);
            this.grpController.PerformLayout();
            this.grpAxisNo.ResumeLayout(false);
            this.grpAxisNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudXNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZNo)).EndInit();
            this.grpAxisParam.ResumeLayout(false);
            this.grpAxisParam.PerformLayout();
            this.grpAxisCfg.ResumeLayout(false);
            this.grpAxisCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPulse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNegLimit)).EndInit();
            this.grpSpeed.ResumeLayout(false);
            this.grpSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecTime)).EndInit();
            this.grpHome.ResumeLayout(false);
            this.grpHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeOffset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpController;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.GroupBox grpAxisNo;
        private System.Windows.Forms.Label lblXNo;
        private System.Windows.Forms.Label lblYNo;
        private System.Windows.Forms.Label lblZNo;
        private System.Windows.Forms.NumericUpDown nudXNo;
        private System.Windows.Forms.NumericUpDown nudYNo;
        private System.Windows.Forms.NumericUpDown nudZNo;
        private System.Windows.Forms.GroupBox grpAxisParam;
        private System.Windows.Forms.Label lblAxisName;
        private System.Windows.Forms.ComboBox cboAxisName;
        private System.Windows.Forms.Button btnReadCtrl;
        private System.Windows.Forms.Button btnWriteCtrl;
        private System.Windows.Forms.Button btnApplyAll;
        private System.Windows.Forms.Button btnReloadCfg;
        private System.Windows.Forms.Button btnSaveCfg;
        private System.Windows.Forms.GroupBox grpAxisCfg;
        private System.Windows.Forms.Label lblPulse;
        private System.Windows.Forms.NumericUpDown nudPulse;
        private System.Windows.Forms.Label lblSoftLimit;
        private System.Windows.Forms.CheckBox chkSoftLimit;
        private System.Windows.Forms.Label lblPosLimit;
        private System.Windows.Forms.NumericUpDown nudPosLimit;
        private System.Windows.Forms.Label lblNegLimit;
        private System.Windows.Forms.NumericUpDown nudNegLimit;
        private System.Windows.Forms.GroupBox grpSpeed;
        private System.Windows.Forms.Label lblStartSpeed;
        private System.Windows.Forms.NumericUpDown nudStartSpeed;
        private System.Windows.Forms.Label lblStopSpeed;
        private System.Windows.Forms.NumericUpDown nudStopSpeed;
        private System.Windows.Forms.Label lblAccTime;
        private System.Windows.Forms.NumericUpDown nudAccTime;
        private System.Windows.Forms.Label lblDecTime;
        private System.Windows.Forms.NumericUpDown nudDecTime;
        private System.Windows.Forms.GroupBox grpHome;
        private System.Windows.Forms.Label lblHomeMode;
        private System.Windows.Forms.NumericUpDown nudHomeMode;
        private System.Windows.Forms.Label lblHomeLow;
        private System.Windows.Forms.NumericUpDown nudHomeLow;
        private System.Windows.Forms.Label lblHomeHigh;
        private System.Windows.Forms.NumericUpDown nudHomeHigh;
        private System.Windows.Forms.Label lblHomeAcc;
        private System.Windows.Forms.NumericUpDown nudHomeAcc;
        private System.Windows.Forms.Label lblHomeDec;
        private System.Windows.Forms.NumericUpDown nudHomeDec;
        private System.Windows.Forms.Label lblHomeOffset;
        private System.Windows.Forms.NumericUpDown nudHomeOffset;
    }
}
