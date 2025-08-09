import React from 'react';
import ListOfPlayer from './Components/ListOfPlayers';
import IndianPlayer from './Components/IndianPlayer';

function App() {
  const flag = false; // Change to false to see the other output

  if (flag) {
    // When flag is true, display the list of players and filtered scores
    return (
      <div>
        <h1>List of Players</h1>
        <ListOfPlayer />
      </div>
    );
  } else {
    // When flag is false, display the Indian players components
    return (
      <div>
        <h1>Indian Players</h1>
        <IndianPlayer />
      </div>
    );
  }
}

export default App;