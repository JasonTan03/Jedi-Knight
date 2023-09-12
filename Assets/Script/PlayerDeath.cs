using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public void gameOver()
       
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitToDie());
        
    }
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(3/2);
        Time.timeScale = 0f;
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
