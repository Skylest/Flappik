using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ��������������� ���������� ������ � ����
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// ������� ��������� ������
    /// </summary>
    [SerializeField] private Sprite spriteOn, spriteOff;

    /// <summary>
    /// ������ �� ������ "�����"
    /// </summary>
    [SerializeField] private Image buttonImage;

    /// <summary>
    /// ���� ������� �� ����
    /// </summary>
    private int isMusPlay = 1;

    private AudioSource audioSource;    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        isMusPlay = PlayerPrefs.GetInt("MusicSetting", 1);

        if (isMusPlay == 1)
        {
            audioSource.mute = false;
            buttonImage.sprite = spriteOn;
        }
        else
        {
            audioSource.mute = true;
            buttonImage.sprite = spriteOff;
        }
    }

    /// <summary>
    /// ��������� �� ����� ��� ����������� ������������� ������ � ������
    /// </summary>
    public void PlayPause()
    {
        if (isMusPlay == 1)
        {
            isMusPlay = 0;
            PlayerPrefs.SetInt("MusicSetting", 0);
            audioSource.mute = true;
            audioSource.Pause();
            buttonImage.sprite = spriteOff;

        }
        else
        {
            isMusPlay = 1;
            PlayerPrefs.SetInt("MusicSetting", 1);
            audioSource.mute = false;
            audioSource.UnPause();
            buttonImage.sprite = spriteOn;
        }
    }
}