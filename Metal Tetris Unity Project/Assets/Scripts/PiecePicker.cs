using System;
using UnityEngine;

public class PiecePicker : MonoBehaviour
{
    PlayerController _playerController;
    Camera _main;



    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _main = Camera.main;
    }

    private void Start() => _playerController.PlayerClicked += PickAPiece;
    private void OnDestroy() => _playerController.PlayerClicked -= PickAPiece;

    void PickAPiece(Vector3 mousePosition)
    {
        mousePosition = _main.WorldToScreenPoint(mousePosition);
        var ray = _main.ScreenPointToRay(mousePosition);
        RaycastHit2D[] RaycastHit = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);
        foreach (var hit in RaycastHit)
        {
            if (hit.collider == null) continue;

            if (hit.collider.GetComponent<PieceGrabber>() != null)
            {
                PieceGrabber grabber = hit.collider.GetComponent<PieceGrabber>();
                grabber.GrabAPiece();
            }
            if (hit.collider.GetComponent<CutThisSheet>() != null)
            {
                CutThisSheet cutter = hit.collider.GetComponent<CutThisSheet>();
                cutter.CutTheSheet();
            }

        }
    }

}
