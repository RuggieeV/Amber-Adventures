using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Transition : MonoBehaviour
{

    public string SceneName;
    public int EndSpawnPoint;
    public static int CurrentSpawnIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSpawnIndex = EndSpawnPoint;
            SceneManager.LoadScene(SceneName);

        }
    }

}
