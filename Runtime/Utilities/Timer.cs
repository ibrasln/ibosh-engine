using System;
using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    /// <summary>
    /// A simple timer class that triggers an event when the set duration elapses.
    /// </summary>
    /// <remarks>
    /// The Timer class allows you to start, stop, and track time in seconds. It raises the OnTimerDone event once the time runs out.
    /// The Tick method must be called regularly (e.g., from an Update loop) to check the timer's progress.
    /// </remarks>
    public class Timer
    {
        public event Action OnTimerDone;

        private float _startTime;
        private readonly float _duration;
        private float _targetTime;
        private bool _isActive;

        public Timer(float duration)
        {
            _duration = duration;
        }

        /// <summary>
        /// Starts the timer with the specified duration.
        /// </summary>
        public void StartTimer()
        {
            _startTime = Time.time;
            _targetTime = _startTime + _duration;
            _isActive = true;
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer() => _isActive = false;

        /// <summary>
        /// Checks if the timer has reached the target time and triggers the event if done.
        /// </summary>
        public void Tick()
        {
            if (!_isActive) return;

            if (!(Time.time >= _targetTime)) return;

            OnTimerDone?.Invoke();
            StopTimer();
        }
    }
}