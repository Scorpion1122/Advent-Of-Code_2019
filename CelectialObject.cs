using System.Collections.Generic;

namespace AdventOfCode_2019
{
    public class CelectialObject
    {
        public CelectialObject Parent { get; private set; } 
        public string Name { get; private set; }

        private List<CelectialObject> children = new List<CelectialObject>();

        public CelectialObject(string name)
        {
            Name = name;
        }

        public void SetParent(CelectialObject parent)
        {
            Parent = parent;
        }

        public void AddChild(CelectialObject child)
        {
            children.Add(child);
        }
    }
}