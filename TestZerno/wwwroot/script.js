document.addEventListener('DOMContentLoaded', function() {
    var button1 = document.getElementById('button1');
    var button2 = document.getElementById('button2');
    var button3 = document.getElementById('button3');

    button1.addEventListener('click', function() {
      window.location.href = "view.html";
    });
  
    button2.addEventListener('click', function() {
      window.location.href = "change.html";
    });
    button3.addEventListener('click', function() {
      window.location.href = "delete.html";
    });
    function fetchDataFromServer(datas) {
      fetch(datas, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        }
      }).then(response => {
        return response.json(); 
      })
        .then(data => {
          const slicedData = data.slice(); 
         console.log(slicedData);
          
          return slicedData;
        });
    }
    
  });