using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 move;
    public float forwardSpeed, powerSpeed, charactorHeight = 0.85f, rolling = 0.3f;
    public float maxSpeed, speedRate;
    public int currentLane = 0;
    public float laneDistance = 2.5f;//The distance between tow lanes
    public float rangeMin = -2, rangeMax = 2;
    public float changeLaneSpeed = 0.3f;
    public Ease changeLaneAnimation = Ease.OutQuad;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
	public float groundRadius = 0.17f;

    public float gravity = -12f;
    public float jumpHeight = 2;
    private Vector3 velocity;
    public Transform respawnPosition;
    public Animator animator;
    public Volume effectVolume;
    public int animatorWeight = 0;

    public bool gameOver;

    private bool isSliding = false;

    public AudioSource source, actionAudios;
    public AudioClip run, roll, jump, hitDie;

    private float animationSpeed;
    private float runningSpeed;

    public DOTweenAnimation bike;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1;
        GameObject sunLight = GameObject.Find("Directional Light");
        sunLight.transform.SetParent(transform);
    }


    void Update()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

         if (isGrounded && velocity.y < 0)
             velocity.y = -1f;

        controller.Move(velocity * Time.deltaTime);
        if (!gameOver)
          {
              move.z = forwardSpeed + powerSpeed;
              if (forwardSpeed < maxSpeed)
                  forwardSpeed += speedRate/10 * Time.deltaTime;

              if(animationSpeed < 1)
                animationSpeed += speedRate / 10 * Time.deltaTime;

            runningSpeed = (forwardSpeed + powerSpeed) / 5;
          //  animator.SetFloat("animation", runningSpeed);
          //  animator.SetFloat("speed", animationSpeed);


            //animator.SetBool("run", isGrounded);


            if (isGrounded)
            {
                if (SwipeManager.swipeUp)
                    Jump();

                if (SwipeManager.swipeDown && !isSliding)
                    StartCoroutine(Slide());
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
                if (SwipeManager.swipeDown && !isSliding)
                {
                    StartCoroutine(Slide());
                    velocity.y = -10;
                }

            }

            //Gather the inputs on which lane we should be
            if (SwipeManager.swipeRight)
            {
                Steer(1);
                //  StartCoroutine(straff("straffRight"));
            }
            if (SwipeManager.swipeLeft)
            {
                Steer(-1);
                // StartCoroutine(straff("straffLeft"));
            }
            controller.Move(move * Time.deltaTime);
          }
        else
            velocity.y = -1f;


        SideRays();
    }

    private void Steer(int val)
    {
        int prevLane = currentLane;
        currentLane += val;
        currentLane = (int)Mathf.Clamp(currentLane, rangeMin, rangeMax);

        if(prevLane != currentLane)
        {
            float targetX = currentLane * laneDistance;
            float startX = transform.position.x;
            float elapsedTime = 0f;

            DOTween.To(() => startX, x =>
            {
                Vector3 newPos = transform.position;
                newPos.x = x;
                controller.Move((newPos - transform.position)); // Use CharacterController.Move()
            }, targetX, changeLaneSpeed)
            .SetEase(changeLaneAnimation);



            float steer = val;
            DOTween.To(() => steer, x => steer = x, 0, changeLaneSpeed+0.5f)
            .SetEase(changeLaneAnimation)
                   .OnUpdate(() =>
                   {
                       animator.SetFloat("steer", steer);
                   }
                   );
                   
        }
    }
    private void Jump()
    {
        //sound(jump);
      //  if(bike.gameObject.activeInHierarchy)
       //     bike.DORestart();
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
        animator.SetTrigger("jump");
        isSliding = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.right * 3);
        Gizmos.DrawRay(transform.position + Vector3.up, -transform.right * 3);
    }

    private void SideRays()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up / 2, transform.right, out hit, 3))
        {
            if (hit.transform.TryGetComponent<MovingTween>(out MovingTween car))
            {
                if (car.movingTween.IsPlaying())
                {
                    Camera_Orbit.instance.ShakeCamera(forwardSpeed/5);
                }
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up / 2, -transform.right, out hit, 3))
        {
            if (hit.transform.TryGetComponent<MovingTween>(out MovingTween car))
            {
                if (car.movingTween.IsPlaying())
                {
                    Camera_Orbit.instance.ShakeCamera(forwardSpeed / 5);
                }
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(gameOver == true)
        {
            return;
        }
        if (hit.transform.tag == "Obstacles")
        {
            Debug.Log("Game over " + hit.gameObject.name);
            gameOver = true;
            StartCoroutine(endMenu());
            respawnPosition.parent = null;
        }
    }

    


    private IEnumerator Slide()
    {
        print("Swipe Down");
        yield return null;
        /*
        isSliding = true;
        animator.SetTrigger("roll");
        controller.height = 0.5f;
        controller.center = new Vector3(0, rolling, 0);
        sound(roll);
        yield return new WaitForSeconds(1.25f);
        controller.height = 2.44f;
        controller.center = new Vector3(0, charactorHeight, 0);
        isSliding = false;*/
    }

    public void sound(AudioClip clip)
    {
        actionAudios.clip = clip;
        actionAudios.Play();
    }

    public void FootEvent(AnimationEvent animationEvent)
    {
       // print($"Float {animationEvent.floatParameter}: Int {animationEvent.intParameter}: string {animationEvent.stringParameter}: object {animationEvent.objectReferenceParameter.name}");
       // Vector3 FootPoint = animationEvent.intParameter == 0? animator.GetIKPosition(AvatarIKGoal.LeftFoot) : animator.GetIKPosition(AvatarIKGoal.RightFoot);
       // GameObject obj = Instantiate(animationEvent.objectReferenceParameter.GameObject(), transform.position + FootPoint, Quaternion.identity);
        sound(run);
       // Destroy(obj, 1);
    }

    public IEnumerator endMenu()
    {
        float currentWeight = 1;
        // Dowtween to increase the weight of the animation
        DOTween.To(() => currentWeight, x => currentWeight = x, 0, 1)
            .OnUpdate(() =>
            {
                effectVolume.weight = currentWeight;
            })
            .SetEase(Ease.Linear);

        // effectsAnimation.Play("Die effects");
        animator.SetBool("isHit", true);
        //effectsAnimation.SetBool("normal", true);
        sound(hitDie);
        yield return new WaitForSeconds(1.5f);
        GameManager.OnGameOver?.Invoke();
        GameManager.Instance.endMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Continue()
    {
        var player = FindObjectOfType<Player>().transform;
        PowerUpsManager.powerUp = true;
        PowerUpsManager.fastRun = true;
        animator.SetBool("isHit", false);
        PowerUpsManager.Condition();
        respawnPosition = player;
        gameOver = false;
    }

    public void closeCall(string text)
    {
        /*GameObject obj;
        obj = Instantiate(cloaseCallCanvas);
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        obj.GetComponentInChildren<Text>().text = text;
        Destroy(obj, 2);*/
    }
}