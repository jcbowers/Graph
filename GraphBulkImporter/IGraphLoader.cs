using System.Threading.Tasks;
using GraphBulkImporter.Model;

namespace GraphBulkImporter
{
    interface IGraphLoader
    {
        Task LoadGraphAsync(ObjectList graph);
    }
}