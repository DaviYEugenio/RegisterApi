using Dapper;
using Microsoft.Extensions.Configuration;
using RegisterApi.Services.Candidate.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Repositories.Candidate
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IConfiguration _config;
        public CandidateRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GetConnection()
        {
            var connection = _config.GetSection("ConnectionStrings").
GetSection("Connection").Value;
            return connection;
        }
        public async Task Save(CandidateRequestViewModel model)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "INSERT INTO Candidate(Id, Name, IsFromIBPV, ShepherdOrMissionary, SpouseTraining, DateInscription, Church, Email, Fone, Cell, FoneComercial, TrainingId) " +
                    "VALUES(@Id, @Name, @IsFromIBPV, @ShepherdOrMissionary, @SpouseTraining, @DateInscription, @Church, @Email, @Fone, @Cell, @FoneComercial, @TrainingId)";

                var result = await con.ExecuteAsync(query, model);
                con.Close();
            }
        }
        public async Task AddStatus(Guid id)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "DECLARE @myid uniqueidentifier = NEWID();  INSERT INTO CandidateStatus(Id,CandidateId, StatusId) " +
                    "VALUES(@myid, @Id, '73aa8855-c2a5-459b-bcf3-32274f3cbfe4')";

                var result = await con.ExecuteAsync(query, new { id });
                con.Close();
            }
        }
        public async Task<bool> ValidEmail(string email)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT 1 FROM Candidate WHERE email = @email";
                var result = await con.QueryAsync<bool>(@query, new { email });                 
                con.Close();
                return result.Any();
            }
        }
        public async Task<IEnumerable<TrainingRequestViewModel>> Get()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT Name, Id FROM Training";
                var result = await con.QueryAsync<TrainingRequestViewModel>(@query);
                con.Close();
                return result;
            }
        }


    }
}
