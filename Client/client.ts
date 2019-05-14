/// <reference path="typings/altv-client.d.ts"/>

import alt from 'alt';
import game from 'natives';

import playerConnect from 'scripts/PlayerConnect';
import clientCommands from 'scripts/ClientCommands';

const init = async () => {
    try {
        let count = 0;
        await playerConnect();
        count++;
        await clientCommands();
        count++;

        alt.log(`All ${count} scripts loaded successfully.`);
    }
    catch (Exception)
    {
        alt.logError(`Failed to load scripts.\nMessage: ${Exception.Message}`);
        game.freezeEntityPosition(alt.getLocalPlayer().scriptID, true);
        game.doScreenFadeOut(0);
        alt.logError(`Blocking spawning! Try to reconnect, if the problem happens again please contact the serverowner.`);
    }
};
init();