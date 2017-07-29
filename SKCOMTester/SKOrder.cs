using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKCOMLib;

namespace SKCOMTester
{
    public partial class SKOrder : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------
        private bool m_bfirst = true;
        private int m_nCode;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        SKCOMLib.SKOrderLib m_pSKOrder = null;
        public SKOrderLib OrderObj
        {
            get { return m_pSKOrder; }
            set { m_pSKOrder = value; }
        }

        public string m_strLoginID = "";
        public string LoginID
        {
            get { return m_strLoginID; }
            set { m_strLoginID = value; }
        }


        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public SKOrder()
        {
            InitializeComponent();
        }

        private void SKOrder_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region API Event
        //----------------------------------------------------------------------
        // API Event
        //----------------------------------------------------------------------

        void m_OrderObj_OnAccount(string bstrLogInID, string bstrAccountData)
        {
            string[] strValues;
            string strAccount;

            strValues = bstrAccountData.Split(',');
            strAccount = bstrLogInID + " " + strValues[1] + strValues[3];

            if (strValues[0] == "TS")
            {
                boxStockAccount.Items.Add(strAccount);

                //boxExecutionAccount.Items.Add("證券 " + strAccount);
            }
            else if (strValues[0] == "TF")
            {
                boxFutureAccount.Items.Add(strAccount);

                //boxExecutionAccount.Items.Add("期貨 " + strAccount);
            }
            else if (strValues[0] == "OF")
            {
                boxOSFutureAccount.Items.Add(strAccount);
            }
            else if (strValues[0] == "OS")
            {
                boxOSStockAccount.Items.Add(strAccount);
            }

        }

        void m_pSKOrder_OnAsyncOrder(int nThreaID, int nCode, string bstrMessage)
        {
            WriteMessage("Thread ID:" + nThreaID.ToString() + " Code:" + nCode.ToString() + " Message:" + bstrMessage);
        }


