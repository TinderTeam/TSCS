// ScreenController.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "CScreenControllerExport.h"
#include "CInstanceFactory.h"

// This is an example of an exported function.
CSCREENCONTROLLER_API int fnScreenController(void)
{
	return 42;
}

CSCREENCONTROLLER_API bool connectScreen(char * ipAddr)
{
	LOG_INFO("connectScreen");
	if(NULL == ipAddr)
	{
		LOG_ERROR("null point of ipAddr");
		return false;
	}
	bool result = CInstanceFactory::getInstance()->getController()->connectScreen(std::string(ipAddr));
	
	return result;
}

 


CSCREENCONTROLLER_API bool initScreen()
{
	LOG_INFO("initScreen");
	bool result = CInstanceFactory::getInstance()->getController()->initScreen();
	
	//LOG_INFO(StringUtil::addToString("init screen result is ",result).c_str());
 
	return result;
}

CSCREENCONTROLLER_API void closeConnect()
{
	LOG_INFO("closeConnect");

	CInstanceFactory::getInstance()->getController()->closeConnect();


}
 


CSCREENCONTROLLER_API char * getScreenCS()
{
	LOG_INFO("getScreenName");
	std::string str;
	bool result = CInstanceFactory::getInstance()->getController()->getScreenCS(str);


	if(!result)
	{
		str = std::string("");
		LOG_ERROR("can not get the screen name");
	}

	const int len = str.length();
	char * name = new char[len+1];
	strcpy(name,str.c_str());
	LOG_INFO("get the screen is ");
	LOG_INFO(name);
	return name;
}

CSCREENCONTROLLER_API bool setScreenCS(char * cs)
{
	LOG_INFO("setScreenName");
	if(NULL == cs)
	{
		LOG_ERROR("null point of screen name");
		return false;
	}
	LOG_INFO("the screen cs to set is ");
	LOG_INFO(cs);
	bool result = CInstanceFactory::getInstance()->getController()->setScreenCS(std::string(cs));

	//LOG_INFO(StringUtil::addToString("set screen name result is ",result).c_str());

	return result;
}

 

CSCREENCONTROLLER_API bool setScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{
	LOG_INFO("setScreenLight");
    bool result = CInstanceFactory::getInstance()->getController()->setScreenLight(lightInfo);

	//LOG_INFO(StringUtil::addToString("set screen light result is ",result).c_str());
	
	return result;

}

CSCREENCONTROLLER_API bool getScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{
	LOG_INFO("getScreenLight");
    bool result = CInstanceFactory::getInstance()->getController()->getScreenLight(lightInfo);

	//LOG_INFO(StringUtil::addToString("get screen light result is ",result).c_str());

	return result;
}



CSCREENCONTROLLER_API int getScreenColor(void)
{
	LOG_INFO("getScreenColor");
	int color = CInstanceFactory::getInstance()->getController()->getScreenColor();

	LOG_INFO(StringUtil::addToString("get screen color is ",color).c_str());

	return color;
}

CSCREENCONTROLLER_API bool setScreenColor(int color)
{
	LOG_INFO("setScreenColor");
	LOG_INFO(StringUtil::addToString("set screen color is ",color).c_str());

	bool result = CInstanceFactory::getInstance()->getController()->setScreenColor(color);

	//LOG_INFO(StringUtil::addToString("set screen color result is ",result).c_str());
	
	return result;
}

CSCREENCONTROLLER_API int getScreenLength(void)
{
	LOG_INFO("getScreenLength");
	int length = CInstanceFactory::getInstance()->getController()->getScreenLength();

	//LOG_INFO(StringUtil::addToString("get screen length is ",length).c_str());

	return length;
}

CSCREENCONTROLLER_API bool setScreenLength(int length)
{
	LOG_INFO("setScreenLength");
	LOG_INFO(StringUtil::addToString("set screen length is ",length).c_str());
	bool result = CInstanceFactory::getInstance()->getController()->setScreenLength(length);
	//LOG_INFO(StringUtil::addToString("set screen length result is ",result).c_str());
	return result;
}




