using System;
using LightBot.Scripts.Commands;
using UnityEngine;

namespace LightBot.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Action onCommandsDone;

        private CommandCenter _commandCenter;
        private Coroutine _executeCommand;

        private void Awake()
        {
            CreateInstance();
            CreateCommandCenter();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
        }

        private void CreateCommandCenter()
        {
            _commandCenter = new CommandCenter(OnCommandsDone);
        }

        private void OnCommandsDone()
        {
            onCommandsDone?.Invoke();
        }

        public void AddCommand(Command command)
        {
            _commandCenter.AddCommand(command);
        }

        public void RemoveCommand(Command command)
        {
            _commandCenter.RemoveCommand(command);
        }

        public void ExecuteCommands()
        {
            _executeCommand = StartCoroutine(_commandCenter.ExecuteCommands());
        }

        public void StopExecuteCommands()
        {
            if (_executeCommand != null)
                StopCoroutine(_executeCommand);
        }
    }
}