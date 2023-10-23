namespace LightBot.Scripts
{
    public abstract class Command
    {
        protected readonly Bot Bot;

        protected Command(Bot bot)
        {
            Bot = bot;
        }

        public abstract void Execute();
    }
}