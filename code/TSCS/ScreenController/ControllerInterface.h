#pragma once

#include <string>
#include <vector>
#include "ScreenConstant.h"
#include "CSocketCommunicator.h"

#include "StringUtil.h"

class ControllerInterface
{
public:
	ControllerInterface(void);
	~ControllerInterface(void);

	virtual bool connectScreen(std::string ipAddr);
	virtual void closeConnect(void);

	virtual bool initScreen(void);
	virtual bool setScreenName(std::string name);
	virtual std::string getScreenName();
	virtual bool setScreenColor(int name);
	virtual int getScreenColor();

	virtual bool setScreenDisp(std::string segment);
    virtual bool setScreenOn(void);
	virtual bool setScreenOff(void);
	virtual bool saveScreen(bool update,bool save);

	virtual bool setScreenIpAddr(std::string ipAddr);
	virtual bool setSegmentColor(int segNum,int color);

	virtual bool setRoadInfo(ROAD_INFO raodInfo[],int length);
	virtual bool getRoadInfo(ROAD_INFO raodInfo[],int length);


 
private:
	bool connected;
	CSocketCommunicator communicator;

	bool sendCmd(std::string sendData);
	bool getData(std::string sendData,std::string revData);
	std::string makeSendData(std::string cmdCode, std::string data);
	std::string  getScreenDesp();
};
