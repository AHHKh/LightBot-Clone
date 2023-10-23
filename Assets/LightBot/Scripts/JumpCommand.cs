namespace LightBot.Scripts
{
    public class JumpCommand : Command
    {
        public JumpCommand(Bot bot) : base(bot)
        {
        }

        public override void Execute()
        {
            Bot.Jump();
        }
    }
}