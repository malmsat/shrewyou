using UnityEngine;

public class AnimationControlle : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput != 0) // the != means not equals to, so if there is any movement value
        {
            anim.SetBool("isMoving", true);

        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}