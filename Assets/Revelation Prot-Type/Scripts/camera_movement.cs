using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    const float MAX_DISTANCE = 4f;
    const float MAX_HEIGHT = 2.5f;
    const float MIN_HEIGHT = -2.5f;

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
            destination.z = transform.position.z;
            transform.position = destination;
        }
        if ((target.position - projection).y > MAX_HEIGHT || (target.position - projection).y < MIN_HEIGHT)
        {
            projection = Vector3.MoveTowards(projection, target.position, Time.deltaTime * speed);
            destination = projection;
            destination.x = transform.position.x;
            destination.z = transform.position.z;
            transform.position = destination;
        }
    }
}