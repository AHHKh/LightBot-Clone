namespace LightBot.Scripts
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