using UnityEngine;

public class DeleteLater : MonoBehaviour
{
    private GameObject currentDress;
    public GameObject dress1;
    public GameObject dress2;

    private void Start()
    {
        currentDress = dress1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentDress.SetActive(false);

            currentDress = currentDress == dress1 ? dress2 : dress1;

            currentDress.SetActive(true);
        }
    }
}
