document.addEventListener('DOMContentLoaded', () => {
   document.getElementById("dogBtn").addEventListener('click', displayDoggoAsync);
   document.getElementById('ratesBtn').addEventListener('click', getRates);

});

function getRates() {
   fetch('https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_28rQwT3ktxntui98HJuOnnHcgaW5XLAbGVrlmTJW')
      .then((response) => {
         return response.json();
      })
      .then((data) => {
         const rates = data.data;
         const currencyDiv = document.getElementById('currency');
         currencyDiv.innerHTML = '';  // Clear previous content
         //console.log(rates);
         for (key in rates) {
            const value = rates[key];
            console.log(`${key} - ${value}`);
            const rateDiv = document.createElement('div');
            rateDiv.textContent = `${key} - ${value}`;
            currencyDiv.appendChild(rateDiv);

         }
      })
      .catch(error => console.log('Error fetching rates', error));
}

async function displayDoggoAsync() {
   const API_URL = 'https://dog.ceo/api/breeds/image/random';

   // asynchronous communication
   let response = await fetch(API_URL)
   let json = await response.json();
   const img = document.createElement('img'); // create a new html element
   img.src = await json.message; // add the src for the picture
   const dogImg = document.getElementById('dogImg'); //connect to the html
   dogImg.appendChild(img); // add the image as a child of the dogImg element 

   //async and await the same as .then but newer syntax
}