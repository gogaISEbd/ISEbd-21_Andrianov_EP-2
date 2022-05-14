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
using CarRepairShopContracts.ViewModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.BindingModels;

namespace CarRepairShopView
{
    public partial class FormReplenishmentWareHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IWareHouseLogic _logicW;

        private readonly IComponentLogic _logicI;

        public FormReplenishmentWareHouse(IComponentLogic logicI, IWareHouseLogic logicW)
        {
            InitializeComponent();
            _logicW = logicW;
            _logicI = logicI;
        }

        private void FormReplenishmentWareHouse_Load(object sender, EventArgs e)
        {
            try
            {
                List<WareHouseViewModel> listW = _logicW.Read(null);
                if (listW != null)
                {
                    comboBoxWareHouse.DisplayMember = "WareHouseName";
                    comboBoxWareHouse.ValueMember = "Id";
                    comboBoxWareHouse.DataSource = listW;
                    comboBoxWareHouse.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список складов");
                }

                List<ComponentViewModel> listI = _logicI.Read(null);
                if (listI != null)
                {
                    comboBoxIngredient.DisplayMember = "ComponentName";
                    comboBoxIngredient.ValueMember = "Id";
                    comboBoxIngredient.DataSource = listI;
                    comboBoxIngredient.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список компонентов");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWareHouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ComponentViewModel> listI = _logicI.Read(null);
                _logicW.ReplenishByComponent(new WareHouseReplenishmentBindingModel
                {
                    WareHouseId = Convert.ToInt32(comboBoxWareHouse.SelectedValue),
                    ComponentId = listI[comboBoxIngredient.SelectedIndex].Id,
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
