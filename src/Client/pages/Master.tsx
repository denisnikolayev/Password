import * as React from "react"

export class Master extends React.Component<{}, {}> {
    render() {
        return (
            <div>
                <div>{this.props.children}</div>
            </div>
        );
    }
}