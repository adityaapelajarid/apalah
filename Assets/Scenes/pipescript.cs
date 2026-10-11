using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15f;
    void Start()
    {
        // Optionally, you can add some randomization to the obstacle's position or size here
    }

    void Update()
    {
        // Move the obstacle to the left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // If the timer reaches the death time, destroy the obstacle
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
        
    }
}
