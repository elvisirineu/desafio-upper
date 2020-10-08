using System;
using System.Collections.Generic;
using System.Text;
using Upper.Desafio.Domain.Entities;

namespace Upper.Desafio.Persistence.Seed
{
    public class EspecieSeed
    {
        public static List<Especie> Data()
        {
            var lista = new List<Especie>();
            lista.Add(new Especie(1, "Nativa"));
            lista.Add(new Especie(2, "Exótica"));
            lista.Add(new Especie(3, "Invasora"));

            return lista;
        }

    }
}
