using System;
using UnityEngine;

[Serializable]
public class GameData
{
    [SerializeField]
    private float playerLife;
    [SerializeField]
    private float playerMaxLife;
    [SerializeField]
    private float playerMana;
    [SerializeField]
    private float playerMaxMana;
    [SerializeField]
    private float playerDamage;
    [SerializeField]
    private float fireBallDamage;
    [SerializeField]
    private float bigAttackDamage;
    

    public float PlayerLife
    { 
        get {return playerLife;}
        set {playerLife = value;}
    }

    public float PlayerMaxLife
    {
        get { return playerMaxLife; }
        set { playerMaxLife = value; }
    }

    public float PlayerMana
    {
        get { return playerMana; }
        set { playerMana = value; }
    }

    public float PlayerMaxMana
    {
        get { return playerMaxMana; }
        set { playerMaxMana = value; }
    }

    public float PlayerDamage
    { 
    
        get{return playerDamage;}
        set {playerDamage = value;}    
    }

    public float FireBallDamage
    {

        get { return fireBallDamage; }
        set { fireBallDamage = value; }
    }

    public float BigAttackDamage
    {

        get { return bigAttackDamage; }
        set { bigAttackDamage = value; }
    }



}
