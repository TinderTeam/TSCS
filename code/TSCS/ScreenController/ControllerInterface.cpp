#include "StdAfx.h"
#include "ControllerInterface.h"
#include "CInstanceFactory.h"

ControllerInterface::ControllerInterface(void)
{
	this->connected = false;
}

ControllerInterface::~ControllerInterface(void)
{

}

bool ControllerInterface::connectScreen(std::string & ipAddr)
{
	
	LOG_INFO("connect to screen,the ip address is: ");
	LOG_INFO(ipAddr.c_str());

	bool result = this->communicator.connectServer(ipAddr,SOCKET_PORT);
	if(result)
	{
		std::string screenName;
		result = this->getScreenName(screenName);
	}
	this->connected = result;
    return result;
}

void ControllerInterface::closeConnect()
{
	this->communicator.closeConnect();
	
}


bool ControllerInterface::initScreen(void)
{ 
	bool result =this->sendCmd(CMD_INIT,"");

	return result;
}

bool ControllerInterface::setScreenName(std::string & name)
{
	 
	//get the description from screen
	std::string str;
	bool result  = getScreenDesp(str);

	std::vector< std::string> nameList;

	if(str.empty())
	{

		LOG_INFO("the screen name is empty");
		nameList.push_back(name);
		
	}
	else
	{
		//modify the description 
		nameList = StringUtil::split(str,std::string(SPLIT_FLAG));
		nameList[0] = name;
	
	}

	std::string desp = StringUtil::convertToStringWithFlag(nameList,std::string(SPLIT_FLAG));
	//send the description to screen
 
 
	result =this->sendCmd(CMD_SET_DESP,desp);

	return result;
}
bool ControllerInterface::getScreenName(std::string & str)
{
	std::string temp;
	bool result  = getScreenDesp(temp);

	if(!result)
	{
		return result;

	}
	std::vector< std::string> nameList = StringUtil::split(temp,std::string(SPLIT_FLAG));

	str = nameList[0];
	return result;
}

bool ControllerInterface::getRoadInfo(ROAD_INFO roadInfo[],int length)
{
	std::string str;
	bool result = getScreenDesp(str);

	std::vector< std::string> nameList = StringUtil::split(str,std::string(SPLIT_FLAG));


	for(int i=1;i<nameList.size();i++)
	{
		if(i<=length)
		{
			roadInfo[i-1].roadNum = i-1;
			strcpy(roadInfo[i-1].roadName,nameList[i].c_str());
			
		}
		else
		{
			LOG_WARN("the road name list size in screen bigger road number.");
		}
       
	}
	return result;
}

bool ControllerInterface::setRoadInfo(ROAD_INFO roadInfo[],int length)
{
	std::string str;
	bool result = getScreenDesp(str);

	std::vector< std::string> nameList;
	if(str.empty())
	{

		nameList.push_back(" ");
	}
	else
	{
       nameList.push_back(StringUtil::split(str,std::string(SPLIT_FLAG))[0]);
	}

	for(int i=0;i<length;i++)
	{
       nameList.push_back(roadInfo[i].roadName);
	}
   
	std::string desp = StringUtil::convertToStringWithFlag(nameList,std::string(SPLIT_FLAG));
	//send the description to screen
	result =this->sendCmd(CMD_SET_DESP,desp);

	return result;
}

bool ControllerInterface::setScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{
	std::string data;
	data.push_back((char)lightInfo.lightCtr);
	data.push_back((char)lightInfo.lightA);
	data.push_back((char)lightInfo.lightB);
	bool result =this->sendCmd(CMD_SET_L,data);
	return result;
}
bool ControllerInterface::getScreenLight(SCREEN_LIGHT_INFO & lightInfo)
{ 

	std::string revData;
	bool result  = getRecvDataByCmd(CMD_GET_L,revData);
 
 
	if(!result)
	{
		LOG_ERROR("get screen light failed");
	}

	if(revData.length()>=3)
	{
		lightInfo.lightCtr = revData[0];
		lightInfo.lightA = revData[1];
		lightInfo.lightB = revData[2];

	}

	return result;
}

bool ControllerInterface::getScreenDesp(std::string & recvData)
{
 
 
	bool result = this->getRecvDataByCmd(CMD_GET_DESP,recvData);
 
	return result;
}

bool ControllerInterface::setScreenColor(int color)
{
 

	//send the description to screen
	std::string data;
	data.push_back((char)color);
	bool result =this->sendCmd(CMD_SET_YS,data);

	return result;
}
int ControllerInterface::getScreenColor()
{
 
	std::string revData;
	this->getRecvDataByCmd(CMD_GET_YS,revData);

	int color = -1;
    if(!revData.empty())
	{
      color = revData[0];

	}
	
	return color;
}

bool ControllerInterface::setScreenLength(int length)
{


	//send the description to screen
	std::string data;
	data.push_back((char)(length/256));
	data.push_back((char)(length%256));
	bool result =this->sendCmd(CMD_SET_SP,data);

	return result;
}
int ControllerInterface::getScreenLength()
{

	std::string revData;
	this->getRecvDataByCmd(CMD_GET_SP,revData);

	int lenght = -1;
	if(revData.length() == 2)
	{
		lenght = revData[1] +  revData[0];

	}

	return lenght;
}

