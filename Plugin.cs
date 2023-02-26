using Exiled.API.Features;
using Exiled.API.Enums;
using System;
using LS.Handlers;
using Player = Exiled.Events.Handlers.Player;

namespace LS
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "L.S. Serpent Hand";
        public override string Author => "dheb";

        public static Plugin Instance { get; private set; }
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public override Version RequiredExiledVersion => new Version(6, 0, 0);
        public override Version Version => new Version(1, 0, 0);

        private PlayerHandler playerHandler;

        public override void OnEnabled()
        {
            Log.Info("L.S. Serpent Hand plugin has been successfully enabled!");
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("L.S. Serpent Hand plugin has been disabled.");
            Instance = null;
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            playerHandler = new PlayerHandler();

            Player.Died += playerHandler.OnDied;
            Player.Destroying += playerHandler.OnDestroying;
            Player.ChangingItem += playerHandler.OnChangingItem;
        }
        private void UnregisterEvents()
        {
            Player.Died -= playerHandler.OnDied;
            Player.Destroying -= playerHandler.OnDestroying;
            Player.ChangingItem -= playerHandler.OnChangingItem;

            playerHandler = null;
        }
    }
}
