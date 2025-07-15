using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [Header("Hitboxes")]
    [SerializeField] private GameObject attackArea1;
    [SerializeField] private GameObject attackAreaHeavy;

    [Header("Combo")]
    [SerializeField] private float comboResetTime = 1f;

    private Animator animator;
    private int comboStep = 0;
    private float comboTimer = 0f;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        attackArea1.SetActive(false);
        attackAreaHeavy.SetActive(false);
    }

    private void Update()
    {
        if (comboStep > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0f)
                ResetCombo();
        }

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    TryAttack();
        //}
    }

    public void TryAttack()
    {
        if (isAttacking) return;

        comboStep++;
        comboStep = Mathf.Clamp(comboStep, 1, 3);

        animator.SetInteger("comboStep", comboStep);
        isAttacking = true;
        comboTimer = comboResetTime;
    }

    public void EnableAttackHitbox()
    {
        if (comboStep == 1 || comboStep == 3)
        {
            attackArea1.SetActive(true);
        }
        else if (comboStep == 2)
        {
            attackAreaHeavy.SetActive(true);
        }
    }

    public void DisableAttackHitbox()
    {
        attackArea1.SetActive(false);
        attackAreaHeavy.SetActive(false);
    }

    public void EndAttack()
    {
        isAttacking = false;

        if (comboStep >= 3)
        {
            ResetCombo();
        }
    }

    private void ResetCombo()
    {
        comboStep = 0;
        animator.SetInteger("comboStep", 0);
        isAttacking = false;
        DisableAttackHitbox();
    }
}
