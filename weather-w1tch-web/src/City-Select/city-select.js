import './city-select.css';
import React from 'react';

function ListItem(props) {
    return <option lat={props.value.lat} lon={props.value.lon}>{props.value.city} - {props.value.country}</option>
}

export default class CitySelect extends React.Component {
    constructor(props) {
        super(props);
        this.state = { citySelected: {} };
    }

    getItems() { // Get city from webapi
        return this.props.cities.map(t =>
            <ListItem key={t.city} value={t} />
        );
    }

    handleChange = (e) => {
        if (e.target.value.indexOf('Select') > -1) return; // Prevent default option to continue

        this.setState({citySelected: e.target.value})
        this.props.onChange({
            lat: e.target.selectedOptions[0].getAttribute('lat'),
            lon: e.target.selectedOptions[0].getAttribute('lon'),
            location : e.target.value
        });
    }

    render() {
        return (
            <select name="City" className='city-input' onChange={this.handleChange} value={this.state.citySelected}>
                <option>Select city!</option>
                {this.getItems()}
            </select>
        );
    }
}