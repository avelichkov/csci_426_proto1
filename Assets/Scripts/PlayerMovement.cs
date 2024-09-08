using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        //rb2d.velocity = new Vector2(horizontalInput * speed, 0);
        rb2d.MovePosition((Vector2)transform.position + (horizontalInput * speed * Time.deltaTime * new Vector2(1,0)));
        //transform.Translate(direction * speed * Time.deltaTime);
    }
}
