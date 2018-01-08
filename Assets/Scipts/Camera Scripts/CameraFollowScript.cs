using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform player;

    public float minX, maxX;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 tmp = transform.position;
            tmp.x = player.position.x;

            if (tmp.x < minX)
            {
                tmp.x = minX;
            }

            if (tmp.x < minX)
            {
                tmp.x = minX;
            }

            transform.position = tmp;
        }

    }
}
