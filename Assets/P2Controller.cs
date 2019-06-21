using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : BasePlayer
{
    public AudioClip[] list;
    public AudioSource sound;

    private float speed = 5f;
    private int jumpNum = 0;
    private bool facingRight = false;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
        if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCrouching = true;
            anim.SetInteger("condition", 1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouching = false;
            anim.SetInteger("condition", 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (facingRight == true)
            {
                GameObject a = Instantiate(arrow, pos, new Quaternion(0, 0, 0, 0));
                a.tag = "RedArrow";
                sound.clip = list[4];
                sound.Play();
            }
            if (facingRight == false)
            {
                GameObject a = Instantiate(arrow, pos, new Quaternion(0, 180, 0, 0));
                a.tag = "RedArrow";
                sound.clip = list[4];
                sound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (facingRight == true)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x + 0.2f, pos.y, pos.z), new Quaternion(0, 180, 0, 0));
                s.tag = "RedSword";
                sound.clip = list[3];
                sound.Play();
            }
            if (facingRight == false)
            {
                GameObject s = Instantiate(sword, new Vector3(pos.x + 0.2f, pos.y, pos.z), Quaternion.identity);
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
