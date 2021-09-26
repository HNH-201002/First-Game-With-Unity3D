using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    [SerializeField] public float force = 10.0f;

    bool isground = false;
    Rigidbody r2;
    public ParticleSystem jumpParticle;
    AudioSource audioSource;
    public AudioClip jumpAudio;
    public ParticleSystem deadParticle;
    // Start is called before the first frame update
    void Start()
    {
        r2 = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted) 
        {
            Jump();
            Move();
        }
        if (transform.position.y <= -12.0f)
        {
            GameManager.instance.OverGame();
            deadParticle.Play();
        }
    }
    void Move()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
       
    }
    void Jump()
    {
        
        if (Input.GetMouseButton(0))
        {
            if (isground) 
            {
                r2.AddForce(Vector3.up * force, ForceMode.Impulse);
                isground = false;
                Invoke("jumpParticlePlay",0.75f);
                audioSource.PlayOneShot(jumpAudio);
            }    
        }
    }
    void jumpParticlePlay()
    {
        jumpParticle.Play();
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {       
            isground = true;    
        }
    }
}
