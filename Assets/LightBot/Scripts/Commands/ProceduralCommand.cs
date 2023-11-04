using System.Collections;
using System.Collections.Generic;
using LightBot.Scripts.Managers;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class ProceduralCommand : Command
    {
        private MemoryType _memoryType;
        private CommandCenter _commandCenter;
        private List<Command> _commands;

        public ProceduralCommand(Bot bot, MemoryType memoryType, CommandCenter commandCenter) : base(bot)
        {
            _memoryType = memoryType;
            _commandCenter = commandCenter;
        }

        public override IEnumerator Execute()
        {
            _commands = _commandCenter.GetCommands(_memoryType);
            foreach (Command c in _commands)
                yield return c.Execute();
        }
    }
}