using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public float delaySecond = 1;
    EnemyHealth enemyHealth = new EnemyHealth();
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.SetActive(false);

            ModeSelect();

        }
    }

    public void ModeSelect()
    {
        
         StartCoroutine(LoadAfterDelay());
        
    }
   IEnumerator LoadAfterDelay()
    {
            yield return new WaitForSeconds(delaySecond);
         SceneManager.LoadScene("Level 2");

    }

}
