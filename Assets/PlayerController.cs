using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  Vector2 movement;

  string lastDirection = "down";
  Animator animator;

  bool isAttacking = false;

  [SerializeField]
  AnimationClip attackDown;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    transform.Translate(movement * 5 * Time.deltaTime);

    if (!isAttacking)
    {
      if (movement.y > 0)
      {
        animator.Play("WalkUp");
        lastDirection = "up";
      }
      else if (movement.y < 0)
      {
        animator.Play("WalkDown");
        lastDirection = "down";
      }
      else
      {
        if (lastDirection == "up") animator.Play("IdleUp");
        if (lastDirection == "down") animator.Play("IdleDown");
      }
    }

  }

  void OnMove(InputValue value)
  {
    movement = value.Get<Vector2>();
  }

  void OnFire()
  {
    isAttacking = true;
    animator.Play(attackDown.name);

    // List<AnimationClip> clips = new(animator.runtimeAnimatorController.animationClips);
    // float length = clips.Find(c => c.name == "AttackDown").length;

    Invoke("StopAttacking", attackDown.length);
  }

  void StopAttacking() => isAttacking = false;
}
