using UnityEngine;

[System.Serializable]

public struct Stats
{
    [SerializeField] private int Atk;
    [SerializeField] private int Def;
    [SerializeField] private int Res;
    [SerializeField] private int Spd;
    [SerializeField] private int Crt;
    [SerializeField] private int Aim;
    [SerializeField] private int Eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.Atk = atk;
        this.Def = def;
        this.Res = res;
        this.Spd = spd;
        this.Crt = crt;
        this.Aim = aim;
        this.Eva = eva;
    }

    public static Stats Sum(Stats stats1, Stats stats2)
    {
        return new Stats(
            stats1.Atk + stats2.Atk,
            stats1.Def + stats2.Def,
            stats1.Res + stats2.Res,
            stats1.Spd + stats2.Spd,
            stats1.Crt + stats2.Crt,
            stats1.Aim + stats2.Aim,
            stats1.Eva + stats2.Eva
        );
    }

    #region "GetStatsParams"

    // Method to get the Atk Stat
    public int GetAtk() => Atk;

    // Method to get the Def Stat
    public int GetDef() => Def;

    // Method to get the Res Stat
    public int GetRes() => Res;

    // Method to get the Spd Stat
    public int GetSpd() => Spd;

    // Method to get the Crt Stat
    public int GetCrt() => Crt;

    // Method to get the Aim Stat
    public int GetAim() => Aim;

    // Method to get the Eva Stat
    public int GetEva() => Eva;

    #endregion

}