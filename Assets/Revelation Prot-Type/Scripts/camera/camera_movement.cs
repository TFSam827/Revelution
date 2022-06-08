using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    const float MAX_DISTANCE = 2.5f;
    public float MAX_HEIGHT = 1f;
    public float MIN_HEIGHT = -1f;

    public GameObject target; // Specify the player
    public float speed = 0;
    private Vector3 destination;
    private Vector3 projection;

    void Start()
    {
        destination = transform.position;
        projection = target.transform.position;
    }

    void Update()
    {
        if ((target.transform.position - projection).magnitude > MAX_DISTANCE)
        {
            projection = Vector3.MoveTowards(projection, target.transform.position, Time.deltaTime * speed);
            destination = projection;
            destination.y = transform.position.y;
            destination.z = transform.position.z;
            transform.position = destination;
        }
        if ((target.transform.position - projection).y > MAX_HEIGHT || (target.transform.position - projection).y < MIN_HEIGHT)
        {
            projection = Vector3.MoveTowards(projection, target.transform.position, Time.deltaTime * speed);
            destination = projection;
            destination.x = transform.position.x;
            destination.z = transform.position.z;
            transform.position = destination;
        }
        if (target.activeSelf == false)
        {
            projection = Vector3.MoveTowards(projection, target.transform.position, Time.deltaTime * speed);
            destination = projection;
            destination.y = target.transform.position.y;
            destination.z = transform.position.z;
            transform.position = destination;
        }
    }
}