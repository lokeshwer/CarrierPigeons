using System;
using System.Collections.Generic;
using System.Web.Security;
using DomainModel.Tests;
using NHibernate;

namespace DomainModel.UserRegistration
{
    public class UserRegistrationService : IUserRegistration
    {
        public IUserRepository Repository { get; set; }

        public UserRegistrationService(IUserRepository repository)
        {
            this.Repository = repository;
        }


        public int MinPasswordLength
        {
            get
            {
                return 8;
            }
        }

        public bool AreCredentialsValid(string email, string password)
        {
            User ExistingUser = Repository.LoadUser(email);
            if (ExistingUser != null && ExistingUser.Password.Equals(password))
            {
                return true;
            }
            return false;
        }

        public MembershipCreateStatus CreateUser(User user)
        {
            User existingUser = Repository.LoadUser(user.EmailAddress);
            if (existingUser != null)
                throw new DuplicateRegistrationException();
            Repository.SaveUser(user);
            return MembershipCreateStatus.Success;

        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }


        //public bool ChangePassword(string userName, string oldPassword, string newPassword)
        //{
        //    //User currentUser = _provider.GetUser(userName, true /* userIsOnline */);
        //    //return currentUser.ChangePassword(oldPassword, newPassword);
        //}

    }

}