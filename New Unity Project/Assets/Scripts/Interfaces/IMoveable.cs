using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Rigidbody2D RB { get; set;}
    bool IsFacingRight { get; set;}
    void Move(Vector2 velocity);
    void CheckDirection(Vector2 velocity);
}
