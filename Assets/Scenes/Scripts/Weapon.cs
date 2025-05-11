using System;
using UnityEngine;

[Serializable]

public class Weapon
{
    // Fields to store weapon properties    
    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private Elements.DAMAGE_TYPE elementType;
    [SerializeField] private Stats bonusStats;

    // Enum to define the type of element
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL,
    }

    public Weapon(string name, DAMAGE_TYPE dmgType, Elements.DAMAGE_TYPE elementType, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elementType = elementType;
        this.bonusStats = bonusStats;
    }

    #region "Get,Set"

    // Property to represent the name of the weapon
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property to represent the damage type of the weapon
    public DAMAGE_TYPE DmgType
    {
        get { return dmgType; }
        set { dmgType = value; }
    }

    // Corrected property to avoid StackOverflowException
    public Elements.DAMAGE_TYPE Elem
    {
        get { return elementType; }
        set { elementType = value; }
    }

    // Property to represent the bonus stats of the weapon
    public Stats BonusStats
    {
        get { return bonusStats; }
        set { bonusStats = value; }
    }

    #endregion
}
