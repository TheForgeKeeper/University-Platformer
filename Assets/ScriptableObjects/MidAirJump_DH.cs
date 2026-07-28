using UnityEngine;

[CreateAssetMenu(menuName = "DataHolders/Orbs_DHs/MidAirJump_DH")]
public class MidAirJump_DH : ScriptableObject
{
    [SerializeField] private float _jumpForce;

    public float jumpForce => _jumpForce;
}
