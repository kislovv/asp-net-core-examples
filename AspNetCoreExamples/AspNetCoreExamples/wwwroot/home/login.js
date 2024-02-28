document.getElementById("loginForm").addEventListener("submit", async (event) => {
    event.preventDefault();
    var myFormData = new FormData(event.target);

    var user = {};
    myFormData.forEach((value, key) => (user[key] = value));
    console.log(user);

    let response = await fetch('/signin', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user)
    });

    if (response.ok) {
        window.resultMessage.innerText = "Вы успешно вошли в систему. " +
            "Через пару секунд вы будете перенаправлены на страницу авторизации";
        setTimeout(function () {
            window.location.href = "/home";
        }, 2000);
    }
    else {
        window.resultMessage.innerText = `Неверно введен логин или пароль.` +
            `Информация по ошибке ${result.message}`;
    }
});