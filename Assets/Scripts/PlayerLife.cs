using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool dead = false;
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource fall;

    private void Update()
    {
        if (transform.position.y < -2f && !dead) {
            fall.Play();
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // if the player is "collided" to the enemy
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            // we make the player the child of the platform
            hurt.Play();
            Die();
        }
    }

    void Die()
    {
        // Invoke creates a delay on calling the function basically
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
