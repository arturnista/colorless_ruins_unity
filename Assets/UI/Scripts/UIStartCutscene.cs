using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStartCutscene : MonoBehaviour
{

    [SerializeField] private Image _skipTime;

    private int _messageIndex = 0;

    private float _holdingTime;
    private const float _holdingDelay = 1f;
    
    void Start()
    {
        _holdingTime = 0;
        UIMessage.Main.OnCloseMessage += ShowNextMessage;
        ShowNextMessage();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _holdingTime += Time.deltaTime;
            _skipTime.fillAmount = Mathf.Clamp01(_holdingTime / _holdingDelay);

            if (_holdingTime > _holdingDelay)
            {
                LoadGame();
            }
        }
        else
        {
            _holdingTime = 0;
            _skipTime.fillAmount = 0f;
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    void ShowNextMessage()
    {
        switch (_messageIndex)
        {
            case 0:
                UIMessage.Main.Show("Your head hurts from the fall.\n\nYou don't know where you are.");
                break;
            case 1:
                UIMessage.Main.Show("You must find a way back.\n\nBack to home.\nBack to the Color Kingdom.");
                break;
            default:
                LoadGame();
                break;
        }
        _messageIndex += 1;
    }

}
