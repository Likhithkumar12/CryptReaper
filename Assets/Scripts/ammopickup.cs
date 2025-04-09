using UnityEngine;

public class ammopickup : pickup
{
    [SerializeField] int ammoamount=100;
    protected override void onpickup(Activeweapon activeweapon)
    {
        activeweapon.adjustammo(ammoamount);
        
    }
   
}
