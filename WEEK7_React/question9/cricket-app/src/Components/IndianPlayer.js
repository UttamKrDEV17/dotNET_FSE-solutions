import React from 'react';

const T20Players = ['First Player', 'Second Player', 'Third Player'];
const RanjiTrophyPlayers = ['Fourth Player', 'Fifth Player', 'Sixth Player'];

const IndianPlayer = () => {
  const allIndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

  // For Destructuring Odd Players
  const [first, , third, , fifth] = T20Players; // Example, based on the provided image

  return (
    <div>
      <h2>Odd Players</h2>
      <ul>
        <li>First : {first}</li>
        <li>Third : {third}</li>
        <li>Fifth : {fifth}</li>
      </ul>
      <hr />
      <h2>List of Indian Players Merged:</h2>
      <ul>
        {allIndianPlayers.map((player, index) => (
          <li key={index}>Mr. {player}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayer;