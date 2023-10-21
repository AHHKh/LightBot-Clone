using UnityEngine;

namespace LightBot.Scripts
{
    public class LightPlatform : Platform
    {
        [SerializeField] private bool isLightOn;
        [SerializeField] private Material offMaterial;
        [SerializeField] private Material onMaterial;
    }
}