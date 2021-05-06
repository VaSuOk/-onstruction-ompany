using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Сonstruction_сompany.Users_classes
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
        private uint id;
        private UserType userType;
        private string PIB;
        private string Email;
        private string Phone;
        #endregion

        #region Constructors
        public User(uint id, UserType userType, string PIB, string Email, string Phone)
        {
            this.id = id;
            this.userType = userType;
            this.PIB = PIB;
            this.Email = Email;
            this.Phone = Phone;
        }
        public User(uint id, UserType userType, string PIB)
        {
            this.id = id;
            this.userType = userType;
            this.PIB = PIB;
            this.Email = "";
            this.Phone = "";
        }
        public User()
        {
            this.id = 0;
            this.userType = UserType.Unregistered;
            this.PIB = "";
            this.Email = "";
            this.Phone = "";
        }
        public User(User user)
        {
            this.id = user.id;
            this.userType = user.userType;
            this.PIB = user.PIB;
            this.Email = user.Email;
            this.Phone = user.Phone;
        }
        #endregion

        #region Setters and getters
        public uint GetID() { return id; }
        public UserType GetUserType() { return userType; }
        public string GetPIB() { return PIB; }
        public string GetEmail() { return Email; }
        public string GetPhone() { return Phone; }

        public void SetID(uint id) { this.id = id; }
        public void SetUserType(UserType userType) { this.userType = userType; }
        public void SetPIB(string PIB) { this.PIB = PIB; }
        public void SetEmail(string Email) { this.Email = Email; }
        public void SetPhone(string Phone) { this.Phone = Phone; }
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
