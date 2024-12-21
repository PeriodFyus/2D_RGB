using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EntityFX))]
[RequireComponent(typeof(ItemDrop))] 
public class Enemy : Entity
{
    [SerializeField]
    protected LayerMask whatIsPlayer;

    [Header("Move info")]
    public float moveSpeed = 1.5f;
    public float idleTime = 2f;
    public float battleTime = 4f;
    private float defaultSpeed;

    [Header("Stunned info")]
    public float stunDuration = 1;
    public Vector2 stunDirection = new Vector2(3, 5);
    protected bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    [Header("Attack info")]
    public float agroDistance = 2;
    public float attackDistance = 1.5f;
    public float attackCooldown = 0.4f;
    public float minAttackCooldown = 0.35f;
    public float maxAttackCooldown = 0.45f;
    [HideInInspector] public float lastTimeAttacked;
    public EnemyStateMachine stateMachine { get; private set; }
    public EntityFX fx { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        fx = GetComponent<EntityFX>();
        defaultSpeed = moveSpeed;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public override void SlowEntityBy(float _slowPercentage, float _slowDuration)
    {
        moveSpeed = moveSpeed * (1 - _slowPercentage);
        anim.speed = anim.speed * (1 - _slowPercentage);

        Invoke("ReturnDefaultSpeed", _slowDuration);
    }

    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();

        moveSpeed = defaultSpeed;
    }

    public virtual void OpenCounterAttackWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeStunned()
    {
        if (canBeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }

    public virtual void FreezeTime(bool _timeFrozen)
    {
        if (_timeFrozen)
        {
            moveSpeed = 0;
            anim.speed = 0;
        }
        else
        {
            moveSpeed = defaultSpeed;
            anim.speed = 1;
        }
    }

    public virtual void FreezeTimeFor(float _seceonds) => StartCoroutine(FreezeTimeCoroutine(_seceonds));

    protected virtual IEnumerator FreezeTimeCoroutine(float _seceonds)
    {
        FreezeTime(true);

        yield return new WaitForSeconds(_seceonds);

        FreezeTime(false);
    }

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual void AnimationSpecialSttackTrigger() 
    {
    }

    public virtual RaycastHit2D IsPlayerDetected()
    {
        float playerDistanceCheck = 5;

        RaycastHit2D playerDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, playerDistanceCheck, whatIsPlayer);

        return playerDetected;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
    }

    public override void Die()
    {
        base.Die();
        counterImage.SetActive(false);
    }
}
