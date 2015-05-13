using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;

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
            if( Input.GetMouseButtonDown( 0 ) )
            {
                currentWeapon.Fire();
            }
        }
	}
}
