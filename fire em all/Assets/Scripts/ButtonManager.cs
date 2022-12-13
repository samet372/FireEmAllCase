using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
     Animator animator;
    [SerializeField] PanelManager PanelManager;
    [SerializeField] CamAnimation camAnimation;
    [SerializeField] PoolManager poolManager;

    [SerializeField] ParticleSystem _starFallVfx; //VFX
    [SerializeField] ParticleSystem _moneyVfxConfetti;
    [SerializeField] ParticleSystem _moneyVfx;

    [SerializeField] ParticleSystem _sadEmoji; //Emoji
    [SerializeField] ParticleSystem _angryEmoji;

    [SerializeField] ParticleSystem _correct; //Particle
    [SerializeField] ParticleSystem _badDecision;
    [SerializeField] ParticleSystem _goodJob;
    [SerializeField] ParticleSystem _hrTask;

    private void Start()
    {
        _starFallVfx.Stop();
        _moneyVfxConfetti.Stop();
        _moneyVfx.Stop();
        _sadEmoji.Stop();
        _angryEmoji.Stop();

    }
    public void HireButton()
    {
        animator = GameObject.Find("Girl(Clone)").GetComponent<Animator>();
        animator.SetBool("SittingClap", true);

        _starFallVfx.Play();
        _correct.Play();

        PanelManager.HirePanel();//setActive(false);
        camAnimation.Invoke("CamAnim", 1.5f); //camera animation
        poolManager.Invoke("PlayerSpawner", 2f); //player spawn

        Invoke("PlayerFalse", 2f); //player.SetActive(false)
        
    }
  
    public void DismissButton()
    {
        animator = GameObject.Find("Girl(Clone)").GetComponent<Animator>();
        animator.SetBool("SittingDisbelief", true);

        _sadEmoji.Play();
        _badDecision.Play();

        PanelManager.HirePanel();//setActive(false);
        camAnimation.Invoke("CamAnim", 1.5f);
        poolManager.Invoke("PlayerSpawner", 2f);

        Invoke("PlayerFalse", 2f);
        
    }
    public void FireButton()
    {
        animator = GameObject.Find("Men(Clone)").GetComponent<Animator>();
        animator.SetBool("SittingAngry", true);

        _angryEmoji.Play();
        _goodJob.Play();

        PanelManager.FirePanel();//setActive(false);

        Vibrator.Vibrate(500);
        Invoke("MoneyVfx", 3f);
        
    }
    
    public void PromoteButton()
    {
        animator = GameObject.Find("Men(Clone)").GetComponent<Animator>();
        animator.SetBool("SittingClap", true);

        _starFallVfx.Play();
        _correct.Play();

        PanelManager.FirePanel(); //setActive(false);

        Vibrator.Vibrate(500); //phone vibration
        Invoke("MoneyVfx", 3f);
        
    }

    void PlayerFalse() // player.setActive
    {
        GameObject.Find("Girl(Clone)").SetActive(false);
    }

    void MoneyVfx() //end Vfx
    {
        _moneyVfxConfetti.Play();
        _moneyVfx.Play();
        _hrTask.Play();
    }
}
