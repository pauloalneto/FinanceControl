using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class UserBase
    {
        public UserBase()
        {

        }

        public UserBase(int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; protected set; }
        public string Name { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }

        public void SetUserId(int id)
        {
            this.UserId = id;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetLogin(string logn)
        {
            this.Login = Login;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
        public void SetEmail(string email)
        {
            this.Email = email;
        }
    }
}
