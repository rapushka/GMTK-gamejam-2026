using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    // Just a Marker to show, that the class should be accessed through ServiceLocator
    public interface IService { }

    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> Map = new();

        public static void Set<TService>(TService service)
            where TService : IService
        {
            var serviceType = typeof(TService);
#if DEBUG
            if (Map.ContainsKey(serviceType))
                Debug.LogError($"[ServiceLocator] Trying to overwrite Service {serviceType.Name}!");
#endif

            Map[serviceType] = service;
        }

        public static TService Get<TService>()
            where TService : IService
        {
            var serviceType = typeof(TService);
#if DEBUG
            if (!Map.ContainsKey(serviceType))
                Debug.LogError($"[ServiceLocator] There's no {serviceType.Name} registered!");
#endif
            return (TService)Map[serviceType];
        }
    }
}