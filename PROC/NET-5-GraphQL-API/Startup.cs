using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommanderGQL
{
    /// <summary>
    /// Reference
    /// https://www.freecodecamp.org/news/five-common-problems-in-graphql-apps-and-how-to-fix-them-ac74d37a293c/
    /// http://csharp.academy/mutation-testing/#:~:text=The%20idea%20is%20to%20create,(which%20is%20not%20good).
    /// Kill mutation 
    /// GraphQL API with .NET 5 and Hot Chocolate
    /// Core concept:
    /// https://youtu.be/HuN94qNwQmM?t=1457
    /// REST<=>GraphQL
    /// https://youtu.be/HuN94qNwQmM?t=1789
    /// Multiple request implementation; data over fetching
    /// GraphQL.NET <=> HotChocolate; HotChocolate has more features
    /// Insomnia api for API test
    /// Docker container run; SQL server is localhost,1433
    /// https://youtu.be/HuN94qNwQmM?t=3234
    /// Application Architecture
    /// https://youtu.be/HuN94qNwQmM?t=4530
    /// Schema Visalization
    /// https://apis.guru/graphql-voyager/
    /// https://localhost:5001/graphql-voyager
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //create instances of given Microsoft.EntityFrameworkCore.DbContext type where
            //instances are pooled for reuse.
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("connection_string")));

            services
                .AddGraphQLServer()
                .AddProjections()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddFiltering()
                .AddSorting()
                .AddSubscriptionType<Subscription>()
                //AddInMemorySubscriptions just for development
                .AddInMemorySubscriptions();
                
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Subscription requires web sockets
            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
