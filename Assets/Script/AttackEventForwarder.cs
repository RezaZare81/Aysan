using UnityEngine;

public class AttackEventForwarder : MonoBehaviour
{
    [SerializeField] private PlayerAttacking playerAttackScript;

    public void EndAttack()
    {
        playerAttackScript.EndAttack();
    }

    public void EnableAttackHitbox()
    {
        playerAttackScript.EnableAttackHitbox();
    }

    public void DisableAttackHitbox()
    {
        playerAttackScript.DisableAttackHitbox();
    }
}
