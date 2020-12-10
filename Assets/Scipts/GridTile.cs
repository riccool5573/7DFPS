using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] Renderer r;
    [SerializeField] Color color;
    [SerializeField] float brightness;
    Vector3 scale;
    MaterialPropertyBlock m;
    // Start is called before the first frame update
    void Start()
    {
        m = new MaterialPropertyBlock();
        
    }

    // Update is called once per frame
    void Update()
    {
        scale = GetComponent<MeshFilter>().mesh.bounds.size;
        scale.x *= transform.localScale.x;
        scale.y *= transform.localScale.y;
        scale.z *= transform.localScale.z;
        m.SetColor("Color", color);
        
        m.SetVector("Scale",new Vector4( scale.x, scale.y, scale.z, 0));
        m.SetVector("Brightness", new Vector4(brightness, brightness, brightness, brightness));
        r.SetPropertyBlock(m);
        
    }
}
