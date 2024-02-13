using UnityEngine;

public class DogEnemy : MonoBehaviour
{
    public int damageAmount = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyHealth(-damageAmount);
        }
    }
}
