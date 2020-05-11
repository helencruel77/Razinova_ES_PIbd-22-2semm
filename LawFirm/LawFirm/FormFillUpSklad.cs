﻿using LawFirmBusinessLogics.BusinessLogics;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmBusinessLogics.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace LawFirmView
{
    public partial class FormFillUpSklad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ISkladLogic skladlogic;
        private readonly IBlankLogic blanklogic;
        private readonly MainLogic mainlogic;
        public FormFillUpSklad(ISkladLogic skladlogic, IBlankLogic blanklogic, MainLogic mainlogic)
        {
            InitializeComponent();
            this.skladlogic = skladlogic;
            this.blanklogic = blanklogic;
            this.mainlogic = mainlogic;
        }
        private void FormSklad_Load(object sender, EventArgs e)
        {
            try
            {
                var listS = skladlogic.GetList();
                comboBoxSklad.DataSource = listS;
                comboBoxSklad.DisplayMember = "SkladName";
                comboBoxSklad.ValueMember = "Id";
                var listB = blanklogic.Read(null);
                comboBoxBlank.DataSource = listB;
                comboBoxBlank.DisplayMember = "BlankName";
                comboBoxBlank.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSklad.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxBlank.SelectedValue == null)
            {
                MessageBox.Show("Выберите бланк", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Укажите количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                mainlogic.FillUpSklad(new SkladBlankBindingModel
                {
                    Id = 0,
                    SkladId = Convert.ToInt32(comboBoxSklad.SelectedValue),
                    BlankId = Convert.ToInt32(comboBoxBlank.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло усешно", "Сообщение",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
