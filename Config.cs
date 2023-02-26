using Exiled.API.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using Exiled.API.Enums;

namespace LS
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public static Vector3 SpawnPosition { get; set; } = new Vector3(63f, 992f, -51f);

        public static List<ItemType> ItemList { get; set; } = new List<ItemType>
        {
            ItemType.GunRevolver,
            ItemType.ArmorCombat,
            ItemType.Adrenaline,
            ItemType.SCP268,
            ItemType.KeycardChaosInsurgency
        };

        public static Dictionary<AmmoType, ushort> AmmoList { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato556, 0 },
            { AmmoType.Nato762, 0 },
            { AmmoType.Nato9, 0 },
            { AmmoType.Ammo12Gauge, 0 },
            { AmmoType.Ammo44Cal, 36 }
        };

        public static float Health { get; set; } = 115f;
        public static string LSCustomInfo { get; set; } = "Przywódczyni Serpents Hand";
        public static string LSCustomName { get; set; } = "L.S. 'Black Queen'";
    }
}

