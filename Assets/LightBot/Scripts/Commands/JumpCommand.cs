namespace LightBot.Scripts.Commands
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