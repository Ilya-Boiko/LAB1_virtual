using UnityEngine;


public class ChangeColor_sp : MonoBehaviour
{
    public Material activeMaterial = null;
    private MeshRenderer meshRenderer = null;
    public Material defaultMaterial = null;
    public bool fl = true;
    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }
    public void SetNewMaterial_sp()
    {
        if (fl == true)
        {
             meshRenderer.material = activeMaterial;
             fl = false;
        }
        else{
              meshRenderer.material = defaultMaterial;
             fl = true;
        }

    }

    // public void SetDefaultMaterial()
    // {
    //     meshRenderer.material = defaultMaterial;
    // }
}
