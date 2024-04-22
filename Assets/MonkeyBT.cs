using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class MonkeyBT : BehaviorTree.Tree
{
    // public static float speed = 2f;
    // public static float fovRange = 6f;
    public static float attackRange = 10.0f;
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new ThrowDart(transform)
            })
        });


        return root;
    }
}

public class CheckEnemyInAttackRange : Node
{
    private Transform _transform;
    private Animator _animator;


    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }


    public override NodeState Evaluate()
    {
        Debug.Log("?");
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        Transform target = (Transform)t;
        Debug.Log("Distance: " + Vector3.Distance(_transform.position, target.position));
        if (Vector3.Distance(_transform.position, target.position) <= MonkeyBT.attackRange)
        {
            Debug.Log("Kick its butt!");
            _animator.SetBool("IsAttacking", true);
            _animator.SetBool("IsMoving", false);
            state = NodeState.SUCCESS;
            return state;
        }


        state = NodeState.FAILURE;
        return state;
    }


}

public class ThrowDart : Node
{
    private Transform _transform;
    private Animator _animator;

    public ThrowDart(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        state = NodeState.SUCCESS;
        return state;
    }
}