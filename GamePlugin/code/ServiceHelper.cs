﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GamePlugin
{
    public static class ServiceHelper
    {
        public static IEnumerable<Type> knownTypes = new List<Type>{ 
            typeof(MoveMetadata),
            typeof(PlayerMoveMetadata)
        };
        public static T GetTypedObjectFromJson<T>(string json)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), knownTypes);
                stream.Position = 0;
                return (T)serializer.ReadObject(stream);
            }
        }
        public static string GetJsonStringFromObject<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType(), knownTypes);
                stream.Position = 0;
                serializer.WriteObject(stream, obj);
                byte[] byteArray = stream.ToArray();
                return Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }
        }
    }
}
