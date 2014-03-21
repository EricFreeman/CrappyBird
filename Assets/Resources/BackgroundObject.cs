using UnityEngine;

namespace Assets.Resources
{
    public class BackgroundObject
    {
        public GameObject GameObject;
        public float MoveSpeed;

        public float MaxHeight;
        public float MinHeight;

        public float MinScale;

        private float _z;

        public static BackgroundObject Create(Sprite sprite, float minHeight, float maxHeight, float minSpeed, float maxSpeed, float z, float minScale = 1f)
        {
            var cloudObj = new BackgroundObject {GameObject = new GameObject()};
            cloudObj.GameObject.AddComponent("SpriteRenderer");
            cloudObj.MaxHeight = maxHeight;
            cloudObj.MinHeight = minHeight;
            cloudObj._z = z;
            cloudObj.MinScale = minScale;
            var s = cloudObj.GameObject.GetComponent<SpriteRenderer>();
            s.sprite = sprite;

            s.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(minHeight, maxHeight), 1f);
            s.transform.localScale = new Vector3(Random.Range(minScale, 1f), Random.Range(minScale, 1f), Random.Range(minScale, 1f));

            cloudObj.MoveSpeed = Random.Range(minSpeed, maxSpeed);

            return cloudObj;
        }

        public void Update()
        {
           GameObject.transform.position += Vector3.left * MoveSpeed;

           if (GameObject.transform.position.x < -11.5)
            {
                GameObject.transform.position = new Vector3(Random.Range(10.5f, 12), Random.Range(MinHeight, MaxHeight), 1f);
                GameObject.transform.localScale = new Vector3(Random.Range(MinScale, 1f), Random.Range(MinScale, 1f), Random.Range(MinScale, 1f));
                MoveSpeed = Random.Range(.01f, .03f);
            }
        }
    }
}
