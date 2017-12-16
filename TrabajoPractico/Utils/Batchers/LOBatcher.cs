using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Metaheuristic;

namespace TrabajoPractico.Utils.Batchers
{
    public class LOBatcher
    {
        public List<LOInput> Inputs { get; set; }
        public List<LOGenetic> GeneticInstances { get; set; } = new List<LOGenetic>();

        public LOBatcher(List<LOInput> inputs, int poblationSize, int selectionCount, int iterNumber)
        {
            Inputs = inputs;

            foreach (LOInput loInput in inputs)
            {
                Matriz matrix = loInput.GetMatriz();
                var genetic = new LOGenetic(matrix, poblationSize, selectionCount, iterNumber);
                GeneticInstances.Add(genetic);
            }
        }

        public List<LOOutput> Start()
        {
            var outputs = new List<LOOutput>();

            return outputs;
        }

    }
}
