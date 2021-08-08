using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    [GraphQLDescription("Request any software or service that has a platform/command")]
    public class Query
    {
        //Match AddPooledDbContextFactory with ScopedService
        //Singleton : same for every request
        //Scoped : create once per client request (multi-thread)
        //Transient : new instance created every time
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
