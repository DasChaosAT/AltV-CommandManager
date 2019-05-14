using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Server.Objects.Enum;

namespace Server.Server.Commands
{
    internal class ConsoleManager
    { 
        /*
         * Register each command here.
         */
        private static readonly List<Tuple<string, CommandType, byte>> CommandList = new List<Tuple<string, CommandType, byte>>
        {
            /*
             * Name, CommandType, Needed Permission
             */
            new Tuple<string, CommandType, byte>("HelloServer", CommandType.Server, 0),

            new Tuple<string, CommandType, byte>("HelloPlayer", CommandType.Client, 0),

            new Tuple<string, CommandType, byte>("veh", CommandType.ServerWithPlayer, 0),
        };

        internal static async Task OnPlayerEvent(IPlayer player, string eventName, object[] args)
        {
            switch (eventName)
            {
                case "CONSOLE_Command":
                {
                    if (args.Length < 1)
                    {
                        return;
                    }

                    var command = (string) args[0];
                    var argsObject = (object[]) args[1];

                    var arguments = new string[argsObject.Length+1];

                    for (var i = 0; i < argsObject.Length; i++)
                    {
                        arguments[i] = (string) argsObject[i];
                    }

                    await ParseClientCommands(player, command, arguments);

                    break;
                }
            }
        }

        internal static async Task OnConsoleCommand(string command, string[] args)
        {
            await ParseServerCommand(command, args);
        }

        internal static async Task ParseClientCommands(IPlayer player, string command, string[] arguments, bool message = true)
        {
            const byte commandPermission = 254; //Replace with Database Request

            if (CommandList.Exists(x =>
                x.Item1 == command && x.Item2 == CommandType.Client && x.Item3 <= commandPermission))
            {
                await player.EmitAsync("COMMAND_" + command, arguments);
            }
            else if (CommandList.Exists(x =>
                x.Item1 == command && x.Item2 == CommandType.Server && x.Item3 <= commandPermission))
            {
                await ParseServerCommand(command, arguments);
            }
            else if (CommandList.Exists(x =>
                x.Item1 == command && x.Item2 == CommandType.ServerWithPlayer && x.Item3 <= commandPermission))
            {
                await ParseServerWithPlayerCommand(player, command, arguments);
            }
            else
            {
                if (message)
                {
                    await player.EmitAsync("COMMAND_");
                }
            }
        }

        private static async Task ParseServerCommand(string command, string[] arguments)
        {
            await Server.ManageCommands(command, arguments);
        }

        private static async Task ParseServerWithPlayerCommand(IPlayer player, string command, string[] arguments)
        {
            await ServerWithPlayer.ManageCommands(player, command, arguments);
        }
    }
}
