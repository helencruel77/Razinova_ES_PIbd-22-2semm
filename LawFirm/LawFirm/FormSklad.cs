using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
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
    public partial class FormSklad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ISkladLogic logic;
        private int? id;
        public FormSklad(ISkladLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormSklad_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    var view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.SkladName;
                    }
                    var skladList = logic.GetList();
                    var skladBlanks = skladList[0].SkladBlanks;
                    for (int i = 0; i < skladList.Count; ++i)
                    {
                        if (skladList[i].Id == id)
                        {
                            skladBlanks = skladList[i].SkladBlanks;
                        }
                    }
                    if (skladBlanks != null)
                    {
                        dataGridView.DataSource = skladBlanks;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

            private void buttonSave_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(textBoxName.Text))
                {
                    MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    if (id.HasValue)
                    {
                        logic.UpdElement(new SkladBindingModel { Id = id.Value, SkladName = textBoxName.Text });
                    }
                    else
                    {
                        logic.AddElement(new SkladBindingModel { SkladName = textBoxName.Text });
                    }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
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
