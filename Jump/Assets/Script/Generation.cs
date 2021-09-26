using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public Transform lastForm;
    public GameObject[] platForm;
    public Transform player;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = lastForm.position;
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Spawn()
    {       
        while (true) {
            int rand = Random.Range(0,platForm.Length);
            int randPosX = Random.Range(3,8);
            GameObject platformObject = Instantiate(platForm[rand],lastPos, Quaternion.identity);
            lastPos = new Vector3(platformObject.transform.position.x + randPosX,0,0);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
