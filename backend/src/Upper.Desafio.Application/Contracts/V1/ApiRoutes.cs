using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upper.Desafio.Application.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class UpperDesafio
        {
            public const string Arvore = Base + "/arvore";
            public const string ArvoreById = Base + "/arvore/{id}";

            public const string Especie = Base + "/especie";
            public const string EspecieById = Base + "/especie/{id}";

            public const string Grupo = Base + "/grupo";
            public const string GrupoById = Base + "/grupo/{id}";

            public const string Colheita = Base + "/colheita";
            public const string ColheitaById = Base + "/colheita/{id}";
            public const string ColheitaByArvoreId = Base + "/colheita/get-colheita-by-arvore/{id}";
            public const string ColheitaByGrupoId = Base + "/colheita/get-colheita-by-grupo/{id}";
            public const string ColheitaByPeriodo = Base + "/colheita/get-colheita-by-periodo/{periodo}";
        }

    }
}
