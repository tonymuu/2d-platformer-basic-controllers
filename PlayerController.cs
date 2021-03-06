﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Vector2 jump = Vector2.zero;
    public Vector2 move = Vector2.zero;
    public Vector2 friction;
    ScoreCounter scoreCounter = new ScoreCounter();

    private int score = 0;

    public float maxspeed;

    public AudioSource sounds;
    

    float offset;
    bool dead;
    bool isGround = false;
    bool didjump = false;
    //1 is right, 0 is left
    int direction = 2;

    
    float angle = 0;
    Animator myAnimator;
    void Start()
    {
        myAnimator = transform.GetComponentInChildren<Animator>();
        sounds = GetComponent<AudioSource>();
        
        
    }

    void Update()
    {
      
       
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                didjump = true;

            }
       
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
        {

            direction = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
        {
            direction = 1;
        }
        
    }

    void FixedUpdate()
    {
        if (dead)
            return;
            if (didjump)
            {
                

                didjump = false;
                rigidbody2D.AddForce(jump * 10);
                sounds.Play();
                myAnimator.SetTrigger("didjump");

        }
        if (direction == 0 && rigidbody2D.velocity.x > -15)
        {
            rigidbody2D.velocity -= move * Time.deltaTime;
            direction = 2;
        }
        if (direction == 1 && rigidbody2D.velocity.x < 15)
        {
            rigidbody2D.velocity += move * Time.deltaTime;
            direction = 2;
        }

        if (rigidbody2D.velocity.y < -200)
        {
            dead = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead)
        {
            Animator animator = transform.GetComponentInChildren<Animator>();
            animator.SetTrigger("death");
            GameObject bunny = GameObject.FindGameObjectWithTag("Player");
            
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name.Equals("coin"))
        {
            
            score = score + 1;
            scoreCounter.UpdateText(score);
            Destroy(collider.gameObject);
            
        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("ground"))
        {
            

            if (Input.GetKeyDown(KeyCode.F))
            {
                
                Destroy(collision.collider.gameObject);
            }
        }
    }

    public int getScore()
    {
        return score;
    }
}
