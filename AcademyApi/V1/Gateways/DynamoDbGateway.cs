using Amazon.DynamoDBv2.DataModel;
using AcademyApi.V1.Factories;
using Hackney.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Infrastructure;

namespace AcademyApi.V1.Gateways
{
    public class DynamoDbGateway : IExampleDynamoGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        private readonly ILogger<DynamoDbGateway> _logger;


        public DynamoDbGateway(IDynamoDBContext dynamoDbContext, ILogger<DynamoDbGateway> logger)
        {
            _dynamoDbContext = dynamoDbContext;
            _logger = logger;
        }

        public List<SearchResult> GetAll()
        {
            return new List<SearchResult>();
        }

        [LogCall]
        public async Task<SearchResult> GetEntityById(int id)
        {
            _logger.LogDebug($"Calling IDynamoDBContext.LoadAsync for id parameter {id}");

            var result = await _dynamoDbContext.LoadAsync<CouncilTaxSearchResultDbEntity>(id).ConfigureAwait(false);
            return result?.ToDomain();
        }
    }
}
