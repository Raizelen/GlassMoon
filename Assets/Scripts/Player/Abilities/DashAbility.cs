using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : PlayerAbility
{
    readonly float speed;
    readonly float duration;

    public DashAbility(float speed, float duration)
    {
        this.speed = speed;
        this.duration = duration;
    }

    public override IEnumerator Apply(PlayerController controller)
    {
        if (!controller.canDash || controller.isGrounded || !Input.GetKeyDown(KeyCode.Space)) yield break;

        controller.canDash = false;
        float vel = controller.rb.velocity.x;
        int direction = vel > 0 ? 1 : -1;
        if (vel == 0)
        {
            direction = controller.facingRight ? 1 : -1;
        }
        controller.overrideVelocity = true;
        controller.overridenVelocity = new Vector2(direction * speed, 0);
        yield return new WaitForSeconds(duration);
        controller.overrideVelocity = false;
    }
}
