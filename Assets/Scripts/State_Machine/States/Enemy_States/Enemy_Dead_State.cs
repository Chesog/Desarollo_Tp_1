using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Dead_State : Enemy_Base_State
{
    private float destroyTimer;
    private float destroyTime;

    public Enemy_Dead_State(Enemy_State_Machine enemySM, Enemy_Component enemy) : base(nameof(Enemy_Dead_State), enemySM, enemy) { }

    public override void OnEnter()
    {
        base.OnEnter();
        PlayDeathAnimation();
        DestroyEnemy();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    private void DestroyEnemy()
    {

        destroyTimer += Time.deltaTime;
        if (destroyTimer >= destroyTime)
        {
            GameObject.Destroy(enemy.gameObject);
        }
    }

    public void PlayDeathAnimation() 
    {
         enemy.anim.Play("Standing React Death Backward");
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}
