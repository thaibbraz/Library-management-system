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
    public class Livro: Notifier
    {
        #region Construtores

        public Livro(int _id, String _titulo, String _autor)
        {
            this.aberto = false;
            this.id = _id;
            this.titulo = _titulo;
            this.autor = _autor;
        }

        public Livro()
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
        private string autor;
        public string Autor
        {
            get { return autor; }
            set { autor = value;
                this.OnPropertyChanged("Autor");

            }
        }
        private bool aberto;
        public bool Aberto
        {
            get { return aberto; }
            set { aberto = value;
            }
        }
        private string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value;
                this.OnPropertyChanged("Titulo");
            }
        }

        #endregion

        #region Metodos

        public void Novo()
        {
            this.Id = 0;
            this.Autor = "";
            this.Titulo = "";

        }

        public bool Eliminar(ref string sErro)
        {
            return CamadaDados.Livro.Eliminar(this.Id, ref sErro);
        }

        public bool Gravar(ref string sErro)
        {
            return CamadaDados.Livro.Gravar(this.Id, this.Titulo, this.Autor, this.Aberto, ref sErro);

        }

        public static DataTable ObterLista()

        {
            DataTable dataTable = CamadaDados.Livro.ObterLista();
            return dataTable;
        }

        public static LivroCollection ObterListaLivros()

        {
            DataTable dataTable = Livro.ObterLista();

            LivroCollection livros = new LivroCollection(dataTable);
            return livros;

         }

        public static List<String> ObterListaTitulos()
        {
            CamadaNegocio.LivroCollection livros = CamadaNegocio.Livro.ObterListaLivros();

            List<String> lista = (from element in livros select element.Titulo).ToList();
            return lista;
        }

        internal bool Disponivel()
        {
            bool isDentro = false;

            if (this.Aberto == false)
            {
                isDentro = true;
            }

            return isDentro;
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
            if (!isDentro)
            {
                if (this.Autor.ToUpper().Contains(textoFiltro.ToUpper()))
                {
                    isDentro = true;
                }
            }
            if (!isDentro)
            {
                if (this.Titulo.ToUpper().Contains(textoFiltro.ToUpper()))
                {
                    isDentro = true;
                }
            }
            return isDentro;
        }

        #endregion
    }
   
    public class LivroCollection : Collection<Livro>
     {
            #region Construtores

            public LivroCollection()
            {
            }

            public LivroCollection(DataTable dataTable)
            {
                if (dataTable == null)
                {
                    return;
                }

                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {

                    Livro livro = new Livro();
                    livro.Id = dataRow.Field<int>("Id");
                    livro.Autor = dataRow.Field<string>("Autor");
                    livro.Titulo = dataRow.Field<string>("Titulo");
                    livro.Aberto = dataRow.Field<bool>("Aberto");

                    this.Add(livro);
                }
            }
            public LivroCollection(IEnumerable<Livro> livros)
            {
                foreach (Livro livro in livros)
                {
                    this.Add(livro);
                }
            }
            public LivroCollection FiltroDisponivel()
            {
                LivroCollection livros;

                IEnumerable<Livro> filtroLivros = from Livro element in this
                                                              where (element.Disponivel())
                                                              select element;

               livros = new LivroCollection(filtroLivros);
              

                return livros;
            }
            public LivroCollection FiltroIndisponivel()
            {
                LivroCollection livros;

                IEnumerable<Livro> filtroLivros = from Livro element in this
                                                  where (!(element.Disponivel()))
                                                  select element;

                livros = new LivroCollection(filtroLivros);


                return livros;
            }
            public LivroCollection Filtrar(String textoFiltro)
            {
                LivroCollection livros;
            if (string.IsNullOrEmpty(textoFiltro)) {
                livros = this;
            }
            else
            {

                IEnumerable<Livro> filtroLivros = from Livro element in this
                                                  where (element.DentroFiltro(textoFiltro))
                                                  select element;

                livros = new LivroCollection(filtroLivros);
            }
               



                return livros;
            }



        #endregion

    }
   
}


