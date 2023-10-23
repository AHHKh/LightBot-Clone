namespace LightBot.Scripts
{
    public class MoveCommand : Command
    {
        public MoveCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.Move();
        }
    }
}