using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IUserHelper
    {
        User GetCurrentUser();
        void LoginUser();
        void CreateUser();
        void ChangePassword();
    }
}
