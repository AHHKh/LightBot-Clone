namespace LightBot.Scripts.Commands
{
    public class LightCommand : Command
    {
        public LightCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.SwitchLight();
        }
    }
}