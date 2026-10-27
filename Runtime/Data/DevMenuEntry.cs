using System;
using System.Collections.Generic;

namespace HunterAllen.DevMenu
{
    [Serializable]
    public class DevMenuEntry
    {
        public string Group = "Default";
        public string Label = "N/A";
        public Action OnClick = null;
        public Func<object> GetValue = null;
        public bool HasButton = false;
        public DevMenuEntryType Type = DevMenuEntryType.LabelOnly;
        public bool ToggleDefault = false;
        public float SliderDefault = 0f;
        public bool SliderWholeNumbers;
        public int DropdownDefault = 0;
        public float SliderMinValue = 0f;
        public float SliderMaxValue = 1f;
        public List<string> Options = null;
    }
    public class DevMenuEntryBuilder
    {
        public DevMenuUI Ui;
        public DevMenuEntry Entry;

        public DevMenuEntryBuilder WithEvent(Action onClick)
        {
            Entry.OnClick += onClick;
            return this;
        }
        public DevMenuEntryBuilder WithEvent<T>(Action<T> onClick)
        {
            Entry.OnClick += () => onClick?.Invoke((T)Entry.GetValue());
            return this;
        }

        public DevMenuEntryBuilder WithButton(Action onClick)
        {
            Entry.OnClick += onClick;
            Entry.HasButton = true;
            return this;
        }
        public ButtonData<T> WithButton<T>(Action<T> onClick)
        {
            var buttonData = new ButtonData<T>(this);
            Entry.OnClick += () => onClick?.Invoke((T)Entry.GetValue());
            Entry.HasButton = true;
            return buttonData;
        }
        
        public DevMenuEntryBuilder WithToggle()
        {
            Entry.Type = DevMenuEntryType.Toggle;
            return this;
        }
        public DevMenuEntryBuilder WithSlider(float min, float max, bool wholeNumbers = false)
        {
            Entry.Type = DevMenuEntryType.Slider;
            Entry.SliderMinValue = min;
            Entry.SliderMaxValue = max;
            Entry.SliderWholeNumbers = wholeNumbers;
            return this;
        }
        public DevMenuEntryBuilder WithDropdown(List<string> options)
        {
            Entry.Type = DevMenuEntryType.Dropdown;
            Entry.Options = options;
            return this;
        }

        /// <summary>
        /// Spawns the entry in the dev menu.
        /// </summary>
        public void Build()
        {
            Ui.SpawnEntry(Entry);
        }
    }
    public class ButtonData<T>
    {
        DevMenuEntryBuilder _builder;
        Action<T> _onClick;

        public ButtonData(DevMenuEntryBuilder builder)
        {
            _builder = builder;
        }

        public ButtonData<T> WithToggle()
        {
            _builder.Entry.Type = DevMenuEntryType.Toggle;
            return this;
        }
        public ButtonData<T> WithSlider(float min, float max, bool wholeNumbers = false)
        {
            _builder.Entry.Type = DevMenuEntryType.Slider;
            _builder.Entry.SliderMinValue = min;
            _builder.Entry.SliderMaxValue = max;
            _builder.Entry.SliderWholeNumbers = wholeNumbers;
            return this;
        }
        public ButtonData<T> WithDropdown(List<string> options)
        {
            _builder.Entry.Type = DevMenuEntryType.Dropdown;
            _builder.Entry.Options = options;
            return this;
        }

        public DevMenuEntryBuilder BuildButton()
        {
            return _builder;
        }
    }
    public enum DevMenuEntryType
    {
        LabelOnly,
        Toggle,
        Slider,
        Dropdown
    }
}