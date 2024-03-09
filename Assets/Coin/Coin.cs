using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Stat_script stat;
    private void OnTriggerEnter(Collider other)
    {
        stat.coinCount++;
        scoreText.text = stat.coinCount.ToString();
        Destroy(this.gameObject);
    }
}
