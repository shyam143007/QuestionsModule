using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsModule.AspMVC
{
    public class SubmittedAnswer
    {

        public int id { get; set; }
        public int emp_id { get; set; }
        public int question_id { get; set; }
        public int option_id { get; set; }
    }
}