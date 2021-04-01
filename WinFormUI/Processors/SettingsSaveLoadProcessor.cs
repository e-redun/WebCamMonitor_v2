using MyLib.Processors;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WebCamMonitor
{
    /// <summary>
    /// Сохраняет/загружает значение Properties.Settings.Default
    /// TextBox.Text
    /// ChechBox.Checked
    /// RadioButton.Checked
    /// </summary>
    public static class SettingsSaveLoadProcessor
    {
        /// <summary>
        /// Сохраняет значение Properties.Settings.Default
        /// TextBox.Text
        /// ChechBox.Checked
        /// RadioButton.Checked
        /// </summary>
        /// <param name="control"></param>
        static public void SaveValue(Control control)
        {
            // краткое имя типа контрола
            string controlType = control.GetType().Name;

            switch (controlType)
            {
                case "TextBox":
                    Properties.Settings.Default[control.Name + "Text"] = ((TextBox)control).Text;
                    break;

                case "CheckBox":
                    Properties.Settings.Default[control.Name + "Checked"] = ((CheckBox)control).Checked;
                    break;

                case "RadioButton":
                    Properties.Settings.Default[control.Name + "Checked"] = ((RadioButton)control).Checked;
                    break;
                case "TabControlTablessListBox":
                    Properties.Settings.Default[control.Name + "SelectedIndex"] = ((ListBox)control).SelectedIndex;
                    break;

                case "TabControlDynamic":
                    Properties.Settings.Default[control.Name + "SelectedIndex"] = ((TabControl)control).SelectedIndex;
                    break;

                default:
                    break;
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Загружает значения Properties.Settings.Default для
        /// TextBox.Text
        /// ChechBox.Checked
        /// RadioButton.Checked
        /// TabControlTablessListBox.SelectedIndex
        /// TabControlDynamiс.SelectedIndex
        /// </summary>
        /// <param name="control"></param>
        public static void LoadValue(Control control)
        {
            try
            {
                // краткое название типа контрола
                string controlType = control.GetType().Name;

                switch (controlType)
                {
                    case "TextBox":
                        string value = (string)Properties.Settings.Default[control.Name + "Text"];
                        if (String.IsNullOrWhiteSpace(value))
                        { }
                        else ((TextBox)control).Text = (string)Properties.Settings.Default[control.Name + "Text"];
                        break;

                    case "CheckBox":
                        ((CheckBox)control).Checked = (bool)Properties.Settings.Default[control.Name + "Checked"];
                        break;

                    case "RadioButton":
                        ((RadioButton)control).Checked = (bool)Properties.Settings.Default[control.Name + "Checked"];
                        break;

                    case "TabControlTablessListBox":
                        ((ListBox)control).SelectedIndex = (int)Properties.Settings.Default[control.Name + "SelectedIndex"];
                        break;

                    case "TabControlDynamic":
                        ((TabControl)control).SelectedIndex = (int)Properties.Settings.Default[control.Name + "SelectedIndex"];
                        break;

                    default:
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        /// <summary>
        /// Загружает и проверяет значение поля. Если значение пустое пытается установить дефолтное значение их файла App.config 
        /// </summary>
        /// <param name="hostControl">Страница TabPage</param>
        /// <param name="textBoxName">Имя поля</param>
        internal static void LoadFolderPathTextBoxValueAndCheckForDefault(Control hostControl, string textBoxName)
        {
            TextBox textBox = (TextBox)hostControl.Controls[textBoxName];

            SettingsSaveLoadProcessor.LoadValue(textBox);

            // если установки пусты принимаются установки по умолчанию
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                string defaultSettingsName = textBox.Name.Replace("textBox", "relativeDefault");

                string relativeDefaultPath = ConfigurationManager.AppSettings[defaultSettingsName];

                textBox.Text = Path.Combine(Application.StartupPath, relativeDefaultPath);

                // валидация папки
                Validator.ValidateAndCreateFolder(textBox.Text);
            }
        }

        /// <summary>
        /// Загружает и проверяет значение поля. Если значение пустое пытается установить дефолтное значение их файла App.config 
        /// </summary>
        /// <param name="hostControl">Страница TabPage</param>
        /// <param name="textBoxName">Имя поля</param>
        internal static void LoadFilePathTextBoxValueAndLookForDefault(Control hostControl, TextBox textBox)
        {
            SettingsSaveLoadProcessor.LoadValue(textBox);

            // если установки пусты принимаются установки по умолчанию 
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                string defaultSettingsName = textBox.Name.Replace("textBox", "relativeDefault");

                string relativeDefaultPath = ConfigurationManager.AppSettings[defaultSettingsName];

                string fullFilePath = Path.Combine(Application.StartupPath, relativeDefaultPath);

                // если файл по-умолчанию существует
                if (File.Exists(fullFilePath))

                    textBox.Text = fullFilePath;
            }
        }

        public static void LoadAllValuesOnControl(Control hostControl)
        { 
            try
            {
                foreach (Control control in hostControl.Controls)
                {
                    // название типа контрола
                    string controlType = control.GetType().Name;

                    switch (controlType)
                    {
                        case "TextBox":
                            string value = (string)Properties.Settings.Default[control.Name + "Text"];

                            if (String.IsNullOrWhiteSpace(value) || Properties.Settings.Default[control.Name + "Text"] == null)
                            { break; }
                            else ((TextBox)control).Text = (string)Properties.Settings.Default[control.Name + "Text"];

                            break;

                        case "CheckBox":
                            ((CheckBox)control).Checked = (bool)Properties.Settings.Default[control.Name + "Checked"];
                            break;

                        case "RadioButton":
                            ((RadioButton)control).Checked = (bool)Properties.Settings.Default[control.Name + "Checked"];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }
    }
}