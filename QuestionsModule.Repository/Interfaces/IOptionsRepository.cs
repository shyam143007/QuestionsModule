using QuestionsModule.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsModule.Repository
{
    public interface IOptionsRepository
    {
        List<Option> GetOptions();
        List<Option> GetOptions(int questionId);
    }
}
