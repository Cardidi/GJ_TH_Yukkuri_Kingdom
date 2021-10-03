using UnityEngine;

namespace Environment.Pool
{
    public class PoolMonoBehaviour : MonoBehaviour, IPoolObject
    {
        public bool Free { get; private set; }
        public PoolRoot Pool { get; private set; }

        public string RandomID { get; private set; }

        public void FreeSelf()
        {
            Pool.FreeObject(this);
        }
        
        public virtual void OnInstanced(PoolRoot pool)
        {
            Pool = pool;
            Free = true;
            RandomID = RamdomTools.RandomString(10);
        }

        public virtual void OnUsed()
        {
            Free = false;
        }

        public virtual void OnFree()
        {
            Free = true;
        }

        public override bool Equals(object other)
        {
            if (other is PoolMonoBehaviour)
                return Equals((PoolMonoBehaviour) other);
            
            return false;
        }

        protected bool Equals(PoolMonoBehaviour other)
        {
            return base.Equals(other) && RandomID == other.RandomID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (RandomID != null ? RandomID.GetHashCode() : 0);
            }
        }
    }
}