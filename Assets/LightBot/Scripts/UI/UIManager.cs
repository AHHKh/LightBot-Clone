using System;
using System.Collections.Generic;
using LightBot.Scripts.Commands;
using LightBot.Scripts.Managers;
using LightBot.Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LightBot.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        //[Header("Level Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button stopButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button resetLevelButton;
        [SerializeField] private Button backButton;

        //[Header("Commands Buttons")]
        [SerializeField] private Button moveButton;
        [SerializeField] private Button lightButton;
        [SerializeField] private Button turnLeftButton;
        [SerializeField] private Button turnRightButton;
        [SerializeField] private Button jumpButton;
        [SerializeField] private Button p1Button;
        [SerializeField] private Button p2Button;

        //[Header("Memory Buttons")]
        [SerializeField] private Button memoryButton;
        [SerializeField] private Button p1MemoryButton;
        [SerializeField] private Button p2MemoryButton;
        [SerializeField] private Color selectedMemoryColor;
        [SerializeField] private Color memoryColor;

        //[SerializeField] private Bot bot;
        [SerializeField] private UICommand uiCommandPrefab;
        [SerializeField] private GridLayoutGroup[] commandsParents;
        private MemoryType _commandsMemoryType;
        private UICommand _currentUICommand;
        private List<UICommand> _uiCommandsPool;

        private void Awake()
        {
            playButton.onClick.AddListener(ExecuteCommands);
            stopButton.onClick.AddListener(StopAndReset);
            resetButton.onClick.AddListener(StopAndReset);
            resetLevelButton.onClick.AddListener(ResetLevel);
            backButton.onClick.AddListener(LeaveLevel);

            moveButton.onClick.AddListener(MoveCommand);
            lightButton.onClick.AddListener(LightCommand);
            turnLeftButton.onClick.AddListener(TurnLeftCommand);
            turnRightButton.onClick.AddListener(TurnRightCommand);
            jumpButton.onClick.AddListener(JumpCommand);
            p1Button.onClick.AddListener(P1Command);
            p2Button.onClick.AddListener(P2Command);

            memoryButton.onClick.AddListener(() => SelectMemory(MemoryType.Main));
            p1MemoryButton.onClick.AddListener(() => SelectMemory(MemoryType.Proc1));
            p2MemoryButton.onClick.AddListener(() => SelectMemory(MemoryType.Proc2));
            GameManager.Instance.onCommandsDone = () => SetLevelButtons(false, false, true);
            SelectMemory(MemoryType.Main);
        }

        #region Commands
        private void MoveCommand()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.Move), moveButton.image.sprite);
        }

        private void LightCommand()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.Light), lightButton.image.sprite);
        }

        private void TurnLeftCommand()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.TurnLeft), turnLeftButton.image.sprite);
        }

        private void TurnRightCommand()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.TurnRight), turnRightButton.image.sprite);
        }

        private void JumpCommand()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.Jump), jumpButton.image.sprite);
        }

        private void P1Command()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.P1), p1Button.image.sprite);
        }

        private void P2Command()
        {
            AddCommand(_commandsMemoryType, CreateCommand(CommandTyp.P2), p2Button.image.sprite);
        }

        private Command CreateCommand(CommandTyp commandTyp)
        {
            return GameManager.Instance.CreateCommand(_commandsMemoryType, commandTyp);
        }

        private UICommand GetFromPool()
        {
            UICommand uiCommand;
            if (_uiCommandsPool == null || _uiCommandsPool.Count == 0)
                uiCommand = Instantiate(uiCommandPrefab, commandsParents[(int)(_commandsMemoryType - 1)].transform);
            else
            {
                uiCommand = _uiCommandsPool[0];
                _uiCommandsPool.Remove(uiCommand);
                uiCommand.transform.SetParent(commandsParents[(int)(_commandsMemoryType - 1)].transform);
                uiCommand.transform.SetAsLastSibling();
                uiCommand.gameObject.SetActive(true);
            }
            return uiCommand;
        }

        private void AddToPool(UICommand uiCommand)
        {
            _uiCommandsPool ??= new List<UICommand>();
            uiCommand.gameObject.SetActive(false);
            _uiCommandsPool.Add(uiCommand);
        }

        private void AddCommand(MemoryType memoryType, Command command, Sprite sprite)
        {
            _currentUICommand = GetFromPool();
            _currentUICommand.Initialize(this, memoryType, command, sprite);
        }

        public void RemoveCommand(UICommand uiCommand, MemoryType memoryType, Command command)
        {
            GameManager.Instance.RemoveCommand(memoryType, command);
            AddToPool(uiCommand);
        }
        #endregion

        #region Memory
        private void SelectMemory(MemoryType type)
        {
            _commandsMemoryType = type;
            switch (_commandsMemoryType)
            {
                case MemoryType.Main:
                    memoryButton.image.color = selectedMemoryColor;
                    p1MemoryButton.image.color = memoryColor;
                    p2MemoryButton.image.color = memoryColor;
                    break;
                case MemoryType.Proc1:
                    memoryButton.image.color = memoryColor;
                    p1MemoryButton.image.color = selectedMemoryColor;
                    p2MemoryButton.image.color = memoryColor;
                    break;
                case MemoryType.Proc2:
                    memoryButton.image.color = memoryColor;
                    p1MemoryButton.image.color = memoryColor;
                    p2MemoryButton.image.color = selectedMemoryColor;
                    break;
                case MemoryType.None:
                default:
                    Debug.LogWarning("No memory selected!");
                    break;
            }
        }
        #endregion

        private void ExecuteCommands()
        {
            SetLevelButtons(false, true, false);
            GameManager.Instance.ExecuteCommands();
        }

        private void StopAndReset()
        {
            SetLevelButtons(true, false, false);
            GameManager.Instance.StopExecuteCommands();
            LevelManager.Instance.Reset();
        }

        private void LeaveLevel()
        {
            //todo
        }

        private void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void SetLevelButtons(bool play, bool stop, bool reset)
        {
            playButton.gameObject.SetActive(play);
            stopButton.gameObject.SetActive(stop);
            resetButton.gameObject.SetActive(reset);
        }
    }
}