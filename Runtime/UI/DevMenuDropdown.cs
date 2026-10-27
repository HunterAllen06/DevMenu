using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HunterAllen.DevMenu
{
    public class DevMenuDropdown : DevMenuEntryParameter<int>
    {
        public TMP_Dropdown Dropdown;

        protected override void Initialize()
        {
            Dropdown.onValueChanged.AddListener(ValueChange);
        }
        public override void SetValue(int value) => Dropdown.SetValueWithoutNotify(value);
    }
}