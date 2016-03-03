Copyright © 2003-2014	FEIG ELECTRONIC GmbH, All Rights Reserved.
			Lange Strasse 4
			D-35781 Weilburg
			Federal Republic of Germany
			phone    : +49 6471 31090
			fax      : +49 6471 310999
			e-mail   : obid-support@feig.de
			Internet : http://www.feig.de

OBID and OBID i-scan are registered trademarks of FEIG ELECTRONIC GmbH


===============================
	ID ISC.SDK.NET

	   V4.06.10

      2014-12-11
===============================


1. What is new (main changes)
- Support for new Reader ID CPR60
- Updated Reader Configuration namespaces in ReaderConfig
- All changes can be found in the SDK manual H40301-25x-ID-B


NOTE: To learn more about OBID i-scan Readers use ISOStart V9.8.2 and for OBID classic-pro Readers use CPRStart V9.7.1 


2. System Requirements

The ID ISC.SDK.NET is developed for the .NET-Framework in the version 2.0, 3.0, 3.5, 4.0 and 4.5, each in 32-Bit runtime version.
Beginning with .NET-Framework version 4.0, the 64-Bit runtime version is also supported.


3. First Steps
To become familiar with the OBID Reader Families, Developers should read first the System Manual of the Reader.
We recommend to read secondly the Tutorial. Although it is not yet completed, it gives a structured introduction into the library stack 
and the high-level APIs of the C# class library.
Additionally, FEIG provides tools called ISOStart (for OBID i-scan) and CPRStart (for OBID classic-pro), which demonstrates all capabilities of each Reader Type.
These tools are a great help for Developers to understand the commands, configuration and Reader modes of an OBID Reader.


4. Installation

Extract the ZIP-File in your favorite path.
NOTE: Cyphered protocol transmission depends on openSSL. Copy libeay32.dll from directory run to your application path, if cyphered protocol transmission is used and pay notice about the openSSL licence in SDK manual H40301-x-ID-B.pdf. If not, you need not copy libeay32.dll to your application path.

A) Microsoft Visual Basic .NET (Visual Studio 2008/2010)
Note:
The VS2008 projects depend on the 32-Bit .NET Framework v2.0
The VS2010 projects depend on the 32-Bit .NET Framework v4.0

- ISOHostSample (Program to demonstrate the use of the ISO-Host commands)
- BRMSample (Program to demonstrate the Buffered-Read-Mode for Readers supportimg the Buffered-Read-Mode)
- HexEditor (helper class for ISOSample)
- Authent_Mifare (helper class for ISOHostSample)
- Authent_MYD (helper class for ISOHostSample)
- PortConnection (helper class for ISOHostSample and BRMSample)
- NotificationSample (Program to demonstrate the reception of notifications)
- MultipleUSBReader (Program to demonstrate the connection of multiple USB Readers)
- TagHandlerSample (Basic program to demonstrate the use of TagInventory, TagSelect and use of TagHandler classes)

B) Microsoft Visual C# (Visual Studio 2008/2010)
Note:
The VS2008 projects depend on the 32-Bit .NET Framework v2.0
The VS2010 projects depend on the 32-Bit .NET Framework v4.0

- APDUSample ((Program to demonstrate the use of sending APDUs via classic pro readers like CPR40.30, CPR50, etc. to an ISO14443 tag)
- FUSample (Program to demonstrate the use of the HF/UHF Function Units)
- ISOHostSample (Program to demonstrate the use of the ISO-Host commands)
- ScanSample (Program to demonstrate the use of the Scan-Mode in the reader)
- BRMSample (Program to demonstrate the Buffered-Read-Mode for Readers supportimg the Buffered-Read-Mode)
- NotificationSample (Program to demonstrate the reception of notifications)
- UsbSample (Program to demonstrate the connection of USB reader)
- MultipleUSBReader (Program to demonstrate the connection of multiple USB Readers)
- myAXXESS_Manager (Easy Access Control Program for managing multiple ID MAX50.xx over TCP/IP) --> On Request, please conatct obid-support@feig.de
- TagHandlerSample (Basic program to demonstrate the use of TagInventory, TagSelect and use of TagHandler classes)
- TagHandlerDemo_DESFire_C3 (Program to demonstrate the use of TagHandler class with ISO 14443 Transponder MIFARE DESFire)


5. Project Settings and Particularities

- Microsoft Visual Basic .NET / C#:
After installation please check the reference paths of the several projects. Especially check the reference of the assembly file OBIDISC4NET.DLL. If the file was not located in the project, make a new reference to this file. In view of your environment.
you can generate a link to the RUN-path you need. Here you can find the assembly file OBIDISC4NET.DLL.
For generating and running a Debug Version of the sample programs you should check the path for the "Working Directory". It should be in general the "Run" folder of the .NET-SDK!


6. Dependencies

6.1 Library compliant with 32-Bit .NET 2.0 - 3.5

The .NET library OBIDISC4NET.DLL depends on the following native libraries (in directory run\x86\NET_2.0):
a) OBIDISC4NETnative.DLL
b) FedmIscCoreVC80.DLL
c) FedmIscMyAxxessVC80.DLL
d) FECOM.DLL
e) FEUSB.DLL
f) FETCP.DLL
g) FETCL.DLL
h) FEISC.DLL
i) FEFU.DLL

