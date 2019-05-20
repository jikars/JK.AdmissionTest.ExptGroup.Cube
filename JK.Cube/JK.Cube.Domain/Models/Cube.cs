using JK.Core.Archytecture.DDD;
using JK.Cube.Domain.Exceptions;
using JK.Cube.Domain.Extensions;
using JK.Cube.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JK.Cube.Domain.Models
{
    public class Cube : AggregateRoot
    {

        public int XLenght { get; set; }

        public int YLenght { get; set; }

        public int ZLenght { get; set; }

        public Dictionary<Coordenate, long> Nodes { get; set; }

        public  string Id {
            get
            {
                if (string.IsNullOrEmpty(_Id))
                {
                    _Id = $"{XLenght}-{YLenght}-{ZLenght}-{DateTime.UtcNow}".ToHex();
                }
                return _Id;
            }
            set
            {
                if (string.IsNullOrEmpty(_Id))
                {
                    Id = value;
                }
            }
        }

        public void GenerateCube()
        {
            if (Nodes.Any() && XLenght>0 && YLenght>0 && ZLenght>0)
            {
                Nodes = new Dictionary<Coordenate, long>();
                for (int x=0; x< XLenght; x++)
                {
                    for(int y = 0; y< YLenght; y++)
                    {
                        for (int z = 0; z < YLenght; z++)
                        {
                            Nodes.Add(new Coordenate {X =x,Y=y, Z=z }, 0);
                        }
                    }
                }
            }
        }

        public void Update(Coordenate coordenate, long val)
        {
            if (Nodes.ContainsKey(coordenate))
            {
                Nodes[coordenate] = val;
            }
        }

        public long Query(Coordenate coordenate1, Coordenate coordenate2)
        {
            if(coordenate1.X < coordenate2.X && coordenate1.Y < coordenate2.Y && coordenate1.Z< coordenate2.Z && 
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
