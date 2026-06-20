using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MenuView : MonoBehaviour
{
    [SerializeField] public GameObject FirstMenuEnemy;
    [SerializeField] public GameObject SecondMenuEnemy;
    [SerializeField] public SpriteRenderer BackgroundImage;
    [SerializeField] public AudioClip MenuSound;
    [SerializeField] public AudioSource Source;
    [SerializeField] public Button PlayButton;
    [SerializeField] public Button ExitButton;

    [Header("Enemy Animation Settings")]
    [SerializeField] private float minDelay = 1.0f;  
    [SerializeField] private float maxDelay = 4.0f;

    [Header("Color Animation Settings")]
    [SerializeField] private float speed = 0.5f;

    private float t = 0f;
    private Animator firstEnemyAnimator;
    private Animator secondEnemyAnimator;
    private float nextAnimationTime;

    private void Start()
    {
        if (Source && MenuSound)
        {
            Source.clip = MenuSound;
            Source.loop = true;
            Source.Play();
        }

        if (FirstMenuEnemy != null)
        {
            firstEnemyAnimator = FirstMenuEnemy.GetComponent<Animator>();
        }

        if (SecondMenuEnemy != null)
        {
            secondEnemyAnimator = SecondMenuEnemy.GetComponent<Animator>();
        }

        nextAnimationTime = Time.time + Random.Range(minDelay, maxDelay);
    }

    private void TriggerAnimation(Animator animator)
    {
        if (animator == null) return;
        animator.Play("MenuEnemyAnim", 0, 0f);
        animator.Play("MenuEnemyAnim2", 0, 0f);
    }

    private void TriggerAnimationFirstEnemy(Animator animator)
    {
        if (animator == null) return;
        animator.Play("MenuEnemyAnim", 0, 0f); 
    }

    private void TriggerAnimationSecondEnemy(Animator animator)
    {
        if (animator == null) return;
        animator.Play("MenuEnemyAnim2", 0, 0f); 
    }

    private void PlayRandomEnemyAnimation()
    {
        int randomEnemy = Random.Range(0, 2);

        if (randomEnemy == 0)
        {
            TriggerAnimationFirstEnemy(firstEnemyAnimator);
        }
        else
        {
            TriggerAnimationSecondEnemy(secondEnemyAnimator);
        }
    }

    private void Update()
    {
        if (BackgroundImage != null)
        {
            t += Time.deltaTime * speed;
            float pingPong = Mathf.PingPong(t, 1f);

            Color color = BackgroundImage.color;
            color.a = Mathf.Lerp(1.0f, 0.95f, pingPong);
            BackgroundImage.color = color;
        }

        if (Time.time >= nextAnimationTime)
        {
            PlayRandomEnemyAnimation();
            nextAnimationTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("OnExitButtonPressed");
    }
}
