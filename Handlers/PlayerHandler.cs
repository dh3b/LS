using Exiled.Events.EventArgs.Player;
using Exiled.API.Features.Items;

namespace LS.Handlers
{
    public class PlayerHandler
    {
        public void OnDied(DiedEventArgs ev)
        {
            if (MainWorker.IsLS(ev.Player)) { MainWorker.RemovePlayerInfo(ev.Player); }
        }

        public void OnDestroying(DestroyingEventArgs ev)
        {
            if (MainWorker.IsLS(ev.Player)) { MainWorker.RemovePlayerInfo(ev.Player); }
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            if (MainWorker.IsLS(ev.Player) && ev.NewItem is Usable) { ev.Player.GetCooldownItem(0f, ItemType.SCP268); }
        }
    }
}
