using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace CarRepairShopView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IRepairLogic _logicP;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _logicС;
        public FormCreateOrder(IRepairLogic logicP, IOrderLogic logicO, IClientLogic logicС)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
            _logicС = logicС;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<ClientViewModel> listC = _logicС.Read(null);
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }

                List<RepairViewModel> listP = _logicP.Read(null);
                if (listP != null)
                {
                    comboBoxProduct.DisplayMember = "RepairName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listP;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null &&
            !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    RepairViewModel product = _logicP.Read(new RepairBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
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
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
