using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    Rigidbody r2;
    public GameObject[] gem;
    Vector3 pos;
    public void Start()
    {
        pos = transform.position;
        pos.y += 1.0f;
        r2 = GetComponent<Rigidbody>();
        InvokeRepeating("SpawnGem",2,4);
    }
 
    void Fall()
    {
        r2.isKinematic = false;
        Destroy(gameObject, 1.0f);
    }
    void SpawnGem()
    {
        int rand = Random.Range(0,gem.Length + 15);
        if (rand < gem.Length)
        {
            GameObject gemObject = Instantiate(gem[rand], pos, gem[rand].transform.rotation);
            gemObject.transform.SetParent(gameObject.transform);
        }
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            Invoke("Fall",0.4f);
        }
    }
}
