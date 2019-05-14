using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Async;

namespace Server.Server.Commands
{
    internal class ClientCallback
    {
        public static async Task OnPlayerEvent(IPlayer player, string eventName, object[] args)
        {
            switch (eventName)
            {
                case "COMMAND_CALLBACK_test":
                {
                    await Task.Delay(0); //Suppress Warning
                    AltAsync.Log("Test is working");
                    break;
                }              
            }
        }
    }
}
