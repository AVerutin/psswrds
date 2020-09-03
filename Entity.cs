using System.Collections.Generic;

namespace Psswrds
{
    public class Entity
    {
        private string _name;
        private int _id;
        private Dictionary<string, string> _parameters;

        public Entity()
        {
            _name = "";
            _id = 0;
            _parameters = new Dictionary<string, string>();
        }

        public Entity(string name)
        {
            if (name.Trim() != "")
            {
                _name = name;
                _id = 0;
                _parameters = new Dictionary<string, string>();
            }
        }

        public Entity(int id)
        {
            if (id > 0)
            {
                _name = "";
                _id = id;
                _parameters = new Dictionary<string, string>();
            }
        }

        public Entity(string name, int id)
        {
            if (name.Trim() != "" && id > 0)
            {
                _name = name;
                _id = id;
                _parameters = new Dictionary<string, string>();
            }
        }

        public void SetParameters(Dictionary<string, string> parameters)
        {
            if (parameters.Count > 0)
            {
                _parameters = parameters;
            }
        }

        public void AddParameter(string parameter, string value)
        {
            if (parameter.Trim() != "" && value.Trim() != "")
            {
                _parameters.Add(parameter, value);
            }
        }

        public Dictionary<string, string> GetParameters() => _parameters;
        public string GetName() => _name;
    }
}