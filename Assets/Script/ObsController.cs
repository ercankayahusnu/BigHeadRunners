using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObsController : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerController playerScript;
    private bool hasObstacleUsed;

    
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && hasObstacleUsed == false)
        {
            hasObstacleUsed = true;
            playerScript.TouchedToObstacle();
            Destroy(gameObject);
        }
    }
}
