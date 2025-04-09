using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzlelash;
    [SerializeField] LayerMask layrs;
    CinemachineImpulseSource impulseSource;

    void Awake()
    {
     impulseSource=GetComponent<CinemachineImpulseSource>();   
    }
    public   void shoot(WeaponSO weaponso)
    {
        muzzlelash.Play();
        impulseSource.GenerateImpulse();
        
            RaycastHit Hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out Hit,Mathf.Infinity,layrs,QueryTriggerInteraction.Ignore))
            {
            Instantiate(weaponso.Hit_VFX,Hit.point,Quaternion.identity);
            EnemyHealth enemyHealth=Hit.collider.GetComponentInParent<EnemyHealth>();
            if(enemyHealth){
            enemyHealth.takedamage(weaponso.damage);
            }
            
           // Debug.Log(Hit.collider.name);
            
            }

        
    }
}
