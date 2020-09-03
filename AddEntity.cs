using System;
using System.Windows.Forms;

namespace Psswrds
{
    public partial class AddEntity : Form
    {
        private string _entityName;
        private bool _isEditMode;
        public bool Accepted { get; set; }
        
        public AddEntity()
        {
            _entityName = "";
            _isEditMode = false;
            InitializeComponent();
        }

        
        public void SetEditMode(bool mode) => _isEditMode = mode;
        public bool IsEditMode => _isEditMode;

        public void SetEntityName(string name)
        {
            if (name.Trim() != "")
            {
                _entityName = name;
            }
        }

        public string GetEntityName() => _entityName;

        private void AddEntity_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                textBox1.Text = _entityName;
                button1.Text = "Изменить";
            }
            else
            {
                textBox1.Text = "";
                button1.Text = "Добавить";
            }

            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Нажата кнопка Добавить
            string name = textBox1.Text.Trim(); 
            if (name != "")
            {
                _entityName = name;
            }

            Accepted = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Нажата кнопка Отмена
            Accepted = false;
            Close();
        }
    }
}