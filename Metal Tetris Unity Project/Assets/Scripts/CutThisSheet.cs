using UnityEngine;

public class CutThisSheet : MonoBehaviour
{
    [SerializeField] DeliverySystem _delivery;
    public void CutTheSheet() => _delivery.Deliver();
}
