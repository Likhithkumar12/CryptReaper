using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     [SerializeField] int starthealth=3;
     [SerializeField] Transform weaponcamera;
     [SerializeField] CinemachineVirtualCamera cameraa;
     [SerializeField] Image[] Shieldbars;
     [SerializeField] GameObject gameover;
   
    private  int currenthealthhh=0;
    void Awake()
    {
     currenthealthhh=starthealth; 
     adjustshieldui();  
    }
    public void Takedamage(int amount)
    {
        
        currenthealthhh-=amount;
        Debug.Log("current health"+currenthealthhh);
        adjustshieldui();
        Debug.Log("damage taken"+amount);
        if(currenthealthhh<=0)
        {
            weaponcamera.parent=null;
            Destroy(this.gameObject);
            gameover.SetActive(true);
            cameraa.Priority=20;
            Debug.Log("Player is dead");

        }
    }
    public void adjustshieldui()
    {
        for(int i=0;i<Shieldbars.Length;i++)
        {
            if(i<currenthealthhh)
            {
                Shieldbars[i].gameObject.SetActive(true);
                //Debug.Log(i+"is active");
            }
            else{
                Shieldbars[i].gameObject.SetActive(false);
               // Debug.Log(i+"is inactive");

            }
            
        }
    }
}   
