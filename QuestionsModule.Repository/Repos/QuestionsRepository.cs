using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsModule.DataModel;

namespace QuestionsModule.Repository
{
    public class QuestionsRepository : IQuestionsRepository
    {
        TestDbEntities ctx = null;

        public QuestionsRepository(TestDbEntities _ctx)
        {
            this.ctx = _ctx;
        }
        public List<Question> GetQuestions()
        {
            return ctx.Questions.ToList();
        }
    }
}
