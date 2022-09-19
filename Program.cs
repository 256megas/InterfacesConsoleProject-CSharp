using System;

namespace InterfacesConsoleProject
{
    class Program
    {
        interface Item
        {
            string name { get; set; }
            int goldValue { get; set; }

            void equip();
            void sell();
        }

        interface ItemDamageable{
            int durabillity { get; set; }

            void takeDamage(int _dmg);
        }

        interface ItemPartOfQuest
        {
            void turnIn();
        }

        class Sword : Item, ItemDamageable, ItemPartOfQuest
        {
            public string name { get; set; }
            public int goldValue { get; set; }
            public int durabillity { get; set; }

            public Sword (string _name)
            {
                name = _name;
                goldValue = 100;
                durabillity = 100;
            }

            public void equip() {
                Console.WriteLine(name +" equipped");
            }
            public void sell()
            {
                Console.WriteLine(name + " sold for " + goldValue + " imaginary dollars");
            }
            public void takeDamage(int dmg)
            {
                durabillity -= dmg;
                Console.WriteLine(name + " now has " + durabillity + " of durability");
            }

            public void turnIn()
            {
                Console.WriteLine(name + " turned in.");
            }


        }

        class Axe : Item, ItemDamageable
        {
            public string name { get; set; }
            public int goldValue { get; set; }
            public int durabillity { get; set; }

            public Axe(string _name)
            {
                name = _name;
                goldValue = 100;
                durabillity = 100;
            }

            public void equip()
            {
                Console.WriteLine(name + " equipped");
            }
            public void sell()
            {
                Console.WriteLine(name + " sold for " + goldValue + " imaginary dollars");
            }
            public void takeDamage(int dmg)
            {
                durabillity -= dmg;
                Console.WriteLine(name + " now has " + durabillity + " of durability");
            }


        }

        static void Main(string[] args)
        {
            Sword sword = new Sword("Sword of Destiny");
            sword.equip();
            sword.takeDamage(30);
            sword.turnIn();

            Console.WriteLine();
            
            Axe axe = new Axe("Fury Axe");
            axe.equip();
            axe.takeDamage(10);

            Console.WriteLine();

            //Create an inventory

            Item[] inventory = new Item[2];
            inventory[0] = sword;
            inventory[1] = axe;


            foreach (Item item in inventory)
            {
                ItemPartOfQuest questItem = item as ItemPartOfQuest;
                if (questItem != null)
                {
                    questItem.turnIn();
                }
            }

            Console.ReadKey();
        }
    }
}
