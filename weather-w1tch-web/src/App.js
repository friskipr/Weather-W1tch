import './App.css';
import React from 'react';
import axios from 'axios';
import CitySelect from './City-Select/city-select';

class App extends React.Component {
  constructor(props) {
    super(props);   
    this.state = { cities: [], cityProfile: null };
  }

  onCityChange(data) { // get weather data from webapi
    axios.get(`http://localhost:43921/getweather?lat=${data.lat}&lon=${data.lon}`)
      .then(successResp => {
        successResp.data.location = data.location;
        this.setState({ cityProfile: successResp.data });
      })
      .catch(error => { })
  }

  render() {
      return (
          <div className="App">
            <header className="App-header">
            <h1>Weather W1tch</h1>
              <div>
              {this.state.cities.length > 0 &&
                <CitySelect cities={this.state.cities} onChange={e => this.onCityChange(e)} />
              }
            </div>
            <div>
              {this.state.cityProfile &&
                <div>
                  <h2>{this.state.cityProfile.location}</h2>
                  <p>Skycondition: {this.state.cityProfile.skyCondition}</p>
                  <p>Temperature: {this.state.cityProfile.tempC} / {this.state.cityProfile.tempF}</p>
                  <p>DewPoint: {this.state.cityProfile.dewPoint}</p>
                  <p>Humidity: {this.state.cityProfile.relativeHumidity}</p>
                  <p>Visibility: {this.state.cityProfile.visibility}</p>
                  <p>Wind: {this.state.cityProfile.wind}</p>
                  <p>Pressure: {this.state.cityProfile.pressure}</p>
                  <p>Updated on: {this.state.cityProfile.time}</p>
                </div>
              }
            </div>
            </header>                
          </div>
        );
  }
  
  componentDidMount() { // get city list from webapi
    axios.get("http://localhost:43921/getcity")
      .then(successResp => {
        this.setState({ cities: successResp.data });
      })
      .catch(error => { })
  }

}

export default App;