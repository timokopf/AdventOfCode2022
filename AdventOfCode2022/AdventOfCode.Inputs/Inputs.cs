using System.Dynamic;

namespace AdventOfCode.Inputs
{
    public class Inputs : DynamicObject
    {
        public static dynamic Instance = new Inputs();


        private Dictionary<string, object> _inputs = new();
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
                result = File.ReadAllLines($"{name}Input.txt");
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