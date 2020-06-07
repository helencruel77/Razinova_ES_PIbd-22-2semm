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
    public partial class FormSklad : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormSklad()
        {
            InitializeComponent();
        }

        private void FormSklad_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SkladViewModel view = APISklad.GetRequest<SkladViewModel>($"api/sklad/getsklad?skladid={id}");
                    if (view != null)
                    {
                        textBoxName.Text = view.SkladName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APISklad.PostRequest("api/sklad/createorupdatesklad", new SkladBindingModel
                {
                    Id = id,
                    SkladName = textBoxName.Text
                });

                MessageBox.Show("Склад создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}