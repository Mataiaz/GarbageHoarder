using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : EntityCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        stunCooldown = 2f;
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0f)
            Destroy(this.gameObject);
        if(!stun) {
            Movement();
        }
        else if(cooldown >= Time.deltaTime) {
            stun = false;
        }
        else if(cooldown < Time.deltaTime) {
            cooldown = Time.deltaTime + stunCooldown;
        }


    }

    private void Movement() {

    }
}
