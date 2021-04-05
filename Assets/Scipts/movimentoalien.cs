using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoalien : MonoBehaviour
{


    [SerializeField]
    float speed = 0.05f;

    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * speed;

    }

    void turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftWall")
        {
            turn(1);
            MoveDown();
        }

        if (col.gameObject.name == "RightWall")
        {
            turn(-1);
            MoveDown();
        }
    }
}
