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
    public partial class SKOOQuote : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        private bool m_bfirst = true;
        private int m_nCode;
        private short m_nQuoteServedr;

        SKCOMLib.SKOOQuoteLib m_SKOOQuoteLib = null;
        public SKOOQuoteLib SKOOQuoteLib
        {
            get { return m_SKOOQuoteLib; }
            set { m_SKOOQuoteLib = value; }
        }

        private DataTable m_dtBest5Ask;
        private DataTable m_dtBest5Bid;
        private DataTable m_dtForeigns;

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public SKOOQuote()
        {
            InitializeComponent();

            m_nQuoteServedr = 0;
        }

        private void SKOOQuote_Load(object sender, EventArgs e)
        {
            m_dtForeigns = CreateStocksDataTable();
            m_dtBest5Ask = CreateBest5AskTable();
            m_dtBest5Bid = CreateBest5AskTable();

            SetDoubleBuffered(gridStocks);
        }

        #endregion


        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_bfirst == true)
            {
                m_SKOOQuoteLib.OnConnect += new _ISKOOQuoteLibEvents_OnConnectEventHandler(m_SKOOQuoteLib_OnConnect);
                m_SKOOQuoteLib.OnProducts += new _ISKOOQuoteLibEvents_OnProductsEventHandler(m_SKOOQuoteLib_OnProducts);
                m_SKOOQuoteLib.OnNotifyQuote += new _ISKOOQuoteLibEvents_OnNotifyQuoteEventHandler(m_SKOOQuoteLib_OnNotifyQuote);
                m_SKOOQuoteLib.OnNotifyTicks += new _ISKOOQuoteLibEvents_OnNotifyTicksEventHandler(m_SKOOQuoteLib_OnNotifyTicks);
                m_SKOOQuoteLib.OnNotifyHistoryTicks += new _ISKOOQuoteLibEvents_OnNotifyHistoryTicksEventHandler(m_SKOOQuoteLib_OnNotifyHistoryTicks);
                m_SKOOQuoteLib.OnNotifyBest5 += new _ISKOOQuoteLibEvents_OnNotifyBest5EventHandler(m_SKOOQuoteLib_OnNotifyBest5);

                m_bfirst = false;
            }

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_EnterMonitor();

            SendReturnMessage("SKOOQuoteLib_EnterMonitor");
        }

 

        
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_LeaveMonitor();

            SendReturnMessage("SKOOQuoteLib_LeaveMonitor");
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            listProducts.Items.Clear();
            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_RequestProducts();

            SendReturnMessage("SKOOQuoteLib_RequestProducts");
        }

        private void btnQueryStocks_Click(object sender, EventArgs e)
        {
            m_dtForeigns.Clear();
            gridStocks.ClearSelection();

            gridStocks.DataSource = m_dtForeigns;

            gridStocks.Columns["m_sStockidx"].Visible = false;
            gridStocks.Columns["m_sDecimal"].Visible = false;
            gridStocks.Columns["m_nDenominator"].Visible = false;
            gridStocks.Columns["m_cMarketNo"].Visible = false;
            gridStocks.Columns["m_caExchangeNo"].HeaderText = "交易所代碼";
            gridStocks.Columns["m_caExchangeName"].HeaderText = "交易所名稱";
            gridStocks.Columns["m_caStockNo"].HeaderText = "商品代碼";
            gridStocks.Columns["m_caStockName"].HeaderText = "商品名稱";
            gridStocks.Columns["m_caStockName"].Width = 170;

            gridStocks.Columns["m_nOpen"].HeaderText = "開盤價";
            gridStocks.Columns["m_nHigh"].HeaderText = "最高價";
            gridStocks.Columns["m_nLow"].HeaderText = "最低價";
            gridStocks.Columns["m_nClose"].HeaderText = "成交價";
            gridStocks.Columns["m_dSettlePrice"].HeaderText = "結算價";
            gridStocks.Columns["m_nTickQty"].HeaderText = "單量";
            gridStocks.Columns["m_nRef"].HeaderText = "昨收價";

            gridStocks.Columns["m_nBid"].HeaderText = "買價";
            gridStocks.Columns["m_nBc"].HeaderText = "買量";
            gridStocks.Columns["m_nAsk"].HeaderText = "賣價";
            gridStocks.Columns["m_nAc"].HeaderText = "賣量";
            gridStocks.Columns["m_nTQty"].HeaderText = "成交量";

            short sPageNo ;

            if (short.TryParse(txtOOQuotePage.Text.ToString(), out sPageNo) == false)
                sPageNo = -1;

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_RequestStocks(ref sPageNo, txtStocks.Text.Trim());

            txtOOQuotePage.Text = sPageNo.ToString();

            SendReturnMessage("SKOOQuoteLib_RequestStocks");
        }

        private void btnTicks_Click(object sender, EventArgs e)
        {
            listTicks.Items.Clear();
            m_dtBest5Ask.Clear();
            m_dtBest5Bid.Clear();

            gridBest5Bid.DataSource = m_dtBest5Bid;
            gridBest5Ask.DataSource = m_dtBest5Ask;

            gridBest5Ask.Columns["m_nAskQty"].HeaderText = "張數";
            gridBest5Ask.Columns["m_nAskQty"].Width = 60;
            gridBest5Ask.Columns["m_nAsk"].HeaderText = "賣價";
            gridBest5Ask.Columns["m_nAsk"].Width = 60;

            gridBest5Bid.Columns["m_nAskQty"].HeaderText = "張數";
            gridBest5Bid.Columns["m_nAskQty"].Width = 60;
            gridBest5Bid.Columns["m_nAsk"].HeaderText = "買價";
            gridBest5Bid.Columns["m_nAsk"].Width = 60;

            short sPageNo;

            if (short.TryParse(txtOOTickPage.Text.ToString(), out sPageNo) == false)
                sPageNo = -1;

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_RequestTicks(ref sPageNo, txtTick.Text.ToString().Trim());

            txtOOTickPage.Text = sPageNo.ToString();

            SendReturnMessage("SKOOQuoteLib_RequestStocks");
        }


        #endregion

        #region COM Event
        //----------------------------------------------------------------------
        // COM Event
        //----------------------------------------------------------------------
        void m_SKOOQuoteLib_OnConnect(int nCode, int nSocketCode)
        {
            if (nCode == 3001 && nSocketCode == 0)
            {
                lblSignal.ForeColor = Color.Green;
            }
            else
            {
                lblSignal.ForeColor = Color.Red;
            }
        }

        void m_SKOOQuoteLib_OnProducts(string bstrValue)
        {
            listProducts.Items.Add(bstrValue);
        }

        void m_SKOOQuoteLib_OnNotifyQuote(short sIndex)
        {
            SKFOREIGN pForeign = new SKFOREIGN();

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_GetStockByIndex(sIndex, ref pForeign);

            SKFOREIGN pForeign2 = new SKFOREIGN();
            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_GetStockByNo(pForeign.bstrExchangeNo + "," + pForeign.bstrStockNo, ref pForeign2);

            OnUpDateDataQuote(pForeign);      
        }

        private void gridStocks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);

                if (e.Value != null)
                {
                    string strHeaderText = ((DataGridView)sender).Columns[e.ColumnIndex].HeaderText.ToString();

                    int nDenominator = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["m_nDenominator"].Value.ToString());

                    if (strHeaderText == "名稱")
                    {
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.SkyBlue, e.CellBounds.X, e.CellBounds.Y);
                    }
                    else if (strHeaderText == "買價" || strHeaderText == "賣價" || strHeaderText == "成交價" || strHeaderText == "開盤價" || strHeaderText == "最高價" || strHeaderText == "最低價" || strHeaderText == "昨收價")
                    {
                        double dPrc = double.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["m_nRef"].Value.ToString());

                        double dValue = double.Parse(e.Value.ToString());

                        string strCellValue = "";


                        if (nDenominator > 1)
                        {
                            string strValue = e.Value.ToString();

                            if (strValue.IndexOf('.') > -1)
                            {
                                int nValue1 = int.Parse(strValue.Substring(0, strValue.IndexOf('.')));

                                double dValue2 = double.Parse(strValue.Substring(strValue.IndexOf('.'), (strValue.Length - strValue.IndexOf('.'))));

                                strCellValue = nValue1.ToString() + "'" + (dValue2 * nDenominator).ToString("#0.##");
                            }
                        }
                        else
                        {
                            strCellValue = e.Value.ToString();
                        }

                        if (dValue > dPrc)
                        {
                            e.Graphics.DrawString(strCellValue, e.CellStyle.Font, Brushes.Red, e.CellBounds.X, e.CellBounds.Y);

                        }
                        else if (dValue < dPrc)
                        {
                            e.Graphics.DrawString(strCellValue, e.CellStyle.Font, Brushes.Lime, e.CellBounds.X, e.CellBounds.Y);
                        }
                        else
                        {
                            e.Graphics.DrawString(strCellValue, e.CellStyle.Font, Brushes.White, e.CellBounds.X, e.CellBounds.Y);
                        }
                    }
                    else if (strHeaderText == "單量" || strHeaderText == "成交量")
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
        }


        void m_SKOOQuoteLib_OnNotifyTicks(short sStockIdx, int nPtr, int nTime, int nClose, int nQty)
        {
            string strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + nTime.ToString() + "," + nClose.ToString() + "," + nQty.ToString();

            listTicks.Items.Add(strData);

            listTicks.SelectedIndex = listTicks.Items.Count - 1;
        }

        void m_SKOOQuoteLib_OnNotifyHistoryTicks(short sStockIdx, int nPtr, int nTime, int nClose, int nQty)
        {
            string strData = sStockIdx.ToString() + "," + nPtr.ToString() + "," + nTime.ToString() + "," + nClose.ToString() + "," + nQty.ToString();

            listTicks.Items.Add(strData);

            listTicks.SelectedIndex = listTicks.Items.Count - 1;
        }

        void m_SKOOQuoteLib_OnNotifyBest5(short sStockIdx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5, int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5)
        {
            if (m_dtBest5Ask.Rows.Count == 0 && m_dtBest5Bid.Rows.Count == 0)
            {
                DataRow myDataRow;

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty1;
                myDataRow["m_nAsk"] = nBestAsk1;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty2;
                myDataRow["m_nAsk"] = nBestAsk2;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty3;
                myDataRow["m_nAsk"] = nBestAsk3;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty4;
                myDataRow["m_nAsk"] = nBestAsk4;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty5;
                myDataRow["m_nAsk"] = nBestAsk5;
                m_dtBest5Ask.Rows.Add(myDataRow);



                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty1;
                myDataRow["m_nAsk"] = nBestBid1;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty2;
                myDataRow["m_nAsk"] = nBestBid2;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty3;
                myDataRow["m_nAsk"] = nBestBid3;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty4;
                myDataRow["m_nAsk"] = nBestBid4;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty5;
                myDataRow["m_nAsk"] = nBestBid5;
                m_dtBest5Bid.Rows.Add(myDataRow);

            }
            else
            {
                m_dtBest5Ask.Rows[0]["m_nAskQty"] = nBestAskQty1;
                m_dtBest5Ask.Rows[0]["m_nAsk"] = nBestAsk1;

                m_dtBest5Ask.Rows[1]["m_nAskQty"] = nBestAskQty2;
                m_dtBest5Ask.Rows[1]["m_nAsk"] = nBestAsk2;

                m_dtBest5Ask.Rows[2]["m_nAskQty"] = nBestAskQty3;
                m_dtBest5Ask.Rows[2]["m_nAsk"] = nBestAsk3;

                m_dtBest5Ask.Rows[3]["m_nAskQty"] = nBestAskQty4;
                m_dtBest5Ask.Rows[3]["m_nAsk"] = nBestAsk4;

                m_dtBest5Ask.Rows[4]["m_nAskQty"] = nBestAskQty5;
                m_dtBest5Ask.Rows[4]["m_nAsk"] = nBestAsk5;


                m_dtBest5Bid.Rows[0]["m_nAskQty"] = nBestBidQty1;
                m_dtBest5Bid.Rows[0]["m_nAsk"] = nBestBid1;

                m_dtBest5Bid.Rows[1]["m_nAskQty"] = nBestBidQty2;
                m_dtBest5Bid.Rows[1]["m_nAsk"] = nBestBid2;

                m_dtBest5Bid.Rows[2]["m_nAskQty"] = nBestBidQty3;
                m_dtBest5Bid.Rows[2]["m_nAsk"] = nBestBid3;

                m_dtBest5Bid.Rows[3]["m_nAskQty"] = nBestBidQty4;
                m_dtBest5Bid.Rows[3]["m_nAsk"] = nBestBid4;

                m_dtBest5Bid.Rows[4]["m_nAskQty"] = nBestBidQty5;
                m_dtBest5Bid.Rows[4]["m_nAsk"] = nBestBid5;
            }
        }

        


        #endregion

        #region Custom Method
        //----------------------------------------------------------------------
        // Custom Method
        //----------------------------------------------------------------------

        void SendReturnMessage(string strMessage)
        {
            if (GetMessage != null)
            {
                GetMessage("OOQuote", m_nCode, strMessage);
            }
        }

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

        void OnUpDateDataQuote(SKFOREIGN pForeign)
        {
            short sStockIdx = pForeign.sStockIdx;

            DataRow drFind = m_dtForeigns.Rows.Find(sStockIdx);
            if (drFind == null)
            {
                DataRow myDataRow = m_dtForeigns.NewRow();

                myDataRow["m_sStockidx"] = pForeign.sStockIdx;
                myDataRow["m_sDecimal"] = pForeign.sDecimal;
                myDataRow["m_nDenominator"] = pForeign.nDenominator;
                myDataRow["m_cMarketNo"] = pForeign.bstrMarketNo.Trim();
                myDataRow["m_caExchangeNo"] = pForeign.bstrExchangeNo.Trim();
                myDataRow["m_caExchangeName"] = pForeign.bstrExchangeName.Trim();
                myDataRow["m_caStockNo"] = pForeign.bstrStockNo.Trim();
                myDataRow["m_caStockName"] = pForeign.bstrStockName.Trim() + " " + pForeign.nStrikePrice.ToString() + " " + pForeign.bstrCallPut;

                myDataRow["m_nOpen"] = pForeign.nOpen / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nHigh"] = pForeign.nHigh / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nLow"] = pForeign.nLow / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nClose"] = pForeign.nClose / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_dSettlePrice"] = pForeign.nSettlePrice / (Math.Pow(10, pForeign.sDecimal));

                myDataRow["m_nTickQty"] = pForeign.nTickQty;
                myDataRow["m_nRef"] = pForeign.nRef / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nBid"] = pForeign.nBid / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nBc"] = pForeign.nBc;
                myDataRow["m_nAsk"] = pForeign.nAsk;
                myDataRow["m_nAc"] = pForeign.nAc / (Math.Pow(10, pForeign.sDecimal));
                myDataRow["m_nTQty"] = pForeign.nTQty;

                m_dtForeigns.Rows.Add(myDataRow);
            }
            else
            {
                drFind["m_sStockidx"] = pForeign.sStockIdx;
                drFind["m_sDecimal"] = pForeign.sDecimal;
                drFind["m_nDenominator"] = pForeign.nDenominator;
                drFind["m_cMarketNo"] = pForeign.bstrMarketNo.Trim();
                drFind["m_caExchangeNo"] = pForeign.bstrExchangeNo.Trim();
                drFind["m_caExchangeName"] = pForeign.bstrExchangeName.Trim();
                drFind["m_caStockNo"] = pForeign.bstrStockNo.Trim();
                drFind["m_caStockName"] = pForeign.bstrStockName.Trim() + " " + pForeign.nStrikePrice.ToString() + " " + pForeign.bstrCallPut;

                drFind["m_nOpen"] = pForeign.nOpen / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nHigh"] = pForeign.nHigh / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nLow"] = pForeign.nLow / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nClose"] = pForeign.nClose / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_dSettlePrice"] = pForeign.nSettlePrice / (Math.Pow(10, pForeign.sDecimal));

                drFind["m_nTickQty"] = pForeign.nTickQty;
                drFind["m_nRef"] = pForeign.nRef / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nBid"] = pForeign.nBid / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nBc"] = pForeign.nBc;
                drFind["m_nAsk"] = pForeign.nAsk / (Math.Pow(10, pForeign.sDecimal));
                drFind["m_nAc"] = pForeign.nAc;
                drFind["m_nTQty"] = pForeign.nTQty;
            }
        }

        DataTable CreateStocksDataTable()
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
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nDenominator";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_cMarketNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caExchangeNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caExchangeName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caStockNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caStockName";
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
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_dSettlePrice";
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
            myDataColumn.DataType = Type.GetType("System.Int64");
            myDataColumn.ColumnName = "m_nTQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataTable.PrimaryKey = new DataColumn[] { myDataTable.Columns["m_sStockidx"] };

            return myDataTable;
        }

        private DataTable CreateBest5AskTable()
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

        private void txtTick_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetTick_Click(object sender, EventArgs e)
        {
            short sStockidx;
            int nPtr;

            if (short.TryParse(txtTickStockidx.Text, out sStockidx) == false)
                return;

            if (int.TryParse(txtTickPtr.Text, out nPtr) == false)
                return;

            SKFOREIGNTICK skTick = new SKFOREIGNTICK();

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_GetTick(sStockidx, nPtr, ref skTick);

            SendReturnMessage("SKOOQuoteLib_GetTick");

            if (m_nCode == 0)
            {
                lblGetTick.Text = skTick.nTime.ToString() + "/" + skTick.nClose.ToString() + "/" + skTick.nQty.ToString();
            }
        }

        private void btnGetBest5_Click(object sender, EventArgs e)
        {
            short sStockidx;

            if (short.TryParse(txtBestStockidx.Text, out sStockidx) == false)
                return;

            SKBEST5 skBest5 = new SKBEST5();

            m_nCode = m_SKOOQuoteLib.SKOOQuoteLib_GetBest5(sStockidx, ref skBest5);

            SendReturnMessage("SKOOQuoteLib_GetBest5");

            if (m_nCode == 0)
            {
                lblBest5Bid.Text = skBest5.nBid1.ToString() + "/" + skBest5.nBidQty1.ToString() + " " + skBest5.nBid2.ToString() + "/" + skBest5.nBidQty2.ToString() + " ...";

                lblBest5Ask.Text = skBest5.nAsk1.ToString() + "/" + skBest5.nAskQty1.ToString() + " " + skBest5.nAsk2.ToString() + "/" + skBest5.nAskQty2.ToString() + " ...";
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (m_nQuoteServedr == 0)
            {
                groupBox1.Text = "Server 2";
                m_nQuoteServedr = 1;
            }
            else
            {
                groupBox1.Text = "Server 1";
                m_nQuoteServedr = 0;
            }

            m_SKOOQuoteLib.SKOOQuoteLib_SetQuoteServer(m_nQuoteServedr);
        }

        

        
        
    }
}
