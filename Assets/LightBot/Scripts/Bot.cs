using UnityEngine;

namespace LightBot.Scripts
{
    public class Bot : MonoBehaviour
    {
        private Vector2 _position;
        private int _height;
        private Direction _currentDirection;

        #region Commands
        public void SwitchLight()
        {
            Debug.Log("SwitchLight");
        }

        public void Move()
        {
            Debug.Log("Move");
        }

        public void TurnLeft()
        {
            Debug.Log("TurnLeft");
        }

        public void TurnRight()
        {
            Debug.Log("TurnRight");
        }

        public void Jump()
        {
            Debug.Log("Jump");
        }
        #endregion
    }
}