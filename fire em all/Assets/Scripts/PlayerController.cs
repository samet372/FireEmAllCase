using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Transform _targetPoint;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AnimationStopper"))
        {
            if (gameObject.CompareTag("Girl"))
            {
                animator.SetBool("Sit", true);
                animator.SetBool("SittingIdle", true);
                gameObject.transform.RotateAround(gameObject.transform.position, Vector3.down, 105f);
            }
            if (gameObject.CompareTag("Men"))
            {
                animator.SetBool("Sit", true);
                animator.SetBool("SittingRubingArm", true);
                gameObject.transform.RotateAround(gameObject.transform.position, Vector3.down, 105f);
            }
        }
    }
    void PlayerMove()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, _targetPoint.position, Time.deltaTime);
    }
}
