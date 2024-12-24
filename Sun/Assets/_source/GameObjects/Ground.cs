using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._source
{
    internal class Ground : EarthObjectStats
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Color _dayC;
        [SerializeField] private Color _evningC;
        [SerializeField] private Color _morningC;
        [SerializeField] private Color _nightC;

        protected override void AfterEvening()
        {
            camera.backgroundColor = _nightC;
        }

        protected override void Day()
        {
            camera.backgroundColor = _dayC;
        }

        protected override void Evening()
        {
            camera.backgroundColor = _evningC;
        }

        protected override void Morning()
        {
            camera.backgroundColor = _morningC;
        }

        protected override void Night()
        {
            camera.backgroundColor = _nightC;
        }
    }
}
