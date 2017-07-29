namespace SKCOMTester
{
    partial class SKOSQuote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnServerTime = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblPage = new System.Windows.Forms.Label();
            this.gridStocks = new System.Windows.Forms.DataGridView();
            this.btnQueryStocks = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStocks = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblBest5Ask = new System.Windows.Forms.Label();
            this.lblBest5Bid = new System.Windows.Forms.Label();
            this.btnGetBest5 = new System.Windows.Forms.Button();
            this.txtBestStockidx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblGetTick = new System.Windows.Forms.Label();
            this.btnGetTick = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTickPtr = new System.Windows.Forms.TextBox();
            this.txtTickStockidx = new System.Windows.Forms.TextBox();
            this.gridBest5Bid = new System.Windows.Forms.DataGridView();
            this.gridBest5Ask = new System.Windows.Forms.DataGridView();
            this.listTicks = new System.Windows.Forms.ListBox();
            this.btnTicks = new System.Windows.Forms.Button();
            this.txtTick = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnOverseaProducts2 = new System.Windows.Forms.Button();
            this.listOverseaProducts = new System.Windows.Forms.ListBox();
            this.btnOverseaProducts = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.boxKLineType = new System.Windows.Forms.ComboBox();
            this.listKLine = new System.Windows.Forms.ListBox();
            this.btnKLine = new System.Windows.Forms.Button();
            this.txtKLine = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSignal = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStocks)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBest5Bid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBest5Ask)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(40, 14);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(156, 66);
            this.btnInitialize.TabIndex = 40;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(482, 69);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(135, 35);
            this.btnServer.TabIndex = 39;
            this.btnServer.Text = "切換行情 Server\r\n( 執行後請重新連線 )";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnServerTime
            // 
            this.btnServerTime.Location = new System.Drawing.Point(724, 69);
            this.btnServerTime.Name = "btnServerTime";
            this.btnServerTime.Size = new System.Drawing.Size(135, 35);
            this.btnServerTime.TabIndex = 38;
            this.btnServerTime.Text = "ServerTime";
            this.btnServerTime.UseVisualStyleBackColor = true;
            this.btnServerTime.Click += new System.EventHandler(this.btnServerTime_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblServerTime);
            this.groupBox3.Location = new System.Drawing.Point(724, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 49);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Time";
            // 
            // lblServerTime
            // 
            this.lblServerTime.AutoSize = true;
            this.lblServerTime.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblServerTime.Location = new System.Drawing.Point(27, 18);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(83, 19);
            this.lblServerTime.TabIndex = 0;
            this.lblServerTime.Text = "--：--：--";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(40, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 294);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblPage);
            this.tabPage1.Controls.Add(this.gridStocks);
            this.tabPage1.Controls.Add(this.btnQueryStocks);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtStocks);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quote";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(69, 8);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(39, 12);
            this.lblPage.TabIndex = 13;
            this.lblPage.Text = "lblPage";
            // 
            // gridStocks
            // 
            this.gridStocks.AllowUserToAddRows = false;
            this.gridStocks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridStocks.Location = new System.Drawing.Point(6, 48);
            this.gridStocks.Name = "gridStocks";
            this.gridStocks.ReadOnly = true;
            this.gridStocks.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gridStocks.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridStocks.RowTemplate.Height = 24;
            this.gridStocks.Size = new System.Drawing.Size(841, 214);
            this.gridStocks.TabIndex = 12;
            this.gridStocks.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridStocks_CellPainting);
            // 
            // btnQueryStocks
            // 
            this.btnQueryStocks.Location = new System.Drawing.Point(358, 6);
            this.btnQueryStocks.Name = "btnQueryStocks";
            this.btnQueryStocks.Size = new System.Drawing.Size(133, 23);
            this.btnQueryStocks.TabIndex = 11;
            this.btnQueryStocks.Text = "查詢";
            this.btnQueryStocks.UseVisualStyleBackColor = true;
            this.btnQueryStocks.Click += new System.EventHandler(this.btnQueryStocks_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "格式 [ 交易代碼,商品報價代碼 ] ( 多筆以 井號{#}區隔 )";
            // 
            // txtStocks
            // 
            this.txtStocks.Location = new System.Drawing.Point(71, 23);
            this.txtStocks.Name = "txtStocks";
            this.txtStocks.Size = new System.Drawing.Size(243, 22);
            this.txtStocks.TabIndex = 9;
            this.txtStocks.Text = "CBT,ZB1609#HKF,HSI1609#CME,ES_1609";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.gridBest5Bid);
            this.tabPage2.Controls.Add(this.gridBest5Ask);
            this.tabPage2.Controls.Add(this.listTicks);
            this.tabPage2.Controls.Add(this.btnTicks);
            this.tabPage2.Controls.Add(this.txtTick);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ticks & Best5";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblBest5Ask);
            this.groupBox5.Controls.Add(this.lblBest5Bid);
            this.groupBox5.Controls.Add(this.btnGetBest5);
            this.groupBox5.Controls.Add(this.txtBestStockidx);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(611, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 119);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GetBest5";
            // 
            // lblBest5Ask
            // 
            this.lblBest5Ask.AutoSize = true;
            this.lblBest5Ask.Location = new System.Drawing.Point(15, 91);
            this.lblBest5Ask.Name = "lblBest5Ask";
            this.lblBest5Ask.Size = new System.Drawing.Size(33, 12);
            this.lblBest5Ask.TabIndex = 7;
            this.lblBest5Ask.Text = "label5";
            // 
            // lblBest5Bid
            // 
            this.lblBest5Bid.AutoSize = true;
            this.lblBest5Bid.Location = new System.Drawing.Point(15, 66);
            this.lblBest5Bid.Name = "lblBest5Bid";
            this.lblBest5Bid.Size = new System.Drawing.Size(33, 12);
            this.lblBest5Bid.TabIndex = 6;
            this.lblBest5Bid.Text = "label5";
            // 
            // btnGetBest5
            // 
            this.btnGetBest5.Location = new System.Drawing.Point(155, 17);
            this.btnGetBest5.Name = "btnGetBest5";
            this.btnGetBest5.Size = new System.Drawing.Size(75, 23);
            this.btnGetBest5.TabIndex = 5;
            this.btnGetBest5.Text = "GetBest5";
            this.btnGetBest5.UseVisualStyleBackColor = true;
            this.btnGetBest5.Click += new System.EventHandler(this.btnGetBest5_Click);
            // 
            // txtBestStockidx
            // 
            this.txtBestStockidx.Location = new System.Drawing.Point(67, 18);
            this.txtBestStockidx.Name = "txtBestStockidx";
            this.txtBestStockidx.Size = new System.Drawing.Size(67, 22);
            this.txtBestStockidx.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stockidx";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblGetTick);
            this.groupBox4.Controls.Add(this.btnGetTick);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtTickPtr);
            this.groupBox4.Controls.Add(this.txtTickStockidx);
            this.groupBox4.Location = new System.Drawing.Point(611, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 88);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GetTick";
            // 
            // lblGetTick
            // 
            this.lblGetTick.AutoSize = true;
            this.lblGetTick.Location = new System.Drawing.Point(94, 55);
            this.lblGetTick.Name = "lblGetTick";
            this.lblGetTick.Size = new System.Drawing.Size(33, 12);
            this.lblGetTick.TabIndex = 4;
            this.lblGetTick.Text = "label4";
            // 
            // btnGetTick
            // 
            this.btnGetTick.Location = new System.Drawing.Point(6, 50);
            this.btnGetTick.Name = "btnGetTick";
            this.btnGetTick.Size = new System.Drawing.Size(75, 23);
            this.btnGetTick.TabIndex = 3;
            this.btnGetTick.Text = "GetTick";
            this.btnGetTick.UseVisualStyleBackColor = true;
            this.btnGetTick.Click += new System.EventHandler(this.btnGetTick_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stockidx/nPtr";
            // 
            // txtTickPtr
            // 
            this.txtTickPtr.Location = new System.Drawing.Point(162, 14);
            this.txtTickPtr.Name = "txtTickPtr";
            this.txtTickPtr.Size = new System.Drawing.Size(68, 22);
            this.txtTickPtr.TabIndex = 1;
            // 
            // txtTickStockidx
            // 
            this.txtTickStockidx.Location = new System.Drawing.Point(79, 14);
            this.txtTickStockidx.Name = "txtTickStockidx";
            this.txtTickStockidx.Size = new System.Drawing.Size(67, 22);
            this.txtTickStockidx.TabIndex = 0;
            // 
            // gridBest5Bid
            // 
            this.gridBest5Bid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBest5Bid.Location = new System.Drawing.Point(470, 49);
            this.gridBest5Bid.MultiSelect = false;
            this.gridBest5Bid.Name = "gridBest5Bid";
            this.gridBest5Bid.ReadOnly = true;
            this.gridBest5Bid.RowHeadersVisible = false;
            this.gridBest5Bid.RowTemplate.Height = 24;
            this.gridBest5Bid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridBest5Bid.Size = new System.Drawing.Size(131, 172);
            this.gridBest5Bid.TabIndex = 11;
            // 
            // gridBest5Ask
            // 
            this.gridBest5Ask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBest5Ask.Location = new System.Drawing.Point(333, 49);
            this.gridBest5Ask.MultiSelect = false;
            this.gridBest5Ask.Name = "gridBest5Ask";
            this.gridBest5Ask.ReadOnly = true;
            this.gridBest5Ask.RowHeadersVisible = false;
            this.gridBest5Ask.RowTemplate.Height = 24;
            this.gridBest5Ask.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridBest5Ask.Size = new System.Drawing.Size(131, 172);
            this.gridBest5Ask.TabIndex = 10;
            // 
            // listTicks
            // 
            this.listTicks.Font = new System.Drawing.Font("PMingLiU", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listTicks.FormattingEnabled = true;
            this.listTicks.ItemHeight = 17;
            this.listTicks.Location = new System.Drawing.Point(8, 49);
            this.listTicks.Name = "listTicks";
            this.listTicks.Size = new System.Drawing.Size(319, 174);
            this.listTicks.TabIndex = 2;
            // 
            // btnTicks
            // 
            this.btnTicks.Location = new System.Drawing.Point(126, 10);
            this.btnTicks.Name = "btnTicks";
            this.btnTicks.Size = new System.Drawing.Size(94, 33);
            this.btnTicks.TabIndex = 1;
            this.btnTicks.Text = "Request Tick";
            this.btnTicks.UseVisualStyleBackColor = true;
            this.btnTicks.Click += new System.EventHandler(this.btnTicks_Click);
            // 
            // txtTick
            // 
            this.txtTick.Location = new System.Drawing.Point(7, 17);
            this.txtTick.Name = "txtTick";
            this.txtTick.Size = new System.Drawing.Size(113, 22);
            this.txtTick.TabIndex = 0;
            this.txtTick.Text = "CME,ES_1403";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnOverseaProducts2);
            this.tabPage3.Controls.Add(this.listOverseaProducts);
            this.tabPage3.Controls.Add(this.btnOverseaProducts);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(855, 268);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Products";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnOverseaProducts2
            // 
            this.btnOverseaProducts2.Location = new System.Drawing.Point(218, 21);
            this.btnOverseaProducts2.Name = "btnOverseaProducts2";
            this.btnOverseaProducts2.Size = new System.Drawing.Size(223, 43);
            this.btnOverseaProducts2.TabIndex = 4;
            this.btnOverseaProducts2.Text = "GetOverseaProductsDetail";
            this.btnOverseaProducts2.UseVisualStyleBackColor = true;
            this.btnOverseaProducts2.Click += new System.EventHandler(this.btnOverseaProducts2_Click);
            // 
            // listOverseaProducts
            // 
            this.listOverseaProducts.Font = new System.Drawing.Font("PMingLiU", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listOverseaProducts.FormattingEnabled = true;
            this.listOverseaProducts.ItemHeight = 17;
            this.listOverseaProducts.Location = new System.Drawing.Point(63, 70);
            this.listOverseaProducts.Name = "listOverseaProducts";
            this.listOverseaProducts.Size = new System.Drawing.Size(717, 174);
            this.listOverseaProducts.TabIndex = 3;
            // 
            // btnOverseaProducts
            // 
            this.btnOverseaProducts.Location = new System.Drawing.Point(63, 21);
            this.btnOverseaProducts.Name = "btnOverseaProducts";
            this.btnOverseaProducts.Size = new System.Drawing.Size(117, 43);
            this.btnOverseaProducts.TabIndex = 2;
            this.btnOverseaProducts.Text = "GetOverseaProducts";
            this.btnOverseaProducts.UseVisualStyleBackColor = true;
            this.btnOverseaProducts.Click += new System.EventHandler(this.btnOverseaProducts_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.boxKLineType);
            this.tabPage4.Controls.Add(this.listKLine);
            this.tabPage4.Controls.Add(this.btnKLine);
            this.tabPage4.Controls.Add(this.txtKLine);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(855, 268);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "KLine Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // boxKLineType
            // 
            this.boxKLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxKLineType.FormattingEnabled = true;
            this.boxKLineType.Items.AddRange(new object[] {
            "分鐘線",
            "日線",
            "週線",
            "月線"});
            this.boxKLineType.Location = new System.Drawing.Point(303, 26);
            this.boxKLineType.Name = "boxKLineType";
            this.boxKLineType.Size = new System.Drawing.Size(121, 20);
            this.boxKLineType.TabIndex = 14;
            // 
            // listKLine
            // 
            this.listKLine.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listKLine.FormattingEnabled = true;
            this.listKLine.ItemHeight = 15;
            this.listKLine.Location = new System.Drawing.Point(37, 61);
            this.listKLine.Name = "listKLine";
            this.listKLine.Size = new System.Drawing.Size(768, 169);
            this.listKLine.TabIndex = 13;
            // 
            // btnKLine
            // 
            this.btnKLine.Location = new System.Drawing.Point(458, 15);
            this.btnKLine.Name = "btnKLine";
            this.btnKLine.Size = new System.Drawing.Size(171, 40);
            this.btnKLine.TabIndex = 12;
            this.btnKLine.Text = "RequestLKine";
            this.btnKLine.UseVisualStyleBackColor = true;
            this.btnKLine.Click += new System.EventHandler(this.btnKLine_Click);
            // 
            // txtKLine
            // 
            this.txtKLine.Location = new System.Drawing.Point(179, 26);
            this.txtKLine.Name = "txtKLine";
            this.txtKLine.Size = new System.Drawing.Size(100, 22);
            this.txtKLine.TabIndex = 11;
            this.txtKLine.Text = "CME,ES_1403";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSignal);
            this.groupBox1.Location = new System.Drawing.Point(517, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(65, 54);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server 1";
            // 
            // lblSignal
            // 
            this.lblSignal.AutoSize = true;
            this.lblSignal.Font = new System.Drawing.Font("PMingLiU", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSignal.ForeColor = System.Drawing.Color.Red;
            this.lblSignal.Location = new System.Drawing.Point(15, 21);
            this.lblSignal.Name = "lblSignal";
            this.lblSignal.Size = new System.Drawing.Size(32, 22);
            this.lblSignal.TabIndex = 0;
            this.lblSignal.Text = "●";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(385, 24);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 32);
            this.btnDisconnect.TabIndex = 34;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 32);
            this.button1.TabIndex = 33;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SKOSQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.btnServerTime);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.button1);
            this.Name = "SKOSQuote";
            this.Size = new System.Drawing.Size(946, 418);
            this.Load += new System.EventHandler(this.SKOSQuote_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStocks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBest5Bid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBest5Ask)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnServerTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.DataGridView gridStocks;
        private System.Windows.Forms.Button btnQueryStocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStocks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblBest5Ask;
        private System.Windows.Forms.Label lblBest5Bid;
        private System.Windows.Forms.Button btnGetBest5;
        private System.Windows.Forms.TextBox txtBestStockidx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblGetTick;
        private System.Windows.Forms.Button btnGetTick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTickPtr;
        private System.Windows.Forms.TextBox txtTickStockidx;
        private System.Windows.Forms.DataGridView gridBest5Bid;
        private System.Windows.Forms.DataGridView gridBest5Ask;
        private System.Windows.Forms.ListBox listTicks;
        private System.Windows.Forms.Button btnTicks;
        private System.Windows.Forms.TextBox txtTick;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listOverseaProducts;
        private System.Windows.Forms.Button btnOverseaProducts;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox boxKLineType;
        private System.Windows.Forms.ListBox listKLine;
        private System.Windows.Forms.Button btnKLine;
        private System.Windows.Forms.TextBox txtKLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSignal;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOverseaProducts2;
    }
}
