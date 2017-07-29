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
    public partial class FutureOrderControl : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        private int m_nCode;
        public string m_strMessage;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        public delegate void OrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event OrderHandler OnFutureOrderSignal;

        public delegate void OrderCLRHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event OrderCLRHandler OnFutureOrderCLRSignal;

        public delegate void DecreaseOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, int nDecreaseQty);
        public event DecreaseOrderHandler OnDecreaseOrderSignal;

        public delegate void CancelOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo);
        public event CancelOrderHandler OnCancelOrderSignal;

        public delegate void CancelOrderByStockHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strStockNo);
        public event CancelOrderByStockHandler OnCancelOrderByStockSignal;


        public delegate void CorrectPriceBySeqNoHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, string strPrice, int nTradeType);
        public event CorrectPriceBySeqNoHandler OnCorrectPriceBySeqNo;

        public delegate void CorrectPriceByBookNoHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSymbol, string strSeqNo, string strPrice, int nTradeType);
        public event CorrectPriceByBookNoHandler OnCorrectPriceByBookNo;


        public delegate void OpenInterestHandler(string strLogInID, string strAccount);
        public event OpenInterestHandler OnOpenInterestSignal;

        public delegate void FutureRightsHandler(string strLogInID, string strAccount, int nCoinType);
        public event FutureRightsHandler OnFutureRightsSignal;
        

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
        public FutureOrderControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        private void btnSendFutureOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;


            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;         

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount    = m_UserAccount;
            pFutureOrder.bstrPrice          = strPrice;
            pFutureOrder.bstrStockNo        = strFutureNo;
            pFutureOrder.nQty               = nQty;
            pFutureOrder.sBuySell           = (short)nBidAsk;
            pFutureOrder.sDayTrade          = (short)nFlag;
            pFutureOrder.sTradeType         = (short)nPeriod;            

            if (OnFutureOrderSignal != null)
            {
                OnFutureOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendFutureOrderAsync_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;            

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;            

            if (OnFutureOrderSignal != null)
            {
                OnFutureOrderSignal(m_UserID, true, pFutureOrder);
            }

        }

        private void btnSendFutureOrderCLR_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;
            int nNewClose;
            int nReserved;


            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;

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
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxReserved.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = boxReserved.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureOrderCLRSignal != null)
            {
                OnFutureOrderCLRSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendFutureOrderCLRAsync_Click(object sender, EventArgs e)
        {

            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;
            int nNewClose;
            int nReserved;

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;

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
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxReserved.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = boxReserved.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureOrderCLRSignal != null)
            {
                OnFutureOrderCLRSignal(m_UserID, true, pFutureOrder);
            }
        }
        #endregion

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            int nQty = 0;
            string strSeqNo;

            if (txtDecreaseSeqNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入委託序號");
                return;
            }
            strSeqNo = txtDecreaseSeqNo.Text.Trim();

            if (int.TryParse(txtDecreaseQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("改量請輸入數字");
                return;
            }
            if (OnDecreaseOrderSignal != null)
            {
                OnDecreaseOrderSignal(m_UserID, true, m_UserAccount, strSeqNo, nQty);
            }
        }

        private void btnCancelOrderBySeqNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strSeqNo;

            if (txtCancelSeqNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入委託序號");
                return;
            }
            strSeqNo = txtCancelSeqNo.Text.Trim();
            if (OnCancelOrderSignal != null)
            {
                OnCancelOrderSignal(m_UserID, true, m_UserAccount, strSeqNo);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strStockNo;

            if (txtCancelStockNo.Text.Trim() == "")
            {
                if (MessageBox.Show("未輸入商品代碼會刪除所有委託單，是否刪單?", "委託全部刪單", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("已取消本次操作");
                    return;
                }
            }
            strStockNo = txtCancelStockNo.Text.Trim();
            if (OnCancelOrderByStockSignal != null)
            {
                OnCancelOrderByStockSignal(m_UserID, true, m_UserAccount, strStockNo);
            }
        }

        private void btnCorrectPriceBySeqNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            if (OnCorrectPriceBySeqNo != null)
            {
                int nTradeType;
                string strSeqNo;
                string strPrice;

                if (txtCorrectSeqNo.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入委託序號");
                    return;
                }
                strSeqNo = txtCorrectSeqNo.Text.Trim();

                double dPrice = 0.0;
                if (double.TryParse(txtCorrectPrice.Text.Trim(), out dPrice) == false)
                {
                    MessageBox.Show("修改價格請輸入數字");
                    return;
                }
                strPrice = txtCorrectPrice.Text.Trim();

                if (boxCorrectTradeType.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇委託條件");
                    return;
                }
                nTradeType = boxCorrectTradeType.SelectedIndex;

                OnCorrectPriceBySeqNo(m_UserID, true, m_UserAccount, strSeqNo, strPrice, nTradeType);
            }
        }

        private void btnCorrectPriceByBookNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            if (OnCorrectPriceByBookNo != null)
            {
                int nTradeType;
                string strBookNo;
                string strPrice;

                if (txtCorrectBookNo.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入委託書號");
                    return;
                }
                strBookNo = txtCorrectBookNo.Text.Trim();

                double dPrice = 0.0;
                if (double.TryParse(txtCorrectPrice.Text.Trim(), out dPrice) == false)
                {
                    MessageBox.Show("修改價格請輸入數字");
                    return;
                }
                strPrice = txtCorrectPrice.Text.Trim();

                if (boxCorrectSymbol.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇市場簡稱");
                    return;
                }
                nTradeType = boxCorrectTradeType.SelectedIndex;

                if (boxCorrectTradeType.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇委託條件");
                    return;
                }

                OnCorrectPriceByBookNo(m_UserID, true, m_UserAccount, boxCorrectSymbol.Text.Trim(), strBookNo, strPrice, nTradeType);
            }
        }

        private void btnGetOpenInterest_Click(object sender, EventArgs e)
        {
            if (OnOpenInterestSignal != null)
            {
                OnOpenInterestSignal(m_UserID, m_UserAccount);
            }
        }

        private void btnGetFutureRights_Click(object sender, EventArgs e)
        {
            int nCoinType;
            if (comBox_CoinType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇幣別");
                return;
            }
            nCoinType = comBox_CoinType.SelectedIndex;
            
            if (OnFutureRightsSignal != null)
            {

                OnFutureRightsSignal(m_UserID, m_UserAccount, nCoinType+1);
            }
        }

    }
}
