using System;
using HunterAllen.Menus;
using TMPro;
using UnityEngine;

namespace HunterAllen.DevMenu
{
    public class DevMenuGroup : MonoBehaviour
    {
        [SerializeField] Menu _menu;

        internal DevMenuGroup Initialize(MenuGroup parentMenuGroup)
        {
            _menu.ParentMenuGroup = parentMenuGroup;
            return this;
        }

        public void Open() => _menu.EnterMenu();
    }
}