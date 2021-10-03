using System;
using System.Collections.Generic;
using System.Linq;

namespace Environment.Pool
{
    public class PoolRoot
    {
        public bool Overable => mOverCapacity;
        public int Capacity => mCapacity;
        public int Count => mInstance.Count;
        public int UsingCount => mInstance.Count(i => !i.Free);

        private bool mOverCapacity;
        private int mCapacity;
        private readonly List<IPoolObject> mInstance;
        private readonly Func<PoolRoot, IPoolObject> mCreator;

        /// <summary>
        /// The init point of pool.
        /// </summary>
        /// <param name="capacity">The max number of pool</param>
        /// <param name="instanceCreator">The function to create object</param>
        /// <param name="overCapacity">Does it allow to over capacity</param>
        public PoolRoot(int capacity, Func<PoolRoot, IPoolObject> instanceCreator, bool overCapacity = false)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException($"You can not give a capacity lower than 0.");

            mCapacity = capacity;
            mOverCapacity = overCapacity;
            mCreator = instanceCreator;
            
            mInstance = new List<IPoolObject>();
            for (var i = 0; i < capacity; i++)
            {
                var ins = instanceCreator(this);
                ins.OnInstanced(this);
                mInstance.Add(ins);
            }
        }

        public void SetCapacity(int capacity, bool overCapacity = false)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException($"You can not give a caoacity lower than 0.");

            mCapacity = capacity;
            mOverCapacity = overCapacity;
        }

        public IPoolObject GetObject()
        {
            var o = mInstance.Find(t => t.Free);

            if (o == null && mOverCapacity)
            {
                o = mCreator(this);
                mInstance.Add(o);
                
                o.OnInstanced(this);
            }
            
            o?.OnUsed();

            return o;
        }

        public T GetObject<T>() where T : class, IPoolObject
        {
            return GetObject() as T;
        }
        
        public bool TryGetObject(out IPoolObject obj)
        {
            obj = GetObject();
            return obj != null;
        }
        
        public bool TryGetObject<T>(out T obj) where T : class, IPoolObject
        {
            obj = GetObject() as T;
            return obj != null;
        }

        public void FreeObject(IPoolObject obj)
        {
            if (!mInstance.Exists(m => m.Equals(obj)))
                throw new ArgumentException("You can not use this pool to free this object");
            
            obj.OnFree();

        }

        public void FreeAllObject()
        {
            mInstance.ForEach(i =>
            {
                if (i.Free) return;
                FreeObject(i);
            });
        }

    }
}