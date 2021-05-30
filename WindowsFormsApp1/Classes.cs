using MySql.Data.MySqlClient;
using System;

namespace WindowsFormsApp1
{
    class hotel
    {
        public string name;
        public string country;
        public string address;
        public int pricePerDay;

        public string get(char t)
        {
            return address;
        }
        public int get(int i)
        {
            return pricePerDay;
        }
        public hotel() { }
        public hotel(string n, string c, string a, int p)
        {
            name = n;
            country = c;
            address = a;
            pricePerDay = p;
        }
    }

    class tour : hotel
    {
        public string transportType;
        public DateTime startTour;
        public string duration;
        public int id;


        public tour() { }
        public tour(string n, string c, string a, int p, string t, DateTime sT, string d,int i)
        {
            name = n;
            country = c;
            address = a;
            pricePerDay = p;
            transportType = t;
            startTour = sT;
            duration = d;
            id = i;

        }
        public static string operator +(tour tmp)
        {
            return tmp.name;
        }

    }

    class DB
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=practica");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
