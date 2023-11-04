using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LightBot.Scripts.Models;

namespace LightBot.Scripts.Commands
{
    public class CommandCenter
    {
        private readonly Action _onCommandsDone;

        private readonly Dictionary<MemoryType, List<Command>> _commands;

        public CommandCenter(Action onCommandsDone)
        {
            _commands = new Dictionary<MemoryType, List<Command>>();
            _onCommandsDone = onCommandsDone;
        }

        public void AddCommand(MemoryType memoryType, Command command)
        {
            if (!_commands.ContainsKey(memoryType))
                _commands.Add(memoryType, new List<Command>());
            _commands[memoryType].Add(command);
        }

        public void RemoveCommand(MemoryType memoryType, Command command)
        {
            _commands[memoryType].Remove(command);
        }

        public List<Command> GetCommands(MemoryType memoryType)
        {
            return _commands[memoryType];
        }

        public IEnumerator ExecuteCommands()
        {
            foreach (Command command in _commands[MemoryType.Main])
                yield return command.Execute();
            _onCommandsDone?.Invoke();
        }
    }
}