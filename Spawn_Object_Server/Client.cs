using FivePD.API;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace Test
{
    internal class TestCallout: Callout
    {
        private Prop _debris;

        public TestCallout() 
        {
            //Use this to call the delete function on the server
            //BaseScript.TriggerServerEvent("Callout:SV:DeleteDebris", _debris.NetworkId);
        }

        [EventHandler("Callout:CL:DebrisSpawned")]
        private async void RecievedDebrisData(int netId)
        {
            int timeout = 60000; // 1 min timeout
            _debris = (Prop)Entity.FromNetworkId(netId);

            int startTimer = GetGameTimer();
            bool isTimeout = false;

            while(_debris == null && !isTimeout)
            {
                //Didnt find the debris nearby wait a bit before searching again
                await BaseScript.Delay(2500);

                //Search for debris
                _debris = (Prop)Entity.FromNetworkId(netId);

                //stop looking if we pass 1 minute and cant find the debris and end Callout
                if(GetGameTimer() - startTimer > timeout) { isTimeout = true; EndCallout(); }

            }
        }
    }
}
