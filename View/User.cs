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
        public uint id { get; set; }
        public UserType userType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Region { get; set; }
        public string Sity { get; set; }
        public byte[] UserImage { get; set; }
        #endregion

    }
}
