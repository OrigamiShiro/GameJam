using UnityEngine.SceneManagement;

namespace GameJam
{
    public static class SceneManager
    {
        public enum Scenes
        {
            MainMenu = 0,
            Level1,
            Level2,
        }
        
        public static void LoadScene(Scenes sceneId)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneId, LoadSceneMode.Single);
        }
    }
}
