using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");
    private const float TransitionDuration = 0.1f;
    public AudioSource audioSource;
    public AudioClip blockingSound;
    public float volume = 0.5f;

    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine){}
   

    public override void Enter()
    {
        stateMachine.PlayRandomSound(stateMachine.EnemyAttackSounds, stateMachine.EnemyAttackVolume);
        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockBack);

        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
       
    }

    public override void Tick(float deltaTime)
    {
        if(GetNormalizedTime(stateMachine.Animator, "Attack") >= 1)
        {
            stateMachine.SwitchState(new EnemyChasingstate(stateMachine));
        }

        FacePlayer();
        
    }

     public override void Exit()
    {
       
    }
}
