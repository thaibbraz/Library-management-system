using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{ 
    
    // Não estou a utilizar neste momento esta class

    public class Estatistica
    {
        #region Construtores

        public Estatistica()
        {
            this.ano = 0;
            this.mes = 0;
            this.contagem = 0;
        }

        #endregion

        #region Propriedades

        private int ano;
        public int Ano
        {
            get { return this.ano; }
            set
            {
                this.ano = value;
            }
        }

        private int mes;
        public int Mes
        {
            get { return this.mes; }
            set
            {
                this.mes = value;
            }
        }

        private int contagem;
        public int Contagem
        {
            get { return this.contagem; }
            set
            {
                this.contagem = value;
            }
        }

        #endregion

        #region Metodos

        public static DataTable ObterLista()
        {
            return CamadaDados.Requisicao.ObterEstatistica();
        }

        public static EstatisticaCollection ObterListaEstatistica()
        {
            DataTable dataTable = Estatistica.ObterLista();

            EstatisticaCollection estatisticas = new EstatisticaCollection(dataTable);

            return estatisticas;
        }

        public static DataTable ObterLista(DateTime dataInicio, DateTime dataFim)
        {
            return CamadaDados.Requisicao.ObterEstatistica(dataInicio, dataFim);
        }


        public static EstatisticaCollection ObterListaEstatistica(DateTime dataInicio, DateTime dataFim)
        {
            DataTable dataTable = Estatistica.ObterLista(dataInicio, dataFim);

            EstatisticaCollection estatisticas = new EstatisticaCollection(dataTable);

            return estatisticas;
        }

        public void Novo()
        {
            this.Ano = 0;
            this.Mes = 0;
            this.Contagem = 0;
        }


        #endregion


        public class EstatisticaCollection : Collection<Estatistica>
        {
            #region Construtores

            public EstatisticaCollection()
            {
            }

            public EstatisticaCollection(IEnumerable<Estatistica> estatisticas)
            {
                foreach (Estatistica estatistica in estatisticas)
                {
                    this.Add(estatistica);
                }
            }

            public EstatisticaCollection(DataTable dataTable)
                : this()
            {
                if (dataTable == null)
                {
                    return;
                }

                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Estatistica estatistica = new Estatistica();
                    estatistica.Ano = dataRow.Field<int>("Ano");
                    estatistica.Mes = dataRow.Field<int>("Mes");
                    estatistica.Contagem = dataRow.Field<int>("Contagem");

                    this.Add(estatistica);
                }
            }

            #endregion

        }

    }
}
