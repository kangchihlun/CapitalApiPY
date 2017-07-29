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
    public partial class SKQuote : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------
        public bool m_bfirst = true;
        public int m_nCode;
        public int m_nSimulateStock;
        public int m_nCount = 0;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        // Kang Added
        public delegate void SKPYIntMsgHdl(string strType,List<int> anyValue);
        public event SKPYIntMsgHdl GetIntMessagePY;

        public delegate void SKPYStrMsgHdl(string strType, List<string> anyValue);
        public event SKPYStrMsgHdl GetStrMessagePY;

        public SKCOMLib.SKQuoteLib m_SKQuoteLib = null;
        public SKQuoteLib SKQuoteLib
        {
            get { return m_SKQuoteLib; }
            set { m_SKQuoteLib = value; }
        }

        public string m_strLoginID = "";
        public string LoginID
        {
            get { return m_strLoginID; }
            set
            {
                m_strLoginID = value;
            }
        }

        public DataTable m_dtStocks;
        public DataTable m_dtBest5Ask;
        public DataTable m_dtBest5Bid;

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public SKQuote()
        {
            InitializeComponent();
        }

        public void SKQuote_Load(object sender, EventArgs e)
        {
            m_dtStocks = CreateStocksDataTable();
            m_dtBest5Ask = CreateBest5AskTable();
            m_dtBest5Bid = CreateBest5AskTable();

            SetDoubleBuffered(gridStocks);
            chkbox_msms.Checked = true;
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

        // Kang Added
        void SendReturnMessageINT_PY(string strType, List<int> anyValue)
        {
            if (GetIntMessagePY != null)
            {
                GetIntMessagePY(strType, anyValue);
            }
        }

        void SendReturnMessageSTR_PY(string strType, List<string> anyValue)
        {
            if (GetStrMessagePY != null)
            {
                GetStrMessagePY(strType, anyValue);
            }
        }
        // end of Kang Added

        #endregion

        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        public void button1_Click(object sender, EventArgs e)
        {
            if (m_bfirst == true)
            {
                m_SKQuoteLib.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(m_SKQuoteLib_OnConnection);
                m_SKQuoteLib.OnNotifyQuote += new _ISKQuoteLibEvents_OnNotifyQuoteEventHandler(m_SKQuoteLib_OnNotifyQuote);
                m_SKQuoteLib.OnNotifyHistoryTicks  += new _ISKQuoteLibEvents_OnNotifyHistoryTicksEventHandler(m_SKQuoteLib_OnNotifyHistoryTicks); 
                m_SKQuoteLib.OnNotifyTicks  += new _ISKQuoteLibEvents_OnNotifyTicksEventHandler(m_SKQuoteLib_OnNotifyTicks);
                m_SKQuoteLib.OnNotifyBest5 += new _ISKQuoteLibEvents_OnNotifyBest5EventHandler(m_SKQuoteLib_OnNotifyBest5);
                m_SKQuoteLib.OnNotifyKLineData += new _ISKQuoteLibEvents_OnNotifyKLineDataEventHandler(m_SKQuoteLib_OnNotifyKLineData);
                m_SKQuoteLib.OnNotifyServerTime += new _ISKQuoteLibEvents_OnNotifyServerTimeEventHandler(m_SKQuoteLib_OnNotifyServerTime);
                m_SKQuoteLib.OnNotifyMarketTot += new _ISKQuoteLibEvents_OnNotifyMarketTotEventHandler(m_SKQuoteLib_OnNotifyMarketTot);
                m_SKQuoteLib.OnNotifyMarketBuySell += new _ISKQuoteLibEvents_OnNotifyMarketBuySellEventHandler(m_SKQuoteLib_OnNotifyMarketBuySell);
                m_SKQuoteLib.OnNotifyMarketHighLow += new _ISKQuoteLibEvents_OnNotifyMarketHighLowEventHandler(m_SKQuoteLib_OnNotifyMarketHighLow);
                m_SKQuoteLib.OnNotifyMACD += new _ISKQuoteLibEvents_OnNotifyMACDEventHandler(m_SKQuoteLib_OnNotifyMACD);
                m_SKQuoteLib.OnNotifyBoolTunel += new _ISKQuoteLibEvents_OnNotifyBoolTunelEventHandler(m_SKQuoteLib_OnNotifyBoolTunel);
                m_SKQuoteLib.OnNotifyFutureTradeInfo += new _ISKQuoteLibEvents_OnNotifyFutureTradeInfoEventHandler(m_SKQuoteLib_OnNotifyFutureTradeInfo);
                m_SKQuoteLib.OnNotifyStrikePrices += new _ISKQuoteLibEvents_OnNotifyStrikePricesEventHandler(m_SKQuoteLib_OnNotifyStrikePrices);
                m_bfirst = false;
            }
            m_nCode = m_SKQuoteLib.SKQuoteLib_EnterMonitor();
        }

        public void btnDisconnect_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_LeaveMonitor();

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_LeaveMonitor");
        }

        public void btnTicks_Click(object sender, EventArgs e)
        {
            // Kang Added
            //Console.WriteLine("<------- btnTicks_Click Perform Click -------> ");
            //Console.WriteLine("<-------"+ txtTick.Text.Trim() + " -------> ");
            //Console.WriteLine("<-------" + m_SKQuoteLib.ToString() + " -------> ");
            
            //
            listTicks.Items.Clear();
            m_dtBest5Ask.Clear();
            m_dtBest5Bid.Clear();
            GridBest5Ask.DataSource = m_dtBest5Ask;
            GridBest5Bid.DataSource = m_dtBest5Bid;

            GridBest5Ask.Columns["m_nAskQty"].HeaderText = "張數";
            GridBest5Ask.Columns["m_nAskQty"].Width = 60;
            GridBest5Ask.Columns["m_nAsk"].HeaderText = "賣價";
            GridBest5Ask.Columns["m_nAsk"].Width = 60;

            GridBest5Bid.Columns["m_nAskQty"].HeaderText = "張數";
            GridBest5Bid.Columns["m_nAskQty"].Width = 60;
            GridBest5Bid.Columns["m_nAsk"].HeaderText = "買價";
            GridBest5Bid.Columns["m_nAsk"].Width = 60;

            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestTicks(0, txtTick.Text.Trim());

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestTicks");
        }

        public void btnQueryStocks_Click(object sender, EventArgs e)
        {
            short sPage;

            if (short.TryParse(txtPageNo.Text, out sPage) == false)
                return;


            m_dtStocks.Clear();
            gridStocks.ClearSelection();

            gridStocks.DataSource = m_dtStocks;

            gridStocks.Columns["m_sStockidx"].Visible = false;
            gridStocks.Columns["m_sDecimal"].Visible = false;
            gridStocks.Columns["m_sTypeNo"].Visible = false;
            gridStocks.Columns["m_cMarketNo"].Visible = false;
            gridStocks.Columns["m_caStockNo"].HeaderText = "代碼";
            gridStocks.Columns["m_caName"].HeaderText = "名稱";
            gridStocks.Columns["m_nOpen"].HeaderText = "開盤價";
            //gridStocks.Columns["m_nHigh"].Visible = false;
            gridStocks.Columns["m_nHigh"].HeaderText = "最高";
            //gridStocks.Columns["m_nLow"].Visible = false;
            gridStocks.Columns["m_nLow"].HeaderText = "最低";
            gridStocks.Columns["m_nClose"].HeaderText = "成交價";
            gridStocks.Columns["m_nTickQty"].HeaderText = "單量";
            gridStocks.Columns["m_nRef"].HeaderText = "昨收價";
            gridStocks.Columns["m_nBid"].HeaderText = "買價";
            //gridStocks.Columns["m_nBc"].Visible = false;
            gridStocks.Columns["m_nBc"].HeaderText = "買量";
            gridStocks.Columns["m_nAsk"].HeaderText = "賣價";
            //gridStocks.Columns["m_nAc"].Visible = false;
            gridStocks.Columns["m_nAc"].HeaderText = "賣量";
            //gridStocks.Columns["m_nTBc"].Visible = false;
            gridStocks.Columns["m_nTBc"].HeaderText = "買盤量";
            //gridStocks.Columns["m_nTAc"].Visible = false;
            gridStocks.Columns["m_nTAc"].HeaderText = "賣盤量";
            gridStocks.Columns["m_nFutureOI"].Visible = false;
            //gridStocks.Columns["m_nTQty"].Visible = false;
            gridStocks.Columns["m_nTQty"].HeaderText = "總量";
            //gridStocks.Columns["m_nYQty"].Visible = false;
            gridStocks.Columns["m_nYQty"].HeaderText = "昨量";
            //gridStocks.Columns["m_nUp"].Visible = false;
            gridStocks.Columns["m_nUp"].HeaderText = "漲停";
            //gridStocks.Columns["m_nDown"].Visible = false;
            gridStocks.Columns["m_nDown"].HeaderText = "跌停";

            string[] Stocks = txtStocks.Text.Trim().Split(new Char[] { ',' });

            foreach (string s in Stocks)
            {
                SKSTOCK pSKStock = new SKSTOCK();

                int nCode = m_SKQuoteLib.SKQuoteLib_GetStockByNo(s.Trim(), ref pSKStock);

                OnUpDateDataRow(pSKStock);

                if (nCode == 0)
                {
                    OnUpDateDataRow(pSKStock);
                }
            }

            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestStocks(ref sPage, txtStocks.Text.Trim());

            txtPageNo.Text = sPage.ToString();

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestStocks");
        }

        public void btnTickStop_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestTicks(50, txtTick.Text.Trim());

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_CancelRequestTicks");
        }

        public void btnServerTime_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestServerTime();

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestServerTime");
        }

        public void btnGetBest5_Click(object sender, EventArgs e)
        {
            short sMarket;
            short sStockidx;

            if (short.TryParse(txtBestMarket.Text, out sMarket) == false)
                return;

            if (short.TryParse(txtBestStockidx.Text, out sStockidx) == false)
                return;

            SKBEST5 skBest5 = new SKBEST5();

            m_nCode = m_SKQuoteLib.SKQuoteLib_GetBest5(sMarket, sStockidx, ref skBest5);

            if (m_nCode == 0)
            {
                lblBest5Bid.Text = skBest5.nBid1.ToString() + "/" + skBest5.nBidQty1.ToString() + " " + skBest5.nBid2.ToString() + "/" + skBest5.nBidQty2.ToString() + " ...";

                lblBest5Ask.Text = skBest5.nAsk1.ToString() + "/" + skBest5.nAskQty1.ToString() + " " + skBest5.nAsk2.ToString() + "/" + skBest5.nAskQty2.ToString() + " ...";
            }

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_GetBest5");

        }
        public void btnKLine_Click(object sender, EventArgs e)
        {
            listKLine.Items.Clear();
            
            short sKLineType = short.Parse(boxKLine.SelectedIndex.ToString());
            short sOutType = short.Parse(boxOutType.SelectedIndex.ToString());

            if (sKLineType < 0)
                return;

            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestKLine(txtKLine.Text.Trim(), sKLineType, sOutType);

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestKLine");
        }

        public void gridStocks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);

                    if (e.Value != null)
                    {
                        string strHeaderText = ((DataGridView)sender).Columns[e.ColumnIndex].HeaderText.ToString();

                        if (strHeaderText == "名稱")
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.SkyBlue, e.CellBounds.X, e.CellBounds.Y);
                        }
                        else if (strHeaderText == "買價" || strHeaderText == "賣價" || strHeaderText == "成交價" || strHeaderText == "開盤價" || strHeaderText == "最高" || strHeaderText == "最低")
                        {
                            double dPrc = double.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["m_nRef"].Value.ToString());

                            double dValue = double.Parse(e.Value.ToString());

                            if (m_nSimulateStock == 1 && strHeaderText != "開盤價")            //盤前揭示為深灰色;
                                e.Graphics.FillRectangle(Brushes.SlateGray, e.CellBounds);

                            if (dValue > dPrc)
                            {
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Red, e.CellBounds.X, e.CellBounds.Y);
                            }
                            else if (dValue < dPrc)
                            {
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Lime, e.CellBounds.X, e.CellBounds.Y);
                            }
                            else
                            {
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.White, e.CellBounds.X, e.CellBounds.Y);
                            }
                        }
                        else if (strHeaderText == "單量")
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Yellow, e.CellBounds.X, e.CellBounds.Y);
                        }
                        else
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.White, e.CellBounds.X, e.CellBounds.Y);
                        }
                    }
                    e.Handled = true;
                }
                catch (Exception ex)
                {

                }
            }
        }

        #endregion

        #region COM EVENT
        //----------------------------------------------------------------------
        // COM EVENT
        //----------------------------------------------------------------------
        void m_SKQuoteLib_OnConnection(int nKind, int nCode)
        {
            if (nKind == 3001)
            {

                if (nCode == 0)
                {
                    lblSignal.ForeColor = Color.Yellow;
                }
            }
            else if (nKind == 3002)
            {
                lblSignal.ForeColor = Color.Red;
            }
            else if (nKind == 3003)
            {
                lblSignal.ForeColor = Color.Green;
            }
            else if (nKind == 3021)//網路斷線
            {
                lblSignal.ForeColor = Color.DarkRed;                 
            }

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnConnection", new List<int> { nKind, nCode });
        }

        void m_SKQuoteLib_OnNotifyQuote(short sMarketNo, short sStockIdx)
        {
            SKSTOCK pSKStock = new SKSTOCK();
            m_SKQuoteLib.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref pSKStock);
            OnUpDateDataRow(pSKStock);

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyQuote", new List<int> { sMarketNo, sStockIdx });
        }

        
        void m_SKQuoteLib_OnNotifyTicks(short sMarketNo, short sStockIdx, int nPtr, int lTimehms, int lTimemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        {
            string strData = "";
            //string strTimeNoMsMs = "";
            //int nlength = lTime.ToString().Length;
            //if (nlength >6)
            //    strTimeNoMsMs = lTime.ToString().Substring(0, nlength - 6);
            //[-1020-add for h:m:s'millissecond''microsecond][-0219-add Qty-]
            //string strData = nPtr.ToString() + "," + nTime.ToString() + "," + nBid.ToString() + "," + nAsk.ToString() + "," + nClose.ToString() + "," + nQty.ToString();
            if (chkbox_msms.Checked == true)
                strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + lTimehms.ToString() + "," + nBid.ToString() + "," + nAsk.ToString() + "," + nClose.ToString() + "," + nQty.ToString();
            else
                strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + lTimehms.ToString() + " " + lTimemillismicros.ToString() + "," + nBid.ToString() + "," + nAsk.ToString() + "," + nClose.ToString() + "," + nQty.ToString();
            
            //[揭示]//0:一般;1:試算揭示
            if ((chkBoxSimulate.Checked) || (!chkBoxSimulate.Checked && nSimulate == 0))
                listTicks.Items.Add(strData);

            if (listTicks.Items.Count < 200)
                listTicks.SelectedIndex = listTicks.Items.Count - 1;
            else
                listTicks.Items.Clear();

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyTicks", new List<int> { sMarketNo, sStockIdx, nPtr, lTimehms, lTimemillismicros, nBid, nAsk, nClose, nQty, nSimulate });
        }

        void m_SKQuoteLib_OnNotifyHistoryTicks(short sMarketNo, short sStockIdx, int nPtr, int lTimehms, int lTimemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        {
            //[-0219-add Qty-]
            string strData = "";

            if (chkbox_msms.Checked == true)
                strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + lTimehms.ToString() + "," + nBid.ToString() + "," + nAsk.ToString() + "," + nClose.ToString() + "," + nQty.ToString();
            else
                strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + lTimehms.ToString() + " " + lTimemillismicros.ToString() + "," + nBid.ToString() + "," + nAsk.ToString() + "," + nClose.ToString() + "," + nQty.ToString();
                        
            //[揭示]//0:一般;1:試算揭示
            if ((chkBoxSimulate.Checked)   ||(!chkBoxSimulate.Checked && nSimulate == 0))
                listTicks.Items.Add(strData);

            if (listTicks.Items.Count < 200)
                listTicks.SelectedIndex = listTicks.Items.Count - 1;
            else
                listTicks.Items.Clear();


            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyHistoryTicks", new List<int> { sMarketNo, sStockIdx, nPtr, lTimehms, lTimemillismicros, nBid, nAsk, nClose, nQty, nSimulate });

        }

        void m_SKQuoteLib_OnNotifyBest5(short sMarketNo, short sStockIdx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5, int nExtendBid, int nExtendBidQty, int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5, int nExtendAsk, int nExtendAskQty, int nSimulate)
        {
            //0:一般;1:試算揭示
            if (nSimulate == 0)
            {
                GridBest5Ask.ForeColor = Color.Black;
                GridBest5Bid.ForeColor = Color.Black;
            }
            else
            {
                GridBest5Ask.ForeColor = Color.Gray;
                GridBest5Bid.ForeColor = Color.Gray;
            }

            SKSTOCK pSKStock = new SKSTOCK();
            double dDigitNum = 0.000;
            string strStockNoTick = txtTick.Text.Trim();
            int nCode = m_SKQuoteLib.SKQuoteLib_GetStockByNo(strStockNoTick, ref pSKStock);
            //[-1022-a-]
            if (nCode == 0)
                dDigitNum = (Math.Pow(10, pSKStock.sDecimal));
            else
                dDigitNum = 100.00;//default value

            if (m_dtBest5Ask.Rows.Count == 0 && m_dtBest5Bid.Rows.Count == 0)
            {
                DataRow myDataRow;

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty1;
                myDataRow["m_nAsk"] = nBestAsk1 / dDigitNum;///100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty2;
                myDataRow["m_nAsk"] = nBestAsk2 / dDigitNum;//100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty3;
                myDataRow["m_nAsk"] = nBestAsk3 / dDigitNum;//100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty4;
                myDataRow["m_nAsk"] = nBestAsk4 / dDigitNum;// 100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty5;
                myDataRow["m_nAsk"] = nBestAsk5 / dDigitNum;// 100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);



                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty1;
                myDataRow["m_nAsk"] = nBestBid1 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty2;
                myDataRow["m_nAsk"] = nBestBid2 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty3;
                myDataRow["m_nAsk"] = nBestBid3 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty4;
                myDataRow["m_nAsk"] = nBestBid4 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty5;
                myDataRow["m_nAsk"] = nBestBid5 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

            }
            else
            {
                m_dtBest5Ask.Rows[0]["m_nAskQty"] = nBestAskQty1;
                m_dtBest5Ask.Rows[0]["m_nAsk"] = nBestAsk1 / dDigitNum;

                m_dtBest5Ask.Rows[1]["m_nAskQty"] = nBestAskQty2;
                m_dtBest5Ask.Rows[1]["m_nAsk"] = nBestAsk2 / dDigitNum;

                m_dtBest5Ask.Rows[2]["m_nAskQty"] = nBestAskQty3;
                m_dtBest5Ask.Rows[2]["m_nAsk"] = nBestAsk3 / dDigitNum;

                m_dtBest5Ask.Rows[3]["m_nAskQty"] = nBestAskQty4;
                m_dtBest5Ask.Rows[3]["m_nAsk"] = nBestAsk4 / dDigitNum;

                m_dtBest5Ask.Rows[4]["m_nAskQty"] = nBestAskQty5;
                m_dtBest5Ask.Rows[4]["m_nAsk"] = nBestAsk5 / dDigitNum;


                m_dtBest5Bid.Rows[0]["m_nAskQty"] = nBestBidQty1;
                m_dtBest5Bid.Rows[0]["m_nAsk"] = nBestBid1 / dDigitNum;

                m_dtBest5Bid.Rows[1]["m_nAskQty"] = nBestBidQty2;
                m_dtBest5Bid.Rows[1]["m_nAsk"] = nBestBid2 / dDigitNum;

                m_dtBest5Bid.Rows[2]["m_nAskQty"] = nBestBidQty3;
                m_dtBest5Bid.Rows[2]["m_nAsk"] = nBestBid3 / dDigitNum;

                m_dtBest5Bid.Rows[3]["m_nAskQty"] = nBestBidQty4;
                m_dtBest5Bid.Rows[3]["m_nAsk"] = nBestBid4 / dDigitNum;

                m_dtBest5Bid.Rows[4]["m_nAskQty"] = nBestBidQty5;
                m_dtBest5Bid.Rows[4]["m_nAsk"] = nBestBid5 / dDigitNum;
            }

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyBest5", new List<int> { sMarketNo, sStockIdx, nBestBid1, nBestBidQty1, nBestBid2, nBestBidQty2, nBestBid3, nBestBidQty3, nBestBid4, nBestBidQty4, nBestBid5, nBestBidQty5, nExtendBid, nExtendBidQty, nBestAsk1, nBestAskQty1, nBestAsk2, nBestAskQty2, nBestAsk3, nBestAskQty3, nBestAsk4, nBestAskQty4, nBestAsk5, nBestAskQty5, nExtendAsk, nExtendAskQty, nSimulate});
        }

        void m_SKQuoteLib_OnNotifyServerTime(short sHour, short sMinute, short sSecond, int nTotal)
        {
            lblServerTime.Text = sHour.ToString("D2") + ":" + sMinute.ToString("D2") + ":" + sSecond.ToString("D2");

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyServerTime", new List<int> { sHour, sMinute, sSecond, nTotal });
        }

        void m_SKQuoteLib_OnNotifyKLineData(string bstrStockNo, string bstrData)
        {
            listKLine.Items.Add(bstrData);

            //Kang Added
            SendReturnMessageSTR_PY("m_SKQuoteLib_OnNotifyKLineData", new List<string> { bstrStockNo, bstrData});
        }

        void m_SKQuoteLib_OnNotifyMarketTot(short sMarketNo, short sPrt, int nTime, int nTotv, int nTots, int nTotc)
        {
            double dTotv = nTotv / 100.0;

            if (sMarketNo == 0)
            {
                lblTotv.Text = dTotv.ToString() + "(億)";
                lblTots.Text = nTots.ToString() + "(筆)";
                lblTotc.Text = nTotc.ToString() + "(張)";
            }
            else
            {
                lblTotv2.Text = dTotv.ToString() + "(億)";
                lblTots2.Text = nTots.ToString() + "(筆)";
                lblTotc2.Text = nTotc.ToString() + "(張)";
            }

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyMarketTot", new List<int> { sMarketNo, sPrt, nTime, nTotv, nTots, nTotc });
        }

        void m_SKQuoteLib_OnNotifyMarketBuySell(short sMarketNo, short sPrt, int nTime, int nBc, int nSc, int nBs, int nSs)
        {
            if (sMarketNo == 0)
            {
                lbllBc.Text = nBc.ToString() + "(筆)";
                lbllBs.Text = nBs.ToString() + "(張)";
                lbllSc.Text = nSc.ToString() + "(筆)";
                lbllSs.Text = nSs.ToString() + "(張)";
            }
            else
            {
                lbllBc2.Text = nBc.ToString() + "(筆)";
                lbllBs2.Text = nBs.ToString() + "(張)";
                lbllSc2.Text = nSc.ToString() + "(筆)";
                lbllSs2.Text = nSs.ToString() + "(張)";
            }


            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyMarketBuySell", new List<int> { sMarketNo, sPrt, nTime, nBc, nSc, nBs, nSs });

        }

        void m_SKQuoteLib_OnNotifyMarketHighLow(short sMarketNo, short sPrt, int nTime, short sUp, short sDown, short sHigh, short sLow, short sNoChange)
        {
            if (sMarketNo == 0)
            {
                lblsUp.Text = sUp.ToString();
                lblsDown.Text = sDown.ToString();
                lblsHigh.Text = sHigh.ToString();
                lblsLow.Text = sLow.ToString();
                lblsNoChange.Text = sNoChange.ToString();
            }
            else
            {
                lblsUp2.Text = sUp.ToString();
                lblsDown2.Text = sDown.ToString();
                lblsHigh2.Text = sHigh.ToString();
                lblsLow2.Text = sLow.ToString();
                lblsNoChange2.Text = sNoChange.ToString();
            }

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyMarketHighLow", new List<int> { sMarketNo, sPrt, nTime, sUp, sDown, sHigh, sLow, sNoChange });
        }

        void m_SKQuoteLib_OnNotifyMACD(short sMarketNo, short sStockIdx, string bstrMACD, string bstrDIF, string bstrOSC)
        {
            lblMACD.Text = bstrMACD;

            lblDIF.Text = bstrDIF;
            lblOSC.Text = bstrOSC;

            //Kang Added
            SendReturnMessageSTR_PY("m_SKQuoteLib_OnNotifyMACD", new List<string> { sMarketNo.ToString(), sStockIdx.ToString(), bstrMACD, bstrDIF, bstrOSC });
        }

        void m_SKQuoteLib_OnNotifyBoolTunel(short sMarketNo, short sStockIdx, string bstrAVG, string bstrUBT, string bstrLBT)
        {
            lblAVG.Text = bstrAVG;
            lblUBT.Text = bstrUBT;
            lblLBT.Text = bstrLBT;

            //Kang Added
            SendReturnMessageSTR_PY("m_SKQuoteLib_OnNotifyBoolTunel", new List<string> { sMarketNo.ToString(), sStockIdx.ToString(), bstrAVG, bstrUBT, bstrLBT });
        }

        void m_SKQuoteLib_OnNotifyFutureTradeInfo(string bstrStockNo, short sMarketNo, short sStockIdx, int nBuyTotalCount, int  nSellTotalCount, int  nBuyTotalQty, int nSellTotalQty, int  nBuyDealTotalCount,int  nSellDealTotalCount)
        {      
            lblFTIBc.Text = nBuyTotalCount.ToString() ;
            lblFTISc.Text = nSellTotalCount.ToString() ;
            lblFTIBq.Text = nBuyTotalQty.ToString() ;
            lblFTISq.Text = nSellTotalQty.ToString() ;
            lblFTIBDC.Text = nBuyDealTotalCount.ToString() ;
            lblFTISDC.Text =  nSellDealTotalCount.ToString();

            //Kang Added
            SendReturnMessageINT_PY("m_SKQuoteLib_OnNotifyFutureTradeInfo", new List<int> { sMarketNo, sStockIdx, nBuyTotalCount, nSellTotalCount, nBuyTotalQty, nSellTotalQty, nBuyDealTotalCount, nSellDealTotalCount });
        }

        void m_SKQuoteLib_OnNotifyStrikePrices(string bstrOptionData)
        {
            //[-0119-]
            string strData = "";
            strData = bstrOptionData;
            
            listStrikePrices.Items.Add(strData);
            m_nCount++;
            if (listStrikePrices.Items.Count < 200)
                listStrikePrices.SelectedIndex = listStrikePrices.Items.Count - 1;
            else
                listStrikePrices.Items.Clear();


            txt_StrikePriceCount.Text = m_nCount.ToString();

            //Kang Added
            SendReturnMessageSTR_PY("m_SKQuoteLib_OnNotifyStrikePrices", new List<string> { bstrOptionData });
        }


        #endregion

        #region Custom Method
        //----------------------------------------------------------------------
        // Custom Method
        //----------------------------------------------------------------------
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo aProp =
                        typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        public DataTable CreateStocksDataTable()
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sStockidx";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sDecimal";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sTypeNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_cMarketNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caStockNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nOpen";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nHigh";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nLow";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nClose";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTickQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nRef";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nBid";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nBc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nAsk";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nAc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTBc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTAc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nFutureOI";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nYQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nUp";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nDown";
            myDataTable.Columns.Add(myDataColumn);

            myDataTable.PrimaryKey = new DataColumn[] { myDataTable.Columns["m_caStockNo"] };

            return myDataTable;
        }

        public void OnUpDateDataRow(SKSTOCK pStock)
        {

            string strStockNo = pStock.bstrStockNo;

            DataRow drFind = m_dtStocks.Rows.Find(strStockNo);
            if (drFind == null)
            {
                try
                {
                    DataRow myDataRow = m_dtStocks.NewRow();

                    myDataRow["m_sStockidx"] = pStock.sStockIdx;
                    myDataRow["m_sDecimal"] = pStock.sDecimal;
                    myDataRow["m_sTypeNo"] = pStock.sTypeNo;
                    myDataRow["m_cMarketNo"] = pStock.bstrMarketNo;
                    myDataRow["m_caStockNo"] = pStock.bstrStockNo;
                    myDataRow["m_caName"] = pStock.bstrStockName;
                    myDataRow["m_nOpen"] = pStock.nOpen / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nHigh"] = pStock.nHigh / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nLow"] = pStock.nLow / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nClose"] = pStock.nClose / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nTickQty"] = pStock.nTickQty;
                    myDataRow["m_nRef"] = pStock.nRef / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nBid"] = pStock.nBid / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nBc"] = pStock.nBc;
                    myDataRow["m_nAsk"] = pStock.nAsk / (Math.Pow(10, pStock.sDecimal));
                    m_nSimulateStock = pStock.nSimulate;                 //成交價/買價/賣價;揭示
                    myDataRow["m_nAc"] = pStock.nAc;
                    myDataRow["m_nTBc"] = pStock.nTBc;
                    myDataRow["m_nTAc"] = pStock.nTAc;
                    myDataRow["m_nFutureOI"] = pStock.nFutureOI;
                    myDataRow["m_nTQty"] = pStock.nTQty;
                    myDataRow["m_nYQty"] = pStock.nYQty;
                    myDataRow["m_nUp"] = pStock.nUp / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nDown"] = pStock.nDown / (Math.Pow(10, pStock.sDecimal));

                    m_dtStocks.Rows.Add(myDataRow);

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                drFind["m_sStockidx"] = pStock.sStockIdx;
                drFind["m_sDecimal"] = pStock.sDecimal;
                drFind["m_sTypeNo"] = pStock.sTypeNo;
                drFind["m_cMarketNo"] = pStock.bstrMarketNo;
                drFind["m_caStockNo"] = pStock.bstrStockNo;
                drFind["m_caName"] = pStock.bstrStockName;
                drFind["m_nOpen"] = pStock.nOpen / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nHigh"] = pStock.nHigh / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nLow"] = pStock.nLow / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nClose"] = pStock.nClose / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nTickQty"] = pStock.nTickQty;
                drFind["m_nRef"] = pStock.nRef / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nBid"] = pStock.nBid / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nBc"] = pStock.nBc;
                drFind["m_nAsk"] = pStock.nAsk / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nAc"] = pStock.nAc;
                drFind["m_nTBc"] = pStock.nTBc;
                drFind["m_nTAc"] = pStock.nTAc;
                drFind["m_nFutureOI"] = pStock.nFutureOI;
                drFind["m_nTQty"] = pStock.nTQty;
                drFind["m_nYQty"] = pStock.nYQty;
                drFind["m_nUp"] = pStock.nUp / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nDown"] = pStock.nDown / (Math.Pow(10, pStock.sDecimal));
            }
        }

        public DataTable CreateBest5AskTable()
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nAskQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nAsk";
            myDataTable.Columns.Add(myDataColumn);

            return myDataTable;

        }

        #endregion

        public void update_Click(object sender, EventArgs e)
        {
            //m_nCode = m_SKQuoteLib.sk

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_MarketTrading");
        }

        public void btnGetTick_Click(object sender, EventArgs e)
        {
            short sMarket;
            short sStockidx;
            int nPtr;

            if (short.TryParse(txtTickMarket.Text, out sMarket) == false)
                return;

            if (short.TryParse(txtTickStockidx.Text, out sStockidx) == false)
                return;

            if (int.TryParse(txtTickPtr.Text, out nPtr) == false)
                return;

            SKTICK skHistoryTick = new SKTICK();
            m_nCode = m_SKQuoteLib.SKQuoteLib_GetTick(sMarket, sStockidx, nPtr, ref  skHistoryTick);

            if (m_nCode == 0)
            {
                //lblGetTick.Text = skHistoryTick.nTime.ToString() + "/" + skHistoryTick.nBid.ToString() + " " + skHistoryTick.nAsk.ToString() + "/" + skHistoryTick.nClose.ToString() + " ...";
                lblGetTick.Text = skHistoryTick.nTimehms.ToString() + "/" + skHistoryTick.nBid.ToString() + " " + skHistoryTick.nAsk.ToString() + "/" + skHistoryTick.nClose.ToString() + " ...";

            }

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestOneHistoryTick");
        }

        public void button4_Click(object sender, EventArgs e)
        {

            m_nCode = m_SKQuoteLib.SKQuoteLib_GetMarketBuySellUpDown();
            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestMarketBuySellUpDown");
        }

        public void btnGetBool_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestBoolTunel(0, textBool.Text.Trim());
            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestBoolTunel");
        }

        public void btnGetMACD_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestMACD(0, textMACD.Text.Trim());
            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestMACD");
        }

        public void btnCancelBool_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestBoolTunel(50, textBool.Text.Trim());
            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_CancelRequstBoolTunel");
        }

        public void btnCancelMACD_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestMACD(50, textMACD.Text.Trim());
            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_CancelRequstMACD");
        }

        public void Btn_RequestFutureTradeInfo_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestFutureTradeInfo( 0, text_StockNo.Text.Trim());

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestFutureTradeInfo");
        }

        public void btn_cancelFTI_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestFutureTradeInfo(50, text_StockNo.Text.Trim());

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_CancelRequestFutureTradeInfo");
        }

        public void lblSignal_Paint(object sender, PaintEventArgs e)
        {
            if (lblSignal.ForeColor == Color.DarkRed)
                btnDisconnect_Click(this, null);     //Nework is broken收到網路已斷線
        }

        public void GetStrikePrices_Click(object sender, EventArgs e)
        {            
            listStrikePrices.Items.Clear();            

            m_nCode = m_SKQuoteLib.SKQuoteLib_GetStrikePrices();

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_GetStrikePrice");
        }

        public void btnKLineAM_Click(object sender, EventArgs e)
        {
            listKLine.Items.Clear();

            short sKLineType = short.Parse(boxKLine.SelectedIndex.ToString());
            short sOutType = short.Parse(boxOutType.SelectedIndex.ToString());
            short sTradeSession = short.Parse(boxTradeSession.SelectedIndex.ToString());

            if (sKLineType < 0)
                return;

            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestKLineAM(txtKLine.Text.Trim(), sKLineType, sOutType, sTradeSession);

            SendReturnMessage("Quote", m_nCode, "SKQuoteLib_RequestKLineAM");
            //boxTradeSession
        }

        
      
   }   
}