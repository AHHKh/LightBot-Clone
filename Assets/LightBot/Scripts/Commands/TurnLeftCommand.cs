using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class TurnLeftCommand : Command
    {
        public TurnLeftCommand(Bot bot) : base(bot)
        {
        }

        public override IEnumerator Execute()
        {
            yield return Bot.TurnLeft();
        }
    }
}