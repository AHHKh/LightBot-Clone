using System;
using System.Collections;
using LightBot.Scripts.Managers;
using UnityEngine;

namespace LightBot.Scripts.Models
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private float positionThreshold = 0.01f;
        [SerializeField] private float rotationThreshold = 1f;
        private Platform _currentPlatform;
        private Direction _currentDirection;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _currentPlatform = LevelManager.Instance.GetPlatForm(Vector2.zero);
            _currentDirection = Direction.Forward;
        }

        #region Commands
        public IEnumerator SwitchLight()
        {
            Debug.Log("SwitchLight");
            yield break;
        }

        public IEnumerator Move()
        {
            Debug.Log("Move");
            Platform nextPlatform = LevelManager.Instance.GetNextPlatform(_currentPlatform, _currentDirection);
            if (nextPlatform == null || nextPlatform.Height != _currentPlatform.Height)
                yield break;
            while ((transform.position - nextPlatform.transform.position).magnitude > positionThreshold)
            {
                transform.position = Vector3.Lerp(transform.position, nextPlatform.transform.position, Time.deltaTime);
                yield return null;
            }
            transform.position = nextPlatform.transform.position;
            _currentPlatform = nextPlatform;
        }

        public IEnumerator TurnLeft()
        {
            Debug.Log("TurnLeft");
            yield break;
        }

        public IEnumerator TurnRight()
        {
            Debug.Log("TurnRight");
            yield break;
        }

        public IEnumerator Jump()
        {
            Debug.Log("Jump");
            yield break;
        }
        #endregion

        public void Reset()
        {
            Debug.Log("reset");
        }
    }
}