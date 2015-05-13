using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    public float attackRange;
    public NavMeshAgent agent;

    Animator animator;
    GameObject target;

    enum State
    {
        Idle,
        Chase,
        Attack,
        Damage,
        Dead
    };

    State state;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch(state)
        {
        case State.Idle:
            UpdateIdle();
            break;
        case State.Chase:
            UpdateChase();
            break;
        case State.Attack:
            UpdateAttack();
            break;
        case State.Damage:
            UpdateDamage();
            break;
        case State.Dead:
            UpdateDead();
            break;
        }
        animator.SetBool( "bTargetSpotted", true );
    }

    void OnTriggerEnter(Collider other)
    {
        print( "trigger enter" );
        if( other.CompareTag( "Player" ) )
        {
            print( "player trigger enter" );
            target = other.gameObject;
        }
    }

    void OnTriggerExit( Collider other )
    {
        print( "trigger exit" );
        if( other.CompareTag( "Player" ) )
        {
            print( "player trigger exit" );
            target = null;
        }
    }

    void UpdateIdle()
    {
        if( target != null )
        {
            state = State.Chase;
            animator.SetBool( "bTargetSpotted", true );
        }
    }

    void UpdateChase()
    {
        if( target == null )
        {
            state = State.Idle;
            animator.SetBool( "bTargetSpotted", false );
        }
        else
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if( distance <= attackRange )
            {
                state = State.Attack;
                animator.SetTrigger( "tAttack" );
            }
            else
            {
                print( "chase" );
                agent.SetDestination( target.transform.position );

            }
        }
    }

    void UpdateAttack()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo( 0 );
        if( info.IsName( "Main.Idle" ) )
        {
            state = State.Idle;
        }
    }

    void UpdateDamage()
    {

    }

    void UpdateDead()
    {

    }
}
