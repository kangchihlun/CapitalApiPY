# CapitalApiPY
群益Api_2.1.3.6 Python 串接範例


Last Modified 2017/07/29


V_0.0.0.1


適用Python 版本：3.5.2 |Anaconda custom (64-bit)|


目錄結構簡介：


[lib]

	內有Python DotNet執行檔，測試時請把python exe 環境指到此目錄下的 nPython.exe
	如果是其他Python 版本，請至 https://github.com/pythonnet/pythonnet 自行編譯成需要的版本 
	(在project property 改成 PY_34 or PY_27)  
  	SKCOMTester.exe 實際運行python時調用，內容物跟群益給的 2.1.3.6 範例相似，
	只是大部分的 Member 被我改成了Public
	額外增加了以下兩個監聽消息的方法讓Python這邊收聽：
	SendReturnMessageINT_PY (監聽都是int的回傳消息)
	SendReturnMessageSTR_PY (監聽都是string的回傳消息，如果有混合的一律轉成Str)

[CapitalPYClass] 

	主要內容引用了 vn.py (http://www.vnpy.org/) 的事件引擎，讓Capital傳來的事件進入Queue隊列
	
