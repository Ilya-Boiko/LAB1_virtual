using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    public Material activeMaterial = null;
    private MeshRenderer meshRenderer = null;
    public Material defaultMaterial = null;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }
    public void SetNewMaterial()
    {
        meshRenderer.material = activeMaterial;
    }

    public void SetDefaultMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }
}
