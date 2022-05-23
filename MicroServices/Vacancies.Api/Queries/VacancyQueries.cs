using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vacancies.Api.Models.Responses;
using Vacancies.Api.Queries.Contracts;
using Vacancies.Application.Configuration;

namespace Vacancies.Api.Queries
{
    public class VacancyQueries : IVacancyQueries
    {
        private readonly IOptions<AppSettings> _options;

        public VacancyQueries(IOptions<AppSettings> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected const string GET_QUERY = "SELECT TOP 1 IdVacancy, Job, Description, InsertDate FROM dbo.vacancies (nolock) WHERE IdVacancy = @IdVacancy";

        protected const string LIST_QUERY = "SELECT IdVacancy, Job, NumCandidates FROM dbo.vacancies (nolock)";

        public async Task<VacancyDetailResponse> GetAsync(int idVacancy)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdVacancy", idVacancy);

            using (var connection = new SqlConnection(_options.Value.ConnectionStrings.DefaultConnection))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<VacancyDetailResponse>(GET_QUERY, parameters);
            }
        }

        public async Task<List<VacancyListItemResponse>> ListAsync()
        {
            using (var connection = new SqlConnection(_options.Value.ConnectionStrings.DefaultConnection))
            {
                await connection.OpenAsync();

                return (await connection.QueryAsync<VacancyListItemResponse>(LIST_QUERY)).AsList();
            }
        }
    }
}