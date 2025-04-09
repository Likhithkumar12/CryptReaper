using UnityEngine;

public abstract class pickup : MonoBehaviour
{
     const string player="Player";
     [SerializeField] float rotationspeed=500f;
    void Update()
    {
        transform.Rotate(0f,rotationspeed*Time.deltaTime,0f);
    }
    void OnTriggerEnter(Collider other)
    {
    
        if(other.CompareTag(player))
        {
            Activeweapon activeweapon=other.GetComponentInChildren<Activeweapon>();
            onpickup(activeweapon);
            Destroy(this.gameObject);  

        }
        
    }
    protected abstract void onpickup(Activeweapon activeweapon);
}
