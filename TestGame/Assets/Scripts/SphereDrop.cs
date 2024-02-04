using UnityEngine;

public class SphereDrop : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
    private bool isFrozen = true;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFrozen)
            {
                
                UnfreezeAndDrop();
            }
            else
            {
                
                Freeze();
            }
        }
    }


    void Freeze()
    {

        GetComponent<Rigidbody>().isKinematic = true;
        isFrozen = true;
    }

    void UnfreezeAndDrop()
    {
        if (isFrozen)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            isFrozen = false;
        }
    }

   
}
