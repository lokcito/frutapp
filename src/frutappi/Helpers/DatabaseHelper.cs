using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

using frutappi.Models;
namespace frutappi.Helpers
{
    public class DatabaseHelper
    {
        public static bool insert<T>(ref T data, string _path)
        {
            using (var connection = new SQLiteConnection(_path))
            {
                connection.CreateTable<T>();
                if ( connection.Insert(data) != 0 )
                {
                    //connection.Close();
                    return true;
                }
            }
            return false;
        }
        public static List<Product> getProducts(string _path)
        {
            List<Product> _tmp = new List<Product>();
            using (var connection = new SQLiteConnection(_path)) {
                _tmp = connection.Table<Product>().ToList();
            }
            return _tmp;
        }
        public static string locate(string _path)
        {
            string pathDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(pathDirectory, _path);
        }
    }
}