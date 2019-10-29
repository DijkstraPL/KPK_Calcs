using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class TestDataRepository : Repository<TestData>, ITestDataRepository
    {
        public TestDataRepository(ScriptInterpreterDbContext context) : base(context)
        {
        }
    }
}
