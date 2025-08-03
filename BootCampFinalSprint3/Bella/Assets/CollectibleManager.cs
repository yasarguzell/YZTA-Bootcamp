using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [Header("Toplanabilir Nesneler")]
    public GameObject[] collectibles;  // Inspector'dan atayacaksýn

    [Header("Kapý")]
    public GameObject door;  // Yok edilecek kapý

    private int collectedCount = 0;

    void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýþýlan nesne toplanabilirler listesindeyse
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (other.gameObject == collectibles[i])
            {
                // Nesneyi yok et
                Destroy(other.gameObject);

                // Sayacý artýr
                collectedCount++;

                Debug.Log("Toplandý: " + collectedCount);

                // Tüm nesneler toplandýysa kapýyý yok et
                if (collectedCount >= collectibles.Length)
                {
                    Destroy(door);
                    Debug.Log("Kapý yok edildi!");
                }

                // Ayný nesneyi tekrar saymamak için listeden çýkar
                collectibles[i] = null;

                break;
            }
        }
    }
}
