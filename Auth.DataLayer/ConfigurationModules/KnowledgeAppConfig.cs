using Auth.DataLayer.ConfigurationModules.Common;
using Auth.DataLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules
{
    public class KnowledgeAppConfig : IModuleConfig
    { 
        private static Lazy<KnowledgeAppConfig> _instance = new Lazy<KnowledgeAppConfig>(() => new KnowledgeAppConfig());

        public static KnowledgeAppConfig Instance = _instance.Value;

        public Guid SystemModuleId { get; }
        public List<Catalog> Catalogs { get; }

        public KnowledgeAppConfig()
        {
            SystemModuleId = SystemModules.Knowledge.Id;

            Catalogs = new List<Catalog>()
            {
                KnowledgeAppCatalogs.Article,
                KnowledgeAppCatalogs.ArticleScope
            };
        }

        private static class KnowledgeAppCatalogs
        {
            public static Catalog Article = new Catalog(WorkingEntities.KnowledgeArticle.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("8aedaa03-7411-4f7f-99e8-831e945235d3"), Title = "Просмотр"        },
                new CatalogOperation(){Id = Guid.Parse("e13d0ef6-1b8a-4d18-bf92-af3bc5c3c87e"), Title = "Создание"        },
                new CatalogOperation(){Id = Guid.Parse("7e36a241-411f-492d-9dfe-fe4f705873fe"), Title = "Редактирование"  },
                new CatalogOperation(){Id = Guid.Parse("7a4f1875-984d-45a3-91c9-f5b54100e941"), Title = "Комментирование" }
            });

            public static Catalog ArticleScope = new Catalog(WorkingEntities.KnowledgeArticleScope.Id, new List<CatalogOperation>()
            {
                new CatalogOperation(){Id = Guid.Parse("eb482231-22fe-4a1f-a0eb-b75ba1d7a637"), Title = "Просмотр"        },
                new CatalogOperation(){Id = Guid.Parse("6ae31340-7648-4b42-b91a-b7558abb8e03"), Title = "Создание"        },
                new CatalogOperation(){Id = Guid.Parse("343c87a5-5391-4e07-ae4b-cb7f1ec14a55"), Title = "Редактирование"  }
            });
        }
    }
}
