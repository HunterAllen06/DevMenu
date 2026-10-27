using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HunterAllen.DevMenu
{
    public class DevMenuButton : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _label;
        [SerializeField] Button _button;

        public event Action OnClick;
        // Func<bool>

        internal DevMenuButton Initialize(string label)
        {
            _label.text = label;
            _button.onClick.AddListener(Click);
            return this;
        }

        public DevMenuButton WithClickEvent(Action onClick)
        {
            OnClick += () => onClick?.Invoke();
            return this;
        }

        public void Click() => OnClick?.Invoke();
    }
}