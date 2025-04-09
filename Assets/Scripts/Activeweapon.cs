using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;
public class Activeweapon : MonoBehaviour
{
   
    StarterAssetsInputs starterAssetsInputs;
     Animator animator;
     [SerializeField] WeaponSO startingweaponSO;
     WeaponSO currentweaponsSO;
     [SerializeField] TMP_Text ammoText;
     [SerializeField] Camera weaponcamera;
    [SerializeField] CinemachineVirtualCamera cameraFOV;
    [SerializeField] GameObject zoomimage;
   
    FirstPersonController firstPersonController;
    Weapon currentweapon;
    float timesincelastshoot=0f;
    float defaultFOV;
    float defaultzoomrotationspeed;
    int currentammo;
    void Awake()
    {
        starterAssetsInputs=GetComponentInParent<StarterAssetsInputs>();
        animator=GetComponent<Animator>();
        defaultFOV=cameraFOV.m_Lens.FieldOfView;
       
        firstPersonController=GetComponentInParent<FirstPersonController>();
          defaultzoomrotationspeed=firstPersonController.RotationSpeed;
    }
    void Start()
    {
        switchweapon(startingweaponSO);
        adjustammo(currentweaponsSO.magazinesize);
    }
    void Update()
    {
        handleshoot();
        timesincelastshoot+=Time.deltaTime;
        handlezoom();
    
    }
    public void adjustammo(int amount)
    {
        currentammo+=amount ;
        if(currentammo>currentweaponsSO.magazinesize)
        {
            currentammo=currentweaponsSO.magazinesize;
        }
        ammoText.text=currentammo.ToString("D2");

    }
    public void switchweapon(WeaponSO currentweaponSO)
{
    if (currentweapon)
    {
        Destroy(currentweapon.gameObject);
    }
    Weapon newweapon = Instantiate(currentweaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
    
    currentweapon = newweapon;
    this.currentweaponsSO = currentweaponSO;
    adjustammo(currentweaponsSO.magazinesize);
    
}
      void handleshoot()
    {
        if(!starterAssetsInputs.shoot ||currentammo<=0) return;
        if(timesincelastshoot>=currentweaponsSO.firerate)
        {
            animator.Play("Shoot",0,0f);
            currentweapon.shoot(currentweaponsSO);
            timesincelastshoot=0f;
            adjustammo(-1);
        }
        if(!currentweaponsSO.Isautomatic)
        {
         starterAssetsInputs.ShootInput(false);
        }
    }
    void handlezoom()
    {
        
        if(!currentweaponsSO.canZoom)return;
        if(starterAssetsInputs.zoom)
        {
           cameraFOV.m_Lens.FieldOfView=currentweaponsSO.zoomamout;
           zoomimage.SetActive(true);
           weaponcamera.fieldOfView=currentweaponsSO.zoomamout;
           firstPersonController.changeRotationspeed(currentweaponsSO.zoomrotationspeed);

        }
        else
        {
             cameraFOV.m_Lens.FieldOfView=defaultFOV;
             zoomimage.SetActive(false);
             weaponcamera.fieldOfView=defaultFOV;
             firstPersonController.changeRotationspeed(defaultzoomrotationspeed);
            
        }


    }
}