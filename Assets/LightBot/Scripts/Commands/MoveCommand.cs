using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class MoveCommand : Command
    {
        public MoveCommand(Bot bot) : base(bot)
        {
        }

        public override IEnumerator Execute()
        {
            yield return Bot.Move();
        }
    }
}