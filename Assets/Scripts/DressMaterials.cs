using UnityEngine;

public class DressMaterials : MonoBehaviour
{
    public static DressMaterials Singleton;
    public CapsuleCollider[] capsuleColliders;
    public Renderer _renderer;

    [Space(10), Header("Clothing")]
    public GameObject miniDress;

    private GameObject currentClothing;


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

        if (currentClothing)
            currentClothing.SetActive(false);

        currentClothing = newClothing;
        currentClothing.SetActive(true);
    }
}
