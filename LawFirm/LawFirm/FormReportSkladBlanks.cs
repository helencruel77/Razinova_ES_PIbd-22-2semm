using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.BusinessLogics;
using LawFirmBusinessLogics.Interfaces;
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

namespace LawFirm
{
    public partial class FormReportSkladBlanks : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        private readonly ISkladLogic skladLogic;
        public FormReportSkladBlanks(ReportLogic logic, ISkladLogic skladLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.skladLogic = skladLogic;
        }
        private void FormReportSkladBlanks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = skladLogic.GetList();

                if (list != null)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var sklad in list)
                    {
                        int blanksSum = 0;

                        dataGridView1.Rows.Add(new object[] { sklad.SkladName, "", "" });

                        foreach (var component in sklad.SkladBlanks)
                        {
                            dataGridView1.Rows.Add(new object[] { "", component.BlankName, component.Count });
                            blanksSum += component.Count;
                        }

                        dataGridView1.Rows.Add(new object[] { "Итого", "", blanksSum });
                        dataGridView1.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveSkladBlanksToExcelFile(new ReportBindingModel { FileName = dialog.FileName });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}