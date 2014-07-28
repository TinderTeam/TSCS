#include "StdAfx.h"
#include "CDataProtocol.h"





CDataProtocol::CDataProtocol(void)
{
}

CDataProtocol::~CDataProtocol(void)
{
}

bool CDataProtocol::encode(std::string  rawData,std::string encodeData)
{
 
	for(int i=0;i<DATA_START_FLAG_LENGTH;i++)
	{
		encodeData.push_back(DATA_START_FLAG[i]);
	}

    encodeData.append(rawData);

	unsigned short crcCode = calCRC16(rawData);

	encodeData.push_back((char)(crcCode/256));
	encodeData.push_back((char)(crcCode%256));

	for(int i=0;i<DATA_END_FLAG_LENGTH;i++)
	{
		encodeData.push_back(DATA_END_FLAG[i]);
	}


	return true;
}

bool CDataProtocol::decode(std::string rawData,std::string decodeData)
{
	int length = rawData.length() - DATA_START_FLAG_LENGTH - CRC_LENGTH - DATA_END_FLAG_LENGTH;

	for(int i=0;i<length;i++)
	{

		decodeData[i] = rawData[DATA_START_FLAG_LENGTH+i];
	}

	return true;
}

unsigned short CDataProtocol::calCRC16(std::string rawData)
{
	unsigned short crc = (short) 0xFFFF; 
	int i = 0;

	while (i < rawData.length())
	{
		for (int j = 0; j < 8; j++)
		{
			bool c15 = ((crc >> 15 & 1) == 1);
			bool bit = ((rawData[i] >> (7 - j) & 1) == 1);
			crc <<= 1;
			if (c15 ^ bit)
				crc ^= 0x1021; 
		}
		i++;
	}
	return crc;
}