using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {
            Destroy(gameObject);
        }
    }
}
