using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJump : PlayerAbility
{
    private int jumps;
   



    public MultiJump(int jumps)
    {
        this.jumps = jumps;
    }

    public override IEnumerator Apply(PlayerController controller)
    {
        if (controller.currentJumped >= jumps) yield break;

        // Jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            controller.currentJumped++;
            controller.rb.velocity = new Vector2(controller.rb.velocity.x, controller.jumpVelocity);
           

        }
        yield break;
    }
}
