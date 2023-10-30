using UnityEngine;

namespace LightBot.Scripts.Models
{
    public class Platform : MonoBehaviour
    {
        [field: SerializeField] public Vector2 Position { get; private set; }
        [field: SerializeField, Min(1)] public int Height { get; private set; }
        [field: SerializeField] public float originalHeightScale { get; private set; } = 0.5f;
        [SerializeField] private Transform platform;

        private void OnDrawGizmos()
        {
            platform.localScale =
                new Vector3(platform.localScale.x, Height * originalHeightScale, platform.localScale.z);
        }
    }
}