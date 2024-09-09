using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem collisionParticles;
    public Rigidbody2D rg2d;
    public bool once = true;
    
    // Start is called before the first frame update
    public void Update()
    {
        Shot();
        once = true;
        
    }
    public void Shot()
    {
        Vector3 CurrentVelocity = rg2d.velocity;

        Debug.Log("I was shot");
        if (CurrentVelocity.y > 0 && once){
            var emission = collisionParticles.emission;
            var dur = collisionParticles.main.duration;

            emission.enabled = true;
            collisionParticles.Play();
            once = false;      
        }
    }

}
