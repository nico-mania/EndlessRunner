using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

//yoinked at https://youtu.be/MwvmNyYKgwA
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    public SpawnManager spawnManager;

    private int lane = 1; // 0 = left, 1 = middle, 2 = right
    [SerializeField] private float laneDistance = 8;



    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            lane++;
            if (lane == 3)
                lane = 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lane--;
            if (lane == -1)
                lane = 0;
        }

        Vector3 playerPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0)
        {
            playerPosition += Vector3.left * laneDistance;
        }
        else if (lane == 2)
        {
            playerPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, 10 * Time.deltaTime);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
