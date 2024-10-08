using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Target : MonoBehaviour
{
    public Shake cam;
    public PlayerMovement player;
    public GameObject ground;
    public ParticleSystem collisionParticles;
    public Rigidbody2D rg2d;

    public DummyTarget dummyTarget;
    public bool once = true;
    private bool hasCollided = false;
    
    // Start is called before the first frame update
    public void Update()
    {
        if (IsColliding() && !hasCollided)
        {
            StartCoroutine(Explode());
            hasCollided = true;
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
        Shot();
        cam.ShakeScreen();
        dummyTarget.Initialize(transform.position);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        RestartGame();
    }

    private bool IsColliding()
    {
        Collider2D colA = GetComponent<Collider2D>();
        Collider2D colB = player.GetComponent<PolygonCollider2D>();
        Collider2D colC = ground.GetComponent<Collider2D>();
        return colA.IsTouching(colB) || colA.IsTouching(colC);
    }

    public void RestartGame()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        FindObjectOfType<AudioManager>().pitch = 0.75f;
        // Reload the current scene by its name or build index
        SceneManager.LoadScene(currentScene.name);
    }
}