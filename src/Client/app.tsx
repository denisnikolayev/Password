import * as React from "react"
import {render} from "react-dom";
import "babel-polyfill";
import * as $ from "jquery";

$.post("/api/ping",
    {},
    data => {
        render(<h1>Hello world {data}</h1>, document.getElementById("app"));
    });
