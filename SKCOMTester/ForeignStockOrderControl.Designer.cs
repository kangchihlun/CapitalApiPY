namespace SKOrderTester
{
    partial class ForeignStockOrderControl
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
            this.btnSendForeignStockOrderAsync = new System.Windows.Forms.Button();
            this.btnSendForeignStockOrder = new System.Windows.Forms.Button();
            this.boxBidAsk = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxExchange = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boxCurrency3 = new System.Windows.Forms.ComboBox();
            this.boxCurrency2 = new System.Windows.Forms.ComboBox();
            this.boxCurrency1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxAccountType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelForeignOrderByBookNo = new System.Windows.Forms.Button();
            this.btnCancelForeignOrderBySeqNo = new System.Windows.Forms.Button();
            this.txtCancelBookNo = new System.Windows.Forms.TextBox();
            this.txtCancelSeqNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.boxCancelExchange = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendForeignStockOrderAsync);
            this.groupBox1.Controls.Add(this.btnSendForeignStockOrder);
            this.groupBox1.Controls.Add(this.boxBidAsk);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtStockNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.boxExchange);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.boxCurrency3);
            this.groupBox1.Controls.Add(this.boxCurrency2);
            this.groupBox1.Controls.Add(this.boxCurrency1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxAccountType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "複委託";
            // 
            // btnSendForeignStockOrderAsync
            // 
            this.btnSendForeignStockOrderAsync.Location = new System.Drawing.Point(535, 69);
            this.btnSendForeignStockOrderAsync.Name = "btnSendForeignStockOrderAsync";
            this.btnSendForeignStockOrderAsync.Size = new System.Drawing.Size(177, 23);
            this.btnSendForeignStockOrderAsync.TabIndex = 20;
            this.btnSendForeignStockOrderAsync.Text = "SendForeignStockOrderAsync";
            this.btnSendForeignStockOrderAsync.UseVisualStyleBackColor = true;
            this.btnSendForeignStockOrderAsync.Click += new System.EventHandler(this.btnSendForeignStockOrderAsync_Click);
            // 
            // btnSendForeignStockOrder
            // 
            this.btnSendForeignStockOrder.Location = new System.Drawing.Point(535, 32);
            this.btnSendForeignStockOrder.Name = "btnSendForeignStockOrder";
            this.btnSendForeignStockOrder.Size = new System.Drawing.Size(177, 23);
            this.btnSendForeignStockOrder.TabIndex = 19;
            this.btnSendForeignStockOrder.Text = "SendForeignStockOrder";
            this.btnSendForeignStockOrder.UseVisualStyleBackColor = true;
            this.btnSendForeignStockOrder.Click += new System.EventHandler(this.btnSendForeignStockOrder_Click);
            // 
            // boxBidAsk
            // 
            this.boxBidAsk.FormattingEnabled = true;
            this.boxBidAsk.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.boxBidAsk.Location = new System.Drawing.Point(202, 86);
            this.boxBidAsk.Name = "boxBidAsk";
            this.boxBidAsk.Size = new System.Drawing.Size(49, 20);
            this.boxBidAsk.TabIndex = 16;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(346, 84);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(65, 22);
            this.txtQty.TabIndex = 18;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(267, 84);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(62, 22);
            this.txtPrice.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "委託量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "委託價";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "買賣別";
            // 
            // txtStockNo
            // 
            this.txtStockNo.Location = new System.Drawing.Point(115, 84);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(67, 22);
            this.txtStockNo.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "商品代碼";
            // 
            // boxExchange
            // 
            this.boxExchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxExchange.FormattingEnabled = true;
            this.boxExchange.Items.AddRange(new object[] {
            "美股"});
            this.boxExchange.Location = new System.Drawing.Point(20, 84);
            this.boxExchange.Name = "boxExchange";
            this.boxExchange.Size = new System.Drawing.Size(72, 20);
            this.boxExchange.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "交易所";
            // 
            // boxCurrency3
            // 
            this.boxCurrency3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCurrency3.FormattingEnabled = true;
            this.boxCurrency3.Items.AddRange(new object[] {
            "HKD",
            "NTD",
            "USD",
            "JPY",
            "SGD",
            "EUR",
            "AUD"});
            this.boxCurrency3.Location = new System.Drawing.Point(443, 32);
            this.boxCurrency3.Name = "boxCurrency3";
            this.boxCurrency3.Size = new System.Drawing.Size(62, 20);
            this.boxCurrency3.TabIndex = 8;
            // 
            // boxCurrency2
            // 
            this.boxCurrency2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCurrency2.FormattingEnabled = true;
            this.boxCurrency2.Items.AddRange(new object[] {
            "HKD",
            "NTD",
            "USD",
            "JPY",
            "SGD",
            "EUR",
            "AUD"});
            this.boxCurrency2.Location = new System.Drawing.Point(355, 32);
            this.boxCurrency2.Name = "boxCurrency2";
            this.boxCurrency2.Size = new System.Drawing.Size(62, 20);
            this.boxCurrency2.TabIndex = 7;
            // 
            // boxCurrency1
            // 
            this.boxCurrency1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCurrency1.FormattingEnabled = true;
            this.boxCurrency1.Items.AddRange(new object[] {
            "HKD",
            "NTD",
            "USD",
            "JPY",
            "SGD",
            "EUR",
            "AUD"});
            this.boxCurrency1.Location = new System.Drawing.Point(267, 32);
            this.boxCurrency1.Name = "boxCurrency1";
            this.boxCurrency1.Size = new System.Drawing.Size(62, 20);
            this.boxCurrency1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "3.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "2.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "扣款幣別順序：";
            // 
            // boxAccountType
            // 
            this.boxAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAccountType.FormattingEnabled = true;
            this.boxAccountType.Items.AddRange(new object[] {
            "外幣專戶",
            "台幣專戶"});
            this.boxAccountType.Location = new System.Drawing.Point(77, 32);
            this.boxAccountType.Name = "boxAccountType";
            this.boxAccountType.Size = new System.Drawing.Size(69, 20);
            this.boxAccountType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "專戶別：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelForeignOrderByBookNo);
            this.groupBox2.Controls.Add(this.btnCancelForeignOrderBySeqNo);
            this.groupBox2.Controls.Add(this.txtCancelBookNo);
            this.groupBox2.Controls.Add(this.txtCancelSeqNo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.boxCancelExchange);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(3, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "取消委託";
            // 
            // btnCancelForeignOrderByBookNo
            // 
            this.btnCancelForeignOrderByBookNo.Location = new System.Drawing.Point(329, 54);
            this.btnCancelForeignOrderByBookNo.Name = "btnCancelForeignOrderByBookNo";
            this.btnCancelForeignOrderByBookNo.Size = new System.Drawing.Size(177, 23);
            this.btnCancelForeignOrderByBookNo.TabIndex = 18;
            this.btnCancelForeignOrderByBookNo.Text = "Cancel ForeignOrder ByBookNo";
            this.btnCancelForeignOrderByBookNo.UseVisualStyleBackColor = true;
            this.btnCancelForeignOrderByBookNo.Click += new System.EventHandler(this.btnCancelForeignOrderByBookNo_Click);
            // 
            // btnCancelForeignOrderBySeqNo
            // 
            this.btnCancelForeignOrderBySeqNo.Location = new System.Drawing.Point(329, 26);
            this.btnCancelForeignOrderBySeqNo.Name = "btnCancelForeignOrderBySeqNo";
            this.btnCancelForeignOrderBySeqNo.Size = new System.Drawing.Size(177, 23);
            this.btnCancelForeignOrderBySeqNo.TabIndex = 17;
            this.btnCancelForeignOrderBySeqNo.Text = "Cancel ForeignOrder BySeqNo";
            this.btnCancelForeignOrderBySeqNo.UseVisualStyleBackColor = true;
            this.btnCancelForeignOrderBySeqNo.Click += new System.EventHandler(this.btnCancelForeignOrderBySeqNo_Click);
            // 
            // txtCancelBookNo
            // 
            this.txtCancelBookNo.Location = new System.Drawing.Point(223, 56);
            this.txtCancelBookNo.Name = "txtCancelBookNo";
            this.txtCancelBookNo.Size = new System.Drawing.Size(100, 22);
            this.txtCancelBookNo.TabIndex = 16;
            // 
            // txtCancelSeqNo
            // 
            this.txtCancelSeqNo.Location = new System.Drawing.Point(223, 28);
            this.txtCancelSeqNo.Name = "txtCancelSeqNo";
            this.txtCancelSeqNo.Size = new System.Drawing.Size(100, 22);
            this.txtCancelSeqNo.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(128, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "委託書號刪單：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "委託序號刪單：";
            // 
            // boxCancelExchange
            // 
            this.boxCancelExchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCancelExchange.FormattingEnabled = true;
            this.boxCancelExchange.Items.AddRange(new object[] {
            "美股"});
            this.boxCancelExchange.Location = new System.Drawing.Point(20, 46);
            this.boxCancelExchange.Name = "boxCancelExchange";
            this.boxCancelExchange.Size = new System.Drawing.Size(72, 20);
            this.boxCancelExchange.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "交易所";
            // 
            // ForeignStockOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ForeignStockOrderControl";
            this.Size = new System.Drawing.Size(811, 240);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox boxExchange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox boxCurrency3;
        private System.Windows.Forms.ComboBox boxCurrency2;
        private System.Windows.Forms.ComboBox boxCurrency1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxAccountType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendForeignStockOrderAsync;
        private System.Windows.Forms.Button btnSendForeignStockOrder;
        private System.Windows.Forms.ComboBox boxBidAsk;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelForeignOrderByBookNo;
        private System.Windows.Forms.Button btnCancelForeignOrderBySeqNo;
        private System.Windows.Forms.TextBox txtCancelBookNo;
        private System.Windows.Forms.TextBox txtCancelSeqNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox boxCancelExchange;
        private System.Windows.Forms.Label label11;

    }
}
