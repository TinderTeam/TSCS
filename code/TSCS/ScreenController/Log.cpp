#include "StdAfx.h"
#include "Log.h"  

//////////////////////////////////////////////////////////////////////  
// Construction/Destruction  
//////////////////////////////////////////////////////////////////////  

# define LOG_FILE_NAME "log/ScreenController.log"
Log::Log()  
{  

 

}  

Log::~Log()  
{  
}  

Log& Log::instance()  
{  
	static Log log;  
	return log;  
}  

bool Log::open_log()  
{  

	log4cplus::tstring fileName;
	std::string fileNameStr = std::string(LOG_FILE_NAME);
	for(int i=0;i<fileNameStr.length();i++)
	{
		fileName.push_back(fileNameStr[i]);
	}
	SharedAppenderPtr append(new RollingFileAppender(fileName,5*1024,10));  
 
	/* step 2: Instantiate a layout object */  
	std::string pattern = "%D{[%m/%d/%y  %H:%M:%S]} %p - %m [%l] %n"; 
	


	log4cplus::tstring tPattern;
	for(int i=0;i<pattern.length();i++)
	{
        tPattern.push_back(pattern[i]);
	}
	std::auto_ptr<Layout> layout(new PatternLayout(tPattern));  

	/* step 3: Attach the layout object to the appender */  
	append->setLayout(layout);  


	Logger logger = log4cplus::Logger::getInstance(fileName);  

	/* step 4: Instantiate a logger object */  

	/* step 5: Attach the appender object to the logger  */  
	logger.addAppender(append);  

	/* step 6: Set a priority for the logger  */  
	int Log_level = 1;
	logger.setLogLevel(Log_level);  

	return true;  
}  
Logger Log::getLogger()
{
	log4cplus::tstring fileName;
	std::string fileNameStr = std::string(LOG_FILE_NAME);
	for(int i=0;i<fileNameStr.length();i++)
	{
		fileName.push_back(fileNameStr[i]);
	}
	Logger logger = log4cplus::Logger::getInstance(fileName);  
	return logger;
}