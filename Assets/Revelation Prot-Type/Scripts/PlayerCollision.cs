using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject spawner;

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {
            transform.position = spawner.transform.position;
        }
    }
}