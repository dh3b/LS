using CommandSystem;
using System;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace LS.Commands.SubCommands
{
    class Spawn : ICommand
    {
        public string Command { get; } = "spawn";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Spawnuje jednego gracza jako LS";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!sender.CheckPermission("ls.spawn"))
            {
                response = "Nie masz parmisji ls.spawn";
                return false;
            }

            if (arguments.Count is 0)
            {
                if (!MainWorker.IsLS(player) && !player.IsOverwatchEnabled)
                {
                    response = "Spawnuję...";
                    MainWorker.SpawnPlayer(player);
                    return true;
                }

                response = "Jesteś już LS!";
                return false;
            }

            Player playerArg = Player.Get(arguments.At(0));
            if (playerArg is null)
            {
                response = "Nieprawidłowy argument komendy! Proszę podać nick lub numer ID gracza.";
                return false;
            }

            if (!MainWorker.IsLS(playerArg) && !player.IsOverwatchEnabled)
            {
                response = $"Spawnuję ({playerArg.Id}) {playerArg.Nickname}...";
                MainWorker.SpawnPlayer(playerArg);
                return true;
            }

            response = $"({playerArg.Id}) {playerArg.Nickname} jest już LS!";
            return false;
        }
    }
}
