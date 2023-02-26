using System;
using CommandSystem;
using LS.Commands.SubCommands;

namespace LS.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class LSParentCommand : ParentCommand
    {
        public LSParentCommand() => LoadGeneratedCommands();
        public override string Command => "LS";
        public override string[] Aliases => Array.Empty<string>();
        public override string Description => "Komenda zarządzająca dla pluginu LS Serpents Hand";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Spawn());
            RegisterCommand(new Info());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Wybierz odpowiednią subkomendę! .LS spawn lub .LS info";
            return false;
        }
    }
}
