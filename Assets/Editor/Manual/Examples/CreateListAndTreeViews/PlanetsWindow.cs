using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Manual.Examples.CreateListAndTreeViews
{
    public class PlanetsWindow : EditorWindow
    {
        [SerializeField] protected VisualTreeAsset uxml;

        protected interface IPlanetOrGroup
        {
            public string Name { get; }
            public bool Populated { get; }
        }

        protected class Planet : IPlanetOrGroup
        {
            public string Name { get; }
            public bool Populated { get; }

            public Planet(string name, bool populated = false)
            {
                Name = name;
                Populated = populated;
            }
        }

        protected class PlanetGroup : IPlanetOrGroup
        {
            public string Name { get; }

            public bool Populated
            {
                get
                {
                    var anyPlanetPopulated = false;
                    foreach (Planet planet in Planets)
                    {
                        anyPlanetPopulated |= planet.Populated;
                    }

                    return anyPlanetPopulated;
                }
            }

            public readonly IReadOnlyList<Planet> Planets;

            public PlanetGroup(string name, IReadOnlyList<Planet> planets)
            {
                this.Name = name;
                this.Planets = planets;
            }
        }

        protected static readonly List<PlanetGroup> planetGroups = new()
        {
            new PlanetGroup("Inner Planets", new List<Planet>()
            {
                new Planet("Mercury"),
                new Planet("Venus"),
                new Planet("Earth", true),
                new Planet("Mars")
            }),
            new PlanetGroup("Outer Planets", new List<Planet>()
            {
                new Planet("Jupiter"),
                new Planet("Saturn"),
                new Planet("Uranus"),
                new Planet("Neptune")
            })
        };

        protected static List<Planet> Planets
        {
            get
            {
                var retVal = new List<Planet>(8);
                foreach (var group in planetGroups)
                {
                    retVal.AddRange(group.Planets);
                }

                return retVal;
            }
        }

        protected static IList<TreeViewItemData<IPlanetOrGroup>> TreeRoots
        {
            get
            {
                int id = 0;
                var roots = new List<TreeViewItemData<IPlanetOrGroup>>(planetGroups.Count);
                foreach (var group in planetGroups)
                {
                    var planetsInGroup = new List<TreeViewItemData<IPlanetOrGroup>>(group.Planets.Count);
                    foreach (var planet in group.Planets)
                    {
                        planetsInGroup.Add(new TreeViewItemData<IPlanetOrGroup>(id++, planet));
                    }

                    roots.Add(new TreeViewItemData<IPlanetOrGroup>(id++, group, planetsInGroup));
                }

                return roots;
            }
        }
    }
}