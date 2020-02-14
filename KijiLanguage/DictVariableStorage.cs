using System;
using System.Collections.Generic;
using System.Text;

namespace KijiLanguage
{
    public class DictVariableStorage : IVariableStorage
    {
        private IDictionary<string, int> _dict = new Dictionary<string, int>();

        public void SetVariable(string name, int value)
        {
            if (_dict.ContainsKey(name))
            {
                _dict[name] = value;
            }
            else
            {
                _dict.Add(name, value);
            }
        }

        public int GetVariable(string name)
        {
            int value;

            try
            {
                value = _dict[name];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return value;
        }

        public void RemoveVariable(string name)
        {
            try
            {
                _dict.Remove(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
