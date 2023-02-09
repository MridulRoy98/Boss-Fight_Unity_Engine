using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineFreeLook cineMachineCamera;

    private void Awake()
    {
        cineMachineCamera= GetComponent<CinemachineFreeLook>();
    }
    
    public void ShakeCamera()
    {
    }

}
