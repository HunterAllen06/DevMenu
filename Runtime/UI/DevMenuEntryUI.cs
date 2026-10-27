using System;
using TMPro;
using UnityEngine;

namespace HunterAllen.DevMenu
{
    public class DevMenuEntryUI : MonoBehaviour
    {
        public string Id;
        [SerializeField] TextMeshProUGUI _label;
        [SerializeField] Transform _anchor;

        internal DevMenuEntryUI Build(DevMenuEntry entry, DevMenuPrefabs prefabs)
        {
            Id = entry.Label;
            _label.text = entry.Label;

            Action<DevMenuEntry, DevMenuPrefabs> spawnFunction = entry.Type switch
            {
                DevMenuEntryType.Toggle => SpawnToggle,
                DevMenuEntryType.Slider => SpawnSlider,
                DevMenuEntryType.Dropdown => SpawnDropdown,
                _ => null,
            };

            if (entry.HasButton)
            {
                var button = Instantiate(prefabs.Button, _anchor);
                button.Initialize("Run").WithClickEvent(entry.OnClick);
            }

            spawnFunction?.Invoke(entry, prefabs);

            return this;
        }

        void SpawnToggle(DevMenuEntry entry, DevMenuPrefabs prefabs)
        {
            var toggle = Instantiate(prefabs.Toggle, _anchor);
            toggle.SetValue(entry.ToggleDefault);

            entry.GetValue = () => toggle.Toggle.isOn;

            if (!entry.HasButton)
            {
                // toggle.OnValueChange += OnValueChange;
                toggle.OnValueChange += (value) => entry.OnClick?.Invoke();
            }
        }
        void SpawnSlider(DevMenuEntry entry, DevMenuPrefabs prefabs)
        {
            var slider = Instantiate(prefabs.Slider, _anchor);
            slider.Slider.minValue = entry.SliderMinValue;
            slider.Slider.maxValue = entry.SliderMaxValue;
            slider.SetValue(entry.SliderDefault);

            entry.GetValue = () => slider.Slider.value;

            if (!entry.HasButton)
            {
                // slider.OnValueChange += OnValueChange;
                slider.OnValueChange += (value) => entry.OnClick?.Invoke();
            }
        }
        void SpawnDropdown(DevMenuEntry entry, DevMenuPrefabs prefabs)
        {
            var dropdown = Instantiate(prefabs.Dropdown, _anchor);
            dropdown.Dropdown.AddOptions(entry.Options);
            dropdown.SetValue(entry.DropdownDefault);

            entry.GetValue = () => dropdown.Dropdown.value;

            if (!entry.HasButton)
            {
                // dropdown.OnValueChange += OnValueChange;
                dropdown.OnValueChange += (value) => entry.OnClick?.Invoke();
            }
        }
    }
}