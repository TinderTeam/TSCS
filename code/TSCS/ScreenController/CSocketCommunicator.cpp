#include "StdAfx.h"
#include "CSocketCommunicator.h"
#include "StringUtil.h"
#include "Log.h"

CSocketCommunicator::CSocketCommunicator(void)
{
}

CSocketCommunicator::~CSocketCommunicator(void)
{
}

bool CSocketCommunicator::connectServer(std::string & ipAddr,int port)
{
	WORD wVersionRequested;
    WSADATA wsaData;
    int err;
 
    wVersionRequested = MAKEWORD( 1, 1 );
 
    err = WSAStartup( wVersionRequested, &wsaData );
    if ( err != 0 ) 
	{
       return false;
    }
 
    if ( LOBYTE( wsaData.wVersion ) != 1 ||HIBYTE( wsaData.wVersion ) != 1 ) 
	{
       WSACleanup( );
       return false;
    }
     this->sockClient=socket(AF_INET,SOCK_STREAM,0);
 
 
	 this->addrSrv.sin_addr.S_un.S_addr=inet_addr(ipAddr.c_str());
     this->addrSrv.sin_family=AF_INET;
     this->addrSrv.sin_port=htons(port);
     err = connect(this->sockClient,(SOCKADDR*)&this->addrSrv,sizeof(SOCKADDR));
	 if(0 > err)
	 {
		 return false;
	 }

	 timeval timeOut;
	 timeOut.tv_sec = TIME_OUT;
	 timeOut.tv_usec = 0;
 	 setsockopt(this->sockClient,SOL_SOCKET,SO_RCVTIMEO,(char *)&timeOut,sizeof(struct timeval)); 
   
     //recv(sockClient,this->recvBuf,50,0);
 

     return true;
}

bool CSocketCommunicator::sendData(char* data,int length)
{
	LOG_INFO("send data is:");
	LOG_INFO(StringUtil::convertToIntString(data,length).c_str());
	int err = send(this->sockClient,data,length+1,0);
	if(err < 0)
	{
		return false;
	}
	return true;
}

bool CSocketCommunicator::receiveData(char* data,int length)
{

	int err = recv(sockClient,data,length,0);
	if(err < 0)
	{
		LOG_ERROR("receive data error");
		return false;
	}
	LOG_INFO("recieve data is:");
	LOG_INFO(StringUtil::convertToIntString(data,length).c_str());
	return true; 
}

void CSocketCommunicator::closeConnect(void)
{
     closesocket(this->sockClient);
     WSACleanup();

}