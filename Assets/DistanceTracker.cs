using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
    public Transform target1;
    public Transform target2;

    public Animator anim1;
    public Animator anim2;

    public float interactionDistance = 0.25f;

    private bool areClose = false;

    void Update()
    {
        if (target1 == null || target2 == null || anim1 == null || anim2 == null)
            return;
        float distance = Vector3.Distance(target1.position, target2.position);

        if (distance <= interactionDistance && !areClose)
        {
            areClose = true;
            anim1.SetBool("isAttacking", true);
            anim2.SetBool("isAttacking", true);

            Debug.Log("Attack. Distance is " + distance);
        }

        else if (distance > interactionDistance && areClose)
        {
            areClose = false;
            anim1.SetBool("isAttacking", false);
            anim2.SetBool("isAttacking", false);

            Debug.Log("Idle. Distance is " + distance);
        }
    }
}