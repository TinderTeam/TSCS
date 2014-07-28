#pragma once

#include "ControllerInterface.h"
#include "CDataProtocol.h"
#include "Log.h"

class CInstanceFactory
{
public:
	
	~CInstanceFactory(void);
	 static CInstanceFactory* getInstance();
	 ControllerInterface* getController();
	 CDataProtocol getDataProtocol();

private:
	CInstanceFactory(void);
	static CInstanceFactory * instance;
	ControllerInterface * controller;
	CDataProtocol dataProtocol;
 
};
