using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;
using System.Collections.Generic;

namespace InfiniteRadio
{
    public class InfiniteRadioPlugin : Plugin<Config>
    {
        public override string Author => "zazarick";
        public override string Name => "InfiniteRadio";
        public override string Prefix => "infradio";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        private CoroutineHandle _coroutine;

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.UsingRadioBattery += OnUsingRadioBattery;
            _coroutine = Timing.RunCoroutine(RadioBatteryRegen());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.UsingRadioBattery -= OnUsingRadioBattery;
            if (_coroutine.IsRunning)
                Timing.KillCoroutines(_coroutine);
            base.OnDisabled();
        }

        private void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            ev.IsAllowed = false;
            if (ev.Player.CurrentItem is Radio radio)
                radio.BatteryLevel = (byte)Config.BatteryCharge;
        }

        private IEnumerator<float> RadioBatteryRegen()
        {
            while (true)
            {
                foreach (var player in Player.List)
                {
                    if (player.CurrentItem is Radio radio)
                        radio.BatteryLevel = (byte)Config.BatteryCharge;
                }
                yield return Timing.WaitForSeconds(Config.RegenInterval);
            }
        }
    }
}
