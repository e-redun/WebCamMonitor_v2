using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MyLib.Processors
{
    public static class ControlProcessor
    {
        /// <summary>
        /// Возвращает список элементов управления включая дочерние
        /// </summary>
        /// <param name="control"></param>
        /// <returns>List<Control></returns>
        static public List<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(ctrl => GetAllControls(ctrl))
                                  .Concat(controls)
                                  .ToList();
        }
        /// <summary>
        /// Перегрузка
        /// Возвращает список элементов управления (определенного типа) включая дочерние
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        static public List<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() == type)
                                  .ToList();
        }

        /// <summary>
        /// Возвращает список элементов управления (исключая определенный тип) включая дочерние
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        static public List<Control> GetAllControlsExceptType(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(ctrl => GetAllControlsExceptType(ctrl, type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() != type)
                                  .ToList();
        }
        /// <summary>
        /// Перегрузка
        /// Возвращает список элементов управления (определенного типа) включая дочерние
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        static public List<Control> GetAllControlsIncludingSubClasses(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                  .Concat(controls)
                                  .Where(c => (c.GetType() == type) || (c.GetType().IsSubclassOf(type)))
                                  .ToList();
        }
    }
}
