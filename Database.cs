using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Psswrds
{
    public class Database
    {
        private NpgsqlConnection npgsqlConnection;
        private NpgsqlCommand npgsqlCommand;
        private NpgsqlDataAdapter npgsqlDataAdapter;

        private const string connectionString =
            "Server=192.168.56.104;Port=5432;Database=pguser;User Id=pguser;Password=pg_psswrd;";

        public Database()
        {
            npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlCommand = new NpgsqlCommand();
            npgsqlDataAdapter = new NpgsqlDataAdapter();
        }

        /// <summary>
        /// Добавить новую сущность в базу данных
        /// </summary>
        /// <param name="entity">Экземпляр добавляемой сущности</param>
        public void AddEntity(Entity entity)
        {
            if (entity != null)
            {
                string query;
                // Проверим, есть ли в базе данных сущность с таким именем
                query = string.Format(@"select count(id) from psswd.entities where entity = '{0}';", entity.GetName());
                npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
                long id = 0;
                
                try
                {
                    npgsqlConnection.Open();
                    id = (long)npgsqlCommand.ExecuteScalar();
                    npgsqlConnection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка базы данных", MessageBoxButtons.OK);
                }

                if (id == 0)
                {
                    query = string.Format(@"insert into psswd.entities (entity) values ('{0}');", entity.GetName());
                    npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);

                    try
                    {
                        npgsqlConnection.Open();
                        npgsqlCommand.ExecuteNonQuery();
                        npgsqlConnection.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка базы данных", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show($"Сущность с наименованием [{entity.GetName()}] уже существует!",
                        "Ошибка при добавлении сущности", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Добавление параметра сущности по ее наименованию
        /// </summary>
        /// <param name="entityName">Наименование сущности</param>
        /// <param name="parameter">Добавляемый параметр</param>
        public void AddParameter(string entityName, Parameter parameter)
        {
            
        }

        /// <summary>
        /// Добавление параметра сущности по ее ID в базк данных
        /// </summary>
        /// <param name="id">ID сущности в базе данных</param>
        /// <param name="parameter">Добавляемый параметр</param>
        public void AddParameter(long id, Parameter parameter)
        {
            
        }
        
        public DataTable NewData()
        {
            string query = "select * from psswd.entities order by entity;";
            npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection)
            {
                CommandTimeout = 20
            };

            npgsqlDataAdapter = new NpgsqlDataAdapter(npgsqlCommand);
            DataSet dataSet = new DataSet();
            npgsqlDataAdapter.Fill(dataSet, "entities");
            DataTable table = dataSet.Tables[0];

            return table;
        }        
    }
}