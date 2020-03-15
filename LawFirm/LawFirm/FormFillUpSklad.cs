using LawFirmBusinessLogics.BusinessLogics;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmLogic.BindingModels;
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
        private void FormFillUpSklad_Load(object sender, EventArgs e)
        {
            try
            {
                var SList = skladlogic.GetList();
                comboBoxSklad.DataSource = SList;
                comboBoxSklad.DisplayMember = "SkladName";
                comboBoxSklad.ValueMember = "Id";
                var BList = blanklogic.Read(null);
                comboBoxBlank.DataSource = BList;
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
                int skladId = Convert.ToInt32(comboBoxSklad.SelectedValue);
                int blankId = Convert.ToInt32(comboBoxBlank.SelectedValue);
                int count = Convert.ToInt32(textBoxCount.Text);
                this.mainlogic.FillUpSklad(new SkladBlankBindingModel
                {
                    SkladId = skladId,
                    BlankId = blankId,
                    Count = count
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
