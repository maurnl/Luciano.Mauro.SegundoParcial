using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMenuTruco : Form
    {
        private PresentadorMenuTruco presentadorMenuTruco;
        public FrmMenuTruco()
        {
            InitializeComponent();
            this.presentadorMenuTruco = new PresentadorMenuTruco(this);
        }
    }
}
