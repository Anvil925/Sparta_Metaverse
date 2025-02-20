using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactionUI; // "F 키를 눌러주세요" UI 오브젝트
    private bool isPlayerInRange = false;

    private void Start()
    {
        interactionUI.SetActive(false); // 처음에는 UI 숨김
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionUI.SetActive(true); // UI 표시
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionUI.SetActive(false); // UI 숨김
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("상호작용 실행!");
        interactionUI.SetActive(false); // UI 숨김
    }
}