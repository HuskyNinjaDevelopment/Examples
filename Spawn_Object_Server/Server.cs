using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server: BaseScript
    {
        public Server() { }

        [EventHandler("Callout:SV:SpawnDebris")]
        private void SpawnDebris([FromSource]Player player, Vector3 position, string modelName)
        {
            //Spawn Prop
            Prop debris = new Prop(CreateObject(GetHashKey(modelName), position.X, position.Y, position.Z, true, true, false));

            //Tell player who trigged event the netId
            player.TriggerEvent("Callout:CL:DebrisSpawned", debris.NetworkId);
        }

        [EventHandler("Callout:SV:DeleteDebris")]
        private void DeleteDebris(int netId)
        {
            //Get the prop
            Entity prop = Entity.FromNetworkId(netId);

            DeleteEntity(prop.Handle);
        }
    }
}
