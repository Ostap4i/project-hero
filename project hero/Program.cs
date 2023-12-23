using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace project_hero
{



 
    public enum AttackType
    {
        Physical,
        Magical
    }

    public class Hero
    {

      
       
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int ResistanceToPhysical { get; set; }
        public int ResistanceToMagical { get; set; }
        public double CriticalChance { get; set; }
        public double DodgeChance { get; set; }

        public delegate int AttackDelegate(int damage, AttackType attackType, double criticalChance);

        public virtual int Attack(AttackDelegate attackDelegate, AttackType attackType)
        {
            int damage = attackDelegate(AttackPower, attackType, CriticalChance);
            return damage;
        }

        public virtual void ReceiveDamage(int damage)
        {
            // Логіка отримання урону (застосовується в підкласах)
            Health -= damage;
            Console.WriteLine($"{Name} received {damage} damage. Remaining health: {Health}");
        }

        internal int Attack(AttackDelegate attackDelegate)
        {
            throw new NotImplementedException();
        }
    }

   

    public class Warrior : Hero
    {
        public new string Name = "Warrior";
        public new int Health = 1200;
        public new int AttackPower = 150;
        public new int ResistanceToPhysical = 160;
        public new int ResistanceToMagical = 100;
        public new double CriticalChance = 55;
        public new double DodgeChance = 60;

        private string v1;
        private int v2;
        private int v3;
        private double v4;
        private double v5;
        private double v6;
        private double v7;
        private int v8;

        public Warrior(string v1, int v2, int v3, double v4, double v5, double v6, double v7, int v8)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

        public int Armor { get; set; }

        public override int Attack(AttackDelegate attackDelegate, AttackType attackType)
        {
            int damage = base.Attack(attackDelegate, attackType);
            return attackDelegate(damage + Armor, attackType, CriticalChance);
        }
    }


    public class Mage : Hero
    {
        public new string Name = "Mage";
        public new int Health = 950;
        public new int AttackPower = 150;
        public new int ResistanceToPhysical = 170;
        public new int ResistanceToMagical = 100;
        public new double  CriticalChance = 45;
        public new double DodgeChance = 60;
        public new int attackType = 2;

        private string v1;
        private int v2;
        private int v3;
        private double v4;
        private double v5;
        private double v6;
        private double v7;
        private int v8;

        public Mage(string v1, int v2, int v3, double v4, double v5, double v6, double v7, int v8)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

        public int SpellPower { get; set; }

        public override int Attack(AttackDelegate attackDelegate, AttackType attackType)
        {
            int damage = base.Attack(attackDelegate, attackType);
            return attackDelegate(damage + SpellPower, attackType, CriticalChance);
        }
    }

   

    public class Archer : Hero
    {
        public new string Name = "Archer ";
        public new int Health = 1000;
        public new int AttackPower = 160;
        public new int ResistanceToPhysical = 100;
        public new int ResistanceToMagical = 150;
        public new double CriticalChance = 70;
        public new double DodgeChance = 70;
        public new int attackType = 2;

        private string v1;
        private int v2;
        private int v3;
        private double v4;
        private double v5;
        private double v6;
        private double v7;
        private int v8;

        public Archer(string v1, int v2, int v3, double v4, double v5, double v6, double v7, int v8)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

        public int Precision { get; set; }

        public override int Attack(AttackDelegate attackDelegate, AttackType attackType)
        {
            int damage = base.Attack(attackDelegate, attackType);
            return attackDelegate(damage + Precision, attackType, CriticalChance);
        }
    }

    public class BattleSystem
    {
        private List<Hero> heroes;

        public BattleSystem(List<Hero> selectedHeroes)
        {
            heroes = selectedHeroes;
        }

        public void StartBattle()
        {
            // Логіка походового бою
            // Наприклад, кожен герой робить хід по черзі

            foreach (var hero in heroes)
            {
                // Логіка вибору стратегії атаки або захисту
                AttackType attackType = GetAttackStrategy();

                // Логіка вибору бонусів та спеціальних атак
                ApplyBonuses(hero);

                // Логіка бою
                foreach (var enemy in heroes)
                {
                    if (enemy != hero)
                    {
                        int damage = hero.Attack(DealDamage, attackType);
                        enemy.ReceiveDamage(damage);
                    }
                }
            }

            // Вивід статистики бою
            DisplayBattleStatistics();
        }

        private int DealDamage(int damage, AttackType attackType, double criticalChance)
        {
            // Логіка обчислення збитків від атаки
            // Можливо, врахування резистенції, шансу на критичний удар тощо.
            return damage;
        }

        private AttackType GetAttackStrategy()
        {
            // Логіка вибору стратегії атаки гравцем
            // Наприклад, випадковим чином або за допомогою користувацького введення
            return AttackType.Physical;

        }

        private void ApplyBonuses(Hero hero)
        {
            // Логіка застосування бонусів під час бою
            // Наприклад, відновлення здоров'я або особлива атака раз на кілька ходів
        }

        private void DisplayBattleStatistics()
        {
            // Логіка виведення статистики бою
        }
    }

    class Program
    {
        public static object Сonsole { get; private set; }

        static void Main()
        {
            // Ініціалізація героїв та створення системи бою
            List<Hero> selectedHeroes = new List<Hero>
        {
           
               
            // Додайте інших героїв за необхідності
        };

            BattleSystem battleSystem = new BattleSystem(selectedHeroes);

            // Запуск бою
            battleSystem.StartBattle();

            Warrior warrior = new Warrior("Warrior", 100, 20, 0.8, 0.2, 0.1, 0.2, 15);
            Mage mage = new Mage("Mage", 80, 15, 0.2, 0.8, 0.2, 0.1, 50);
            Archer archer = new Archer("Archer", 90, 18, 0.6, 0.4, 0.15, 0.3, 10);

            // Масив героїв
            Hero[] heroes = { warrior, mage, archer };

            // Делегат для обчислення здоров'я після атаки
            Hero.AttackDelegate attackDelegate = (damage, attackType, criticalChance) =>
            {
                Random random = new Random();
                int actualDamage = damage;

                // Логіка обчислення збитків та здоров'я
                //if ( "Magical")
                //{
                //    actualDamage = (int)(actualDamage * (1 - mage.ResistanceToPhysical));
                //}
                //else
                //{
                //    actualDamage = (int)(actualDamage * (1 - mage.ResistanceToMagical));
                //}

                //if (random.NextDouble() < criticalChance)
                //{
                //    actualDamage = (int)(actualDamage * 1.5);
                //    Console.WriteLine("Критичний удар!");
                //}

                return actualDamage;
            };

            // Меню
            while (true)
            {



 Console.WriteLine($@"              __ __  ____ ____    _____ __  __ ____ ", Console.ForegroundColor = ConsoleColor.Red);
 Console.WriteLine($@"/\ \/\ \/\  _`\ /\  _`\ /\  __`\/\ \/\ \/\  _`\ ");
 Console.WriteLine($@"\ \ \_\ \ \ \L\_\ \ \L\ \ \ \/\ \ \ \ \ \ \,\L\_\");
 Console.WriteLine($@"\ \  _  \ \  _\L\ \ ,  /\ \ \ \ \ \ \ \ \/ _\__ \"); 
 Console.WriteLine($@" \ \ \ \ \ \ \L\ \ \ \\ \\ \ \_\ \ \ \_\ \/\ \L\ \",Console.ForegroundColor = ConsoleColor.DarkBlue);
 Console.WriteLine($@"\ \_\ \_\ \____ /\ \_\ \_\ \_____\ \_____\ `\____\");
 Console.WriteLine($@"   \/ _ /\/ _ /\/ ___ /  \/ _ /\/ /\/ _____ /\/ _____ /\/ _____ /");


                Console.WriteLine("\tFIGHTERS:", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine("\t     HEROS:", Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine("\t\t1. Archer", Console.ForegroundColor = ConsoleColor.Blue);
                Console.WriteLine("\t\t2. Mage");
                Console.WriteLine("\t\t3. Warrior");

                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n");



                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Розпочати бій
                        StartBattle(heroes, attackDelegate);
                        break;

                    case "2":
                        // Вийти з програми
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void StartBattle(Hero[] heroes, Hero.AttackDelegate attackDelegate)
        {
            Console.WriteLine("Start battle!");

            while (true)
            {
                foreach (var hero in heroes)
                {
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine($"{hero.Name} виграв бій!");
                        return;
                    }

                    Console.WriteLine($"Хід героя: {hero.Name}");
                    Console.WriteLine("Оберіть дію:");
                    Console.WriteLine("1. Здійснити атаку");
                    Console.WriteLine("2. Пропустити хід");
                    string actionChoice = Console.ReadLine();

                    switch (actionChoice)
                    {
                        case "1":
                            int damage = hero.Attack(attackDelegate);
                            Console.WriteLine($"{hero.Name} завдав {damage} урону.");
                            break;

                        case "2":
                            Console.WriteLine($"{hero.Name} пропустив хід.");
                            break;

                        default:
                            Console.WriteLine("Please, try again");
                            break;
                    }
                }
            }
        }
    }
}
    
    

