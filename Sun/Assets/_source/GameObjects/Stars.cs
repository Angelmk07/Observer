using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._source
{
    internal class Stars : EarthObjectStats
    {
        private SpriteRenderer _renderer;
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        protected override void Day()
        {
            _renderer.color = new Color(
                _renderer.color.r,
                _renderer.color.g,
                _renderer.color.b,
                Mathf.Lerp(_renderer.color.a,0, lerptime*Time.deltaTime)
                );
        }

        protected override void Evening()
        {
            _renderer.color = new Color(
                _renderer.color.r,
                _renderer.color.g,
                _renderer.color.b,
                Mathf.Lerp(_renderer.color.a, 190, lerptime * Time.deltaTime)
                );
        }

        protected override void Morning()
        {
            _renderer.color = new Color(
                _renderer.color.r,
                _renderer.color.g,
                _renderer.color.b,  
                Mathf.Lerp(_renderer.color.a, 0.5f, lerptime * Time.deltaTime )
                );
        }

        protected override void Night()
        {
            _renderer.color = new Color(
                _renderer.color.r,
                _renderer.color.g,
                _renderer.color.b,
                Mathf.Lerp(_renderer.color.a, 255, lerptime * Time.deltaTime)
                );
        }

        protected override void AfterEvening()
        {
            _renderer.color = new Color(
               _renderer.color.r,
               _renderer.color.g,
               _renderer.color.b,
               Mathf.Lerp(_renderer.color.a, 255, lerptime * Time.deltaTime)
               );
        }
    }
}
