using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdsc : MonoBehaviour
{
    
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public Logicscript logic;
    public bool birdAlive = true;


// start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicscript>();
    }

// update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }
}