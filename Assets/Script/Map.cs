using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform playerPos;
    public Transform offScreenPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);



            transform.position = Vector2.MoveTowards(transform.position, offScreenPos.position, speed * Time.deltaTime);

    }
}
