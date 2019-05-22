using JK.Core.Architecture.DDD;
using JK.Cube.Domain.Exceptions;
using JK.Cube.Domain.Extensions;
using JK.Cube.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JK.Cube.Domain.Models
{
    public class Cube : IAggregateRoot
    {
        public string Id { get; set; }
     
        public int XLenght { get; set; }

        public int YLenght { get; set; }

        public int ZLenght { get; set; }

        public Dictionary<Coordenate, long> Nodes { get; set; }

        public Cube()
        {
            Nodes = new Dictionary<Coordenate, long>();
        }

        public void GenerateCube(int lenght)
        {
            if (1 > lenght  || lenght > 100)
            {
               throw new MatrixRangeOutLimitsException($"the matrix out range, range is ${lenght}");
            }

            if(!Nodes.Any())
            {
                XLenght = lenght;
                YLenght = lenght;
                ZLenght = lenght;
            }
            if (string.IsNullOrEmpty(Id))
            {
                Id = $"{XLenght}-{YLenght}-{ZLenght}-{DateTime.UtcNow}".ToHex();
            }
            if (XLenght>0 && YLenght>0 && ZLenght>0)
            {
                for (int x=0; x< XLenght; x++)
                {
                    for(int y = 0; y< YLenght; y++)
                    {
                        for (int z = 0; z < YLenght; z++)
                        {
                            Nodes.Add(new Coordenate {X =x+1,Y=y+1, Z=z+1 }, 0);
                        }
                    }
                }
            }
        }

        public void Update(Coordenate coordenate, long val)
        {
            if (Math.Pow(-10, 9)  > val || val > Math.Pow(10,9))
            {
                throw new ValueNodeAssignOutLimitsException($"Value assigned outside the limits, value is {val}");
            }

            if (Nodes.Any(it=> it.Key.X == coordenate.X && it.Key.Y == coordenate.Y && it.Key.Z == coordenate.Z))
            {
                Nodes[coordenate] = val;
            }
        }

        public long Query(Coordenate coordenate1, Coordenate coordenate2)
        {
            if(coordenate1.X <= coordenate2.X && coordenate1.Y <= coordenate2.Y && coordenate1.Z <= coordenate2.Z && 
                coordenate2.X<= XLenght && coordenate2 .Y<= YLenght && coordenate2.Z <= ZLenght)
            {
                var nodes = Nodes.Where(it => it.Key.X >= coordenate1.X && it.Key.X <= coordenate2.X && it.Key.Y >= coordenate1.Y && 
                                        it.Key.Y <= coordenate2.Y && it.Key.Z >= coordenate1.Z && it.Key.Z <= coordenate2.Z);
                return nodes?.Sum(it => it.Value) ?? 0;
            }
            else
            {
                throw new QueryOutRangeException("Query out limit of matrix");
            }
        }
    }
}
