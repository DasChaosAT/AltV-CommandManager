using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace Server.Login
{
    internal class Login
    {
        private static readonly Position SpawnPosition = new Position(233, -878, 30);

        public static async Task OnPlayerConnect(IPlayer player, string reason)
        {
            await player.SetPositionAsync(SpawnPosition);
        }
    }
}
