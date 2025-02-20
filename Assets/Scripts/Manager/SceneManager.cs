using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환을 위한 네임스페이스

public class SceneController : MonoBehaviour
{
    // 씬 로딩에 대한 상태를 추적 (로딩 중, 로딩 완료)
    private bool isSceneLoading = false;

    private void Update()
    {
        // 예시로 Esc 키를 누르면 게임 종료 씬으로 이동
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene("MainMenu");  // MainMenu 씬으로 전환
        }
    }

    // 씬 로드 함수
    public void LoadScene(string sceneName)
    {
        if (isSceneLoading) return;  // 씬 로딩 중이면 반복해서 로드하지 않음

        isSceneLoading = true;  // 씬 로딩 시작

        // 씬을 비동기적으로 로드
        SceneManager.LoadSceneAsync(sceneName).completed += OnSceneLoaded;
    }

    // 씬 로딩 완료 후 호출될 콜백 함수
    private void OnSceneLoaded(AsyncOperation obj)
    {
        isSceneLoading = false;  // 씬 로딩 완료

        // 씬 로딩 후 추가적인 작업을 여기에 할 수 있음
        Debug.Log("Scene Loaded: " + SceneManager.GetActiveScene().name);
    }

    // 특정 씬을 재시작하는 함수
    public void RestartCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;  // 현재 씬 이름
        LoadScene(currentScene);  // 해당 씬 다시 로드
    }

    // 게임을 종료하고, 특정 씬으로 돌아가는 함수
    public void GoToMainMenu()
    {
        LoadScene("MainMenu");  // "MainMenu" 씬으로 전환
    }

    // 씬을 완전히 언로드하는 함수
    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);  // 특정 씬 언로드
    }
}