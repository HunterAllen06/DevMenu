using System;
using UnityEngine;

namespace HunterAllen.DevMenu
{
    public abstract class DevMenuEntryParameter<T> : MonoBehaviour
    {
        public event Action<T> OnValueChange;

        void Awake()
        {
            Initialize();
        }
        protected abstract void Initialize();
        public void ValueChange(T value) => OnValueChange?.Invoke(value);
        public virtual void SetValue(T value) { }
    }
}