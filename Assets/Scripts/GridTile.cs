using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] Renderer r;
    Color[] colors = { Color.red, Color.green, Color.blue };
    Color lastColor;
    Color currentColor;
    Color nextColor;
    int index = 0;
    float timePerTransition;
    float lastTime;
    [SerializeField] float transitionTime;
    [SerializeField] float brightness;
    Vector3 scale;
    MaterialPropertyBlock m;
    // Start is called before the first frame update
    void Start()
    {
        
        m = new MaterialPropertyBlock();
        lastTime = Time.time;
        lastColor = colors[0];
        nextColor = colors[1];
    }

    // Update is called once per frame
    void Update()
    {
        timePerTransition = 1 / transitionTime;
        float T = timePerTransition * (Time.time - lastTime);
        
        scale = GetComponent<MeshFilter>().mesh.bounds.size;
        scale.x *= transform.localScale.x;
        scale.y *= transform.localScale.y;
        scale.z *= transform.localScale.z;
        currentColor = Color.Lerp(lastColor, nextColor, T);
        m.SetColor("Color", currentColor);
        if (T >= 1)
        {
            lastTime = Time.time;
            index++;
            if (index > colors.Length-1)
            {
                index = 0;
            }
        }
        lastColor = colors[index];
        if(index<colors.Length-1)
        nextColor = colors[index + 1];
        else
        {
            nextColor = colors[0];
        }
        m.SetVector("Scale",new Vector4( scale.x, scale.y, scale.z, 0));
        m.SetVector("Brightness", new Vector4(brightness, brightness, brightness, brightness));
        r.SetPropertyBlock(m);
        
    }
}