CSCREENCONTROLLER_API bool setScreenDisp(SEGMENT_INFO segmentInfo[],int length,int screenColor)
{
	   LOG_INFO("setScreenDisp");
 
       bool result = CInstanceFactory::getInstance()->getController()->setScreenDisp(segmentInfo,length,screenColor);

	   	//LOG_INFO(StringUtil::addToString("set screen display result is ",result).c_str());

	   return result;
}

CSCREENCONTROLLER_API bool getScreenDisp(SEGMENT_INFO segmentInfo[],int length)
{
	LOG_INFO("getScreenDisp");

	bool result = CInstanceFactory::getInstance()->getController()->getScreenDisp(segmentInfo,length);

	//LOG_INFO(StringUtil::addToString("set screen display result is ",result).c_str());

	return result;
}



CSCREENCONTROLLER_API bool setScreenIpAddr(char * ipAddr,char * macAddr)
{
	LOG_INFO("setScreenIpAddr");
	if(NULL == ipAddr || NULL == macAddr)
	{
		LOG_ERROR("null point of screen ip Address or mac Address ");
		return false;
	}
	bool result = CInstanceFactory::getInstance()->getController()->setScreenIpAddr(std::string(ipAddr),std::string(macAddr));

	//LOG_INFO(StringUtil::addToString("set ip address result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API bool getSegmentColor(int segNum,SEGMENT_INFO & segmentInfo)
{
	LOG_INFO("getSegmentColor");
	bool result = CInstanceFactory::getInstance()->getController()->getSegmentColor(segNum,segmentInfo);
	//LOG_INFO(StringUtil::addToString("set segment color result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API bool setSegmentColor(int segNum,int color)
{
	LOG_INFO("setSegmentColor");
	bool result = CInstanceFactory::getInstance()->getController()->setSegmentColor(segNum,color);
	//LOG_INFO(StringUtil::addToString("set segment color result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API bool setSegmentColorByAddr(int roadNum,int startAddr,int endAddr,int color)
{
	LOG_INFO("setSegmentColorByAddr");
	bool result = CInstanceFactory::getInstance()->getController()->setSegmentColorByAddr(roadNum,startAddr,endAddr,color);
	//LOG_INFO(StringUtil::addToString("set segment color result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API bool getSegmentByAddr(int segNum,int color)
{
	LOG_INFO("setSegmentColor");
	bool result = CInstanceFactory::getInstance()->getController()->setSegmentColor(segNum,color);
	//LOG_INFO(StringUtil::addToString("set segment color result is ",result).c_str());
	return result;
}


CSCREENCONTROLLER_API bool saveScreen(void)
{

	LOG_INFO("saveScreen");
	bool result = CInstanceFactory::getInstance()->getController()->saveScreen(true,true);

	//LOG_INFO(StringUtil::addToString("save Screen result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API bool  setScreenOn()
{

	LOG_INFO("setScreenOn");
	 
	bool result = CInstanceFactory::getInstance()->getController()->setScreenOn();
     
	return result;
}

CSCREENCONTROLLER_API bool  setScreenOff()
{
	LOG_INFO("setScreenOff");
	bool result = CInstanceFactory::getInstance()->getController()->setScreenOff();
	
	//LOG_INFO(StringUtil::addToString("set Screen off result is ",result).c_str());
	return result;
}

CSCREENCONTROLLER_API int getScreenOnOff()
{
	LOG_INFO("getScreenOnOff");
	int status = CInstanceFactory::getInstance()->getController()->getScreenOnOff();
	
	return status;
}

// This is the constructor of a class that has been exported.
// see ScreenController.h for the class definition
CScreenControllerExport::CScreenControllerExport()
{
	std::string a;
	return;
}
 
