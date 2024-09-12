using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMoveable
{

    [field: SerializeField] public float MaxHealth { get; set;} = 100f;
    public float CurrentHealth { get; set;}
    public Rigidbody2D RB { get; set;}
    public bool IsFacingRight { get; set;} = true;

    #region State Machine Variables

    public PlayerStateMachine StateMachine {get;set;}
    public PlayerIdleState IdleState {get;set;}
    public PlayerAttackState AttackState {get;set;}


    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        AttackState = new PlayerAttackState(this, StateMachine);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update() 
    {
        StateMachine.CurrentPlayerState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }
    #region Health / Dmg / Die
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
        
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Movement
    public void Move(Vector2 velocity)
    {
        RB.velocity = velocity;
    }

    public void CheckDirection(Vector2 velocity)
    {
        if(IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    #endregion

    #region Animations

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentPlayerState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        PlayerDamaged,
        PlayFootstepSound
    }




    #endregion




}
