using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Target : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject ground;
    public ParticleSystem collisionParticles;
    public Rigidbody2D rg2d;
    public bool once = true;
    
    // Start is called before the first frame update
    public void Update()
    {
        if (IsColliding())
        {
            StartCoroutine(Explode());
        }
        
    }
    public void Shot()
    {
        Vector3 CurrentVelocity = rg2d.velocity;

        Debug.Log("I was shot");
        var emission = collisionParticles.emission;
        var dur = collisionParticles.main.duration;

        emission.enabled = true;
        collisionParticles.Play();     
    }

    public IEnumerator Explode()
    {
        //Do particle effects
        yield return new WaitForSeconds(0f);
        RestartGame();
    }
    private bool IsColliding()
    {
        Collider2D colA = GetComponent<Collider2D>();
        Collider2D colB = player.GetComponent<PolygonCollider2D>();
        Collider2D colC = ground.GetComponent<Collider2D>();
        Debug.Log(colA.IsTouching(colB));
        return colA.IsTouching(colB);
    }

    public void RestartGame()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene by its name or build index
        SceneManager.LoadScene(currentScene.name);
    }
}