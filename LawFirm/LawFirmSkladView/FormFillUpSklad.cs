using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawFirmSkladView
{
    public partial class FormFillUpSklad : Form
    {
        private int id;
        public FormFillUpSklad(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void FormFillUpSklad_Load(object sender, System.EventArgs e)
        {
            try
            {
                List<BlankViewModel> list = APISklad.GetRequest<List<BlankViewModel>>($"api/sklad/getblankslist");
                if (list != null)
                {
                    comboBoxBlank.DisplayMember = "BlankName";
                    comboBoxBlank.ValueMember = "Id";
                    comboBoxBlank.DataSource = list;
                    comboBoxBlank.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxBlank.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APISklad.PostRequest("api/sklad/replanishsklad", new SkladBlankBindingModel
                {
                    Id = 0,
                    SkladId = id,
                    BlankId = Convert.ToInt32(comboBoxBlank.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}