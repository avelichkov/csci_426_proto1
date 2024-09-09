using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTarget : MonoBehaviour
{


    // Start is called before the first frame update
    public void Initialize(Vector2 pos)
    {
        transform.position = pos;
        var emission = GetComponent<ParticleSystem>().emission;
        emission.enabled = true;
        GetComponent<ParticleSystem>().Play();

        FindAnyObjectByType<AudioManager>().Play("explosion");
    }
}
