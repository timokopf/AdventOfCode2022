using System.Dynamic;

namespace AdventOfCode.Inputs
{
    public class Inputs : DynamicObject
    {
        private readonly Dictionary<string, object> _inputs = new();

        public static dynamic Instance = new Inputs();

        private Inputs() 
        {
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string name = binder.Name;

            if (_inputs.TryGetValue(name, out result))
            {
                return true;
            }

            try
            {
                string[] fileContents = File.ReadAllLines($"{name}Input.txt");
                if (fileContents.Length == 1)
                {
                    result = fileContents[0];
                } else
                {
                    result = fileContents;
                }

                _inputs[name] = result;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}