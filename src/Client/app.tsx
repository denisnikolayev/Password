import * as React from "react"
import { render } from "react-dom";
import { Router, Route, Link, browserHistory, IndexRoute } from "react-router"
//import "babel-polyfill";
import * as $ from "jquery";

import {Master} from "./pages/Master"
import {Home} from "./pages/Home/Home"

$.post("/api/ping",
    {},
    () => {
        render(
            <Router history={browserHistory}>
                <Route path="/" component={Master}>
                    <IndexRoute component={Home}/>
                </Route>
            </Router>,
            document.getElementById("app")
        );
    });
