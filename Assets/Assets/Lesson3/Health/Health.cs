using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int currentHealth;
    private int futureHealth; // Для лечения или ядов (a. k. a. для замедленного действия)
    private int remaining_ticks = 0;
    public System.Action<int> OnHealthChanged;
    public System.Action<int, int, int> OnPoisonChanged;


    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
        // OnPoisonChanged?.Invoke(currentHealth, futureHealth, remaining_ticks);
    }
    

    public void Damaged(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);
    }

    IEnumerator PoisonDamage(DamageType damageType)
    {
        remaining_ticks += damageType.ticks;
        OnPoisonChanged?.Invoke(currentHealth, futureHealth, remaining_ticks);
        while (remaining_ticks > 0)
        {
            remaining_ticks -= 1;
            yield return new WaitForSeconds(damageType.delaySeconds);
            Damaged(damageType.subDamage);
        }
        OnPoisonChanged?.Invoke(currentHealth, futureHealth, remaining_ticks);
    }

    // public void TakeDamagePoison(DamageType damageType)
    // {
        
    //     currentHealth -= damageType.subDamage;
    //     OnPoisonChanged?.Invoke(currentHealth, futureHealth, remaining_ticks);
    // }

    public void TakeDamage(DamageType damageType)
    {
        Damaged(damageType.damage);
        if (damageType.name == "Poison")
        {
            StartCoroutine(PoisonDamage(damageType));
        }
    }
}