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
        private static CoroutineHandle _checkRoomHandle;
        private static readonly Config Config = Plugin.Instance.Config;
        private static int _timer = Config.Seconds;
        public static void Spawned(SpawnedEventArgs ev)
        {
            if (!_checkRoomHandle.IsRunning)
                _checkRoomHandle = Timing.RunCoroutine(CheckRoom(ev.Player)); 
        }

        private static IEnumerator<float> CheckRoom(Player player)
        {
            yield return Timing.WaitForSeconds(1);
            if (player.CurrentRoom?.Type is RoomType.HczNuke)
                _timer--;
            else
                _timer = Config.Seconds;

            if (_timer <= 0)
                player.EnableEffect(EffectType.Decontaminating);
            else
                player.DisableEffect(EffectType.Decontaminating); 
        }
    }
}