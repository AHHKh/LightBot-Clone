namespace LightBot.Scripts
{
    public class SwitchLightCommand : Command
    {
        public SwitchLightCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.SwitchLight();
        }
    }
}