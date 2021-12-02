using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    public class UserCredentials
    {
        #region fields
        private string userName;
        private string userLogin;
        private string password;
        #endregion  fields


        #region properties
        public string UserName { get => userName; set => userName = value; }
        public string UserLogin { get => userLogin; set => userLogin = value; }
        public string Password { get => password; set => password = value; }
        #endregion properties


        #region constructors
        public UserCredentials(string userName, string userLogin, string password)
        {
            this.userName = userName;
            this.userLogin = userLogin;
            this.password = password;
        }
        #endregion constructors
    }
}
