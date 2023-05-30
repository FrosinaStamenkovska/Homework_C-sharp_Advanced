using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Models.Database
{
    public class UserDatabase
    {
        private string _folderPath;
        private string _filePath;
        
        public UserDatabase()
        {
            _folderPath = @"..\..\..\Users";
            _filePath = _folderPath + @"\Users.json";

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        private List<User> ReadFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string content = sr.ReadToEnd();
                    List<User> result = JsonConvert.DeserializeObject<List<User>>(content);

                    return result ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error happend during the storage operation!");
            }
        }

        private void SaveToFile(List<User> users)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    string jsonContent = JsonConvert.SerializeObject(users);
                    sw.WriteLine(jsonContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error happend during the storage operation");
            }
        }

        public User FindUser(string username)
        {
            List<User> _users = ReadFromFile();
            User user = _users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public bool CorrectPassword(User user, string password)
        {
            User foundUser = FindUser(user.Username);
            if (foundUser != null && user.Password == password)
            {
                return true;
            }
            return false;
        }

        public void InsertUser (User user)
        {
            List<User> _users = ReadFromFile();
            User foundUser = _users.FirstOrDefault(x => x.Username == user.Username);
            if (foundUser == null) 
            {
                _users.Add(user);
                SaveToFile(_users);
            }
        }
        public List<User> GetAllUsers()
        {
            List<User> _users = ReadFromFile();
            return _users;
        }

        public void UpdateUser(User user)
        {
            List<User> _users = ReadFromFile();
            User foundUser = _users.FirstOrDefault(x => x.Username == user.Username);

            if (foundUser == null)
            {
                throw new Exception($"User with username {user.Username} is not found");
            }
            int indexOfUser = _users.IndexOf(foundUser);
            _users[indexOfUser] = user;
            SaveToFile(_users);
        }
    }
}
