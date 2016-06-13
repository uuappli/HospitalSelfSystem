#ifndef _CCTALKDLL_H_
#define _CCTALKDLL_H_

unsigned char  __stdcall  ccTalkOpenPort(unsigned char port);
unsigned char __stdcall  SimplePoll();
unsigned char __stdcall  ReqManuID(unsigned char *data);
unsigned char __stdcall  ReqProductCode(unsigned char *data);
unsigned char __stdcall  ReqEquipmentID(unsigned char *data);
unsigned char __stdcall  ReqSoftwareRev(unsigned char *data);
unsigned char __stdcall  ReqSN(unsigned char *data);
unsigned char __stdcall  ReqHopperStatus(unsigned char *data);//返回4个字节
/*
[ event counter ]
[ payout coins remaining ]
[ last payout : coins paid ] 
[ last payout : coins unpaid ]
*/
unsigned char __stdcall  TestHopper(unsigned char *data);//返回一个字节的状态，各位如下
/*
Bit mask :
Bit 0 - Absolute maximum current exceeded
Bit 1 - Payout timeout occurred
Bit 2 - Motor reversed during last payout to clear a jam
Bit 3 - Opto fraud attempt, path blocked during idle
Bit 4 - Opto fraud attempt, short-circuit during idle
Bit 5 - Opto blocked permanently during payout
Bit 6 - Power-up detected
Bit 7 - Payout disabled
*/
unsigned char __stdcall  ReqPayoutHLStat(unsigned char *data);
/*
Received data : [ level status ]
This command allows the reading of high / low level sensors in a payout system.
Multiple hoppers are supported if they exist at the same address.
Bit 0 - Low level sensor status
0 = higher than or equal to low level trigger
1 = lower than low level trigger
Bit 1 - High level sensor status
0 = lower than high level trigger
1 = higher than or equal to high level trigger
Bit 2 - <reserved>
Bit 3 - <reserved>
Bit 4 - Low level sensor support
0 = feature not supported or fitted
1 = feature supported and fitted
Bit 5 - High level sensor support
0 = feature not supported or fitted
1 = feature supported and fitted
Bit 6 - <reserved>
Bit 7 - <reserved>
The trigger level is usually fixed mechanically.
*/
unsigned char __stdcall  EnableHopper(unsigned char enaCode);
/*
[ enable code ]
165 - enable hopper payout
not 165 - disable hopper payout
*/
unsigned char __stdcall  ReqCipherKey(unsigned char *rspKey);
/*
Received data : <variable>
This command requests a cipher key from the slave device and is part of the hopper
dispense encryption algorithm.
*/
unsigned char __stdcall  DispenseHopperCoins(unsigned char *Key,unsigned char nCoins);
/*
Transmitted data : <variable> [ no. of coins ]
Received data : ACK or NAK
*/
unsigned char __stdcall  EmergencyStop(unsigned char *rspRemain);
/*
Received data : [ payout coins remaining ]
This command immediately halts the payout sequence and reports back the number of
coins which failed to be paid out
*/
unsigned char __stdcall  ResetHopper();

unsigned char __stdcall SndRcvccTalkCmd(unsigned char cmdHeader,unsigned char slen,unsigned char *data,unsigned char *rsp,unsigned char *rsplen,unsigned short timeout);

unsigned char __stdcall  PayoutCoins(unsigned char nCoins);

unsigned char __stdcall  ccTalkClosePort(void);
#endif