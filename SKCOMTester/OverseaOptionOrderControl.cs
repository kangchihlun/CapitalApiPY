using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKCOMLib;

namespace SKOrderTester
{
    public partial class OverseaOptionOrderControl : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        private int m_nCode;
        public string m_strMessage;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        public delegate void OrderHandler(string strLogInID, bool bAsyncOrder, OVERSEAFUTUREORDER pStock);
        public event OrderHandler OnOverseaOptionOrderSignal;

        public delegate void GetOverseaOptions();
        public event GetOverseaOptions OnOnOverseaOptionSignal;

        private string m_UserID = "";
        public string UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        private string m_UserAccount = "";
        public string UserAccount
        {
            get { return m_UserAccount; }
            set { m_UserAccount = value; }
        }

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public OverseaOptionOrderControl()
        {
            InitializeComponent();
        }

        #endregion

        private void btnSendOverseaFutureOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇海期帳號");
                return;
            }

            string strTradeName;
            string strStockNo;
            string strYearMonth;
            int nBuySell;
            int nNewClose;
            int nDayTrade;
            int nTradeType;
            int nSpecialTradeType;
            int nCallPut;
            string strStrikePrice;
            string strOrder;
            string strOrderNumerator;
            string strTrigger;
            string strTriggerNumerator;
            int nQty;

            if (txtTradeNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入交易所代號");
                return;
            }
            strTradeName = txtTradeNo.Text.Trim();

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strStockNo = txtStockNo.Text.Trim();

            if (txtYearMonth.Text.Trim() == "")
            {
                MessageBox.Show("請輸入年月");
                return;
            }
            strYearMonth = txtYearMonth.Text.Trim();

            double dPrice = 0.0;
            if (double.TryParse(txtOrder.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strOrder = txtOrder.Text.Trim();

            if (double.TryParse(txtOrderNumerator.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價分子請輸入數字");
                return;
            }
            strOrderNumerator = txtOrderNumerator.Text.Trim();

            //if (double.TryParse(txtTrigger.Text.Trim(), out dPrice) == false)
            //{
            //    MessageBox.Show("觸發價請輸入數字");
            //    return;
            //}
            strTrigger = txtTrigger.Text.Trim();

            //if (double.TryParse(txtTriggerNumerator.Text.Trim(), out dPrice) == false)
            //{
            //    MessageBox.Show("觸發價分子請輸入數字");
            //    return;
            //}
            strTriggerNumerator = txtTriggerNumerator.Text.Trim();

            strStrikePrice = txtStrikePrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBuySell = boxBidAsk.SelectedIndex;

            if (boxNewClose.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewClose.SelectedIndex;

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nDayTrade = boxFlag.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nTradeType = boxPeriod.SelectedIndex;

            if (boxSpecialTradeType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託類型");
                return;
            }
            nSpecialTradeType = boxSpecialTradeType.SelectedIndex;

            if (boxCallPut.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇CALL PUT");
                return;
            }
            nCallPut = boxCallPut.SelectedIndex;

            OVERSEAFUTUREORDER pOSOrder = new OVERSEAFUTUREORDER();

            pOSOrder.bstrFullAccount        = m_UserAccount;
            pOSOrder.bstrExchangeNo         = strTradeName;
            pOSOrder.bstrOrder              = strOrder;
            pOSOrder.bstrOrderNumerator     = strOrderNumerator;
            pOSOrder.bstrStockNo            = strStockNo;
            pOSOrder.bstrTrigger            = strTrigger;
            pOSOrder.bstrTriggerNumerator   = strTriggerNumerator;
            pOSOrder.bstrYearMonth          = strYearMonth;
            pOSOrder.bstrStrikePrice        = strStrikePrice;
            pOSOrder.nQty                   = nQty;
            pOSOrder.sBuySell               = (short)nBuySell;
            pOSOrder.sDayTrade              = (short)nDayTrade;
            pOSOrder.sNewClose              = (short)nNewClose;
            pOSOrder.sSpecialTradeType      = (short)nSpecialTradeType;
            pOSOrder.sTradeType             = (short)nTradeType;
            pOSOrder.sCallPut               = (short)nCallPut;

            if (OnOverseaOptionOrderSignal != null)
            {
                OnOverseaOptionOrderSignal(m_UserID, false, pOSOrder);
            }
        }

        private void btnGetOverseaOptions_Click(object sender, EventArgs e)
        {
            if (OnOnOverseaOptionSignal != null)
            {
                OnOnOverseaOptionSignal();
            }
        }

        private void btnSendOverseaFutureOrderAsync_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇海期帳號");
                return;
            }

            string strTradeName;
            string strStockNo;
            string strYearMonth;
            int nBuySell;
            int nNewClose;
            int nDayTrade;
            int nTradeType;
            int nSpecialTradeType;
            int nCallPut;
            string strStrikePrice;
            string strOrder;
            string strOrderNumerator;
            string strTrigger;
            string strTriggerNumerator;
            int nQty;

            if (txtTradeNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入交易所代號");
                return;
            }
            strTradeName = txtTradeNo.Text.Trim();

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strStockNo = txtStockNo.Text.Trim();

            if (txtYearMonth.Text.Trim() == "")
            {
                MessageBox.Show("請輸入年月");
                return;
            }
            strYearMonth = txtYearMonth.Text.Trim();

            double dPrice = 0.0;
            if (double.TryParse(txtOrder.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strOrder = txtOrder.Text.Trim();

            if (double.TryParse(txtOrderNumerator.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價分子請輸入數字");
                return;
            }
            strOrderNumerator = txtOrderNumerator.Text.Trim();

            //if (double.TryParse(txtTrigger.Text.Trim(), out dPrice) == false)
            //{
            //    MessageBox.Show("觸發價請輸入數字");
            //    return;
            //}
            strTrigger = txtTrigger.Text.Trim();

            //if (double.TryParse(txtTriggerNumerator.Text.Trim(), out dPrice) == false)
            //{
            //    MessageBox.Show("觸發價分子請輸入數字");
            //    return;
            //}
            strTriggerNumerator = txtTriggerNumerator.Text.Trim();

            strStrikePrice = txtStrikePrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBuySell = boxBidAsk.SelectedIndex;

            if (boxNewClose.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewClose.SelectedIndex;

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nDayTrade = boxFlag.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nTradeType = boxPeriod.SelectedIndex;

            if (boxSpecialTradeType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託類型");
                return;
            }
            nSpecialTradeType = boxSpecialTradeType.SelectedIndex;

            if (boxCallPut.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇CALL PUT");
                return;
            }
            nCallPut = boxCallPut.SelectedIndex;

            OVERSEAFUTUREORDER pOSOrder = new OVERSEAFUTUREORDER();

            pOSOrder.bstrFullAccount = m_UserAccount;
            pOSOrder.bstrExchangeNo = strTradeName;
            pOSOrder.bstrOrder = strOrder;
            pOSOrder.bstrOrderNumerator = strOrderNumerator;
            pOSOrder.bstrStockNo = strStockNo;
            pOSOrder.bstrTrigger = strTrigger;
            pOSOrder.bstrTriggerNumerator = strTriggerNumerator;
            pOSOrder.bstrYearMonth = strYearMonth;
            pOSOrder.bstrStrikePrice = strStrikePrice;           
            pOSOrder.nQty = nQty;
            pOSOrder.sBuySell = (short)nBuySell;
            pOSOrder.sDayTrade = (short)nDayTrade;
            pOSOrder.sNewClose = (short)nNewClose;
            pOSOrder.sSpecialTradeType = (short)nSpecialTradeType;
            pOSOrder.sTradeType = (short)nTradeType;
            pOSOrder.sCallPut = (short)nCallPut;

            if (OnOverseaOptionOrderSignal != null)
            {
                OnOverseaOptionOrderSignal(m_UserID, true, pOSOrder);
            }
        }
    }
}
