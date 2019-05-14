using System;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Server.Server.Commands;

namespace Server
{
    internal class Base : AsyncResource
    {

        public override void OnStart()
        {
            AltAsync.OnPlayerConnect += OnPlayerConnect;
            AltAsync.OnPlayerDisconnect += OnPlayerDisconnect;
            AltAsync.OnPlayerDead += OnPlayerDead;
            AltAsync.OnConsoleCommand += OnConsoleCommand;
            AltAsync.OnPlayerEvent += OnPlayerEvent;

            AltAsync.Log("Server initialized.");
        }

        private static async Task OnConsoleCommand(string name, string[] args)
        {
           await ConsoleManager.OnConsoleCommand(name, args);
        }

		private static async Task OnPlayerDead(IPlayer player, IEntity killer, uint weapon)
		{
			var pos = await player.GetPositionAsync();
			await player.DespawnAsync();
			await player.SpawnAsync(pos);
		}

		private static async Task OnPlayerEvent(IPlayer player, string eventName, object[] args)
		{
		    await ConsoleManager.OnPlayerEvent(player, eventName, args);
		    await ClientCallback.OnPlayerEvent(player, eventName, args);
        }

        public override void OnStop()
        {
            AltAsync.Log("Server stopped");
        }

        private static async Task OnPlayerConnect(IPlayer player, string reason)
        {
            var name = await player.GetNameAsync();
            AltAsync.Log(name + " has joined the Server.");

            await Login.Login.OnPlayerConnect(player, reason);
        }

        private static async Task OnPlayerDisconnect(ReadOnlyPlayer player, IPlayer origin, string reason)
        {
            var name = await player.GetNameAsync();
            AltAsync.Log(name + " has disconnected.");
        }
    }
}
