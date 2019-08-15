using Build_IT_Data.Calculators.Interfaces;
using Build_IT_ScriptService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Services.Queries.GetAllServices
{
    public class GetAllServicesQuery : IRequest<IEnumerable<ServiceResource>>
    {
        public class Handler : IRequestHandler<GetAllServicesQuery, IEnumerable<ServiceResource>>
        {
            #region Fields

            private List<ServiceResource> _contracts;
            private IEnumerable<ICalculator> _calculators;

            #endregion // Fields

            #region Constructors

            public Handler()
            {
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ServiceResource>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
            {
                _contracts = new List<ServiceResource>();

                var configuration = new ContainerConfiguration()
                .WithAssembly(typeof(ServiceStartup).GetTypeInfo().Assembly);

                using (var container = configuration.CreateContainer())
                {
                    _calculators = container.GetExports<ICalculator>();
                }
                await SetContracts();

                return _contracts;
            }

            #endregion // Public_Methods

            #region Private_Methods

            private async Task SetContracts()
            {
                foreach (var calculator in _calculators)
                {
                    var calculatorType = calculator.GetType();
                    var exportAttribute = calculatorType.GetCustomAttributes<ExportAttribute>()
                        .FirstOrDefault(e => e.ContractName != null) as ExportAttribute;

                    var properties = calculatorType.GetProperties();
                    List<SimplePropertyResource> data = await GetData(calculator, properties);
                    List<SimplePropertyResource> results = await GetResults(calculatorType);

                    _contracts.Add(new ServiceResource
                    {
                        ContractName = exportAttribute.ContractName,
                        Description = calculator.Description,
                        Properties = data,
                        Results = results,
                    });
                }
            }

            private async Task<List<SimplePropertyResource>> GetData(ICalculator calculator, PropertyInfo[] properties)
            {
                var data = new List<SimplePropertyResource>();
                await Task.Run(() =>
                {
                    foreach (var property in properties)
                    {
                        var propertyData = property.GetValue(calculator) as Property;
                        if (propertyData != null)
                            data.Add(new SimplePropertyResource
                            {
                                Name = propertyData.Name,
                                Description = propertyData.Description,
                                Required = propertyData.Required
                            });
                    }
                });
                return data;
            }

            private async Task<List<SimplePropertyResource>> GetResults(Type calculatorType)
            {
                var results = new List<SimplePropertyResource>();

                await Task.Run(() =>
                {
                    var instance = Activator.CreateInstance(calculatorType);

                    foreach (var resultParameter in (instance as ICalculator).Result.Descriptions)
                        results.Add(new SimplePropertyResource
                        {
                            Name = resultParameter.Key,
                            Description = resultParameter.Value,
                        });
                });
                return results;
            }

            #endregion // Private_Methods
        }
    }
}
