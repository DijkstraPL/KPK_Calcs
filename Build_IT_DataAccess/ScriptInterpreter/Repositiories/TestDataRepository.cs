using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class TestDataRepository : Repository<TestData>, ITestDataRepository
    {
        #region Properties

        public ScriptInterpreterDbContext ScriptInterpreterContext
            => Context as ScriptInterpreterDbContext;

        #endregion // Properties

        #region Constructors

        public TestDataRepository(ScriptInterpreterDbContext context) : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods

        public async Task<IEnumerable<TestData>> GetAllTestDataForScriptAsync(long scriptId)
        {
            return await ScriptInterpreterContext.TestDatas
                .Where(td => td.ScriptId == scriptId)
                .Include(td => td.TestParameters)
                .Include(td => td.Assertions)
                .ToListAsync();
        }

        public async Task<TestData> GetTestDataWithAllDependanciesAsync(long testDataId)
        {
            return await ScriptInterpreterContext.TestDatas
                .Include(td => td.TestParameters)
                .Include(td => td.Assertions)
                .FirstOrDefaultAsync(td => td.Id == testDataId);
        }

        #endregion // Public_Methods
    }
}
