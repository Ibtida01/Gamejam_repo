using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollector : MonoBehaviour
{
    private int score=0;//different fruits contribute different increment to score
    [SerializeField] private UnityEngine.UI.Text scoretxt;
    [SerializeField] private AudioSource collectFruitaudio;
    private void OnTriggerEnter2D(Collider2D fruit) 
    {
        if(fruit.gameObject.CompareTag("Banana"))
        {
            //UnityEngine.Debug.Log("collision detected!!");
            collectFruitaudio.Play();
            score+=20;
            scoretxt.text="Score:" +score;
            Destroy(fruit.gameObject);
        }

    }
}
