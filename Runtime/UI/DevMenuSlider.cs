using System;
using UnityEngine;
using UnityEngine.UI;

namespace HunterAllen.DevMenu
{
    public class DevMenuSlider : DevMenuEntryParameter<float>
    {
        public Slider Slider;
        
        protected override void Initialize()
        {
            Slider.onValueChanged.AddListener(ValueChange);
        }
        public override void SetValue(float value) => Slider.SetValueWithoutNotify(value);
    }
}