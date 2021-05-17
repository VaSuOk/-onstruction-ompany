using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Media;

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
        private uint id;
        private UserType userType;
        private string Name;
        private string Surname;
        private string Email;
        private string Phone;
        private int Age;
        private string Region;
        private string Sity;
        private byte[] UserImage;
        #endregion

        #region Constructors
        public User(uint id = 0, UserType userType = UserType.Unregistered,
            string Name = "", string Surname = "", string Email = "", string Phone = "", int Age=0, string Region = "", string Sity="", byte[] imageSource=null)
        {
            this.id = id;
            this.userType = userType;
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
            this.Age = Age;
            this.Region = Region;
            this.Sity = Sity;
            this.UserImage = imageSource;
        }

        public User(User user)
        {
            this.id = user.id;
            this.userType = user.userType;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.Age = user.Age;
            this.Region = user.Region;
            this.Sity = user.Sity;
            this.UserImage = user.UserImage;
        }
        #endregion

        #region Setters and getters
        public uint GetID() { return id; }
        public UserType GetUserType() { return userType; }
        public string GetName() { return Name; }
        public string GetSurname() { return Surname; }
        public string GetEmail() { return Email; }
        public string GetPhone() { return Phone; }
        public int GetAge() { return Age; }
        public string GetRegion() { return Region; }
        public string GetSity() { return Sity; }
        public byte[] GetUserImage() { return UserImage; }

        public void SetID(uint id) { this.id = id; }
        public void SetUserType(UserType userType) { this.userType = userType; }
        public void SetName(string Name) { this.Name = Name; }
        //public string SetSurname() { return Surname; }
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
