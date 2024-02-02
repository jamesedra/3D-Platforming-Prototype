using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // if the player is "collided" in the platform
        if (collision.gameObject.name == "Player")
        {
            // we make the player the child of the platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // if the player is NOT "collided" in the platform
        if (collision.gameObject.name == "Player")
        {
            // we remove the player's parent (which is currently the platform)
            collision.gameObject.transform.SetParent(null);
        }
    }
}
