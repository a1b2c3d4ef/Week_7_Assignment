using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(menuName = "Player Stat")]
public class Stat_script : ScriptableObject
{
    public float currentHp = 5;
    public int coinCount = 0;

    public void ResetAll()
    {
        coinCount = 0;
        currentHp = 5;
    }
}
