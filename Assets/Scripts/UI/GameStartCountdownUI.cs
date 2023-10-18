using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartCountdownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopup";
    [SerializeField] private TextMeshProUGUI countdownText;
    
    private Animator animator;
    private int previousCountdownNumber;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Update()
    {
        if (KitchenGameManager.Instance.IsCountdownToStart())
        {
            int countDownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
            countdownText.text = countDownNumber.ToString();

            if (previousCountdownNumber != countDownNumber)
            {
                previousCountdownNumber = countDownNumber;
                animator.SetTrigger(NUMBER_POPUP);
                SoundManager.Instance.PlayCountdownSound();
            }
        }
            
         
        
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