        void m_pSKOrder_OnRealBalanceReport(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnOpenInterest(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnOverseaFutureOpenInterest(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnStopLossReport(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnOverseaFuture(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnOverseaOption(string bstrData)
        {
            WriteMessage(bstrData);
        }

        void m_pSKOrder_OnFutureRights(string bstrData)
        {
            WriteMessage(bstrData);
        
        }

        void m_pSKOrder_OnRequestProfitReport(string bstrData)
        {
            WriteMessage(bstrData);
        }

        #endregion

        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            if (m_bfirst == true)
            {
                m_pSKOrder.OnAccount += new _ISKOrderLibEvents_OnAccountEventHandler(m_OrderObj_OnAccount);
                m_pSKOrder.OnAsyncOrder += new _ISKOrderLibEvents_OnAsyncOrderEventHandler(m_pSKOrder_OnAsyncOrder);
                m_pSKOrder.OnRealBalanceReport += new _ISKOrderLibEvents_OnRealBalanceReportEventHandler(m_pSKOrder_OnRealBalanceReport);
                m_pSKOrder.OnOpenInterest += new _ISKOrderLibEvents_OnOpenInterestEventHandler(m_pSKOrder_OnOpenInterest);
                m_pSKOrder.OnOverseaFutureOpenInterest += new _ISKOrderLibEvents_OnOverseaFutureOpenInterestEventHandler(m_pSKOrder_OnOverseaFutureOpenInterest);
                m_pSKOrder.OnStopLossReport += new _ISKOrderLibEvents_OnStopLossReportEventHandler(m_pSKOrder_OnStopLossReport);
                m_pSKOrder.OnOverseaFuture += new _ISKOrderLibEvents_OnOverseaFutureEventHandler(m_pSKOrder_OnOverseaFuture);
                m_pSKOrder.OnOverseaOption += new _ISKOrderLibEvents_OnOverseaOptionEventHandler(m_pSKOrder_OnOverseaOption);
                m_pSKOrder.OnFutureRights += new _ISKOrderLibEvents_OnFutureRightsEventHandler(m_pSKOrder_OnFutureRights);
                m_pSKOrder.OnRequestProfitReport += new _ISKOrderLibEvents_OnRequestProfitReportEventHandler(m_pSKOrder_OnRequestProfitReport);
                
                m_bfirst = false;
            }
            
            m_nCode = m_pSKOrder.SKOrderLib_Initialize();

            SendReturnMessage("Order", m_nCode, "SKOrderLib_Initialize");
        }

        private void btnReadCert_Click(object sender, EventArgs e)
        {
            m_nCode = m_pSKOrder.ReadCertByID(m_strLoginID);

            SendReturnMessage("Order", m_nCode, "ReadCertByID");
        }

        private void btnGetAccount_Click(object sender, EventArgs e)
        {
            boxStockAccount.Items.Clear();
            boxFutureAccount.Items.Clear();
            boxOSFutureAccount.Items.Clear();
            boxOSStockAccount.Items.Clear();

            m_nCode = m_pSKOrder.GetUserAccount();

            SendReturnMessage("Order", m_nCode, "GetUserAccount");
        }

        private void btnSetMaxQty_Click(object sender, EventArgs e)
        {
            int nQty = 0;
            int.TryParse(txtMaxQty.Text.Trim(), out nQty);

            m_nCode = m_pSKOrder.SetMaxQty(boxOrderLimit.SelectedIndex, nQty);

            SendReturnMessage("Order", m_nCode, "SetMaxQty");
        }

        private void btnSetMaxCount_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            int.TryParse(txtMaxCount.Text.Trim(), out nCount);

            m_nCode = m_pSKOrder.SetMaxCount(boxOrderLimit.SelectedIndex, nCount);
            SendReturnMessage("Order", m_nCode, "SetMaxCount");
        }

        private void btnOrderUnlock_Click(object sender, EventArgs e)
        {
            m_nCode = m_pSKOrder.UnlockOrder(boxOrderLimit.SelectedIndex);
            SendReturnMessage("Order", m_nCode, "UnlockOrder");
        }

        private void btnDownloadOS_Click(object sender, EventArgs e)
        {
            
            m_nCode = m_pSKOrder.SKOrderLib_LoadOSCommodity();
            SendReturnMessage("Order", m_nCode, "SKOrderLib_LoadOSCommodity");
        }

        private void btnDownloadOO_Click(object sender, EventArgs e)
        {
            
            m_nCode = m_pSKOrder.SKOrderLib_LoadOOCommodity();
            SendReturnMessage("Order", m_nCode, "SKOrderLib_LoadOOCommodity");
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void boxStockAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strInfo = boxStockAccount.Text;

            string[] strValues;
            strValues = strInfo.Split(' ');

            stockOrderControl1.UserID = strValues[0];
            stockOrderControl1.UserAccount = strValues[1];
        }

        private void boxOSStockAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strInfo = boxOSStockAccount.Text;

            string[] strValues;
            strValues = strInfo.Split(' ');

            foreignStockOrderControl1.UserID = strValues[0];
            foreignStockOrderControl1.UserAccount = strValues[1];
        }

        private void boxOSFutureAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strInfo = boxOSFutureAccount.Text;

            string[] strValues;
            strValues = strInfo.Split(' ');

            overseaFutureOrderControl1.UserID = strValues[0];
            overseaFutureOrderControl1.UserAccount = strValues[1];

            overseaOptionOrderControl1.UserID = strValues[0];
            overseaOptionOrderControl1.UserAccount = strValues[1];

        }

        private void boxFutureAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strInfo = boxFutureAccount.Text;

            string[] strValues;
            strValues = strInfo.Split(' ');

            futureOrderControl1.UserID = strValues[0];
            futureOrderControl1.UserAccount = strValues[1];

            optionOrderControl1.UserID = strValues[0];
            optionOrderControl1.UserAccount = strValues[1];

            futureStopLossControl1.UserID = strValues[0];
            futureStopLossControl1.UserAccount = strValues[1];
        }


        private void stockOrderControl1_OnOrderSignal(string strLogInID, bool bAsyncOrder, STOCKORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendStockOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("證券委託 :" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendStockOrder");
        }

        private void futureOrderControl1_OnFutureOrderSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendFutureOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("期貨委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendFutureOrder");
        }

        private void futureOrderControl1_OnFutureOrderCLRSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendFutureOrderCLR(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("期貨委託2：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendFutureOrderCLR");
        }
        
