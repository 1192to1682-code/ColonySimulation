using UnityEngine;
using UnityEngine.InputSystem;

public class ColonistAnimatorcontroller : MonoBehaviour
{
    /// <summary>
    /// 住人のアニメーター
    /// </summary>
    public Animator CollonistAnimator;

    private void Update()
    {

        if (Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            PlayIdleAnimation();
        }


        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            PlayWalkingAnimation();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            PlayMineAnimation();
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            PlaySleepingAnimation();
        }


        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            PlayRestAnimation();
        }



        if (Keyboard.current.digit1Key.wasPressedThisFrame
            && Keyboard.current.minusKey.wasPressedThisFrame)
        {
            PlayDeathAnimation();
        }


    }


    public void PlayIdleAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState", 0);
    }
        /// <summary>
        ///歩くアニメーションの再生 
        /// </summary>
        public void PlayWalkingAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState",1);
    
    }

    public void PlayMineAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState",2);

    }
    public void PlaySleepingAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState",3);

    }

        public void PlayRestAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState", 4);

    }

    public void PlayDeathAnimation()
    {

        CollonistAnimator.SetInteger("AnimationState",-1);
        CollonistAnimator.SetTrigger("DeathTrigger");

    }


}
