using System;
using UnityEngine;

namespace LightBot.Scripts.Models
{
    [Serializable]
    public class Memory
    {
        [field: SerializeField] public MemoryType MemoryType { get; private set; }
        [field: SerializeField] public int Capacity { get; private set; }

        public Memory(MemoryType type, int capacity)
        {
            MemoryType = type;
            Capacity = capacity;
        }
    }
}