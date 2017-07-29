# CapitalApiPY
群益Api_2.1.3.6 Python 串接範例

	Last Modified 2017/07/29
	V_0.0.0.1
	適用Python 版本：3.5.2 |Anaconda custom (64-bit)|

目錄結構簡介：

[lib]

	nPython.exe : Python DotNet執行檔，測試時請把python exe 環境指到此目錄下的 nPython.exe
	如果是其他Python 版本，請至 https://github.com/pythonnet/pythonnet 自行編譯成需要的版本 
	(在project property e.g.改成 PYTHON2;PYTHON27;UCS2)  
	
  	SKCOMTester.exe  : 實際運行python時調用，內容物跟群益給的 2.1.3.6 範例相似，
	只是大部分的 Member 被我改成了Public
	額外增加了以下兩個監聽消息的方法讓Python這邊收聽：
	SendReturnMessageINT_PY (監聽都是int的回傳消息)
	SendReturnMessageSTR_PY (監聽都是string的回傳消息，如果有混合的一律轉成Str)
	修改過的Code都放在 SKCOMTester 目錄，皆有標註 Kang Added
	

[CapitalPYClass] 

	
	eventEngine.py : vnpy 的事件引擎主體，一行未改
	
	eventType.py : 定義自己的Event名稱，這裡目前只有把群益 Quote Demo 的Event 加進去
	
	SKPY.py  : python 的Api串接主體，在這邊定義Event 的轉發，主要內容引用了 vn.py 
	(http://www.vnpy.org/) 的事件引擎，讓Capital傳來的事件進入 Queue隊列避免阻塞
	
	UserInfo.cfg : 在這裡改上自己的帳號 & 密碼

執行方法：
	
	lib/Startup.bat 
	
目前進度：

	目前完成：收到Initialize之後開始接收 TX00 的 History Ticks，並在event隊列上把收到的Tick
	列印出來
	ToDo : 繼續完成 OnReply SendOrder 等細節完善
	
