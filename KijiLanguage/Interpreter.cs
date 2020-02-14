using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KijiLanguage
{
    public class Interpreter
    {
        private TextWriter _textWriter;
        private IVariableStorage _varsStorage = new DictVariableStorage();

        private IDictionary<string, Delegate> _commandsStorage;

        public Interpreter(TextWriter textWriter)
        {
            _textWriter = textWriter;

            _commandsStorage = new Dictionary<string, Delegate>()
            {
                { "sub", new Action<string, string>(SubtractValue) },
                { "print", new Action<string>(PrintVariable) },
                { "set", new Action<string,string>(_varsStorage.AddVariable) },
                { "remove", new Action<string>(_varsStorage.RemoveVariable) }
            };
        }

        private void SubtractValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommand(string command)
        {
            var commandSignature = command.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandSignature.ElementAtOrDefault(0);

            if (string.IsNullOrEmpty(commandName) ||
                !_commandsStorage.TryGetValue(commandName, out var function))
            {
                throw new Exception("Wrong command signature.");
            }

            var functionParameters = function.Method.GetParameters();

            var parameters = new List<object>(3);

            for (int i = 0; i < functionParameters.Length; i++)
            {
                parameters.Add(commandSignature[i + 1]);
            }

            function.DynamicInvoke(parameters.ToArray());
        }

        private void PrintVariable(string name)
        {
            var value = _varsStorage.GetVariable(name);

            _textWriter.WriteLine(value);
        }
    }
}
