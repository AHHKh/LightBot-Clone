using System;
using LightBot.Scripts.Commands;
using LightBot.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace LightBot.Scripts.UI
{
    public class UICommand : MonoBehaviour
    {
        [SerializeField] private Button commandButton;
        private UILevel _level;
        private MemoryType _memoryType;
        private Command _command;

        private void Awake()
        {
            commandButton.onClick.AddListener(RemoveFromCommand);
        }

        public void Initialize(UILevel level, MemoryType memoryType, Command command, Sprite sprite)
        {
            commandButton.image.sprite = sprite;
            _level = level;
            _memoryType = memoryType;
            _command = command;
        }

        private void RemoveFromCommand()
        {
            _level.RemoveCommand(this,_memoryType, _command);
        }
    }
}