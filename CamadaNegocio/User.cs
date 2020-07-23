using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
 // Não estou a utilizar neste momento esta class
{
    public class User
    {

        #region Construtores

        public User()
        {
            this.id = 0;
            this.name = string.Empty;
            this.password = string.Empty;
        }

        public User(int id, string name)
            : this()
        {
            this.id = id;
            this.name = name;
        }


        #endregion

        #region Propriedades

        private int id;
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        private string password;
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
            }
        }


        #endregion

        #region Metodos

        // Vai buscar a lista dos users à camada de dados
        public static DataTable GetList(ref string error)
        {
            return CamadaDados.User.GetList(ref error);
        }
        // Vai instanciar a coleção na camada de negócios
        public static UserCollection GetUserList(ref string error)
        {
            DataTable dataTable = User.GetList(ref error);

            UserCollection users = new UserCollection(dataTable);

            return users;
        }
        // Criar novo user
        public void New()
        {
            this.id = 0;
            this.Name = string.Empty;
            this.Password = string.Empty;
        }

        public bool Save(ref string error)
        {
            return CamadaDados.User.Save(this.Id, this.Name, this.Password, ref error);
        }

        public bool Delete(ref string error)
        {
            return CamadaDados.User.Delete(this.Id, ref error);
        }
        // Lista com filtro de nome
        public static List<string> GetUserNames(ref string error)
        {
            CamadaNegocio.UserCollection users = CamadaNegocio.User.GetUserList(ref error);
            List<string> list = GetUserNames(users);

            return list;
        }
        // Recebe a lista de users e instancia numa nova lista
        public static List<string> GetUserNames(CamadaNegocio.UserCollection users)
        {
            List<string> list = null;
            if (users != null)
            {
                list = (from element in users
                        select element.Name).ToList();
            }
            return list;
        }

        #endregion
    }

    public class UserCollection : Collection<User>
    {
        #region Construtores

        public UserCollection()
        {
        }

        public UserCollection(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                this.Add(user);
            }
        }

        public UserCollection(DataTable dataTable)
            : this()
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {
                User user = new User();
                user.Id = dataRow.Field<int>("Id");
                user.Name = dataRow.Field<string>("Name");
                user.Password = dataRow.Field<string>("Password");

                this.Add(user);
            }
        }

        #endregion

    }
}
