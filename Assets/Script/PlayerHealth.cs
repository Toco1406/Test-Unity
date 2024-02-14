using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float invulnerableDelta= 0.15f;
    public float invulnerableDuration= 3;
    public int currentLifePoints;
    public int maxLifePoints; 
    public bool isInvulnerable=false;

    
    public HealthBar healthBar;

    public SpriteRenderer sr;

    public VoidEventChannel OnPlayerDeath;
   
    
   
    private void Start()
    {
     currentLifePoints = maxLifePoints;
     healthBar.SetMaxHealth(maxLifePoints);
 
    }

    public void Hurt(int damage)
    {
        if (isInvulnerable)
        {
            return ;
        }

        currentLifePoints = currentLifePoints - damage;
        healthBar.SetHealth(currentLifePoints);
        
        float amount = ((float)currentLifePoints / (float)maxLifePoints);
        
        if(currentLifePoints <= 0)
        {
            Die();
        }
        else {
               StartCoroutine(Invulnerable());

        }
        

    }

    private void Die ()
    {
        OnPlayerDeath?.Raise();
        transform.Rotate(0,0,45f);
    }

    

    public IEnumerator Invulnerable()
    {
        isInvulnerable = true;

        for (float i = 0; i < invulnerableDuration; i += invulnerableDelta) {
            if(sr.color.a == 1)
            {
               sr.color = new Color(1f, 1f, 1f, 0f); //Color.clear

            }
            else
            {
                sr.color = Color.white;
            }

            yield return new WaitForSeconds (invulnerableDelta);
        }

        sr.color = Color.white;
        isInvulnerable = false;
    }
    
}
   