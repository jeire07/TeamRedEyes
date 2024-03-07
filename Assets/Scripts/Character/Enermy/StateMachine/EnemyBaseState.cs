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
        // 이 메서드는 상태별로 다를 수 있으므로, 상속받은 클래스에서 필요에 따라 오버라이드 해서 사용합니다.
        if (CanMove())
        {
            Move();
        }
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

    public virtual bool CanMove()
    {
        // 기본적으로는 모든 상태에서 이동이 가능하다고 가정합니다.
        return true;
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        Rotate(movementDirection);
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector3 direction)
    {
        // CanMove 체크를 여기서 수행
        if (!CanMove()) return; // 이동 불가능한 상태이면 이동 로직을 실행하지 않음

        float movementSpeed = GetMovementSpeed();
        if (!stateMachine.Enemy.Controller.isGrounded)
        {
            stateMachine.Enemy.ForceReceiver.AddForce(Physics.gravity);
        }

        Vector3 movement = direction * movementSpeed + stateMachine.Enemy.ForceReceiver.Movement;
        movement.y += stateMachine.Enemy.ForceReceiver.Movement.y;
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
        if (!CanMove() || direction == Vector3.zero) return; // 회전 불가능한 상태이거나 방향이 없으면 회전 로직을 실행하지 않음

        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
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
