using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    public class UserDB
    {
        private List<UserCredentials> user;
        public List<UserCredentials> User { get => user; set => user = value; }
        public UserDB() { user = new List<UserCredentials>(); }


        #region methods
        public void AddUser(UserCredentials u)
        {
            user.Add(u);
        }


        public void RemoveUser(UserCredentials u)
        {
            user.Remove(u);
        }
        #endregion methods
    }
}
