using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState CurrentState;
    public float Speed;
    private Rigidbody2D MyRigidBody;
    private Vector3 Change; // why should this be a vector3?
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = PlayerState.Walk;
        Animator = GetComponent<Animator>();
        MyRigidBody = GetComponent<Rigidbody2D>();
        Animator.SetFloat("MoveX", 0);
        Animator.SetFloat("MoveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButtonDown("_Attack") && CurrentState != PlayerState.Attack)
		{
            StartCoroutine(AttackCoroutine());
		}
        else if (CurrentState == PlayerState.Walk)
		{
            UpdateAnimationAndMove();
		}

		Debug.Log("Change: " + Change);
    }

    private IEnumerator AttackCoroutine()
	{
        Animator.SetBool("Attacking", true);
        CurrentState = PlayerState.Attack;
        yield return null;
        Animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        CurrentState = PlayerState.Walk;
	}

    void UpdateAnimationAndMove()
	{
        if (Change != Vector3.zero)
        {
            MoveCharacter();
            Animator.SetFloat("MoveX", Change.x);
            Animator.SetFloat("MoveY", Change.y);
            Animator.SetBool("Moving", true);
        }
        else
        {
            Animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
	{
        // Change.normalized fixes diagional movement speed
        MyRigidBody.MovePosition(
            transform.position + Change.normalized * Speed * Time.fixedDeltaTime 
        );
	}
}
