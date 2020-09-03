using System;
using System.Windows.Forms;

namespace Psswrds
{
    public partial class AddParameters : Form
    {
        private Parameter _parameter;
        public bool Accepted { get; private set; }
        
        public AddParameters()
        {
            _parameter = new Parameter();
            Accepted = false;
            InitializeComponent();
        }

        public Parameter GetParameter() => _parameter;

        private void button1_Click(object sender, EventArgs e)
        {
            // Нажата кнопка Добавить
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                _parameter.ParameterName = textBox1.Text.Trim();
                _parameter.ParameterValue = textBox2.Text.Trim();
                Accepted = true;
            }
            
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Нажата кнопка Отмена
            Accepted = false;
            Close();
        }

        public void SetCaption(string caption)
        {
            if (caption.Trim() != "")
            {
                Text = caption;
            }
        }

        private void AddParameters_Load(object sender, EventArgs e)
        {
            // Загрузка формы
            textBox2.Focus();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}