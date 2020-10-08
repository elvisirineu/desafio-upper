using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;

namespace Upper.Desafio.Persistence.Seed
{
    public class ArvoreSeed
    {

        public static List<Arvore> Data()
        {
            var lista = new List<Arvore>();
            lista.Add(new Arvore(1, "Pau-ferro",10, 1));
            lista.Add(new Arvore(2, "Jabuticabeira",15,1));
            lista.Add(new Arvore(3, "Sibipiruna",20,2));
            lista.Add(new Arvore(4, "Cambuci",30,2));
            lista.Add(new Arvore(5, "Guanhuma",40,3));
            lista.Add(new Arvore(6, "Mulungu",50,1));
            lista.Add(new Arvore(7, "Cereja-do-mato",60,3));
            lista.Add(new Arvore(8, "Pitangueira",70,2));
            lista.Add(new Arvore(9, "Jacarandá",20,2));
            lista.Add(new Arvore(10, "Oiti",15,3));

            return lista;
        }

    }
}
