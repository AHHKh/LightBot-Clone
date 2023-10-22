using System;
using UnityEngine;

namespace LightBot.Scripts
{
    public class Platform : MonoBehaviour
    {
        [field: SerializeField] public Vector2 Position { get; private set; }
        [field: SerializeField, Min(1)] public int Height { get; private set; }
        [SerializeField] private Transform platform;
        [SerializeField] private float originalHeightScale = 0.5f;
        
        private void OnDrawGizmos()
        {
            platform.localScale =
                new Vector3(platform.localScale.x, Height * originalHeightScale, platform.localScale.z);
        }
    }
}