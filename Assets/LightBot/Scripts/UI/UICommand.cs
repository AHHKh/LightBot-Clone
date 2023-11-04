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
        private UIManager _manager;
        private MemoryType _memoryType;
        private Command _command;

        private void Awake()
        {
            commandButton.onClick.AddListener(RemoveFromCommand);
        }

        public void Initialize(UIManager manager, MemoryType memoryType, Command command, Sprite sprite)
        {
            commandButton.image.sprite = sprite;
            _manager = manager;
            _memoryType = memoryType;
            _command = command;
        }

        private void RemoveFromCommand()
        {
            _manager.RemoveCommand(this,_memoryType, _command);
        }
    }
}