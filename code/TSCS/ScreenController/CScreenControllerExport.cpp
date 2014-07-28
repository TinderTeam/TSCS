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
	bool result = CInstanceFactory::getInstance()->getController()->initScreen();
	
	return result;
}

CSCREENCONTROLLER_API void closeConnect()
{

	CInstanceFactory::getInstance()->getController()->closeConnect();
}

CSCREENCONTROLLER_API char * getScreenName()
{

	std::string str = CInstanceFactory::getInstance()->getController()->getScreenName();

	char* chars;
	const int len = str.length();
	chars = new char[len+1];
	strcpy(chars,str.c_str());

	return chars;
}

CSCREENCONTROLLER_API bool setScreenName(char * name)
{
	if(NULL == name)
	{
		LOG_ERROR("null point of screen name");
		return false;
	}
	bool result = CInstanceFactory::getInstance()->getController()->setScreenName(std::string(name));
	return result;
}

CSCREENCONTROLLER_API bool getRoadInfo(ROAD_INFO raodInfo[],int length)
{

	bool result = CInstanceFactory::getInstance()->getController()->getRoadInfo(raodInfo,length);
	return result;
}

CSCREENCONTROLLER_API bool setRoadInfo(ROAD_INFO raodInfo[],int length)
{
	bool result = CInstanceFactory::getInstance()->getController()->setRoadInfo(raodInfo,length);
	return result;
}

CSCREENCONTROLLER_API bool setScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{
    bool result = CInstanceFactory::getInstance()->getController()->getScreenLight(lightInfo);

	return result;

}

CSCREENCONTROLLER_API bool getScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{
    bool result = CInstanceFactory::getInstance()->getController()->getScreenLight(lightInfo);

	return result;
}



CSCREENCONTROLLER_API int getScreenColor(void)
{
	int color = CInstanceFactory::getInstance()->getController()->getScreenColor();
	return color;
}

CSCREENCONTROLLER_API bool setScreenColor(int color)
{
	bool result = CInstanceFactory::getInstance()->getController()->setScreenColor(color);
	return result;
}

CSCREENCONTROLLER_API bool setScreenDisp(SEGMENT_INFO segmentInfo[],int length)
{
	   std::string segmentInfoStr;
	   for(int i=0;i<length;i++)
	   {
		   SEGMENT_INFO segment = segmentInfo[i];
		   segmentInfoStr.push_back(segment.segNum);
		   segmentInfoStr.push_back(segment.roadNum);
		   segmentInfoStr.push_back(segment.color);
		   segmentInfoStr.push_back(segment.startAddr/256);
		   segmentInfoStr.push_back(segment.startAddr%256);
		   segmentInfoStr.push_back(segment.endAddr/256);
		   segmentInfoStr.push_back(segment.endAddr%256);
	   }
       bool result = CInstanceFactory::getInstance()->getController()->setScreenDisp(segmentInfoStr);
	   return result;
}


CSCREENCONTROLLER_API bool setScreenIpAddr(char * ipAddr)
{
	bool result = CInstanceFactory::getInstance()->getController()->setScreenIpAddr(std::string(ipAddr));
	return result;
}

CSCREENCONTROLLER_API bool setSegmentColor(int segNum,int color)
{
	bool result = CInstanceFactory::getInstance()->getController()->setSegmentColor(segNum,color);
	return result;
}

CSCREENCONTROLLER_API bool saveScreen(void)
{
	bool result = CInstanceFactory::getInstance()->getController()->saveScreen(true,true);
	return result;
}

CSCREENCONTROLLER_API bool  setScreenOn()
{
	bool result = CInstanceFactory::getInstance()->getController()->setScreenOn();
	return result;
}

CSCREENCONTROLLER_API bool  setScreenOff()
{
	bool result = CInstanceFactory::getInstance()->getController()->setScreenOff();
	return result;
}
// This is the constructor of a class that has been exported.
// see ScreenController.h for the class definition
CScreenControllerExport::CScreenControllerExport()
{
	std::string a;
	return;
}
 
