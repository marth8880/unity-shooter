﻿using UnityEngine;
using System.Collections;

public class Pistol : Weapon
{
    public override void Fire()
    {

        RaycastHit hitInfo = new RaycastHit();
        if( Physics.Raycast( ray, out hitInfo, range ) )
        {
            //You sunk my battleship!
            Health health = hitInfo.collider.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage( damage );
            }
            hitInfo.rigidbody.AddExplosionForce( 100f, hitInfo.point, 1f );
        }
        else
        {
            Quaternion rotation = Quaternion.FromToRotation( Vector3.forward, hitInfo.normal );
            VFXManager.Instance.Spawn( "Dust", hitInfo.point, rotation );
        }

        VFXManager.Instance.Spawn( "MuzzleFlash", muzzleTransform.position, muzzleTransform.rotation );
    }
}
