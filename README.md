# AltV-CommandManager
This is a CommandManager for AltV, written in C# (Server) and Typescript (Client). Commands can be entered via Server- or Client-Console. All Commands are send to the server to be verified and to check the permission needed for the command.

## Build
To Build correctly you have to install this extension https://marketplace.visualstudio.com/items?itemName=MadsKristensen.CommandTaskRunner or use the .vsix file in the build tools.
- Client: Rebuild the Project "ClientBuild"
- Server: Build the Project "Server"

The builded files can be found in the folder "output" and just needed to be copied into resource-folder.

## Files
- ConsoleManager.cs - Here you can add commands to the Commandlist.
  - The first element is the name of the command (Casesensitiv)
  - The second element is the CommandType (Server, Client, ServerWithPlayer)
  - The third element is the permission needed to run the command.
  - commandPermission - can be changed to a command system


- Server.cs - Here you can add your Servercommands (Default triggered by Server)
- ServerWithPlayer.cs - Here you can add your Servercommands wich needs player to be executed (Default triggered by Client)
- ClientCallBack.cs - Here you can add functions for Clientcommands wich needs Servercommands
- ClientCommands.ts - Here you can add your Clientcommands, a onServer-Event is needed with the prefix "COMMAND_" (Default triggered by Client)