bool ControllerInterface::setScreenDisp(SEGMENT_INFO segmentInfo[],int length)
{
 
	std::vector<std::string> segmentInfoList;

	int packNum = 0;

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
		
		if((length%50) == 0)
		{
		  std::string temp = std::string(segmentInfoStr);
          segmentInfoList.push_back(temp);
		  segmentInfoStr.clear();
		}
		
	}
	segmentInfoList.push_back(segmentInfoStr);
   
	std::vector<std::string>::iterator iter = segmentInfoList.begin();
	bool result;
	for(;iter != segmentInfoList.end();iter++)
	{ 
		bool result =this->sendCmd(CMD_SET_DISP,*iter);
		if(!result)
		{
			LOG_ERROR("send one packet failed");
			return result;
		}
	}

	if(!result)
	{
		LOG_ERROR("send display data failed");
		return result;
	}
	result = this->saveScreen(true,false);

	return result;


}

bool ControllerInterface::setScreenIpAddr(std::string & ipAddr)
{
	std::vector< std::string>  ipList = StringUtil::split(ipAddr,std::string(IP_SPLIT_FLAG));

	std::vector<std::string>::iterator iter = ipList.begin();
	
	std::string data;
	for(;iter != ipList.begin();iter++)
	{
	   int temp = atoi(iter->c_str());
       data.push_back(char(temp));
	}


	bool result =this->sendCmd(CMD_SET_IP,data);

	return result;


}
bool ControllerInterface::setSegmentColor(int segNum,int color)
{
	std::string data;
	data.push_back(segNum);
	data.push_back(color);
 
	bool result =this->sendCmd(CMD_SET_LD,data);

	return result;
}
bool ControllerInterface::saveScreen(bool update,bool save)
{
	std::string data;
	if(update)
	{
	  data.push_back((char)1);
	}
	else
	{
      data.push_back((char)0);
	}
	if(save)
	{
	  data.push_back((char)1);
	}
	else
	{
	  data.push_back((char)0);
	}

 
	bool result =this->sendCmd(CMD_SET_UPDATE,data);

	return result;
}

bool ControllerInterface::setScreenOn(void)
{

	std::string data;
	data.push_back(2);

	bool result =this->sendCmd(CMD_SET_ON_OFF,data);

	return result;


}
bool ControllerInterface::setScreenOff(void)
{

	std::string data;
	data.push_back(1);
 
	bool result =this->sendCmd(CMD_SET_ON_OFF,data);

	return result;


}


std::string ControllerInterface::makeSendData(std::string cmdCode,std::string data)
{
   std::string  sendData;
 

   sendData.push_back(data.length()/256);
   sendData.push_back(data.length()%256);

   for(int i=0;i<RESERVE_LENGTH;i++)
   {
       sendData.push_back(0);
   }

   for(int i=0;i<CMD_CODE_LENGTH;i++)
   {
	   sendData.push_back(cmdCode[i]);
   }

   sendData.append(data);

   return sendData;
}

bool ControllerInterface::getRecvDataByCmd(std::string cmdCode,std::string & revData)
{
	LOG_INFO("get data by command code");
	LOG_INFO(cmdCode.c_str());
	std::string sendData = makeSendData(cmdCode,"");

	std::string temp;
	bool result = this->getData(sendData,temp);

	for(int i=DATA_FIXED_LENGTH;i<temp.length();i++)
	{
        revData.push_back(temp[i]);
	}

	return result;

}

bool ControllerInterface::sendCmd(std::string cmdCode,std::string  data)
{
	LOG_INFO("set data by command code");
	LOG_INFO(cmdCode.c_str());


	std::string sendData = makeSendData(cmdCode,data);
	
	std::string revData;

	bool result = getData(sendData,revData);

	if(!result)
	{
        return result;
	}
 
	//if return ok, send success

	return result;

}
bool ControllerInterface::getData(std::string & sendData,std::string & revData)
{
 

	std::string encodeData;
	//encode the data
	int encodeLength = CInstanceFactory::getInstance()->getDataProtocol().encode(sendData,encodeData);

	
	//send get data command
	char dataBuf[DATA_MAX_LENGTH];
	for(int i=0;i<encodeData.length();i++)
	{
		dataBuf[i] = encodeData[i];
	}
	bool result = this->communicator.sendData(dataBuf,encodeData.length());

	if(!result)
	{
        LOG_ERROR("send data failed");
		return result;
	}

	//read data from socket

	for(int i = 0;i<DATA_MAX_LENGTH;i++)
	{
        dataBuf[i] = 0;
	}
	
	result = this->communicator.receiveData(dataBuf,DATA_MAX_LENGTH);

	if(!result)
	{
		LOG_ERROR("receive data failed");
		return result;
	}

	//decode the data
	std::string rawData;
	for(int i=0;i<DATA_MAX_LENGTH;i++)
	{
		rawData.push_back(dataBuf[i]);
		int index = rawData.find(DATA_END_FLAG);
		if(index != -1)
		{
			break;
		}
	}

	int index = rawData.find(DATA_END_FLAG);
	if(index == -1)
	{
		LOG_ERROR("recive data is valid.");
		return false;
	}
	 

	result = CInstanceFactory::getInstance()->getDataProtocol().decode(rawData,revData);

	

	return result;
}