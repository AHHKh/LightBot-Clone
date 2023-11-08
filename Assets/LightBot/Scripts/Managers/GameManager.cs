using System;
using System.Collections;
using LightBot.Scripts.Commands;
using LightBot.Scripts.Models;
using UnityEngine;

namespace LightBot.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Action onCommandsDone;
        public IEnumerator currentCommand;

        private CommandCenter _commandCenter;

        [SerializeField] private Bot bot;

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

        public Command CreateCommand(MemoryType memoryType, CommandTyp commandTyp)
        {
            Command command = commandTyp switch
            {
                CommandTyp.None => new MoveCommand(bot),
                CommandTyp.Move => new MoveCommand(bot),
                CommandTyp.Light => new LightCommand(bot),
                CommandTyp.TurnLeft => new TurnLeftCommand(bot),
                CommandTyp.TurnRight => new TurnRightCommand(bot),
                CommandTyp.Jump => new JumpCommand(bot),
                CommandTyp.P1 => new ProceduralCommand(bot, MemoryType.Proc1, _commandCenter),
                CommandTyp.P2 => new ProceduralCommand(bot, MemoryType.Proc2, _commandCenter),
                _ => throw new ArgumentOutOfRangeException(nameof(commandTyp), commandTyp, null)
            };
            AddCommand(memoryType, command);
            return command;
        }

        private void AddCommand(MemoryType memoryType, Command command)
        {
            _commandCenter.AddCommand(memoryType, command);
        }

        public void RemoveCommand(MemoryType memoryType, Command command)
        {
            _commandCenter.RemoveCommand(memoryType, command);
        }

        public void ExecuteCommands()
        {
            StartCoroutine(_commandCenter.ExecuteCommands());
        }

        public void WinGame()
        {
            StopExecuteCommands();
        }

        public void StopExecuteCommands()
        {
            if (currentCommand != null)
                StopCoroutine(currentCommand);
            OnCommandsDone();
        }

        public void ResetLevel()
        {
            LevelManager.Instance.ResetBoard();
            bot.Reset();
        }
    }
}