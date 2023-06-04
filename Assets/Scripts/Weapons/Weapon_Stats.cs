using UnityEngine;

public class Weapon_Stats : MonoBehaviour
{
    [SerializeField] private float WeaponDamage;


    //TODO - Fix - Should be native Setter/Getter
    public float GetDamage() 
    {
        return WeaponDamage;
    }

    //TODO - Fix - Should be native Setter/Getter
    public void SetDamage(float newDamage) 
    {
        WeaponDamage = newDamage;
    }
}
