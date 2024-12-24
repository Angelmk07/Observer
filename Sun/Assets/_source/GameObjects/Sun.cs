using UnityEditor.VersionControl;
using UnityEngine;

namespace Assets._source.Observer
{
    internal class Sun : EarthObjectStats
    {
        [SerializeField] private float totalDayDuration = 24.0f;
        [SerializeField] private Vector2 startpoint;
        [SerializeField] private Vector2 morning;
        [SerializeField] private Vector2 day;
        [SerializeField] private Vector2 evening;
        [SerializeField] private Vector2 finish;
        [SerializeField] private float speedLerp = 1.0f;

        private Vector2 currentStart;   
        private Vector2 currentTarget;  
        private float transitionTime;   
        private float phaseDuration;
        private Vector2 currentVelocity;
        [SerializeField]private string currentPhase;    

        private void Start()
        {
            transform.position = startpoint;
            transitionTime = 0.0f;
        }



        private void SetPhase(string phaseName, Vector2 start, Vector2 target, float duration)
        {
            currentPhase = phaseName;
            currentStart = start;
            currentTarget = target;
            phaseDuration = duration;
            transitionTime = 0.0f;
        }

        protected override void Update()
        {
            base.Update();

            if (transitionTime < phaseDuration)
            {
                transitionTime += Time.deltaTime;
                float t = Mathf.Clamp01(transitionTime / phaseDuration);
                transform.position = Vector2.Lerp(currentStart, currentTarget, t*Vector2.Distance(currentStart,currentTarget));
            }
            else
            {
                transitionTime = phaseDuration;
            }
        }





        protected override void Night()
        {
            SetPhase("Night", transform.position, startpoint, totalDayDuration / 5);
        }

        protected override void Morning()
        {
            SetPhase("Morning", transform.position, morning, totalDayDuration / 5);
        }

        protected override void Day()
        {
            SetPhase("Day", transform.position, day, totalDayDuration / 5);
        }

        protected override void Evening()
        {
            SetPhase("Evening", transform.position, evening, totalDayDuration / 5);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(startpoint, 0.5f);
            Gizmos.DrawSphere(morning, 0.5f);
            Gizmos.DrawSphere(day, 0.5f);
            Gizmos.DrawSphere(evening, 0.5f);
            Gizmos.DrawSphere(finish, 0.5f);
        }

        protected override void AfterEvening()
        {
            SetPhase("AfterEvening", transform.position, finish, totalDayDuration / 4);
        }
    }
}
