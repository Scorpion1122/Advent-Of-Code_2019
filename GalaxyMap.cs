using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode_2019
{
    public class GalaxyMap
    {
        private Dictionary<string, CelectialObject> celectialObjects = new Dictionary<string, CelectialObject>();

        public void LoadDataFromFile(string path)
        {
            LoadDataFromString(File.ReadAllText(FileUtility.GetApplicationPath() + path));
        }

        public void LoadDataFromString(string data)
        {
            string[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var orbit in lines)
            {
                string[] orbitData = orbit.Split(')');
                InsertOrbit(orbitData[0], orbitData[1]);
            }
        }

        private void InsertOrbit(string origin, string target)
        {
            CelectialObject originObject = GetCelectialObject(origin);
            CelectialObject targetObject = GetCelectialObject(target);

            originObject.AddChild(targetObject);
            targetObject.SetParent(originObject);
        }

        private CelectialObject GetCelectialObject(string name)
        {
            CelectialObject result;
            if (!celectialObjects.TryGetValue(name, out result))
            {
                result = new CelectialObject(name);
                celectialObjects[name] = result;
            }
            return result;
        }

        public int GetTotalOrbitCount()
        {
            int result = 0;
            foreach(var celestialObject in celectialObjects.Values)
            {
                CelectialObject parent = celestialObject.Parent;
                while (parent != null)
                {
                    result++;
                    parent = parent.Parent;
                }
            }
            return result;
        }

        public int GetShortestPath(string fromName, string targetName)
        {
            CelectialObject from = GetCelectialObject(fromName);
            CelectialObject target = GetCelectialObject(targetName);

            Dictionary<CelectialObject, int> fromToRoot = TraverseUpAndSaveDepth(from);
            Dictionary<CelectialObject, int> targetToRoot = TraverseUpAndSaveDepth(target);

            int minDistance = int.MaxValue;
            foreach (var parent in fromToRoot)
            {
                if (!targetToRoot.TryGetValue(parent.Key, out int depth))
                    continue;

                int distance = depth + parent.Value;
                if (distance < minDistance)
                    minDistance = distance;
            }
            return minDistance;
        }

        private Dictionary<CelectialObject, int> TraverseUpAndSaveDepth(CelectialObject from)
        {
            Dictionary<CelectialObject, int> result = new Dictionary<CelectialObject, int>();
            CelectialObject parent = from.Parent;
            int depth = 0;
            while (parent != null)
            {
                result.Add(parent, depth);
                depth++;
                parent = parent.Parent;
            }
            return result;
        }
    }
}