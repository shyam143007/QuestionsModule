﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsModule.AspMVC
{
    public class Options
    {
        public int id { get; set; }
        public string option_text { get; set; }
        public int question_id { get; set; }
    }
}