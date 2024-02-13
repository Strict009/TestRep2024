using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public int damageAmount = 2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyHealth(-damageAmount);
        }
    }
}
