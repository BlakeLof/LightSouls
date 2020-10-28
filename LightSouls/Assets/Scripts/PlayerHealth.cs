using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //implement on key press - take damage 
        //and on key press of another key - heal damage
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        HealthBar.value = currentHealth;
    }

    void healDamage(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        HealthBar.value = currentHealth;
    }
}