using System;
using UnityEngine;

namespace LightBot.Scripts
{
    public class Light : MonoBehaviour
    {
        [SerializeField] private Material offMaterial;
        [SerializeField] private Material onMaterial;

        [SerializeField] private MeshRenderer renderer;
        /*[SerializeField]*/
        private bool _isLightOn;

        public static Action<bool> OnSwitchLight;

        public void SwitchLight()
        {
            _isLightOn = !_isLightOn;
            renderer.material = _isLightOn ? onMaterial : offMaterial;
            OnSwitchLight?.Invoke(_isLightOn);
        }
    }
}