using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Controller _controller;
    Camera _mainCamera;
    Vector2 _mouseWorldPosition;
    public Action<Vector3> PlayerClicked;
    public Action<float> PlayerRotate;
    public Vector2 MousePosition => _mouseWorldPosition;

    void OnEnable() => _controller.Enable();
    void OnDisable() => _controller.Disable();

    void Awake()
    {
        _controller = new Controller();
        _mainCamera = Camera.main;
    }

    void Start()
    {
        _controller.Player.MousePosition.performed += t => MousePostion(t.ReadValue<Vector2>());
        _controller.Player.PlacePiece.performed += t => PlacePiece();
        _controller.Player.RotatePiece.performed += t => RotatePiece(t.ReadValue<float>());
    }

    void MousePostion(Vector2 cursorInput) => _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(cursorInput);
    void PlacePiece() => PlayerClicked(_mouseWorldPosition);
    private void RotatePiece(float side) => PlayerRotate(side/Mathf.Abs(side));
}
