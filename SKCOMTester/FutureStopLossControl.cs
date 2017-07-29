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
    public partial class FutureStopLossControl : UserControl
    {

        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        private int m_nCode;
        public string m_strMessage;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        public delegate void OrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder);
        public event OrderHandler OnFutureStopLossOrderSignal;


        public delegate void MovingOrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder);
        public event MovingOrderHandler OnMovingStopLossOrderSignal;
        
        public delegate void OptionOrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder);
        public event OptionOrderHandler OnOptionStopLossOrderSignal;

        public delegate void CancelFutrueOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSmartKey, string strTradeType);
        public event CancelFutrueOrderHandler OnCancelFutureStopLossOrderSignal;

        public delegate void CancelMovingOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSmartKey, string strTradeType);
        public event CancelMovingOrderHandler OnCancelMovingStopLossOrderSignal;


        public delegate void CancelOptionOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSmartKey, string strTradeType);
        public event CancelOptionOrderHandler OnCancelOptionStopLossOrderSignal;

        public delegate void StopLossReportHandler(string strLogInID, string strAccount, int nReportStatus, string strKind, string strDate);
        public event StopLossReportHandler OnStopLossReportSignal;

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
        public FutureStopLossControl()
        {
            InitializeComponent();
        }

        #endregion

        private void btnSendFutureStopOrder_Click(object sender, EventArgs e)
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
            string strTigger;
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

            if (boxNewCloseSTP.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewCloseSTP.SelectedIndex;

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

            if (double.TryParse(txtTrigger.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger.Text.Trim();

            if (ReservedBox1.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox1.SelectedIndex;


            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureStopLossOrderSignal != null)
            {
                OnFutureStopLossOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendFutureStopLossOrderAsync_Click(object sender, EventArgs e)
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
            string strTigger;
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

            if (boxNewCloseSTP.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewCloseSTP.SelectedIndex;

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
            if (txtPrice.Text.Trim() == "M")
                strPrice = "M";
            else if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
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

            if (double.TryParse(txtTrigger.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger.Text.Trim();

            if (ReservedBox1.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox1.SelectedIndex;


            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureStopLossOrderSignal != null)
            {
                OnFutureStopLossOrderSignal(m_UserID, true, pFutureOrder);
            }
        }


        private void btnMovingStopLossOrder_Click(object sender, EventArgs e)
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
            string strMovingPint;
            string strTigger;
            int nQty;
            int nNewClose;
            int nReserved;


            if (txtStockNo2.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo2.Text.Trim();

            if (boxBidAsk2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk2.SelectedIndex;

            if (boxPeriod2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }

            nPeriod = boxPeriod2.SelectedIndex;

            if (boxNewCloseMST.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            
            nNewClose = boxNewCloseMST.SelectedIndex;            

            if (boxFlag2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxFlag2.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtMovingPoint.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("移動點數請輸入數字");
                return;
            }
            strMovingPint = txtMovingPoint.Text.Trim();

            if (int.TryParse(txtQty2.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (double.TryParse(txtTrigger2.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger2.Text.Trim();

            if (ReservedBox2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox2.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            //pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.bstrMovingPoint = strMovingPint;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnMovingStopLossOrderSignal != null)
            {
                OnMovingStopLossOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnMovingStopLossOrderAsync_Click(object sender, EventArgs e)
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
            string strMovingPint;
            string strTigger;
            int nQty;
            int nNewClose;
            int nReserved;

            if (txtStockNo2.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo2.Text.Trim();

            if (boxBidAsk2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk2.SelectedIndex;

            if (boxPeriod2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod2.SelectedIndex;

            if (boxNewCloseMST.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }

            nNewClose = boxNewCloseMST.SelectedIndex;

            if (boxFlag2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxFlag2.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtMovingPoint.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("移動點數請輸入數字");
                return;
            }
            strMovingPint = txtMovingPoint.Text.Trim();

            if (int.TryParse(txtQty2.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (double.TryParse(txtTrigger2.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger2.Text.Trim();

            if (ReservedBox2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox2.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            //pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.bstrMovingPoint = strMovingPint;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnMovingStopLossOrderSignal != null)
            {
                OnMovingStopLossOrderSignal(m_UserID, true, pFutureOrder);
            }
        }

        private void btnSendOptionOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nNewClose;
            string strPrice;
            string strTigger;
            int nQty;
            int nReserved;


            if (txtStockNo3.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo3.Text.Trim();

            if (boxBidAsk3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk3.SelectedIndex;

            if (boxPeriod3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod3.SelectedIndex;

            if (boxNewCloseOST.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉位");
                return;
            }
            nNewClose = boxNewCloseOST.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice3.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice3.Text.Trim();

            if (int.TryParse(txtQty3.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (double.TryParse(txtTrigger3.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger3.Text.Trim();

            if (ReservedBox3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox3.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnOptionStopLossOrderSignal != null)
            {
                OnOptionStopLossOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendOptionOrderAsync_Click(object sender, EventArgs e)
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
            string strTigger;
            int nQty;
            int nReserved;

            if (txtStockNo3.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo3.Text.Trim();

            if (boxBidAsk3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk3.SelectedIndex;

            if (boxPeriod3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod3.SelectedIndex;

            if (boxNewCloseOST.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉位");
                return;
            }
            nFlag = boxNewCloseOST.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice3.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice3.Text.Trim();

            if (int.TryParse(txtQty3.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (double.TryParse(txtTrigger3.Text.Trim(), out dPrice) == false)
            {
                MessageBox.Show("觸發價請輸入數字");
                return;
            }
            strTigger = txtTrigger3.Text.Trim();

            if (ReservedBox3.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = ReservedBox3.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sNewClose = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.bstrTrigger = strTigger;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnOptionStopLossOrderSignal != null)
            {
                OnOptionStopLossOrderSignal(m_UserID, true, pFutureOrder);
            }
        }

        private void btnCancelFutureStopLoss_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strBookNo;
            string strSymbol;

            if (txtCancelBookNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單序號");
                return;
            }
            strBookNo = txtCancelBookNo.Text.Trim();

            if (txtCaneclSymbol.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單類別");
                return;
            }
            strSymbol = txtCaneclSymbol.Text.Trim();

            if (OnCancelFutureStopLossOrderSignal != null)
            {
                OnCancelFutureStopLossOrderSignal("", true, m_UserAccount, strBookNo, strSymbol);
            }
        }

        private void btnCancelMovingStopLoss_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strBookNo;
            string strSymbol;

            if (txtCancelBookNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單序號");
                return;
            }
            strBookNo = txtCancelBookNo.Text.Trim();

            if (txtCaneclSymbol.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單類別");
                return;
            }
            strSymbol = txtCaneclSymbol.Text.Trim();

            if (OnCancelMovingStopLossOrderSignal != null)
            {
                OnCancelMovingStopLossOrderSignal(m_UserID, true, m_UserAccount, strBookNo, strSymbol);
            }
        }

        private void btnCancelOptionStopLoss_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strBookNo;
            string strSymbol;

            if (txtCancelBookNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單序號");
                return;
            }
            strBookNo = txtCancelBookNo.Text.Trim();

            if (txtCaneclSymbol.Text.Trim() == "")
            {
                MessageBox.Show("請輸入智慧單類別");
                return;
            }
            strSymbol = txtCaneclSymbol.Text.Trim();

            if (OnCancelOptionStopLossOrderSignal != null)
            {
                OnCancelOptionStopLossOrderSignal(m_UserID, true, m_UserAccount, strBookNo, strSymbol);
            }
        }

        private void btnGetStopLossReport_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            int nTypeReport;
            string strKindReport;
            string strStartDate;

            if (boxTypeReport.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇類型");
                return;
            }
            nTypeReport = boxTypeReport.SelectedIndex;

            if (boxKindReport.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇種類");
                return;
            }
            strKindReport = boxKindReport.Text.Trim();

            if (StartDateBox.Text.Trim() == "" || StartDateBox.Text.Trim() == "YYYYMMDD")
            {
                MessageBox.Show("請輸入查詢日期");
                return;
            }
            strStartDate = StartDateBox.Text.Trim();

            if (OnStopLossReportSignal != null)
            {

                OnStopLossReportSignal(m_UserID, m_UserAccount, nTypeReport, strKindReport, strStartDate);
            }
        }


    }
}
