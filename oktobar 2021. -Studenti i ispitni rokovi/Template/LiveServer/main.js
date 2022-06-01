
import { Fakultet } from "./Fakultet.js"

var mainDiv=document.createElement("div")
mainDiv.className="mainDiv";
document.body.appendChild(mainDiv);

var glavniDiv=document.createElement("div")
glavniDiv.className="glavniDiv";
mainDiv.appendChild(glavniDiv);


/*fetch("https://localhost:5001/Ispit/PreuzmiProdavnice").then(p => {
    p.json().then(data => {
        data.forEach(pk => {*/
const f = new Fakultet(1,'davor');
f.crtajFakultet(glavniDiv);
            /*});
        });
});*/

