using System;
using UnityEngine;

namespace LightBot.Scripts.Models
{
    [Serializable]
    public class PlatformData
    {
        [field: SerializeField] public Vector2 Position { get; private set; }
        [field: SerializeField, Min(1)] public int Height { get; private set; }
    }
}
