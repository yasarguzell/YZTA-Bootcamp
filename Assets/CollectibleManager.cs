using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [Header("Toplanabilir Nesneler")]
    public GameObject[] collectibles;  // Inspector'dan atayacaks�n

    [Header("Kap�")]
    public GameObject door;  // Yok edilecek kap�

    private int collectedCount = 0;

    void OnTriggerEnter(Collider other)
    {
        // E�er �arp���lan nesne toplanabilirler listesindeyse
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (other.gameObject == collectibles[i])
            {
                // Nesneyi yok et
                Destroy(other.gameObject);

                // Sayac� art�r
                collectedCount++;

                Debug.Log("Topland�: " + collectedCount);

                // T�m nesneler topland�ysa kap�y� yok et
                if (collectedCount >= collectibles.Length)
                {
                    Destroy(door);
                    Debug.Log("Kap� yok edildi!");
                }

                // Ayn� nesneyi tekrar saymamak i�in listeden ��kar
                collectibles[i] = null;

                break;
            }
        }
    }
}
