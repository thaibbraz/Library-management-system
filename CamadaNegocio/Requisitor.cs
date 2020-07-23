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
    public class Requisitor:Notifier
    {
        #region Construtores

        public Requisitor(int _id, string _nome, int _telemovel, string _curso)
        {
            this.id = _id;
            this.nome = _nome;
            this.telemovel = _telemovel;
            this.curso = _curso;

        }

        public Requisitor()
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
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value;
                this.OnPropertyChanged("Nome");

            }
        }
        private int telemovel;
        public int Telemovel
        {
            get { return telemovel; }
            set { telemovel = value;
                this.OnPropertyChanged("Telemovel");

            }
        }
        private string curso;
        public string Curso
        {
            get { return curso; }
            set { curso = value;

                this.OnPropertyChanged("Curso");
            }
        }

        #endregion

        #region Metodos

        // Gravar

        public bool Gravar(ref string sErro)
        {
            return CamadaDados.Requisitor.Gravar(this.Id, this.Nome, this.Telemovel, this.Curso, ref sErro);

        }

        // Obter a tabela da camada de dados 

        public static DataTable ObterLista()

        {
            DataTable dataTable = CamadaDados.Requisitor.ObterLista();
            return dataTable;
        }

        // Obter Lista > Collection

        public static RequisitorCollection ObterListaRequisitores()

        {
            DataTable dataTable = Requisitor.ObterLista();

            RequisitorCollection requisitores = new RequisitorCollection(dataTable);
            return requisitores;


        }


        #endregion
        
        public void Novo()
        {
            this.Id = 0;
            this.Nome = "";
            this.Telemovel = 0;
            this.Curso = "";
        }

        public bool Eliminar(ref string sErro)
        {
            return CamadaDados.Requisitor.Eliminar(this.Id, ref sErro);
        }

        internal bool DentroFiltro(string textoFiltro)
        {
            bool isDentro = false;
            int numeroTexto = 0;

            if (int.TryParse(textoFiltro, out numeroTexto))
            {
                if (this.Id == numeroTexto)
                {
                    isDentro = true;
                }
            }


            if (int.TryParse(textoFiltro, out numeroTexto))
            {
                if (this.Telemovel == numeroTexto)
                {
                    isDentro = true;
                }
            }

            if (!isDentro)
            {
                if (this.Nome.ToUpper().Contains(textoFiltro.ToUpper()))
                {
                    isDentro = true;
                }
            }
            if (!isDentro)
            {
                if (this.Curso.ToUpper().Contains(textoFiltro.ToUpper()))
                {
                    isDentro = true;
                }
            }
            return isDentro;
        }
    }
    // Criar Collection

    public class RequisitorCollection : Collection<Requisitor>
        {
            #region Construtores

            public RequisitorCollection()
            {
            }

            public RequisitorCollection(DataTable dataTable)
            {
                if (dataTable == null)
                {
                    return;
                }

                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Requisitor requisitor = new Requisitor();
                    requisitor.Id = dataRow.Field<int>("Id");
                    requisitor.Nome = dataRow.Field<string>("Nome");
                    requisitor.Telemovel = dataRow.Field<int>("Telemovel");
                    requisitor.Curso = dataRow.Field<string>("Curso");

                    this.Add(requisitor);
                }
            }

            #endregion

            // INotifyPropertyChanged

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

        public RequisitorCollection(IEnumerable<Requisitor> requisitores)
        {
            foreach (Requisitor requisitor in requisitores)
            {
                this.Add(requisitor);
            }
        }

        public RequisitorCollection Filtrar(String textoFiltro)
        {
            RequisitorCollection requisitores;
            if (string.IsNullOrEmpty(textoFiltro))
            {
                requisitores = this;
            }
            else
            {

                IEnumerable<Requisitor> filtroRequisitores = from Requisitor element in this
                                                  where (element.DentroFiltro(textoFiltro))
                                                  select element;

                requisitores = new RequisitorCollection(filtroRequisitores);


            }


            return requisitores;
        }
    }


     
}
