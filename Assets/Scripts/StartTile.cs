using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        if(player != null )
        player.transform.position = transform.position;
    }

    
}
