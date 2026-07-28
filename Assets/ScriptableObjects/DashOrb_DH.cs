using UnityEngine;

public class DashOrb_DH : ScriptableObject
{
    [SerializeField]private float _dashForce;
    [SerializeField]private float _dashDuration;

    public float dashForce => _dashForce;
    public float dashDuration => _dashDuration;
}
