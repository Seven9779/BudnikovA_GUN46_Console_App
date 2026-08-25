public class Unit
{
    private float health;
    public string Name { get; }
    public int Damage { get; }
    public float Armor { get; }
    public float Health
    {
        get
        {
            return health;
        }
    }


    public Unit() : this("Unknown Unit") { }

    public Unit(string name)
    {
        Name = name;
        Damage = 5;
        Armor = 0.6f;

    }

    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }

    public bool SetDamage(float value)
    {
        health = health - value * Armor;

        if (health <= 0) return true;
        else return false;
    }
}
