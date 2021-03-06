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

bool ControllerInterface::connectScreen(std::string ipAddr)
{
	
	LOG_INFO("connect to screen,the ip address is: ");
	LOG_INFO(ipAddr.c_str());

	bool result = this->communicator.connectServer(ipAddr,SOCKET_PORT);
	this->connected = result;
    return result;
}

void ControllerInterface::closeConnect()
{
	this->communicator.closeConnect();
	
}


bool ControllerInterface::initScreen(void)
{
	std::string sendData;

	sendData = this->makeSendData(CMD_INIT,"");
 
	 
	bool result =this->sendCmd(sendData);

	return result;
}

bool ControllerInterface::setScreenName(std::string name)
{
	 
	//get the description from screen
	std::string str = getScreenDesp();

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
	std::string sendData = makeSendData(CMD_SET_DESP,desp);
 
	bool result =this->sendCmd(sendData);

	return result;
}
std::string ControllerInterface::getScreenName()
{
	std::string str = getScreenDesp();

	std::vector< std::string> nameList = StringUtil::split(str,std::string(SPLIT_FLAG));

	str = nameList[0];
	return str;
}

bool ControllerInterface::getRoadInfo(ROAD_INFO roadInfo[],int length)
{
	std::string str = getScreenDesp();

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
	return true;
}

bool ControllerInterface::setRoadInfo(ROAD_INFO roadInfo[],int length)
{
	std::string str = getScreenDesp();

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
	std::string sendData = makeSendData(CMD_SET_DESP,desp);

	bool result =this->sendCmd(sendData);

	return true;
}


std::string ControllerInterface::getScreenDesp()
{
 
	std::string sendData = makeSendData(CMD_GET_DESP,"");
 

	std::string revData;
	bool result = this->getData(sendData,revData);
 
	return revData;
}

bool ControllerInterface::setScreenColor(int color)
{
 

	//send the description to screen
	std::string data;
	data.push_back((char)color);
	std::string sendData = makeSendData(CMD_SET_YS,data);

	bool result =this->sendCmd(sendData);

	return result;
}
int ControllerInterface::getScreenColor()
{

	std::string sendData = makeSendData(CMD_GET_YS,"");
	std::string revData;
	this->getData(sendData,revData);

	int color = -1;
    if(!revData.empty())
	{
      color = revData[0];

	}
	
	return color;
}
bool ControllerInterface::setScreenDisp(std::string segment)
{
	
	std::string sendData = makeSendData(CMD_SET_DESP,segment);

	bool result =this->sendCmd(sendData);
	if(!result)
	{
		LOG_ERROR("send display data failed");
		return result;
	}
	result = this->saveScreen(true,false);

	return result;


}

bool ControllerInterface::setScreenIpAddr(std::string ipAddr)
{
	std::vector< std::string>  ipList = StringUtil::split(ipAddr,std::string(IP_SPLIT_FLAG));

	std::vector<std::string>::iterator iter = ipList.begin();
	
	std::string data;
	for(;iter != ipList.begin();iter++)
	{
	   int temp = atoi(iter->c_str());
       data.push_back(char(temp));
	}

	std::string sendData = makeSendData(CMD_SET_IP,data);
	bool result =this->sendCmd(sendData);

	return result;


}
bool ControllerInterface::setSegmentColor(int segNum,int color)
{
	std::string data;
	data.push_back(segNum);
	data.push_back(color);
    std::string sendData = makeSendData(CMD_SET_LD,data);
	bool result =this->sendCmd(sendData);

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

	std::string sendData = makeSendData(CMD_SET_UPDATE,data);

	bool result =this->sendCmd(sendData);

	return result;
}

bool ControllerInterface::setScreenOn(void)
{

	std::string data;
	data.push_back(2);

	std::string sendData = makeSendData(CMD_SET_DESP,data.c_str());

	bool result =this->sendCmd(sendData);

	return result;


}
bool ControllerInterface::setScreenOff(void)
{

	std::string data;
	data.push_back(1);

	std::string sendData = makeSendData(CMD_SET_DESP,data);

	bool result =this->sendCmd(sendData);

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

bool ControllerInterface::sendCmd(std::string sendData)
{
	std::string revData;

	bool result = getData(sendData,revData);

	if(!result)
	{
        return result;
	}
 
	//if return ok, send success

	return result;

}
bool ControllerInterface::getData(std::string sendData,std::string revData)
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
	}
	 

	result = CInstanceFactory::getInstance()->getDataProtocol().decode(rawData,revData);

	return result;
}