using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheTwins.Model
{
    public class Arrows
    {
        public string name { get; }
        public string type { get; set; }
        public int damage { get; set; }
        public int price { get; set; }
        public int amount { get; set; }

        
        public Arrows(string name, string type, int damage, int price, int amount)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
            this.price = price;
            this.amount = amount;
        }
    }

    public struct SwordAndArmor
    {
        public string name;
        public string type;
        public float range;
        public int damage;
        public float atkSpeed;
        public int armor;
        public int maxHP;
        public int price;

        public SwordAndArmor(string name, float range, int damage, float atkSpeed, int price)//Sword
        {
            this.name = name;
            this.type = "Sword";
            this.range = range;
            this.damage = damage;
            this.atkSpeed = atkSpeed;
            this.price = price;
            this.armor = 0;
            this.maxHP = 0;
        }
        public SwordAndArmor(string name, int armor, int maxHP, int price)//Armor
        {
            this.name = name;
            this.type = "Armor";
            this.range = 0;
            this.damage = 0;
            this.atkSpeed = 0;
            this.price = price;
            this.armor = armor;
            this.maxHP = maxHP;
        }
    }
    public static class EquipmentClass
    {
        private static List<SwordAndArmor> swordandArmor = new List<SwordAndArmor>();
        public static List<SwordAndArmor> SwordandArmor
        {
            get {
                if (swordandArmor.Count == 0)
                {
                    swordandArmor = new List<SwordAndArmor>
                    {
                        new SwordAndArmor("wooden sword", 1f, 2, 50f, 20),
                        new SwordAndArmor("iron sword", 1.5f, 3, 55f, 30),
                        new SwordAndArmor("gold sword", 2f, 1, 310f, 50),
                        new SwordAndArmor("wood armor", 5, 20, 10),
                        new SwordAndArmor("iron armor", 8, 30, 20),
                        new SwordAndArmor("gold armor", 10, 40, 50)
                    };
                }
                return swordandArmor;

            } 
                
        }

        private static List<Arrows> quiver = new List<Arrows>();
        public static List<Arrows> Quiver
        {
            get
            {
                if (quiver.Count == 0)
                { 
                    quiver = new List<Arrows>
                    {
                        new Arrows("NormalArrow", "Normal", 4, 5, 0), //When there are local saves, go get the amount value
                        new Arrows("OreArrow", "Ore", 8, 1, 0) //When there are local saves, go get the amount value
                    };
                }
                return quiver;
            }
        }
    }
}