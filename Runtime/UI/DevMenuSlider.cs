using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HunterAllen.DevMenu
{
    public class DevMenuSlider : DevMenuEntryParameter<float>
    {
        public Slider Slider;
        [SerializeField] TextMeshProUGUI _valueText;
        
        protected override void Initialize()
        {
            Slider.onValueChanged.AddListener(ValueChange);
        }
        public override void SetValue(float value) => Slider.SetValueWithoutNotify(value);
        public override void ValueChange(float value)
        {
            base.ValueChange(value);
            if (_valueText) _valueText.text = value.ToString("0.00");
        }
    }
}