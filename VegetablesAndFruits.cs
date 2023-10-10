using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables_Fruits_d_z_shambala
{
    // Класс, описывающий сущность "Фруты-Овощи" - dataclass
    public class VegetablesAndFruits
    {
        // поля - столбцы таблицы БД
        public long? Id { get; set; } = null; 
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int? Calories { get; set; } = null; // вот так int занул делаем

        //public VegetablesAndFruits(long id,string name, string type, string color, decimal calories ) {
        //    Id = id;
        //    Name = name;
        //    Type = type;
        //    Color = color;
        //    Calories = calories;
        //}
        // 
        public override string ToString()
        {
            return $"{Id} {Name} {Type} {Color} {Calories}";
        }
    }
}
// запросы для проверки 05-10-2023
//use Vegetables_Fruits
//update Veg_Fru  set Name_f = 'name', Type_f = 'груша', Color_f = 'желтая' Caloric_f = 100
//                    where id = 2
//select * from game_t