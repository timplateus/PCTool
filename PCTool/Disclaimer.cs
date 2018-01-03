using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCTool
{
    /// <summary>
    ///     A copyright disclaimer for the usage of this program. Will be invoked when the user
    ///     clicks DisclaimerLbl.
    /// </summary>
    /// <remarks> Tplateus, 3/01/2018. </remarks>
    public partial class Disclaimer : Form
    {

        /// <summary> Default constructor. </summary>
        /// <remarks> Tplateus, 3/01/2018. </remarks>
        public Disclaimer()
        {
            InitializeComponent();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
