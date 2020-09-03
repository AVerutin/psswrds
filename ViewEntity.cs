using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Psswrds
{
    public partial class ViewEntity : Form
    {
        private long entityId;
        private string name;
        
        private NpgsqlConnection npgsqlConnection;
        private BindingSource bindingSource;
        private NpgsqlCommand npgsqlCommand;
        private NpgsqlDataAdapter npgsqlDataAdapter;
        private const string connectionString =
            "Server=192.168.56.104;Port=5432;Database=pguser;User Id=pguser;Password=pg_psswrd;";
        
        public ViewEntity()
        {
            entityId = 0;
            name = "";
            dataGridView1 = new DataGridView();
            npgsqlConnection = new NpgsqlConnection(connectionString);
            bindingSource = new BindingSource();
            npgsqlCommand = new NpgsqlCommand();
            npgsqlDataAdapter = new NpgsqlDataAdapter();
            
            InitializeComponent();
        }

        public void SetEntityId(long id)
        {
            if (id > 0)
            {
                entityId = id;
            }
        }

        public void SetEntityName(string _name)
        {
            if (_name.Trim() != "")
            {
                name = _name;
            }
        }

        private void ViewEntity_Load(object sender, EventArgs e)
        {
            // Событие при загрузке формы
            if (entityId == 0 || name.Trim() == "")
            {
                Close();
            }
            
            string query = $"select * from psswd.parameters where entity={entityId} order by parameter;";
            npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection)
            {
                CommandTimeout = 20
            };

            npgsqlDataAdapter = new NpgsqlDataAdapter(npgsqlCommand);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet, "parameters");
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Параметр";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "Значение";
            dataGridView1.Columns[3].Width = 150;
            
            label2.Text = name;
        }
    }
}