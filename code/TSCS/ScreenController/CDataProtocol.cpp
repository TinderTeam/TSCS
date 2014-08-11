#include "StdAfx.h"
#include "CDataProtocol.h"
#include "Log.h"




CDataProtocol::CDataProtocol(void)
{
}

CDataProtocol::~CDataProtocol(void)
{
}

bool CDataProtocol::encode(std::string & rawData,std::string & encodeData)
{
 
	for(int i=0;i<DATA_START_FLAG_LENGTH;i++)
	{
		encodeData.push_back(DATA_START_FLAG[i]);
	}

    encodeData.append(rawData);

	unsigned short crcCode = CRC16(rawData.c_str(),rawData.length());

	encodeData.push_back((char)(crcCode/256));
	encodeData.push_back((char)(crcCode%256));

	for(int i=0;i<DATA_END_FLAG_LENGTH;i++)
	{
		encodeData.push_back(DATA_END_FLAG[i]);
	}


	return true;
}

bool CDataProtocol::decode(std::string & rawData,std::string & decodeData)
{
	int length = rawData.length() - DATA_START_FLAG_LENGTH - CRC_LENGTH - DATA_END_FLAG_LENGTH;

	if(length <= 0)
	{
		return false;
	}
	for(int i=0;i<length;i++)
	{

		decodeData.push_back(rawData[DATA_START_FLAG_LENGTH+i]);
	}

 
	int crcValue  = rawData[DATA_START_FLAG_LENGTH+length] + rawData[DATA_START_FLAG_LENGTH+length+1];
	
	unsigned short crc = calCRC16(decodeData);
	if(crcValue == crc)
	{
		LOG_ERROR("crc value is wrong");
		return false;
	}

	return true;
}

unsigned short CDataProtocol::calCRC16(std::string & rawData)
{
	//unsigned short crc = (short) 0xFFFF; 
	unsigned short shift = (short) 0xFFFF; 
	unsigned short val = (short) 0xFFFF; 
	unsigned short data = (short) 0xFFFF; 
	int i = 0;

	
	for(i=0;i<rawData.length();i++) {
		if((i % 8) == 0)
			data = (rawData[i])<<8;
		val = shift ^ data;
		shift = shift<<1;
		data = data <<1;
		if(val&0x8000)
			shift = shift ^ 0x1021;
	}
	/*
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

	 
	}*/
	return shift;
}

int  CDataProtocol::calcByte(int crc, char b)
{
	int i;
	crc = crc ^ (int)b << 8;

	for ( i = 0; i < 8; i++)
	{
		if ((crc & 0x8000) == 0x8000)
			crc = crc << 1 ^ 0x1021;
		else
			crc = crc << 1;
	}

	return crc & 0xffff;
}

//count crc-16, length in byte
unsigned short  CDataProtocol::CRC16(const char *pBuffer, int length)
{
	unsigned short wCRC16=0;
	int i;
	if (( pBuffer==0 )||( length==0 ))
	{
		return 0;
	}
	for ( i = 0; i < length; i++)
	{
		wCRC16 = calcByte(wCRC16, pBuffer[i]);
	}
	return wCRC16;
}