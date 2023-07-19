document.addEventListener("DOMContentLoaded", function() {
  var button1 = document.getElementById('button1');
  var tbody1 = document.querySelector(".table1 tbody");
  var tbody2 = document.querySelector(".table2 tbody");
  var tbody3 = document.querySelector(".table3 tbody"); // Получаем tbody второй таблицы
  button1.addEventListener('click', function() {
    window.location.href = "main.html";
  });
  fetch('https://localhost:7269/viewtable1', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(response => {
    return response.json(); 
  }).then(data => {
    const slicedData = data.slice(); 
    console.log(slicedData);
    slicedData.sort((a, b) => a.id - b.id); // Сортировка по значению item.id
    slicedData.forEach(item => {
      var row = document.createElement("tr");
      row.innerHTML = `
        <td>${item.id}</td>
        <td>${item.recordDate}</td>
        <td>${item.branchId}</td>
        <td>${item.cropYear}</td>
        <td>${item.counterpartyId}</td>
        <td>${item.counterpartyName}</td>
        <td>${item.contactId}</td>
        <td>${item.product}</td>
        <td>${item.price}</td>
        <td>${item.process}</td>
        <td>${item.amount}</td>
        <td>${item.wetness}</td>
        <td>${item.garbage}</td>
        <td>${item.infection}</td>
      `;
      tbody1.appendChild(row);
    });
  });



  fetch('https://localhost:7269/viewtable2', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(response => {
    return response.json(); 
  }).then(data => {
    const slicedData = data.slice(); 
    slicedData.sort((a, b) => a.id - b.id); // Сортировка по значению item.id
    slicedData.forEach(item => {
      var row = document.createElement("tr");
      row.innerHTML = `
        <td>${item.id}</td>
        <td>${item.category.recordDate}</td>
        <td>${item.category.branchId}</td>
        <td>${item.category.cropYear}</td>
        <td>${item.category.counterpartyId}</td>
        <td>${item.category.counterpartyName}</td>
        <td>${item.category.contactId}</td>
        <td>${item.category.product}</td>
        <td>${item.category.price}</td>
        <td>${item.category.process}</td>
        <td>${item.amount}</td>
        <td>${item.category.wetness}</td>
        <td>${item.category.garbage}</td>
        <td>${item.category.infection}</td>
      `;
      tbody2.appendChild(row);
    });
  });

  fetch('https://localhost:7269/viewtable3', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(response => {
    return response.json(); 
  }).then(data => {
    const slicedData = data.slice(); 
    slicedData.sort((a, b) => a.id - b.id); // Сортировка по значению item.id
    slicedData.forEach(item => {
      var row = document.createElement("tr");
      row.innerHTML = `
        <td>${item.id}</td>
        <td>${item.category.recordDate}</td>
        <td>${item.category.branchId}</td>
        <td>${item.category.counterpartyId}</td>
        <td>${item.category.counterpartyName}</td>
        <td>${item.category.contactId}</td>
        <td>${item.category.product}</td>
        <td>${item.category.price}</td>
        <td>${item.category.process}</td>
        <td>${item.amount}</td>
        <td>${item.avgWetness}</td>
        <td>${item.avgGarbage}</td>
        <td>${item.infection}</td>
      `;
      tbody3.appendChild(row);
    });
  });
});
