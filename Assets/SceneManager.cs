using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{
    [SerializeField] Stat_script stat;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene_GamePlay"))
        {
            if (stat.currentHp <= 0)
                SceneManager.LoadScene("Scene_GameOver");
            else if (stat.coinCount >= 5)
                SceneManager.LoadScene("Scene_Win");
        }
    }
    public void LoadScene(int index)
    { 
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
