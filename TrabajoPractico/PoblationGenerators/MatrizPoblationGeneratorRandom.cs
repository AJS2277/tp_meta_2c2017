using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.PoblationGenerators
{
    public class MatrizPoblationGeneratorRandom : PoblationGenerator
    {
        public MatrizPoblationGeneratorRandom(Matriz matriz, int size, int selections) : base(matriz, size, selections)
        {
            int maxSize = ( matriz.Size * (matriz.Size - 1) ) / 2;
            if(size > maxSize)
            {
                var message = string.Format("No hay suficientes movimientos para satisfacer el tamaño de la población." 
                    + " El máximo es: {0}", maxSize);
                throw new Exception(message);
            }
        }

        public override void Generate()
        {
            Matriz originalAsMatriz = (Matriz)Original;
            var poblation = new List<Matriz>();
            List<Tuple<int, int>> moves = originalAsMatriz.GetRandomCoordinates(Size);

            foreach (var move in moves)
            {
                Matriz individual = FactoryObject.DeepCopy(originalAsMatriz);
                individual.Swap(move);
                poblation.Add(individual);
            }

            Poblation = poblation.Cast<Individual>().ToList();
        }

        public override List<Individual> Select()
        {
            List<Matriz> selectedMatrices = Poblation.Cast<Matriz>().OrderByDescending(x => x.Fitness).Take(Selections).ToList();

            return selectedMatrices.Cast<Individual>().ToList();
        }
    }
}
