using System;
using UnityEngine;

namespace LightBot.Scripts.Models
{
    [RequireComponent(typeof(Platform))]
    public class Light : MonoBehaviour
    {
        [SerializeField] private Material offMaterial;
        [SerializeField] private Material onMaterial;

        [SerializeField] private MeshRenderer renderer;

        public Platform Platform { get; private set; }

        /*[SerializeField]*/
        private bool _isLightOn;

        private void Awake()
        {
            Platform = GetComponent<Platform>();
        }

        public Action<bool> OnSwitchLight;

        public void SwitchLight()
        {
            _isLightOn = !_isLightOn;
            renderer.material = _isLightOn ? onMaterial : offMaterial;
            OnSwitchLight?.Invoke(_isLightOn);
        }
    }
}