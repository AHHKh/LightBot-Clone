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
        [SerializeField] private float moveSpeed = 10;
        [SerializeField] private float rotateSpeed = 100;
        private Platform _currentPlatform;
        private Direction _currentDirection;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _currentPlatform = LevelManager.Instance.GetPlatFormWithPosition(Vector3.forward); //todo need init data from LevelManager
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
            if (nextPlatform == null || (int)nextPlatform.Position.z != (int)_currentPlatform.Position.z)
                yield break;
            while ((transform.position - nextPlatform.transform.position).magnitude > positionThreshold)
            {
                transform.position = Vector3.Lerp(transform.position, nextPlatform.transform.position,
                                                  Time.deltaTime * moveSpeed);
                yield return null;
            }
            transform.position = nextPlatform.transform.position;
            _currentPlatform = nextPlatform;
        }

        public IEnumerator TurnLeft()
        {
            Debug.Log("TurnLeft");
            yield return Turn(Vector3.down, GetNewDirection(Vector3.down));
        }

        public IEnumerator TurnRight()
        {
            Debug.Log("TurnRight");
            yield return Turn(Vector3.up, GetNewDirection(Vector3.up));
        }

        private IEnumerator Turn(Vector3 direction, Direction newDirection)
        {
            Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles + (direction * 90));
            while ((transform.rotation.eulerAngles - newRotation.eulerAngles).magnitude > rotationThreshold)
            {
                transform.Rotate(direction, Time.deltaTime * rotateSpeed);
                yield return null;
            }
            _currentDirection = newDirection;
            transform.rotation = newRotation;
        }

        private Direction GetNewDirection(Vector3 turnDirection)
        {
            return _currentDirection switch //Vector3.up means Right
            {
                Direction.None => Direction.None,
                Direction.Forward => turnDirection == Vector3.up ? Direction.Right : Direction.Left,
                Direction.Left => turnDirection == Vector3.up ? Direction.Forward : Direction.Backward,
                Direction.Right => turnDirection == Vector3.up ? Direction.Backward : Direction.Forward,
                Direction.Backward => turnDirection == Vector3.up ? Direction.Left : Direction.Right,
                _ => Direction.None,
            };
        }

        public IEnumerator Jump()
        {
            Debug.Log("Jump");
            Platform nextPlatform = LevelManager.Instance.GetNextPlatform(_currentPlatform, _currentDirection);
            if (nextPlatform == null || nextPlatform.Position.z == _currentPlatform.Position.z ||
                nextPlatform.Position.z > _currentPlatform.Position.z + 1)
                yield break;
            Vector3 newPosition = nextPlatform.transform.position +
                                  Vector3.up * (nextPlatform.originalHeightScale * (nextPlatform.Position.z - 1));
            while ((transform.position - newPosition).magnitude > positionThreshold)
            {
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
                yield return null;
            }
            transform.position = newPosition;
            _currentPlatform = nextPlatform;
        }
        #endregion

        public void Reset()
        {
            Debug.Log("reset");
            _currentDirection = Direction.Forward;
            _currentPlatform = LevelManager.Instance.GetPlatFormWithPosition(Vector3.zero);
            Vector3 newPosition = _currentPlatform.transform.position +
                                  Vector3.up * (_currentPlatform.originalHeightScale * (_currentPlatform.Position.z - 1));
            transform.position = newPosition;
            transform.rotation = new Quaternion();
        }
    }
}