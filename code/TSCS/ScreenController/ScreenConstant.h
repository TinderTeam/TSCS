#ifndef CONTROL_COMMAND_H
#define CONTROL_COMMAND_H


#define CMD_INIT "INIT-"  // ��ʼ��


#define CMD_SET_SP "SE-SP"  //������Ļ����
#define CMD_GET_SP "GE-SP"

#define CMD_SET_DISP "DISP-" //������ʾ����ʾ����
#define CMD_GET_DISP "GDISP"

#define CMD_SET_UPDATE "DIS--"  //��ʾ�洢����


#define CMD_SET_YS "SETYS"  //��������������ɫ:
#define CMD_GET_YS "GETYS"

#define CMD_SET_LD "SETLD"  //��������·������
#define CMD_GET_LD "GETLD"

#define CMD_SET_L "SET-L"  //���������ȿ��Ʒ�ʽ�����ȵȼ�
#define CMD_GET_L "GET-L"

#define CMD_SET_ON_OFF "SOnof"  //���������   

#define CMD_SET_DESP "SetCS"  //������Ŀ��Ϣλ����Ϣ(��Ļ����)
#define CMD_GET_DESP "GetCS"  //������Ŀ��Ϣλ����Ϣ(��Ļ����)

#define CMD_SET_IP "XG-IP"  //����IP��ַ

#define SPLIT_FLAG  ";"
#define IP_SPLIT_FLAG  "."
#define MAC_SPLIT_FLAG  "-"

#define DATA_BYTES_NUM_LENGTH 2
#define RESERVE_LENGTH 4
#define CMD_CODE_LENGTH 5

#define DATA_FIXED_LENGTH (DATA_BYTES_NUM_LENGTH+RESERVE_LENGTH+CMD_CODE_LENGTH)


#define SOCKET_PORT 6000

#define DATA_MAX_LENGTH  512

#define DATA_START_FLAG_LENGTH   5
#define DATA_END_FLAG_LENGTH   5
const char DATA_START_FLAG[DATA_START_FLAG_LENGTH] ={0x5a,0x53,0x5a,0x4d,0x2d};
const char DATA_END_FLAG[DATA_END_FLAG_LENGTH] ={0x17,0x17,0x17,0x17,0x17};

#define CRC_LENGTH   2

#define DESP_LENGTH 128
#define ROAD_NUM 10

typedef struct       
{     
	int roadNum;     
	int segNum;     
	int color;     
	int startAddr;     
	int endAddr;     
}SEGMENT_INFO; 


typedef struct       
{     
	int roadNum;     
	char roadName[128];     
}ROAD_INFO; 

typedef struct       
{   
	int lightCtr;      
	int lightA;
	int lightB;
}SCREEN_LIGHT_INFO; 


//Include .h file 
 
// Link Lib 
#ifndef _DEBUG 
#pragma comment(lib,"log4cplusUS.lib") 
#else 
#pragma comment(lib,"log4cplusUSD.lib") 
#endif 



#endif