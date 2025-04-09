using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab;
    public int damage=1;
    public float firerate=0.5f;
    public  GameObject Hit_VFX;
    public  bool Isautomatic=false;
    public bool canZoom=false;
    public float zoomamout=10f;

     public int magazinesize=12;
    public float zoomrotationspeed=.3f;
    
    
}
