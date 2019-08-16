using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsModule.AspMVC
{
    public class Questions
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Options> Options { get; set; }
    }
}