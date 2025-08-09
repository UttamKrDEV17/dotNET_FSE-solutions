import React from 'react';
import './App.css'; // Assuming you have some basic CSS in App.css

function App() {
  // An object of a single office to display details
  const office = {
    Name: 'DBS',
    Rent: 50000,
    Address: 'Chennai'
  };

  // An array of office objects to loop through
  const officesList = [
    { name: 'DBS', rent: 50000, address: 'Chennai' },
    { name: 'TCS', rent: 75000, address: 'Bangalore' },
    { name: 'Wipro', rent: 55000, address: 'Hyderabad' }
  ];

  // Function to determine the text color based on rent
  const getRentColor = (rent) => {
    return rent <= 60000 ? 'red' : 'green';
  };

  return (
    <div className="App">
      {/* Page Heading */}
      <h1>Office Space, at Affordable Range</h1>

      {/* Displaying a single office space */}
      <div style={{ padding: '20px', border: '1px solid #ccc', margin: '20px' }}>
        {/* Office space image */}
        <img src="https://tse2.mm.bing.net/th/id/OIP.Vg1vCj0lZ3GurmHHOlI9iwHaE7?rs=1&pid=ImgDetMain&o=7&rm=3" alt="Office Space" style={{ width: '200px' }} />
        <h3>Name: {office.Name}</h3>
        <h4 style={{ color: getRentColor(office.Rent) }}>Rent: Rs. {office.Rent}</h4>
        <h4>Address: {office.Address}</h4>
      </div>
      <hr />

      {/* Displaying a list of office spaces */}
      <h2>Additional Office Spaces</h2>
      {officesList.map((item, index) => (
        <div key={index} style={{ padding: '10px', border: '1px solid #eee', margin: '10px' }}>
          <h3>Name: {item.name}</h3>
          <h4 style={{ color: getRentColor(item.rent) }}>Rent: Rs. {item.rent}</h4>
          <h4>Address: {item.address}</h4>
        </div>
      ))}
    </div>
  );
}

export default App;