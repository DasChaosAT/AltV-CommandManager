/// <reference path="../typings/altv-client.d.ts"/>

import alt from 'alt';
import game from 'natives';

export default async () => {

    alt.on("consoleCommand", (cmd, ...args) => {
        alt.emitServer("CONSOLE_Command", cmd, args);
    });

    alt.onServer("COMMAND_", () => {
        alt.log("Command not found!");
    });

    alt.onServer("COMMAND_HelloPlayer", (...args) => {
        helloPlayer(...args);
    });

    alt.onServer("COMMAND_test", (...args) => {
        alt.emitServer("COMMAND_CALLBACK_test", args);
    });

    alt.log("Module \'ClientCommands\' successfully loaded.");
};

function helloPlayer(...args) {
    if (args !== null && args !== undefined) {
        let print = "";

        for (let i = 0; i < args.length; i++) {
            print += ` ${args[i]}`;
        }

        alt.log(`Hello Player!${print}`);
    }
    else {
        alt.log("Hello Player!");
    }
}

