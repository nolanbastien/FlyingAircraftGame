using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 0.5f;

    private Renderer rendererOffset;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        rendererOffset = GetComponent<Renderer>();
        Vector2 offset = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        offset.Set(Time.time * speed % 1, 0);

        rendererOffset.material.mainTextureOffset = offset;
    }
}
