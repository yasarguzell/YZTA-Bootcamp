using UnityEngine;

public class PlayerCollisionLogger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Çarptýðýn objenin adýný al
        string collidedObjectName = collision.gameObject.name;

        // Konsola yaz
        Debug.Log("Çarptýðýn obje: " + collidedObjectName);
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer bu Collider bir Trigger ise buraya düþer
        string triggeredObjectName = other.gameObject.name;

        Debug.Log("Trigger ile temas edilen obje: " + triggeredObjectName);
    }
}
