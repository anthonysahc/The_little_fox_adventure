using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    
    #region Sigleton
    private static playerInventory instanceInventory;
    public static playerInventory InstanceInventory
    {
        get
        {
            if (instanceInventory == null)
                instanceInventory = FindObjectOfType<playerInventory>();
            return instanceInventory;
        }
    }
    #endregion


    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxTotalHealth;
    [SerializeField] GameObject damageSound;

    bool takeDamage = false;
    int gem;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }
    public int Gem {get {return gem; } }
    public bool IsTakeDamage { get { return takeDamage; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        if(damageSound)
        {
            Instantiate(damageSound, transform.position, Quaternion.identity);
        }
        takeDamage = true;
        gameObject.GetComponent<playerController>().RejectDamage();
        StartCoroutine(waitDamge());
        health -= dmg;
        ClampHealth();

        if (health <= 0)
        {
            gameManager.InstanceGame.gameLose();
        }
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    public void AddGem()
    {
        ++gem;
        if (gem >= 25)
        {
            gem = 0;
            AddHealth();
        }
    }

    IEnumerator waitDamge()
    {
        yield return new WaitForSeconds(0.5f);
        takeDamage = false;
        gameObject.GetComponent<playerMovement>().setAnimatorDamage(false);
    }
}
