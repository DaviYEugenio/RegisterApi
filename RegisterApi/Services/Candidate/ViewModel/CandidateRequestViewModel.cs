using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegisterApi.Services.Candidate.ViewModel
{
    public class CandidateRequestViewModel
    {
        public CandidateRequestViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string TrainingId { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }
       
        [DisplayName("É da IBPV?")]
        public string IsFromIBPV { get; set; }
        
        [DisplayName("É pastor ou missionário?")]
        public string ShepherdOrMissionary { get; set; }
        
        [DisplayName("Cônjuge fará o terinamento?")]
        public string SpouseTraining { get; set; }
        
        [DisplayName("Data de inscrição")]
        public DateTime DateInscription { get; set; }

        [DisplayName("Igreja")]
        public string Church { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public string Fone { get; set; }
   
        [DisplayName("Celular")]
        public string Cell { get; set; }

        [DisplayName("Telefone comercial")]
        public string FoneComercial { get; set; }
    }
}