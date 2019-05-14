/// <reference path="../typings/altv-client.d.ts"/>

import alt from 'alt';
import game from 'natives';

export default async () => {
    alt.on("connectionComplete", () => {
        loadIPLs();
    });

    alt.log("Module \'PlayerConnect\' successfully loaded.");
};

function loadIPLs() {
    alt.log("Loading needed IPLs ...");
    /*
    * River under TrainCrash Bridge
    */
    alt.requestIpl("canyonriver01");
    alt.requestIpl("canyonrvrdeep");

    /*
    * River near Sandy Shores (Caravan Crash - Trevor Mission)
    */
    alt.requestIpl("CS3_05_water_grp1");
}


