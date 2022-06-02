using Candidates.Api.Models.Responses;
using Candidates.Api.Queries.Contracts;
using Candidates.Application.Configuration;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Candidates.Api.Queries
{
    public class CandidateQueries : ICandidateQueries
    {
        private readonly IOptions<AppSettings> _options;

        public CandidateQueries(IOptions<AppSettings> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected const string GET_QUERY = "SELECT TOP 1 IdCandidate, IdVacancy, Name, Surname, Email, InsertDate FROM dbo.candidates (nolock) WHERE IdCandidate = @IdCandidate";

        protected const string LIST_QUERY = "SELECT IdCandidate, IdVacancy, Name, Surname FROM dbo.candidates (nolock) WHERE IdVacancy = @IdVacancy";

        public async Task<CandidateDetailResponse> GetAsync(int idCandidate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdCandidate", idCandidate);

            using (var connection = new SqlConnection(_options.Value.ConnectionStrings.DefaultConnection))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<CandidateDetailResponse>(GET_QUERY, parameters);
            }
        }

        public async Task<List<CandidateListItemResponse>> ListAsync(int idVacancy)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdVacancy", idVacancy);

            using (var connection = new SqlConnection(_options.Value.ConnectionStrings.DefaultConnection))
            {
                await connection.OpenAsync();

                return (await connection.QueryAsync<CandidateListItemResponse>(LIST_QUERY, parameters)).AsList();
            }
        }
    }
}