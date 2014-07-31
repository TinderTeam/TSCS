#pragma once
#include <string>
#include <stdio.h>
#include <Winsock2.h>
#pragma comment(lib, "ws2_32.lib")

#define TIME_OUT 3000 // data receive time out second
class CSocketCommunicator
{
public:
	CSocketCommunicator(void);
	~CSocketCommunicator(void);
	bool connectServer(std::string & ipAddr, int port);
	bool sendData(char*,int length);
	bool receiveData(char* data,int length);
	void closeConnect(void);

private:
	SOCKET sockClient;
	SOCKADDR_IN addrSrv;
	char recvBuf[512];

};
