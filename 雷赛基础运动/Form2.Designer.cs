namespace 雷赛基础运动
{
    partial class Form2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTdec = new System.Windows.Forms.TextBox();
            this.lblTdec = new System.Windows.Forms.Label();
            this.txtTacc = new System.Windows.Forms.TextBox();
            this.lblTacc = new System.Windows.Forms.Label();
            this.txtMaxV = new System.Windows.Forms.TextBox();
            this.lblMaxV = new System.Windows.Forms.Label();
            this.txtMinV = new System.Windows.Forms.TextBox();
            this.lblMinV = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cmbYAxis = new System.Windows.Forms.ComboBox();
            this.lblYAxis = new System.Windows.Forms.Label();
            this.cmbXAxis = new System.Windows.Forms.ComboBox();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstShapes = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblShapeInfo = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblRun = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.txtTdec);
            this.groupBox1.Controls.Add(this.lblTdec);
            this.groupBox1.Controls.Add(this.txtTacc);
            this.groupBox1.Controls.Add(this.lblTacc);
            this.groupBox1.Controls.Add(this.txtMaxV);
            this.groupBox1.Controls.Add(this.lblMaxV);
            this.groupBox1.Controls.Add(this.txtMinV);
            this.groupBox1.Controls.Add(this.lblMinV);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.lblSize);
            this.groupBox1.Controls.Add(this.cmbYAxis);
            this.groupBox1.Controls.Add(this.lblYAxis);
            this.groupBox1.Controls.Add(this.cmbXAxis);
            this.groupBox1.Controls.Add(this.lblXAxis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "插补设置";
            //
            // lblXAxis
            //
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(12, 38);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(37, 15);
            this.lblXAxis.TabIndex = 0;
            this.lblXAxis.Text = "X轴：";
            //
            // cmbXAxis
            //
            this.cmbXAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXAxis.FormattingEnabled = true;
            this.cmbXAxis.Location = new System.Drawing.Point(95, 34);
            this.cmbXAxis.Name = "cmbXAxis";
            this.cmbXAxis.Size = new System.Drawing.Size(130, 23);
            this.cmbXAxis.TabIndex = 1;
            //
            // lblYAxis
            //
            this.lblYAxis.AutoSize = true;
            this.lblYAxis.Location = new System.Drawing.Point(12, 78);
            this.lblYAxis.Name = "lblYAxis";
            this.lblYAxis.Size = new System.Drawing.Size(37, 15);
            this.lblYAxis.TabIndex = 2;
            this.lblYAxis.Text = "Y轴：";
            //
            // cmbYAxis
            //
            this.cmbYAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYAxis.FormattingEnabled = true;
            this.cmbYAxis.Location = new System.Drawing.Point(95, 74);
            this.cmbYAxis.Name = "cmbYAxis";
            this.cmbYAxis.Size = new System.Drawing.Size(130, 23);
            this.cmbYAxis.TabIndex = 3;
            //
            // lblSize
            //
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(12, 118);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(67, 15);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "图形大小：";
            //
            // txtSize
            //
            this.txtSize.Location = new System.Drawing.Point(95, 114);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(130, 25);
            this.txtSize.TabIndex = 5;
            this.txtSize.Text = "50";
            //
            // lblMinV
            //
            this.lblMinV.AutoSize = true;
            this.lblMinV.Location = new System.Drawing.Point(12, 158);
            this.lblMinV.Name = "lblMinV";
            this.lblMinV.Size = new System.Drawing.Size(67, 15);
            this.lblMinV.TabIndex = 6;
            this.lblMinV.Text = "起始速度：";
            //
            // txtMinV
            //
            this.txtMinV.Location = new System.Drawing.Point(95, 154);
            this.txtMinV.Name = "txtMinV";
            this.txtMinV.Size = new System.Drawing.Size(130, 25);
            this.txtMinV.TabIndex = 7;
            this.txtMinV.Text = "0";
            //
            // lblMaxV
            //
            this.lblMaxV.AutoSize = true;
            this.lblMaxV.Location = new System.Drawing.Point(12, 198);
            this.lblMaxV.Name = "lblMaxV";
            this.lblMaxV.Size = new System.Drawing.Size(67, 15);
            this.lblMaxV.TabIndex = 8;
            this.lblMaxV.Text = "最大速度：";
            //
            // txtMaxV
            //
            this.txtMaxV.Location = new System.Drawing.Point(95, 194);
            this.txtMaxV.Name = "txtMaxV";
            this.txtMaxV.Size = new System.Drawing.Size(130, 25);
            this.txtMaxV.TabIndex = 9;
            this.txtMaxV.Text = "30";
            //
            // lblTacc
            //
            this.lblTacc.AutoSize = true;
            this.lblTacc.Location = new System.Drawing.Point(12, 238);
            this.lblTacc.Name = "lblTacc";
            this.lblTacc.Size = new System.Drawing.Size(67, 15);
            this.lblTacc.TabIndex = 10;
            this.lblTacc.Text = "加速时间：";
            //
            // txtTacc
            //
            this.txtTacc.Location = new System.Drawing.Point(95, 234);
            this.txtTacc.Name = "txtTacc";
            this.txtTacc.Size = new System.Drawing.Size(130, 25);
            this.txtTacc.TabIndex = 11;
            this.txtTacc.Text = "0.1";
            //
            // lblTdec
            //
            this.lblTdec.AutoSize = true;
            this.lblTdec.Location = new System.Drawing.Point(12, 278);
            this.lblTdec.Name = "lblTdec";
            this.lblTdec.Size = new System.Drawing.Size(67, 15);
            this.lblTdec.TabIndex = 12;
            this.lblTdec.Text = "减速时间：";
            //
            // txtTdec
            //
            this.txtTdec.Location = new System.Drawing.Point(95, 274);
            this.txtTdec.Name = "txtTdec";
            this.txtTdec.Size = new System.Drawing.Size(130, 25);
            this.txtTdec.TabIndex = 13;
            this.txtTdec.Text = "0.1";
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.lstShapes);
            this.groupBox2.Location = new System.Drawing.Point(274, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "形状选择";
            //
            // lstShapes
            //
            this.lstShapes.ItemHeight = 15;
            this.lstShapes.Items.AddRange(new object[] {
            "心形",
            "圆形",
            "正方形",
            "三角形",
            "五角星",
            "六边形",
            "八边形",
            "菱形",
            "无限符号",
            "螺旋线"});
            this.lstShapes.Location = new System.Drawing.Point(15, 32);
            this.lstShapes.Name = "lstShapes";
            this.lstShapes.Size = new System.Drawing.Size(220, 229);
            this.lstShapes.TabIndex = 0;
            this.lstShapes.SelectedIndexChanged += new System.EventHandler(this.lstShapes_SelectedIndexChanged);
            //
            // btnStart
            //
            this.btnStart.Location = new System.Drawing.Point(15, 278);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始绘制";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // btnStop
            //
            this.btnStop.Location = new System.Drawing.Point(130, 278);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 35);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.lblShapeInfo);
            this.groupBox3.Controls.Add(this.picPreview);
            this.groupBox3.Location = new System.Drawing.Point(534, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 330);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轨迹预览";
            //
            // picPreview
            //
            this.picPreview.BackColor = System.Drawing.Color.White;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(15, 32);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(424, 260);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            //
            // lblShapeInfo
            //
            this.lblShapeInfo.AutoSize = true;
            this.lblShapeInfo.Location = new System.Drawing.Point(15, 300);
            this.lblShapeInfo.Name = "lblShapeInfo";
            this.lblShapeInfo.Size = new System.Drawing.Size(262, 15);
            this.lblShapeInfo.TabIndex = 1;
            this.lblShapeInfo.Text = "选择形状后点击开始绘制（灰色为轮廓，红色为轨迹）";
            //
            // groupBox4
            //
            this.groupBox4.Controls.Add(this.btnZero);
            this.groupBox4.Controls.Add(this.btnEnable);
            this.groupBox4.Controls.Add(this.lblHint);
            this.groupBox4.Controls.Add(this.lblRun);
            this.groupBox4.Controls.Add(this.lblPos);
            this.groupBox4.Location = new System.Drawing.Point(12, 352);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(976, 90);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "运行状态";
            //
            // lblPos
            //
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(20, 42);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(187, 15);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "当前位置：X: 0.000  Y: 0.000";
            //
            // lblRun
            //
            this.lblRun.AutoSize = true;
            this.lblRun.Location = new System.Drawing.Point(400, 42);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(67, 15);
            this.lblRun.TabIndex = 1;
            this.lblRun.Text = "状态：停止";
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(20, 65);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(200, 15);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "提示：绘制前请确认 X/Y 轴已使能（状态机=4）";
            //
            // btnEnable
            //
            this.btnEnable.Location = new System.Drawing.Point(690, 28);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(120, 35);
            this.btnEnable.TabIndex = 4;
            this.btnEnable.Text = "开启使能";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            //
            // btnZero
            //
            this.btnZero.Location = new System.Drawing.Point(830, 28);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(120, 35);
            this.btnZero.TabIndex = 2;
            this.btnZero.Text = "坐标清零";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            //
            // timer2
            //
            this.timer2.Interval = 100;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            //
            // Form2
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 455);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "插补运动";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.ComboBox cmbXAxis;
        private System.Windows.Forms.Label lblYAxis;
        private System.Windows.Forms.ComboBox cmbYAxis;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblMinV;
        private System.Windows.Forms.TextBox txtMinV;
        private System.Windows.Forms.Label lblMaxV;
        private System.Windows.Forms.TextBox txtMaxV;
        private System.Windows.Forms.Label lblTacc;
        private System.Windows.Forms.TextBox txtTacc;
        private System.Windows.Forms.Label lblTdec;
        private System.Windows.Forms.TextBox txtTdec;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstShapes;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblShapeInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Timer timer2;
    }
}
