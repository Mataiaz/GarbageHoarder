using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : EntityCharacter
{
    private bool carryingObject = false;
    void Start() {
        initialSpeed = 4f;
        runSpeed = 8f;
        speed = initialSpeed;
        initialHealth = 100f;
        health = initialHealth;
        cooldown = 5f;
    }

    void Update() {
        Movement(Input.GetAxis("Horizontal")
               , Input.GetAxis("Vertical"));
        DoAction();
    }

    void Movement(float moveHorizontal, float moveVertical) {
        if(carryingObject) {
            if(speed >= initialSpeed)
                speed =- 1f;
        }
        else if(speed < initialSpeed)
            speed = initialSpeed;
        
        Vector2 movement = new Vector2 (moveHorizontal*speed, moveVertical*speed);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    void DoAction() {
        if(Input.GetKeyDown(KeyCode.E))
            Carry();
        if(Input.GetKeyDown(KeyCode.Space))
            Attack();
        if(Input.GetKey(KeyCode.LeftShift)) {
            if(speed != runSpeed)
                speed = runSpeed;
        }
        else if(speed > initialSpeed)
            speed = initialSpeed;

    }

    void Carry() {
        if(worldObject) {
            if(worldObject.tag == "bin") {

            }
        }
    }

    void Attack() {
        if(attackCooldown <= Time.time) {
            if(worldEntity) {
                worldEntity.GetComponent<EnemyCharacter>().health -= 100;
                worldEntity.GetComponent<EnemyCharacter>().stun = true;
            }
            attackCooldown = Time.time + cooldown;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bin" && gameObject != null) {
            worldObject = other.gameObject;
        }
        if(other.tag == "enemy" && gameObject != null) {
            worldEntity = other.gameObject;
        }
        if(other.tag == "storage") {
            canPlaceObject = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "bin" && worldObject == other.gameObject) {
            worldObject = null;
        }
        if(other.tag == "enemy" && worldObject == other.gameObject) {
            worldEntity = null;
        }
        if(other.tag == "storage") {
            canPlaceObject = false;
        }
    }
}
