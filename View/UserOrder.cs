using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.View
{
    public enum Type_Foundation
    {
        Стовпчастий,
        Стрічковий,
        Пальовий,
        Плитний
    }
    public enum Type_Building
    {
        Приватний,
        Квартирний,
        Офісний,
        Виробничий,
        Оздоровчий
    }
    public enum Type_Roof
    {
        Плаский,
        Скатний,
        Шатровий,
        Двоскатний,
        Багатоскатний
    }
    public enum Rofing_Material
    {
        Металочерепиця,
        Профнастил,
        Ондулін,
        Шифер,
        Фальц
    }
    public enum Wall_Material
    {
        Селікатна_цегла,
        Керамічна_цегла,
        Керамічний_блок,
        Газоблок,
        Ракушняк,
        Шлакоблок
    }
    class UserOrder
    {
        public uint ID { get; set; }
        public User user { get; set; }
        public Type_Building type_Building;
        public Type_Foundation type_Foundation { get; set; }
        public Type_Roof type_Roof { get; set; }
        public Wall_Material wall_Material { get; set; }
        public Rofing_Material rofing_Material { get; set; }
        public byte[] Project_File { get; set; }
    }
}
