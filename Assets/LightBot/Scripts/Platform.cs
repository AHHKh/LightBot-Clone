using System;
using UnityEngine;

namespace LightBot.Scripts
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] protected Vector2 position;
        [SerializeField] protected int height;
        [SerializeField] protected Transform platform;
        [SerializeField] protected float originalHeightScale = 0.5f;


        private void OnDrawGizmos()
        {
            platform.localScale =
                new Vector3(platform.localScale.x, height * originalHeightScale, platform.localScale.z);
        }
    }
}