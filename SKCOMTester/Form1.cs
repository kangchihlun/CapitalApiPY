using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKCOMLib;

namespace SKCOMTester
{
    public partial class Form1 : Form
    {
        #region Environment Variable
        //----------------------------------------------------------------------
        // Environment Variable
        //----------------------------------------------------------------------
        int m_nCode;

        public SKCenterLib m_pSKCenter;
        public SKOrderLib m_pSKOrder;
        public SKReplyLib m_pSKReply;
        public SKQuoteLib m_pSKQuote;
        public SKOSQuoteLib m_pSKOSQuote;
        public SKOOQuoteLib m_pSKOOQuote;

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
            m_pSKCenter = new SKCenterLib();            

            m_pSKOrder = new SKOrderLib();
            skOrder1.OrderObj = m_pSKOrder;

            m_pSKReply = new SKReplyLib();
            skReply1.SKReplyLib = m_pSKReply;

            m_pSKQuote = new SKQuoteLib();
            skQuote1.SKQuoteLib = m_pSKQuote;

            m_pSKOSQuote = new SKOSQuoteLib();
            skosQuote1.SKOSQuoteLib = m_pSKOSQuote;

            m_pSKOOQuote = new SKOOQuoteLib();
            skooQuote1.SKOOQuoteLib = m_pSKOOQuote;

            m_pSKCenter.OnShowAgreement += new _ISKCenterLibEvents_OnShowAgreementEventHandler(this.OnShowAgreement);
        }

        #endregion

       
        public void btnInitialize_Click(object sender, EventArgs e)
        {
            //[-for API exam switch-0513-add-]
            if (Chk_Env.Checked == true)
                m_pSKCenter.SKCenterLib_ResetServer("morder1.capital.com.tw");
            
            m_nCode = m_pSKCenter.SKCenterLib_Login(txtAccount.Text.Trim().ToUpper(), txtPassWord.Text.Trim());

            if (m_nCode == 0)
            {
                Console.WriteLine("Successfully login to capital !");
                WriteMessage("登入成功");
                skOrder1.LoginID = txtAccount.Text.Trim().ToUpper();
                skReply1.LoginID = txtAccount.Text.Trim().ToUpper();
                skQuote1.LoginID = txtAccount.Text.Trim().ToUpper();
                skosQuote1.LoginID = txtAccount.Text.Trim().ToUpper();                
            }
            else
                WriteMessage(m_nCode);
        }

        // Kang Modified
        public int Initialize()
        {
            //[-for API exam switch-0513-add-]
            if (Chk_Env.Checked == true)
                m_pSKCenter.SKCenterLib_ResetServer("morder1.capital.com.tw");

            m_nCode = m_pSKCenter.SKCenterLib_Login(txtAccount.Text.Trim().ToUpper(), txtPassWord.Text.Trim());

            if (m_nCode == 0)
            {
                Console.WriteLine("Successfully login to capital !");
                WriteMessage("登入成功");
                skOrder1.LoginID = txtAccount.Text.Trim().ToUpper();
                skReply1.LoginID = txtAccount.Text.Trim().ToUpper();
                skQuote1.LoginID = txtAccount.Text.Trim().ToUpper();
                skosQuote1.LoginID = txtAccount.Text.Trim().ToUpper();
            }
            else
                WriteMessage(m_nCode);
            return m_nCode;
        }


        public void btn_Center_Log_Click(object sender, EventArgs e)
        {
            m_pSKCenter.SKCenterLib_SetLogPath(txt_Center_LogPath.Text.Trim());
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
            listInformation.HorizontalExtent = hzSize;
        }

        public void WriteMessage(int nCode)
        {
            listInformation.Items.Add( m_pSKCenter.SKCenterLib_GetReturnCodeMessage(nCode) );

            listInformation.SelectedIndex = listInformation.Items.Count - 1;

            //listInformation.HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = listInformation.CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listInformation.Items[listInformation.Items.Count - 1].ToString(), listInformation.Font).Width;
            // Set the HorizontalExtent property.
            listInformation.HorizontalExtent = hzSize;
        }

        public void GetMessage(string strType, int nCode, string strMessage)
        {
            string strInfo = "";

            if (nCode != 0)
                strInfo ="【"+ m_pSKCenter.SKCenterLib_GetLastLogInfo()+ "】";

            WriteMessage("【" + strType + "】【" + strMessage + "】【" + m_pSKCenter.SKCenterLib_GetReturnCodeMessage(nCode) + "】" + strInfo);
        }

        void OnShowAgreement(string strData)
        {
            MessageBox.Show(strData);
        }

        // Kang Modified
        #region

        public void onQuoteConnect(string strType, int nCode, string strMessage)
        {
            string strInfo = "";

            if (nCode != 0)
                strInfo = "【" + m_pSKCenter.SKCenterLib_GetLastLogInfo() + "】";

            WriteMessage("【" + strType + "】【" + strMessage + "】【" + m_pSKCenter.SKCenterLib_GetReturnCodeMessage(nCode) + "】" + strInfo);
        }
        #endregion
    }
}
