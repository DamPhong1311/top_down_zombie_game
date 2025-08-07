using UnityEngine;

public class AttackWithMelee : AttackBase
{

    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private Transform player;
    protected override bool CheckAttackInput()
    {
        float distance = Vector3.Distance(player.position, attackPoint.position);
        return distance <= attackRange;
    }

    protected override void PerformAttack()
    {
        Vector3 direction = (player.position - attackPoint.position).normalized;
        Vector3 spawnPos = attackPoint.position + direction * 1f;

        Transform meleeTransform = MeleeSpawner.Instance.SpawnByName(MeleeSpawner.meleeSword1, spawnPos, Quaternion.identity).transform;
        bool isFacingRight = transform.parent.rotation.eulerAngles.y == 0f;

        if (!isFacingRight)
        {
            // Lật vết chém theo trục Y
            Vector3 scale = meleeTransform.localScale;
            scale.y = -Mathf.Abs(scale.y);
            meleeTransform.localScale = scale;
        }
        else
        {
            // Đảm bảo scale y dương khi quay phải
            Vector3 scale = meleeTransform.localScale;
            scale.y = Mathf.Abs(scale.y);
            meleeTransform.localScale = scale;
        }

        SetDirection(direction, meleeTransform);

        Rigidbody bulletRb = meleeTransform.GetComponent<Rigidbody>();
        bulletRb.gameObject.SetActive(true);

    }

    protected void SetDirection(Vector3 direction, Transform obj)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        obj.rotation = Quaternion.Euler(0, 180, angle);
    }
}
