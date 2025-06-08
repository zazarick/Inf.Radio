using Exiled.API.Interfaces;

namespace InfiniteRadio
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float BatteryCharge { get; set; } = 100f;
        public float RegenInterval { get; set; } = 2f;
    }
}
