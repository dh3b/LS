using CommandSystem;
using System;
using Exiled.Permissions.Extensions;

namespace LS.Commands.SubCommands
{
    class Info : ICommand
    {
        public string Command { get; } = "info";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Informacje na temat obecnego stanu pluginu LS";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ls.info"))
            {
                response = "Nie masz parmisji ls.info";
                return false;
            }

            if(MainWorker.LSCount != 0)
            {
                response = $"Plugin LS odpowiada. Obecnie w placówce znajduje się {MainWorker.LSCount} klonów Little Sisters";
                return true;
            }

            response = "Plugin LS odpowiada. Żadnych klonów w placówce";
            return true;
        }
    }
}
