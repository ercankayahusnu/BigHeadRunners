using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    float xSpeed;
    float maxValue = 4.28f;
    bool isPlayerMoving;
    public GameObject headBoxGO;
    private ScalCalculator scalCalculator;
    private Material currentHeadMat;
    Renderer headBoxRenderer;
    public Material warningMat;
    Animator playerAnim;
    public AudioSource playerAudioSource;
    public AudioClip gateClip, colorBoxClip, obsClip, sucessClip;
    void Start()
    {
        scalCalculator = new ScalCalculator();
        headBoxRenderer = headBoxGO.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        currentHeadMat = headBoxRenderer.material;
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerMoving == false)
        {
            return;
        }

        float touchX = 0;
        float newXvalue = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            xSpeed = 250f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            xSpeed = 500f;
            touchX = Input.GetAxis("Mouse X");

        }
        newXvalue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXvalue = Mathf.Clamp(newXvalue, -maxValue, maxValue);
        Vector3 playerNewPosition = new Vector3(newXvalue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isPlayerMoving = false;
            StartIdleAnim();
            GameManager.instance.ShowSucessMenu();
            StopBackgroundMusic();
            PlayAudio(sucessClip, 1f);
        }
        
    }

    public void PassedGate(GateType gateType, int gateValue)
    {
        PlayAudio(gateClip, 1f);
        headBoxGO.transform.localScale = scalCalculator.CalculatePlayerHeadSize(gateType, gateValue, headBoxGO.transform);
        
    }

    public void TouchedToColorBox(Material boxMat)
    {
        PlayAudio(colorBoxClip, 1f);
        headBoxRenderer.material = boxMat;
        currentHeadMat = boxMat;
    }
   public void TouchedToObstacle()
    {
        PlayAudio(obsClip, 1f);
        headBoxGO.transform.localScale = scalCalculator.DecreasePlayerHeadSize(headBoxGO.transform);
        StartCoroutine(StartRedLight());
    }
    private IEnumerator StartRedLight()
    {
        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = warningMat;

        yield return new WaitForSeconds(0.3f);

        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = currentHeadMat;
    
    }
    public void GameStarted()
    {
        isPlayerMoving = true;
        StartRunAnim();
    }
    private void StartRunAnim()
    {
        playerAnim.SetBool("isIdleOn", false);
        playerAnim.SetBool("RunningOn", true);
    }
    private void StartIdleAnim()
    {
        playerAnim.SetBool("isIdleOn", true);
        playerAnim.SetBool("RunningOn", false);
    }
    private void PlayAudio(AudioClip audioClip , float volume)
    {
        playerAudioSource.PlayOneShot(audioClip, volume);
    }
    private void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}