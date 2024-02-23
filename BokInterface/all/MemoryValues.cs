using System.Collections.Generic;
using BokInterface.All;
using BokInterface.Addresses;

namespace BokInterface {

    /// <summary>Class containing instances of memory values for the current game</summary>
    class MemoryValues {

        #region Properties

        private readonly ZoktaiAddresses zoktaiAddresses = new();
        private readonly ShinbokAddresses shinbokAddresses = new();

        /// <summary>Django-related memory values</summary>
        public IDictionary<string, DynamicMemoryValue> Django = new Dictionary<string, DynamicMemoryValue>();

        /// <summary>Solls-related memory values</summary>
        public IDictionary<string, DynamicMemoryValue> Solls = new Dictionary<string, DynamicMemoryValue>();

        /// <summary>Bike-related memory values</summary>
        public IDictionary<string, DynamicMemoryValue> Bike = new Dictionary<string, DynamicMemoryValue>();

        /// <summary>Misc memory values</summary>
        public IDictionary<string, DynamicMemoryValue> Misc = new Dictionary<string, DynamicMemoryValue>();

        /// <summary>U16 memory values</summary>
        public IDictionary<string, MemoryValueU16> U16 = new Dictionary<string, MemoryValueU16>();

        #endregion

        /// <summary>Constructor</summary>
        /// <param name="shorterGameName">Shortened game name (used for setting the lists containing the memory values instances)</param>
        public MemoryValues(string shorterGameName) {

            ClearLists();

            switch (shorterGameName) {
                case "Boktai":
                    InitializeBoktaiList();
                    break;
                case "Zoktai":
                    InitializeZoktaiList();
                    break;
                case "Shinbok":
                    InitializeShinbokList();
                    break;
                case "LunarKnights":
                    InitializeLunarKnightsList();
                    break;
                default:
                    break;
            }
        }

        private void ClearLists() {
            Django.Clear();
            Solls.Clear();
            Bike.Clear();
            Misc.Clear();
        }

        private void InitializeBoktaiList() {

        }

        private void InitializeZoktaiList() {
            Django.Add("current_hp", new DynamicMemoryValue("current_hp", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_hp"]));
            Django.Add("current_ene", new DynamicMemoryValue("current_ene", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_ene"]));

            // Stats
            Django.Add("vit", new DynamicMemoryValue("vit", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_vit"]));
            Django.Add("spr", new DynamicMemoryValue("spr", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_spr"]));
            Django.Add("str", new DynamicMemoryValue("str", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_str"]));
            Django.Add("agi", new DynamicMemoryValue("agi", zoktaiAddresses.Misc["stat"], zoktaiAddresses.Django["current_agi"]));

            // U16
            U16.Add("sword_skill", new MemoryValueU16("sword_skill", zoktaiAddresses.Django["sword_skill"]));
            U16.Add("spear_skill", new MemoryValueU16("spear_skill", zoktaiAddresses.Django["spear_skill"]));
            U16.Add("hammer_skill", new MemoryValueU16("hammer_skill", zoktaiAddresses.Django["hammer_skill"]));
            U16.Add("fists_skill", new MemoryValueU16("fists_skill", zoktaiAddresses.Django["fists_skill"]));
            U16.Add("gun_skill", new MemoryValueU16("gun_skill", zoktaiAddresses.Django["gun_skill"]));
        }

        private void InitializeShinbokList() {
            Django.Add("current_hp", new DynamicMemoryValue("current_hp", shinbokAddresses.Misc["room"], shinbokAddresses.Django["hp"]));

            // Stats
            Django.Add("base_vit", new DynamicMemoryValue("base_vit", shinbokAddresses.Misc["stat"], shinbokAddresses.Django["base_vit"]));
            Django.Add("base_spr", new DynamicMemoryValue("base_spr", shinbokAddresses.Misc["stat"], shinbokAddresses.Django["base_spr"]));
            Django.Add("base_str", new DynamicMemoryValue("base_str", shinbokAddresses.Misc["stat"], shinbokAddresses.Django["base_str"]));
        }

        private void InitializeLunarKnightsList() {

        }
    }
}
