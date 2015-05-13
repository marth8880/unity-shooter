using UnityEngine;
using System.Collections;

public class DestroyParticleEmitterOnFinish : MonoBehaviour
{
    ParticleSystem ps;
	// Use this for initialization
	void Start ()
    {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    if (!ps.IsAlive())
        {
            Destroy( gameObject );
        }
	}
}
