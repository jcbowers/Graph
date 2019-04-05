using System;
using System.Threading.Tasks;

namespace GraphBulkImporter
{
    class ETLContext
    {
        private GraphExtractor graphExtractor;
        private GraphTransformer graphTransformer;
        private IGraphLoader graphLoader;
        private Presenter presenter;

        public ETLContext(
            GraphExtractor graphExtractor,
            GraphTransformer graphTransformer,
            IGraphLoader graphLoader,
            Presenter presenter)
        {
            this.graphExtractor = graphExtractor;
            this.graphTransformer = graphTransformer;
            this.graphLoader = graphLoader;
            this.presenter = presenter;
        }

        internal async Task RunAsync()
        {
            try
            {
                presenter.WriteLine("Beginning Extract");
                var extract = graphExtractor.LoadObjects();
                presenter.WriteLine("Extraction complete");

                presenter.WriteLine("Beginning Transformation");
                var transformed = graphTransformer.Transform(extract);
                presenter.WriteLine("Transformation complete");

                presenter.WriteLine("Beginning Load");
                await graphLoader.LoadGraphAsync(transformed);
                presenter.WriteLine("Load complete");
            }
            catch(Exception ex)
            {
                presenter.WriteLine(ex.Message);
                presenter.WriteLine(ex.ToString());
            }
        }
    }
}
