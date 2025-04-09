using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class projectile : MonoBehaviour
{
    [SerializeField] float speed=10f;
    [SerializeField] GameObject explosion;
    int damage;
   Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
     public void Init(int damage)
    {
        this.damage=damage;
    }
    void Update()
    {
        rb.linearVelocity=transform.forward*speed;
    
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
        PlayerHealth playerHealth=other.GetComponent<PlayerHealth>();
        playerHealth.Takedamage(damage);
        }
        Destroy(this.gameObject);
        Instantiate(explosion,transform.position,quaternion.identity);
        
        

        
    }
}
