using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;
    private float startFollowSpeed;
    public Transform followTarget;

    [Header("Offsets")]
    public Vector3 offset;
    private Vector3 startOffset;
    public Vector3 pauseOffset;

    void Start()
    {
        GameManager.scriptCamera = GetComponent<CameraFollow>();
        startOffset = offset;
        startFollowSpeed = followSpeed;
        //followTarget = Player.PlayerCharacter.transform;
    }

    public void ChangeOffset(Vector3 offsetChange)
    {
        offset = offsetChange;

    }

    public void ResetOffset()
    {
        offset = startOffset;

    }

    public void ChangeTarget(Transform target)
    {
        followTarget = target;

    }

    public void ResetTarget()
    {
        followTarget = GameManager.PlayerCharacter.transform;

    }
    public void ResetLerpSpeed()
    {
        followSpeed = startFollowSpeed;

    }

    void Update()
    {
        //Try setting player character until it is set
        if (followTarget == null) followTarget = GameManager.PlayerCharacter.transform;

        if (followTarget != null)
        {
            if (GameManager.scriptMenu.menuOpen)
            {
                transform.position = Vector3.Lerp(transform.position, followTarget.position + pauseOffset, followSpeed);

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(followTarget.position.x, followTarget.position.y, followTarget.position.z) + offset, followSpeed);

            }
        }
    }
}
