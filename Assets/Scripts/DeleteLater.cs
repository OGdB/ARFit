using UnityEngine;

public class DeleteLater : MonoBehaviour
{
    public Renderer _renderer;
    public Material dress1;
    public Material dress2;

    private void Start()
    {
        dress1 = new(dress1);
        dress2 = new(dress2);

        Material[] dressMaterials = _renderer.materials;
        dressMaterials[1] = dress1;
        _renderer.materials = dressMaterials;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Material[] dressMaterials = _renderer.materials;

            if (dressMaterials[1].color == dress1.color)
            {
                dressMaterials[1] = dress2;
            }
            else if (dressMaterials[1].color == dress2.color)
            {
                dressMaterials[1] = dress1;
            }
            _renderer.materials = dressMaterials;
        }
    }
}
