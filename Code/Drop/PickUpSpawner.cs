using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    //initialize setting
    [SerializeField] private GameObject coin, heart, stamina;

    //drop the pickup item after the destructible object is destroy
    public void DropItems()
    {
        int random = Random.Range(1, 5);

        if (random == 1)
        {
            int goldAmount = Random.Range(1, 4);

            for (int i = 0; i < goldAmount; i++)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }
        }

        if (random == 2)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }

        if (random == 3)
        {
            Instantiate(stamina, transform.position, Quaternion.identity);
        }
    }
}
