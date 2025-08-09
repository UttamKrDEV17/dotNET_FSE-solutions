import React, { useState } from 'react';

const CurrencyConvertor = () => {
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState('');

  // Fixed conversion rate for demonstration
  const conversionRate = 0.012;

  const handleRupeesChange = (event) => {
    setRupees(event.target.value);
  };

  // Handles the conversion of Rupees to Euro
  const convertToEuro = () => {
    const euroValue = parseFloat(rupees) * conversionRate;
    setEuro(euroValue.toFixed(2));
  };

  // Handles the form submission (in this case, the button click)
  const handleSubmit = (event) => {
    event.preventDefault();
    convertToEuro();
  };

  return (
    <div>
      <h2>Currency Convertor</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Indian Rupees (INR):
          <input
            type="number"
            value={rupees}
            onChange={handleRupeesChange}
          />
        </label>
        <br />
        <button type="submit">Convert to Euro</button>
      </form>
      {euro && <h3>Euro: €{euro}</h3>}
    </div>
  );
};

export default CurrencyConvertor;