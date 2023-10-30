using System;
using System.Collections;
using LightBot.Scripts.Managers;
using UnityEngine;

namespace LightBot.Scripts.Models
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private float positionThreshold = 0.05f;
        [SerializeField] private float rotationThreshold = 5f;
        [SerializeField] private float rotateSpeed = 10;
        private Platform _currentPlatform;
        private Direction _currentDirection;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _currentPlatform = LevelManager.Instance.GetPlatForm(Vector2.zero); //todo need init data from LevelManager
            _currentDirection = Direction.Forward; //todo need init data from LevelManager
        }

        #region Commands
        public IEnumerator SwitchLight()
        {
            Debug.Log("SwitchLight");
            Light light = LevelManager.Instance.GetLight(_currentPlatform);
            if (light == null) yield break;
            light.SwitchLight();
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
            yield return Turn(Vector3.down);
        }

        public IEnumerator TurnRight()
        {
            Debug.Log("TurnRight");
            yield return Turn(Vector3.up);
        }

        private IEnumerator Turn(Vector3 direction)
        {
            Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles + (direction * 90));
            while ((transform.rotation.eulerAngles - newRotation.eulerAngles).magnitude > rotationThreshold)
            {
                transform.Rotate(direction, Time.deltaTime * rotateSpeed);
                yield return null;
            }
            transform.rotation = newRotation;
        }

        public IEnumerator Jump()
        {
            Debug.Log("Jump");

            Platform nextPlatform = LevelManager.Instance.GetNextPlatform(_currentPlatform, _currentDirection);
            if (nextPlatform == null || nextPlatform.Height == _currentPlatform.Height ||
                nextPlatform.Height > _currentPlatform.Height + 1)
                yield break;
            Vector3 newPosition = nextPlatform.transform.position +
                                  Vector3.up * (nextPlatform.originalHeightScale * (nextPlatform.Height - 1));
            while ((transform.position - newPosition).magnitude > positionThreshold)
            {
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
                yield return null;
            }
            transform.position = newPosition;
            _currentPlatform = nextPlatform;
        }
        #endregion

        public void Reset()
        {
            Debug.Log("reset");
        }

        // private void Update()
        // {
        //     transform.Rotate(Vector3.up, Time.deltaTime);
        // }
    }
}