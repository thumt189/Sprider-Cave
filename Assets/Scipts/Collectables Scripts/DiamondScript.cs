using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (DoorScipt.instance != null)
        {
            DoorScipt.instance.collectablesCount++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);

            if (DoorScipt.instance != null)
            {
                DoorScipt.instance.DecrementCollectables();
            }
        }
    }
}
