using System;
using System.Collections.Generic;
using System.Text;

namespace KijiLanguage
{
    public interface IVariableStorage
    {
        void AddVariable(string name, string value);
        string GetVariable(string name);
        void RemoveVariable(string name);
    }
}