6.2 Library compliant with 32-Bit .NET 4.0 - 4.5

The .NET library OBIDISC4NET.DLL depends on the following native libraries (in directory run\x86\NET_4.0):
a) OBIDISC4NETnative.DLL
b) FedmIscCoreVC100.DLL
c) FedmIscMyAxxessVC100.DLL
d) FECOM.DLL
e) FEUSB.DLL
f) FETCP.DLL
g) FETCL.DLL
h) FEISC.DLL
i) FEFU.DLL

6.3 Library compliant with 64-Bit .NET 4.0 - 4.5

The .NET library OBIDISC4NET.DLL depends on the following native libraries (in directory run\x64\NET_4.0):
a) OBIDISC4NETnative.DLL
b) FedmIscCoreVC100.DLL
c) FECOM.DLL
d) FEUSB.DLL
e) FETCP.DLL
f) FETCL.DLL
g) FEISC.DLL
h) FEFU.DLL


7. Deployment

7.1 Deployment for 32-Bit Library compliant with .NET 2.0 - 3.5

To install the library files on targets, follow the installation instructions of the manuals.

The library files FedmIscCoreVC80.dll and FedmIscMyAxxessVC80.dll depends on a newer MFC library (Version 8.0.50727.6195) which is usually not present on the target computer. Therefore, it must be installed. So-called merge modules are provided with Visual Studio which can be incorporated in a Setup project and which install the MFC libraries. The following merge modules are necessary for the FedmIscCoreVC80 and FedmIscMyAxxessVC80.dll library:
 
	1. Microsoft_VC80_MFC_x86.msm
	2. Microsoft_VC80_CRT_x86.msm
	3. policy_8_0_Microsoft_VC80_MFC_x86.msm
	4. policy_8_0_Microsoft_VC80_CRT_x86.msm

Alternatively, the installation of the Visual C++ Runtime Libraries can be realized with the download site of Microsoft. For each version of MFC you can find a file called vcredist_x86.exe (Version 8.0.50727.6195 or higher) for download.

Link to Microsoft download site Visual C++ 2005 SP1 Redistributable Packages:
	http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=26347

7.2 Deployment for 32-Bit Library compliant with .NET 4.0 - 4.5

The library files FedmIscCoreVC100.dll and FedmIscMyAxxessVC100.dll depends on a newer MFC library (Version 10.0.30319.460) which is usually not present on the target computer. Therefore, it must be installed. So-called merge modules are provided with Visual Studio which can be incorporated in a Setup project and which install the MFC libraries. The following merge modules are necessary for the FedmIscCoreVC100 and FedmIscMyAxxessVC100.dll library:
 
	1. Microsoft_VC100_MFC_x86.msm
	2. Microsoft_VC100_CRT_x86.msm

Alternatively, the installation of the Visual C++ Runtime Libraries can be realized with the download site of Microsoft. For each version of MFC you can find a file called vcredist_x86.exe (Version 10.0.30319.460 or higher) for download.

Link to Microsoft download site Visual C++ 2010 Redistributable Package (x86):
	http://www.microsoft.com/en-us/download/details.aspx?id=5555

7.3 Deployment for 64-Bit Library compliant with .NET 4.0 - 4.5

The library file FedmIscCoreVC100.dll depends on a newer MFC library (Version 10.0.40219.1) which is usually not present on the target computer. Therefore, it must be installed. So-called merge modules are provided with Visual Studio which can be incorporated in a Setup project and which install the MFC libraries. The following merge modules are necessary for the FedmIscCoreVC100 and FedmIscMyAxxessVC100.dll library:
 
	1. Microsoft_VC100_MFC_x64.msm
	2. Microsoft_VC100_CRT_x64.msm

Alternatively, the installation of the Visual C++ Runtime Libraries can be realized with the download site of Microsoft. For each version of MFC you can find a file called vcredist_x86.exe (Version 10.0.40219.1 or higher) for download.

Link to Microsoft download site Visual C++ 2010 Redistributable Package (x64):
	http://www.microsoft.com/en-us/download/details.aspx?id=14632
