using System.Collections;
using UnityEngine;

/// <summary>
/// Class To Handle The Enemy Attack State
/// </summary>
public class Enemy_Attack_State : Enemy_Base_State
{
    private const string enemy_Attack_Animation_Name = "Standing 1H Magic Attack 01";
    private float bulletSpawnDelay;
    public Enemy_Attack_State(Enemy_State_Machine enemySM, Enemy_Component enemy) : base(nameof(Enemy_Attack_State), enemySM, enemy) { }

    public override void OnEnter()
    {
        base.OnEnter();

        bulletSpawnDelay = 2.0f;
        enemy.character_Health_Component.OnDecrease_Health += Character_Health_Component_OnDecrease_Health;
        enemy.character_Health_Component.OnInsufficient_Health += Character_Health_Component_OnInsufficient_Health;
    }

    private void Character_Health_Component_OnInsufficient_Health()
    {
        base.state_Machine.SetState(base.transitions[nameof(Enemy_Dead_State)]);
    }

    private void Character_Health_Component_OnDecrease_Health()
    {
        base.state_Machine.SetState(base.transitions[nameof(Enemy_Hit_State)]);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        float distance = Vector3.Distance(enemy.transform.position, enemy.target.position);

        if (distance <= enemy.lookRad || distance <= enemy.stopDistance)
            FaceTarget();
        else
            base.state_Machine.SetState(base.transitions[nameof(Enemy_Idle_State)]);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        float distance = Vector3.Distance(enemy.transform.position, enemy.target.position);
        if (distance <= enemy.lookRad)
        {
            if (distance <= enemy.stopDistance)
            {
                if (enemy.ready_To_Attack)
                {
                    enemy.StartCoroutine(AttackPlayer(bulletSpawnDelay, enemy.timeBetweenAttacks));
                }

                enemy.rigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
            else
                base.state_Machine.SetState(base.transitions[nameof(Enemy_Move_State)]);
        }
        else
            base.state_Machine.SetState(base.transitions[nameof(Enemy_Idle_State)]);
    }

    private void FaceTarget()
    {
        enemy.transform.LookAt(enemy.target.position);
    }

    private IEnumerator AttackPlayer(float bulletSpawnDelay, float AttackCooldown)
    {
        enemy.ready_To_Attack = false;
        PlayAttackAnim();
        yield return new WaitForSeconds(bulletSpawnDelay);
        Spawn_Bullet();
        yield return new WaitForSeconds(AttackCooldown);
        enemy.ready_To_Attack = true;
    }

    public void PlayAttackAnim()
    {
        enemy.anim.Play(enemy_Attack_Animation_Name);
    }

    public override void OnExit()
    {
        base.OnExit();
        enemy.character_Health_Component.OnDecrease_Health -= Character_Health_Component_OnDecrease_Health;
        enemy.character_Health_Component.OnInsufficient_Health -= Character_Health_Component_OnInsufficient_Health;
    }

    public void Spawn_Bullet()
    {
        GameObject bullet = GameObject.Instantiate(enemy.bulletPrefab, enemy.bulletSpawn.position, enemy.transform.rotation);
        Bullet_Controller bulletScript = bullet.GetComponent<Bullet_Controller>();
        bulletScript.Fire();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}
