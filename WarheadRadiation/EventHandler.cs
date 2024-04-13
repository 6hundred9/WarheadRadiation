using System.Collections.Generic;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace WarheadRadiation
{
    public class EventHandler
    {
        private static CoroutineHandle CheckRoomHandle;
        private static Config _config = Plugin.Instance.Config;
        private static int timer = _config.Seconds;
        public static void Spawned(SpawnedEventArgs ev)
        {
            if (!CheckRoomHandle.IsRunning)
            {
                CheckRoomHandle = Timing.RunCoroutine(CheckRoom(ev.Player));
            }
        }

        public static IEnumerator<float> CheckRoom(Player player)
        {
            yield return Timing.WaitForSeconds(1);
            if (player.CurrentRoom?.Type is RoomType.HczNuke)
            {
                timer--;
            }
            else
            {
                timer = _config.Seconds;}

            if (timer <= 0)
            {
                player.EnableEffect(EffectType.Decontaminating);
            }
            else
            {
                player.DisableEffect(EffectType.Decontaminating);
            }
        }
    }
}