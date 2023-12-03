using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _12_SQLite_App.Models;

namespace _12_SQLite_App
{
    internal class Repository
    {
        string fileName = System.IO.Path.Combine(FileSystem.AppDataDirectory, "people.db3");
        SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(fileName);
            conn.CreateTable<Person>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;

            try
            {
                init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public List<Person> GetAllPeople()
        {
            
            try
            {
                init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
