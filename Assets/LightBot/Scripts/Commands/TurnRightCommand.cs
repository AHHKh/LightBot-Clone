using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class TurnRightCommand : Command
    {
        public TurnRightCommand(Bot bot) : base(bot)
        {
        }

        public override IEnumerator Execute()
        {
            yield return Bot.TurnRight();
        }
    }
}