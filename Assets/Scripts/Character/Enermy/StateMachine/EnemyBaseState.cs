using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyGroundData groundData;
    

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
    public virtual void TakeDamage(int damage)
    {

    }

    protected bool HasParameter(Animator animator, int hash)
    {
        foreach (var param in animator.parameters)
        {
            if (param.nameHash == hash) return true;
        }
        return false;
    }

    protected void StartAnimation(int hash)
    {
        if (HasParameter(stateMachine.Enemy.Animator, hash))
        {
            stateMachine.Enemy.Animator.SetBool(hash, true);
        }
    }

    protected void StopAnimation(int hash)
    {
        if (HasParameter(stateMachine.Enemy.Animator, hash))
        {
            stateMachine.Enemy.Animator.SetBool(hash, false);
        }
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
        // 지면에 닿아 있지 않을 경우 중력 적용
        if (!stateMachine.Enemy.Controller.isGrounded)
        {
            stateMachine.Enemy.ForceReceiver.AddForce(Physics.gravity);
        }

        // 중력 영향을 받는 이동력 계산
        Vector3 movement = direction * movementSpeed + stateMachine.Enemy.ForceReceiver.Movement;
        movement.y += stateMachine.Enemy.ForceReceiver.Movement.y; // 중력 값 적용
        stateMachine.Enemy.Controller.Move(movement * Time.deltaTime);
    }

    protected void ForceMove()
    {
        stateMachine.Enemy.Controller.Move(stateMachine.Enemy.ForceReceiver.Movement * Time.deltaTime);
    }

    private Vector3 GetMovementDirection()
    {
        // �÷��̾� ��ġ�� ����Ǿ��� ���� ���
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
            direction.y = 0; // ���̸� ������� �ʰ� ȸ���ϵ��� ����
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
        float distance = Vector3.Distance(stateMachine.Target.transform.position, stateMachine.Enemy.transform.position);
        return distance <= stateMachine.Enemy.Data.PlayerChasingRange;
    }

    protected bool IsInAttackRange()
    {
        float distance = Vector3.Distance(stateMachine.Target.transform.position, stateMachine.Enemy.transform.position);
        return distance <= stateMachine.Enemy.Data.AttackRange;
    }

}
