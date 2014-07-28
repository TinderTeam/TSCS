#include "StdAfx.h"
#include "CInstanceFactory.h"

CInstanceFactory* CInstanceFactory::instance=new CInstanceFactory();  


CInstanceFactory::CInstanceFactory(void)
{
   controller = new ControllerInterface();
   Log::instance().open_log();
   LOG_WARN("system start now");
 
}

CInstanceFactory::~CInstanceFactory(void)
{
 
	delete controller;
	delete instance; 

}


CInstanceFactory* CInstanceFactory::getInstance()
{
   return instance;
}

ControllerInterface* CInstanceFactory::getController()
{

	return controller;
}

CDataProtocol CInstanceFactory::getDataProtocol()
{

	return dataProtocol;
}

 