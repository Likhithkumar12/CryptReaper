using UnityEngine;

public class weaponpickup : pickup
{
    [SerializeField] WeaponSO weaponSO;
    protected override void onpickup(Activeweapon activeweapon)
    {
        activeweapon.switchweapon(weaponSO);
    }
}
