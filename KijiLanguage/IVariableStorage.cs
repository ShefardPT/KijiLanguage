using System;
using System.Collections.Generic;
using System.Text;

namespace KijiLanguage
{
    public interface IVariableStorage
    {
        int GetVariable(string name);
        void RemoveVariable(string name);
        void SetVariable(string name, int value);
    }
}
