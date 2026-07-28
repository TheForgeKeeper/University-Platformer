using JdnUtilities;
using UnityEngine;

public class CustomGravity : MonoBehaviour, IPlayerGravity
{
    [SerializeField] private float fallingGravity = 19.2f;
    [SerializeField] private float standardGravity = 9.8f;


    private GroundCheck groundCheck;
    private Rigidbody Rb;
    private float gravity;
    private bool gravityDisabled = false;

    public void InjectData(GroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.useGravity = false;
    }


    private void FixedUpdate()
    {
        if (Rb.linearVelocity.y < 0)
        {
            gravity = fallingGravity;
        }
        else
        {
            gravity = standardGravity;
        }
        if (gravityDisabled )
        {
            gravity = 0;
        }

        Rb.AddForce(Vector3.down * gravity, ForceMode.Force);

    }

    public void DisableGravity()
    {
        Debug.Log("gravityDisabled");
        gravityDisabled = true;
    }

    public void EnableGravity()
    {
        Debug.Log("gravityEnabled");

        gravityDisabled = false;
    }

    public void EnableGravityAfterTime(float time)
    {
        StartCoroutine(JdnCoroutines.CallAfterTime(EnableGravity, time));
    }

    private void OnEnable()
    {
        if(Rb != null) Rb.useGravity = false;
    }

    private void OnDisable()
    {
        Rb.useGravity = true;
    }
}
