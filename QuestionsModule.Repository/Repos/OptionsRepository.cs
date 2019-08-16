using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsModule.DataModel;

namespace QuestionsModule.Repository
{
    public class OptionsRepository : IOptionsRepository
    {
        TestDbEntities ctx = null;
        public OptionsRepository(TestDbEntities _ctx)
        {
            this.ctx = _ctx;
        }
        public List<Option> GetOptions(int questionId)
        {
            return ctx.Options.Where(o => o.question_id == questionId).ToList();
        }

        public List<Option> GetOptions()
        {
            return ctx.Options.ToList();
        }


    }
}
