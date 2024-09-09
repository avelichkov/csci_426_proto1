using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float reloadTime;
    public float forceAmount;
    public Transform tip;

    public GameObject hitbox;
    public Target target;

    private Rigidbody2D targetrb2d;
    private float timer;
    private Rigidbody2D rb2d;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = reloadTime;
        targetrb2d = target.GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
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
        if (Input.GetKeyDown(KeyCode.Space) && IsColliding())// && timer <= 0)
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
        if (audioManager.pitch < 2.5f)
        {
            audioManager.Play("note");
            audioManager.pitch += 0.05f;
        }
        else
        {
            audioManager.Play("one up");
        }
        Vector2 playerToTarget = target.transform.position - tip.position;
        float angle = Vector3.Angle(this.transform.position, playerToTarget) - 90;
        targetrb2d.velocity = new Vector2(0f,0f);
        target.Shot();
        targetrb2d.AddForce(ScaledVector(playerToTarget).normalized * forceAmount,ForceMode2D.Impulse);
        Debug.Log("Angle: " + angle);
    }

    //makes upwards twice as strong as left right
    private Vector2 ScaledVector(Vector2 old)
    {
        return new Vector2(old.x,old.y * 4);

    }

    private bool IsColliding()
    {
        Collider2D colA = target.GetComponent<Collider2D>();
        Collider2D colB = hitbox.GetComponent<Collider2D>();
        Debug.Log(colA.IsTouching(colB));
        return colA.IsTouching(colB);
    }
}
