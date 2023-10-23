namespace LightBot.Scripts
{
    public class TurnRightCommand : Command
    {
        public TurnRightCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.TurnRight();
        }
    }
}