#pragma once
#include <string>
#include <vector>

class StringUtil
{
public:
	StringUtil(void);
	~StringUtil(void);
	static std::string  addToString(const char * str , bool result);
	static std::string  addToString(const char * str , int data);
	static std::vector< std::string>  StringUtil::split(std::string& s, std::string& delim);
	static std::string convertToStringWithFlag(std::vector< std::string> strVector,std::string split);
	static std::string convertToIntString(char * charArray,int length);
};
