using System.Collections.Generic;
using LightBot.Scripts.Models;
using UnityEngine;
using Light = LightBot.Scripts.Models.Light;

namespace LightBot.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Platform> platforms;
        [SerializeField] private List<Light> lights;

        public static LevelManager Instance;

        private void Awake()
        {
            CreateInstance();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
        }

        public Platform GetPlatForm(Vector2 place)
        {
            return platforms.Find(x => x.Position == place);
        }

        public Platform GetNextPlatform(Platform currentPlatform, Direction direction)
        {
            Vector2 newPosition = currentPlatform.Position;
            switch (direction)
            {
                case Direction.None:
                    return null;
                case Direction.Forward:
                    newPosition += Vector2.right; //(1,0)
                    break;
                case Direction.Left:
                    newPosition += Vector2.up; //(0,1)
                    break;
                case Direction.Right:
                    newPosition += Vector2.down; //(0,-1)
                    break;
                case Direction.Backward:
                    newPosition += Vector2.left; //(-1,0)
                    break;
                default:
                    return null;
            }
            return platforms.Find(x => x.Position == newPosition);
        }
    }
}