using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;

namespace ToDo.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string email, string username, string password, string confirmpassword);
        System.Threading.Tasks.Task Login(string username, string password);
        void Logout();
        event Action StateChanged;

    }
}
