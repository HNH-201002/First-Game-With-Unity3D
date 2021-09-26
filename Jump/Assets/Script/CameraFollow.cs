using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 distance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        distance = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > -2)
        {
            followTarget();
        }
    }
    void followTarget()
    {
        Vector3 pos = player.position - distance;
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
