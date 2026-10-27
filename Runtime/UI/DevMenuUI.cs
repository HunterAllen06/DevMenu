using System;
using System.Collections.Generic;
using HunterAllen.Menus;
using UnityEngine;

namespace HunterAllen.DevMenu
{
    [DefaultExecutionOrder(-1)]
    public class DevMenuUI : MonoBehaviour
    {
        public static DevMenuUI Instance;
        
        [SerializeField] DevMenuPrefabs _prefabs;
        [SerializeField] Transform _groupButtonsAnchor;
        [SerializeField] MenuGroup _groupsAnchor;

        Dictionary<string, DevMenuGroup> _groups = new();

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public DevMenuEntryBuilder AddEntry(string group, string label)
        {
            var groupComponent = GetGroup(group);

            return new DevMenuEntryBuilder() { Ui = this, Entry = new DevMenuEntry() { Group = group, Label = label } };
        }
        public void SpawnEntry(DevMenuEntry entry)
        {
            var group = GetGroup(entry.Group);

            if (group.Entries.ContainsKey(entry.Label))
            {
                Debug.LogWarning($"Dev Menu group [{group}] already has an entry with the label [{entry.Label}]");
                return;
            }

            if (_groupsAnchor.ActiveMenu == null) group.Open();

            var entryUi = Instantiate(_prefabs.Entry, group.transform);
            entryUi.Build(entry, _prefabs);
            group.AddEntry(entryUi);
        }

        public void RemoveEntry(string group, string label)
        {
            if (_groups.TryGetValue(group, out var groupComponent) && groupComponent.Entries.TryGetValue(label, out var entry)) Destroy(entry.gameObject);
        }

        DevMenuGroup GetGroup(string group)
        {
            if (_groups.TryGetValue(group, out var groupComponent))
            {
                return groupComponent;
            }

            return SpawnGroup(group);
        }
        DevMenuGroup SpawnGroup(string group)
        {
            var groupComponent = Instantiate(_prefabs.Group, _groupsAnchor.transform);
            _groups.Add(group, groupComponent.Initialize(_groupsAnchor));

            var groupButton = Instantiate(_prefabs.Button, _groupButtonsAnchor);
            groupButton.Initialize(group).OnClick += () => groupComponent.Open();

            return groupComponent;
        }
    }
}