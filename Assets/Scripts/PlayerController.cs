using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid_;
    Animator ani_;
    [SerializeField]
    GameObject gm_;

    Vector3 jumpD = new Vector3(0, 1, 0);
    Vector3 dirr = Vector3.zero;

    [SerializeField]
    float jumpForce = 5.3f;

    int maxJump = 2;
    int currentJump = 0;
    int health = 3;

    bool isJump;
    bool isSuper;

    AudioSource playSound;

    private void Start()
    {
        rigid_ = GetComponent<Rigidbody2D>();
        ani_ = GetComponent<Animator>();
        health = 3;
        //slider_.value = 3;
        playSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJump <2)
                {
                    
                    if (currentJump == 0)
                        ani_.SetTrigger("Jump");
                    else
                        ani_.SetTrigger("Double");
                    currentJump++;
                    rigid_.velocity = jumpD * jumpForce;
                    isJump = true;
                }
            }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!isSuper)
                isSuper = true;
            else
                isSuper = false;
            Debug.Log("Super mode is " + isSuper);
        }
    }


    public void Jump()
    {
        if (currentJump > 0)
        {
            rigid_.velocity = jumpD * jumpForce;

            playSound.Play();
        }
    }

    private void FixedUpdate()
    {
        /*
        if (rigid_.velocity.y < 0)
        {
            currentJump = maxJump;
        }
        */

        if (rigid_.velocity.y > 0)  
        {
            rigid_.gravityScale = 1.0f;
        }
        else
        {
            rigid_.gravityScale = 2.0f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            //ani_.SetBool("Jump", false);
            if (isJump)
            {
                ani_.SetTrigger("Land");
                isJump = false;
                ani_.SetTrigger("Walk");
            }
            currentJump = 0;
        }
        if (collision.gameObject.CompareTag("DeadLand"))
        {
            if (!isSuper)
            {
                Debug.Log("DeadLand");
                gm_.GetComponent<GameManager>().OnDead();
            }
            else
            {
                if (isJump)
                {
                    ani_.SetTrigger("Land");
                    isJump = false;
                    ani_.SetTrigger("Walk");
                }
                currentJump = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Level Clear");
            gm_.GetComponent<GameManager>().LevelClear();
        }
        if (collision.gameObject.CompareTag("Dead") && !isSuper)
        {
            Debug.Log("Dead");
            gm_.GetComponent<GameManager>().OnDead();
        }
    }
}
