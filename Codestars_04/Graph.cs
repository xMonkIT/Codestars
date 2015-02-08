using System;
using System.Collections.Generic;

namespace Codestars_04
{
    class Graph
    {
        List<string> points = new List<string>();
        List<List<bool>> linked = new List<List<bool>>();
        List<bool> visited = new List<bool>();
        List<string> shortcut;

        public void AddPoint(string pointName)
        {
            points.Add(pointName);
            visited.Add(false);
            linked.Add(new List<bool>());
            for (int i = 0; i < linked[0].Count; i++) linked[linked.Count - 1].Add(false);
            foreach (var list in linked) list.Add(false);
        }

        public void CreateLink(string firstPointName, string secondPointName)
        {
            if (!points.Contains(firstPointName)) AddPoint(firstPointName);
            if (!points.Contains(secondPointName)) AddPoint(secondPointName);
            int i = points.IndexOf(firstPointName), j = points.IndexOf(secondPointName);
            linked[i][j] = true;
            linked[j][i] = true;
        }

        public List<string> GetShortcut(string firstPointName, string secondPointName)
        {
            if (!points.Contains(firstPointName) || !points.Contains(secondPointName)) return null;
            if (firstPointName == secondPointName)
            {
                shortcut = new List<string>();
                shortcut.Add(firstPointName);
            }
            else
            {
                shortcut = null;
                for (int i = 0; i < visited.Count; i++) visited[i] = false;
                findPath(new List<string>(), firstPointName, secondPointName);
            }
            return shortcut;
        }

        private void findPath(List<string> path, string firstPointName, string secondPointName)
        {
            path.Add(firstPointName);
            visited[points.IndexOf(firstPointName)] = true;
            if (linked[points.IndexOf(firstPointName)][points.IndexOf(secondPointName)])
            {
                path.Add(secondPointName);
                if (shortcut == null || shortcut.Count > path.Count) shortcut = path;
            }
            else
                foreach (var point in points)
                    if (!visited[points.IndexOf(point)] && linked[points.IndexOf(firstPointName)][points.IndexOf(point)])
                        findPath(path, point, secondPointName);
        }

        public string[] GetPointsAsObjects()
        {
            return points.ToArray();
        }
    }
}
