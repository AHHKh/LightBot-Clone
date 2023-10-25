using System.Collections.Generic;

namespace LightBot.Scripts.Commands
{
    public class CommandCenter
    {
        private List<Command> _commands;

        public CommandCenter()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public void RemoveCommand(Command command)
        {
            _commands.Remove(command);
        }

        public void ExecuteCommands()
        {
            
        }
    }
}