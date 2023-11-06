using System.Collections.Generic;
using UnityEngine;

namespace LightBot.Scripts.Models
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = CREAT_MENU_NAME)]
#endif
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public List<CommandTyp> CommandsTypes { get; private set; }
        [field: SerializeField] public List<Memory> Memories{ get; private set; }
        [field: SerializeField] public List<Vector3Int> PlatformPosition { get; private set; }
        [field: SerializeField] public List<Vector3Int> LightsPosition { get; private set; }
        [field: SerializeField] public Vector2 BotStartPosition { get; private set; }
        [field: SerializeField] public Direction BotStartDirection { get; private set; }
        
        [field: SerializeField] public Vector3 CameraPosition { get; private set; }
        [field: SerializeField] public Vector3 CameraRotation { get; private set; }
        [field: SerializeField] public Vector3 CameraScale { get; private set; }

#if UNITY_EDITOR
        private const string CREAT_MENU_NAME = "LightBot/Create LevelData";
#endif
    }
}