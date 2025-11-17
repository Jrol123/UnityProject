using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class HealthBarController : MonoBehaviour
{
    // Ссылка на скрипт Health вашего персонажа
    [SerializeField] private Health playerHealth;
    private UIDocument m_UIDocument;
    private ProgressBar m_HealthBar;
    private VisualElement m_PoisonIcon;

    private void Awake()
    {
        m_UIDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        m_HealthBar = m_UIDocument.rootVisualElement.Q<ProgressBar>("HealthBar");
        m_PoisonIcon = m_UIDocument.rootVisualElement.Q<VisualElement>("PoisonIcon");

        if (playerHealth != null)
        {
            // Подписываемся на событие изменения здоровья
            playerHealth.OnHealthChanged += UpdateHealthBar;
            playerHealth.OnPoisonChanged += UpdatePoisonHealthBar;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            // Отписываемся от события при отключении объекта
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }

    // Метод, который обновляет значение ProgressBar
    private void UpdateHealthBar(int currHealth)
    {
        // Умножаем на 100, так как ProgressBar по умолчанию работает с диапазоном 0-100
        m_HealthBar.value = currHealth;

        // Можно также обновлять текст, если он есть (например, "75/100")
        m_HealthBar.title = $"{currHealth} / {playerHealth.maxHealth}";
    }

    private void UpdatePoisonHealthBar(int currentHealth, int futureHealth, int remaining_ticks)
    {
        UpdateHealthBar(currentHealth);
        if (remaining_ticks > 0)
        {
            m_PoisonIcon.visible = true;
        }
        else
        {
            m_PoisonIcon.visible = false;
        }
    }
}