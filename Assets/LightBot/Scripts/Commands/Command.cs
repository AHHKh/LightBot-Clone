using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public abstract class Command
    {
        protected readonly Bot Bot;

        protected Command(Bot bot)
        {
            Bot = bot;
        }

        public abstract IEnumerator Execute();
    }
}