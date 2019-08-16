using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsModule.DataModel;

namespace QuestionsModule.Repository
{
    public class SubmitOptionsRepository : ISubmitOptionsRepository
    {
        TestDbEntities ctx = null;
        public SubmitOptionsRepository(TestDbEntities _ctx)
        {
            this.ctx = _ctx;
        }
        public bool Save(SubmittedAnswer submittedAnswer)
        {
            try
            {
                ctx.SubmittedAnswers.Add(submittedAnswer);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
