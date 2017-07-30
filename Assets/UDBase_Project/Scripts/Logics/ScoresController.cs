using UDBase.Controllers.EventSystem;
using UnityEngine;
using UnityEngine.Events;

namespace UDBase_Project.Scripts.Logics {
	public class ScoresController : MonoBehaviour {
		public float TimeInterval = 5.0f;
		public int ScoresByTime = 5;
		public int ScoresByKill = 100;
		public int ScoresByEnergy = 50;
		public int ScoresByAsteroid = 25;
		[HideInInspector]
		public int Scores;

		public UnityEvent OnScoresChanged;

		float _timer;

		void OnEnable() {
			Events.Subscribe<EnemyDestroyed>(this, OnEnemyDestroyed);
			Events.Subscribe<AsteroidDestroyed>(this, OnAsteroidDestroyed);
			Events.Subscribe<EnergyCollected>(this, OnEnergyCollected);
		}

		void OnDisable() {
			Events.Unsubscribe<EnemyDestroyed>(OnEnemyDestroyed);
			Events.Unsubscribe<AsteroidDestroyed>(OnAsteroidDestroyed);
			Events.Unsubscribe<EnergyCollected>(OnEnergyCollected);
		}

		void OnEnemyDestroyed(EnemyDestroyed e) {
			AddScores(ScoresByKill);
		}

		void OnAsteroidDestroyed(AsteroidDestroyed e) {
			AddScores(ScoresByAsteroid);
		}

		void OnEnergyCollected(EnergyCollected e) {
			AddScores(ScoresByEnergy);
		}
		
		void Update() {
			if (!PlayerMark.Instance) {
				return;
			}
			if (_timer > TimeInterval) {
				_timer = 0.0f;
				AddScores(ScoresByTime);
			} else {
				_timer += Time.deltaTime;
			}
		}

		void AddScores(int value) {
			Scores += value;
			OnScoresChanged.Invoke();
		}
	}
}
