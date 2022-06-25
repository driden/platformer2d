using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource hurt;
    public AudioSource win;
    public AudioSource lose;
    public AudioSource pickUp;
    public AudioSource fireball;
    public AudioSource unlock;


    public void playJump() { jump.Play(); }
    public void playHurt() { hurt.Play(); }
    public void playWin() { win.Play(); }
    public void playLose() { lose.Play(); }
    public void playPickUp() { pickUp.Play(); }
    public void playFireBall() { fireball.Play(); }
    public void playUnlock() { unlock.Play(); }
}
