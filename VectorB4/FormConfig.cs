using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VectorB4
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            switch (AppConfig.Instance.Format)
            {
                case AppConfig.FormatType.Mach3:
                    radioButtonFormatMach3.Checked = true;
                    break;
                case AppConfig.FormatType.Mach4:
                    radioButtonFormatMach4.Checked = true;
                    break;
            }

            switch (AppConfig.Instance.Orientation)
            {
                case AppConfig.OrientationType.Hor:
                    radioButtonOrientationHor.Checked = true;
                    break;
                case AppConfig.OrientationType.Ver:
                    radioButtonOrientationVer.Checked = true;
                    break;
            }

            switch (AppConfig.Instance.Repeats)
            {
                case AppConfig.RepeatsType.Zero:
                    radioButtonRepeatZero.Checked = true;
                    break;
                case AppConfig.RepeatsType.End:
                    radioButtonRepeatEnd.Checked = true;
                    break;
            }
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (radioButtonFormatMach3.Checked)
                AppConfig.Instance.Format = AppConfig.FormatType.Mach3;
            else if (radioButtonFormatMach4.Checked)
                AppConfig.Instance.Format = AppConfig.FormatType.Mach4;

            if (radioButtonOrientationHor.Checked)
                AppConfig.Instance.Orientation = AppConfig.OrientationType.Hor;
            else if (radioButtonOrientationVer.Checked)
                AppConfig.Instance.Orientation = AppConfig.OrientationType.Ver;

            if (radioButtonRepeatZero.Checked)
                AppConfig.Instance.Repeats = AppConfig.RepeatsType.Zero;
            else if (radioButtonRepeatEnd.Checked)
                AppConfig.Instance.Repeats = AppConfig.RepeatsType.End;

            AppConfig.Instance.Save();
        }
    }
}
