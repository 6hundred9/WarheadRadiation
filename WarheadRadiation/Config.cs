using Exiled.API.Interfaces;

namespace WarheadRadiation
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string Message { get; set; } = "{seconds} seconds until radiation starts";
        public int Seconds { get; set; } = 60;
    }
}