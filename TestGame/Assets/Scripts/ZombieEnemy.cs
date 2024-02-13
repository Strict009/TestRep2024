using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    public int damageAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyHealth(-damageAmount);
        }
    }
}
