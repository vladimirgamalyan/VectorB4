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

namespace VectorB4
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
            var generator = new ScannerGenerator();
            var parameters = new ScannerGenerator.TapParameters
            {
                Radius = numericUpDownRadius.Value,
                Speed = numericUpDownSpeed.Value,
                Step = numericUpDownStep.Value,
                Retire = numericUpDownRetire.Value,
                Orientation = AppConfig.Instance.Orientation,
                InputOblakoFile = Properties.Settings.Default.InputOblakoFile
            };

            string outputPath = Properties.Settings.Default.OutputScanerFile;

            try
            {
                // Генерация строк
                List<string> lines = generator.GenerateLines(parameters);

                // Запись в файл
                File.WriteAllLines(outputPath, lines, Encoding.GetEncoding("Windows-1251"));

                MessageBox.Show($"Файл {outputPath} успешно создан.",
                                "Готово",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка генерации: " + ex.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string sourceFileName = Properties.Settings.Default.InputOblakoFile;
            string outputFileName = Properties.Settings.Default.OutputDXFFile;

            if (!File.Exists(sourceFileName))
            {
                ShowError("Файл не найден: " + sourceFileName);
                return;
            }

            try
            {
                // Читаем исходный файл
                var sourceLines = File.ReadAllLines(sourceFileName, Encoding.GetEncoding("Windows-1251"))
                                      .ToList();

                // Конвертация
                var converter = new OblakoToDxfConverter();
                var parameters = new OblakoToDxfConverter.ConvertParameters
                {
                    Format = AppConfig.Instance.Format
                };

                List<string> dxfLines = converter.ConvertLines(sourceLines, parameters);

                // Запись результата
                File.WriteAllLines(outputFileName, dxfLines, Encoding.GetEncoding("Windows-1251"));

                MessageBox.Show($"Файл {outputFileName} успешно создан.",
                                "Готово",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Ошибка конвертации: " + ex.Message);
            }
        }


        private void ShowError(string msg)
        {
            MessageBox.Show(
                msg,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void buttonFixReturn_Click(object sender, EventArgs e)
        {
            string fileName = Properties.Settings.Default.InputGCodeTapFile;
            if (!File.Exists(fileName))
            {
                ShowError("Файл не найден: " + fileName);
                return;
            }

            try
            {
                // Чтение входных строк
                var lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1251")).ToList();

                var fixer = new GCodeFixer();
                var parameters = new GCodeFixer.FixParameters
                {
                    Repeats = (int)numericUpDownRepeats.Value,
                    RepeatStep = numericUpDownRepeatStep.Value,
                    Format = AppConfig.Instance.Format,
                    Orientation = AppConfig.Instance.Orientation,
                    RepeatsMode = AppConfig.Instance.Repeats
                };

                // Исправление G-кода
                List<string> fixedLines = fixer.FixLines(lines, parameters);

                // Перезапись файла
                File.WriteAllLines(fileName, fixedLines, Encoding.GetEncoding("Windows-1251"));

                MessageBox.Show($"Файл {fileName} успешно исправлен.",
                                "Готово",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка обработки файла {fileName}: " + ex.Message);
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
            labelBottomLabelText.Text = Properties.Settings.Default.BottomLabelText;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new FormConfig())
            {
                // Открываем как модальное окно
                settingsForm.ShowDialog(this);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true; // клавиша обработана
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
