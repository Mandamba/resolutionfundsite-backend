using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using ResolutionFundSite.Application;
using ResolutionFundSite.Application.Iinterfaces;
using ResolutionFundSite.Domain.Entities;

namespace ResolutionFundSite.Infrastructure.Repositories
{
    public class SharePointRepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly GraphServiceClient _graphClient;
        private readonly string _siteId;
        private readonly string _listName;

        public SharePointRepositoryBase(IOptions<SharePointSettings> options)
        {
            var settings = options.Value;
            _siteId = settings.SiteId;
            _listName = typeof(T).Name;

            var confidentialClient = ConfidentialClientApplicationBuilder.Create(settings.ClientId)
                .WithClientSecret(settings.ClientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{settings.TenantId}"))
                .Build();

            var authProvider = new ClientCredentialProvider(confidentialClient);
            _graphClient = new GraphServiceClient(authProvider);
        }
        public async Task CreateAsync(T entity)
        {
            var listItem = new ListItem
            {
                Fields = new FieldValueSet
                {
                    AdditionalData = MapFromEntity(entity)
                }
            };

            await _graphClient.Sites[_siteId]
                              .Lists[_listName]
                              .Items
                              .Request()
                              .AddAsync(listItem);
        }
        public async Task DeleteAsync(int id)
        {
            await _graphClient.Sites[_siteId]
                              .Lists[_listName]
                              .Items[id.ToString()]
                              .Request()
                              .DeleteAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await _graphClient.Sites[_siteId]
                                          .Lists[_listName]
                                          .Items
                                          .Request()
                                          .GetAsync();

            return items.Select(item => MapToEntity(item)).ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item = await _graphClient.Sites[_siteId]
                                         .Lists[_listName]
                                         .Items[id.ToString()]
                                         .Request()
                                         .GetAsync();

            return MapToEntity(item);
        }

        // Atualiza um item da lista com base no ID da entidade
        public async Task UpdateAsync(T entity)
        {
            var listItem = new ListItem
            {
                Fields = new FieldValueSet
                {
                    AdditionalData = MapFromEntity(entity)
                }
            };

            await _graphClient.Sites[_siteId]
                              .Lists[_listName]
                              .Items[entity.Id.ToString()]
                              .Request()
                              .UpdateAsync(listItem);
        }
        private T MapToEntity(ListItem item)
        {
            var entity = Activator.CreateInstance<T>();
            entity.Id = int.Parse(item.Id);

            if (item.Fields.AdditionalData.TryGetValue("Title", out object titleValue))
            {
                entity.Title = titleValue?.ToString();
            }

            return entity;
        }

        private IDictionary<string, object> MapFromEntity(T entity)
        {
            return new Dictionary<string, object>
            {
                { "Title", entity.Title }
            };
        }
    }
}
