using System;
using UnityEngine;
using UnityEngine.UI;

namespace HunterAllen.DevMenu
{
    public class DevMenuToggle : DevMenuEntryParameter<bool>
    {
        public Toggle Toggle;

        protected override void Initialize()
        {
            Toggle.onValueChanged.AddListener(ValueChange);
        }
        public override void SetValue(bool value) => Toggle.SetIsOnWithoutNotify(value);
    }
}