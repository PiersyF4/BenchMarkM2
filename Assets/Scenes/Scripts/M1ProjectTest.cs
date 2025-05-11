using Elements;
using System;
using UnityEngine;

[Serializable]

public class M1ProjectTest : MonoBehaviour
{

    [SerializeField] private Hero a;
    [SerializeField] private Hero b;

    // Aggiunto flag per interrompere Update
    private bool isBattleOver = false; 

    void Update()
    {
        // Interrompe l'esecuzione di Update se la battaglia è finita
        if (isBattleOver) return; 

        // Estraggo vincitore del duello  
        Hero winner = GetWinner(a, b);
        if (winner == null)
        {
            // Duello tra i due eroi  
            Battle(a, b);
        }
        else
        {
            Debug.Log("Il vincitore è: " + winner.GetName());

            // Imposta il flag per interrompere Update
            isBattleOver = true;
        }
    }

    private void Battle(Hero a, Hero b)
    {
        // Calcolo velocità totale dell'eroe
        int speedA = GetHeroTotalSpeed(a);
        int speedB = GetHeroTotalSpeed(b);

        Hero firstAttacker, secondAttacker;

        // Determino chi attacca per primo
        if (speedA > speedB)
        {
            firstAttacker = a;
            secondAttacker = b;
        }
        else if (speedA < speedB)
        {
            firstAttacker = b;
            secondAttacker = a;
        }
        else
        {
            // Se la velocità è uguale, scelgo casualmente
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                firstAttacker = a;
                secondAttacker = b;
            }
            else
            {
                firstAttacker = b;
                secondAttacker = a;
            }
        }

        // Esegui l'attacco
        Debug.Log($"{firstAttacker.GetName()} attacca {secondAttacker.GetName()}");
        Attack(firstAttacker, secondAttacker);

        // Controllo se il secondo eroe è vivo per eseguire il contrattacco
        if (secondAttacker.IsAlive())
        {
            Debug.Log($"{secondAttacker.GetName()} contrattacca {firstAttacker.GetName()}");
            Attack(secondAttacker, firstAttacker);
        }
    }

    // Funzione per il check se hero è vivo
    private Hero GetWinner(Hero a, Hero b)
    {
        if (!a.IsAlive()) return b;
        if (!b.IsAlive()) return a;
        return null;
    }

    // Calcolo velocità totale dell'eroe
    private int GetHeroTotalSpeed(Hero hero)
    {
        return hero.BaseStats.GetSpd() + hero.GetWeapon().BonusStats.GetSpd();
    }

    // Funzione per l'attacco
    private void Attack(Hero attacker, Hero defender)
    {
        // Controllo se l'attacco ha colpito
        if (!GameFormulas.HasHit(attacker.BaseStats, defender.BaseStats))
            return;

        // Controllo debolezza e resistenza
        DAMAGE_TYPE attackerDamageType = attacker.GetWeapon().Elem;
        DAMAGE_TYPE defenderWeakness = defender.GetWeakness();
        DAMAGE_TYPE defenderResistance = defender.GetResistance();
        
        if (attackerDamageType == defenderWeakness)
            Debug.Log("WEAKNESS");
        else if (attackerDamageType == defenderResistance)
            Debug.Log("RESIST");

        // Calcolo danno inflitto
        int damage = GameFormulas.CalculateDamage(attacker, defender);
        if (damage > 0)
        {
            Debug.Log("Danno inflitto: " + damage);
            defender.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Attacco inefficace");
        }
    }
}
