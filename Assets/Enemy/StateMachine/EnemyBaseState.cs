using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly EnemyGroundData groundData;

    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine = enemyStateMachine;
        groundData = stateMachine.Enemy.Data.EnemyGroundData;
    }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }
    public virtual void Update()
    {
        Move();
    }
    public virtual void PhysicsUpdate()
    {

    }

    protected bool HasParameter(Animator animator, int hash)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.nameHash == hash)
                return true;
        }
        return false;
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, false);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        Rotate(movementDirection);
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        Vector3 movement = direction * movementSpeed + stateMachine.Enemy.ForceReceiver.Movement;
        movement.y = 0; // y축 이동 제한
        stateMachine.Enemy.Controller.Move(movement * Time.deltaTime);
    }

    protected void ForceMove()
    {
        stateMachine.Enemy.Controller.Move(stateMachine.Enemy.ForceReceiver.Movement * Time.deltaTime);
    }

    private Vector3 GetMovementDirection()
    {
        return (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
    }

    //private void Move(Vector3 direction)
    //{
    //    float movementSpeed = GetMovementSpeed();
    //    stateMachine.Enemy.Controller.Move(((direction * movementSpeed)+stateMachine.Enemy.ForceReceiver.Movement) * Time.deltaTime);
    //}

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.y = 0; // 높이를 고려하지 않고 회전하도록 설정
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected float GetNormalizedTime(Animator animator,string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);
        
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }

        else if (animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

    protected bool IsInChaseRange()
    {
        //if (stateMachine.Target.IsDead) { return false; }

        float PlayerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;

        return PlayerDistanceSqr <= stateMachine.Enemy.Data.PlayerChasingRange * stateMachine.Enemy.Data.PlayerChasingRange;
    }
}
