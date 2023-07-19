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

        fetch('https://localhost:7269/delete', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({id: id})
        })
        .then(function(response) {
            if (response.ok) {
                messageElement.textContent = 'Дані успішно видалені.';
                messageElement.style.color = 'green';
            } else {
                messageElement.textContent = 'Помилка при видалені даних.';
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
