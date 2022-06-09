using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform spawner;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {
            transform.position = spawner.position;
        } else if (collision.gameObject.tag == "edge")
        {
            transform.position = spawner.position;
        }
    }
}
