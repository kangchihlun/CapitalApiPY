# -*- coding: utf-8 -*-
# Last Modified 2017/07/22
# Author Chih Lun Kang
# https://github.com/kangchihlun

import sys,os
import builtins
import clr


clr.AddReference("System")
clr.AddReference("System.Windows.Forms")
import System
import System.Windows.Forms as WinForm
asm = System.Reflection.Assembly
asm = asm.LoadWithPartialName("PresentationFramework") # 載入所需的dll
#import System.Windows
Assembly = System.Reflection.Assembly
skExePath = os.getcwd()+"\\SKCOMTester.exe"
if(not os.path.exists(skExePath)):
	skExePath = os.getcwd()+"\\CapitalApi_2.13.6_PYT\\CapitalApiPY35\\CapitalApiPY\\lib\\SKCOMTester.exe"
Assembly.LoadFrom( skExePath )
import SKCOMTester as skTest
skForm = skTest.Form1()

def HeardIt(strType,anyValue):
	# for eventHandler debugging
	# queuedMsg.append( [strType] + anyValue)
	WinForm.MessageBox.Show("Heard Message")
#skForm.skQuote1.GetIntMessagePY += HeardIt

curModulePath = os.getcwd()+'\\CapitalPYClass'
if(not os.path.exists(curModulePath)):
	curModulePath = os.path.dirname(skExePath) +'\\CapitalPYClass'
if(not curModulePath in sys.path):
	sys.path.append(curModulePath)
from CapitalPYClass import SKPY
skpy = SKPY.SKPYClass(skForm)

