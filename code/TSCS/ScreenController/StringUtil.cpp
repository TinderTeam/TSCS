#include "StdAfx.h"
#include "StringUtil.h"

StringUtil::StringUtil(void)
{
}

StringUtil::~StringUtil(void)
{
}
std::string StringUtil::addToString(const char * str,bool result)
{
	std::string temp;
	if(NULL != str)
	{
	  temp = std::string(str);
	}

	if(result)
	{
		temp.append("true");
	}
	else
	{
		temp.append("false");
	}
	return temp;

}

std::string StringUtil::addToString(const char * str , int data)
{
	std::string temp;
	if(NULL != str)
	{
		temp = std::string(str);
	}
	char buf[10];
	sprintf(buf, "%X", data);
	temp.append(buf);

	return temp;

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


		str += iterVector->c_str();
		str += split;
		
		 
	}
   return str;

}

std::string StringUtil::convertToIntString(char * charArray,int length)
{
	

	std::string str;
	for(int i=0;i < length;i++)
	{
		char buf[10];
		sprintf(buf, "%X", charArray[i]);
		std::string temp = buf;

		if(temp.length()>=2)
		{
	       str.push_back(temp[temp.length()-2]);
		}
		else
		{
           str.push_back('0');
		}

		if(temp.length()>=1)
		{
		   str.push_back(temp[temp.length()-1]);
		}
		else
		{
		   str.push_back('0');
		}
	

		str.append(" ");

	}
	return str;

}