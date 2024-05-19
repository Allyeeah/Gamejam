using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke("Think", 5);
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider != null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 2);
        }
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        anim.SetInteger("WalkSpeed", nextMove);
        if (nextMove != 0)
        {
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
}
