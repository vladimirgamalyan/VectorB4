using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vector_B4
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            loadFormValues();
        }

        private void buttonCreateTap_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"scaner.tap", false, Encoding.GetEncoding("Windows-1251")))
            {
                decimal radius = this.numericUpDownRadius.Value;
                decimal speed = this.numericUpDownSpeed.Value;
                decimal step = this.numericUpDownStep.Value;
                decimal retire = this.numericUpDownRetire.Value;

                decimal currentRadius = 0;

                file.WriteLine("(*** сканирование ***)");
                file.WriteLine("M40");
                file.WriteLine("F" + speed.ToString("0.##"));
                file.WriteLine("(установите щуп у края диска, затем нажмите СТАРТ!*)");
                file.WriteLine("M00");
                file.WriteLine("G91");

                do {

                    file.WriteLine("G31X-20");
                    file.WriteLine("G0X" + retire.ToString("0.##"));
                    file.WriteLine("G0Y" + step.ToString("0.##"));

                    currentRadius += step;
                } while (currentRadius <= radius);

                file.WriteLine("G90");
                file.WriteLine("G0X0");
                file.WriteLine("G0Y0");
                file.WriteLine("(* сканирование сохранить как:\"oblako T\" !!! *)");
                file.WriteLine("M30");
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            // Читаем файл "oblako T" , парсим его и создаем файл "LINE.dxf".

            try
            {
                string line;
                using (System.IO.StreamReader srcFile = new System.IO.StreamReader("oblako T"))
                {
                    using (System.IO.StreamWriter dstFile = new System.IO.StreamWriter("LINE.dxf"))
                    {
                        dstFile.WriteLine("0");
                        dstFile.WriteLine("SECTION");
                        dstFile.WriteLine("  2");
                        dstFile.WriteLine("ENTITIES");
                        dstFile.WriteLine("  0");
                        dstFile.WriteLine("POLYLINE");
                        dstFile.WriteLine("  8");
                        dstFile.WriteLine("");

                        while ((line = srcFile.ReadLine()) != null)
                        {
                            string[] values = line.Split(',').Select(sValue => sValue.Trim()).ToArray();

                            dstFile.WriteLine("  0");
                            dstFile.WriteLine("VERTEX");
                            dstFile.WriteLine("  8");
                            dstFile.WriteLine("0");
                            dstFile.WriteLine(" 10");
                            dstFile.WriteLine(values[0]);
                            dstFile.WriteLine(" 20");
                            dstFile.WriteLine(values[1]);
                            dstFile.WriteLine(" 30");
                            dstFile.WriteLine(values[2]);
                            dstFile.WriteLine(" 70");
                            dstFile.WriteLine("    32");
                        }

                        dstFile.WriteLine("  0");
                        dstFile.WriteLine("SEQEND");
                        dstFile.WriteLine("  0");
                        dstFile.WriteLine("ENDSEC");
                        dstFile.WriteLine("  0");
                        dstFile.WriteLine("EOF");
                    }
                }
            }
            catch
            {
            }
        }

        private void buttonFixReturn_Click(object sender, EventArgs e)
        {
            // Корректируем файл, чтобы при возврате резец не задел диск.

            string tempLineValue;
            List<string> result = new List<string>();
            using (FileStream inputStream = File.OpenRead("G-Code.tap"))
            {
                using (StreamReader inputReader = new StreamReader(inputStream))
                {
                    while (null != (tempLineValue = inputReader.ReadLine()))
                    {
                        if (tempLineValue == "G0X0.000Y0.000")
                        {
                            result.Add("G0X0");
                            result.Add("G0Y0");
                        }
                        else
                        {
                            result.Add(tempLineValue);
                        }
                    }
                }
            }

            using (StreamWriter outputWriter = new StreamWriter("G-Code.tap"))
            {
                foreach (string s in result)
                {
                    outputWriter.WriteLine(s);
                }
            }
        }

        private bool onLoadSettingFlag = false;

        private void loadFormValues()
        {
            onLoadSettingFlag = true;
            this.numericUpDownRadius.Value = Properties.Settings.Default.SettingRadius;
            this.numericUpDownSpeed.Value = Properties.Settings.Default.SettingSpeed;
            this.numericUpDownStep.Value = Properties.Settings.Default.SettingStep;
            this.numericUpDownRetire.Value = Properties.Settings.Default.SettingRetire;
            onLoadSettingFlag = false;
        }

        private void saveFormValues()
        {
            if (onLoadSettingFlag)
                return;
            Properties.Settings.Default["SettingRadius"] = this.numericUpDownRadius.Value;
            Properties.Settings.Default["SettingSpeed"] = this.numericUpDownSpeed.Value;
            Properties.Settings.Default["SettingStep"] = this.numericUpDownStep.Value;
            Properties.Settings.Default["SettingRetire"] = this.numericUpDownRetire.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownStep_ValueChanged(object sender, EventArgs e)
        {
            decimal radius = this.numericUpDownRadius.Value;
            decimal step = this.numericUpDownStep.Value;
            if (radius < step)
                this.numericUpDownStep.Value = radius;
            saveFormValues();
        }

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            decimal radius = this.numericUpDownRadius.Value;
            decimal step = this.numericUpDownStep.Value;
            if (radius < step)
                this.numericUpDownRadius.Value = step;
            saveFormValues();
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            saveFormValues();
        }

        private void numericUpDownRetire_ValueChanged(object sender, EventArgs e)
        {
            saveFormValues();
        }
    }
}
