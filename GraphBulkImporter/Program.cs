using System;

namespace GraphBulkImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new Presenter();

            var context = new ETLContext(
                new GraphExtractor(),
                new GraphTransformer(),
                new GraphMLLoader(),
                presenter);

            context.RunAsync().Wait();

            presenter.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
