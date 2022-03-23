using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{

    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashSFX;
    bool isDead = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            if (isDead == false)
            {
                FindObjectOfType<PlayerMovement>().DisableMovement();
                crashParticle.Play();
                isDead = true;
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("RestartLevel", delayTime);
            }


            
          
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
