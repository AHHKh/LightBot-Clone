namespace LightBot.Scripts.Commands
{
    public class TurnLeftCommand : Command
    {
        public TurnLeftCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.TurnLeft();
        }
    }
}