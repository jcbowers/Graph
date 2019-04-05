using GraphBulkImporter.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphBulkImporter
{
    class GraphTransformer
    {
        internal ObjectList Transform(ObjectList extract)
        {
            var graph = new ObjectList();
            var nodes = new List<Node>();

            foreach (var node in extract.Objects.Where(o => IsAllowedType(o.Type) && IsValidId(o.Name)))
            {
                nodes.Add(node);
            }

            foreach (var node in nodes)
            {
                if (node.Dependencies != null)
                {
                    node.Dependencies = node.Dependencies.Where(d => IsValidId(d) && nodes.Any(n => n.Name == d)).ToArray();
                }

                if (node.Dependents != null)
                {
                    node.Dependents = node.Dependents.Where(d => IsValidId(d) && nodes.Any(n => n.Name == d)).ToArray();
                }
            }

            graph.Objects = nodes.ToArray();

            return graph;
        }

        private static bool IsAllowedType(string type)
        {
            return type == "Table" || type == "View" || type == "Function" || type == "Stored Procedure";
        }

        private static bool IsValidId(string id)
        {
            return !string.IsNullOrWhiteSpace(id);
        }
    }
}
