using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Server.Objects.Enum;

namespace Server.Server.Commands
{
    internal class Server
    {
        /*
         *  Add your Server Commands here 
         */
        internal static async Task ManageCommands(string command, string[] arguments)
        {
            switch (command)
            {
                #region SpecialCommands
                case "client":
                {
                    await Client(arguments);
                    break;
                }
                #endregion
                #region ServerCommands
                case "HelloServer":
                {
                    HelloServer(arguments);
                    break;
                }
                #endregion
                default:
                {
                    AltAsync.Log("Command `" + command + "` not found.");
                    break;
                }
            }
        }

        #region SpecialCommands
        private static async Task Client(IReadOnlyList<string> args)
        {
            if (args.Count < 2)
            {
                AltAsync.Log("Could too few arguments.");
                return;
            }

            var playerName = args[0];
            var command = args[1];
            var arguments = new string[args.Count - 2];

            for (var i = 2; i < args.Count; i++)
            {
                arguments[i - 2] = args[i];
            }

            IPlayer player = null;
            foreach (var client in Alt.GetAllPlayers())
            {
                var name = client.GetNameAsync();
                if (name.Result != playerName)
                {
                    continue;
                }

                player = client;
                break;
            }

            if (player == null)
            {
                AltAsync.Log("Could not find Player `" + playerName + "`.");
                return;
            }

            await ConsoleManager.ParseClientCommands(player, command, arguments, false);
        }
        #endregion

        #region ServerCommands
        private static void HelloServer(string[] arguments)
        {
            var printString = arguments.Aggregate("", (current, arg) => current + (" " + arg)); // Arguments to one String

            AltAsync.Log("Hello Server!" + printString);
        }
        #endregion
    }
}
