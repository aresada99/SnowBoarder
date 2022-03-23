using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishParticle;
    [SerializeField] AudioSource finish_sound;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().DisableMovement();
            finish_sound.Play();
            finishParticle.Play();
            Invoke("RestartScene", delayTime);            
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene("Level1");
    }

}
