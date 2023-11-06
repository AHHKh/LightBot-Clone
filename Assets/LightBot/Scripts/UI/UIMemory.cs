using LightBot.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LightBot.Scripts.UI
{
    public class UIMemory : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private Button selectButton;
        [SerializeField] private Image[] commandSlots;
        private Memory _memory;
        private Color _selectColor, _normalColor;
        private bool _isSelected;

        public void Initialize(Memory memory, Color selectColor, Color normalColor)
        {
            _memory = memory;
            _selectColor = selectColor;
            _normalColor = normalColor;
        }

        public void Select_Deselect()
        {
        }
    }
}