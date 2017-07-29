namespace SKCOMTester
{
    partial class SKOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitialize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReadCert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetAccount = new System.Windows.Forms.Button();
            this.boxOSStockAccount = new System.Windows.Forms.ComboBox();
            this.lblOSStockAccount = new System.Windows.Forms.Label();
            this.boxOSFutureAccount = new System.Windows.Forms.ComboBox();
            this.lblOSFutureAccount = new System.Windows.Forms.Label();
            this.boxFutureAccount = new System.Windows.Forms.ComboBox();
            this.lblFutureAccount = new System.Windows.Forms.Label();
            this.boxStockAccount = new System.Windows.Forms.ComboBox();
            this.lblStockAccount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOrderUnlock = new System.Windows.Forms.Button();
            this.btnSetMaxCount = new System.Windows.Forms.Button();
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetMaxQty = new System.Windows.Forms.Button();
            this.txtMaxQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxOrderLimit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.listInformation = new System.Windows.Forms.ListBox();
            this.btnDownloadOS = new System.Windows.Forms.Button();
            this.btnDownloadOO = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stockOrderControl1 = new SKOrderTester.StockOrderControl();
            this.futureOrderControl1 = new SKOrderTester.FutureOrderControl();
            this.optionOrderControl1 = new SKOrderTester.OptionOrderControl();
            this.overseaFutureOrderControl1 = new SKOrderTester.OverseaFutureOrderControl();
            this.overseaOptionOrderControl1 = new SKOrderTester.OverseaOptionOrderControl();
            this.futureStopLossControl1 = new SKOrderTester.FutureStopLossControl();
            this.foreignStockOrderControl1 = new SKOrderTester.ForeignStockOrderControl();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInitialize.Location = new System.Drawing.Point(96, 9);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(4);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(117, 28);
            this.btnInitialize.TabIndex = 17;
            this.btnInitialize.Text = "Order Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "1.下單物件初始";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "2.讀取憑證";
            // 
            // btnReadCert
            // 
            this.btnReadCert.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReadCert.Location = new System.Drawing.Point(303, 9);
            this.btnReadCert.Name = "btnReadCert";
            this.btnReadCert.Size = new System.Drawing.Size(173, 28);
            this.btnReadCert.TabIndex = 32;
            this.btnReadCert.Text = "讀取憑證  ReadCertByID";
            this.btnReadCert.UseVisualStyleBackColor = true;
            this.btnReadCert.Click += new System.EventHandler(this.btnReadCert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "3.取得下單帳號";
            // 
            // btnGetAccount
            // 
            this.btnGetAccount.Location = new System.Drawing.Point(590, 10);
            this.btnGetAccount.Name = "btnGetAccount";
            this.btnGetAccount.Size = new System.Drawing.Size(135, 28);
            this.btnGetAccount.TabIndex = 34;
            this.btnGetAccount.Text = "GetAccount";
            this.btnGetAccount.UseVisualStyleBackColor = true;
            this.btnGetAccount.Click += new System.EventHandler(this.btnGetAccount_Click);
            // 
            // boxOSStockAccount
            // 
            this.boxOSStockAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxOSStockAccount.FormattingEnabled = true;
            this.boxOSStockAccount.Location = new System.Drawing.Point(664, 65);
            this.boxOSStockAccount.Name = "boxOSStockAccount";
            this.boxOSStockAccount.Size = new System.Drawing.Size(181, 20);
            this.boxOSStockAccount.TabIndex = 42;
            this.boxOSStockAccount.SelectedIndexChanged += new System.EventHandler(this.boxOSStockAccount_SelectedIndexChanged);
            // 
            // lblOSStockAccount
            // 
            this.lblOSStockAccount.AutoSize = true;
            this.lblOSStockAccount.Location = new System.Drawing.Point(717, 47);
            this.lblOSStockAccount.Name = "lblOSStockAccount";
            this.lblOSStockAccount.Size = new System.Drawing.Size(65, 12);
            this.lblOSStockAccount.TabIndex = 41;
            this.lblOSStockAccount.Text = "複委託帳號";
            // 
            // boxOSFutureAccount
            // 
            this.boxOSFutureAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxOSFutureAccount.FormattingEnabled = true;
            this.boxOSFutureAccount.Location = new System.Drawing.Point(438, 65);
            this.boxOSFutureAccount.Name = "boxOSFutureAccount";
            this.boxOSFutureAccount.Size = new System.Drawing.Size(190, 20);
            this.boxOSFutureAccount.TabIndex = 40;
            this.boxOSFutureAccount.SelectedIndexChanged += new System.EventHandler(this.boxOSFutureAccount_SelectedIndexChanged);
            // 
            // lblOSFutureAccount
            // 
            this.lblOSFutureAccount.AutoSize = true;
            this.lblOSFutureAccount.Location = new System.Drawing.Point(502, 47);
            this.lblOSFutureAccount.Name = "lblOSFutureAccount";
            this.lblOSFutureAccount.Size = new System.Drawing.Size(53, 12);
            this.lblOSFutureAccount.TabIndex = 39;
            this.lblOSFutureAccount.Text = "海期帳號";
            // 
            // boxFutureAccount
            // 
            this.boxFutureAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxFutureAccount.FormattingEnabled = true;
            this.boxFutureAccount.Location = new System.Drawing.Point(211, 65);
            this.boxFutureAccount.Name = "boxFutureAccount";
            this.boxFutureAccount.Size = new System.Drawing.Size(188, 20);
            this.boxFutureAccount.TabIndex = 38;
            this.boxFutureAccount.SelectedIndexChanged += new System.EventHandler(this.boxFutureAccount_SelectedIndexChanged);
            // 
            // lblFutureAccount
            // 
            this.lblFutureAccount.AutoSize = true;
            this.lblFutureAccount.Location = new System.Drawing.Point(281, 47);
            this.lblFutureAccount.Name = "lblFutureAccount";
            this.lblFutureAccount.Size = new System.Drawing.Size(53, 12);
            this.lblFutureAccount.TabIndex = 37;
            this.lblFutureAccount.Text = "期貨帳號";
            // 
            // boxStockAccount
            // 
            this.boxStockAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxStockAccount.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.boxStockAccount.FormattingEnabled = true;
            this.boxStockAccount.Location = new System.Drawing.Point(3, 65);
            this.boxStockAccount.Name = "boxStockAccount";
            this.boxStockAccount.Size = new System.Drawing.Size(166, 20);
            this.boxStockAccount.TabIndex = 36;
            this.boxStockAccount.SelectedIndexChanged += new System.EventHandler(this.boxStockAccount_SelectedIndexChanged);
            // 
            // lblStockAccount
            // 
            this.lblStockAccount.AutoSize = true;
            this.lblStockAccount.Location = new System.Drawing.Point(48, 47);
            this.lblStockAccount.Name = "lblStockAccount";
            this.lblStockAccount.Size = new System.Drawing.Size(53, 12);
            this.lblStockAccount.TabIndex = 35;
            this.lblStockAccount.Text = "證券帳號";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrderUnlock);
            this.groupBox1.Controls.Add(this.btnSetMaxCount);
            this.groupBox1.Controls.Add(this.txtMaxCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSetMaxQty);
            this.groupBox1.Controls.Add(this.txtMaxQty);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.boxOrderLimit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(9, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 45);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "每秒下單限制";
            // 
            // btnOrderUnlock
            // 
            this.btnOrderUnlock.Location = new System.Drawing.Point(685, 11);
            this.btnOrderUnlock.Name = "btnOrderUnlock";
            this.btnOrderUnlock.Size = new System.Drawing.Size(145, 28);
            this.btnOrderUnlock.TabIndex = 8;
            this.btnOrderUnlock.Text = "下單解鎖";
            this.btnOrderUnlock.UseVisualStyleBackColor = true;
            this.btnOrderUnlock.Click += new System.EventHandler(this.btnOrderUnlock_Click);
            // 
            // btnSetMaxCount
            // 
            this.btnSetMaxCount.Location = new System.Drawing.Point(500, 13);
            this.btnSetMaxCount.Name = "btnSetMaxCount";
            this.btnSetMaxCount.Size = new System.Drawing.Size(90, 23);
            this.btnSetMaxCount.TabIndex = 7;
            this.btnSetMaxCount.Text = "SetMaxCount";
            this.btnSetMaxCount.UseVisualStyleBackColor = true;
            this.btnSetMaxCount.Click += new System.EventHandler(this.btnSetMaxCount_Click);
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Location = new System.Drawing.Point(432, 13);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(63, 21);
            this.txtMaxCount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "筆數";
            // 
            // btnSetMaxQty
            // 
            this.btnSetMaxQty.Location = new System.Drawing.Point(290, 14);
            this.btnSetMaxQty.Name = "btnSetMaxQty";
            this.btnSetMaxQty.Size = new System.Drawing.Size(80, 23);
            this.btnSetMaxQty.TabIndex = 4;
            this.btnSetMaxQty.Text = "SetMaxQty";
            this.btnSetMaxQty.UseVisualStyleBackColor = true;
            this.btnSetMaxQty.Click += new System.EventHandler(this.btnSetMaxQty_Click);
            // 
            // txtMaxQty
            // 
            this.txtMaxQty.Location = new System.Drawing.Point(226, 15);
            this.txtMaxQty.Name = "txtMaxQty";
            this.txtMaxQty.Size = new System.Drawing.Size(59, 21);
            this.txtMaxQty.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "市埸別：";
            // 
            // boxOrderLimit
            // 
            this.boxOrderLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxOrderLimit.FormattingEnabled = true;
            this.boxOrderLimit.Items.AddRange(new object[] {
            "TS ( 證券 )",
            "TF ( 期貨 )",
            "TO ( 台選 )",
            "OS ( 複委託 )",
            "OF ( 海期 )",
            "OO ( 海選 )"});
            this.boxOrderLimit.Location = new System.Drawing.Point(67, 15);
            this.boxOrderLimit.Name = "boxOrderLimit";
            this.boxOrderLimit.Size = new System.Drawing.Size(94, 20);
            this.boxOrderLimit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "口數";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(13, 142);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 409);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.stockOrderControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(933, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "證券";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.futureOrderControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(933, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "期貨";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.optionOrderControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(933, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "選擇權";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.overseaFutureOrderControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(933, 383);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "海期";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.overseaOptionOrderControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(933, 383);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "海選";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.futureStopLossControl1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(933, 383);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "停損單";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.foreignStockOrderControl1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(933, 383);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "複委託";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // listInformation
            // 
            this.listInformation.FormattingEnabled = true;
            this.listInformation.HorizontalScrollbar = true;
            this.listInformation.ItemHeight = 12;
            this.listInformation.Location = new System.Drawing.Point(13, 557);
            this.listInformation.Name = "listInformation";
            this.listInformation.ScrollAlwaysVisible = true;
            this.listInformation.Size = new System.Drawing.Size(937, 124);
            this.listInformation.TabIndex = 45;
            // 
            // btnDownloadOS
            // 
            this.btnDownloadOS.Location = new System.Drawing.Point(21, 14);
            this.btnDownloadOS.Name = "btnDownloadOS";
            this.btnDownloadOS.Size = new System.Drawing.Size(107, 20);
            this.btnDownloadOS.TabIndex = 46;
            this.btnDownloadOS.Text = "下載海期商品檔";
            this.btnDownloadOS.UseVisualStyleBackColor = true;
            this.btnDownloadOS.Click += new System.EventHandler(this.btnDownloadOS_Click);
            // 
            // btnDownloadOO
            // 
            this.btnDownloadOO.Location = new System.Drawing.Point(145, 14);
            this.btnDownloadOO.Name = "btnDownloadOO";
            this.btnDownloadOO.Size = new System.Drawing.Size(102, 20);
            this.btnDownloadOO.TabIndex = 47;
            this.btnDownloadOO.Text = "下載海選商品檔";
            this.btnDownloadOO.UseVisualStyleBackColor = true;
            this.btnDownloadOO.Click += new System.EventHandler(this.btnDownloadOO_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownloadOO);
            this.groupBox2.Controls.Add(this.btnDownloadOS);
            this.groupBox2.Location = new System.Drawing.Point(731, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 41);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4.海期選下單設定";
            // 
            // stockOrderControl1
            // 
            this.stockOrderControl1.Location = new System.Drawing.Point(15, 6);
            this.stockOrderControl1.Name = "stockOrderControl1";
            this.stockOrderControl1.Size = new System.Drawing.Size(912, 325);
            this.stockOrderControl1.TabIndex = 0;
            this.stockOrderControl1.UserAccount = "";
            this.stockOrderControl1.UserID = "";
            this.stockOrderControl1.OnOrderSignal += new SKOrderTester.StockOrderControl.OrderHandler(this.stockOrderControl1_OnOrderSignal);
            this.stockOrderControl1.OnDecreaseOrderSignal += new SKOrderTester.StockOrderControl.DecreaseOrderHandler(this.stockOrderControl1_OnDecreaseOrderSignal);
            this.stockOrderControl1.OnCancelOrderSignal += new SKOrderTester.StockOrderControl.CancelOrderHandler(this.stockOrderControl1_OnCancelOrderSignal);
            this.stockOrderControl1.OnCancelOrderByStockSignal += new SKOrderTester.StockOrderControl.CancelOrderByStockHandler(this.stockOrderControl1_OnCancelOrderByStockSignal);
            this.stockOrderControl1.OnRealBalanceSignal += new SKOrderTester.StockOrderControl.RealBalanceHandler(this.stockOrderControl1_OnRealBalanceSignal);
            this.stockOrderControl1.OnRequestProfitReportSignal += new SKOrderTester.StockOrderControl.RequestProfitReportHandler(this.stockOrderControl1_OnRequestProfitReportSignal);
            // 
            // futureOrderControl1
            // 
            this.futureOrderControl1.Location = new System.Drawing.Point(6, 6);
            this.futureOrderControl1.Name = "futureOrderControl1";
            this.futureOrderControl1.Size = new System.Drawing.Size(905, 447);
            this.futureOrderControl1.TabIndex = 0;
            this.futureOrderControl1.UserAccount = "";
            this.futureOrderControl1.UserID = "";
            this.futureOrderControl1.OnFutureOrderSignal += new SKOrderTester.FutureOrderControl.OrderHandler(this.futureOrderControl1_OnFutureOrderSignal);
            this.futureOrderControl1.OnFutureOrderCLRSignal += new SKOrderTester.FutureOrderControl.OrderCLRHandler(this.futureOrderControl1_OnFutureOrderCLRSignal);
            this.futureOrderControl1.OnDecreaseOrderSignal += new SKOrderTester.FutureOrderControl.DecreaseOrderHandler(this.stockOrderControl1_OnDecreaseOrderSignal);
            this.futureOrderControl1.OnCancelOrderSignal += new SKOrderTester.FutureOrderControl.CancelOrderHandler(this.stockOrderControl1_OnCancelOrderSignal);
            this.futureOrderControl1.OnCancelOrderByStockSignal += new SKOrderTester.FutureOrderControl.CancelOrderByStockHandler(this.stockOrderControl1_OnCancelOrderByStockSignal);
            this.futureOrderControl1.OnCorrectPriceBySeqNo += new SKOrderTester.FutureOrderControl.CorrectPriceBySeqNoHandler(this.futureOrderControl1_OnCorrectPriceBySeqNo);
            this.futureOrderControl1.OnCorrectPriceByBookNo += new SKOrderTester.FutureOrderControl.CorrectPriceByBookNoHandler(this.futureOrderControl1_OnCorrectPriceByBookNo);
            this.futureOrderControl1.OnOpenInterestSignal += new SKOrderTester.FutureOrderControl.OpenInterestHandler(this.futureOrderControl1_OnOpenInterestSignal);
            this.futureOrderControl1.OnFutureRightsSignal += new SKOrderTester.FutureOrderControl.FutureRightsHandler(this.futureOrderControl1_OnFutureRightsSignal);
            // 
            // optionOrderControl1
            // 
            this.optionOrderControl1.Location = new System.Drawing.Point(14, 6);
            this.optionOrderControl1.Name = "optionOrderControl1";
            this.optionOrderControl1.Size = new System.Drawing.Size(897, 352);
            this.optionOrderControl1.TabIndex = 0;
            this.optionOrderControl1.UserAccount = "";
            this.optionOrderControl1.UserID = "";
            this.optionOrderControl1.OnOptionOrderSignal += new SKOrderTester.OptionOrderControl.OrderHandler(this.optionOrderControl1_OnOptionOrderSignal);
            // 
            // overseaFutureOrderControl1
            // 
            this.overseaFutureOrderControl1.Location = new System.Drawing.Point(11, 6);
            this.overseaFutureOrderControl1.Name = "overseaFutureOrderControl1";
            this.overseaFutureOrderControl1.Size = new System.Drawing.Size(900, 382);
            this.overseaFutureOrderControl1.TabIndex = 0;
            this.overseaFutureOrderControl1.UserAccount = "";
            this.overseaFutureOrderControl1.UserID = "";
            this.overseaFutureOrderControl1.OnOverseaFutureOrderSignal += new SKOrderTester.OverseaFutureOrderControl.OrderHandler(this.overseaFutureOrderControl1_OnOverseaFutureOrderSignal);
            this.overseaFutureOrderControl1.OnOverseaFutureOrderSpreadSignal += new SKOrderTester.OverseaFutureOrderControl.SpreadOrderHandler(this.overseaFutureOrderControl1_OnOverseaFutureOrderSpreadSignal);
            this.overseaFutureOrderControl1.OnDecreaseOrderSignal += new SKOrderTester.OverseaFutureOrderControl.DecreaseOrderHandler(this.overseaFutureOrderControl1_OnDecreaseOrderSignal);
            this.overseaFutureOrderControl1.OnOpenInterestSignal += new SKOrderTester.OverseaFutureOrderControl.OpenInterestHandler(this.overseaFutureOrderControl1_OnOpenInterestSignal);
            this.overseaFutureOrderControl1.OnOverseaFuturesSignal += new SKOrderTester.OverseaFutureOrderControl.OverseaFuturesHandler(this.overseaFutureOrderControl1_OnOverseaFuturesSignal);
            this.overseaFutureOrderControl1.OnCancelOrderSignal += new SKOrderTester.OverseaFutureOrderControl.CancelOrderHandler(this.overseaFutureOrderControl1_OnCancelOrderSignal);
            this.overseaFutureOrderControl1.OnCancelOrderByBookSignal += new SKOrderTester.OverseaFutureOrderControl.CancelOrderByBookHandler(this.overseaFutureOrderControl1_OnCancelOrderByBookSignal);
            // 
            // overseaOptionOrderControl1
            // 
            this.overseaOptionOrderControl1.Location = new System.Drawing.Point(9, 6);
            this.overseaOptionOrderControl1.Name = "overseaOptionOrderControl1";
            this.overseaOptionOrderControl1.Size = new System.Drawing.Size(902, 360);
            this.overseaOptionOrderControl1.TabIndex = 0;
            this.overseaOptionOrderControl1.UserAccount = "";
            this.overseaOptionOrderControl1.UserID = "";
            this.overseaOptionOrderControl1.OnOverseaOptionOrderSignal += new SKOrderTester.OverseaOptionOrderControl.OrderHandler(this.overseaOptionOrderControl1_OnOverseaOptionOrderSignal);
            this.overseaOptionOrderControl1.OnOnOverseaOptionSignal += new SKOrderTester.OverseaOptionOrderControl.GetOverseaOptions(this.overseaOptionOrderControl1_OnOnOverseaOptionSignal);
            // 
            // futureStopLossControl1
            // 
            this.futureStopLossControl1.Location = new System.Drawing.Point(13, 6);
            this.futureStopLossControl1.Name = "futureStopLossControl1";
            this.futureStopLossControl1.Size = new System.Drawing.Size(898, 392);
            this.futureStopLossControl1.TabIndex = 0;
            this.futureStopLossControl1.UserAccount = "";
            this.futureStopLossControl1.UserID = "";
            this.futureStopLossControl1.OnFutureStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.OrderHandler(this.futureStopLossControl1_OnFutureStopLossOrderSignal);
            this.futureStopLossControl1.OnMovingStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.MovingOrderHandler(this.futureStopLossControl1_OnMovingStopLossOrderSignal);
            this.futureStopLossControl1.OnOptionStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.OptionOrderHandler(this.futureStopLossControl1_OnOptionStopLossOrderSignal);
            this.futureStopLossControl1.OnCancelFutureStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.CancelFutrueOrderHandler(this.futureStopLossControl1_OnCancelFutureStopLossOrderSignal);
            this.futureStopLossControl1.OnCancelMovingStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.CancelMovingOrderHandler(this.futureStopLossControl1_OnCancelMovingStopLossOrderSignal);
            this.futureStopLossControl1.OnCancelOptionStopLossOrderSignal += new SKOrderTester.FutureStopLossControl.CancelOptionOrderHandler(this.futureStopLossControl1_OnCancelOptionStopLossOrderSignal);
            this.futureStopLossControl1.OnStopLossReportSignal += new SKOrderTester.FutureStopLossControl.StopLossReportHandler(this.futureStopLossControl1_OnStopLossReportSignal);
            // 
            // foreignStockOrderControl1
            // 
            this.foreignStockOrderControl1.Location = new System.Drawing.Point(6, 3);
            this.foreignStockOrderControl1.Name = "foreignStockOrderControl1";
            this.foreignStockOrderControl1.Size = new System.Drawing.Size(921, 237);
            this.foreignStockOrderControl1.TabIndex = 0;
            this.foreignStockOrderControl1.UserAccount = "";
            this.foreignStockOrderControl1.UserID = "";
            this.foreignStockOrderControl1.OnForeignOrderSignal += new SKOrderTester.ForeignStockOrderControl.ForeignOrderHandler(this.ForeignOrderControl1_OnForeignOrderSignal);
            this.foreignStockOrderControl1.OnCancelForeignOrderBySeqSignal += new SKOrderTester.ForeignStockOrderControl.CancelForeignOrderBySeqHandler(this.ForeignOrderControl1_OnCancelForeignOrderBySeqSignal);
            this.foreignStockOrderControl1.OnCancelForeignOrderByBookSignal += new SKOrderTester.ForeignStockOrderControl.CancelForeignOrderByBookHandler(this.ForeignOrderControl1_OnCancelForeignOrderByBookSignal);
            // 
            // SKOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listInformation);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.boxOSStockAccount);
            this.Controls.Add(this.lblOSStockAccount);
            this.Controls.Add(this.boxOSFutureAccount);
            this.Controls.Add(this.lblOSFutureAccount);
            this.Controls.Add(this.boxFutureAccount);
            this.Controls.Add(this.lblFutureAccount);
            this.Controls.Add(this.boxStockAccount);
            this.Controls.Add(this.lblStockAccount);
            this.Controls.Add(this.btnGetAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReadCert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInitialize);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "SKOrder";
            this.Size = new System.Drawing.Size(997, 689);
            this.Load += new System.EventHandler(this.SKOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReadCert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetAccount;
        private System.Windows.Forms.ComboBox boxOSStockAccount;
        private System.Windows.Forms.Label lblOSStockAccount;
        private System.Windows.Forms.ComboBox boxOSFutureAccount;
        private System.Windows.Forms.Label lblOSFutureAccount;
        private System.Windows.Forms.ComboBox boxFutureAccount;
        private System.Windows.Forms.Label lblFutureAccount;
        private System.Windows.Forms.ComboBox boxStockAccount;
        private System.Windows.Forms.Label lblStockAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOrderUnlock;
        private System.Windows.Forms.Button btnSetMaxCount;
        private System.Windows.Forms.TextBox txtMaxCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetMaxQty;
        private System.Windows.Forms.TextBox txtMaxQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox boxOrderLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private SKOrderTester.StockOrderControl stockOrderControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listInformation;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private SKOrderTester.FutureOrderControl futureOrderControl1;
        private SKOrderTester.OptionOrderControl optionOrderControl1;
        private SKOrderTester.OverseaFutureOrderControl overseaFutureOrderControl1;
        private SKOrderTester.OverseaOptionOrderControl overseaOptionOrderControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private SKOrderTester.FutureStopLossControl futureStopLossControl1;
        private System.Windows.Forms.Button btnDownloadOS;
        private System.Windows.Forms.Button btnDownloadOO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage8;
        private SKOrderTester.ForeignStockOrderControl foreignStockOrderControl1;
    }
}
