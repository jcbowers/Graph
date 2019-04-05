using System.Collections.Generic;

namespace GraphBulkImporter
{
    class Graph<T>
    {
        internal IEnumerable<T> Nodes { get; set; }

        internal IEnumerable<(string SourceId, string TargetId)> Relationships { get; set; }
    }
}
