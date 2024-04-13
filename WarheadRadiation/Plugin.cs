using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace WarheadRadiation
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Warhead Radiation";
        public override string Author => "6hundred9";
        public override string Prefix => "WR";
        public override Version RequiredExiledVersion => new Version(8, 8, 0);
        public override bool IgnoreRequiredVersionCheck => true;
        public static Plugin Instance;
        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Player.Spawned += EventHandler.Spawned;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Spawned -= EventHandler.Spawned;
            base.OnDisabled();
        }
    }
}