using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float reloadTime;
    public float forceAmount;
    public Transform tip;
    public Target target;

    public Rigidbody2D targetrb2d;
    private float timer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        timer = reloadTime;
        targetrb2d = target.GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        //rb2d.velocity = new Vector2(horizontalInput * speed, 0);
        //rb2d.MovePosition((Vector2)transform.position + (horizontalInput * speed * Time.deltaTime * new Vector2(1,0)));
        
        transform.Translate(horizontalInput * new Vector2(1,0) * speed * Time.deltaTime);

        // Check for shot
        if (Input.GetKeyDown(KeyCode.Space))// && timer <= 0)
        {
            Debug.Log("shoot");
            Shoot();
            timer = reloadTime;
        }
        timer -= Time.deltaTime;
    }

    private void Shoot()
    {
        //get angle
        Vector2 playerToTarget = target.transform.position - tip.position;
        float angle = Vector3.Angle(this.transform.position, playerToTarget) - 90;
        targetrb2d.velocity = new Vector2(0f,0f);
        target.Shot();
        targetrb2d.AddForce(playerToTarget.normalized * forceAmount,ForceMode2D.Impulse);
        Debug.Log("Angle: " + angle);
    }
}
