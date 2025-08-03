using UnityEngine;

public class SimpleCharacterSwitcher : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;

    void Start()
    {
        character1.SetActive(true);
        character2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        if (character1.activeSelf)
        {
            // Pozisyon kopyala
            character2.transform.position = character1.transform.position;
            character2.transform.rotation = character1.transform.rotation;

            // Aktiflik deðiþtir
            character1.SetActive(false);
            character2.SetActive(true);
        }
        else
        {
            character1.transform.position = character2.transform.position;
            character1.transform.rotation = character2.transform.rotation;

            character2.SetActive(false);
            character1.SetActive(true);
        }
    }
}
