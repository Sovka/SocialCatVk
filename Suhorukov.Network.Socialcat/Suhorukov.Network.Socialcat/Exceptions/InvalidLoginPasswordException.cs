using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suhorukov.Network.Socialcat.Exceptions
{
    class InvalidLoginPasswordException : Exception
    {
        public InvalidLoginPasswordException() : base("ошибка авторизации - неверный логин или пароль")
        {
        }
    }
}
