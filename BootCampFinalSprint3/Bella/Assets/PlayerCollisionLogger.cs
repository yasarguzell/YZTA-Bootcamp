using UnityEngine;

public class PlayerCollisionLogger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �arpt���n objenin ad�n� al
        string collidedObjectName = collision.gameObject.name;

        // Konsola yaz
        Debug.Log("�arpt���n obje: " + collidedObjectName);
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er bu Collider bir Trigger ise buraya d��er
        string triggeredObjectName = other.gameObject.name;

        Debug.Log("Trigger ile temas edilen obje: " + triggeredObjectName);
    }
}
