using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheTwins.Model
{
    public struct Enchants
    {
        public int tier;
        public int bonusHp;
        public int BonusDamage;
        public int price;

        public Enchants(int tier, int bonusHp, int BonusDamage, int price)
        {
            this.tier = tier;
            this.bonusHp = bonusHp;
            this.BonusDamage = BonusDamage;
            this.price = price;

        }
    }
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

    public class SwordAndArmor
    {
        public string name;
        public string type;
        public int damage;
        public float atkSpeed;
        public int armor;
        public int maxHP;
        public int price;
        public int enchantTier;
        public int id;


        public SwordAndArmor() { }
        public SwordAndArmor(string name,  int damage, float atkSpeed, int price,int enchantTier,int arrayIndex)//Sword
        {
            this.name = name;
            this.type = "Sword";
            this.damage = damage;
            this.atkSpeed = atkSpeed;
            this.price = price;
            this.enchantTier = enchantTier;
            this.armor = 0;
            this.maxHP = 0;
            this.id = arrayIndex; 
        }
        public SwordAndArmor(string name, int armor, int maxHP, int price,int enchantTier, int arrayIndex)//Armor
        {
            this.name = name;
            this.type = "Armor";
            this.damage = 0;
            this.atkSpeed = 0;
            this.enchantTier = enchantTier;
            this.price = price;
            this.armor = armor;
            this.maxHP = maxHP;
            this.id = arrayIndex;
        }
    }
    public static class EquipmentClass
    {
        private static List<Enchants> enchant = new List<Enchants>();
        public static List<Enchants> Enchant
        {
            get
            {
                if (enchant.Count == 0)
                {
                    enchant.Add(new Enchants(0, 0, 0, 0));
                    enchant.Add(new Enchants(1, 10, 10, 50));
                    enchant.Add(new Enchants(2, 20, 20, 75));
                    enchant.Add(new Enchants(3, 25, 30, 100));
                }
                return enchant;
            }
        }

        private static List<SwordAndArmor> swordandArmor = new List<SwordAndArmor>();
        public static List<SwordAndArmor> SwordandArmor
        {
            get {
                if (swordandArmor.Count == 0)
                {
                    //ir buscar a save
                    int enchantTier = 0; //busca da database

                    swordandArmor.Add(new SwordAndArmor("Wooden sword", 1, 1.5f, 0, enchantTier, 0));
                    swordandArmor.Add(new SwordAndArmor("Iron sword",  4, 2f, 20, enchantTier, 1));
                    swordandArmor.Add(new SwordAndArmor("Gold sword", 4, 1.5f, 40, enchantTier, 2));
                    swordandArmor.Add(new SwordAndArmor("Diamond sword", 5, 1f, 100, enchantTier, 3));

                    swordandArmor.Add(new SwordAndArmor("Wooden armor", 0, 0, 0, enchantTier, 4));
                    swordandArmor.Add(new SwordAndArmor("Iron armor", 1, 20, 20, enchantTier, 5));
                    swordandArmor.Add(new SwordAndArmor("Gold armor", 1, 40, 40, enchantTier, 6));
                    swordandArmor.Add(new SwordAndArmor("Diamond armor", 4, 40, 100, enchantTier, 7));
                    
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