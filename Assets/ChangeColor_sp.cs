using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor_sp : MonoBehaviour
{
    public Material activeMaterial = null;
    private MeshRenderer meshRenderer = null;
    public Material defaultMaterial = null;
    public bool fl = true;
    private float openTime;

    
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
            openTime = Time.time; 
        }
        else{
            meshRenderer.material = defaultMaterial;
            fl = true;
        }

    }


    void Update()
    {
        if ((Time.time - openTime) >= 5f)
        {
            meshRenderer.material = defaultMaterial;
            fl = true;
        }
    }

    // public void SetDefaultMaterial()
    // {
    //     meshRenderer.material = defaultMaterial;
    // }
}
