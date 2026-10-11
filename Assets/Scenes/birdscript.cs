using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public Logicscript logic;
    public bool birdAlive = true;
    public GameObject cetakanPeluru;
    public float kecepatanLempar = 10f;
    public float  waktuCooldown = 1.5f;
    private float waktuBisaNembak = 0f;


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

        if (Input.GetMouseButtonDown(0) && Time.time >= waktuBisaNembak)
        {
            GetComponent<AudioSource>().Play();
            waktuBisaNembak = Time.time + waktuCooldown;
            Vector3 posisiMaju = transform.position + new Vector3(2f, 0, 0);
            GameObject peluruBaru = Instantiate(cetakanPeluru, posisiMaju, cetakanPeluru.transform.rotation);
            peluruBaru.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(kecepatanLempar, 0);
            Destroy(peluruBaru, 2f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }
}