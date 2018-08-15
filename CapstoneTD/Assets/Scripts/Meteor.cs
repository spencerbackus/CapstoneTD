using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour
{
    public GameObject meteor;
    public GameObject tur1, tur2, tur3;
    private float timer = 3f;
    public int count = 0;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && count <= 3)
        {
            SpawnMeteor(meteor);
            timer = 3f;
            count++;
        }
        if (timer <= 0f && count > 3)
        {
            SpawnMeteor(meteor);
            SpawnMeteor(meteor);
            timer = 3f;
            count++;
        }

        if (timer <= 0f && count > 6)
        {
            SpawnMeteor(meteor);
            SpawnMeteor(meteor);
            SpawnMeteor(meteor);
            timer = 3f;
        }
    }

    void SpawnMeteor(GameObject meteor)
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f, 80.0f), 30, Random.Range(-10.0F, 80.0f));
        //instantiate the meteor
        Instantiate(meteor, pos, Quaternion.identity);
    }

    void OnMouseDown()
    {
        Destroy(meteor);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            Destroy(meteor);
            Stats.lives = Stats.lives - 2;
            Stats.money = Stats.money - 350;
        }
        else if(collision.gameObject.tag == "Turret2")
        {
            Destroy(meteor);
            Stats.lives = Stats.lives - 3;
            Stats.money = Stats.money - 400;
        }
        else if(collision.gameObject.tag == "Turret3")
        {
            Destroy(meteor);
            Stats.lives = Stats.lives - 5;
            Stats.money = Stats.money - 500;
        }
        else if(collision.gameObject.tag == "Finish")
        {
            Stats.lives = 0;
        }
        else
        {
            Destroy(meteor);
            Stats.lives--;
            Stats.money = Stats.money - 200;
        }

    }

}


