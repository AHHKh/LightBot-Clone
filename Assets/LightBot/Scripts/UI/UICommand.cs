using LightBot.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace LightBot.Scripts.UI
{
    public class UICommand : MonoBehaviour
    {
        [SerializeField] private Button commandButton;
        private UIManager _manager;
        private Command _command;

        public void Initialize(UIManager manager, Command command, Sprite sprite)
        {
            commandButton.image.sprite = sprite;
            _manager = manager;
            _command = command;
            commandButton.onClick.AddListener(RemoveFromCommand);
        }

        private void RemoveFromCommand()
        {
            _manager.RemoveCommand(this, _command);
        }
    }
}