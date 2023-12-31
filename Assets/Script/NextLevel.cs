using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public bool isActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && isActive)
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
