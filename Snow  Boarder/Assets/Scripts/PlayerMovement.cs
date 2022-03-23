using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torque = 3f;
    SurfaceEffector2D surfaceEffector2D;
    float boostSpeed = 20f;
    float baseSpeed = 15f;
    [SerializeField] ParticleSystem snowboardparticle;
    bool canMove = true;
    
     
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }


    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        snowboardparticle.Stop();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            snowboardparticle.Play();
        }    
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque*Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque*Time.deltaTime);
        }
    }

    void RespondToBoost()
    {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

}
