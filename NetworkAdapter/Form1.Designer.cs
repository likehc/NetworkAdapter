namespace NetworkAdapter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_SearchNetAdapters = new System.Windows.Forms.Button();
            this.combox_NetAdapters = new System.Windows.Forms.ComboBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.labIP = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.labMask = new System.Windows.Forms.Label();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.labGateway = new System.Windows.Forms.Label();
            this.txtDNS1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNS2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPv6 = new System.Windows.Forms.TextBox();
            this.labIPv6 = new System.Windows.Forms.Label();
            this.labMaskLength = new System.Windows.Forms.Label();
            this.btnAdaEdit = new System.Windows.Forms.Button();
            this.cmb_AdaEdit = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lab_speed = new System.Windows.Forms.Label();
            this.btn_OpenConn = new System.Windows.Forms.Button();
            this.labIsDHCP = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_StartDHCP = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.chkBox_UpdateInfo = new System.Windows.Forms.CheckBox();
            this.timerUpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.txt_mac_speed = new System.Windows.Forms.TextBox();
            this.lab_OperationStatus = new System.Windows.Forms.Label();
            this.btn_SetMaskLength = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_SaveToxml = new System.Windows.Forms.Button();
            this.btn_SetFromTxt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SearchNetAdapters
            // 
            this.btn_SearchNetAdapters.Location = new System.Drawing.Point(330, 17);
            this.btn_SearchNetAdapters.Name = "btn_SearchNetAdapters";
            this.btn_SearchNetAdapters.Size = new System.Drawing.Size(137, 33);
            this.btn_SearchNetAdapters.TabIndex = 1;
            this.btn_SearchNetAdapters.Text = "获取网卡信息";
            this.btn_SearchNetAdapters.UseVisualStyleBackColor = true;
            this.btn_SearchNetAdapters.Click += new System.EventHandler(this.btn_SearchNetAdapters_Click);
            // 
            // combox_NetAdapters
            // 
            this.combox_NetAdapters.FormattingEnabled = true;
            this.combox_NetAdapters.Location = new System.Drawing.Point(44, 23);
            this.combox_NetAdapters.Name = "combox_NetAdapters";
            this.combox_NetAdapters.Size = new System.Drawing.Size(280, 23);
            this.combox_NetAdapters.TabIndex = 2;
            this.combox_NetAdapters.SelectedIndexChanged += new System.EventHandler(this.combox_NetAdapters_SelectedIndexChanged);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(60, 102);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 25);
            this.txtIP.TabIndex = 5;
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(23, 105);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(31, 15);
            this.labIP.TabIndex = 3;
            this.labIP.Text = "IP:";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(60, 149);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(150, 25);
            this.txtMask.TabIndex = 6;
            // 
            // labMask
            // 
            this.labMask.AutoSize = true;
            this.labMask.Location = new System.Drawing.Point(13, 152);
            this.labMask.Name = "labMask";
            this.labMask.Size = new System.Drawing.Size(45, 15);
            this.labMask.TabIndex = 3;
            this.labMask.Text = "掩码:";
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(60, 190);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(150, 25);
            this.txtGateway.TabIndex = 7;
            // 
            // labGateway
            // 
            this.labGateway.AutoSize = true;
            this.labGateway.Location = new System.Drawing.Point(13, 193);
            this.labGateway.Name = "labGateway";
            this.labGateway.Size = new System.Drawing.Size(45, 15);
            this.labGateway.TabIndex = 3;
            this.labGateway.Text = "网关:";
            // 
            // txtDNS1
            // 
            this.txtDNS1.Location = new System.Drawing.Point(60, 243);
            this.txtDNS1.Name = "txtDNS1";
            this.txtDNS1.Size = new System.Drawing.Size(150, 25);
            this.txtDNS1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "DNS1:";
            // 
            // txtDNS2
            // 
            this.txtDNS2.Location = new System.Drawing.Point(60, 290);
            this.txtDNS2.Name = "txtDNS2";
            this.txtDNS2.Size = new System.Drawing.Size(150, 25);
            this.txtDNS2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "DNS2:";
            // 
            // txtIPv6
            // 
            this.txtIPv6.Location = new System.Drawing.Point(60, 337);
            this.txtIPv6.Multiline = true;
            this.txtIPv6.Name = "txtIPv6";
            this.txtIPv6.ReadOnly = true;
            this.txtIPv6.Size = new System.Drawing.Size(254, 25);
            this.txtIPv6.TabIndex = 2;
            // 
            // labIPv6
            // 
            this.labIPv6.AutoSize = true;
            this.labIPv6.Location = new System.Drawing.Point(13, 340);
            this.labIPv6.Name = "labIPv6";
            this.labIPv6.Size = new System.Drawing.Size(47, 15);
            this.labIPv6.TabIndex = 3;
            this.labIPv6.Text = "IPv6:";
            // 
            // labMaskLength
            // 
            this.labMaskLength.AutoSize = true;
            this.labMaskLength.Location = new System.Drawing.Point(216, 135);
            this.labMaskLength.Name = "labMaskLength";
            this.labMaskLength.Size = new System.Drawing.Size(37, 15);
            this.labMaskLength.TabIndex = 3;
            this.labMaskLength.Text = "长度";
            // 
            // btnAdaEdit
            // 
            this.btnAdaEdit.Location = new System.Drawing.Point(521, 52);
            this.btnAdaEdit.Name = "btnAdaEdit";
            this.btnAdaEdit.Size = new System.Drawing.Size(101, 33);
            this.btnAdaEdit.TabIndex = 10;
            this.btnAdaEdit.Text = "修改静态IP";
            this.btnAdaEdit.UseVisualStyleBackColor = true;
            this.btnAdaEdit.Click += new System.EventHandler(this.btnAdaEdit_Click);
            // 
            // cmb_AdaEdit
            // 
            this.cmb_AdaEdit.FormattingEnabled = true;
            this.cmb_AdaEdit.Location = new System.Drawing.Point(473, 23);
            this.cmb_AdaEdit.Name = "cmb_AdaEdit";
            this.cmb_AdaEdit.Size = new System.Drawing.Size(149, 23);
            this.cmb_AdaEdit.TabIndex = 1;
            this.cmb_AdaEdit.SelectedIndexChanged += new System.EventHandler(this.cmb_AdaEdit_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(775, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(775, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lab_speed
            // 
            this.lab_speed.AutoSize = true;
            this.lab_speed.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_speed.ForeColor = System.Drawing.Color.Black;
            this.lab_speed.Location = new System.Drawing.Point(18, 50);
            this.lab_speed.Name = "lab_speed";
            this.lab_speed.Size = new System.Drawing.Size(59, 19);
            this.lab_speed.TabIndex = 8;
            this.lab_speed.Text = "speed";
            // 
            // btn_OpenConn
            // 
            this.btn_OpenConn.Location = new System.Drawing.Point(347, 100);
            this.btn_OpenConn.Name = "btn_OpenConn";
            this.btn_OpenConn.Size = new System.Drawing.Size(137, 32);
            this.btn_OpenConn.TabIndex = 3;
            this.btn_OpenConn.Text = "打开 网络连接";
            this.btn_OpenConn.UseVisualStyleBackColor = true;
            this.btn_OpenConn.Click += new System.EventHandler(this.btn_OpenConn_Click);
            // 
            // labIsDHCP
            // 
            this.labIsDHCP.AutoSize = true;
            this.labIsDHCP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labIsDHCP.ForeColor = System.Drawing.Color.Red;
            this.labIsDHCP.Location = new System.Drawing.Point(218, 104);
            this.labIsDHCP.Name = "labIsDHCP";
            this.labIsDHCP.Size = new System.Drawing.Size(53, 20);
            this.labIsDHCP.TabIndex = 10;
            this.labIsDHCP.Text = "DHCP";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(775, 263);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_StartDHCP
            // 
            this.btn_StartDHCP.Location = new System.Drawing.Point(521, 98);
            this.btn_StartDHCP.Name = "btn_StartDHCP";
            this.btn_StartDHCP.Size = new System.Drawing.Size(101, 34);
            this.btn_StartDHCP.TabIndex = 4;
            this.btn_StartDHCP.Text = "开启DHCP";
            this.btn_StartDHCP.UseVisualStyleBackColor = true;
            this.btn_StartDHCP.Click += new System.EventHandler(this.btn_StartDHCP_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(775, 325);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txt_Info
            // 
            this.txt_Info.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Info.Location = new System.Drawing.Point(347, 145);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.Size = new System.Drawing.Size(275, 190);
            this.txt_Info.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(775, 369);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chkBox_UpdateInfo
            // 
            this.chkBox_UpdateInfo.AutoSize = true;
            this.chkBox_UpdateInfo.Checked = true;
            this.chkBox_UpdateInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_UpdateInfo.Location = new System.Drawing.Point(29, 0);
            this.chkBox_UpdateInfo.Name = "chkBox_UpdateInfo";
            this.chkBox_UpdateInfo.Size = new System.Drawing.Size(300, 19);
            this.chkBox_UpdateInfo.TabIndex = 17;
            this.chkBox_UpdateInfo.Text = "是否自动刷新(焦点在输入框时自动暂停)";
            this.chkBox_UpdateInfo.UseVisualStyleBackColor = true;
            // 
            // timerUpdateInfo
            // 
            this.timerUpdateInfo.Enabled = true;
            this.timerUpdateInfo.Interval = 1500;
            this.timerUpdateInfo.Tick += new System.EventHandler(this.timerUpdateInfo_Tick);
            // 
            // txt_mac_speed
            // 
            this.txt_mac_speed.Location = new System.Drawing.Point(100, 49);
            this.txt_mac_speed.Name = "txt_mac_speed";
            this.txt_mac_speed.ReadOnly = true;
            this.txt_mac_speed.Size = new System.Drawing.Size(155, 25);
            this.txt_mac_speed.TabIndex = 20;
            // 
            // lab_OperationStatus
            // 
            this.lab_OperationStatus.AutoSize = true;
            this.lab_OperationStatus.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_OperationStatus.Location = new System.Drawing.Point(262, 53);
            this.lab_OperationStatus.Name = "lab_OperationStatus";
            this.lab_OperationStatus.Size = new System.Drawing.Size(29, 19);
            this.lab_OperationStatus.TabIndex = 21;
            this.lab_OperationStatus.Text = "UP";
            // 
            // btn_SetMaskLength
            // 
            this.btn_SetMaskLength.Location = new System.Drawing.Point(219, 153);
            this.btn_SetMaskLength.Name = "btn_SetMaskLength";
            this.btn_SetMaskLength.Size = new System.Drawing.Size(92, 23);
            this.btn_SetMaskLength.TabIndex = 22;
            this.btn_SetMaskLength.Text = "24位";
            this.btn_SetMaskLength.UseVisualStyleBackColor = true;
            this.btn_SetMaskLength.Click += new System.EventHandler(this.btn_SetMaskLength_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(775, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btn_SaveToxml
            // 
            this.btn_SaveToxml.Location = new System.Drawing.Point(216, 243);
            this.btn_SaveToxml.Name = "btn_SaveToxml";
            this.btn_SaveToxml.Size = new System.Drawing.Size(98, 25);
            this.btn_SaveToxml.TabIndex = 24;
            this.btn_SaveToxml.Text = "保存到xml";
            this.btn_SaveToxml.UseVisualStyleBackColor = true;
            this.btn_SaveToxml.Click += new System.EventHandler(this.btn_SaveToxml_Click);
            // 
            // btn_SetFromTxt
            // 
            this.btn_SetFromTxt.Location = new System.Drawing.Point(216, 193);
            this.btn_SetFromTxt.Name = "btn_SetFromTxt";
            this.btn_SetFromTxt.Size = new System.Drawing.Size(98, 23);
            this.btn_SetFromTxt.TabIndex = 25;
            this.btn_SetFromTxt.Text = "<-";
            this.btn_SetFromTxt.UseVisualStyleBackColor = true;
            this.btn_SetFromTxt.Click += new System.EventHandler(this.btn_SetFromTxt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 381);
            this.Controls.Add(this.btn_SetFromTxt);
            this.Controls.Add(this.btn_SaveToxml);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_SetMaskLength);
            this.Controls.Add(this.lab_OperationStatus);
            this.Controls.Add(this.txt_mac_speed);
            this.Controls.Add(this.chkBox_UpdateInfo);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_StartDHCP);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.labIsDHCP);
            this.Controls.Add(this.btn_OpenConn);
            this.Controls.Add(this.lab_speed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdaEdit);
            this.Controls.Add(this.labIPv6);
            this.Controls.Add(this.txtIPv6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDNS2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDNS1);
            this.Controls.Add(this.labGateway);
            this.Controls.Add(this.txtGateway);
            this.Controls.Add(this.labMaskLength);
            this.Controls.Add(this.labMask);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.labIP);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.cmb_AdaEdit);
            this.Controls.Add(this.combox_NetAdapters);
            this.Controls.Add(this.btn_SearchNetAdapters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "本地连接设置工具   --不优化版   by  yhc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SearchNetAdapters;
        private System.Windows.Forms.ComboBox combox_NetAdapters;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.Label labMask;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.Label labGateway;
        private System.Windows.Forms.TextBox txtDNS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNS2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPv6;
        private System.Windows.Forms.Label labIPv6;
        private System.Windows.Forms.Label labMaskLength;
        private System.Windows.Forms.Button btnAdaEdit;
        private System.Windows.Forms.ComboBox cmb_AdaEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lab_speed;
        private System.Windows.Forms.Button btn_OpenConn;
        private System.Windows.Forms.Label labIsDHCP;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_StartDHCP;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox chkBox_UpdateInfo;
        private System.Windows.Forms.Timer timerUpdateInfo;
        private System.Windows.Forms.TextBox txt_mac_speed;
        private System.Windows.Forms.Label lab_OperationStatus;
        private System.Windows.Forms.Button btn_SetMaskLength;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_SaveToxml;
        private System.Windows.Forms.Button btn_SetFromTxt;
    }
}

