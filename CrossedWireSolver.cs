using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AdventOfCode_2019;
using AdventOfCode_2019.Mathematics;

namespace AdventOfCode_2019
{
    public class CrossedWireSolver
    {
        private List<Wire> wires = new List<Wire>();
        private List<Intersection> intersections = new List<Intersection>();

        public void ParseFileData(string dataPath)
        {
            wires.Clear();
            intersections.Clear();

            string[] lines = File.ReadAllLines(FileUtility.GetApplicationPath() + dataPath);
            for (int i = 0; i < lines.Length; i++)
            {
                Wire wire = new Wire(lines[i]);
                wires.Add(wire);
            }
            FindAllIntersections();
        }

        private void FindAllIntersections()
        {
            for (int i = 0; i < wires.Count; i++)
            {
                for (int j = i + 1; j < wires.Count; j++)
                {
                    FindAllIntersections(wires[i], wires[j]);
                }
            }
        }

        private void FindAllIntersections(Wire wireOne, Wire wireTwo)
        {
            foreach (var coordinate in wireOne.coordinates)
            {
                if (!wireTwo.coordinates.TryGetValue(coordinate.Key, out int otherIndex))
                    continue;
                intersections.Add(new Intersection()
                    {
                        coordinate = coordinate.Key,
                        travelDistanceWireOne = coordinate.Value,
                        travelDistanceWireTwo = otherIndex,
                    });
            }
        }

        public int GetDistanceToClosestIntersection()
        {
            int closestDistance = int.MaxValue;
            for (int i = 0; i < intersections.Count; i++)
            {
                Intersection intersection = intersections[i];
                int distanceToOrigin = intersection.coordinate.SqrMagnitude;
                if (distanceToOrigin < closestDistance)
                    closestDistance = distanceToOrigin;
            }
            return closestDistance;
        }

        public int GetDistanceToIntersectionWithShortestPath()
        {
            int shortestPath = int.MaxValue;
            for (int i = 0; i < intersections.Count; i++)
            {
                Intersection intersection = intersections[i];
                int pathDistance = intersection.travelDistanceWireOne + intersection.travelDistanceWireTwo;
                if (pathDistance < shortestPath)
                    shortestPath = pathDistance;
            }
            return shortestPath;
        }
    }
}