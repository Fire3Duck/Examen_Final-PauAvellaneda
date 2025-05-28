using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        else if(other.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");
            
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();

        }


        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estoy muerto");

            gameManager.GameOver();
        }  
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
