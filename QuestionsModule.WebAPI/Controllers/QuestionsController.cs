using QuestionsModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionsModule.DataModel;

namespace QuestionsModule.WebAPI.Controllers
{
    public class QuestionsController : ApiController
    {
        IQuestionsRepository questionsRepo = null;
        IOptionsRepository optionsRepository = null;
        ISubmitOptionsRepository submitOptionsRepository = null;
        public QuestionsController(IQuestionsRepository _questionsRepo, IOptionsRepository _optionsRepository, ISubmitOptionsRepository _submitOptionsRepository)
        {
            questionsRepo = _questionsRepo;
            optionsRepository = _optionsRepository;
            submitOptionsRepository = _submitOptionsRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(questionsRepo.GetQuestions());
        }

        [Route("api/questions/{id}/options")]
        public IHttpActionResult Get(int id)
        {
            return Ok(optionsRepository.GetOptions(id));
        }

        [Route("api/submit")]
        public IHttpActionResult Post(List<SubmittedAnswer> submittedOptions)
        {
            foreach (var item in submittedOptions)
            {
                if (submitOptionsRepository.Save(item))
                {
                    continue;
                }
                else
                {
                    return Ok(HttpStatusCode.InternalServerError);                   
                }
            }
            return Ok(HttpStatusCode.Created);

        }
    }
}
