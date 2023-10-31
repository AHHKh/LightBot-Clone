using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LightBot.Scripts.Commands
{
    public class CommandCenter
    {
        private readonly Action _onCommandsDone;
        private readonly List<Command> _commands;

        public CommandCenter(Action onCommandsDone)
        {
            _commands = new List<Command>();
            _onCommandsDone = onCommandsDone;
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public void RemoveCommand(Command command)
        {
            _commands.Remove(command);
        }

        public IEnumerator ExecuteCommands()
        {
            //return _commands.Select(command => command.Execute()).GetEnumerator();
            foreach (Command command in _commands)
                yield return command.Execute();
            _onCommandsDone?.Invoke();
        }
    }
}