using System.Collections;
using UnityEngine;

public class turret : MonoBehaviour
{
   [SerializeField] Transform playertargetpoint;
   [SerializeField] Transform turrethead;
   [SerializeField] Transform projectilespawnpoint;
   PlayerHealth player;
   [SerializeField] GameObject PRojectileprefab;
   [SerializeField] int damage=2;
   [SerializeField]  float waittime=.2f;
   


    void Start()
    {
        player=FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(fireroutine());
    }

    void Update()
    {
        turrethead.LookAt(playertargetpoint);
        
    }
    IEnumerator fireroutine()
    {
        while(player)
        {
             yield return new WaitForSeconds(waittime);
              projectile projectile=Instantiate(PRojectileprefab,projectilespawnpoint.position,Quaternion.identity).GetComponent<projectile>();
              projectile.transform.LookAt(playertargetpoint);
              projectile.Init(damage);

             

        }
      

    }
}
