using System.Collections.Generic;
using System;
using System.Windows.Forms;
using MyLib.Processors;
using System.Reflection;

namespace MyLib.Controls.MonitorTabPageLayouts
{
    public partial class MonitorTabPageLayout : UserControl
    {
        TableLayoutPanelCellBorderStyle _allCellBodersStyle;
        /// <summary>
        /// Шаблон страницы
        /// </summary>
        public MonitorTabPageLayout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Стиль границы ячеек
        /// </summary>
        public TableLayoutPanelCellBorderStyle AllCellBodersStyle
        { private get
            {
                return _allCellBodersStyle;
            }
            set
            {
                _allCellBodersStyle = value;
                // границы TableLayoutPanelCells
                ResetAllTableLayoutPanelCellsBorders(_allCellBodersStyle);
            }
        }

        /// <summary>
        /// Переустанавливает границы ячеек шаблона
        /// </summary>
        /// <param name="borderStyle"></param>
        private void ResetAllTableLayoutPanelCellsBorders(TableLayoutPanelCellBorderStyle borderStyle)
        {
            List<Control> controls = ControlProcessor.GetAllControls(this, typeof(TableLayoutPanel));

            foreach (TableLayoutPanel tableLayoutPanel in controls)
            {
                tableLayoutPanel.CellBorderStyle = borderStyle;
            }
        }
    }
}
