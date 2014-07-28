#include "StdAfx.h"
#include "StringUtil.h"

StringUtil::StringUtil(void)
{
}

StringUtil::~StringUtil(void)
{
}
std::vector< std::string>  StringUtil::split(std::string& s, std::string& delim)
{
	std::vector< std::string>  ret;
	size_t last = 0;  
	size_t index=s.find_first_of(delim,last);  
	while (index!=std::string::npos)  
	{  
		ret.push_back(s.substr(last,index-last));  
		last=index+1;  
		index=s.find_first_of(delim,last);  
	}  
	if (index-last>0)  
	{  
		ret.push_back(s.substr(last,index-last));  
	} 

	return ret;
}
std::string StringUtil::convertToStringWithFlag(std::vector< std::string> strVector,std::string split)
{
	std::string str;
	std::vector<std::string>::iterator iterVector = strVector.begin();
	for(;iterVector != strVector.end();iterVector++)
	{

		if(iterVector != strVector.begin())
		{
			str += split;
		}
		str += iterVector->c_str();
		
		 
	}
   return str;

}

std::string StringUtil::convertToIntString(char * charArray,int length)
{
	

	std::string str;
	for(int i=0;i < length;i++)
	{
		char buf[10];
		sprintf(buf, "%d", charArray[i]);
		std::string temp = buf;
		str.append(temp);

	}
	return str;

}