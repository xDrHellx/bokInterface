namespace BokInterface.All {

    /// <summary>Main class for utilities</summary>
    public class Utilities {

        public Utilities() {

        }

        /// <summary>Retrieve the code for the current game running on BizHawk</summary>
        /// <returns><c>uint</c>Game code</returns>
        public uint GetGameCode() {
            var code = APIs.Memory.ReadU32(0x080000AC);

            // If the code is 0, it's not a GBA game & we need to try different memory addresses
            if(code == 0){
                code = APIs.Memory.ReadU32(0x3FFE0C, "Main RAM");
            }

            return code;
        }

        /// <summary>Shortcut method for retrieving the value of a dynamic memory address</summary>
        /// <param name="firstAddress">First address to read (U32)</param>
        /// <param name="secondAddress">Second address to read (U16)</param>
        /// <returns><c>uint</c>Value</returns>
        public uint ReadDynamicAddress(uint firstAddress, uint secondAddress) {
            return APIs.Memory.ReadU16(APIs.Memory.ReadU32(firstAddress) + secondAddress);
        }

        /// <summary>Shortcut method for retrieving the value of a dynamic memory address</summary>
        /// <param name="value">Value to set</param>
        /// <param name="firstAddress">First address (U32)</param>
        /// <param name="secondAddress">Second address (U16)</param>
        public void WriteDynamicAddress(uint value, uint firstAddress, uint secondAddress) {
            APIs.Memory.WriteU16(APIs.Memory.ReadU32(firstAddress) + secondAddress, value);
        }
    }
}