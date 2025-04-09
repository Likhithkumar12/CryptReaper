using UnityEngine;

public class explosion : MonoBehaviour
{
    [SerializeField] float radius=1.5f;
    [SerializeField] int damage=2;
    void Update()
    {
        Explode();
    }
    void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,radius); 
    }
   public  void Explode()
{
    Collider[] collders = Physics.OverlapSphere(transform.position, radius);
    //Debug.Log("Colliders found: " + collders.Length);

    foreach (Collider colliderr in collders)
{
    PlayerHealth playerHealth = colliderr.GetComponent<PlayerHealth>();
    if (playerHealth == null) continue;
    
    playerHealth.Takedamage(damage);
    break;
    //Debug.Log("Player found: " + colliderr.name);
}

}

}