        private void optionOrderControl1_OnOptionOrderSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendOptionOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("選擇權委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendOptionOrder");
        }

        private void overseaFutureOrderControl1_OnOverseaFutureOrderSignal(string strLogInID, bool bAsyncOrder, OVERSEAFUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendOverseaFutureOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("海期委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendOverseaFutureOrder");
        }

        private void overseaFutureOrderControl1_OnOverseaFutureOrderSpreadSignal(string strLogInID, bool bAsyncOrder, OVERSEAFUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendOverseaFutureSpreadOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("海期價差委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendOverseaFutureSpreadOrder");
        }

        private void overseaOptionOrderControl1_OnOverseaOptionOrderSignal(string strLogInID, bool bAsyncOrder, OVERSEAFUTUREORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendOverseaOptionOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("海選委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendOverseaOptionOrder");
        }

        private void futureStopLossControl1_OnFutureStopLossOrderSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendFutureStopLossOrder(strLogInID, bAsyncOrder, pOrder, out strMessage);

            WriteMessage("期貨停損委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendFutureStopLossOrder");
        }

        private void futureStopLossControl1_OnMovingStopLossOrderSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendMovingStopLossOrder(strLogInID, bAsyncOrder, pOrder, out strMessage);

            WriteMessage("期貨移動停損委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendMovingStopLossOrder");
        }

        private void futureStopLossControl1_OnOptionStopLossOrderSignal(string strLogInID, bool bAsyncOrder, FUTUREORDER pOrder)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendOptionStopLossOrder(strLogInID, bAsyncOrder, pOrder, out strMessage);

            WriteMessage("選擇權停損委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendOptionStopLossOrder");
        }

        private void ForeignOrderControl1_OnForeignOrderSignal(string strLogInID, bool bAsyncOrder, FOREIGNORDER pStock)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.SendForeignStockOrder(strLogInID, bAsyncOrder, pStock, out strMessage);

            WriteMessage("複委託：" + strMessage);
            SendReturnMessage("Order", m_nCode, "SendForeignStockOrder");
        }

        private void ForeignOrderControl1_OnCancelForeignOrderBySeqSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, string strExchangeNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelForeignStockOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, strExchangeNo, out strMessage);

            WriteMessage("複委託刪單BySeq：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelForeignStockOrderBySeqNo");
        }

        private void ForeignOrderControl1_OnCancelForeignOrderByBookSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo, string strExchangeNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelForeignStockOrderByBookNo(strLogInID, bAsyncOrder, strAccount, strBookNo, strExchangeNo, out strMessage);

            WriteMessage("複委託刪單ByBook：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelForeignStockOrderByBookNo");
        }

        private void stockOrderControl1_OnDecreaseOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, int nDecreaseQty)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.DecreaseOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, nDecreaseQty, out strMessage);

            WriteMessage("改量：" + strMessage);
            SendReturnMessage("Order", m_nCode, "DecreaseOrderBySeqNo");
        }

        private void overseaFutureOrderControl1_OnDecreaseOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, int nDecreaseQty)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.OverSeaDecreaseOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, nDecreaseQty, out strMessage);

            WriteMessage("海期改量：" + strMessage);
            SendReturnMessage("Order", m_nCode, "OverSeaDecreaseOrderBySeqNo");
        }

        private void stockOrderControl1_OnCancelOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, out strMessage);

            WriteMessage("刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelOrderBySeqNo");
        }

        private void stockOrderControl1_OnCancelOrderByBookSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strBookNo, out strMessage);

            WriteMessage("刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelOrderBySeqNo");
        }

        private void stockOrderControl1_OnCancelOrderByStockSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strStockNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelOrderByStockNo(strLogInID, bAsyncOrder, strAccount, strStockNo, out strMessage);

            WriteMessage("刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelOrderByStockNo");
        }

        private void futureStopLossControl1_OnCancelFutureStopLossOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo, string strSymbol)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelFutureStopLoss(strLogInID, bAsyncOrder, strAccount, strBookNo, strSymbol, out strMessage);

            WriteMessage("停損刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelFutureStopLoss");
        }

        private void futureStopLossControl1_OnCancelMovingStopLossOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo, string strSymbol)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelMovingStopLoss(strLogInID, bAsyncOrder, strAccount, strBookNo, strSymbol, out strMessage);

            WriteMessage("移動停損刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelMovingStopLoss");
        }

        private void futureStopLossControl1_OnCancelOptionStopLossOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo, string strSymbol)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CancelOptionStopLoss(strLogInID, bAsyncOrder, strAccount, strBookNo, strSymbol, out strMessage);

            WriteMessage("選擇權停損刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CancelOptionStopLoss");
        }

        private void futureOrderControl1_OnCorrectPriceBySeqNo(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, string strPrice, int nTradeType)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CorrectPriceBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, strPrice, nTradeType, out strMessage);

            WriteMessage("期權改價：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CorrectPriceBySeqNo");
        }
        private void futureOrderControl1_OnCorrectPriceByBookNo(string strLogInID, bool bAsyncOrder, string strAccount, string strSymbol, string strBookNo, string strPrice, int nTradeType)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.CorrectPriceByBookNo(strLogInID, bAsyncOrder, strAccount, strSymbol, strBookNo, strPrice, nTradeType, out strMessage);

            WriteMessage("期權依書號改價：" + strMessage);
            SendReturnMessage("Order", m_nCode, "CorrectPriceByBookNo");
        }

        private void overseaFutureOrderControl1_OnCancelOrderSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.OverSeaCancelOrderBySeqNo(strLogInID, bAsyncOrder, strAccount, strSeqNo, out strMessage);

            WriteMessage("海期刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "OverSeaCancelOrderBySeqNo");
        }
        private void overseaFutureOrderControl1_OnCancelOrderByBookSignal(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo)
        {
            string strMessage = "";
            m_nCode = m_pSKOrder.OverSeaCancelOrderByBookNo(strLogInID, bAsyncOrder, strAccount, strBookNo, out strMessage);

            WriteMessage("海期依書號刪單：" + strMessage);
            SendReturnMessage("Order", m_nCode, "OverSeaCancelOrderByBookNo");
        }
        
        private void stockOrderControl1_OnRealBalanceSignal(string strLogInID, string strAccount)
        {
            m_nCode = m_pSKOrder.GetRealBalanceReport(strLogInID, strAccount);
            SendReturnMessage("Order", m_nCode, "GetRealBalanceReport");
        }

        private void stockOrderControl1_OnRequestProfitReportSignal(string strLogInID, string strAccount)
        {
            m_nCode = m_pSKOrder.GetRequestProfitReport(strLogInID, strAccount);
            SendReturnMessage("Order", m_nCode, "GetRequestProfitReport");
        }

        private void futureOrderControl1_OnOpenInterestSignal(string strLogInID, string strAccount)
        {
            m_nCode = m_pSKOrder.GetOpenInterest(strLogInID, strAccount);
            SendReturnMessage("Order", m_nCode, "GetOpenInterest");
        }

        private void overseaFutureOrderControl1_OnOpenInterestSignal(string strLogInID, string strAccount)
        {
            m_nCode = m_pSKOrder.GetOverseaFutureOpenInterest(strLogInID, strAccount);
            SendReturnMessage("Order", m_nCode, "GetOverseaFutureOpenInterest");
        }
        private void futureStopLossControl1_OnStopLossReportSignal(string strLogInID, string strAccount, int nReportStatus, string strKind, string strDate)
        {
            m_nCode = m_pSKOrder.GetStopLossReport(strLogInID, strAccount, nReportStatus, strKind , strDate);
            SendReturnMessage("Order", m_nCode, "GetStopLossReport");
        }

        private void overseaFutureOrderControl1_OnOverseaFuturesSignal()
        {
            m_nCode = m_pSKOrder.GetOverseaFutures();
            SendReturnMessage("Order", m_nCode, "GetOverseaFutures");
        }

        private void overseaOptionOrderControl1_OnOnOverseaOptionSignal()
        {
            m_nCode = m_pSKOrder.GetOverseaOptions();
            SendReturnMessage("Order", m_nCode, "GetOverseaOptions");
        }

        private void futureOrderControl1_OnFutureRightsSignal(string strLogInID, string strAccount,int nCoinType)
        {
            m_nCode = m_pSKOrder.GetFutureRights(strLogInID, strAccount, (short)nCoinType);
            SendReturnMessage("Order", m_nCode, "GetFutureRights");
        }
        #endregion

        #region Custom Method
        //----------------------------------------------------------------------
        // Custom Method
        //----------------------------------------------------------------------

        void SendReturnMessage(string strType, int nCode, string strMessage)
        {
            if (GetMessage != null)
            {
                GetMessage(strType, nCode, strMessage);
            }
        }

        public void WriteMessage(string strMsg)
        {
            listInformation.Items.Add(strMsg);

            listInformation.SelectedIndex = listInformation.Items.Count - 1;

            //listInformation.HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = listInformation.CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listInformation.Items[listInformation.Items.Count - 1].ToString(), listInformation.Font).Width;
            // Set the HorizontalExtent property.
            //[20170607-d-]listInformation.HorizontalExtent = hzSize;
        }

        #endregion




    }
}
