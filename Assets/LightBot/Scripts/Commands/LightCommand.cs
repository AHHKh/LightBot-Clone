using System.Collections;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class LightCommand : Command
    {
        public LightCommand(Bot bot) : base(bot)
        {
        }

        public override IEnumerator Execute()
        {
            yield return Bot.SwitchLight();
        }
    }
}