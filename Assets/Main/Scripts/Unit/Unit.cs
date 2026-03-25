using UnityEngine;

public class Unit : MonoBehaviour
{

    [Header("Unit - 참조")]
    [SerializeField] protected Rigidbody2D rb;

    [Header("Unit - 스탯")]
    [SerializeField] protected float MaxHp;

    [Header("Unit - 유닛 설정")]
    [SerializeField] protected float Gravity;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float lifeTime;

    protected float Hp;
    protected float Atk;

    protected bool isDead;
    protected float lifeTime_Timer;

    private void Awake()
    {
        rb.gravityScale = Gravity;
        Hp = MaxHp;
    }

    private void Update()
    {
        DeadCheck();
    }

    private void DeadCheck()
    {
        if (isDead)
        {
            lifeTime_Timer += Time.deltaTime;

            if (lifeTime <= lifeTime_Timer)
            {
                Die();
            }
        }
    }

    public void Move(Vector2 direction, float speed)
    {
        direction = direction.normalized;
        rb.linearVelocityX = direction.x * speed;
    }

    public void Jump(float jumpForce)
    {
        rb.linearVelocityY = jumpForce;
    }

    public void Attack(Unit[] Target, float Damage, bool Single = true)
    {
        if (Single)
        {
            Target[0].TakeDamage(Damage);
        }
        else
        {
            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].TakeDamage(Damage);
            }
        }

    }

    public void TakeDamage(float Damage)
    {
        Hp -= Damage;

        if (Hp <= 0)
        {
            isDead = true;
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
