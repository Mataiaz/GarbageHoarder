using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacter : MonoBehaviour
{
    public float health;
    protected float speed;
    protected float runSpeed;
    protected float initialSpeed;
    protected float initialHealth;
    protected float cooldown;
    protected float attackCooldown;
    protected float stunCooldown;
    public bool stun = false;
    public bool canPlaceObject = false;
    protected GameObject worldObject;
    protected GameObject worldEntity;
}
