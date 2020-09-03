namespace Psswrds
{
    public class Parameter
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }

        public Parameter()
        {
            ParameterName = default;
            ParameterValue = default;
        }
    }
}