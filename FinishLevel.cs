using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] AudioSource FinishLevelSound;
    private bool TouchedFlagBefore=false;
    private void OnTriggerEnter2D(Collider2D trophy)
    {
        if(trophy.gameObject.name == "Player")
        {
            Debug.Log("done");
            if(TouchedFlagBefore==false)
               { 
                FinishLevelSound.Play();
                TouchedFlagBefore=true;
                Invoke("NextLevel",2f);
               }
        }
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
