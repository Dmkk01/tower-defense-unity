using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Waypoint waypoint;

    public Vector3 CurrentPointPosition => waypoint.GetWaypointPosition(_currentWaypointIndex);
    private int _currentWaypointIndex;
    
    private void Start() {
        _currentWaypointIndex = 0;
    }

    private void Update() {
        Move();
        if (CurrentPointPositionReached()) {
            UpdateCurrentPositionIndex();
        }
    }   

    private void Move() {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime);
    }

    private bool CurrentPointPositionReached() {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;

        if (distanceToNextPointPosition < 0.1f) {
            return true;
        }

        return false;
    }

    private void UpdateCurrentPositionIndex() {
        int lastWaypointIndex = waypoint.Points.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex) {
            _currentWaypointIndex++;
        }
    }
}
