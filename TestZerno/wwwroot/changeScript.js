document.addEventListener('DOMContentLoaded', function() {
    var changeForm = document.getElementById('changeForm');
    var messageElement = document.getElementById('message');
    var button1 = document.getElementById('button1');



    button1.addEventListener('click', function() {
        window.location.href = "main.html";
      });
    changeForm.addEventListener('submit', function(event) {
        event.preventDefault(); 

        var id = document.getElementById('id').value;
        var amount = document.getElementById('amount').value;
        var wetness = document.getElementById('wetness').value || null; 
        var garbage = document.getElementById('garbage').value || null; 
        var infection = document.getElementById('infection').value || null; 

        var data = {
            id: id,
            amount: amount,
            wetness: wetness,
            garbage: garbage,
            infection: infection
        };

        fetch('https://localhost:7269/change', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({id: id, amount: amount, wetness: wetness, garbage: garbage,infection: infection})
        })
        .then(function(response) {
            if (response.ok) {
                messageElement.textContent = 'Дані успішно змінені.';
                messageElement.style.color = 'green';
            } else {
                messageElement.textContent = 'Помилка при зміні даних.';
                messageElement.style.color = 'red';
            }
        })
        .catch(function(error) {
            console.log(error);
            messageElement.textContent = 'Сталася помилка при виконані запиту.';
            messageElement.style.color = 'red';
        });
    });
});
