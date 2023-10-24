namespace LightBot.Scripts.Commands
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