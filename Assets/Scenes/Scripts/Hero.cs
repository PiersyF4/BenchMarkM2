using Elements; // Namespace for ELEMENT enum
using UnityEngine;

[System.Serializable]

// Hero class to represent a character in the game
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private DAMAGE_TYPE resistance, weakness;
    [SerializeField] private Weapon weapon;


    // Constructor to initialize the hero with name, health points, base stats, resistance, weakness, and weapon
    public Hero(string name, int hp, Stats baseStats, DAMAGE_TYPE resistance, DAMAGE_TYPE weakness, Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }


    // get and set methods for the fields 

    // Property to represent the name of the hero
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property to represent the health points of the hero
    public int Hp
    {
        get { return hp; }
        set
        {
            if (value > 0)
                hp = value;
            else
                hp = 0;
        }
    }

    // Property to represent the base stats of the hero
    public Stats BaseStats
    {
        get { return baseStats; }
        set { baseStats = value; }
    }

    // Property to represent the resistance of the hero
    public DAMAGE_TYPE Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }

    // Property to represent the weakness of the hero
    public DAMAGE_TYPE Weakness
    {
        get { return weakness; }
        set { weakness = value; }
    }

    // Weapon property to represent the weapon of the hero
    public Weapon Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    #region "GetHeroParams"

    // Method to get the name of the hero
    public string GetName() => name;

    // Method to get the health points of the hero
    public int GetHp() => hp;

    // Method to get the base stats of the hero
    public Stats GetBaseStat() => baseStats;

    // Method to get the resistance of the hero
    public DAMAGE_TYPE GetResistance() => resistance;

    // Method to get the weakness of the hero
    public DAMAGE_TYPE GetWeakness() => weakness;

    // Method to get the weapon of the hero
    public Weapon GetWeapon() => weapon;

    #endregion

    #region "SetHeroParams"

    // Method to set the health points of the hero
    public void SetHp(int hp)
    {
        if (hp > 0)
            this.hp = hp;
        else
            this.hp = 0;
    }

    #endregion

    #region "Functions"

    // Method to add health points to the hero
    public void AddHp(int amount)
    {
        SetHp(hp + amount);
    }

    // Method for the hero to take damage
    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    // Method to check if the hero is alive
    public bool IsAlive()
    {
        if (this.hp > 0)
            return true;
        else
            return false;
    }

    #endregion


}