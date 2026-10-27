using System;
using System.Collections.Generic;
using HunterAllen.Menus;
using TMPro;
using UnityEngine;

namespace HunterAllen.DevMenu
{
    public class DevMenuGroup : MonoBehaviour
    {
        [SerializeField] Menu _menu;
        public Dictionary<string, DevMenuEntryUI> Entries = new();

        internal DevMenuGroup Initialize(MenuGroup parentMenuGroup)
        {
            _menu.ParentMenuGroup = parentMenuGroup;
            return this;
        }

        public void Open() => _menu.EnterMenu();

        public void AddEntry(DevMenuEntryUI entry)
        {
            Entries.Add(entry.Id, entry);
        }
    }
}