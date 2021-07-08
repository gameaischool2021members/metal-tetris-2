using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _UISceneindex = 1;
    private void Awake()
    {
        SceneManager.LoadSceneAsync(_UISceneindex, LoadSceneMode.Additive);
    }

}
