using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HPMall.HpControl
{
    /// <summary>
    /// HpRadio.xaml 的交互逻辑
    /// </summary>
    public partial class HpRadio : UserControl
    {
        public HpRadio()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private string _txt;
        public string Txt
        {
            set
            {
                _txt = value;
            }
            get
            {
                return _txt;
            }
        }
    }
}
