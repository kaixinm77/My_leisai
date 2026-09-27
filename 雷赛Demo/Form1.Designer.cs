namespace 雷赛Demo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDwell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblXMove = new System.Windows.Forms.Label();
            this.lblYMove = new System.Windows.Forms.Label();
            this.lblZMove = new System.Windows.Forms.Label();
            this.lblXAlarm = new System.Windows.Forms.Label();
            this.lblYAlarm = new System.Windows.Forms.Label();
            this.lblZAlarm = new System.Windows.Forms.Label();
            this.indXMove = new System.Windows.Forms.Label();
            this.indYMove = new System.Windows.Forms.Label();
            this.indZMove = new System.Windows.Forms.Label();
            this.indXAlarm = new System.Windows.Forms.Label();
            this.indYAlarm = new System.Windows.Forms.Label();
            this.indZAlarm = new System.Windows.Forms.Label();
            this.grpOperation = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClearError = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpManual = new System.Windows.Forms.GroupBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblUnit = new System.Windows.Forms.Label();
            this.grpJog = new System.Windows.Forms.GroupBox();
            this.btnYPlus = new System.Windows.Forms.Button();
            this.btnZPlus = new System.Windows.Forms.Button();
            this.btnXMinus = new System.Windows.Forms.Button();
            this.btnXPlus = new System.Windows.Forms.Button();
            this.btnYMinus = new System.Windows.Forms.Button();
            this.btnZMinus = new System.Windows.Forms.Button();
            this.grpLocate = new System.Windows.Forms.GroupBox();
            this.lblLocX = new System.Windows.Forms.Label();
            this.lblLocY = new System.Windows.Forms.Label();
            this.lblLocZ = new System.Windows.Forms.Label();
            this.nudLocX = new System.Windows.Forms.NumericUpDown();
            this.nudLocY = new System.Windows.Forms.NumericUpDown();
            this.nudLocZ = new System.Windows.Forms.NumericUpDown();
            this.btnMoveX = new System.Windows.Forms.Button();
            this.btnMoveY = new System.Windows.Forms.Button();
            this.btnMoveZ = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsslError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJob = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJobStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJobStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            this.panelRight.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpOperation.SuspendLayout();
            this.grpManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.grpJog.SuspendLayout();
            this.grpLocate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocZ)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.AllowUserToOrderColumns = true;
            this.dgvPoints.AllowUserToResizeRows = false;
            this.dgvPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colX,
            this.colY,
            this.colZ,
            this.colDwell,
            this.colEnable});
            this.dgvPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoints.Location = new System.Drawing.Point(0, 28);
            this.dgvPoints.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.RowHeadersWidth = 51;
            this.dgvPoints.RowTemplate.Height = 23;
            this.dgvPoints.Size = new System.Drawing.Size(900, 693);
            this.dgvPoints.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 20F;
            this.colName.HeaderText = "点位名称";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            // 
            // colX
            // 
            this.colX.DataPropertyName = "X";
            this.colX.FillWeight = 15F;
            this.colX.HeaderText = "X";
            this.colX.MinimumWidth = 6;
            this.colX.Name = "colX";
            // 
            // colY
            // 
            this.colY.DataPropertyName = "Y";
            this.colY.FillWeight = 15F;
            this.colY.HeaderText = "Y";
            this.colY.MinimumWidth = 6;
            this.colY.Name = "colY";
            // 
            // colZ
            // 
            this.colZ.DataPropertyName = "Z";
            this.colZ.FillWeight = 15F;
            this.colZ.HeaderText = "Z";
            this.colZ.MinimumWidth = 6;
            this.colZ.Name = "colZ";
            // 
            // colDwell
            // 
            this.colDwell.DataPropertyName = "WaitTime";
            this.colDwell.FillWeight = 20F;
            this.colDwell.HeaderText = "停留时间";
            this.colDwell.MinimumWidth = 6;
            this.colDwell.Name = "colDwell";
            // 
            // colEnable
            // 
            this.colEnable.DataPropertyName = "Enable";
            this.colEnable.FillWeight = 15F;
            this.colEnable.HeaderText = "启用";
            this.colEnable.MinimumWidth = 6;
            this.colEnable.Name = "colEnable";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.Control;
            this.panelRight.Controls.Add(this.grpStatus);
            this.panelRight.Controls.Add(this.grpOperation);
            this.panelRight.Controls.Add(this.grpManual);
            this.panelRight.Controls.Add(this.grpJog);
            this.panelRight.Controls.Add(this.grpLocate);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(900, 28);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(326, 693);
            this.panelRight.TabIndex = 2;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.label1);
            this.grpStatus.Controls.Add(this.label2);
            this.grpStatus.Controls.Add(this.label3);
            this.grpStatus.Controls.Add(this.label4);
            this.grpStatus.Controls.Add(this.label5);
            this.grpStatus.Controls.Add(this.label6);
            this.grpStatus.Controls.Add(this.lblXMove);
            this.grpStatus.Controls.Add(this.lblYMove);
            this.grpStatus.Controls.Add(this.lblZMove);
            this.grpStatus.Controls.Add(this.lblXAlarm);
            this.grpStatus.Controls.Add(this.lblYAlarm);
            this.grpStatus.Controls.Add(this.lblZAlarm);
            this.grpStatus.Controls.Add(this.indXMove);
            this.grpStatus.Controls.Add(this.indYMove);
            this.grpStatus.Controls.Add(this.indZMove);
            this.grpStatus.Controls.Add(this.indXAlarm);
            this.grpStatus.Controls.Add(this.indYAlarm);
            this.grpStatus.Controls.Add(this.indZAlarm);
            this.grpStatus.Location = new System.Drawing.Point(3, 2);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(4);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(4);
            this.grpStatus.Size = new System.Drawing.Size(323, 175);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "控制器状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "正常";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "正常";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "正常";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "正常";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "正常";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "正常";
            // 
            // lblXMove
            // 
            this.lblXMove.AutoSize = true;
            this.lblXMove.Location = new System.Drawing.Point(13, 28);
            this.lblXMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXMove.Name = "lblXMove";
            this.lblXMove.Size = new System.Drawing.Size(98, 15);
            this.lblXMove.TabIndex = 0;
            this.lblXMove.Text = "X轴运动状态:";
            // 
            // lblYMove
            // 
            this.lblYMove.AutoSize = true;
            this.lblYMove.Location = new System.Drawing.Point(13, 52);
            this.lblYMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYMove.Name = "lblYMove";
            this.lblYMove.Size = new System.Drawing.Size(98, 15);
            this.lblYMove.TabIndex = 1;
            this.lblYMove.Text = "Y轴运动状态:";
            // 
            // lblZMove
            // 
            this.lblZMove.AutoSize = true;
            this.lblZMove.Location = new System.Drawing.Point(13, 78);
            this.lblZMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZMove.Name = "lblZMove";
            this.lblZMove.Size = new System.Drawing.Size(98, 15);
            this.lblZMove.TabIndex = 2;
            this.lblZMove.Text = "Z轴运动状态:";
            // 
            // lblXAlarm
            // 
            this.lblXAlarm.AutoSize = true;
            this.lblXAlarm.Location = new System.Drawing.Point(13, 102);
            this.lblXAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXAlarm.Name = "lblXAlarm";
            this.lblXAlarm.Size = new System.Drawing.Size(98, 15);
            this.lblXAlarm.TabIndex = 3;
            this.lblXAlarm.Text = "X轴报警状态:";
            // 
            // lblYAlarm
            // 
            this.lblYAlarm.AutoSize = true;
            this.lblYAlarm.Location = new System.Drawing.Point(13, 128);
            this.lblYAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYAlarm.Name = "lblYAlarm";
            this.lblYAlarm.Size = new System.Drawing.Size(98, 15);
            this.lblYAlarm.TabIndex = 4;
            this.lblYAlarm.Text = "Y轴报警状态:";
            // 
            // lblZAlarm
            // 
            this.lblZAlarm.AutoSize = true;
            this.lblZAlarm.Location = new System.Drawing.Point(13, 152);
            this.lblZAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZAlarm.Name = "lblZAlarm";
            this.lblZAlarm.Size = new System.Drawing.Size(98, 15);
            this.lblZAlarm.TabIndex = 5;
            this.lblZAlarm.Text = "Z轴报警状态:";
            // 
            // indXMove
            // 
            this.indXMove.BackColor = System.Drawing.Color.Lime;
            this.indXMove.Location = new System.Drawing.Point(137, 28);
            this.indXMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indXMove.Name = "indXMove";
            this.indXMove.Size = new System.Drawing.Size(17, 16);
            this.indXMove.TabIndex = 6;
            // 
            // indYMove
            // 
            this.indYMove.BackColor = System.Drawing.Color.Lime;
            this.indYMove.Location = new System.Drawing.Point(137, 52);
            this.indYMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indYMove.Name = "indYMove";
            this.indYMove.Size = new System.Drawing.Size(17, 16);
            this.indYMove.TabIndex = 7;
            // 
            // indZMove
            // 
            this.indZMove.BackColor = System.Drawing.Color.Lime;
            this.indZMove.Location = new System.Drawing.Point(137, 78);
            this.indZMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indZMove.Name = "indZMove";
            this.indZMove.Size = new System.Drawing.Size(17, 16);
            this.indZMove.TabIndex = 8;
            // 
            // indXAlarm
            // 
            this.indXAlarm.BackColor = System.Drawing.Color.Lime;
            this.indXAlarm.Location = new System.Drawing.Point(137, 102);
            this.indXAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indXAlarm.Name = "indXAlarm";
            this.indXAlarm.Size = new System.Drawing.Size(17, 16);
            this.indXAlarm.TabIndex = 9;
            // 
            // indYAlarm
            // 
            this.indYAlarm.BackColor = System.Drawing.Color.Lime;
            this.indYAlarm.Location = new System.Drawing.Point(137, 128);
            this.indYAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indYAlarm.Name = "indYAlarm";
            this.indYAlarm.Size = new System.Drawing.Size(17, 16);
            this.indYAlarm.TabIndex = 10;
            // 
            // indZAlarm
            // 
            this.indZAlarm.BackColor = System.Drawing.Color.Lime;
            this.indZAlarm.Location = new System.Drawing.Point(137, 152);
            this.indZAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indZAlarm.Name = "indZAlarm";
            this.indZAlarm.Size = new System.Drawing.Size(17, 16);
            this.indZAlarm.TabIndex = 11;
            // 
            // grpOperation
            // 
            this.grpOperation.Controls.Add(this.btnReset);
            this.grpOperation.Controls.Add(this.btnClearError);
            this.grpOperation.Controls.Add(this.btnStart);
            this.grpOperation.Controls.Add(this.btnStop);
            this.grpOperation.Location = new System.Drawing.Point(3, 182);
            this.grpOperation.Margin = new System.Windows.Forms.Padding(4);
            this.grpOperation.Name = "grpOperation";
            this.grpOperation.Padding = new System.Windows.Forms.Padding(4);
            this.grpOperation.Size = new System.Drawing.Size(323, 130);
            this.grpOperation.TabIndex = 1;
            this.grpOperation.TabStop = false;
            this.grpOperation.Text = "控制器操作";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(11, 25);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(301, 31);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "复位（回零）";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClearError
            // 
            this.btnClearError.Location = new System.Drawing.Point(11, 61);
            this.btnClearError.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(301, 31);
            this.btnClearError.TabIndex = 1;
            this.btnClearError.Text = "清除错误";
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 98);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(148, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始作业";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(164, 98);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(148, 31);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止作业";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpManual
            // 
            this.grpManual.Controls.Add(this.lblSpeed);
            this.grpManual.Controls.Add(this.nudSpeed);
            this.grpManual.Controls.Add(this.lblUnit);
            this.grpManual.Location = new System.Drawing.Point(3, 318);
            this.grpManual.Margin = new System.Windows.Forms.Padding(4);
            this.grpManual.Name = "grpManual";
            this.grpManual.Padding = new System.Windows.Forms.Padding(4);
            this.grpManual.Size = new System.Drawing.Size(323, 68);
            this.grpManual.TabIndex = 2;
            this.grpManual.TabStop = false;
            this.grpManual.Text = "手动控制";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(13, 32);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(45, 15);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "速度:";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(73, 29);
            this.nudSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.nudSpeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(147, 25);
            this.nudSpeed.TabIndex = 1;
            this.nudSpeed.ValueChanged += new System.EventHandler(this.nudSpeed_ValueChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(229, 32);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(39, 15);
            this.lblUnit.TabIndex = 2;
            this.lblUnit.Text = "MM/S";
            // 
            // grpJog
            // 
            this.grpJog.Controls.Add(this.btnYPlus);
            this.grpJog.Controls.Add(this.btnZPlus);
            this.grpJog.Controls.Add(this.btnXMinus);
            this.grpJog.Controls.Add(this.btnXPlus);
            this.grpJog.Controls.Add(this.btnYMinus);
            this.grpJog.Controls.Add(this.btnZMinus);
            this.grpJog.Location = new System.Drawing.Point(3, 390);
            this.grpJog.Margin = new System.Windows.Forms.Padding(4);
            this.grpJog.Name = "grpJog";
            this.grpJog.Padding = new System.Windows.Forms.Padding(4);
            this.grpJog.Size = new System.Drawing.Size(323, 165);
            this.grpJog.TabIndex = 3;
            this.grpJog.TabStop = false;
            this.grpJog.Text = "点动控制";
            // 
            // btnYPlus
            // 
            this.btnYPlus.Location = new System.Drawing.Point(120, 25);
            this.btnYPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btnYPlus.Name = "btnYPlus";
            this.btnYPlus.Size = new System.Drawing.Size(73, 32);
            this.btnYPlus.TabIndex = 0;
            this.btnYPlus.Tag = "Y,1";
            this.btnYPlus.Text = "Y+";
            this.btnYPlus.UseVisualStyleBackColor = true;
            this.btnYPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnYPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // btnZPlus
            // 
            this.btnZPlus.Location = new System.Drawing.Point(220, 25);
            this.btnZPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btnZPlus.Name = "btnZPlus";
            this.btnZPlus.Size = new System.Drawing.Size(73, 32);
            this.btnZPlus.TabIndex = 1;
            this.btnZPlus.Tag = "Z,1";
            this.btnZPlus.Text = "Z+";
            this.btnZPlus.UseVisualStyleBackColor = true;
            this.btnZPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnZPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // btnXMinus
            // 
            this.btnXMinus.Location = new System.Drawing.Point(20, 72);
            this.btnXMinus.Margin = new System.Windows.Forms.Padding(4);
            this.btnXMinus.Name = "btnXMinus";
            this.btnXMinus.Size = new System.Drawing.Size(73, 32);
            this.btnXMinus.TabIndex = 2;
            this.btnXMinus.Tag = "X,0";
            this.btnXMinus.Text = "X-";
            this.btnXMinus.UseVisualStyleBackColor = true;
            this.btnXMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnXMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // btnXPlus
            // 
            this.btnXPlus.Location = new System.Drawing.Point(220, 72);
            this.btnXPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btnXPlus.Name = "btnXPlus";
            this.btnXPlus.Size = new System.Drawing.Size(73, 32);
            this.btnXPlus.TabIndex = 3;
            this.btnXPlus.Tag = "X,1";
            this.btnXPlus.Text = "X+";
            this.btnXPlus.UseVisualStyleBackColor = true;
            this.btnXPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnXPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // btnYMinus
            // 
            this.btnYMinus.Location = new System.Drawing.Point(120, 120);
            this.btnYMinus.Margin = new System.Windows.Forms.Padding(4);
            this.btnYMinus.Name = "btnYMinus";
            this.btnYMinus.Size = new System.Drawing.Size(73, 32);
            this.btnYMinus.TabIndex = 4;
            this.btnYMinus.Tag = "Y,0";
            this.btnYMinus.Text = "Y-";
            this.btnYMinus.UseVisualStyleBackColor = true;
            this.btnYMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnYMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // btnZMinus
            // 
            this.btnZMinus.Location = new System.Drawing.Point(220, 120);
            this.btnZMinus.Margin = new System.Windows.Forms.Padding(4);
            this.btnZMinus.Name = "btnZMinus";
            this.btnZMinus.Size = new System.Drawing.Size(73, 32);
            this.btnZMinus.TabIndex = 5;
            this.btnZMinus.Tag = "Z,0";
            this.btnZMinus.Text = "Z-";
            this.btnZMinus.UseVisualStyleBackColor = true;
            this.btnZMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnZMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseUp);
            // 
            // grpLocate
            // 
            this.grpLocate.Controls.Add(this.lblLocX);
            this.grpLocate.Controls.Add(this.lblLocY);
            this.grpLocate.Controls.Add(this.lblLocZ);
            this.grpLocate.Controls.Add(this.nudLocX);
            this.grpLocate.Controls.Add(this.nudLocY);
            this.grpLocate.Controls.Add(this.nudLocZ);
            this.grpLocate.Controls.Add(this.btnMoveX);
            this.grpLocate.Controls.Add(this.btnMoveY);
            this.grpLocate.Controls.Add(this.btnMoveZ);
            this.grpLocate.Location = new System.Drawing.Point(3, 560);
            this.grpLocate.Margin = new System.Windows.Forms.Padding(4);
            this.grpLocate.Name = "grpLocate";
            this.grpLocate.Padding = new System.Windows.Forms.Padding(4);
            this.grpLocate.Size = new System.Drawing.Size(323, 135);
            this.grpLocate.TabIndex = 4;
            this.grpLocate.TabStop = false;
            this.grpLocate.Text = "定位移动";
            // 
            // lblLocX
            // 
            this.lblLocX.AutoSize = true;
            this.lblLocX.Location = new System.Drawing.Point(13, 30);
            this.lblLocX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocX.Name = "lblLocX";
            this.lblLocX.Size = new System.Drawing.Size(23, 15);
            this.lblLocX.TabIndex = 0;
            this.lblLocX.Text = "X:";
            // 
            // lblLocY
            // 
            this.lblLocY.AutoSize = true;
            this.lblLocY.Location = new System.Drawing.Point(13, 62);
            this.lblLocY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocY.Name = "lblLocY";
            this.lblLocY.Size = new System.Drawing.Size(23, 15);
            this.lblLocY.TabIndex = 1;
            this.lblLocY.Text = "Y:";
            // 
            // lblLocZ
            // 
            this.lblLocZ.AutoSize = true;
            this.lblLocZ.Location = new System.Drawing.Point(13, 95);
            this.lblLocZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocZ.Name = "lblLocZ";
            this.lblLocZ.Size = new System.Drawing.Size(23, 15);
            this.lblLocZ.TabIndex = 2;
            this.lblLocZ.Text = "Z:";
            // 
            // nudLocX
            // 
            this.nudLocX.DecimalPlaces = 3;
            this.nudLocX.Location = new System.Drawing.Point(47, 26);
            this.nudLocX.Margin = new System.Windows.Forms.Padding(4);
            this.nudLocX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLocX.Name = "nudLocX";
            this.nudLocX.Size = new System.Drawing.Size(147, 25);
            this.nudLocX.TabIndex = 3;
            // 
            // nudLocY
            // 
            this.nudLocY.DecimalPlaces = 3;
            this.nudLocY.Location = new System.Drawing.Point(47, 59);
            this.nudLocY.Margin = new System.Windows.Forms.Padding(4);
            this.nudLocY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLocY.Name = "nudLocY";
            this.nudLocY.Size = new System.Drawing.Size(147, 25);
            this.nudLocY.TabIndex = 4;
            // 
            // nudLocZ
            // 
            this.nudLocZ.DecimalPlaces = 3;
            this.nudLocZ.Location = new System.Drawing.Point(47, 91);
            this.nudLocZ.Margin = new System.Windows.Forms.Padding(4);
            this.nudLocZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLocZ.Name = "nudLocZ";
            this.nudLocZ.Size = new System.Drawing.Size(147, 25);
            this.nudLocZ.TabIndex = 5;
            // 
            // btnMoveX
            // 
            this.btnMoveX.Location = new System.Drawing.Point(207, 25);
            this.btnMoveX.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveX.Name = "btnMoveX";
            this.btnMoveX.Size = new System.Drawing.Size(100, 30);
            this.btnMoveX.TabIndex = 6;
            this.btnMoveX.Tag = "X";
            this.btnMoveX.Text = "移动";
            this.btnMoveX.UseVisualStyleBackColor = true;
            this.btnMoveX.Click += new System.EventHandler(this.btnMoveX_Click);
            // 
            // btnMoveY
            // 
            this.btnMoveY.Location = new System.Drawing.Point(207, 58);
            this.btnMoveY.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveY.Name = "btnMoveY";
            this.btnMoveY.Size = new System.Drawing.Size(100, 30);
            this.btnMoveY.TabIndex = 7;
            this.btnMoveY.Tag = "Y";
            this.btnMoveY.Text = "移动";
            this.btnMoveY.UseVisualStyleBackColor = true;
            this.btnMoveY.Click += new System.EventHandler(this.btnMoveY_Click);
            // 
            // btnMoveZ
            // 
            this.btnMoveZ.Location = new System.Drawing.Point(207, 90);
            this.btnMoveZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveZ.Name = "btnMoveZ";
            this.btnMoveZ.Size = new System.Drawing.Size(100, 30);
            this.btnMoveZ.TabIndex = 8;
            this.btnMoveZ.Tag = "Z";
            this.btnMoveZ.Text = "移动";
            this.btnMoveZ.UseVisualStyleBackColor = true;
            this.btnMoveZ.Click += new System.EventHandler(this.btnMoveZ_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tsslError
            // 
            this.tsslError.Name = "tsslError";
            this.tsslError.Size = new System.Drawing.Size(54, 20);
            this.tsslError.Text = "无错误";
            // 
            // tsslX
            // 
            this.tsslX.Name = "tsslX";
            this.tsslX.Size = new System.Drawing.Size(58, 20);
            this.tsslX.Text = "X: 0.00";
            // 
            // tsslY
            // 
            this.tsslY.Name = "tsslY";
            this.tsslY.Size = new System.Drawing.Size(57, 20);
            this.tsslY.Text = "Y: 0.00";
            // 
            // tsslZ
            // 
            this.tsslZ.Name = "tsslZ";
            this.tsslZ.Size = new System.Drawing.Size(57, 20);
            this.tsslZ.Text = "Z: 0.00";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslError,
            this.tsslX,
            this.tsslY,
            this.tsslZ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 721);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1226, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.toolStripSeparator1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(116, 24);
            this.menuFile.Text = "控制器配置(&F)";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(224, 26);
            this.menuOpen.Text = "打开控制器配置(&O)";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(224, 26);
            this.menuExit.Text = "退出(&X)";
            // 
            // menuJob
            // 
            this.menuJob.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJobStart,
            this.menuJobStop});
            this.menuJob.Name = "menuJob";
            this.menuJob.Size = new System.Drawing.Size(99, 24);
            this.menuJob.Text = "点位控制(&J)";
            // 
            // menuJobStart
            // 
            this.menuJobStart.Name = "menuJobStart";
            this.menuJobStart.Size = new System.Drawing.Size(152, 26);
            this.menuJobStart.Text = "开始作业";
            // 
            // menuJobStop
            // 
            this.menuJobStop.Name = "menuJobStop";
            this.menuJobStop.Size = new System.Drawing.Size(152, 26);
            this.menuJobStop.Text = "停止作业";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuJob});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1226, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 747);
            this.Controls.Add(this.dgvPoints);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpOperation.ResumeLayout(false);
            this.grpManual.ResumeLayout(false);
            this.grpManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.grpJog.ResumeLayout(false);
            this.grpLocate.ResumeLayout(false);
            this.grpLocate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocZ)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblXMove;
        private System.Windows.Forms.Label lblYMove;
        private System.Windows.Forms.Label lblZMove;
        private System.Windows.Forms.Label lblXAlarm;
        private System.Windows.Forms.Label lblYAlarm;
        private System.Windows.Forms.Label lblZAlarm;
        private System.Windows.Forms.Label indXMove;
        private System.Windows.Forms.Label indYMove;
        private System.Windows.Forms.Label indZMove;
        private System.Windows.Forms.Label indXAlarm;
        private System.Windows.Forms.Label indYAlarm;
        private System.Windows.Forms.Label indZAlarm;
        private System.Windows.Forms.GroupBox grpOperation;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClearError;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox grpManual;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.GroupBox grpJog;
        private System.Windows.Forms.Button btnXPlus;
        private System.Windows.Forms.Button btnXMinus;
        private System.Windows.Forms.Button btnYPlus;
        private System.Windows.Forms.Button btnYMinus;
        private System.Windows.Forms.Button btnZPlus;
        private System.Windows.Forms.Button btnZMinus;
        private System.Windows.Forms.GroupBox grpLocate;
        private System.Windows.Forms.Label lblLocX;
        private System.Windows.Forms.Label lblLocY;
        private System.Windows.Forms.Label lblLocZ;
        private System.Windows.Forms.NumericUpDown nudLocX;
        private System.Windows.Forms.NumericUpDown nudLocY;
        private System.Windows.Forms.NumericUpDown nudLocZ;
        private System.Windows.Forms.Button btnMoveX;
        private System.Windows.Forms.Button btnMoveY;
        private System.Windows.Forms.Button btnMoveZ;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDwell;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel tsslError;
        private System.Windows.Forms.ToolStripStatusLabel tsslX;
        private System.Windows.Forms.ToolStripStatusLabel tsslY;
        private System.Windows.Forms.ToolStripStatusLabel tsslZ;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuJob;
        private System.Windows.Forms.ToolStripMenuItem menuJobStart;
        private System.Windows.Forms.ToolStripMenuItem menuJobStop;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}
