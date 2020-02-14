using System;
using System.Collections.Generic;
using System.Text;

namespace KijiLanguage
{
    public class DictVariableStorage : IVariableStorage
    {
        private IDictionary<string, string> _dict = new Dictionary<string, string>();

        public void AddVariable(string name, string value)
        {
            try
            {
                _dict.Add(name, value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetVariable(string name)
        {
            string value;

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
