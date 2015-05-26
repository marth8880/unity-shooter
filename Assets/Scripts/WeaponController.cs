using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;
    int currentWeaponInt = 1;



	// Use this for initialization
	void Start ()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (currentWeapon)
        {
            if( Input.GetKeyDown( "1" ))
            {
                if( currentWeaponInt == 1 )
                {
                    currentWeaponInt = 2;
                }
                else
                {
                    currentWeaponInt = 1;
                }
            }
            if( Input.GetMouseButtonDown( 0 ) )
            {
                currentWeapon.Fire();
            }
        }
	}
}
