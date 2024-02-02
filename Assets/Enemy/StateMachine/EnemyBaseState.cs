using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly EnemyGroundData groundData;
    

    protected Vector3 lastKnownPlayerPosition;

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
        // 플레이어 위치가 변경되었을 때만 계산
        if (stateMachine.Target.transform.position != lastKnownPlayerPosition)
        {
            lastKnownPlayerPosition = stateMachine.Target.transform.position;
            return (lastKnownPlayerPosition - stateMachine.Enemy.transform.position).normalized;
        }
        return (lastKnownPlayerPosition - stateMachine.Enemy.transform.position).normalized;
    }

    protected void Rotate(Vector3 direction)
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

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animator.IsInTransition(0) && stateInfo.IsTag(tag))
        {
            return animator.GetNextAnimatorStateInfo(0).normalizedTime;
        }
        return stateInfo.IsTag(tag) ? stateInfo.normalizedTime : 0f;
    }

    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
        bool isInChaseRange = playerDistanceSqr <= stateMachine.Enemy.Data.PlayerChasingRange * stateMachine.Enemy.Data.PlayerChasingRange;

        // 로깅 추가
        Debug.Log($"IsInChaseRange: {isInChaseRange}, Distance: {playerDistanceSqr}, ChaseRange: {stateMachine.Enemy.Data.PlayerChasingRange * stateMachine.Enemy.Data.PlayerChasingRange}");

        return isInChaseRange;
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
        bool isInAttackRange = playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange;

        // 로깅 추가
        Debug.Log($"IsInAttackRange: {isInAttackRange}, Distance: {playerDistanceSqr}, AttackRange: {stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange}");

        return isInAttackRange;
    }

}
