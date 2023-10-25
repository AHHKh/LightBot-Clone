using System;
using LightBot.Scripts.Commands;
using UnityEngine;

namespace LightBot.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private CommandCenter _commandCenter;

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
            _commandCenter = new CommandCenter();
        }

        public void AddCommand(Command command)
        {
            _commandCenter.AddCommand(command);
        }

        public void RemoveCommand(Command command)
        {
            _commandCenter.RemoveCommand(command);
        }
    }
}