using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;
using Exiled.API.Extensions;

namespace LS
{
    class MainWorker
    {
        public static int LSCount = 0;
        public static bool IsLS(Player player) => player.SessionVariables.ContainsKey("IsLS");
        public static void SpawnPlayer(Player player)
        {
            player.SessionVariables.Add("IsLS", null);
            player.Role.Set(PlayerRoles.RoleTypeId.Tutorial, SpawnReason.Respawn);
            player.MaxHealth = Config.Health;
            player.Health = Config.Health;
            player.CustomInfo = Config.LSCustomInfo;
            player.CustomName = $"{Config.LSCustomName} ({player.Nickname})";
            LSCount++;

            Timing.CallDelayed(0.4f, () =>
            {
                player.ResetInventory(Config.ItemList);
                foreach (var ammo in Config.AmmoList)
                    player.Ammo[ammo.Key.GetItemType()] = ammo.Value;
            });

            Timing.CallDelayed(0.8f, () => player.Position = Config.SpawnPosition);

            Log.Debug($"({player.Id}) {player.Nickname} spawned as LS");
            Log.Debug($"Current LS Count: {LSCount}");
        }

        public static void RemovePlayerInfo(Player player)
        {
            player.SessionVariables.Remove("IsLS");
            player.MaxHealth = default;
            player.Health = default;
            player.CustomInfo = string.Empty;
            player.CustomName = string.Empty;
            LSCount--;

            Log.Debug($"({player.Id}) {player.Nickname} died as LS");
            Log.Debug($"Current LS Count: {LSCount}");
        }
    }
}
