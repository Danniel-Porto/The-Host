using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] grassStepSound;
    [SerializeField] AudioClip[] solidStepSound;
    [SerializeField] AudioClip[] liquidStepSound;
    AudioSource audioSource;
    PlayerMotor pm;
    PlayerSettings settings;

    public int floorType;
    bool isStepPlaying;

    private void Start()
    {
        pm = GetComponent<PlayerMotor>();
        audioSource = GetComponent<AudioSource>();
        settings = GetComponent<PlayerSettings>();
    }

    private void Update()
    {
        StepSound();
    }

    private void StepSound()
    {
        if ((Mathf.Sin(pm.time)) < 0 & !isStepPlaying)
        {
            isStepPlaying = true;

            switch (floorType)
            {
                case 0:
                    audioSource.PlayOneShot(grassStepSound[Random.Range(0, 4)], 0.28f * settings.playerVolume);
                    break;
                case 1:
                    audioSource.PlayOneShot(solidStepSound[Random.Range(0, 4)], 0.28f * settings.playerVolume);
                    break;
                case 2:
                    audioSource.PlayOneShot(liquidStepSound[Random.Range(0, 4)], 0.28f * settings.playerVolume);
                    break;
                default:
                    break;
            }
        }
        else if ((Mathf.Sin(pm.time)) >= 0 & isStepPlaying)
        {
            isStepPlaying = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FloorGrass":
                floorType = 0;
                break;
            case "FloorSolid":
                floorType = 1;
                break;
            case "FloorLiquid":
                floorType = 2;
                break;
            default:
                break;
        }
    }
}
