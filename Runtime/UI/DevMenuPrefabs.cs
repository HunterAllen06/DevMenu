using UnityEngine;

namespace HunterAllen.DevMenu
{
    [CreateAssetMenu(fileName = "DevMenuPrefabs", menuName = "Dev Menu/Prefabs")]
    public class DevMenuPrefabs : ScriptableObject
    {
        public DevMenuGroup Group;
        public DevMenuEntryUI Entry;
        public DevMenuButton Button;
        public DevMenuToggle Toggle;
        public DevMenuSlider Slider;
        public DevMenuDropdown Dropdown;
    }
}