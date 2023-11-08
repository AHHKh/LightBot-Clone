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

        private int _lightOnCount;

        private void Awake()
        {
            CreateInstance();
            Initialize();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Initialize()
        {
            _lightOnCount = 0;
            AddListenersToLights();
        }

        private void AddListenersToLights()
        {
            foreach (Light l in lights)
                l.OnSwitchLight += CheckGameLights;
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

        public Light GetLight(Platform platform)
        {
            return lights.Find(x => x.Platform == platform);
        }

        public void ResetBoard()
        {
            foreach (Light l in lights)
                l.Reset();
        }

        private void CheckGameLights(bool turnOn)
        {
            _lightOnCount += turnOn ? +1 : -1;
            Debug.Log($"LightOnCount = {_lightOnCount}");
            if (_lightOnCount == lights.Count)
                WinGame();
        }

        private void WinGame()
        {
            Debug.Log("WinGame");
            GameManager.Instance.WinGame();
        }
    }
}