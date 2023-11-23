using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerlife : MonoBehaviour
{
  private void OncollisionEenter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
