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
    public partial class ForeignStockOrderControl : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        private int m_nCode;
        public string m_strMessage;

        public delegate void ForeignOrderHandler(string strLogInID, bool bAsyncOrder, FOREIGNORDER pStock);
        public event ForeignOrderHandler OnForeignOrderSignal;

        public delegate void CancelForeignOrderBySeqHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, string strExchangeNo);
        public event CancelForeignOrderBySeqHandler OnCancelForeignOrderBySeqSignal;

        public delegate void CancelForeignOrderByBookHandler(string strLogInID, bool bAsyncOrder, string strAccount,  string strBookNo, string strExchangeNo);
        public event CancelForeignOrderByBookHandler OnCancelForeignOrderByBookSignal;

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
        public ForeignStockOrderControl()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        private void btnSendForeignStockOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇複委託帳號");
                return;
            }

            string strStockNo;
            string strExchangeNo = "";
            string strPrice;
            string strCurrency1;
            string strCurrency2;
            string strCurrency3;
            int nBidAsk;
            int nAccountType;
            int nQty;

            if (boxAccountType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇專戶別");
                return;
            }
            nAccountType = boxAccountType.SelectedIndex + 1;

            if (boxBidAsk.SelectedIndex == 0 && boxCurrency1.SelectedIndex < 0)
            {
                MessageBox.Show("買單請至少選擇扣款幣別 1");
                return;
            }
            strCurrency1 = boxCurrency1.Text;
            strCurrency2 = boxCurrency2.Text;
            strCurrency3 = boxCurrency3.Text;

            if (boxExchange.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇交易所");
                return;
            }
            if (boxExchange.SelectedIndex == 0)
            {
                strExchangeNo = "US";
            }

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strStockNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

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
            
            FOREIGNORDER pForeignOrder = new FOREIGNORDER();

            pForeignOrder.bstrFullAccount   = m_UserAccount;
            pForeignOrder.bstrStockNo       = strStockNo;
            pForeignOrder.bstrExchangeNo    = strExchangeNo;
            pForeignOrder.bstrPrice         = strPrice;
            pForeignOrder.bstrCurrency1     = strCurrency1;
            pForeignOrder.bstrCurrency2     = strCurrency2;
            pForeignOrder.bstrCurrency3     = strCurrency3;
            pForeignOrder.sBuySell          = (short)nBidAsk;
            pForeignOrder.nAccountType      = nAccountType;
            pForeignOrder.nQty              = nQty;
            
            if (OnForeignOrderSignal != null)
            {
                OnForeignOrderSignal(m_UserID, false, pForeignOrder);
            }
        }

        private void btnSendForeignStockOrderAsync_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇複委託帳號");
                return;
            }

            string strStockNo;
            string strExchangeNo = "";
            string strPrice;
            string strCurrency1;
            string strCurrency2;
            string strCurrency3;
            int nBidAsk;
            int nAccountType;
            int nQty;

            if (boxAccountType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇專戶別");
                return;
            }
            nAccountType = boxAccountType.SelectedIndex + 1;

            if (boxBidAsk.SelectedIndex == 0 && boxCurrency1.SelectedIndex < 0)
            {
                MessageBox.Show("買單請至少選擇扣款幣別 1");
                return;
            }
            strCurrency1 = boxCurrency1.Text;
            strCurrency2 = boxCurrency2.Text;
            strCurrency3 = boxCurrency3.Text;

            if (boxExchange.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇交易所");
                return;
            }
            if (boxExchange.SelectedIndex == 0)
            {
                strExchangeNo = "US";
            }

            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strStockNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

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

            FOREIGNORDER pForeignOrder = new FOREIGNORDER();

            pForeignOrder.bstrFullAccount = m_UserAccount;
            pForeignOrder.bstrStockNo = strStockNo;
            pForeignOrder.bstrExchangeNo = strExchangeNo;
            pForeignOrder.bstrPrice = strPrice;
            pForeignOrder.bstrCurrency1 = strCurrency1;
            pForeignOrder.bstrCurrency2 = strCurrency2;
            pForeignOrder.bstrCurrency3 = strCurrency3;
            pForeignOrder.sBuySell = (short)nBidAsk;
            pForeignOrder.nAccountType = nAccountType;
            pForeignOrder.nQty = nQty;

            if (OnForeignOrderSignal != null)
            {
                OnForeignOrderSignal(m_UserID, true, pForeignOrder);
            }
        }

        private void btnCancelForeignOrderBySeqNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇複委託帳號");
                return;
            }

            string strExchangeNo = "";
            if (boxCancelExchange.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇交易所");
                return;
            }
            if (boxCancelExchange.SelectedIndex == 0)
            {
                strExchangeNo = "US";
            }
            if (OnCancelForeignOrderBySeqSignal != null)
            {
                OnCancelForeignOrderBySeqSignal(m_UserID, true, m_UserAccount, txtCancelSeqNo.Text.Trim(), strExchangeNo);
            }
        }

        private void btnCancelForeignOrderByBookNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇複委託帳號");
                return;
            }

            string strExchangeNo = "";
            if (boxCancelExchange.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇交易所");
                return;
            }
            if (boxCancelExchange.SelectedIndex == 0)
            {
                strExchangeNo = "US";
            }
            if (OnCancelForeignOrderByBookSignal != null)
            {
                OnCancelForeignOrderByBookSignal(m_UserID, true, m_UserAccount, txtCancelBookNo.Text.Trim(), strExchangeNo);
            }
        }
        #endregion
    }
}
