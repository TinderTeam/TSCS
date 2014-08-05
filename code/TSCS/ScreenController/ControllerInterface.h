#pragma once

#include <string>
#include <vector>
#include "ScreenConstant.h"
#include "CSocketCommunicator.h"

#include "StringUtil.h"
#include <vector>


class ControllerInterface
{
public:
	ControllerInterface(void);
	~ControllerInterface(void);

	virtual bool connectScreen(std::string & ipAddr);
	virtual void closeConnect(void);

	virtual bool initScreen(void);
	virtual bool setScreenName(std::string & name);
	virtual bool getScreenName(std::string & name);
	virtual bool setScreenColor(int color);
	virtual int  getScreenColor();

	virtual bool setScreenLength(int length);
	virtual int getScreenLength();

	virtual bool setScreenDisp(SEGMENT_INFO segmentInfo[],int length,int screenColor);
    virtual bool setScreenOn(void);
	virtual bool setScreenOff(void);
	virtual bool saveScreen(bool update,bool save);

	virtual bool setScreenIpAddr(std::string & ipAddr,std::string & macAddr);
	virtual bool setSegmentColor(int segNum,int color);

	virtual bool setRoadInfo(ROAD_INFO raodInfo[],int length);
	virtual bool getRoadInfo(ROAD_INFO raodInfo[],int length);
 
	virtual bool setScreenLight(SCREEN_LIGHT_INFO & lightInfo);
	virtual bool getScreenLight(SCREEN_LIGHT_INFO & lightInfo);
 
private:
	bool connected;
	CSocketCommunicator communicator;

	bool sendCmd(std::string cmdcode,std::string  sendData);
	bool getData(std::string & sendData,std::string & revData);
	bool getRecvDataByCmd(std::string cmdCode,std::string& revData);
	std::string makeSendData(std::string cmdCode, std::string  data);
	bool getScreenDesp(std::string & name);
};
