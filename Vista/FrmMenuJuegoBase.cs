﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista
{
    public partial class FrmMenuJuegoBase : Form
    {
        public FrmMenuJuegoBase()
        {
            InitializeComponent();

        }
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return createParams;
            }
        }

        protected virtual void btnCrearPartida_Click(object sender, EventArgs e)
        {

        }

        protected virtual void FrmMenuJuegoBase_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
