using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : BasePlayer
{

    public AudioClip[] list;
    public AudioSource sound;

    private float speed = 5f;
    private int jumpNum = 0;
    private bool facingRight = true;
    private bool isGrounded = true;
    private bool isCrouching = false;
    private bool isDead = false;

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator anim;
    public GameObject arrow;
    public GameObject sword;

    public Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        pos = transform.position;
        if (Input.GetKeyDown("w"))
        {
            if (jumpNum < 2)
            {
                if(isGrounded == true)
                {
                    rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                    jumpNum += 1;
                    if(jumpNum == 1)
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
                if(isGrounded == false)
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
        if (Input.GetKey("a"))
        {
            if (facingRight == true)
            {
                transform.Rotate(0, 180, 0, Space.World);
                facingRight = false;
            }
            if (isCrouching == false)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-speed / 2 * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            isCrouching = true;
            anim.SetInteger("condition", 1);
            bc.size = new Vector3(4f, 12f);
        }
        if (Input.GetKeyUp("s"))
        {
            isCrouching = false;
            anim.SetInteger("condition", 0);
            bc.size = new Vector3(4f, 13.5f);
        }
        if (Input.GetKey("d"))
        {
            if (facingRight == false)
            {
                transform.Rotate(0, 180, 0, Space.World);
                facingRight = true;
            }
            if (isCrouching == false)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(speed / 2 * Time.deltaTime, 0, 0);
            }
        }
        //attacks
        if (Input.GetKeyDown("q"))
        {
            if (facingRight == true)
            {
                GameObject a = Instantiate(arrow, pos, new Quaternion(0, 0, 0, 0));
                a.tag = "BlueArrow";
                sound.clip = list[4];
                sound.Play();
            }
            if (facingRight == false)
            {
                GameObject a = Instantiate(arrow, pos, new Quaternion(0, 180, 0, 0));
                a.tag = "BlueArrow";
                sound.clip = list[4];
                sound.Play();
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (facingRight == true)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x + 0.2f, pos.y, pos.z), new Quaternion(0, 180, 0, 0));
                s.tag = "BlueSword";
                sound.clip = list[3];
                sound.Play();
            }
            if (facingRight == false)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x - 0.2f, pos.y, pos.z), Quaternion.identity);
                s.tag = "BlueSword";
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
        if (col.gameObject.tag == "RedArrow")
        {
            health -= Random.Range(3f, 7f);
            print("p1:" + health);
            sound.clip = list[0];
            sound.Play();
        }
        if (col.gameObject.tag == "RedSword")
        {
            health -= Random.Range(7f, 13f);
            print("p1:" + health);
            sound.clip = list[0];
            sound.Play();
        }
    }
}