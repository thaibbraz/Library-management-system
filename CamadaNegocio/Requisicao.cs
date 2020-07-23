using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Requisicao:Notifier
    {
        #region Construtores

        public Requisicao(int _id, DateTime _dataInicio, DateTime _dataFim, bool devolvido, int _idRequisitor, int _idLivro)
        {
            this.id = _id;
            this.dataInicio = _dataInicio;
            this.dataFim = _dataFim;
            this.devolvido = false;
            this.idRequisitor = _idRequisitor;
            this.idLivro = _idLivro;


        }

        public Requisicao()
        {
        }
        #endregion

        #region Propriedades

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value;
            this.OnPropertyChanged("Id");
            }
        }
        private DateTime dataInicio;
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value;
             this.OnPropertyChanged("DataInicio");
            }
        }
        private DateTime dataFim;
        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value;
                this.OnPropertyChanged("DataFim");
            }
        }
        private bool devolvido;
        public bool Devolvido
        {
            get { return devolvido; }
            set { devolvido = value;
                this.OnPropertyChanged("Devolvido");
            }
        }
        private int idRequisitor;
        public int IdRequisitor
        {
            get { return idRequisitor; }
            set { idRequisitor = value;
                this.OnPropertyChanged("IdRequisitor");
            }
        }
        private int idLivro;
        public int IdLivro
        {
            get { return idLivro; }
            set { idLivro = value;
                this.OnPropertyChanged("IdLivro");
            }
        }

        #endregion

        #region Metodos

        public bool Gravar(ref string sErro)
        {
            return CamadaDados.Requisicao.Gravar(this.Id, this.DataInicio, this.DataFim, this.devolvido, this.IdRequisitor, this.IdLivro, ref sErro);

        }

        // Vai à camada de dados e obtem lista: 

        public static DataTable ObterLista()

        {

            DataTable dataTable = CamadaDados.Requisicao.ObterLista();

            return dataTable;

        }



        // Guarda a lista obtida num dataTable 

        public static RequisicaoCollection ObterListaRequisicoes()

        {

            DataTable dataTable = Requisicao.ObterLista();
            RequisicaoCollection requisicoes = new RequisicaoCollection(dataTable);
            return requisicoes;

        }

        #endregion



        public bool Eliminar(ref string sErro)
        {
            return CamadaDados.Requisicao.Eliminar(this.Id, ref sErro);
        }

    }
    public class RequisicaoCollection : Collection<Requisicao>
    {
            #region Construtores

            public RequisicaoCollection()
            {
            }

            public RequisicaoCollection(DataTable dataTable)
            {
                if (dataTable == null)
                {
                    return;
                }

                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Requisicao requisicao = new Requisicao();
                    requisicao.Id = dataRow.Field<int>("Id");
                    requisicao.DataInicio = dataRow.Field<DateTime>("DataInicio");
                    requisicao.DataFim = dataRow.Field<DateTime>("DataFim");
                    requisicao.Devolvido = dataRow.Field<bool>("Devolvido");
                    requisicao.IdRequisitor = dataRow.Field<int>("IdRequisitor");
                    requisicao.IdLivro = dataRow.Field<int>("IdLivro");

                    this.Add(requisicao);
                }
            }

            #endregion


            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(
                        this,
                        new PropertyChangedEventArgs(propertyName)
                        );
                }
            }
     }

   
}
