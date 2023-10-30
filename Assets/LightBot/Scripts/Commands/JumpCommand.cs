using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class JumpCommand : Command
    {
        public JumpCommand(Bot bot) : base(bot)
        {
        }

        public override IEnumerator Execute()
        {
            yield return Bot.Jump();
        }
    }
}