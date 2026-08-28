namespace Units 
{
    public class Unit
    {
        private const int DefaultDamage = 5;
        private const float DefaultArmor = 0.6f;
        private const float DefaultHealth = 100f;

        private float health;
        public string Name { get; }
        public int Damage { get; }
        public float Armor { get; }
        public float Health => health;
        


        public Unit() : this("Unknown Unit") { }

        public Unit(string name)
        {
            Name = name;
            Damage = DefaultDamage;
            Armor = DefaultArmor;
            health = DefaultHealth;
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
