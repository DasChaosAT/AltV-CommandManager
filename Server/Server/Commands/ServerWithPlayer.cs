using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace Server.Server.Commands
{
    internal class ServerWithPlayer
    {
        /*
         *  Add Server with Player Commands here 
         */

        internal static async Task ManageCommands(IPlayer player, string command, string[] arguments, bool message = true)
        {
            switch (command)
            {
                #region ServerWithPlayerCommands
                case "car":
                case "veh":
                {
                    await Veh(player, arguments);
                    break;
                }
                #endregion
                default:
                {
                    if (message)
                    {
                        await player.EmitAsync("COMMAND_");
                    }
                    break;
                }
            }
        }

        #region ServerWithPlayerCommands
        private static async Task Veh(IPlayer player, string[] arguments)
        {
            if (!arguments.Any())
                return;

            var playerPos = await player.GetPositionAsync();
            var playerRotation = await player.GetRotationAsync();

            var veh = await AltAsync.CreateVehicle(Alt.Hash(arguments[0]), playerPos + new Position(5, 0, 0),
                playerRotation);

            if (veh == null)
                return;

            await veh.SetModKitAsync(1);
        }
        #endregion
    }
}
