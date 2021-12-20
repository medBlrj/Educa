using Educa.Controllers;
using Educa.Entities.QuestionsEntities;
using Educa.Helper.GenericResponseModels;
using Educa.Repository.QuestionsRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Educa.Services.QuestionsServices
{
    public class QuestionsServices : IQuestionsServices
    {
        private readonly IQuestionsRepository questionsRepository;
        public QuestionsServices(IQuestionsRepository questionsRepository)
        {
            this.questionsRepository = questionsRepository;
        }

        public async Task<IEnumerable<Questions>> ListAsync()
        {
            return  questionsRepository.GetAllQuestions();
        }
    }
}
