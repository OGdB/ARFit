using UnityEngine;

public class ClothingChanger : MonoBehaviour
{
    public static ClothingChanger Singleton;

    public GameObject currentClothing;


    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeClothing(GameObject newClothing)
    {
        if (currentClothing == newClothing) return;

        if (currentClothing != null)
            currentClothing.SetActive(false);

        currentClothing = newClothing;
        currentClothing.SetActive(true);
    }
}
