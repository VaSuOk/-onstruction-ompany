using System;
using System.Collections.Generic;
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
        /*
                public int UserRegistration(string Login, string Password, string NS, string Email, string Phone, UserType userType)
                {
                    try
                    {
                        DataBase.Get_Instance().Connect();
                        MySqlCommand command = new MySqlCommand(
                                    "INSERT INTO `user` (`Type`, `PIB`, `Email`, `Mobile_number`, `Login`, `Password`) " +
                                    "VALUES ( @Type, @PIB, @Email, @Mobile_number, @Login, @Password)", DataBase.Get_Instance().connection);

                        command.Parameters.Add("@Type", MySqlDbType.VarChar).Value = userType;
                        command.Parameters.Add("@PIB", MySqlDbType.VarChar).Value = NS;
                        command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                        command.Parameters.Add("@Mobile_number", MySqlDbType.VarChar).Value = Phone;
                        command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Login;
                        command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;

                        if (command.ExecuteNonQuery() > 0)
                        {
                            this.Email = Email; this.Phone = Phone; this.PIB = NS; this.userType = userType;
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
        */

        /*public int UserLogin(string login, string password)
        {
            
            DataTable temp = new DataTable();
            try
            {
                DataBase.Get_Instance().Connect();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `Login` = @login AND `Password` = @password", DataBase.Get_Instance().connection);
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;

                adapter.Fill(temp);
                if (temp.Rows.Count > 0)
                {
                    this.id = Convert.ToUInt32(temp.Rows[0][0]);
                    this.userType = ConvertToEnum(Convert.ToString(temp.Rows[0][1]));
                    this.PIB = Convert.ToString(temp.Rows[0][2]);
                    this.Email = Convert.ToString(temp.Rows[0][3]);
                    this.Phone = Convert.ToString(temp.Rows[0][4]);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }

        }*/

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
