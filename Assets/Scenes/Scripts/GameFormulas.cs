using Elements;
using UnityEngine;

public static class GameFormulas
{
    // Restituisce true se attackElement è uguale alla weaknes del defender
    public static bool HasElementAdvantage(DAMAGE_TYPE attackElement, Hero defender)
    {
        return attackElement == defender.Weakness;
    }

    // Restituisce true se attackElement è uguale alla resistance del defender
    public static bool HasElementDisadvantage(DAMAGE_TYPE attackElement, Hero defender)
    {
        return attackElement == defender.Resistance;
    }

    // Sfrutta le funzioni precedenti e restituisce 1.5f se ha vantaggio, 0.5f se ha svantaggio, 1.0f altrimenti
    public static float EvaluateElementalModifier(DAMAGE_TYPE attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
            return 1.5f;
        else if (HasElementDisadvantage(attackElement, defender))
            return 0.5f;
        else
            return 1.0f;
    }

    // Restituisce true se l'attacco ha colpito, false altrimenti
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.GetAim() - defender.GetEva();
        if (Random.Range(0, 100) > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        return true;
    }

    //Calcola il danno inflitto da un attaccante a un difensore
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        // Calcolo stats di attaccante e difensore 
        Stats attackerStats = Stats.Sum(attacker.BaseStats, attacker.Weapon.BonusStats);
        Stats defenderStats = Stats.Sum(defender.BaseStats, defender.Weapon.BonusStats);

        int baseDmg;
        float elementalModifier;
        float finalDmg;

        // Calcolo danno in base al tipo di attacco
        switch (attacker.Weapon.DmgType)
        {
            // In caso di attacco fisico e magico
            case Weapon.DAMAGE_TYPE.PHYSICAL:
            case Weapon.DAMAGE_TYPE.MAGICAL:

                // Calcolo danno base in base al tipo di attacco
                baseDmg = attackerStats.GetAtk() -
                          (attacker.Weapon.DmgType == Weapon.DAMAGE_TYPE.PHYSICAL
                                                      ? defenderStats.GetDef()   // Attacco fisico
                                                      : defenderStats.GetRes()); // Attacco magico

                // Calcolo modificatore elementale
                elementalModifier = EvaluateElementalModifier(attacker.Weapon.Elem, defender);
                finalDmg = baseDmg * elementalModifier;

                // Controllo se l'attacco è un crit
                if (IsCrit(attackerStats.GetCrt()))
                    finalDmg *= 2;
                break;

            default:
                return -1;
        }
        // controllo se il danno è negativo, per evitare che il nemico si curi
        if (finalDmg < 0)
        {
            finalDmg = 0;
        }

        return Mathf.FloorToInt(finalDmg);
    }


    // Restituisce true se l'attacco è un critico, false altrimenti
    public static bool IsCrit(int critValue)
    {
        if (critValue > Random.Range(0, 100))
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }

}