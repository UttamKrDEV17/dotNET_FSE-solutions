import React, { useState } from 'react';
import CurrencyConvertor from './components/CurrencyConvertor';
import './App.css';

function App() {
  const [counter, setCounter] = useState(0);

  // Method to increment the counter
  const increment = () => {
    setCounter(prevCounter => prevCounter + 1);
  };

  // Method to decrement the counter
  const decrement = () => {
    setCounter(prevCounter => prevCounter - 1);
  };

  // Method to say hello
  const sayHello = () => {
    console.log('Hello');
  };

  // Method to show a static message
  const staticMessage = () => {
    alert('This is a static message.');
  };

  // Button that invokes multiple methods
  const handleMultipleEvents = () => {
    increment(); 
    sayHello();
    staticMessage();
  };

  // Button with an argument
  const sayWelcome = (message) => {
    alert(message);
  };

  // Synthetic event handler
  const handleSyntheticEvent = (event) => {
    console.log('I was clicked'); 
    console.log(event.target);
  };

  return (
    <div className="App">
      <h1>React Event Handling Examples</h1>

      {/* Counter buttons */}
      <div>
        <h2>Counter: {counter}</h2>
        <button onClick={increment}>Increment</button>
        <button onClick={decrement}>Decrement</button>
      </div>
      <hr />

      {/* Button to invoke multiple methods */}
      <div>
        <button onClick={handleMultipleEvents}>Increase and Say Hello</button>
      </div>
      <hr />

      {/* Button with an argument */}
      <div>
        <button onClick={() => sayWelcome('Welcome!')}>Say Welcome</button>
      </div>
      <hr />

      {/* Synthetic event button */}
      <div>
        <button onClick={handleSyntheticEvent}>Synthetic Event Button</button>
      </div>
      <hr />

      {/* Currency Convertor component */}
      <CurrencyConvertor />
    </div>
  );
}

export default App;