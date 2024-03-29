using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        var cameraTransform = transform;
        var player1Pos = player1.position;
        var player2Pos = player2.position;

        var pos = (player1Pos + player2Pos) * 0.5f;
        pos.y = cameraTransform.position.y;
        pos.z = cameraTransform.position.z;
        cameraTransform.position = pos;
        
        _camera.orthographicSize = Math.Clamp(Math.Abs((player1Pos.x - player2Pos.x) * 0.5f), 4, 36);
    }
}