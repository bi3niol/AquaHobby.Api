import React, { Component } from "react"

export default class AquariumNavView extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        var content = <div />;
        if (props.Aquarium) {
            content = <div className="card w-100">
                <h3 class="card-header">{props.Aquarium.Name}</h3>
                <div className="card-block">
                </div>
            </div>;
        }

        return (
            { content }
        );
    }
}