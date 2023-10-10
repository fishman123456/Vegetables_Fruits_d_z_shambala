﻿using ComputerGamesCrudApp_AttachedMode.Model;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Vegetables_Fruits_d_z_shambala
{
    // класс, обеспечивающий выполнение операций с БД
    internal class DbVegetablesAndFruitsClient
    {
        // провайдер подключения к БД
        private DbConnectionProvider connectionProvider;

        // конструктор
        public DbVegetablesAndFruitsClient(DbConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        // операции с БД

        // 1. получить все записи
        public List<VegetablesAndFruits> SelectAll()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Veg_Fru_t order by id;", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResult(reader);
                }
            }
        }
        // 1.2 получить  записи названий овощей и фруктов
        public List<VegetablesAndFruits> SelectName()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT Veg_Fru_t.id, Veg_Fru_t.Name_f FROM Veg_Fru_t order by id;", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResultNameId(reader);
                }
            }
        }
        // 1.3 получить  записи цветов овощей и фруктов
        public List<VegetablesAndFruits> SelectColor()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT Veg_Fru_t.id, Veg_Fru_t.Color_f FROM Veg_Fru_t order by id;", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResultColorId(reader);
                }
            }
        }
        // 1.4 показать максимальную калорийность овощей и фруктов
        public List<VegetablesAndFruits> SelectMaxCalories()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * " +
                    " FROM Veg_Fru_t " +
                    "order by Сalories_f desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY;"
                   , connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResult(reader);
                }
            }
        }

        // 1.5 показать минимальную калорийность овощей и фруктов
        public List<VegetablesAndFruits> SelectMinCalories()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * " +
                    " FROM Veg_Fru_t " +
                    "order by Сalories_f  OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY;"
                   , connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResult(reader);
                }
            }
        }
        // 1.5 показать среднюю калорийность овощей и фруктов
        public List<string> SelectAVGCalories()
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT avg (Сalories_f)" +
                    " FROM Veg_Fru_t "
                   , connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    List<string> result = new List<string>();
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0).ToString());
                    }
                    return result;
                }
            }
        }
        // 2. получить запись по id
        public List<VegetablesAndFruits> SelectById(int id)
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VegFru_t order by id;", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // считать строки результат в List<VegetablesAndFruits>
                    return ReadSelectResult(reader);
                }
            }
        }

        // 3. добавить запись
        // Id_f - Name_f - Type_f - Color_f - Сalories_f 

        public void Insert(VegetablesAndFruits VegetablesAndFruits)
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                // формируем команду INSERT с использованием параметров запроса
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Veg_Fru_t (name_f, Type_f, Color_f, Сalories_f)" +
                    " VALUES (@Name, @Type, @Color, @Calories);",
                    connection
                );
                // добавляем параметры в запрос
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Name;
                cmd.Parameters.Add("@Type", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Type;
                cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Color;
                cmd.Parameters.Add("@Calories", System.Data.SqlDbType.Int).Value = VegetablesAndFruits.Calories;
                // выполняем запрос
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    // если результат не соответствует ожидаемому значению, то выбросить исключение
                    throw new Exception($"rowsAffected {rowsAffected} != 1");
                }
            }
        }

        // 4. удалить запись по id
        public void Delete(int id)
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                // формируем команду delete 
                SqlCommand cmd = new SqlCommand(
                    "delete Veg_Fru_t where id = " + id + ";", connection);
                // выполняем запрос
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    // если результат не соответствует ожидаемому значению, то выбросить исключение
                    throw new Exception($"rowsaffected {rowsAffected} != 1");
                }
            }
        }

        // 5. обновить запись по id
        public void Update(VegetablesAndFruits VegetablesAndFruits)
        {
            using (SqlConnection connection = connectionProvider.OpenDbConnection())
            {
                // формируем команду INSERT с использованием параметров запроса
                SqlCommand cmd = new SqlCommand(
                    "update Veg_Fru_t  set Name_f = @Name, Type_f = @Type," +
                    " Color_f = @Color, Сalories_f = @Calories " +
                    "where Id =  @id;",
                    connection
                );
                // добавляем параметры в запрос
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = VegetablesAndFruits.Id;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Name;
                cmd.Parameters.Add("@Type", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Type;
                cmd.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar).Value = VegetablesAndFruits.Color;
                cmd.Parameters.Add("@Calories", System.Data.SqlDbType.Int).Value = VegetablesAndFruits.Calories;
                // выполняем запрос
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    // если результат не соответствует ожидаемому значению, то выбросить исключение
                    throw new Exception($"rowsAffected {rowsAffected} != 1");
                }
            }
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ

        // 1. конвертация строки результата в объект VegetablesAndFruits
        private VegetablesAndFruits ConvertReaderRow(SqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = (string)reader["Name_f"];
            string type = (string)reader["Type_f"];
            string color = (string)reader["Color_f"];
            int calories = (int)reader["Сalories_f"];
            return new VegetablesAndFruits() { Id = id, Name = name, Type = type, Color = color, Calories = calories };
        }

        // 2. чтение табличного результата в список обектов
        private List<VegetablesAndFruits> ReadSelectResult(SqlDataReader reader)
        {
            List<VegetablesAndFruits> VegetablesAndFruitss = new List<VegetablesAndFruits>();
            while (reader.Read())
            {
                VegetablesAndFruits VegetablesAndFruits = ConvertReaderRow(reader);
                VegetablesAndFruitss.Add(VegetablesAndFruits);
            }
            return VegetablesAndFruitss;
        }

        // // 1. конвертация строки результата в объект VegetablesAndFruits номер и имя 
        private VegetablesAndFruits ConvertReaderRowNameId(SqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = (string)reader["Name_f"];

            return new VegetablesAndFruits() { Id = id, Name = name };
        }
        //
        // 2. чтение табличного результата в список обектов
        private List<VegetablesAndFruits> ReadSelectResultNameId(SqlDataReader reader)
        {
            List<VegetablesAndFruits> VegetablesAndFruitss = new List<VegetablesAndFruits>();
            while (reader.Read())
            {
                VegetablesAndFruits VegetablesAndFruits = ConvertReaderRowNameId(reader);
                VegetablesAndFruitss.Add(VegetablesAndFruits);
            }
            return VegetablesAndFruitss;
        }

        // // 1. конвертация строки результата в объект VegetablesAndFruits номер и цвет 
        private VegetablesAndFruits ConvertReaderRowColorId(SqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string color = (string)reader["Color_f"];

            return new VegetablesAndFruits() { Id = id, Color = color };
        }

        // 2. чтение табличного результата в список обектов
        private List<VegetablesAndFruits> ReadSelectResultColorId(SqlDataReader reader)
        {
            List<VegetablesAndFruits> VegetablesAndFruitss = new List<VegetablesAndFruits>();
            while (reader.Read())
            {
                VegetablesAndFruits VegetablesAndFruits = ConvertReaderRowColorId(reader);
                VegetablesAndFruitss.Add(VegetablesAndFruits);
            }
            return VegetablesAndFruitss;
        }

        // // 1. конвертация строки результата в строку среднее значение 


    }
}
