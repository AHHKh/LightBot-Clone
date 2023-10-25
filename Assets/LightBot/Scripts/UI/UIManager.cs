using System;
using System.Collections.Generic;
using LightBot.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace LightBot.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button moveButton;
        [SerializeField] private Button lightButton;
        [SerializeField] private Button turnLeftButton;
        [SerializeField] private Button turnRightButton;
        [SerializeField] private Button jumpButton;
        [SerializeField] private Button p1Button;
        [SerializeField] private Button p2Button;
        [SerializeField] private Bot bot;
        [SerializeField] private UICommand uiCommandPrefab;
        [SerializeField] private GridLayoutGroup[] commandsParents;
        private int _commandsMemoryIndex;
        private UICommand _currentUICommand;
        private List<UICommand> _uiCommandsPool;

        private void Awake()
        {
            moveButton.onClick.AddListener(MoveCommand);
            lightButton.onClick.AddListener(LightCommand);
            turnLeftButton.onClick.AddListener(TurnLeftCommand);
            turnRightButton.onClick.AddListener(TurnRightCommand);
            jumpButton.onClick.AddListener(JumpCommand);
            p1Button.onClick.AddListener(P1Command);
            p2Button.onClick.AddListener(P2Command);
        }

        private void MoveCommand()
        {
            AddCommand(new MoveCommand(bot), moveButton.image.sprite);
        }

        private void LightCommand()
        {
            AddCommand(new LightCommand(bot), lightButton.image.sprite);
        }

        private void TurnLeftCommand()
        {
            AddCommand(new TurnLeftCommand(bot), turnLeftButton.image.sprite);
        }

        private void TurnRightCommand()
        {
            AddCommand(new TurnRightCommand(bot), turnRightButton.image.sprite);
        }

        private void JumpCommand()
        {
            AddCommand(new JumpCommand(bot), jumpButton.image.sprite);
        }

        private void P1Command()
        {
            AddCommand(new ProceduralCommand(bot), p1Button.image.sprite);
        }

        private void P2Command()
        {
            AddCommand(new ProceduralCommand(bot), p2Button.image.sprite);
        }

        private UICommand GetFromPool()
        {
            UICommand uiCommand;
            if (_uiCommandsPool == null || _uiCommandsPool.Count == 0)
                uiCommand = Instantiate(uiCommandPrefab, commandsParents[_commandsMemoryIndex].transform);
            else
            {
                uiCommand = _uiCommandsPool[0];
                _uiCommandsPool.Remove(uiCommand);
                uiCommand.gameObject.SetActive(true);
            }
            return uiCommand;
        }

        private void AddToPool(UICommand uiCommand)
        {
            _uiCommandsPool ??= new List<UICommand>();
            uiCommand.gameObject.SetActive(false);
            uiCommand.transform.SetAsLastSibling();
            _uiCommandsPool.Add(uiCommand);
        }

        private void AddCommand(Command command, Sprite sprite)
        {
            GameManager.Instance.AddCommand(command);
            _currentUICommand = GetFromPool();
            _currentUICommand.Initialize(this, command, sprite);
        }

        public void RemoveCommand(UICommand uiCommand, Command command)
        {
            GameManager.Instance.RemoveCommand(command);
            AddToPool(uiCommand);
        }
    }
}