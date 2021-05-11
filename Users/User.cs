using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Сonstruction_сompany.Users
{
    public enum UserType
    {
        Unregistered,
        Customer,
        Worker,
        Moderator
    }
    public class User
    {
        #region Data fields
        protected uint id;
        protected UserType userType;
        protected string Name;
        protected string Surname;
        protected string Email;
        protected string Phone;
        #endregion

        #region Constructors
        public User(uint id = 0, UserType userType = UserType.Unregistered,
            string Name = "", string Surname = "", string Email = "", string Phone = "")
        {
            this.id = id;
            this.userType = userType;
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
        }

        public User(User user)
        {
            this.id = user.id;
            this.userType = user.userType;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Phone = user.Phone;
        }
        #endregion

        #region Setters and getters
        public uint GetID() { return id; }
        public UserType GetUserType() { return userType; }
        public string GetName() { return Name; }
        public string GetSurname() { return Surname; }
        public string GetEmail() { return Email; }
        public string GetPhone() { return Phone; }
        /*  нема потреби їх юзати
        public void SetID(uint id) { this.id = id; }
        public void SetUserType(UserType userType) { this.userType = userType; }
        public void SetName(string PIB) { this.PIB = PIB; }
        public void SetEmail(string Email) { this.Email = Email; }
        public void SetPhone(string Phone) { this.Phone = Phone; }
        */
        #endregion

        #region Methods
        public static UserType ConvertToEnum(string UEnum)
        {
            switch (UEnum)
            {
                case "Customer":
                    {
                        return UserType.Customer;
                    }
                case "Worker":
                    {
                        return UserType.Worker;
                    }
                case "Moderator":
                    {
                        return UserType.Moderator;
                    }
                default: return UserType.Unregistered;
            }
        }
        #endregion
    }
}
