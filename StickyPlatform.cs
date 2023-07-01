using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.CompareTag("PlayerTag")) // compareTag("PlayerTag_Name") we can also accomplish this way but as singleplayer game(1 player per game session)
            //we don't need a tag
            {
                //then we wanna make Player as a child of MovingPlatform1.platform
               Debug.Log("player jumped in!!");
              collision.gameObject.transform.SetParent(transform);//here param transform is the transform component of a stickyplatform
             
             }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerTag"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
