using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    const float MAX_DISTANCE = 5f;

    public Transform target; // Specify the player
    public float speed = 1;
    private Vector3 destination;
    private Vector3 projection;

    void Start()
    {
        destination = transform.position;
        projection = target.position;
    }

    void LateUpdate()
    {
        if ((target.position - projection).magnitude > MAX_DISTANCE)
        {
            projection = Vector3.MoveTowards(projection, target.position, Time.deltaTime * speed);
            destination = projection;
            destination.y = transform.position.y;
            transform.position = destination;
        }
    }
}