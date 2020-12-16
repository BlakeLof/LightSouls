using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS{
public class PlayerStats : CharacterStats
{
  
    public float coolDownTimer;

    public HealthBar healthbar;

//    AnimatorHandler animatorHandler;

//    private void Awake()
//    {
//        animatorHandler = GetComponentInChildren<AnimatorHandler>();
//    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
            coolDownTimer = 0;
        if (Input.GetKeyDown(KeyCode.Q) && coolDownTimer == 0)
            DrinkFlask();
            
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth > 0)
            currentHealth = 0;
        healthbar.SetCurrentHealth(currentHealth);
        if(currentHealth == 0)
        {
            currentHealth = 0;
<<<<<<< Updated upstream
        //   AnimatorHandler.PlayerTargetAnimation("Unarmed-Death1", true);
        }
        // AnimatorHandler.PlayerTargetAnimation("Damage_Animation", true);
=======
<<<<<<< HEAD
         // AnimatorHandler.PlayerTargetAnimation("Unarmed-Death1", true);
        }
       // AnimatorHandler.PlayerTargetAnimation("Damage_Animation", true);
=======
        //   AnimatorHandler.PlayerTargetAnimation("Unarmed-Death1", true);
        }
        // AnimatorHandler.PlayerTargetAnimation("Damage_Animation", true);
>>>>>>> e048c9852b16d39cf6fffc42c0355d23e3a74e37
>>>>>>> Stashed changes
        
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthbar.SetCurrentHealth(currentHealth);
    }
    public void DrinkFlask()
    {
        Heal(25);
        coolDownTimer = 8;
    }
}
}
