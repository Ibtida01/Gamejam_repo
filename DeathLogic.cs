using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaughtFire : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource DeathSound;
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D FirePlace)
    {
        if(FirePlace.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Caught on fire!!!");
            Die();
        }
    }
    void Die()
    {
        rb.bodyType=RigidbodyType2D.Static;
        //Debug.Log("DEATH");
        DeathSound.Play();
        anim.SetTrigger("Death");
        Invoke("RestartLevel",2f);
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
