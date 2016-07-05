import * as React from "react"
import {Link} from "react-router"

export class Home extends React.Component<{}, {}> {
    render() {
        return (
            <div>
                <div>
                    <Link to=""><span>Password Reset</span></Link>
                </div>
                <div>
                    <Link to=""><span>Account Unlock</span></Link>
                </div>
                <div>
                    <Link to=""><span>Login</span></Link>
                </div>
            </div>
        );
    }
}