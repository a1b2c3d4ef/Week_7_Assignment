using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] Stat_script stat;
    [SerializeField][Range(0, 3)] private int movingPattern; 
    private float delay = 1;
    private GameObject bombObject, bombExplosion;

    private void Start()
    {
        bombObject = transform.GetChild(0).gameObject;
        bombExplosion = transform.GetChild(1).gameObject;
        GetComponent<Animator>().SetInteger("pattern", movingPattern);
    }
    private void OnTriggerEnter(Collider other)
    {
        stat.currentHp--;
        healthText.text = stat.currentHp.ToString();
        bombObject.SetActive(false);
        bombExplosion.SetActive(true);
        Invoke("DestroyBomb", delay);
    }
    private void DestroyBomb()
    { 
        Destroy(this.gameObject);
    }
}
