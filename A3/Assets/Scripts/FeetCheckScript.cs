using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheckScript : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerScript>().onPlatform = true;
        }
    }

  
    void Update()
    {
        
    }
}
