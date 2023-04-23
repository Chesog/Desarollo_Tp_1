using UnityEngine;

public class Weapon_Stats : MonoBehaviour
{
    [SerializeField] private float WeaponDamage;


    public float GetDamage() 
    {
        return WeaponDamage;
    }

    public void SetDamage(float newDamage) 
    {
        WeaponDamage = newDamage;
    }
}
