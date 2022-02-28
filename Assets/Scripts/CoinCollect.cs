using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            Score.coinCount += 1;
            Destroy(gameObject);
            
        }
    }
}
