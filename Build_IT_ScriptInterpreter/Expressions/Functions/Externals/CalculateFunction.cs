using Build_IT_Data.Calculators.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using Build_IT_ScriptService;
using NCalc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;

namespace Build_IT_ScriptInterpreter.Expressions.Functions.Externals
{
    public class CalculateFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }

        public Func<FunctionArgs, object> Function { get; private set; }

        [Import]
        public ICalculator Calculator { get; set; }

        #endregion // Properties

        #region Fields

        #endregion // Fields

        #region Constructors

        public CalculateFunction()
        {
            Set();
        }

        #endregion // Constructors

        #region Private_Methods

        private void Set()
        {
            Name = "Calculate";
            Function = (e) =>
            {
                ICollection<object> arguments = new List<object>();
                Compose(e.Parameters[0]?.Evaluate()?.ToString());
                for (int i = 1; i < e.Parameters.Length; i++)
                    arguments.Add(e.Parameters[i].Evaluate());

                Calculator.Map(arguments);
                return Calculator.Calculate();
            };
        }

        private void Compose(string calculatorName)
        {
            var configuration = new ContainerConfiguration()
               .WithAssembly(typeof(ServiceStartup).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                Calculator = container.GetExport<ICalculator>(calculatorName);
            }
        }

        #endregion // Private_Methods      
    }
}
