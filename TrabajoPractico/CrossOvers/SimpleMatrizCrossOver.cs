using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.List;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.CrossOvers
{
    public class SimpleMatrizCrossOver : CrossOver
    {
        public List<Individual> Cross(List<Individual> poblation, List<Individual> childrens)
        {
            var crossList = new List<Individual>();

            foreach (var children in childrens)
            {
                var mutatedMatriz = (Matriz)children;
                var randomMatriz = (Matriz) ListFactory.GetRandomElement(poblation);

                var crossMatriz = Cross(randomMatriz, mutatedMatriz);
                crossList.Add(crossMatriz);
            }

            return crossList;
        }

        public Individual Cross(Individual normal, Individual mutated)
        {
            var normalMatriz = (Matriz)normal;
            var mutatedMatriz = (Matriz)mutated;

            List<Tuple<int, int>> newMoves = ListFactory.TotalRandomMix(normalMatriz.Moves, mutatedMatriz.Moves);
            Matriz newMatriz = FactoryObject.DeepCopy(normalMatriz);

            newMatriz.Moves = newMoves;
            newMatriz.Rebuild();

            return newMatriz;
        }
    }
}
