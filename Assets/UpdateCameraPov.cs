using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class UpdateCameraPov : MonoBehaviour
{
    private Material _material;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _material.SetVector("_CameraForward", Camera.main.transform.forward);
    }
}
