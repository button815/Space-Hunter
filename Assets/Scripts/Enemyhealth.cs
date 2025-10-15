using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health = 3;

    public void Takedamage (int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
