using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon_A3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                    file.WriteLine("G31X20");
                    file.WriteLine("G0X-" + retire.ToString("0.##"));
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
            // Читаем oblako T файл, парсим его и создаем LINE.dxf.
            
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

        private void numericUpDownStep_ValueChanged(object sender, EventArgs e)
        {
            decimal radius = this.numericUpDownRadius.Value;
            decimal step = this.numericUpDownStep.Value;
            if (radius < step)
                this.numericUpDownStep.Value = radius;
        }

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            decimal radius = this.numericUpDownRadius.Value;
            decimal step = this.numericUpDownStep.Value;
            if (radius < step)
                this.numericUpDownRadius.Value = step;
        }
    }
}
