using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public void Initialize(Vector2 pos)
    {
        transform.position = pos;
    }
}
