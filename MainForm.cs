using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;

namespace Psswrds
{
    public partial class MainForm : Form
    {
        private AddEntity _addEntity;
        private ViewEntity _viewEntity;
        private AddParameters _addParameters;
        
        private List<Entity> _entities;
        private Database _db;
        private BindingSource _bindingSource;

        public MainForm()
        {
            _addEntity = new AddEntity();
            _viewEntity = new ViewEntity();
            _addParameters = new AddParameters();
            
            _entities = new List<Entity>();
            _db = new Database();
            _bindingSource = new BindingSource();
            dataGridView1 = new DataGridView();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Enabled = true;
            dataGridView1.ReadOnly = true;
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Выбран пункт меню Сущность - Добавить
            _addEntity.SetEditMode(false);
            _addEntity.ShowDialog();
            if (_addEntity.Accepted)
            {
                string entityName = _addEntity.GetEntityName();
                Entity entity = new Entity(entityName);
                _db.AddEntity(entity);
                dataGridView1.DataSource = _db.NewData();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bindingSource.DataSource = _db.NewData();
            dataGridView1.DataSource = _bindingSource;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[1].Width = 250;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // Пункт меню Сущность - Открыть

            // Получить текущую строку
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.CurrentRow;
            int id = (int)row.Cells[0].Value;
            string name = row.Cells[1].Value.ToString();

            _viewEntity.SetEntityId(id);
            _viewEntity.SetEntityName(name);
            _viewEntity.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // Пункт меню Параметры - Добавить
            
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.CurrentRow;
            int id = (int)row.Cells[0].Value;
            string name = row.Cells[1].Value.ToString();
            
            _addParameters.SetCaption(name);
            _addParameters.ShowDialog();
            Parameter newParam = _addParameters.GetParameter();
        }
    }
}