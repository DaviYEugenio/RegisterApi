using RegisterApi.Services.Candidate.ViewModel;
using RegisterApi.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Services.Candidate
{
    public interface ICandidateService
    {
        Task<ResposeViewModel<CandidateResponseViewModel>> Save(CandidateRequestViewModel model);
        Task<IEnumerable<TrainingRequestViewModel>> Get();
    }
}
