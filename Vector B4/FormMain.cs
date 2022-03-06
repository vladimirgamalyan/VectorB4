using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

                file.WriteLine("(*** scaning ***)");
                file.WriteLine("M40");
                file.WriteLine("F" + speed.ToString("0.##"));
                file.WriteLine("M08");
                file.WriteLine("(* ustanovite shuo ukrya diska i najmite start *)");
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
                file.WriteLine("(* skanirovanie sohranit kak:\"oblako T.txt\" !!! *)");
                file.WriteLine("M30");
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            // Читаем файл "oblako T.txt" , парсим его и создаем файл "LINE.dxf".

            try
            {
                string line;
                using (System.IO.StreamReader srcFile = new System.IO.StreamReader("oblako T.txt"))
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
                            //string[] values = line.Split(',').Select(sValue => sValue.Trim()).ToArray();

                            // Mach4 version
                            string[] values = line.Split(' ').Select(sValue => sValue.Trim().Substring(1)).ToArray();

                            foreach (var item in values)
                            {
                                Console.WriteLine(item.ToString());
                            }

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

        private List<string> shiftProgram(List<string> lines, decimal shift)
        {
            var result = new List<string>();

            /*
                Проходим по всем строкам, и если находим значение X, то корректируем его.

            */

            bool changed = false;

            foreach (string line in lines)
            {
                string pattern = @"(X-?\d+\.\d+)";
                string[] lineParts = Regex.Split(line, pattern);

                for (int i = 0; i < lineParts.Length; ++i)
                {
                    if (lineParts[i].StartsWith("X"))
                    {
                        string valueString = lineParts[i].Substring(1);
                        try
                        {
                            decimal value = decimal.Parse(valueString, CultureInfo.InvariantCulture);
                            value -= shift;
                            changed = true;

                            NumberFormatInfo nfi = new NumberFormatInfo();
                            nfi.NumberDecimalSeparator = ".";
                            nfi.NumberGroupSeparator = "";

                            lineParts[i] = "X" + value.ToString(nfi);
                        }
                        catch (FormatException)
                        {
                            throw new Exception(String.Format("Unable to parse {0}.", valueString));
                        }
                    }
                }

                result.Add(String.Join("", lineParts));
            }

            if (!changed)
                throw new Exception("nothing to shift in loop");

            return result;
        }

        private void buttonFixReturn_Click(object sender, EventArgs e)
        {
            const string FileName = "G-Code.tap";

            List<string> lines = File.ReadLines(FileName).ToList();

            // корректируем программу так, чтобы при возврате резец не задел диск
            List<string> linesCorrected = new List<string>();
            foreach (string line in lines)
            {
                if (line == "G0X0.000Y0.000")
                {
                    linesCorrected.Add("G0X0");
                    linesCorrected.Add("G0Y0");
                }
                else
                {
                    linesCorrected.Add(line);
                }
            }


            // теперь делаем повторы

            List<string> linesResult = new List<string>();
            List<string> linesProgramBody = new List<string>();

            bool programBody = false;
            foreach (string line in linesCorrected)
            {
                if (line.Contains("M30"))
                    break;

                if (programBody)
                    linesProgramBody.Add(line);
                else
                    linesResult.Add(line);

                if (line.Contains("M3"))
                    programBody = true;
            }

            int repeats = (int) numericUpDownRepeats.Value;
            decimal repeatStep = this.numericUpDownRepeatStep.Value;

            for (int i = 0; i < repeats; ++i)
            {
                linesResult.Add(String.Format("(* cicl {0} iz {1} *)", i + 1, repeats));
                if (i > 0)
                    linesResult.AddRange(shiftProgram(linesProgramBody, repeatStep * i));
                else
                    linesResult.AddRange(linesProgramBody);
            }

            linesResult.Add("M05"); // mach4
            linesResult.Add("M30");

#if DEBUG
            File.WriteAllLines("test.txt", linesResult);
#else
            File.WriteAllLines(FileName, linesResult, Encoding.GetEncoding("Windows-1251"));
#endif
        }

        private bool onLoadSettingFlag = false;

        private void loadFormValues()
        {
            onLoadSettingFlag = true;
            this.numericUpDownRadius.Value = Properties.Settings.Default.SettingRadius;
            this.numericUpDownSpeed.Value = Properties.Settings.Default.SettingSpeed;
            this.numericUpDownStep.Value = Properties.Settings.Default.SettingStep;
            this.numericUpDownRetire.Value = Properties.Settings.Default.SettingRetire;
            this.numericUpDownRepeats.Value = Properties.Settings.Default.SettingRepeats;
            this.numericUpDownRepeatStep.Value = Properties.Settings.Default.SettingRepeatStep;
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
            Properties.Settings.Default["SettingRepeats"] = this.numericUpDownRepeats.Value;
            Properties.Settings.Default["SettingRepeatStep"] = this.numericUpDownRepeatStep.Value;
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

        private void numericUpDownRepeats_ValueChanged(object sender, EventArgs e)
        {
            saveFormValues();
        }

        private void numericUpDownRepeatStep_ValueChanged(object sender, EventArgs e)
        {
            saveFormValues();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
