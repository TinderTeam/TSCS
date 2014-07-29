#pragma once
#include <string>
#include "ScreenConstant.h"



class CDataProtocol
{
public:

	CDataProtocol(void);
	~CDataProtocol(void);

	bool encode(std::string & rawData,std::string & encodeData);
	bool decode(std::string & rawData,std::string & decodeData);
	unsigned short calCRC16(std::string & rawData);

};
