# VendingMachineCore

This project was programmed on Visual Studio 2017 Community edition using .NET Core 2.0 and windows 7.
I inclueded the release folder in this redo for windows/macs. 

Steps to install/Run:
1. Download Visual Studio: https://www.visualstudio.com/vs/features/net-development/
2. Download .NetCore https://www.microsoft.com/net/download/windows
3. Download zip and extract or clone the repo to your own machine.
4. Run VendingMachine.sln and Build the project from the directory you downloaded the files to.
5. Run debuging mode with F5 or start the application in your ~\VendingMachine\bin\Debug\VendingMachineCore.exe directory.

Mac:
1. Open Terminal
2. navigate to ~\VendingMachineCore\VendingMachineCore\bin\Release\netcoreapp2.0\osx-x64
3. run 'dotnet VendingMachineCore.dll' (I dont have a mac available but this should be close to working)

Steps to run unit tests:
1. With the solution open and built run the tests from the top menu option Test>Run>All Tests.
2. This should pop open a Test Explorer menu on the left with the test results.

CLI:
1. Open Developer Command Prompt for VS 2017
2. navigate to your VendingMachineCore\VendingMachineCore.Tests
3. Run 'dotnet test'
