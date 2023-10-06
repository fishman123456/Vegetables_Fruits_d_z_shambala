using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables_Fruits_d_z_shambala
{
    // Класс, описывающий сущность "Фруты-Овощи" - dataclass
    internal class VegetablesAndFruits
    {
        // поля - столбцы таблицы БД
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public decimal Calories { get; set; }

        // 
        public override string ToString()
        {
            return $"{Id} - {Name} - {Type} - {Color} - {Calories}";
        }
    }
}
// запросы для проверки 05-10-2023
//use Vegetables_Fruits
//update Veg_Fru  set Name_f = 'name', Type_f = 'груша', Color_f = 'желтая' Caloric_f = 100
//                    where id = 2
//select * from game_t