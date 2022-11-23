using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject player;
    public float Maxspeed = 0.2f;
    float speed = 0f;
    bool LookRight = true;
    public PlayerAnimController ac;
    bool IsRun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if ((LookRight && dx < 0) || (!LookRight && dx>0))
            Flip();
        if ((dx != 0 || dy != 0))
        {
            if (!IsRun)
            {
                ac.SetRunAnim();
                IsRun = true;
            }
            if (speed < Maxspeed)
                speed += 0.005f;
        }
        else
        {
            if (IsRun)
            {
                ac.SetStayAnim();
                IsRun = false;
            }
            if (speed > 0)
                speed -= 0.005f;
        }
        player.transform.position = new Vector3(player.transform.position.x + dx*speed, player.transform.position.y + dy*speed, player.transform.position.z);
    }
    private void Flip()
    {
        LookRight = !LookRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }
}
