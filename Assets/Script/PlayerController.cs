using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Planet;
    public Image[] UIhealth;
    public AudioClip audioHit;
    public AudioClip audioUpgrade;

    public float moveSpeed;
    public float maxHealth = 5;

    float movement;
    int health = 5;
    bool isDie = false;

    AudioSource audioSource;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    void Start()
    {
        moveSpeed = 350f;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(health == 0)
        {
            if (!isDie)
            {
                Die();
            }
            return;
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(Planet.transform.position, Vector3.back, movement * Time.fixedDeltaTime * moveSpeed);
        if (health == 0)
        {
            if (!isDie)
            {
                Die();
            }
            return;
        }
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            OnInvincible();
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);
            Die();
            gameManager.GameOver();
        }
    }

    void OnInvincible()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffInvincible", 1.5f);
        circleCollider.enabled = false;
    }
    
    void OffInvincible()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        circleCollider.enabled = true;
    }

    void Die()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        isDie = true;
        gameManager.GameOver();
    }  

    void Move()
    {
        float key = 0;
        movement = Input.GetAxisRaw("Horizontal");
        
        if (movement > 0) key = 0.15f;
        if (movement < 0) key = -0.15f;
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 0.15f, 1);
        }

        // animation
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "hit":
                audioSource.clip = audioHit;
                break;
            case "upgrade":
                audioSource.clip = audioUpgrade;
                break;
        }
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gameManager.NextMoon();
            PlaySound("upgrade");
        }
        if(collision.gameObject.tag == "Enemy")
        {
            HealthDown();
            PlaySound("hit");
        }
    }
}
