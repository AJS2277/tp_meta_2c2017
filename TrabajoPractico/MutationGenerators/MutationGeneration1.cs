using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.MutationGenerators
{
    public class MutationGeneration1 : MutationGenerator
    {
        public override void Mutate(Individual individual)
        {
            
            var matriz = (Matriz)individual;
            int position = matriz.GetRandomPosition();
            Tuple<int, int> randomCoordinate = matriz.GetRandomCoordinate();

            matriz.Moves.RemoveAt(position);
            matriz.Moves.Insert(position, randomCoordinate);

            matriz.Rebuild();
        }
    }
}
