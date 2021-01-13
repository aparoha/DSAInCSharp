using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.SystemDesign.ConsistentHashing
{
    //https://www.ably.io/blog/implementing-efficient-consistent-hashing
    //http://tom-e-white.com/2007/11/consistent-hashing.html
    //https://www.akamai.com/us/en/multimedia/documents/technical-publication/consistent-hashing-and-random-trees-distributed-caching-protocols-for-relieving-hot-spots-on-the-world-wide-web-technical-publication.pdf
    //https://www.acodersjourney.com/system-design-interview-consistent-hashing/
    //https://www.toptal.com/big-data/consistent-hashing
    //https://www.acodersjourney.com/system-design-interview-consistent-hashing/
    class ConsistentHash
    {
        private readonly SortedDictionary<uint, Server> _hashRing;
        private readonly int _numberOfReplicas; // The number of virtual nodes
        public ConsistentHash(int numberOfReplicas, List<Server> servers)
        {
            _numberOfReplicas = numberOfReplicas;
            _hashRing = new SortedDictionary<uint, Server>();
            if(servers != null)
            foreach(Server s in servers)
            {
                    AddServerToHashRing(s);
            }
        }
        public void AddServerToHashRing(Server server)
        {
            for(int i=0; i < _numberOfReplicas; i++)
            {
                //Fuse the server ip with the replica number
                string serverIdentity = String.Concat(server.IpAddress, ":", i);
                //Get the hash key of the server
                uint hashKey = FNVHash.To32BitFnv1aHash(serverIdentity);
                //Insert the server at the hashkey in the Sorted Dictionary
                _hashRing.Add(hashKey, server);
            }
        }
        public void RemoveServerFromHashRing(Server server)
        {
            for (int i = 0; i < _numberOfReplicas; i++)
            {
                //Fuse the server ip with the replica number
                string serverIdentity = String.Concat(server.IpAddress, ":", i);
                //Get the hash key of the server
                uint hashKey = FNVHash.To32BitFnv1aHash(serverIdentity);
                //Insert the server at the hashkey in the Sorted Dictionary
                _hashRing.Remove(hashKey);
            }
        }
        // Get the Physical server where a key is mapped to
        public Server GetServerForKey(String key)
        {
            Server serverHoldingKey;
            if(_hashRing.Count==0)
            {
                return null;
            }
            // Get the hash for the key
            uint hashKey = FNVHash.To32BitFnv1aHash(key);
            if(_hashRing.ContainsKey(hashKey))
            {
                serverHoldingKey = this._hashRing[hashKey];
            }
            else
            {
                uint[] sortedKeys = _hashRing.Keys.ToArray();
                //Find the first server key greater than  the hashkey
                uint firstServerKey = sortedKeys.FirstOrDefault(x => x >= hashKey);
                // Get the Server at that Hashkey
                serverHoldingKey = _hashRing[firstServerKey];
            }
            return serverHoldingKey;
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> rackServers = new List<Server> {new Server("10.0.0.1"), new Server("10.0.0.2")};
            int numberOfReplicas = 1;
            ConsistentHash serverDistributor = new ConsistentHash(numberOfReplicas, rackServers);
            //add a new server to the mix
            Server newServer = new Server("10.0.0.3");
            serverDistributor.AddServerToHashRing(newServer);
            //Assume you have a key "key0"
            Server serverForKey = serverDistributor.GetServerForKey("key0");
            Console.WriteLine("Server: " + serverForKey.IpAddress + " holds key: Key0");
            // Now remove a server
            serverDistributor.RemoveServerFromHashRing(newServer););
            // Now check on which server "key0" landed up
            serverForKey = serverDistributor.GetServerForKey("key0");
            Console.WriteLine("Server: " + serverForKey.IpAddress + " holds key: Key0");
        }
    } 
    */
}
