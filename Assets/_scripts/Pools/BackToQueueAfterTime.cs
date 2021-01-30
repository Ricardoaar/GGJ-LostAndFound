using UnityEngine;

namespace _scripts
{
    public class BackToQueueAfterTime : MonoBehaviour, IBackToQueue
    {
        [SerializeField] private float timeToBack;
        private float _currentTime;
        [SerializeField] private ParticlePool pool;

        private void OnEnable()
        {
            _currentTime = 0;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= timeToBack)
            {
                BackToQueue();
            }
        }

        public void BackToQueue()
        {
            if (pool != null)
            {
                pool.EnqueueObj(gameObject);
            }

            gameObject.SetActive(false);
        }

        public void SetPool(ObjectPool objPool)
        {
            pool = (ParticlePool) objPool;
        }
    }
}