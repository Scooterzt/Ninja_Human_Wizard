using System.Security.Cryptography;
using System;

namespace Human
{
    class Program
    {
        public class Human{
            public string Name;
            public int Strength;
            public int Intelligence;
            public int Dexterity;
            private int health;
            public int Health{
                get {return health;}
                set {health = value;}
            }
            public Human(string name){ // human constracor
                Name = name;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                health = 100;
            }
            public Human(string name, int strength, int intelligence, int dexterity, int health1){ //also human constractor with more atribute 
                Name = name;
                Strength = strength;
                Intelligence = intelligence;
                Dexterity = dexterity;
                health = health1;
            }
            public virtual int Attack(Human target){ //method for atack
                int dmg = Strength*3;
                target.health -= dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.health;
            }
        }
        public class Wizard : Human{
            public Wizard(String name) : base(name) {
                Intelligence = 25;
                Health = 50;
            }
            public override int Attack(Human target){
                base.Attack(target);
                int damage = Strength*5;
                target.Intelligence -= damage;
                Console.WriteLine($"{Name} also take your intelligence down by {damage} points");
                this.Health += damage;
                return target.Intelligence; 
            }
            public int Heal(Human target){
                target.Health += Intelligence*10;
                return target.Health;
            }

        }
        public class Ninja : Human{
            public Ninja(String name) : base(name){
                Dexterity = 150;
            }
            public override int Attack(Human target){
                base.Attack(target);
                int damage = Strength*5;
                target.Dexterity -= damage;
                Console.WriteLine($"{Name} also take your dexterity down by {damage} points");
                Random rand = new Random();
                int chance = rand.Next(1,6);
                if(chance == 1){
                    target.Health -= 10;
                }
                return target.Dexterity;
            }
            public void Steal(Human target){
                target.Health -= 5;
                this.Health +=5;
                Console.WriteLine($"{Name} steal 5 points of health from {target}");
            }
        }
        public class Samurai : Human{
            public Samurai(String name) : base(name){
                Health = 200;
            }
            public override int Attack(Human target){
                if(target.Health < 50){
                    target.Health = 0;
                    Console.WriteLine("{}") 
                }
                else{
                base.Attack(target);
                }
                return target.Health;
            }
            public void Meditate(){
                this.Health = 100;
                Console.WriteLine($"{Name} now back to full health level!");
            }

        }
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Human roman = new Human("Roman");
            Human lee = new Human("lee");
            Wizard bob = new Wizard("Bob");
            Wizard frank = new Wizard("Frank");
            Ninja alex = new Ninja("Alex");
            Samurai cat = new Samurai("KOT");
            roman.Attack(lee);
            Human lendon = new Human("Lendon", 5,7,5,90);
            roman.Attack(lendon);
            Console.WriteLine($"Lendon health: {lendon.Health}");
            Console.WriteLine(lee.Health);
            lendon.Attack(roman);
            Console.WriteLine($"Roman health: {roman.Health}");
            bob.Attack(frank);
            frank.Attack(roman);
            bob.Attack(lee);
            alex.Attack(roman);
            Console.WriteLine($"Roman dexterity is: {roman.Dexterity}");
            cat.Meditate();
            cat.Attack(roman);
            frank.Heal(roman);
            lee.Attack(cat);
            alex.Attack(frank);
        }
    }
}
