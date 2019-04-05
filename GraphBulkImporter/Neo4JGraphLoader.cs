using System.Configuration;
using System.Threading.Tasks;
using System;
using Neo4jClient;
using GraphBulkImporter.Model;
using System.Net.Http;

namespace GraphBulkImporter
{
    class Neo4JGraphLoader : IGraphLoader
    {
        public async Task LoadGraphAsync(ObjectList graph)
        {
            using (var client = new GraphClient(
                new Uri(ConfigurationManager.AppSettings["neo4jUri"]),
                new HttpClientWrapper(
                    ConfigurationManager.AppSettings["dbUser"],
                    ConfigurationManager.AppSettings["dbPassword"],
                new HttpClient() { Timeout = TimeSpan.FromMinutes(20) })))
            {
                await client.ConnectAsync();

                await client.Cypher.Match("(n)").DetachDelete("n").ExecuteWithoutResultsAsync();

                await client.Cypher
                    .Unwind(graph.Objects, "object")
                   .Merge("(o:Object {name:object.Name, type:object.Type})")
                   .Set("o = object")
                   .With("o, object")
                   .Unwind("object.Dependencies", "Uses")
                   .Merge("(o1:Object {name:Uses})")
                   .Merge("(o)-[:USES]->(o1)")
                   .With("o, object")
                   .Unwind("object.Dependents", "UsedBy")
                   .Merge("(o2:Object {name:UsedBy})")
                   .Merge("(o2)<-[:USEDBY]-(o)")
                   .ExecuteWithoutResultsAsync();
            }
        }
    }
}
