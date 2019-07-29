using Build_IT_Data.Calculators.Interfaces;
using Build_IT_ScriptService;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    public class ServicesController
    {
        [ImportMany]
        public IEnumerable<ICalculator> Calculators { get; }
        public IList<(string contractName, IList<string> properties)> Contracts { get; }

        public ServicesController()
        {
            Contracts = new List<(string, IList<string>)>();

            var configuration = new ContainerConfiguration()
              .WithAssembly(typeof(ServiceStartup).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                Calculators = container.GetExports<ICalculator>();
            }

            SetContracts();
        }

        private void SetContracts()
        {
            foreach (var calculator in Calculators)
            {
                var calculatorType = calculator.GetType();
                var exportAttribute = calculatorType.GetCustomAttributes<ExportAttribute>()
                    .FirstOrDefault(e => e.ContractName != null) as ExportAttribute;

                var properties = calculatorType.GetProperties();
                List<string> names = GetNames(calculator, properties);

                Contracts.Add((exportAttribute.ContractName, names));
            }
        }

        private List<string> GetNames(ICalculator calculator, PropertyInfo[] properties)
        {
            var names = new List<string>();
            foreach (var property in properties)
            {
                var propertyData = property.GetValue(calculator) as Property;
                if (propertyData != null)
                    names.Add(propertyData.Name);
            }

            return names;
        }
    }
}
