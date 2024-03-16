using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    // 충돌한 오브젝트의 컬라이더.
    private List<Collider> colliderList = new List<Collider>();

    [SerializeField] private int layerGround;
    private const int IGNORE_RAYCASY_LAYER = 2;

    [SerializeField] private Material green;
    [SerializeField] private Material red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }
    private void ChangeColor()
    {
        if (colliderList.Count > 0)
            SetColor(red);//레드
        else
            SetColor(green);
    }
    private void SetColor(Material mat)
    {
        foreach (Transform th_Chile in this.transform)
        {
            var newMatrials = new Material[th_Chile.GetComponent<Renderer>().materials.Length];
            for (int i = 0; i < newMatrials.Length; i++)
            {
                newMatrials[i] = mat;
            }
            th_Chile.GetComponent<Renderer>().materials = newMatrials;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCASY_LAYER)
            colliderList.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCASY_LAYER)
            colliderList.Remove(other);
    }

    public bool isBuilderble()
    {
        return colliderList.Count == 0;
    }
}
