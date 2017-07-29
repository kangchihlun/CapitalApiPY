namespace SKOrderTester
{
    partial class FutureOrderControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxReserved = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSendFutureOrderCLRAsync = new System.Windows.Forms.Button();
            this.btnSendFutureOrderCLR = new System.Windows.Forms.Button();
            this.boxNewClose = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSendFutureOrderAsync = new System.Windows.Forms.Button();
            this.btnSendFutureOrder = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.boxFlag = new System.Windows.Forms.ComboBox();
            this.boxPeriod = new System.Windows.Forms.ComboBox();
            this.boxBidAsk = new System.Windows.Forms.ComboBox();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDecreaseQty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDecreaseQty = new System.Windows.Forms.Button();
            this.txtDecreaseSeqNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelOrderBySeqNo = new System.Windows.Forms.Button();
            this.txtCancelSeqNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCancelStockNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.boxCorrectSymbol = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCorrectPriceByBookNo = new System.Windows.Forms.Button();
            this.txtCorrectBookNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCorrectPriceBySeqNo = new System.Windows.Forms.Button();
            this.boxCorrectTradeType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCorrectPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCorrectSeqNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetOpenInterest = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comBox_CoinType = new System.Windows.Forms.ComboBox();
            this.btnGetFutureRights = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxReserved);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnSendFutureOrderCLRAsync);
            this.groupBox1.Controls.Add(this.btnSendFutureOrderCLR);
            this.groupBox1.Controls.Add(this.boxNewClose);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnSendFutureOrderAsync);
            this.groupBox1.Controls.Add(this.btnSendFutureOrder);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.boxFlag);
            this.groupBox1.Controls.Add(this.boxPeriod);
            this.groupBox1.Controls.Add(this.boxBidAsk);
            this.groupBox1.Controls.Add(this.txtStockNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "期貨委託";
            // 
            // boxReserved
            // 
            this.boxReserved.FormattingEnabled = true;
            this.boxReserved.Items.AddRange(new object[] {
            "盤中",
            "T盤預約"});
            this.boxReserved.Location = new System.Drawing.Point(427, 98);
            this.boxReserved.Name = "boxReserved";
            this.boxReserved.Size = new System.Drawing.Size(88, 20);
            this.boxReserved.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(425, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 18;
            this.label18.Text = "盤別";
            // 
            // btnSendFutureOrderCLRAsync
            // 
            this.btnSendFutureOrderCLRAsync.Location = new System.Drawing.Point(531, 101);
            this.btnSendFutureOrderCLRAsync.Name = "btnSendFutureOrderCLRAsync";
            this.btnSendFutureOrderCLRAsync.Size = new System.Drawing.Size(178, 23);
            this.btnSendFutureOrderCLRAsync.TabIndex = 17;
            this.btnSendFutureOrderCLRAsync.Text = "SendFutureOrderCLRAsync";
            this.btnSendFutureOrderCLRAsync.UseVisualStyleBackColor = true;
            this.btnSendFutureOrderCLRAsync.Click += new System.EventHandler(this.btnSendFutureOrderCLRAsync_Click);
            // 
            // btnSendFutureOrderCLR
            // 
            this.btnSendFutureOrderCLR.Location = new System.Drawing.Point(531, 72);
            this.btnSendFutureOrderCLR.Name = "btnSendFutureOrderCLR";
            this.btnSendFutureOrderCLR.Size = new System.Drawing.Size(178, 23);
            this.btnSendFutureOrderCLR.TabIndex = 16;
            this.btnSendFutureOrderCLR.Text = "SendFutureOrderCLR";
            this.btnSendFutureOrderCLR.UseVisualStyleBackColor = true;
            this.btnSendFutureOrderCLR.Click += new System.EventHandler(this.btnSendFutureOrderCLR_Click);
            // 
            // boxNewClose
            // 
            this.boxNewClose.FormattingEnabled = true;
            this.boxNewClose.Items.AddRange(new object[] {
            "新倉",
            "平倉",
            "自動"});
            this.boxNewClose.Location = new System.Drawing.Point(335, 98);
            this.boxNewClose.Name = "boxNewClose";
            this.boxNewClose.Size = new System.Drawing.Size(50, 20);
            this.boxNewClose.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(333, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "倉別";
            // 
            // btnSendFutureOrderAsync
            // 
            this.btnSendFutureOrderAsync.Location = new System.Drawing.Point(531, 42);
            this.btnSendFutureOrderAsync.Name = "btnSendFutureOrderAsync";
            this.btnSendFutureOrderAsync.Size = new System.Drawing.Size(178, 23);
            this.btnSendFutureOrderAsync.TabIndex = 13;
            this.btnSendFutureOrderAsync.Text = "SendFutureOrderAsync";
            this.btnSendFutureOrderAsync.UseVisualStyleBackColor = true;
            this.btnSendFutureOrderAsync.Click += new System.EventHandler(this.btnSendFutureOrderAsync_Click);
            // 
            // btnSendFutureOrder
            // 
            this.btnSendFutureOrder.Location = new System.Drawing.Point(531, 13);
            this.btnSendFutureOrder.Name = "btnSendFutureOrder";
            this.btnSendFutureOrder.Size = new System.Drawing.Size(178, 23);
            this.btnSendFutureOrder.TabIndex = 12;
            this.btnSendFutureOrder.Text = "SendFutureOrder";
            this.btnSendFutureOrder.UseVisualStyleBackColor = true;
            this.btnSendFutureOrder.Click += new System.EventHandler(this.btnSendFutureOrder_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(427, 42);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 22);
            this.txtQty.TabIndex = 11;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(335, 42);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(74, 22);
            this.txtPrice.TabIndex = 10;
            // 
            // boxFlag
            // 
            this.boxFlag.FormattingEnabled = true;
            this.boxFlag.Items.AddRange(new object[] {
            "非當沖",
            "當沖"});
            this.boxFlag.Location = new System.Drawing.Point(247, 42);
            this.boxFlag.Name = "boxFlag";
            this.boxFlag.Size = new System.Drawing.Size(68, 20);
            this.boxFlag.TabIndex = 9;
            // 
            // boxPeriod
            // 
            this.boxPeriod.FormattingEnabled = true;
            this.boxPeriod.Items.AddRange(new object[] {
            "ROD",
            "IOC",
            "FOK"});
            this.boxPeriod.Location = new System.Drawing.Point(173, 42);
            this.boxPeriod.Name = "boxPeriod";
            this.boxPeriod.Size = new System.Drawing.Size(64, 20);
            this.boxPeriod.TabIndex = 8;
            // 
            // boxBidAsk
            // 
            this.boxBidAsk.FormattingEnabled = true;
            this.boxBidAsk.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.boxBidAsk.Location = new System.Drawing.Point(105, 42);
            this.boxBidAsk.Name = "boxBidAsk";
            this.boxBidAsk.Size = new System.Drawing.Size(49, 20);
            this.boxBidAsk.TabIndex = 7;
            // 
            // txtStockNo
            // 
            this.txtStockNo.Location = new System.Drawing.Point(19, 42);
            this.txtStockNo.MaxLength = 15;
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(64, 22);
            this.txtStockNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "委託量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "委託價";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "當沖與否";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "委託條件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "買賣別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品代碼";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDecreaseQty);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnDecreaseQty);
            this.groupBox4.Controls.Add(this.txtDecreaseSeqNo);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(3, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(800, 54);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "委託減量";
            // 
            // txtDecreaseQty
            // 
            this.txtDecreaseQty.Location = new System.Drawing.Point(399, 18);
            this.txtDecreaseQty.Name = "txtDecreaseQty";
            this.txtDecreaseQty.Size = new System.Drawing.Size(72, 22);
            this.txtDecreaseQty.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = " 輸入欲減少的數量";
            // 
            // btnDecreaseQty
            // 
            this.btnDecreaseQty.Location = new System.Drawing.Point(582, 18);
            this.btnDecreaseQty.Name = "btnDecreaseQty";
            this.btnDecreaseQty.Size = new System.Drawing.Size(190, 23);
            this.btnDecreaseQty.TabIndex = 11;
            this.btnDecreaseQty.Text = "Decrease Order By SeqNo";
            this.btnDecreaseQty.UseVisualStyleBackColor = true;
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);
            // 
            // txtDecreaseSeqNo
            // 
            this.txtDecreaseSeqNo.Location = new System.Drawing.Point(103, 18);
            this.txtDecreaseSeqNo.Name = "txtDecreaseSeqNo";
            this.txtDecreaseSeqNo.Size = new System.Drawing.Size(136, 22);
            this.txtDecreaseSeqNo.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "委託序號";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelOrderBySeqNo);
            this.groupBox2.Controls.Add(this.txtCancelSeqNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnCancelOrder);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCancelStockNo);
            this.groupBox2.Location = new System.Drawing.Point(5, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "取消委託";
            // 
            // btnCancelOrderBySeqNo
            // 
            this.btnCancelOrderBySeqNo.Location = new System.Drawing.Point(245, 48);
            this.btnCancelOrderBySeqNo.Name = "btnCancelOrderBySeqNo";
            this.btnCancelOrderBySeqNo.Size = new System.Drawing.Size(178, 23);
            this.btnCancelOrderBySeqNo.TabIndex = 5;
            this.btnCancelOrderBySeqNo.Text = "Cancel Order By SeqNo";
            this.btnCancelOrderBySeqNo.UseVisualStyleBackColor = true;
            this.btnCancelOrderBySeqNo.Click += new System.EventHandler(this.btnCancelOrderBySeqNo_Click);
            // 
            // txtCancelSeqNo
            // 
            this.txtCancelSeqNo.Location = new System.Drawing.Point(103, 51);
            this.txtCancelSeqNo.Name = "txtCancelSeqNo";
            this.txtCancelSeqNo.Size = new System.Drawing.Size(136, 22);
            this.txtCancelSeqNo.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "委託序號";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(245, 19);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(178, 23);
            this.btnCancelOrder.TabIndex = 2;
            this.btnCancelOrder.Text = "Cancel Order By StockNo";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "商品代碼";
            // 
            // txtCancelStockNo
            // 
            this.txtCancelStockNo.Location = new System.Drawing.Point(103, 20);
            this.txtCancelStockNo.Name = "txtCancelStockNo";
            this.txtCancelStockNo.Size = new System.Drawing.Size(136, 22);
            this.txtCancelStockNo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.boxCorrectSymbol);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.btnCorrectPriceByBookNo);
            this.groupBox3.Controls.Add(this.txtCorrectBookNo);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.btnCorrectPriceBySeqNo);
            this.groupBox3.Controls.Add(this.boxCorrectTradeType);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtCorrectPrice);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCorrectSeqNo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(5, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(798, 94);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "改價";
            // 
            // boxCorrectSymbol
            // 
            this.boxCorrectSymbol.FormattingEnabled = true;
            this.boxCorrectSymbol.Items.AddRange(new object[] {
            "TF",
            "TO"});
            this.boxCorrectSymbol.Location = new System.Drawing.Point(255, 66);
            this.boxCorrectSymbol.Name = "boxCorrectSymbol";
            this.boxCorrectSymbol.Size = new System.Drawing.Size(69, 20);
            this.boxCorrectSymbol.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(196, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 25;
            this.label16.Text = "市場簡稱";
            // 
            // btnCorrectPriceByBookNo
            // 
            this.btnCorrectPriceByBookNo.Location = new System.Drawing.Point(602, 61);
            this.btnCorrectPriceByBookNo.Name = "btnCorrectPriceByBookNo";
            this.btnCorrectPriceByBookNo.Size = new System.Drawing.Size(190, 27);
            this.btnCorrectPriceByBookNo.TabIndex = 24;
            this.btnCorrectPriceByBookNo.Text = "CorrectPriceByBookNo";
            this.btnCorrectPriceByBookNo.UseVisualStyleBackColor = true;
            this.btnCorrectPriceByBookNo.Click += new System.EventHandler(this.btnCorrectPriceByBookNo_Click);
            // 
            // txtCorrectBookNo
            // 
            this.txtCorrectBookNo.Location = new System.Drawing.Point(101, 66);
            this.txtCorrectBookNo.Name = "txtCorrectBookNo";
            this.txtCorrectBookNo.Size = new System.Drawing.Size(89, 22);
            this.txtCorrectBookNo.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 23;
            this.label15.Text = "委託書號";
            // 
            // btnCorrectPriceBySeqNo
            // 
            this.btnCorrectPriceBySeqNo.Location = new System.Drawing.Point(602, 16);
            this.btnCorrectPriceBySeqNo.Name = "btnCorrectPriceBySeqNo";
            this.btnCorrectPriceBySeqNo.Size = new System.Drawing.Size(190, 27);
            this.btnCorrectPriceBySeqNo.TabIndex = 21;
            this.btnCorrectPriceBySeqNo.Text = "CorrectPriceBySeqNo";
            this.btnCorrectPriceBySeqNo.UseVisualStyleBackColor = true;
            this.btnCorrectPriceBySeqNo.Click += new System.EventHandler(this.btnCorrectPriceBySeqNo_Click);
            // 
            // boxCorrectTradeType
            // 
            this.boxCorrectTradeType.FormattingEnabled = true;
            this.boxCorrectTradeType.Items.AddRange(new object[] {
            "ROD",
            "IOC",
            "FOK"});
            this.boxCorrectTradeType.Location = new System.Drawing.Point(529, 43);
            this.boxCorrectTradeType.Name = "boxCorrectTradeType";
            this.boxCorrectTradeType.Size = new System.Drawing.Size(64, 20);
            this.boxCorrectTradeType.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(470, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "委託條件";
            // 
            // txtCorrectPrice
            // 
            this.txtCorrectPrice.Location = new System.Drawing.Point(390, 43);
            this.txtCorrectPrice.Name = "txtCorrectPrice";
            this.txtCorrectPrice.Size = new System.Drawing.Size(74, 22);
            this.txtCorrectPrice.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "修改價格";
            // 
            // txtCorrectSeqNo
            // 
            this.txtCorrectSeqNo.Location = new System.Drawing.Point(101, 21);
            this.txtCorrectSeqNo.Name = "txtCorrectSeqNo";
            this.txtCorrectSeqNo.Size = new System.Drawing.Size(136, 22);
            this.txtCorrectSeqNo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "委託序號";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnGetOpenInterest);
            this.groupBox5.Location = new System.Drawing.Point(5, 379);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(237, 49);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "未平倉";
            // 
            // btnGetOpenInterest
            // 
            this.btnGetOpenInterest.Location = new System.Drawing.Point(47, 14);
            this.btnGetOpenInterest.Name = "btnGetOpenInterest";
            this.btnGetOpenInterest.Size = new System.Drawing.Size(175, 29);
            this.btnGetOpenInterest.TabIndex = 10;
            this.btnGetOpenInterest.Text = "GetOpenInterest";
            this.btnGetOpenInterest.UseVisualStyleBackColor = true;
            this.btnGetOpenInterest.Click += new System.EventHandler(this.btnGetOpenInterest_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.comBox_CoinType);
            this.groupBox6.Controls.Add(this.btnGetFutureRights);
            this.groupBox6.Location = new System.Drawing.Point(267, 379);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(399, 49);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "權益數";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "幣別";
            // 
            // comBox_CoinType
            // 
            this.comBox_CoinType.FormattingEnabled = true;
            this.comBox_CoinType.Items.AddRange(new object[] {
            "TWD",
            "RMB"});
            this.comBox_CoinType.Location = new System.Drawing.Point(111, 19);
            this.comBox_CoinType.Name = "comBox_CoinType";
            this.comBox_CoinType.Size = new System.Drawing.Size(64, 20);
            this.comBox_CoinType.TabIndex = 21;
            // 
            // btnGetFutureRights
            // 
            this.btnGetFutureRights.Location = new System.Drawing.Point(218, 14);
            this.btnGetFutureRights.Name = "btnGetFutureRights";
            this.btnGetFutureRights.Size = new System.Drawing.Size(175, 29);
            this.btnGetFutureRights.TabIndex = 10;
            this.btnGetFutureRights.Text = "GetFutureRights";
            this.btnGetFutureRights.UseVisualStyleBackColor = true;
            this.btnGetFutureRights.Click += new System.EventHandler(this.btnGetFutureRights_Click);
            // 
            // FutureOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FutureOrderControl";
            this.Size = new System.Drawing.Size(811, 440);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendFutureOrderAsync;
        private System.Windows.Forms.Button btnSendFutureOrder;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox boxFlag;
        private System.Windows.Forms.ComboBox boxPeriod;
        private System.Windows.Forms.ComboBox boxBidAsk;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDecreaseQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDecreaseQty;
        private System.Windows.Forms.TextBox txtDecreaseSeqNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelOrderBySeqNo;
        private System.Windows.Forms.TextBox txtCancelSeqNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCancelStockNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox boxCorrectTradeType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCorrectPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCorrectSeqNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCorrectPriceBySeqNo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnGetOpenInterest;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnGetFutureRights;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comBox_CoinType;
        private System.Windows.Forms.Button btnCorrectPriceByBookNo;
        private System.Windows.Forms.TextBox txtCorrectBookNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox boxCorrectSymbol;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox boxNewClose;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSendFutureOrderCLRAsync;
        private System.Windows.Forms.Button btnSendFutureOrderCLR;
        private System.Windows.Forms.ComboBox boxReserved;
        private System.Windows.Forms.Label label18;
    }
}
