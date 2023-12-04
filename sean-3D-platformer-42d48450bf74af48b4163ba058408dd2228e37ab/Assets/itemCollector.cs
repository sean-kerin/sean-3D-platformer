using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text coinsText;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "coins: " + coins;
            
        }
    }
}
