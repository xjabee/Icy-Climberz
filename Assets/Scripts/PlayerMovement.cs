using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   // private float Speed = 1f;
    public float jumpStr = 45f;
    private float jumpMul = 1f;
    public bool IsGrounded = false;
    public Animator animator;
    public GameObject deathpart;
    public GameObject platform;
    private float increment = 4;
    public bool ded = false;
    private bool touched = false;
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       sr = GetComponent<SpriteRenderer>();
       Vector2 InitVelo = rb.velocity;
       InvokeRepeating("spawnPlatforms", 0f, 0.2f);
    }

    // Update is called once per frame

    void Update()
    {
        if(ded)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Replay();
            }
        }
    }
    void FixedUpdate()
    {

        float posX = Input.GetAxis("Horizontal");
        Debug.Log(posX);
        Vector2 movement = new Vector2(posX, 0);
        animator.SetFloat("Speed", Mathf.Abs(posX));
        animator.SetBool("IsJumping", IsGrounded);
        Debug.Log(jumpMul);
        //transform.Translate(posX * Speed * Time.deltaTime, 0, 0);
        rb.AddRelativeForce(movement, ForceMode2D.Impulse);
        
        if (posX > 0)
        {
            sr.flipX = false;
        } else if (posX < 0)
        {
            sr.flipX = true;
        }
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            
            Debug.Log("i jumped");
            rb.AddForce(Vector2.up *  jumpStr * (rb.velocity.magnitude/2), ForceMode2D.Impulse);
            Debug.Log(rb.velocity.magnitude);
        }
        
    }
    private void OnCollisionEnter2D (Collision2D c)
    {
        Vector3 DeathSpawn = new Vector3(0.5f, transform.position.y - 3.5f, -0.8631236f);

        if(c.transform.tag == "Platform")
        {
            IsGrounded = true;
            Instantiate(deathpart, DeathSpawn, Quaternion.identity);
            touched = true;
        }
        if(c.transform.tag == "OoB")
        {
            UIManager.Instance.UIEndscreen(true);
            ded = true;
           // SceneManager.LoadScene(0);
            Debug.Log("U ded bish");
        }
        if(c.transform.tag =="Starting Platform")
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D (Collision2D c)
    {
        if(c.transform.tag == "Platform")
        {
            IsGrounded = false;
                Destroy(c.gameObject, 2);   
            
        }
        if(c.transform.tag =="Starting Platform")
        {
            IsGrounded = false;
        }
    }
    private void destroyPlatform(Collision2D c)
    {
        Destroy(c.gameObject);
    }

    private void spawnPlatforms()
    {
        Vector3 randomPlatform = new Vector3(Random.Range(-2, 4), increment, 0);
        Instantiate(platform, randomPlatform, Quaternion.identity); //makes platform when touched
        increment+=4;
    }

    public void Replay()
    {
        UIManager.Instance.UIEndscreen(false);
        ded = false;
        SceneManager.LoadScene(0);
    }
}

