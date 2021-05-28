using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Models;

namespace ToDo.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password)
        {

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                throw new EmptyFieldsException();
            }

            User storedAccount = await _accountService.GetByUsername(username);
            if(storedAccount == null)
            {
                throw new InvalidLoginOrPasswordException(username, password);
            }
            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(storedAccount.PasswordHash, password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidLoginOrPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmepassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmepassword))
            {
                result = RegistrationResult.EmptyFields;
            }

            if (password != confirmepassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            User emailAccount = await _accountService.GetByEmail(email);
            if(emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            User usernameAccount = await _accountService.GetByUsername(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if(result == RegistrationResult.Success)
            {
                string passwordhash = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordhash,
                    Role = "User",
                    Status = true,
                    DateJoined = DateTime.Now
                };

                await _accountService.Create(user);

            }

            return result;
        }
    }
}
