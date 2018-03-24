using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public GameObject GameManager;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);

            GameManager.GetComponent<GameManager>().GameOver();
        }
        
    }
}
