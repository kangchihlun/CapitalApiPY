# -*- coding: utf-8 -*-
# Last Modified 2017/07/22
# Author Chih Lun Kang
# https://github.com/kangchihlun

import sys,os
import configparser
import threading
import builtins
import clr
from eventEngine import *
import System
import System.Windows.Forms as WinForm
import datetime
from time import sleep


class SKPYClass():
	def __init__(self,__skform):
		
		self.skForm	= __skform
		# 事件引擎，所有数据都推送到其中，再由事件引擎进行分发
		self.__eventEngine = EventEngine()
		self.__eventEngine.start()       
		
		# 请求编号，由api负责管理
		self.__reqid = 0
		
		# 以下变量用于实现连接和重连后的自动登陆
		self.__userid = ''
		self.__password = ''
		self.__brokerid = ''
		
		# 以下集合用于重连后自动订阅之前已订阅的合约，使用集合为了防止重复
		self.__setSubscribed = set()
		
		# Read Config
		broker ,user , pwd = self.readConfigFile()
		self.__brokerid = broker
		self.__userid = user
		self.__password = pwd
		
		if(not self.__userid):
			WinForm.MessageBox.Show("No Config File Found!")
		
		self.queuedMsg=[]
		self.StartSKCom()
		
		
		
	def StartSKCom(self):
		self.skForm.txtAccount.Text = self.__userid
		self.skForm.txtPassWord.Text = self.__password
		
		# Register Event To Capital SKForm
		self.skForm.skQuote1.GetIntMessagePY += self.HeardMessageAndTransfer
		self.skForm.skQuote1.GetStrMessagePY += self.HeardMessageAndTransfer
		
		# Fake Switch in Case of Performance Issue
		# Used in Transfer SKForm Message
		self.transfer_msg_dict={
			'm_SKQuoteLib_OnConnection':self._sendEvt_SKQuoteLib_OnConnection,
		    'm_SKQuoteLib_OnNotifyQuote':self._sendEvt_SKQuoteLib_OnNotifyQuote,
		    'm_SKQuoteLib_OnNotifyHistoryTicks':self._sendEvt_SKQuoteLib_OnNotifyHistoryTicks,
		    'm_SKQuoteLib_OnNotifyTicks':self._sendEvt_SKQuoteLib_OnNotifyTicks,
		    'm_SKQuoteLib_OnNotifyBest5':self._sendEvt_SKQuoteLib_OnNotifyBest5,
		    'm_SKQuoteLib_OnNotifyKLineData':self._sendEvt_SKQuoteLib_OnNotifyKLineData,
		    'm_SKQuoteLib_OnNotifyServerTime':self._sendEvt_SKQuoteLib_OnNotifyServerTime,
		    'm_SKQuoteLib_OnNotifyMarketTot':self._sendEvt_SKQuoteLib_OnNotifyMarketTot,
		    'm_SKQuoteLib_OnNotifyMarketBuySell':self._sendEvt_SKQuoteLib_OnNotifyMarketBuySell,
		    'm_SKQuoteLib_OnNotifyFutureTradeInfo':self._sendEvt_SKQuoteLib_OnNotifyFutureTradeInfo,
		}
		
		# Register All Event To EventEngine
		self.__eventEngine.register(EVENT_SKQuoteLib_OnConnection, self.m_SKQuoteLib_OnConnection)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyQuote, self.m_SKQuoteLib_OnNotifyQuote)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyHistoryTicks, self.m_SKQuoteLib_OnNotifyHistoryTicks)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyTicks, self.m_SKQuoteLib_OnNotifyTicks)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyBest5, self.m_SKQuoteLib_OnNotifyBest5)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyKLineData, self.m_SKQuoteLib_OnNotifyKLineData)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyServerTime, self.m_SKQuoteLib_OnNotifyServerTime)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyMarketTot, self.m_SKQuoteLib_OnNotifyMarketTot)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyMarketBuySell, self.m_SKQuoteLib_OnNotifyMarketBuySell)
		self.__eventEngine.register(EVENT_SKQuoteLib_OnNotifyFutureTradeInfo, self.m_SKQuoteLib_OnNotifyFutureTradeInfo)
		# Register timer process
		self.__eventEngine.register(EVENT_TIMER, self.onTimer1)

		# Start SK Form
		def showDlg():
			self.skForm.ShowDialog()
			
		thread1 = threading.Thread(target = showDlg)
		thread1.start()
		
		m_nCode = self.skForm.Initialize()
		self.skForm.skQuote1.SKQuote_Load(None,None)
		
		# Start Quote / OSQuote / Order / Reply
		if(m_nCode == 0):
			self.skForm.skQuote1.button1_Click(None,None)
			
		
	#

	
	# Receiver From Capital Form , Transfer Message To Event Engine
	def HeardMessageAndTransfer(self,strType,anyValue):
		# for eventHandler debugging
		# queuedMsg.append( [strType] + anyValue)
		self.transfer_msg_dict[strType](anyValue)
		#WinForm.MessageBox.Show(str(self.transfer_msg_dict[strType])) #ok
	
	# Inner Dictionary Function to transfer message to EvnetEngine
	def _sendEvt_SKQuoteLib_OnConnection(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnConnection)
		event.dict_['nKind'] = int(anyValue[0])
		event.dict_['nCode'] = int(anyValue[1])
		# WinForm.MessageBox.Show( '_sendEvt_SKQuoteLib_OnConnection' +  str(event.dict_)) #ok
		self.__eventEngine.put(event)

	def _sendEvt_SKQuoteLib_OnNotifyQuote(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnNotifyQuote)
		event.dict_['sMarketNo'] = int(anyValue[0])
		event.dict_['sStockIdx'] = int(anyValue[1])
		self.__eventEngine.put(event)

	def _sendEvt_SKQuoteLib_OnNotifyTicks(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnNotifyTicks)
		event.dict_['sMarketNo'] = int(anyValue[0])
		event.dict_['sStockIdx'] = int(anyValue[1])
		event.dict_['nPtr'] = int(anyValue[2])
		event.dict_['lTimehms'] = int(anyValue[3])
		event.dict_['lTimemillismicros'] = int(anyValue[4])
		event.dict_['nBid'] = int(anyValue[5])
		event.dict_['nAsk'] = int(anyValue[6])
		event.dict_['nClose'] = int(anyValue[7])
		event.dict_['nQty'] = int(anyValue[8])
		event.dict_['nSimulate'] = int(anyValue[9])
		self.__eventEngine.put(event)

	def _sendEvt_SKQuoteLib_OnNotifyHistoryTicks(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnNotifyHistoryTicks)
		event.dict_['sMarketNo'] = int(anyValue[0])
		event.dict_['sStockIdx'] = int(anyValue[1])
		event.dict_['nPtr'] = int(anyValue[2])
		event.dict_['lTimehms'] = int(anyValue[3])
		event.dict_['lTimemillismicros'] = int(anyValue[4])
		event.dict_['nBid'] = int(anyValue[5])
		event.dict_['nAsk'] = int(anyValue[6])
		event.dict_['nClose'] = int(anyValue[7])
		event.dict_['nQty'] = int(anyValue[8])
		event.dict_['nSimulate'] = int(anyValue[9])
		self.__eventEngine.put(event)

	def _sendEvt_SKQuoteLib_OnNotifyBest5(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnNotifyHistoryTicks)
		event.dict_['sMarketNo'] = int(anyValue[0])
		event.dict_['sStockIdx'] = int(anyValue[1])
		event.dict_['nBestBid1'] = int(anyValue[2])
		event.dict_['nBestBidQty1'] = int(anyValue[3])
		event.dict_['nBestBid2'] = int(anyValue[4])
		event.dict_['nBestBidQty2'] = int(anyValue[5])
		event.dict_['nBestBid3'] = int(anyValue[6])	
		event.dict_['nBestBidQty3'] = int(anyValue[7])
		event.dict_['nBestBid4'] = int(anyValue[8])
		event.dict_['nBestBidQty4'] = int(anyValue[9])
		event.dict_['nBestBid5'] = int(anyValue[10])
		event.dict_['nBestBidQty5'] = int(anyValue[11])
		event.dict_['nExtendBid'] = int(anyValue[12])
		event.dict_['nExtendBidQty'] = int(anyValue[13])
		event.dict_['nBestAsk1'] = int(anyValue[14])
		event.dict_['nBestAskQty1'] = int(anyValue[15])
		event.dict_['nBestAsk2'] = int(anyValue[16])
		event.dict_['nBestAskQty2'] = int(anyValue[17])
		event.dict_['nBestAsk3'] = int(anyValue[19])
		event.dict_['nBestAskQty3'] = int(anyValue[20])
		event.dict_['nBestAsk4'] = int(anyValue[21])
		event.dict_['nBestAskQty4'] = int(anyValue[22])
		event.dict_['nBestAsk5'] = int(anyValue[23])
		event.dict_['nBestAskQty5'] = int(anyValue[24])
		event.dict_['nExtendAsk'] = int(anyValue[25])
		event.dict_['nExtendAskQty'] = int(anyValue[26])
		event.dict_['nSimulate'] = int(anyValue[27])
		
	def _sendEvt_SKQuoteLib_OnNotifyKLineData(self,anyValue):
		event = Event(_type_ = EVENT_SKQuoteLib_OnNotifyHistoryTicks)
		event.dict_['sMarketNo'] = int(anyValue[0])
		event.dict_['sStockIdx'] = int(anyValue[1])
		event.dict_['nBestBid1'] = int(anyValue[2])		
		pass
	def _sendEvt_SKQuoteLib_OnNotifyServerTime(self,anyValue):
		pass
	def _sendEvt_SKQuoteLib_OnNotifyMarketTot(self,anyValue):
		pass
	def _sendEvt_SKQuoteLib_OnNotifyMarketBuySell(self,anyValue):
		pass
	def _sendEvt_SKQuoteLib_OnNotifyFutureTradeInfo(self,anyValue):
		pass

	#	End of Inner Dictionary Function


	# FAKE COM EVENTS [Message Interpretation]	
	# Registered Event Process
	def m_SKQuoteLib_OnConnection(self,event):
		nKind = int(event.dict_['nKind'])
		nCode = int(event.dict_['nCode'])
		#
		#print(" < ====== m_SKQuoteLib_OnConnection ====== >" + str(event.dict_['nKind']) +'/' + str(event.dict_['nCode']))
		if (nKind == 3001):
			if (nCode == 0):
				
				# Test to auto tick get
				#WinForm.MessageBox.Show(" < ====== m_SKQuoteLib_OnConnection ====== >" + str(event.dict_['nKind']) +'/' + str(event.dict_['nCode']))
				print(" < ====== m_SKQuoteLib_OnConnection ====== >" + str(event.dict_['nKind']) +'/' + str(event.dict_['nCode']))
				sleep(4.5)
				self.skForm.skQuote1.txtTick.Text = "TX00"
				self.skForm.skQuote1.btnTicks_Click(None,None)
				
		elif(nKind == 3002):
			pass
		elif (nKind == 3003):
			pass
		elif (nKind == 3021):#網路斷線
			print("Unconnected!")
		
	def m_SKQuoteLib_OnNotifyQuote(self,event):
		sMarketNo = int(event.dict_['sMarketNo'])
		sStockIdx = int(event.dict_['sStockIdx'])
		pSKStock = SKSTOCK()
		#self.m_SKQuoteLib.SKQuoteLib_GetStockByIndex(sMarketNo,sStockIdx,pSKStock)

	def m_SKQuoteLib_OnNotifyHistoryTicks(self,event):
		sMarketNo = int(event.dict_['sMarketNo'])
		sStockIdx = int(event.dict_['sStockIdx'])
		nPtr = int(event.dict_['nPtr'])
		lTimehms = int(event.dict_['lTimehms'])
		lTimemillismicros = int(event.dict_['lTimemillismicros'])
		nBid = int(event.dict_['nBid'])
		nAsk = int(event.dict_['nAsk'])
		nClose = int(event.dict_['nClose'])
		nQty = int(event.dict_['nQty'])
		nSimulate = int(event.dict_['nSimulate'])
		
		strData = 'm_SKQuoteLib_OnNotifyHistoryTicks -->' + str(sMarketNo) + "," + str(sStockIdx) + "," + str(nBid) + "," + str(nAsk)
		print(strData)		

	def m_SKQuoteLib_OnNotifyTicks(self,event):
		sMarketNo = int(event.dict_['sMarketNo'])
		sStockIdx = int(event.dict_['sStockIdx'])
		nPtr = int(event.dict_['nPtr'])
		lTimehms = int(event.dict_['lTimehms'])
		lTimemillismicros = int(event.dict_['lTimemillismicros'])
		nBid = int(event.dict_['nBid'])
		nAsk = int(event.dict_['nAsk'])
		nClose = int(event.dict_['nClose'])
		nQty = int(event.dict_['nQty'])
		nSimulate = int(event.dict_['nSimulate'])
		
		strData = 'SKQuoteLib_OnNotifyTicks ->' + str(sMarketNo) + "," + str(sStockIdx) + "," + str(nBid) + "," + str(nAsk)
		print()

	def m_SKQuoteLib_OnNotifyBest5(self,event):
		sMarketNo = int(event.dict_['sMarketNo'])
		sStockIdx = int(event.dict_['sStockIdx'])
		nBestBid1 = int(event.dict_['nBestBid1'])
		nBestBidQty1 = int(event.dict_['nBestBidQty1'])
		nBestBid2 = int(event.dict_['nBestBid2'])
		nBestBidQty2 = int(event.dict_['nBestBidQty2'])
		nBestBid3 = int(event.dict_['nBestBid3'])
		nBestBidQty3 = int(event.dict_['nBestBidQty3'])
		nBestBid4 = int(event.dict_['nBestBid4'])
		nBestBidQty4 = int(event.dict_['nBestBidQty4'])
		nBestBid5 = int(event.dict_['nBestBid5'])
		nBestBidQty5 = int(event.dict_['nBestBidQty5'])
		nExtendBid = int(event.dict_['nExtendBid'])
		nExtendBidQty = int(event.dict_['nExtendBidQty'])
		nBestAsk1 = int(event.dict_['nBestAsk1'])
		nBestAskQty1 = int(event.dict_['nBestAskQty1'])
		nBestAsk2 = int(event.dict_['nBestAsk2'])
		nBestAskQty2 = int(event.dict_['nBestAskQty2'])
		nBestAsk3 = int(event.dict_['nBestAsk3'])
		nBestAskQty3 = int(event.dict_['nBestAskQty3'])
		nBestAsk4 = int(event.dict_['nBestAsk4'])
		nBestAskQty4 = int(event.dict_['nBestAskQty4'])
		nBestAsk5 = int(event.dict_['nBestAsk5'])
		nBestAskQty5 = int(event.dict_['nBestAskQty5'])
		nExtendAsk = int(event.dict_['nExtendAsk'])
		nExtendAskQty = int(event.dict_['nExtendAskQty'])
		nSimulate = int(event.dict_['nSimulate'])
		
		strData = 'SKQuoteLib_OnNotifyBest5 ->' + str(sMarketNo) + "," + str(sStockIdx) + "," + str(nBestBid1) + "," + str(nBestAsk1)
		print(strData)

	def m_SKQuoteLib_OnNotifyKLineData(self,bstrStockNo, bstrData):
		print(strData)
	def m_SKQuoteLib_OnNotifyServerTime(self,sHour,sMinute,sSecond,nTotal):
		strData = str(sHour) + ":" + str(sMinute)+ ":" + str(sSecond)
		#print(strData)

	def m_SKQuoteLib_OnNotifyMarketTot(self,sMarketNo, sPrt, nTime, nTotv, nTots, nTotc):
		dTotv = str(nTotv / 100.0)
		strData = dTotv + "(億)"
		strData += str(nTots) + "(筆)"
		strData += str(nTotc) + "(張)"
		print(strData)

	def m_SKQuoteLib_OnNotifyMarketBuySell(self,sMarketNo, sPrt, nTime, nBc, nSc, nBs, nSs):
		strData = str(nBc) + "(筆)"
		strData += str(nBs) + "(張)"
		strData += str(nSc) + "(筆)"
		strData += str(nSs) + "(張)"
		print(strData)

	def m_SKQuoteLib_OnNotifyFutureTradeInfo(self,bstrStockNo, sMarketNo, sStockIdx, nBuyTotalCount, nSellTotalCount, nBuyTotalQty, nSellTotalQty, nBuyDealTotalCount, nSellDealTotalCount):
		strData = str(nBuyTotalCount)
		strData += str(nSellTotalCount)
		strData += str(nBuyTotalQty)
		strData += str(nSellTotalQty)
		strData += str(nBuyDealTotalCount)
		strData += str(nSellDealTotalCount)
		print(strData)

	def onTimer1(self, event):
		dt = datetime.datetime.now()
		print(dt)
		WinForm.MessageBox.Show(" < ====== on timer ====== >" + dt )
		
		

	# 	End of Event Engine Process
	
	
	# ################################# #
	# 		Class General Functions
	# ################################# #
	def readConfigFile(self):
		
		curConfigPath = ''	
		configPath = os.path.dirname(os.path.abspath(__file__))
		configPath2 = os.getcwd()
		if(os.path.exists(configPath)):
			curConfigPath = configPath
		elif(os.path.exists(configPath2)):
			curConfigPath = configPath2
		
		if(not os.path.exists(curConfigPath)):
			return None,None,None
		
		# Read Config
		curConfigPath += '\\UserInfo.cfg'
		config = configparser.ConfigParser()
		if(not os.path.exists(curConfigPath)):
			return None,None,None
		
		res = None
		try:res = config.read(curConfigPath)
		except:pass
		if(not res):
			return None,None,None
		
		return	config['USERINFO']['BROKERID'],\
			    config['USERINFO']['USERID'],\
			    config['USERINFO']['PASSWORD']
				
		
	def RequestTick(self,prodArr = []):
		for st_prod in prodArr:
			m_nCode = self.m_SKQuoteLib.SKQuoteLib_RequestTicks(0,st_prod)

	def QueryStocks(self,prodArr = []):
		for st_prod in prodArr:
			pSKStock = ""
			nCode = self.m_SKQuoteLib.SKQuoteLib_GetStockByNo(s.Trim(), pSKStock);
			m_nCode = m_SKQuoteLib.SKQuoteLib_RequestStocks(sPage, st_prod);

	def Disconnect(self):
		m_nCode = self.m_SKQuoteLib.SKQuoteLib_LeaveMonitor()
	



'''
Test code
'''
# capitalSK = SKPYClass()

