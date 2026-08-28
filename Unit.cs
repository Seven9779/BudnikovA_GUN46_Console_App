using Intervals;

namespace Units 
{
    public class Unit
    {
        private const float DefaultArmor = 0.6f;
        private const float DefaultHealth = 100f;

        private float health;
        public string Name { get; }
        public Interval Damage { get; }
        public float Armor { get; }
        public float Health => health;
        


        public Unit() : this("Unknown Unit",0,10) { }

        public Unit(string name) 
        {
            Name = name;
            Armor = DefaultArmor;
            health = DefaultHealth;
       
        }

        public Unit(string name, int minDamage, int maxDamage) : this(name)
        {
            Damage = new Interval(minDamage, maxDamage);
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            if(value < 0) 
            {
                value = 0;
            }
            health = Math.Max(0f, health - value * Armor);

            return health <= 0;
        }
    }

}
