﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UDBase_Project.Scripts.Logics {
	public class Spawner : MonoBehaviour {
		[System.Serializable]
		public struct Vector3Int {
			public int X, Y, Z;
		}
		
		[System.Serializable]
		public class Block {
			public Vector3Int Position;
		}
		
		public Transform Trigger;
		public float Distance = 10.0f;
		public float ClearRange = 0.5f;
		public GameObject ObstaclePrefab;
		public int MinObstacles;
		public int MaxObstacles;
		public List<Block> Blocks = new List<Block>();

		Vector3Int FindPosition() {
			return ConvertToIntVector(Trigger.position);
		}

		void Update() {
			TryGenerate();
		}

		Vector3Int ConvertToIntVector(Vector3 pos) {
			var normPos = pos / Distance;
			return new Vector3Int() {
				X = Mathf.RoundToInt(normPos.x), 
				Y = Mathf.RoundToInt(normPos.y), 
				Z = Mathf.RoundToInt(normPos.z)
			};
		}

		bool IsAlreadyGenerated(Vector3Int pos) {
			foreach (var block in Blocks) {
				if ((block.Position.X == pos.X)
					&& (block.Position.Y == pos.Y)
				    && (block.Position.Z == pos.Z)) {
					return true;
				}
			}
			return false;
		}

		void AddBlock(Vector3Int pos) {
			Blocks.Add(new Block(){Position = pos});
		}
		
		void TryGenerate() {
			var normPos = FindPosition();
			if (IsAlreadyGenerated(normPos)) {
				return;
			}
			AddBlock(normPos);
			StartCoroutine(Generate(Trigger.position));
		}

		float LimitValue(float value) {
			if (value >= 0.0f) {
				return Math.Max(value, ClearRange);
			} else {
				return Math.Min(value, ClearRange);
			}
		}
		
		Vector3 FindGeneratePosition(Vector3 originPos) {
			var vec = Random.insideUnitSphere;
			vec.x = LimitValue(vec.x);
			vec.y = LimitValue(vec.y);
			vec.z = LimitValue(vec.z);
			return originPos + vec * Distance;

		}
		
		IEnumerator Generate(Vector3 pos) {
			var obstacles = Random.Range(MinObstacles, MaxObstacles + 1);
			for (int i = 0; i < obstacles; i++) {
				var generatePos = FindGeneratePosition(pos);
				Instantiate(ObstaclePrefab, generatePos, Quaternion.identity);
				yield return null;
			}
		}
	}
}
