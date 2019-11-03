using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface ITestDataRepository : IRepository<TestData>
    {
        #region Public_Methods
        
        Task<IEnumerable<TestData>> GetAllTestDataForScriptAsync(long scriptId);
        Task<TestData> GetTestDataWithAllDependanciesAsync(long testDataId);
        void RemoveWithAllDependancies(TestData testData);

        #endregion // Public_Methods
    }
}
