#if !defined(AFX_LOG_H__B87F71E3_FFAE_4CFA_A528_3F4F2FF7D69E__INCLUDED_)  
#define AFX_LOG_H__B87F71E3_FFAE_4CFA_A528_3F4F2FF7D69E__INCLUDED_  

#include "log4cplus/loglevel.h"  
#include "log4cplus/ndc.h"   
#include "log4cplus/logger.h"  
#include "log4cplus/configurator.h"  
#include "iomanip"  
#include "log4cplus/fileappender.h"  
#include "log4cplus/layout.h"  
 
using namespace log4cplus;  
using namespace log4cplus::helpers;  

//��־��װ  
#define LOG_TRACE(p) if(NULL != p && *p != 0) LOG4CPLUS_TRACE(Log::getLogger(), p)  
#define LOG_DEBUG(p) if(NULL != p && *p != 0)LOG4CPLUS_DEBUG(Log::getLogger(), p)  
#define LOG_INFO(p) if(NULL != p && *p != 0)LOG4CPLUS_INFO(Log::getLogger(), p)  
#define LOG_WARN(p) if(NULL != p && *p != 0)LOG4CPLUS_WARN(Log::getLogger(), p)  
#define LOG_ERROR(p) if(NULL != p && *p != 0)LOG4CPLUS_ERROR(Log::getLogger(), p)  


// ��־�����࣬ȫ�ֹ���һ����־  
class Log  
{  
public:  
	// ����־  
	bool open_log();  

	// �����־ʵ��  
	static Log& instance();  
	static Logger getLogger();
 
 

private:  
	Log();  

	virtual ~Log();  
   
 
};  

#endif // !defined(AFX_LOG_H__B87F71E3_FFAE_4CFA_A528_3F4F2FF7D69E__INCLUDED_)  

  