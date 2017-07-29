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
    public partial class SKReply : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------
        private bool m_bfirst = true;
        private int m_nCode;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        SKCOMLib.SKReplyLib m_SKReplyLib = null;
        public SKReplyLib SKReplyLib
        {
            get { return m_SKReplyLib; }
            set { m_SKReplyLib = value; }
        }

        public string m_strLoginID = "";
        public string LoginID
        {
            get { return m_strLoginID; }
            set 
            { 
                m_strLoginID = value;
                lblConnectID.Text = "ID："+m_strLoginID;
            }
        }

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public SKReply()
        {
            InitializeComponent();
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
        #endregion

        #region COM Event
        //----------------------------------------------------------------------
        // COM Event
        //----------------------------------------------------------------------

        void OnConnect(string strUserID, int nErrorCode)
        {
            lblSignal.ForeColor = Color.Yellow;
        }

        void OnDisconnect(string strUserID, int nErrorCode)
        {
            lblSignal.ForeColor = Color.Red;
        }

        void OnComplete(string strUserID)
        {
            lblSignal.ForeColor = Color.Green;
            lblSignalReplySolace.ForeColor = Color.Green;
            listMessage.Items.Add(" OnComplete :" + strUserID);
            listNewMessage.Items.Add(" OnComplete :" + strUserID);
        }
        void OnData(string strUserID, string strData)
        {
            listMessage.Items.Add("{"+strUserID+"}OnData:"+strData);
        }
        void OnNewData(string strUserID, string strData)
        {
            listNewMessage.Items.Add("{" + strUserID + "}OnNewData:" + strData);
        }

        void m_SKReplyLib_OnReportCount(string bstrUserID, int nCount)
        {
            listMessage.Items.Add("ID：" + bstrUserID + " Count：" + nCount.ToString());
        }

        void OnMessage(string bstrUserId, string bstrMessage)
        {
            listMessage.Items.Add("OnMessage ID：" + bstrUserId + " Message：" + bstrMessage);
        }

        void OnClear(string bstrMarket)
        {
            listMessage.Items.Add("Clear Market：" + bstrMarket);
            listNewMessage.Items.Add("Clear Market：" + bstrMarket);
        }
        void OnSolaceReplyConnection(string bstrUserId, int nCode)
        {
            lblSignal.ForeColor = Color.Yellow;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_bfirst == true)
            {
                m_SKReplyLib.OnConnect += new _ISKReplyLibEvents_OnConnectEventHandler(this.OnConnect);
                m_SKReplyLib.OnDisconnect += new _ISKReplyLibEvents_OnDisconnectEventHandler(this.OnDisconnect);
                m_SKReplyLib.OnComplete += new _ISKReplyLibEvents_OnCompleteEventHandler(this.OnComplete);
                m_SKReplyLib.OnData += new _ISKReplyLibEvents_OnDataEventHandler(this.OnData);
                m_SKReplyLib.OnReportCount += new _ISKReplyLibEvents_OnReportCountEventHandler(m_SKReplyLib_OnReportCount);
                m_SKReplyLib.OnReplyMessage += new _ISKReplyLibEvents_OnReplyMessageEventHandler(this.OnMessage);
                m_SKReplyLib.OnReplyClear += new _ISKReplyLibEvents_OnReplyClearEventHandler(this.OnClear);                
                m_SKReplyLib.OnNewData += new _ISKReplyLibEvents_OnNewDataEventHandler(this.OnNewData);
                m_SKReplyLib.OnSolaceReplyConnection += new _ISKReplyLibEvents_OnSolaceReplyConnectionEventHandler(this.OnSolaceReplyConnection);
                m_bfirst = false;
            }

            int nCode = m_SKReplyLib.SKReplyLib_ConnectByID( m_strLoginID.Trim());

            SendReturnMessage("Reply", nCode, "SKReplyLib_ConnectByID");
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            int nCode = m_SKReplyLib.SKReplyLib_CloseByID(m_strLoginID.Trim());

            SendReturnMessage("Reply", nCode, "SKReplyLib_CloseByID");
        }


    }
}
