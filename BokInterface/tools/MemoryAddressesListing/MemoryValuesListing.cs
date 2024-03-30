using System.Data;
using System.Drawing;
using System.Windows.Forms;

using BokInterface.Addresses;

namespace BokInterface.Tools.MemoryValuesListing {
    /// <summary>Shows the list of all memory addresses listed for a game, based on the ones added in the Bok Interface itself</summary>
    class MemoryValuesListing : Form {

        #region Main properties

        public int index = 0;
        private DataTable dataTable = new();
        private string currentGame = "";

        #endregion

        #region Memory addresses properties

        private readonly BoktaiAddresses boktaiAddresses = new();
        private readonly ZoktaiAddresses zoktaiAddresses = new();
        private readonly ShinbokAddresses shinbokAddresses = new();
        private readonly LunarKnightsAddresses lunarKnightsAddresses = new();

        #endregion

        #region Subwindow-related methods

        public MemoryValuesListing(string name, string title, int width, int height, string currentGame, string icon = "", Form? parentForm = null) {
            Name = name;
            Text = title;
            Icon = GetIcon(icon);
            AutoScaleDimensions = new SizeF(6F, 15F);
            AutoScaleMode = AutoScaleMode.Inherit;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = SystemColors.Control;
            Font = BokInterface.defaultFont;
            AutoScroll = true;
            SetSubwindowSize(width, height);
            this.currentGame = currentGame;

            if (parentForm != null) {
                Owner = parentForm;
            }

            // Prevent flickering
            // SetStyle(
            //     ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
            //     true
            // );
        }

        /// <summary>Get the specified icon if it exist</summary>
        /// <param name="fileName">File name (without .ico extension)</param>
        /// <returns><c>System.Drawing.Icon</c>Specified Icon instance (or default if the specified icon could not be found)</returns>
        protected Icon GetIcon(string fileName) {
            if (fileName == "") {
                return Icon;
            } else {
                return (Icon)Properties.Resources.ResourceManager.GetObject(fileName);
            }
        }

        /// <summary>Sets the subwindow's size</summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        protected void SetSubwindowSize(int width, int height) {
            ClientSize = new Size(width, height);
        }

        /// <summary>
        /// <para>Initialize frame loop</para>
        /// <para>Adds the corresponding methods to BokInterface.functionsList to have them be executed every frame</para>
        /// <para>Also get the index from that list for removing the methods when closing the Tile Data Viewer</para>
        /// </summary>
        public void InitializeFrameLoop() {
            BokInterface.functionsList.Add(Refresh);

            /**
             * Get the index of the added function,
             * used for removing the method from BokInterface.functionsList when the subwindow is closed
             */
            index = BokInterface.functionsList.Count - 1;
        }

        #endregion
    }
}