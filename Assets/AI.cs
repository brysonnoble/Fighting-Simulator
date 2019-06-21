using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : BasePlayer
{

    public AudioClip[] list;
    public AudioSource sound;

    private float speed = 5f;
    private int jumpNum = 0;
    private bool isGrounded = true;
    private bool facingRight = false;

    public GameObject p1;
    public Vector3 target;
    public Vector3 pos;
    public Rigidbody2D rb;
    public GameObject arrow;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        //movement
        if (p1 == null && FindObjectOfType<P1Controller>() != null)
        {
            p1 = FindObjectOfType<P1Controller>().gameObject;
        }
        if (p1 != null)
        {
            target = p1.GetComponent<Transform>().transform.position;
            if (target.x > transform.position.x)
            {
                if (facingRight == false)
                {
                    transform.Rotate(0, 180, 0, Space.World);
                    facingRight = true;
                }
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (target.x < transform.position.x)
            {
                if (facingRight == true)
                {
                    transform.Rotate(0, 180, 0, Space.World);
                    facingRight = false;
                }
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (target.y - 0.5f > transform.position.y)
            {
                if (jumpNum < 2)
                {
                    if (isGrounded == true)
                    {
                        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                        jumpNum += 1;
                        if (jumpNum == 1)
                        {
                            sound.clip = list[1];
                            sound.Play();
                        }
                        else
                        {
                            sound.clip = list[2];
                            sound.Play();
                        }
                    }
                    if (isGrounded == false)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, 0);
                        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                        jumpNum += 1;
                        if (jumpNum == 1)
                        {
                            sound.clip = list[1];
                            sound.Play();
                        }
                        else
                        {
                            sound.clip = list[2];
                            sound.Play();
                        }
                    }
                }
            }
        }
        print(Vector3.Distance(target, pos));
        //attack
        if (Vector3.Distance(target, pos) < 2)
        {
            print("attakc");
            if (facingRight == true)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x + 0.2f, pos.y, pos.z), new Quaternion(0, 180, 0, 0));
                s.tag = "RedSword";
                sound.clip = list[3];
                sound.Play();
            }
            if (facingRight == false)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x - 0.2f, pos.y, pos.z), Quaternion.identity);
                s.tag = "RedSword";
                sound.clip = list[3];
                sound.Play();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        jumpNum = 0;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BlueArrow")
        {
            health -= Random.Range(3f, 7f);
            print("p2:" + health);
            sound.clip = list[0];
            sound.Play();
        }
        if (col.gameObject.tag == "BlueSword")
        {
            health -= Random.Range(7f, 13f);
            print("p2:" + health);
            sound.clip = list[0];
            sound.Play();
        }
    }

}
