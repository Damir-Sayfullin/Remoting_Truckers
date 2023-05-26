using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truckers
{
    public partial class FormLogist : Form
    {
        private FormLogin formLogin;
        public FormLogist(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin;
        }
    }
}
