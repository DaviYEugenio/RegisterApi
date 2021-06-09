using RegisterApi.Repositories.Candidate;
using RegisterApi.Services.Candidate;
using RegisterApi.Services.Candidate.ViewModel;
using RegisterApi.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<IEnumerable<TrainingRequestViewModel>> Get()
        {
            var model = new List<TrainingRequestViewModel>();
            var result = await _candidateRepository.Get();
            return result;
        }
            public async Task<ResposeViewModel<CandidateResponseViewModel>> Save(CandidateRequestViewModel model)
        {
            var response = await _candidateRepository.ValidEmail(model.Email);
            if (response == false)
            {
                model.DateInscription = DateTime.UtcNow;
                await _candidateRepository.Save(model);                
                var message = new CandidateResponseViewModel
                {
                    Message = "Candastrado com sucesso"
                };
                await _candidateRepository.AddStatus(model.Id);
                return new ResposeViewModel<CandidateResponseViewModel>(true, message);
            }
            else
            {
                var message = new CandidateResponseViewModel
                {
                    Message = "Usuario já cadastrado"
                };
                return new ResposeViewModel<CandidateResponseViewModel>(false, message);
            }            
        }       
    }
}



