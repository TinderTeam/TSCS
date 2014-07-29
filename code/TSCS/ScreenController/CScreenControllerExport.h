// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the SCREENCONTROLLER_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// SCREENCONTROLLER_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CSCREENCONTROLLER_EXPORTS
#define CSCREENCONTROLLER_API __declspec(dllexport)
#else
#define CSCREENCONTROLLER_API __declspec(dllimport)
#endif

// This class is exported from the ScreenController.dll
class CSCREENCONTROLLER_API CScreenControllerExport {
public:
	CScreenControllerExport(void);
	// TODO: add your methods here.
};

#include <string>
#include "ScreenConstant.h"
 
extern "C" CSCREENCONTROLLER_API int fnScreenController(void);

extern "C" CSCREENCONTROLLER_API bool connectScreen(char * ipAddr);

extern "C" CSCREENCONTROLLER_API bool initScreen(void);

extern "C" CSCREENCONTROLLER_API void closeConnect(void);



extern "C" CSCREENCONTROLLER_API bool setScreenName(char* name);
extern "C" CSCREENCONTROLLER_API char * getScreenName();

extern "C" CSCREENCONTROLLER_API bool setRoadInfo(ROAD_INFO raodInfo[],int length);
extern "C" CSCREENCONTROLLER_API bool getRoadInfo(ROAD_INFO raodInfo[],int length);
extern "C" CSCREENCONTROLLER_API bool setScreenLight(SCREEN_LIGHT_INFO & lightInfo);
extern "C" CSCREENCONTROLLER_API bool getScreenLight(SCREEN_LIGHT_INFO & lightInfo);

extern "C" CSCREENCONTROLLER_API bool setScreenColor(int color);
extern "C" CSCREENCONTROLLER_API int getScreenColor();

extern "C" CSCREENCONTROLLER_API bool setScreenDisp(SEGMENT_INFO segmentInfo[],int length);
extern "C" CSCREENCONTROLLER_API int getScreenDisp();

extern "C" CSCREENCONTROLLER_API bool setScreenIpAddr(char * ipAddr);


extern "C" CSCREENCONTROLLER_API bool setScreenOn();

extern "C" CSCREENCONTROLLER_API bool setScreenOff();


extern "C" CSCREENCONTROLLER_API bool setSegmentColor(int segNum,int color);


extern "C" CSCREENCONTROLLER_API bool saveScreen(void);





